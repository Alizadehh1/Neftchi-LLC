using MediatR;

namespace NeftchiLLC.Application.Features.Partner.Queries.PartnerGetAllQuery
{
    public class PartnerGetAllRequest : IRequest<List<PartnerGetAllDto>>
    {
    }
}
