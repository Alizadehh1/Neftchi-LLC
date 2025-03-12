using MediatR;

namespace NeftchiLLC.Application.Features.License.Commands.LicenseRemoveCommand
{
	public class LicenseRemoveRequest : IRequest
	{
		public int Id { get; set; }
	}
}
