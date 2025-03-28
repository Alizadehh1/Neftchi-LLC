using MediatR;
using Microsoft.EntityFrameworkCore;
using NeftchiLLC.Application.Dtos;
using NeftchiLLC.Application.Repositories;

namespace NeftchiLLC.Application.Features.Portfolio.Queries.PortfoliosGetAllRequest
{
	class PortfoliosGetAllRequestHandler(IPortfolioRepository portfolioRepository) : IRequestHandler<PortfoliosGetAllRequest, IEnumerable<PortfolioGetAllDto>>
	{
		public async Task<IEnumerable<PortfolioGetAllDto>> Handle(PortfoliosGetAllRequest request, CancellationToken cancellationToken)
		{
			var portfolios = portfolioRepository.GetAll(d => d.DeletedAt == null);
			var files = portfolioRepository.GetFiles(d => d.DeletedAt == null);

			return await portfolios.Select(f => new PortfolioGetAllDto
			{
				Files = files.Where(x => x.PortfolioId == f.Id).Select(d => new DocumentFileGetAllDto
				{
					IsMain = d.IsMain,
					Name = d.Name,
					Path = d.Path,
					Id = d.Id,
				}).ToList(),
				Name = f.Name,
				Description = f.Description,
				Id = f.Id,
			}).ToListAsync(cancellationToken);
		}
	}
}
