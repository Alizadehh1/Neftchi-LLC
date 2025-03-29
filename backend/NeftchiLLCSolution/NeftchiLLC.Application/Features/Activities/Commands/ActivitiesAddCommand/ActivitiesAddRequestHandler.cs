using MediatR;
using NeftchiLLC.Application.Repositories;

namespace NeftchiLLC.Application.Features.Activities.Commands.ActivitiesAddCommand
{
	class ActivitiesAddRequestHandler(IActivitiesRepository activitiesRepository) : IRequestHandler<ActivitiesAddRequest>
	{
		public async Task Handle(ActivitiesAddRequest request, CancellationToken cancellationToken)
		{
			var value = new Domain.Models.Entities.Activities
			{
				Order = request.Order,
				Description = request.Description,
			};
			await activitiesRepository.AddAsync(value, cancellationToken);
			await activitiesRepository.SaveAsync(cancellationToken);
		}
	}
}
