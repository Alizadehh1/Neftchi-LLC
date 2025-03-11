﻿using Intelect.Application.Core.Services;
using Intelect.Infrastructure.Core.Services;
using MediatR;
using NeftchiLLC.Application.Repositories;
using NeftchiLLC.Domain.Models.Entities;

namespace NeftchiLLC.Application.Features.Portfolio.Commands.PortfolioAddCommand
{
	class PortfolioAddRequestHandler(IFileService fileService, IPortfolioRepository portfolioRepository, LocalFileService localFileService) : IRequestHandler<PortfolioAddRequest, Domain.Models.Entities.Portfolio>
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

			var files = await Task.WhenAll(request.Files.Select(async m => new PortfolioFile
			{
				Name = Path.GetFileNameWithoutExtension(fileService.UploadAsync(m.File).Result),
				PortfolioId = portfolio.Id,
				IsMain = m.IsMain,
				Path = await localFileService.UploadAsync(m.File),
			}));

			await portfolioRepository.AddFilesAsync(portfolio, files, cancellationToken);
			await portfolioRepository.SaveAsync(cancellationToken);

			return portfolio;
		}
	}
}
