using Intelect.Infrastructure.Core.Common;
using Intelect.Infrastructure.Core.Services;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using NeftchiLLC.Domain.Models.Entities;
using NeftchiLLC.Domain.Models.Membership;

namespace NeftchiLLC.Domain.Contexts
{
	public class NeftchiContext : IdentityDbContext<NeftchiUser>
	{
		private readonly IDateTimeService dateTimeService;

		public NeftchiContext(DbContextOptions options, IDateTimeService dateTimeService)
			: base(options)
		{
			this.dateTimeService = dateTimeService;
		}
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);

			modelBuilder.ApplyConfigurationsFromAssembly(typeof(NeftchiContext).Assembly);
		}
        public DbSet<Translation> Translations { get; set; }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
		{
			var changes = this.ChangeTracker.Entries<IAuditableEntity>();

			if (changes != null)
			{
				foreach (var entry in changes.Where(m => m.State == EntityState.Added
				|| m.State == EntityState.Modified
				|| m.State == EntityState.Deleted))
				{
					switch (entry.State)
					{
						case EntityState.Added:
							//entry.Entity.CreatedBy = identityService.GetPrincipalId();
							entry.Entity.CreatedAt = dateTimeService.ExecutingTime;
							break;
						case EntityState.Modified:
							entry.Property(m => m.CreatedBy).IsModified = false;
							entry.Property(m => m.CreatedAt).IsModified = false;
							//entry.Entity.LastModifiedBy = identityService.GetPrincipalId();
							entry.Entity.LastModifiedAt = dateTimeService.ExecutingTime;
							break;
						case EntityState.Deleted:
							entry.State = EntityState.Modified;
							entry.Property(m => m.CreatedBy).IsModified = false;
							entry.Property(m => m.CreatedAt).IsModified = false;
							entry.Property(m => m.LastModifiedBy).IsModified = false;
							entry.Property(m => m.LastModifiedAt).IsModified = false;
							//entry.Entity.DeletedBy = identityService.GetPrincipalId();
							entry.Entity.DeletedAt = dateTimeService.ExecutingTime;
							break;
						default:
							break;
					}
				}
			}

			return base.SaveChangesAsync(cancellationToken);
		}
	}
}
