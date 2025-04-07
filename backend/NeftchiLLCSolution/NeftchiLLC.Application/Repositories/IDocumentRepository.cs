using Intelect.Infrastructure.Core.Common;
using NeftchiLLC.Domain.Models.Entities;
using System.Linq.Expressions;

namespace NeftchiLLC.Application.Repositories
{
	public interface IDocumentRepository : IAsyncRepository<Document>
	{
		IQueryable<DocumentFile> GetFiles(Expression<Func<DocumentFile, bool>> expression = null);
		Task<IEnumerable<DocumentFile>> AddFilesAsync(Document document, IEnumerable<DocumentFile> files, CancellationToken cancellationToken = default);
		Task RemoveFileAsync(DocumentFile file, CancellationToken cancellationToken = default);
	}
}
