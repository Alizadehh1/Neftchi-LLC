using Intelect.Domain.Core.Commons;

namespace NeftchiLLC.Domain.Models.Entities
{
	public class Equipment : AuditableEntity
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public int Quantity { get; set; }
		public string Model { get; set; }
		public string Description { get; set; }
	}
}
