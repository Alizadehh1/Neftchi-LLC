using MediatR;

namespace NeftchiLLC.Application.Features.Partner.Queries.PartnerGetByIdQuery
{
    public class PartnerGetByIdRequest : IRequest<PartnerGetByIdDto>
    {
		public int Id { get; set; }
	}
}
