using MediatR;

namespace NeftchiLLC.Application.Features.Activities.Commands.ActivitiesRemoveCommand
{
    public class ActivitiesRemoveRequest : IRequest
    {
		public int Id { get; set; }
	}
}
