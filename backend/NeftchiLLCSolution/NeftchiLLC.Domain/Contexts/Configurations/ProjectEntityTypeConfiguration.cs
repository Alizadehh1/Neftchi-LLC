using Intelect.Infrastructure.Core.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NeftchiLLC.Domain.Models.Entities;

namespace NeftchiLLC.Domain.Contexts.Configurations
{
	class ProjectEntityTypeConfiguration : IEntityTypeConfiguration<Project>
	{
		public void Configure(EntityTypeBuilder<Project> builder)
		{
			builder.Property(m => m.Id).HasColumnType("int").UseIdentityColumn(1, 1);
			builder.Property(m => m.Name).HasColumnType("nvarchar").HasMaxLength(50).IsRequired();
			builder.Property(m => m.OrganisationName).HasColumnType("nvarchar").HasMaxLength(100).IsRequired();
			builder.Property(m => m.OrganisationShortName).HasColumnType("nvarchar").HasMaxLength(50).IsRequired();
			builder.Property(m => m.Description).HasColumnType("nvarchar").HasMaxLength(500).IsRequired(false);
			builder.Property(m => m.Date).HasColumnType("nvarchar").HasMaxLength(50).IsRequired(false);
			builder.Property(m => m.Materials).HasColumnType("nvarchar").HasMaxLength(500).IsRequired(false);
			builder.Property(m => m.EmployeeNumber).HasColumnType("int").IsRequired(false);
			builder.Property(m => m.DeliveryDate).HasColumnType("datetime").IsRequired(false);

			builder.ConfigureAuditable();

			builder.HasKey(m => m.Id);
			builder.ToTable("Projects");
		}
	}
}
