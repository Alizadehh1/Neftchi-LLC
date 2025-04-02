using MediatR;

namespace NeftchiLLC.Application.Features.Project.Queries.ProjectsGetAllQuery
{
	public class ProjectsGetAllRequest : IRequest<IEnumerable<ProjectsGetAllDto>>
	{
	}
}
