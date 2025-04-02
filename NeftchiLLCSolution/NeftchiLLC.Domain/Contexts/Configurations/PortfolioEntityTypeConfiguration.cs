using Intelect.Infrastructure.Core.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NeftchiLLC.Domain.Models.Entities;

namespace NeftchiLLC.Domain.Contexts.Configurations
{
	class PortfolioEntityTypeConfiguration : IEntityTypeConfiguration<Portfolio>
	{
		public void Configure(EntityTypeBuilder<Portfolio> builder)
		{

			builder.Property(m => m.Id).HasColumnType("int").UseIdentityColumn(1, 1);
			builder.Property(m => m.Name).HasColumnType("nvarchar").HasMaxLength(100).IsRequired();
			builder.Property(m => m.Description).HasColumnType("nvarchar").HasMaxLength(1000).IsRequired(false);

			builder.ConfigureAuditable();

			builder.HasKey(m => m.Id);
			builder.ToTable("Portfolios");
		}
	}
}
