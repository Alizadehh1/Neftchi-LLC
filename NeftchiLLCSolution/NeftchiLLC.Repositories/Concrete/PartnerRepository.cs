using Intelect.Infrastructure.Core.Common;
using Microsoft.EntityFrameworkCore;
using NeftchiLLC.Application.Repositories;
using NeftchiLLC.Domain.Models.Entities;

namespace NeftchiLLC.Repositories.Concrete
{
	class PartnerRepository : AsyncRepository<Partner>, IPartnerRepository
	{
		public PartnerRepository(DbContext db) : base(db)
		{
		}
	}
}
