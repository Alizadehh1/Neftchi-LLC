using Intelect.Infrastructure.Core.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NeftchiLLC.Domain.Models.Entities;

namespace NeftchiLLC.Domain.Contexts.Configurations
{
	class PartnerEntityTypeConfiguration : IEntityTypeConfiguration<Partner>
	{
		public void Configure(EntityTypeBuilder<Partner> builder)
		{

			builder.Property(m => m.Id).HasColumnType("int").UseIdentityColumn(1, 1);
			builder.Property(m => m.Name).HasColumnType("nvarchar").HasMaxLength(100).IsRequired(false);
			builder.Property(m => m.WebsiteUrl).HasColumnType("nvarchar").HasMaxLength(100).IsRequired(false);
			builder.Property(m => m.LogoUrl).HasColumnType("nvarchar").HasMaxLength(100).IsRequired();
			builder.Property(m => m.Order).HasColumnType("int").IsRequired();

			builder.ConfigureAuditable();

			builder.HasKey(m => m.Id);
			builder.ToTable("Partners");
		}
	}
}
