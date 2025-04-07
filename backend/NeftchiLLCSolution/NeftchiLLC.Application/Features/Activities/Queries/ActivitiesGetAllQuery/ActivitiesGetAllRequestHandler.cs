using MediatR;
using Microsoft.EntityFrameworkCore;
using NeftchiLLC.Application.Repositories;

namespace NeftchiLLC.Application.Features.Activities.Queries.ActivitiesGetAllQuery
{
	class ActivitiesGetAllRequestHandler(IActivitiesRepository activitiesRepository) : IRequestHandler<ActivitiesGetAllRequest, List<ActivitiesGetAllDto>>
	{
		public async Task<List<ActivitiesGetAllDto>> Handle(ActivitiesGetAllRequest request, CancellationToken cancellationToken)
		{
			var values = activitiesRepository.GetAll(d=>d.DeletedAt==null).OrderBy(d=>d.Order);
			return await values.Select(d => new ActivitiesGetAllDto
			{
				Description = d.Description,
				Id = d.Id,
			}).ToListAsync(cancellationToken);
		}
	}
}
