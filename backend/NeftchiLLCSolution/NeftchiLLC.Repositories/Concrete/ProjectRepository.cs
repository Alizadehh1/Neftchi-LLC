using Intelect.Infrastructure.Core.Common;
using Microsoft.EntityFrameworkCore;
using MongoDB.Driver.Linq;
using NeftchiLLC.Application.Repositories;
using NeftchiLLC.Domain.Models.Entities;
using System.Linq.Expressions;

namespace NeftchiLLC.Repositories.Concrete
{
	class ProjectRepository : AsyncRepository<Project>, IProjectRepository
	{
		public ProjectRepository(DbContext db) : base(db)
		{
		}

		public async Task<IEnumerable<ProjectFile>> AddFilesAsync(Project project, IEnumerable<ProjectFile> files, CancellationToken cancellationToken = default)
		{
			var projectFilesTable = db.Set<ProjectFile>();
			await projectFilesTable.AddRangeAsync(files, cancellationToken);
			return await Task.FromResult(files);
		}

		public IQueryable<ProjectFile> GetFiles(Expression<Func<ProjectFile, bool>> expression = null)
		{
			var query = db.Set<ProjectFile>().AsQueryable();

			if (expression != null)
			{
				query = query.Where(expression);
			}

			return query;
		}

		public async Task RemoveFileAsync(ProjectFile file, CancellationToken cancellationToken = default)
		{
			var existingFile = await db.Set<ProjectFile>().FindAsync(file.Id);
			if (existingFile != null)
			{
				db.Set<ProjectFile>().Remove(existingFile);
				await db.SaveChangesAsync(cancellationToken);
			}
			else
			{
				throw new InvalidOperationException("File does not exist.");
			}
		}
	}
}
