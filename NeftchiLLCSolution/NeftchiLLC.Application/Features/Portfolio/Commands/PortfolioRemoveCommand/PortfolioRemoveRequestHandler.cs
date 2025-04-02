using MediatR;
using NeftchiLLC.Application.Repositories;

namespace NeftchiLLC.Application.Features.Portfolio.Commands.PortfolioRemoveCommand
{
	class PortfolioRemoveRequestHandler(IPortfolioRepository portfolioRepository) : IRequestHandler<PortfolioRemoveRequest>
	{
		public async Task Handle(PortfolioRemoveRequest request, CancellationToken cancellationToken)
		{
			var portfolio = await portfolioRepository.GetAsync(d => d.DeletedAt == null && d.Id == request.Id, cancellationToken: cancellationToken);
			var portfolioFiles = portfolioRepository.GetFiles(d => d.PortfolioId == portfolio.Id && d.DeletedAt == null);
			portfolioRepository.Remove(portfolio);

			foreach (var file in portfolioFiles)
				await portfolioRepository.RemoveFileAsync(file, cancellationToken);
			await portfolioRepository.SaveAsync(cancellationToken);
		}
	}
}
