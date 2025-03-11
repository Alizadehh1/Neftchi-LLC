using MediatR;
using NeftchiLLC.Application.Dtos;

namespace NeftchiLLC.Application.Features.Portfolio.Commands.PortfolioEditCommand
{
	public class PortfolioEditRequest : IRequest<string>
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }
		public List<DocumentAddFileDto> Files { get; set; }
	}
}
