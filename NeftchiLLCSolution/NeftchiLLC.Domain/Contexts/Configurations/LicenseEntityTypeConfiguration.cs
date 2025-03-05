using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NeftchiLLC.Domain.Models;

namespace NeftchiLLC.Domain.Contexts.Configurations
{
	class LicenseEntityTypeConfiguration : IEntityTypeConfiguration<License>
	{
		public void Configure(EntityTypeBuilder<License> builder)
		{
			builder.Property(m => m.Id).HasColumnType("int").UseIdentityColumn(1, 1);
			builder.Property(m => m.Name).HasColumnType("nvarchar").HasMaxLength(50).IsRequired();

			builder.HasKey(m => m.Id);
			builder.ToTable("Licenses");
		}
	}
}
