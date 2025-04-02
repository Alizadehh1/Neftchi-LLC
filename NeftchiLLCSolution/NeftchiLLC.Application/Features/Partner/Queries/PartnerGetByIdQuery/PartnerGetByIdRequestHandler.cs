using MediatR;
using NeftchiLLC.Application.Repositories;

namespace NeftchiLLC.Application.Features.Partner.Queries.PartnerGetByIdQuery
{
	class PartnerGetByIdRequestHandler(IPartnerRepository partnerRepository) : IRequestHandler<PartnerGetByIdRequest, PartnerGetByIdDto>
	{
		public async Task<PartnerGetByIdDto> Handle(PartnerGetByIdRequest request, CancellationToken cancellationToken)
		{
			var value = await partnerRepository.GetAsync(d => d.Id == request.Id && d.DeletedAt == null, cancellationToken: cancellationToken);
			return new PartnerGetByIdDto
			{
				Id = value.Id,
				LogoUrl = value.LogoUrl,
				Name = value.Name,
				Order = value.Order,
				WebsiteUrl = value.WebsiteUrl,
			};
		}
	}
}
