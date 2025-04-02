using MediatR;

namespace NeftchiLLC.Application.Features.Portfolio.Commands.PortfolioRemoveCommand
{
	public class PortfolioRemoveRequest : IRequest
	{
		public int Id { get; set; }
	}
}
