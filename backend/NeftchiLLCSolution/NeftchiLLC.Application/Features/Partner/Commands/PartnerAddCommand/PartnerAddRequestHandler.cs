using Intelect.Application.Core.Services;
using MediatR;
using NeftchiLLC.Application.Repositories;

namespace NeftchiLLC.Application.Features.Partner.Commands.PartnerAddCommand
{
	class PartnerAddRequestHandler(IPartnerRepository partnerRepository, LocalFileService localFileService) : IRequestHandler<PartnerAddRequest>
	{
		public async Task Handle(PartnerAddRequest request, CancellationToken cancellationToken)
		{
			var value = new Domain.Models.Entities.Partner
			{
				Name = request.Name,
				Order = request.Order,
				WebsiteUrl = request.WebsiteUrl,
			};
			value.LogoUrl = await localFileService.UploadAsync(request.File);
			await partnerRepository.AddAsync(value);
			await partnerRepository.SaveAsync(cancellationToken);
		}
	}
}
