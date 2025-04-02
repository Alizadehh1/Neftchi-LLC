using Intelect.Domain.Core.Commons;

namespace NeftchiLLC.Domain.Models.Entities
{
    public class AboutUs : AuditableEntity
	{
		public int Id { get; set; }
		public string Title { get; set; }
		public string ImagePath { get; set; }
		public string Content { get; set; }
	}
}
