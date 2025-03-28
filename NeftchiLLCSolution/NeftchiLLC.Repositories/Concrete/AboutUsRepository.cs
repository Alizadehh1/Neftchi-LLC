using Intelect.Infrastructure.Core.Common;
using Microsoft.EntityFrameworkCore;
using NeftchiLLC.Application.Repositories;
using NeftchiLLC.Domain.Models.Entities;

namespace NeftchiLLC.Repositories.Concrete
{
	class AboutUsRepository : AsyncRepository<AboutUs>, IAboutUsRepository
	{
		public AboutUsRepository(DbContext db) : base(db)
		{
		}
	}
}
