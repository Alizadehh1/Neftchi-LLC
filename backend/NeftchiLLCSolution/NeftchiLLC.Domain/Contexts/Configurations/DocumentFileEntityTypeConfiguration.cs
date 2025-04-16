using Intelect.Infrastructure.Core.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NeftchiLLC.Domain.Models.Entities;

namespace NeftchiLLC.Domain.Contexts.Configurations
{
	class DocumentFileEntityTypeConfiguration : IEntityTypeConfiguration<DocumentFile>
	{
		public void Configure(EntityTypeBuilder<DocumentFile> builder)
		{
			builder.Property(m => m.Id).HasColumnType("int").UseIdentityColumn(1, 1);
			builder.Property(m => m.Name).HasColumnType("varchar").HasMaxLength(200).IsRequired();
			builder.Property(m => m.Path).HasColumnType("varchar").HasMaxLength(300).IsRequired();
			builder.Property(m => m.DocumentId).HasColumnType("int").IsRequired();
			builder.Property(m => m.IsMain).HasColumnType("bit").HasDefaultValue(false).IsRequired();

			builder.ConfigureAuditable();

			builder.HasKey(m => m.Id);
			builder.ToTable("DocumentFiles");

			builder.HasOne<Document>()
				.WithMany()
				.HasPrincipalKey(m => m.Id)
				.HasForeignKey(m => m.DocumentId)
				.OnDelete(DeleteBehavior.Cascade);
		}
	}
}
