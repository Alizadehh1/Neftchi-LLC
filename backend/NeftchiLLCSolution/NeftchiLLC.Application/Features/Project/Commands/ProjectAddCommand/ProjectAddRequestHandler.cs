﻿using Intelect.Infrastructure.Core.Services;
using MediatR;
using NeftchiLLC.Application.Repositories;
using NeftchiLLC.Application.Services;
using NeftchiLLC.Domain.Models.Entities;

namespace NeftchiLLC.Application.Features.Project.Commands.ProjectAddCommand
{
	class ProjectAddRequestHandler(IProjectRepository projectRepository, IFileService fileService, FtpFileService ftpFileService) : IRequestHandler<ProjectAddRequest, Domain.Models.Entities.Project>
	{
		public async Task<Domain.Models.Entities.Project> Handle(ProjectAddRequest request, CancellationToken cancellationToken)
		{
			var entity = new Domain.Models.Entities.Project
			{
				Name = request.Name,
				OrganisationName = request.OrganisationName,
				OrganisationShortName = request.OrganisationShortName,
				Description = request.Description,
				Date = request.Date,
				Materials = request.Materials,
				EmployeeNumber = request.EmployeeNumber,
				DeliveryDate = request.DeliveryDate,
			};

			await projectRepository.AddAsync(entity,cancellationToken);
			await projectRepository.SaveAsync(cancellationToken);

			var files = request.Files.Select(m =>
			{
				var uploadedPath = ftpFileService.Upload(m.File);
				return new ProjectFile
				{
					Name = Path.GetFileNameWithoutExtension(uploadedPath),
					ProjectId = entity.Id,
					IsMain = m.IsMain,
					Path = uploadedPath,
				};
			});

			await projectRepository.AddFilesAsync(entity, files, cancellationToken);
			await projectRepository.SaveAsync(cancellationToken);

			return entity;
		}
	}
}
