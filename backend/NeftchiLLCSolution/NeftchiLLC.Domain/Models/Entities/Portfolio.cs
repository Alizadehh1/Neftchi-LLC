using Intelect.Domain.Core.Commons;

namespace NeftchiLLC.Domain.Models.Entities
{
	public class Portfolio : AuditableEntity
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }
	}
}
