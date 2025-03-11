using MediatR;
using NeftchiLLC.Application.Dtos;

namespace NeftchiLLC.Application.Features.Portfolio.Queries.PortfolioGetByIdQuery
{
	public class PortfolioGetByIdRequest : IRequest<PortfolioGetByIdDto>
	{
		public int Id { get; set; }
	}
}
