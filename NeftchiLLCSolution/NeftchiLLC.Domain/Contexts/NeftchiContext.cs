using Microsoft.EntityFrameworkCore;

namespace NeftchiLLC.Domain.Contexts
{
	class NeftchiContext : DbContext
	{
		public NeftchiContext(DbContextOptions options)
			: base(options)
		{
			
		}
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);

			modelBuilder.ApplyConfigurationsFromAssembly(typeof(NeftchiContext).Assembly);
		}
	}
}
