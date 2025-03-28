using MediatR;

namespace NeftchiLLC.Application.Features.CompletedWork.Queries.CompletedWorkGetByIdQuery
{
    public class CompletedWorkGetByIdRequest : IRequest<CompletedWorkGetByIdDto>
    {
		public int Id { get; set; }
	}
}
