using MediatR;
using NeftchiLLC.Application.Dtos;

namespace NeftchiLLC.Application.Features.License.Commands.LicenseEditCommand
{
	public class LicenseEditRequest : IRequest<string>
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public List<DocumentAddFileDto> Files { get; set; }
	}
}
