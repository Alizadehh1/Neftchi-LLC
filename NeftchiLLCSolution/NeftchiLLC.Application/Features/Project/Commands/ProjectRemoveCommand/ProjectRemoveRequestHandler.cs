using MediatR;
using NeftchiLLC.Application.Repositories;

namespace NeftchiLLC.Application.Features.Project.Commands.ProjectRemoveCommand
{
	class ProjectRemoveRequestHandler(IProjectRepository projectRepository) : IRequestHandler<ProjectRemoveRequest>
	{
		public async Task Handle(ProjectRemoveRequest request, CancellationToken cancellationToken)
		{
			var entity = await projectRepository.GetAsync(d => d.Id == request.Id && d.DeletedAt == null, cancellationToken: cancellationToken);

			projectRepository.Remove(entity);
			await projectRepository.SaveAsync(cancellationToken);
		}
	}
}
