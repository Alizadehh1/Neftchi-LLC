using Intelect.Infrastructure.Core.Common;
using Microsoft.EntityFrameworkCore;
using NeftchiLLC.Application.Repositories;
using NeftchiLLC.Domain.Models.Entities;

namespace NeftchiLLC.Repositories.Concrete
{
	class ActivitiesRepository : AsyncRepository<Activities>, IActivitiesRepository
	{
		public ActivitiesRepository(DbContext db) : base(db)
		{
		}
	}
}
