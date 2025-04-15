using MediatR;
using NeftchiLLC.Application.Repositories;
using NeftchiLLC.Application.Services;

namespace NeftchiLLC.Application.Features.Partner.Commands.PartnerEditCommand
{
	class PartnerEditRequestHandler(IPartnerRepository partnerRepository, AzureBlobService azureBlobService) : IRequestHandler<PartnerEditRequest>
	{
		public async Task Handle(PartnerEditRequest request, CancellationToken cancellationToken)
		{
			var value = await partnerRepository.GetAsync(d => d.Id == request.Id && d.DeletedAt == null, cancellationToken: cancellationToken);
			value.Name = request.Name;
			value.Order = request.Order;
			if (request.File is not null)
				value.LogoUrl = await azureBlobService.UploadAsync(request.File);

			await partnerRepository.SaveAsync(cancellationToken);
		}
	}
}
