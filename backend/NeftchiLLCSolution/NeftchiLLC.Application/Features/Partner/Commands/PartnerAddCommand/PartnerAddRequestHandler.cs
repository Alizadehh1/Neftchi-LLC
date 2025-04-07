using MediatR;
using NeftchiLLC.Application.Repositories;
using NeftchiLLC.Application.Services;

namespace NeftchiLLC.Application.Features.Partner.Commands.PartnerAddCommand
{
	class PartnerAddRequestHandler(AzureBlobService azureBlobService, IPartnerRepository partnerRepository) : IRequestHandler<PartnerAddRequest>
	{
		public async Task Handle(PartnerAddRequest request, CancellationToken cancellationToken)
		{
			var value = new Domain.Models.Entities.Partner
			{
				Name = request.Name,
				Order = request.Order,
				WebsiteUrl = request.WebsiteUrl,
			};
			value.LogoUrl = await azureBlobService.UploadAsync(request.File);
			await partnerRepository.AddAsync(value);
			await partnerRepository.SaveAsync(cancellationToken);
		}
	}
}
