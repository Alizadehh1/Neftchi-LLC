using MediatR;
using NeftchiLLC.Application.Dtos;
using NeftchiLLC.Application.Repositories;

namespace NeftchiLLC.Application.Features.Project.Queries.ProjectGetByIdQuery
{
	class ProjectGetByIdRequestHandler(IProjectRepository projectRepository) : IRequestHandler<ProjectGetByIdRequest, ProjectGetByIdDto>
	{
		public async Task<ProjectGetByIdDto> Handle(ProjectGetByIdRequest request, CancellationToken cancellationToken)
		{
			var entity = await projectRepository.GetAsync(d => d.Id == request.Id && d.DeletedAt == null, cancellationToken: cancellationToken);
			var files = projectRepository.GetFiles(d => d.DeletedAt == null && d.ProjectId == entity.Id);

			var result = new ProjectGetByIdDto
			{
				Id = entity.Id,
				Name = entity.Name,
				Date = entity.Date,
				DeliveryDate = entity.DeliveryDate,
				Description = entity.Description,
				EmployeeNumber = entity.EmployeeNumber,
				Materials = entity.Materials,
				OrganisationName = entity.OrganisationName,
				Files = files.Select(d => new DocumentFileGetByIdDto
				{
					Id = d.Id,
					Name = d.Name,
					Path = d.Path,
					IsMain = d.IsMain,
				}).ToList()
			};

			return result;
		}
	}
}
