using MediatR;

namespace NeftchiLLC.Application.Features.AboutUs.Queries.AboutUsGetAllQuery
{
    public class AboutUsGetAllRequest : IRequest<List<AboutUsGetAllDto>>
    {
    }
}
