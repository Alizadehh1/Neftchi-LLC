using MediatR;

namespace NeftchiLLC.Application.Features.Certificate.Commands.CertificateRemoveCommand
{
	public class CertificateRemoveRequest : IRequest
	{
		public int Id { get; set; }
	}
}
