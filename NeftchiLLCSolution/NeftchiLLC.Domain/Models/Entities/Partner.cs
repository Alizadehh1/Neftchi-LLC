using Intelect.Domain.Core.Commons;

namespace NeftchiLLC.Domain.Models.Entities
{
    public class Partner : AuditableEntity
    {
		public int Id { get; set; }
		public string? Name { get; set; }
		public string? WebsiteUrl { get; set; }
		public string LogoUrl { get; set; }
		public int Order { get; set; }
	}
}
