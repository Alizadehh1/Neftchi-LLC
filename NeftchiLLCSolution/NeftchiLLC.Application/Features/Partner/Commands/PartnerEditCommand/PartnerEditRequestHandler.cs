using MediatR;
using Microsoft.AspNetCore.Hosting;
using NeftchiLLC.Application.Repositories;
using NeftchiLLC.Application.Services;

namespace NeftchiLLC.Application.Features.Partner.Commands.PartnerEditCommand
{
	class PartnerEditRequestHandler(IPartnerRepository partnerRepository,IWebHostEnvironment env,FtpFileService ftpFileService) : IRequestHandler<PartnerEditRequest>
	{
		public async Task Handle(PartnerEditRequest request, CancellationToken cancellationToken)
		{
			var value = await partnerRepository.GetAsync(d => d.Id == request.Id && d.DeletedAt == null, cancellationToken: cancellationToken);
			value.Name = request.Name;
			value.Order = request.Order;
			if (request.File is not null)
				value.LogoUrl = ftpFileService.Upload(request.File);

			await partnerRepository.SaveAsync(cancellationToken);
		}
	}
}
