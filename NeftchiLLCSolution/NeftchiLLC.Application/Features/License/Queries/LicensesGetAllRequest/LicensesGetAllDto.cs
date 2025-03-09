using NeftchiLLC.Application.Dtos;

namespace NeftchiLLC.Application.Features.License.Queries.LicensesGetAllRequest
{
	public class LicensesGetAllDto
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public DocumentGetDto File { get; set; }
	}
}
