using MediatR;
using NeftchiLLC.Application.Dtos;
using NeftchiLLC.Application.Repositories;

namespace NeftchiLLC.Application.Features.Project.Queries.ProjectsGetAllQuery
{
	class ProjectsGetAllRequestHandler(IProjectRepository projectRepository) : IRequestHandler<ProjectsGetAllRequest, IEnumerable<ProjectsGetAllDto>>
	{
		public async Task<IEnumerable<ProjectsGetAllDto>> Handle(ProjectsGetAllRequest request, CancellationToken cancellationToken)
		{
			var entities = projectRepository.GetAll(d => d.DeletedAt == null);
			var files = projectRepository.GetFiles(d => d.DeletedAt == null && d.IsMain);

			var query = from d in entities
						join f in files on d.Id equals f.ProjectId
						select new ProjectsGetAllDto
						{
							Id = d.Id,
							OrganisationShortName = d.OrganisationShortName,
							File = new DocumentFileGetAllDto
							{
								Id = f.Id,
								IsMain = true,
								Name = f.Name,
								Path = f.Path,
							}
						};

			return query;
		}
	}
}
