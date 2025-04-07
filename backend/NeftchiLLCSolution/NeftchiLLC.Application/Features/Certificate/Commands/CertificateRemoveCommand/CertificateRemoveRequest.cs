using MediatR;

namespace NeftchiLLC.Application.Features.Certificate.Commands.CertificateRemoveCommand
{
	public class RecommendationRemoveRequest : IRequest
	{
		public int Id { get; set; }
	}
}
