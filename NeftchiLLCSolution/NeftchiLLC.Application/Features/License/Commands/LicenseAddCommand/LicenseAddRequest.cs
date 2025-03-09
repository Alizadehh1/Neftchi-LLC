using MediatR;
using NeftchiLLC.Application.Dtos;
using NeftchiLLC.Domain.Models.Entities;

namespace NeftchiLLC.Application.Features.License.Commands.LicenseAddCommand
{
	public class LicenseAddRequest : IRequest<Document>
	{
		public string Name { get; set; }
		public required List<DocumentAddFileDto> Files { get; set; }
	}
}
