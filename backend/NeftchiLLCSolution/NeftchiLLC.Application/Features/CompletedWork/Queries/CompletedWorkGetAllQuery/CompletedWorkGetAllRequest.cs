using MediatR;

namespace NeftchiLLC.Application.Features.CompletedWork.Queries.CompletedWorkGetAllQuery
{
    public class CompletedWorkGetAllRequest : IRequest<List<CompletedWorkGetAllDto>>
    {
    }
}
