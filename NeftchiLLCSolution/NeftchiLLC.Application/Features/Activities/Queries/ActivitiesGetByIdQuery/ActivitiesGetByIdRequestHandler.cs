using MediatR;
using NeftchiLLC.Application.Repositories;

namespace NeftchiLLC.Application.Features.Activities.Queries.ActivitiesGetByIdQuery
{
	class ActivitiesGetByIdRequestHandler(IActivitiesRepository activitiesRepository) : IRequestHandler<ActivitiesGetByIdRequest, ActivitiesGetByIdDto>
	{
		public async Task<ActivitiesGetByIdDto> Handle(ActivitiesGetByIdRequest request, CancellationToken cancellationToken)
		{
			var value = await activitiesRepository.GetAsync(d => d.Id == request.Id && d.DeletedAt == null, cancellationToken: cancellationToken);
			return new ActivitiesGetByIdDto
			{
				Id = request.Id,
				Description = value.Description,
				Order = value.Order,
			};
		}
	}
}
