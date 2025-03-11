using MediatR;

namespace NeftchiLLC.Application.Features.License.Commands.LicenseRemoveCommand
{
	public class CertificateRemoveRequest : IRequest
	{
		public int Id { get; set; }
	}
}
