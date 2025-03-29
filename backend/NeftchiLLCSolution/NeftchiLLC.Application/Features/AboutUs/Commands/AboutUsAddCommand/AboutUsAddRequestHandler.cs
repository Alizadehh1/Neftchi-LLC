using Intelect.Application.Core.Services;
using MediatR;
using NeftchiLLC.Application.Repositories;

namespace NeftchiLLC.Application.Features.AboutUs.Commands.AboutUsAddCommand
{
	class AboutUsAddRequestHandler(IAboutUsRepository aboutUsRepository,LocalFileService localFileService) : IRequestHandler<AboutUsAddRequest>
	{
		public async Task Handle(AboutUsAddRequest request, CancellationToken cancellationToken)
		{
			var value = new Domain.Models.Entities.AboutUs
			{
				Content = request.Content,
				Title = request.Title,
			};
			value.ImagePath = await localFileService.UploadAsync(request.File);

			await aboutUsRepository.AddAsync(value, cancellationToken);
			await aboutUsRepository.SaveAsync(cancellationToken);
		}
	}
}
