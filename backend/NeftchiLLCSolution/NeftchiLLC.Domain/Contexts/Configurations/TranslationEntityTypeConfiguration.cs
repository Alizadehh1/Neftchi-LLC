using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NeftchiLLC.Domain.Models.Entities;

namespace NeftchiLLC.Domain.Contexts.Configurations
{
	class TranslationEntityTypeConfiguration : IEntityTypeConfiguration<Translation>
	{
		public void Configure(EntityTypeBuilder<Translation> builder)
		{
			builder.Property(m => m.Id).HasColumnType("int").UseIdentityColumn(1, 1);
			builder.Property(m => m.Key).HasColumnType("nvarchar(max)").IsRequired();
			builder.Property(m => m.Value).HasColumnType("nvarchar(max)").IsRequired();
			builder.Property(m => m.Language).HasColumnType("nvarchar(max)").IsRequired();

			builder.HasKey(m => m.Id);
			builder.ToTable("Translations");
		}
	}
}
