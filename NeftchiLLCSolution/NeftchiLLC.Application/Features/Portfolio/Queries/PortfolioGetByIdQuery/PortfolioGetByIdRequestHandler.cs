using MediatR;
using NeftchiLLC.Application.Dtos;
using NeftchiLLC.Application.Repositories;

namespace NeftchiLLC.Application.Features.Portfolio.Queries.PortfolioGetByIdQuery
{
	class PortfolioGetByIdRequestHandler(IPortfolioRepository portfolioRepository) : IRequestHandler<PortfolioGetByIdRequest, PortfolioGetByIdDto>
	{
		public async Task<PortfolioGetByIdDto> Handle(PortfolioGetByIdRequest request, CancellationToken cancellationToken)
		{
			var portfolio = await portfolioRepository.GetAsync(d =>d.DeletedAt == null && d.Id == request.Id, cancellationToken: cancellationToken);

			var files = portfolioRepository.GetFiles(d => d.DeletedAt == null && d.PortfolioId == portfolio.Id);

			var result = new PortfolioGetByIdDto
			{
				Id = portfolio.Id,
				Name = portfolio.Name,
				Files = files.Select(d => new DocumentFileGetByIdDto
				{
					Id = d.Id,
					Name = d.Name,
					Path = d.Path,
					IsMain = d.IsMain
				}).ToList()
			};

			return result;
		}
	}
}
