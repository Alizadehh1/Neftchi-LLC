using Intelect.Domain.Core.Commons;

namespace NeftchiLLC.Domain.Models.Entities
{
	public class Project : AuditableEntity
	{
		public int Id { get; set; }
		public required string Name { get; set; }
		public required string OrganisationName { get; set; }
		public required string OrganisationShortName { get; set; }
		public required string? Description { get; set; }
		public int? EmployeeNumber { get; set; }
		public string? Date { get; set; }
		public DateTime? DeliveryDate { get; set; }
		public string? Materials { get; set; }
	}
}
