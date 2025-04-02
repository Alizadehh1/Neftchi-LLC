using NeftchiLLC.Application.Dtos;

namespace NeftchiLLC.Application.Features.Portfolio.Queries.PortfoliosGetAllRequest
{
	public class PortfolioGetAllDto
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }
		public List<DocumentFileGetAllDto> Files { get; set; }
	}
}
