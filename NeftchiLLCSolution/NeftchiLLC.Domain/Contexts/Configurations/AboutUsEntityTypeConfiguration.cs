using Intelect.Infrastructure.Core.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NeftchiLLC.Domain.Models.Entities;

namespace NeftchiLLC.Domain.Contexts.Configurations
{
	class AboutUsEntityTypeConfiguration : IEntityTypeConfiguration<AboutUs>
	{
		public void Configure(EntityTypeBuilder<AboutUs> builder)
		{
			builder.Property(m => m.Id).HasColumnType("int").UseIdentityColumn(1, 1);
			builder.Property(m => m.Title).HasColumnType("nvarchar").HasMaxLength(100).IsRequired();
			builder.Property(m => m.ImagePath).HasColumnType("nvarchar").HasMaxLength(100).IsRequired();
			builder.Property(m => m.Content).HasColumnType("LONGTEXT").IsRequired();

			builder.ConfigureAuditable();

			builder.HasKey(m => m.Id);
			builder.ToTable("AboutUses");
		}
	}
}
