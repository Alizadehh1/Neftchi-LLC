using MediatR;
using NeftchiLLC.Application.Repositories;

namespace NeftchiLLC.Application.Features.Partner.Commands.PartnerRemoveCommand
{
	class PartnerRemoveRequestHandler(IPartnerRepository partnerRepository) : IRequestHandler<PartnerRemoveRequest>
	{
		public async Task Handle(PartnerRemoveRequest request, CancellationToken cancellationToken)
		{
			var value = await partnerRepository.GetAsync(d => d.Id == request.Id && d.DeletedAt == null, cancellationToken: cancellationToken);
			partnerRepository.Remove(value);
			await partnerRepository.SaveAsync(cancellationToken);
		}
	}
}
