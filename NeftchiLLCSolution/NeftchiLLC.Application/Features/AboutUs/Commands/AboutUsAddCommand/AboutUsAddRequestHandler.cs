using Intelect.Application.Core.Services;
using MediatR;
using NeftchiLLC.Application.Repositories;
using NeftchiLLC.Application.Services;

namespace NeftchiLLC.Application.Features.AboutUs.Commands.AboutUsAddCommand
{
	class AboutUsAddRequestHandler(IAboutUsRepository aboutUsRepository,FtpFileService ftpFileService) : IRequestHandler<AboutUsAddRequest>
	{
		public async Task Handle(AboutUsAddRequest request, CancellationToken cancellationToken)
		{
			var value = new Domain.Models.Entities.AboutUs
			{
				Content = request.Content,
				Title = request.Title,
			};
			value.ImagePath = ftpFileService.Upload(request.File);

			await aboutUsRepository.AddAsync(value, cancellationToken);
			await aboutUsRepository.SaveAsync(cancellationToken);
		}
	}
}
