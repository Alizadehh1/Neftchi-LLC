using MediatR;
using NeftchiLLC.Application.Repositories;

namespace NeftchiLLC.Application.Features.AboutUs.Commands.AboutUsRemoveCommand
{
	class AboutUsRemoveRequestHandler(IAboutUsRepository aboutUsRepository) : IRequestHandler<AboutUsRemoveRequest>
	{
		public async Task Handle(AboutUsRemoveRequest request, CancellationToken cancellationToken)
		{
			var value = await aboutUsRepository.GetAsync(d => d.DeletedAt == null && d.Id == request.Id, cancellationToken: cancellationToken);
			aboutUsRepository.Remove(value);
			await aboutUsRepository.SaveAsync(cancellationToken);
		}
	}
}
