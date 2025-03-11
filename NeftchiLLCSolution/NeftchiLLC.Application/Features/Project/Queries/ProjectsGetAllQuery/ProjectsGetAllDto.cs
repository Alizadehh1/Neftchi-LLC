using NeftchiLLC.Application.Dtos;

namespace NeftchiLLC.Application.Features.Project.Queries.ProjectsGetAllQuery
{
	public class ProjectsGetAllDto
	{
		public int Id { get; set; }
		public string OrganisationShortName { get; set; }
		public DocumentFileGetAllDto File { get; set; }
	}
}
