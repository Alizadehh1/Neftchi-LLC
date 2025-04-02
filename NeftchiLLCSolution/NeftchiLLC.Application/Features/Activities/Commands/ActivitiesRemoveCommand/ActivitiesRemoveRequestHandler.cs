using MediatR;
using NeftchiLLC.Application.Repositories;

namespace NeftchiLLC.Application.Features.Activities.Commands.ActivitiesRemoveCommand
{
	class ActivitiesRemoveRequestHandler(IActivitiesRepository activitiesRepository) : IRequestHandler<ActivitiesRemoveRequest>
	{
		public async Task Handle(ActivitiesRemoveRequest request, CancellationToken cancellationToken)
		{
			var value = await activitiesRepository.GetAsync(d => d.Id == request.Id && d.DeletedAt == null, cancellationToken: cancellationToken);
			activitiesRepository.Remove(value);
			await activitiesRepository.SaveAsync(cancellationToken);
		}
	}
}
