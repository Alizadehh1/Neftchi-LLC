using NeftchiLLC.Application.Dtos;

namespace NeftchiLLC.Application.Features.Portfolio.Queries.PortfolioGetByIdQuery
{
	public class PortfolioGetByIdDto
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }
		public List<DocumentFileGetByIdDto> Files { get; set; }
	}
}
