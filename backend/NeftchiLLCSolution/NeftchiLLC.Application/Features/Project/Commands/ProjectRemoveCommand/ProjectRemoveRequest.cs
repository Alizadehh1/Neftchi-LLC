using MediatR;

namespace NeftchiLLC.Application.Features.Project.Commands.ProjectRemoveCommand
{
	public class ProjectRemoveRequest : IRequest
	{
		public int Id { get; set; }
	}
}
