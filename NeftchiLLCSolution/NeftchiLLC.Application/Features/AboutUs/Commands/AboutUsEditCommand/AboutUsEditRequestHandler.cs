using Intelect.Application.Core.Services;
using MediatR;
using Microsoft.AspNetCore.Hosting;
using NeftchiLLC.Application.Repositories;
using NeftchiLLC.Application.Services;

namespace NeftchiLLC.Application.Features.AboutUs.Commands.AboutUsEditCommand
{
	class AboutUsEditRequestHandler(IAboutUsRepository aboutUsRepository, FtpFileService ftpFileService,IWebHostEnvironment env) : IRequestHandler<AboutUsEditRequest>
	{
		public async Task Handle(AboutUsEditRequest request, CancellationToken cancellationToken)
		{
			var value = await aboutUsRepository.GetAsync(d => d.DeletedAt == null && d.Id == request.Id, cancellationToken: cancellationToken);
			value.Title = request.Title;
			value.Content = request.Content;
			if (request.File is not null)
			{
				string oldPath = value.ImagePath;
				value.ImagePath = ftpFileService.Upload(request.File);
				string physicalOldPath = Path.Combine(env.ContentRootPath, "wwwroot", "uploads", oldPath);
				if (File.Exists(physicalOldPath))
					File.Delete(physicalOldPath);
			}
			await aboutUsRepository.SaveAsync(cancellationToken);
		}
	}
}
