using MediatR;
using NeftchiLLC.Application.Repositories;
using NeftchiLLC.Application.Services;

namespace NeftchiLLC.Application.Features.Partner.Commands.PartnerRemoveCommand
{
	class PartnerRemoveRequestHandler(IPartnerRepository partnerRepository,AzureBlobService azureBlobService) : IRequestHandler<PartnerRemoveRequest>
	{
		public async Task Handle(PartnerRemoveRequest request, CancellationToken cancellationToken)
		{
			var value = await partnerRepository.GetAsync(d => d.Id == request.Id && d.DeletedAt == null, cancellationToken: cancellationToken);
			partnerRepository.Remove(value);
			await azureBlobService.RemoveAsync(value.LogoUrl);
			await partnerRepository.SaveAsync(cancellationToken);
		}
	}
}
