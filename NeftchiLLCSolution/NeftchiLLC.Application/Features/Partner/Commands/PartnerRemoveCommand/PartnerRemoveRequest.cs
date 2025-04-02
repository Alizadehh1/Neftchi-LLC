using MediatR;

namespace NeftchiLLC.Application.Features.Partner.Commands.PartnerRemoveCommand
{
    public class PartnerRemoveRequest : IRequest
    {
		public int Id { get; set; }
	}
}
