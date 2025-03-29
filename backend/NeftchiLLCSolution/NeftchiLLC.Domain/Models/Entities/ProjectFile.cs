using Intelect.Domain.Core.Commons;

namespace NeftchiLLC.Domain.Models.Entities
{
	public class ProjectFile : AuditableEntity
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string Path { get; set; }
		public int ProjectId { get; set; }
		public bool IsMain { get; set; }
	}
}
