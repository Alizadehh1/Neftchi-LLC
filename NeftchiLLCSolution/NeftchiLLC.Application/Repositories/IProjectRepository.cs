using Intelect.Infrastructure.Core.Common;
using NeftchiLLC.Domain.Models.Entities;
using System.Linq.Expressions;

namespace NeftchiLLC.Application.Repositories
{
	public interface IProjectRepository : IAsyncRepository<Project>
	{
		IQueryable<ProjectFile> GetFiles(Expression<Func<ProjectFile, bool>> expression = null);
		Task<IEnumerable<ProjectFile>> AddFilesAsync(Project project, IEnumerable<ProjectFile> files, CancellationToken cancellationToken = default);
		Task RemoveFileAsync(ProjectFile file, CancellationToken cancellationToken = default);
	}
}
