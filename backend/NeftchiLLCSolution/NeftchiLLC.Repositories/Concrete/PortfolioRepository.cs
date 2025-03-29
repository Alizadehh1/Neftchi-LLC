using Intelect.Infrastructure.Core.Common;
using Microsoft.EntityFrameworkCore;
using MongoDB.Driver.Linq;
using NeftchiLLC.Application.Repositories;
using NeftchiLLC.Domain.Models.Entities;
using System.Linq.Expressions;

namespace NeftchiLLC.Repositories.Concrete
{
	class PortfolioRepository : AsyncRepository<Portfolio>, IPortfolioRepository
	{
		public PortfolioRepository(DbContext db) : base(db)
		{
		}

		public async Task<IEnumerable<PortfolioFile>> AddFilesAsync(Portfolio portfolio, IEnumerable<PortfolioFile> files, CancellationToken cancellationToken = default)
		{
			var portfolioFilesTable = db.Set<PortfolioFile>();
			await portfolioFilesTable.AddRangeAsync(files, cancellationToken);
			return await Task.FromResult(files);
		}

		public IQueryable<PortfolioFile> GetFiles(Expression<Func<PortfolioFile, bool>> expression = null)
		{
			var query = db.Set<PortfolioFile>().AsQueryable();

			if (expression != null)
			{
				query = query.Where(expression);
			}

			return query;
		}

		public async Task RemoveFileAsync(PortfolioFile file, CancellationToken cancellationToken = default)
		{
			var existingFile = await db.Set<PortfolioFile>().FindAsync(file.Id);
			if (existingFile != null)
			{
				db.Set<PortfolioFile>().Remove(existingFile);
				await db.SaveChangesAsync(cancellationToken);
			}
			else
			{
				throw new InvalidOperationException("File does not exist.");
			}
		}
	}
}
