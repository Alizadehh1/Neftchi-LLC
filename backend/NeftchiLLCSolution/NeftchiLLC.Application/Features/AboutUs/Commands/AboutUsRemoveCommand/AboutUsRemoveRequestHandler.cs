using MediatR;
using NeftchiLLC.Application.Repositories;
using NeftchiLLC.Application.Services;

namespace NeftchiLLC.Application.Features.AboutUs.Commands.AboutUsRemoveCommand
{
	class AboutUsRemoveRequestHandler(IAboutUsRepository aboutUsRepository, AzureBlobService azureBlobService) : IRequestHandler<AboutUsRemoveRequest>
	{
		public async Task Handle(AboutUsRemoveRequest request, CancellationToken cancellationToken)
		{
			var value = await aboutUsRepository.GetAsync(d => d.DeletedAt == null && d.Id == request.Id, cancellationToken: cancellationToken);
			aboutUsRepository.Remove(value);
			await azureBlobService.RemoveAsync(value.ImagePath);
			await aboutUsRepository.SaveAsync(cancellationToken);
		}
	}
}
