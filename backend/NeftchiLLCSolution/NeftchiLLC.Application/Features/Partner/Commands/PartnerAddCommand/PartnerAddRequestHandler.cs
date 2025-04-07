using Intelect.Application.Core.Services;
using Intelect.Infrastructure.Core.Services;
using MediatR;
using NeftchiLLC.Application.Repositories;
using NeftchiLLC.Application.Services;

namespace NeftchiLLC.Application.Features.Partner.Commands.PartnerAddCommand
{
	class PartnerAddRequestHandler(FtpFileService ftpFileService, IPartnerRepository partnerRepository) : IRequestHandler<PartnerAddRequest>
	{
		public async Task Handle(PartnerAddRequest request, CancellationToken cancellationToken)
		{
			var value = new Domain.Models.Entities.Partner
			{
				Name = request.Name,
				Order = request.Order,
				WebsiteUrl = request.WebsiteUrl,
			};
			value.LogoUrl = ftpFileService.Upload(request.File);
			await partnerRepository.AddAsync(value);
			await partnerRepository.SaveAsync(cancellationToken);
		}
	}
}
