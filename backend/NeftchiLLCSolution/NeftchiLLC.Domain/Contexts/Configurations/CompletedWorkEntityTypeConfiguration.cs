﻿using Intelect.Infrastructure.Core.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NeftchiLLC.Domain.Models.Entities;

namespace NeftchiLLC.Domain.Contexts.Configurations
{
	class CompletedWorkEntityTypeConfiguration : IEntityTypeConfiguration<CompletedWork>
	{
		public void Configure(EntityTypeBuilder<CompletedWork> builder)
		{
			builder.Property(m => m.Id).HasColumnType("int").UseIdentityColumn(1, 1);
			builder.Property(m => m.Order).HasColumnType("int").IsRequired();
			builder.Property(m => m.Description).HasColumnType("LONGTEXT").IsRequired();

			builder.ConfigureAuditable();

			builder.HasKey(m => m.Id);
			builder.ToTable("CompletedWorks");
		}
	}
}
