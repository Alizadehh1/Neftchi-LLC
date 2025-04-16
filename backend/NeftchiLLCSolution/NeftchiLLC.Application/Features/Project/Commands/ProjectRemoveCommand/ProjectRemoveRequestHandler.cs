using MediatR;
using NeftchiLLC.Application.Repositories;
using NeftchiLLC.Application.Services;

namespace NeftchiLLC.Application.Features.Project.Commands.ProjectRemoveCommand
{
	class ProjectRemoveRequestHandler(IProjectRepository projectRepository, AzureBlobService azureBlobService) : IRequestHandler<ProjectRemoveRequest>
	{
		public async Task Handle(ProjectRemoveRequest request, CancellationToken cancellationToken)
		{
			var entity = await projectRepository.GetAsync(d => d.Id == request.Id && d.DeletedAt == null, cancellationToken: cancellationToken);
			var documentFiles = projectRepository.GetFiles(d => d.ProjectId == entity.Id && d.DeletedAt == null).ToList();
			foreach (var file in documentFiles)
			{
				await projectRepository.RemoveFileAsync(file, cancellationToken);
				await azureBlobService.RemoveAsync(file.Path);
			}
			projectRepository.Remove(entity);
			await projectRepository.SaveAsync(cancellationToken);
		}
	}
}
