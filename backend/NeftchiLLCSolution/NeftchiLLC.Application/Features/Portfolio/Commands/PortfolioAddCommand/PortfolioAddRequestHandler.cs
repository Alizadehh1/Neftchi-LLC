using MediatR;
using NeftchiLLC.Application.Repositories;
using NeftchiLLC.Application.Services;
using NeftchiLLC.Domain.Models.Entities;

namespace NeftchiLLC.Application.Features.Portfolio.Commands.PortfolioAddCommand
{
	class PortfolioAddRequestHandler(IPortfolioRepository portfolioRepository, AzureBlobService azureBlobService) : IRequestHandler<PortfolioAddRequest, Domain.Models.Entities.Portfolio>
	{
		public async Task<Domain.Models.Entities.Portfolio> Handle(PortfolioAddRequest request, CancellationToken cancellationToken)
		{
			var portfolio = new Domain.Models.Entities.Portfolio
			{
				Name = request.Name,
				Description = request.Description,
			};

			await portfolioRepository.AddAsync(portfolio, cancellationToken);
			await portfolioRepository.SaveAsync(cancellationToken);

			var files = await Task.WhenAll(request.Files.Select(async m =>
			{
				var uploadedPath = await azureBlobService.UploadAsync(m.File);
				return new PortfolioFile
				{
					Name = Path.GetFileNameWithoutExtension(uploadedPath),
					PortfolioId = portfolio.Id,
					IsMain = m.IsMain,
					Path = uploadedPath,
				};
			}));

			await portfolioRepository.AddFilesAsync(portfolio, files, cancellationToken);
			await portfolioRepository.SaveAsync(cancellationToken);

			return portfolio;
		}
	}
}
