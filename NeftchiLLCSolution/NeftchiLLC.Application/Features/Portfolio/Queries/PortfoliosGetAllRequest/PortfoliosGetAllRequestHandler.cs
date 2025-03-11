using MediatR;
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

			var query = from d in portfolios
						join f in files on d.Id equals f.PortfolioId
						select new PortfolioGetAllDto
						{
							Id = d.Id,
							Name = d.Name,
							File = new DocumentFileGetAllDto
							{
								Id = f.Id,
								Name = f.Name,
								Path = f.Path,
							},
						};

			return query;
		}
	}
}
