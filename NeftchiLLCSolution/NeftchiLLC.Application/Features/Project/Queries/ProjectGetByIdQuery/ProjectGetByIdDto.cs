using NeftchiLLC.Application.Dtos;

namespace NeftchiLLC.Application.Features.Project.Queries.ProjectGetByIdQuery
{
	public class ProjectGetByIdDto
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string OrganisationName { get; set; }
		public string Description { get; set; }
		public int? EmployeeNumber { get; set; }
		public string Date { get; set; }
		public DateTime? DeliveryDate { get; set; }
		public string Materials { get; set; }
		public List<DocumentFileGetByIdDto> Files { get; set; }
	}
}
