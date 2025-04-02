using Intelect.Domain.Core.Commons;

namespace NeftchiLLC.Domain.Models.Entities
{
	public class Service : AuditableEntity
	{
		public int Id { get; set; }
		public int Rank { get; set; }
		public required string Name { get; set; }
	}
}
