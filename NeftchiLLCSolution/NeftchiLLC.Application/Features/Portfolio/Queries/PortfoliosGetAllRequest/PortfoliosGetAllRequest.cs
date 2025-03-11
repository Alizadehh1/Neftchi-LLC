using MediatR;
using NeftchiLLC.Application.Dtos;

namespace NeftchiLLC.Application.Features.Portfolio.Queries.PortfoliosGetAllRequest
{
	public class PortfoliosGetAllRequest : IRequest<IEnumerable<PortfolioGetAllDto>>
	{
	}
}
