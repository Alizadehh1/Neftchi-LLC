using Intelect.Infrastructure.Core.Common;
using Microsoft.EntityFrameworkCore;
using NeftchiLLC.Application.Repositories;
using NeftchiLLC.Domain.Models.Entities;

namespace NeftchiLLC.Repositories.Concrete
{
	class ServiceRepository : AsyncRepository<Service>, IServiceRepository
	{
		public ServiceRepository(DbContext db) : base(db)
		{
		}
	}
}
