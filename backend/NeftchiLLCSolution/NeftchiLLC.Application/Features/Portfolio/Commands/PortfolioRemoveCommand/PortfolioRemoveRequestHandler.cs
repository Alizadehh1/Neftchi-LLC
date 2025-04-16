using MediatR;
using NeftchiLLC.Application.Repositories;
using NeftchiLLC.Application.Services;

namespace NeftchiLLC.Application.Features.Portfolio.Commands.PortfolioRemoveCommand
{
	class PortfolioRemoveRequestHandler(IPortfolioRepository portfolioRepository, AzureBlobService azureBlobService) : IRequestHandler<PortfolioRemoveRequest>
	{
		public async Task Handle(PortfolioRemoveRequest request, CancellationToken cancellationToken)
		{
			var portfolio = await portfolioRepository.GetAsync(d => d.DeletedAt == null && d.Id == request.Id, cancellationToken: cancellationToken);
			var portfolioFiles = portfolioRepository.GetFiles(d => d.PortfolioId == portfolio.Id && d.DeletedAt == null).ToList();
			foreach (var file in portfolioFiles)
			{
				await portfolioRepository.RemoveFileAsync(file, cancellationToken);
				await azureBlobService.RemoveAsync(file.Path);
			}
			portfolioRepository.Remove(portfolio);

			await portfolioRepository.SaveAsync(cancellationToken);
		}
	}
}
