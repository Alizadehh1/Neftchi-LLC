using Intelect.Infrastructure.Core.Common;
using NeftchiLLC.Domain.Models.Entities;
using System.Linq.Expressions;

namespace NeftchiLLC.Application.Repositories
{
	public interface IPortfolioRepository : IAsyncRepository<Portfolio>
	{
		IQueryable<PortfolioFile> GetFiles(Expression<Func<PortfolioFile, bool>> expression = null);
		Task<IEnumerable<PortfolioFile>> AddFilesAsync(Portfolio portfolio, IEnumerable<PortfolioFile> files, CancellationToken cancellationToken = default);
		Task RemoveFileAsync(PortfolioFile file, CancellationToken cancellationToken = default);
	}
}
