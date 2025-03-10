using MediatR;

namespace NeftchiLLC.Application.Features.Project.Queries.ProjectGetByIdQuery
{
	public class ProjectGetByIdRequest : IRequest<ProjectGetByIdDto>
	{
		public int Id { get; set; }
	}
}
