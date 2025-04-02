using MediatR;
using Microsoft.EntityFrameworkCore;
using NeftchiLLC.Application.Repositories;

namespace NeftchiLLC.Application.Features.Partner.Queries.PartnerGetAllQuery
{
	class PartnerGetAllRequestHandler(IPartnerRepository partnerRepository) : IRequestHandler<PartnerGetAllRequest, List<PartnerGetAllDto>>
	{
		public async Task<List<PartnerGetAllDto>> Handle(PartnerGetAllRequest request, CancellationToken cancellationToken)
		{
			var values = partnerRepository.GetAll(d=>d.DeletedAt==null).OrderBy(d=>d.Order);
			return await values.Select(d => new PartnerGetAllDto
			{
				Id = d.Id,
				LogoUrl = d.LogoUrl,
				Name = d.Name,
				Order = d.Order,
				WebsiteUrl = d.WebsiteUrl,
			}).ToListAsync(cancellationToken);
		}
	}
}
