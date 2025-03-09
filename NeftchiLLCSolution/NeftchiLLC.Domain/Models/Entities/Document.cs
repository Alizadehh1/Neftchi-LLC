using Intelect.Domain.Core.Commons;
using NeftchiLLC.Domain.Models.StableModels;

namespace NeftchiLLC.Domain.Models.Entities
{
	public class Document : AuditableEntity
	{
		public int Id { get; set; }
		public required string Name { get; set; }
		public required DocumentType Type { get; set; }
	}
}
