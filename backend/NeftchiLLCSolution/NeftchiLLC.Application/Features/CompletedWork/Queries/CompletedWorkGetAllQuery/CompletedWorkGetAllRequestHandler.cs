using MediatR;
using NeftchiLLC.Application.Repositories;

namespace NeftchiLLC.Application.Features.CompletedWork.Queries.CompletedWorkGetAllQuery
{
	class CompletedWorkGetAllRequestHandler(ICompletedWorkRepository completedWorkRepository) : IRequestHandler<CompletedWorkGetAllRequest, List<CompletedWorkGetAllDto>>
	{
		public async Task<List<CompletedWorkGetAllDto>> Handle(CompletedWorkGetAllRequest request, CancellationToken cancellationToken)
		{
			var values = completedWorkRepository.GetAll(d => d.DeletedAt == null).OrderBy(d=>d.Order);
			return values.Select(d => new CompletedWorkGetAllDto
			{
				Description = d.Description,
				Id = d.Id,
				Order = d.Order,
			}).ToList();
		}
	}
}
