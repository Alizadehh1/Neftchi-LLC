using Intelect.Infrastructure.Core.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NeftchiLLC.Domain.Models.Entities;

namespace NeftchiLLC.Domain.Contexts.Configurations
{
	class EquipmentEntityTypeConfiguration : IEntityTypeConfiguration<Equipment>
	{
		public void Configure(EntityTypeBuilder<Equipment> builder)
		{
			builder.Property(m => m.Id).HasColumnType("int").UseIdentityColumn(1, 1);
			builder.Property(m => m.Name).HasColumnType("nvarchar").HasMaxLength(50).IsRequired();
			builder.Property(m => m.Quantity).HasColumnType("int").IsRequired();
			builder.Property(m => m.Model).HasColumnType("nvarchar").HasMaxLength(50).IsRequired();
			builder.Property(m => m.Description).HasColumnType("nvarchar").HasMaxLength(200).IsRequired();

			builder.ConfigureAuditable();

			builder.HasKey(m => m.Id);
			builder.ToTable("Equipments");
		}
	}
}
