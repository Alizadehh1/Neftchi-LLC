using MediatR;
using NeftchiLLC.Application.Repositories;

namespace NeftchiLLC.Application.Features.Activities.Commands.ActivitiesEditCommand
{
	class ActivitiesEditRequestHandler(IActivitiesRepository activitiesRepository) : IRequestHandler<ActivitiesEditRequest>
	{
		public async Task Handle(ActivitiesEditRequest request, CancellationToken cancellationToken)
		{
			var value = await activitiesRepository.GetAsync(d => d.Id == request.Id && d.DeletedAt == null, cancellationToken: cancellationToken);
			value.Description = request.Description;
			value.Order = request.Order;
			await activitiesRepository.SaveAsync(cancellationToken);
		}
	}
}
