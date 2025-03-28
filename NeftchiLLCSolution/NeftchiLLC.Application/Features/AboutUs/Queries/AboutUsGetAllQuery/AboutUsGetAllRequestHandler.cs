using MediatR;
using Microsoft.EntityFrameworkCore;
using NeftchiLLC.Application.Repositories;

namespace NeftchiLLC.Application.Features.AboutUs.Queries.AboutUsGetAllQuery
{
	class AboutUsGetAllRequestHandler(IAboutUsRepository aboutUsRepository) : IRequestHandler<AboutUsGetAllRequest, List<AboutUsGetAllDto>>
	{
		public async Task<List<AboutUsGetAllDto>> Handle(AboutUsGetAllRequest request, CancellationToken cancellationToken)
		{
			var values = aboutUsRepository.GetAll(d => d.DeletedAt == null);

			return await values.Select(d => new AboutUsGetAllDto
			{
				Content = d.Content,
				Id = d.Id,
				ImagePath = d.ImagePath,
				Title = d.Title,
			}).ToListAsync(cancellationToken);
		}
	}
}
