using MediatR;
using NeftchiLLC.Application.Repositories;

namespace NeftchiLLC.Application.Features.AboutUs.Queries.AboutUsGetByIdQuery
{
	class AboutUsGetByIdRequestHandler(IAboutUsRepository aboutUsRepository) : IRequestHandler<AboutUsGetByIdRequest, AboutUsGetByIdDto>
	{
		public async Task<AboutUsGetByIdDto> Handle(AboutUsGetByIdRequest request, CancellationToken cancellationToken)
		{
			var value = await aboutUsRepository.GetAsync(d => d.DeletedAt == null && d.Id == request.Id, cancellationToken: cancellationToken);
			return new AboutUsGetByIdDto
			{
				Content = value.Content,
				Id = request.Id,
				ImagePath = value.ImagePath,
				Title = value.Title,
			};
		}
	}
}
