using MediatR;
using NeftchiLLC.Application.Dtos;

namespace NeftchiLLC.Application.Features.Project.Commands.ProjectEditCommand
{
	public class ProjectEditRequest : IRequest
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string OrganisationName { get; set; }
		public string OrganisationShortName { get; set; }
		public string Description { get; set; }
		public int EmployeeNumber { get; set; }
		public string Date { get; set; }
		public DateTime DeliveryDate { get; set; }
		public string Materials { get; set; }
		public required List<DocumentAddFileDto> Files { get; set; }
	}
}
