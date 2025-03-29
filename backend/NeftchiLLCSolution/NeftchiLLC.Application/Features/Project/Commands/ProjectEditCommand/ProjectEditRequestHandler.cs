using Intelect.Application.Core.Services;
using Intelect.Infrastructure.Core.Services;
using MediatR;
using NeftchiLLC.Application.Repositories;
using NeftchiLLC.Domain.Models.Entities;

namespace NeftchiLLC.Application.Features.Project.Commands.ProjectEditCommand
{
	class ProjectEditRequestHandler(IProjectRepository projectRepository,IFileService fileService,LocalFileService localFileService) : IRequestHandler<ProjectEditRequest>
	{
		public async Task Handle(ProjectEditRequest request, CancellationToken cancellationToken)
		{
			var entity = await projectRepository.GetAsync(d => d.Id == request.Id && d.DeletedAt == null, cancellationToken: cancellationToken);

			entity.Name = request.Name;
			entity.OrganisationName = request.OrganisationName;
			entity.OrganisationShortName = request.OrganisationShortName;
			entity.Description = request.Description;
			entity.Date = request.Date;
			entity.Materials = request.Materials;
			entity.EmployeeNumber = request.EmployeeNumber;
			entity.DeliveryDate = request.DeliveryDate;

			#region Files

			var existingFiles = projectRepository.GetFiles(d => d.ProjectId == request.Id && d.DeletedAt == null).ToList();

			foreach (var requestFile in request.Files)
			{
				var existingFile = existingFiles.FirstOrDefault(ef => ef.Id == requestFile.Id);

				if (existingFile != null)
				{
					bool needsUpdate = false;

					if (existingFile.IsMain != requestFile.IsMain)
					{
						existingFile.IsMain = requestFile.IsMain;
						needsUpdate = true;
					}

					if (needsUpdate)
					{
						await projectRepository.SaveAsync(cancellationToken);
					}
				}
			}

			var filesToAdd = request.Files.Where(newFile => !existingFiles.Any(existingFile => existingFile.Id == newFile.Id)).ToList();
			// Fetch existing files into memory
			var existingFilesList = existingFiles.ToList();

			// Compute files to delete in memory
			var filesToDelete = existingFilesList
				.Where(existingFile => !request.Files.Any(newFile => newFile.Id == existingFile.Id))
				.ToList();


			#region RemoveUnnecessaryFiles

			foreach (var file in filesToDelete)
				await projectRepository.RemoveFileAsync(file);


			#endregion
			#region Add new files

			var newFiles = await Task.WhenAll(filesToAdd.Select(async m => new ProjectFile
			{
				Name = Path.GetFileNameWithoutExtension(fileService.UploadAsync(m.File).Result),
				ProjectId = entity.Id,
				IsMain = m.IsMain,
				Path = await localFileService.UploadAsync(m.File),
			}));

			#endregion

			await projectRepository.AddFilesAsync(entity, newFiles, cancellationToken);
			await projectRepository.SaveAsync(cancellationToken);

			#endregion

			await projectRepository.SaveAsync(cancellationToken);
		}
	}
}
