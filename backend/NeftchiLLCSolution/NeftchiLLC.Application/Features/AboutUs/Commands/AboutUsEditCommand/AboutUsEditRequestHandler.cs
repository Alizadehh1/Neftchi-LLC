using MediatR;
using Microsoft.AspNetCore.Hosting;
using NeftchiLLC.Application.Repositories;
using NeftchiLLC.Application.Services;

namespace NeftchiLLC.Application.Features.AboutUs.Commands.AboutUsEditCommand
{
	class AboutUsEditRequestHandler(IAboutUsRepository aboutUsRepository, AzureBlobService azureBlobService, IWebHostEnvironment env) : IRequestHandler<AboutUsEditRequest>
	{
		public async Task Handle(AboutUsEditRequest request, CancellationToken cancellationToken)
		{
			var value = await aboutUsRepository.GetAsync(d => d.DeletedAt == null && d.Id == request.Id, cancellationToken: cancellationToken);
			value.Title = request.Title;
			value.Content = request.Content;
			if (request.File is not null)
			{
				string oldPath = value.ImagePath;
				value.ImagePath = await azureBlobService.UploadAsync(request.File);
			}
			await aboutUsRepository.SaveAsync(cancellationToken);
		}
	}
}
