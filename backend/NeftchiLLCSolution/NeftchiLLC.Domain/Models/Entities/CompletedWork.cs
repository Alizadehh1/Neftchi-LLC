﻿using Intelect.Domain.Core.Commons;

namespace NeftchiLLC.Domain.Models.Entities
{
    public class CompletedWork : AuditableEntity
    {
		public int Id { get; set; }
		public string Description { get; set; }
		public int Order { get; set; }
	}
}
