using MediatR;
using NeftchiLLC.Application.Dtos;

namespace NeftchiLLC.Application.Features.Portfolio.Commands.PortfolioAddCommand
{
	public class PortfolioAddRequest : IRequest<Domain.Models.Entities.Portfolio>
	{
		public string Name { get; set; }
		public string Description { get; set; }
		public required List<DocumentAddFileDto> Files { get; set; }
	}
}
