using Intelect.Infrastructure.Core.Common;
using Microsoft.EntityFrameworkCore;
using NeftchiLLC.Application.Repositories;
using NeftchiLLC.Domain.Models.Entities;

namespace NeftchiLLC.Repositories.Concrete
{
	class EquipmentRepository : AsyncRepository<Equipment>, IEquipmentRepository
	{
		public EquipmentRepository(DbContext db) : base(db)
		{
		}
	}
}
