using Intelect.Infrastructure.Core.Common;
using Microsoft.EntityFrameworkCore;
using NeftchiLLC.Application.Repositories;
using NeftchiLLC.Domain.Models.Entities;
using System.Linq.Expressions;

namespace NeftchiLLC.Repositories.Concrete
{
	class DocumentRepository : AsyncRepository<Document>, IDocumentRepository
	{
		public DocumentRepository(DbContext db) : base(db)
		{
			
		}
		public async Task<IEnumerable<DocumentFile>> AddFilesAsync(Document document, IEnumerable<DocumentFile> files, CancellationToken cancellationToken = default)
		{
			var docFilesTable = db.Set<DocumentFile>();
			await docFilesTable.AddRangeAsync(files, cancellationToken);
			return await Task.FromResult(files);
		}

		public IQueryable<DocumentFile> GetFiles(Expression<Func<DocumentFile, bool>> expression = null)
		{
			var query = db.Set<DocumentFile>().AsQueryable();

			if (expression != null)
			{
				query = query.Where(expression);
			}

			return query;
		}

		public async Task RemoveFileAsync(DocumentFile file, CancellationToken cancellationToken = default)
		{
			var existingFile = await db.Set<DocumentFile>().FindAsync(file.Id);
			if (existingFile != null)
			{
				db.Set<DocumentFile>().Remove(existingFile);
				await db.SaveChangesAsync(cancellationToken);
			}
			else
			{
				throw new InvalidOperationException("File does not exist.");
			}
		}
	}
}
