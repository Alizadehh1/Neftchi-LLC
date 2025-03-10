using MediatR;
using NeftchiLLC.Application.Dtos;

namespace NeftchiLLC.Application.Features.Project.Commands.ProjectAddCommand
{
	public class ProjectAddRequest : IRequest<Domain.Models.Entities.Project>
	{
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
