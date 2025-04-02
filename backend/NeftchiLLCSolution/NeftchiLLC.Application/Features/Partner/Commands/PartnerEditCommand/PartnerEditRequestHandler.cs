using Intelect.Application.Core.Services;
using MediatR;
using Microsoft.AspNetCore.Hosting;
using NeftchiLLC.Application.Repositories;

namespace NeftchiLLC.Application.Features.Partner.Commands.PartnerEditCommand
{
	class PartnerEditRequestHandler(IPartnerRepository partnerRepository,IWebHostEnvironment env,LocalFileService localFileService) : IRequestHandler<PartnerEditRequest>
	{
		public async Task Handle(PartnerEditRequest request, CancellationToken cancellationToken)
		{
			var value = await partnerRepository.GetAsync(d => d.Id == request.Id && d.DeletedAt == null, cancellationToken: cancellationToken);
			value.Name = request.Name;
			value.Order = request.Order;
			if (request.File is not null)
			{
				string physicalPathOld = Path.Combine(env.ContentRootPath, "wwwroot", "uploads", "images", value.LogoUrl);
				value.LogoUrl = await localFileService.UploadAsync(request.File);
				if (File.Exists(physicalPathOld))
					File.Delete(physicalPathOld);
			}
			await partnerRepository.SaveAsync(cancellationToken);
		}
	}
}
