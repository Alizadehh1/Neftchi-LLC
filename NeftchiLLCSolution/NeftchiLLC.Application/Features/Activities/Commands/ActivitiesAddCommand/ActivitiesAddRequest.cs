using MediatR;

namespace NeftchiLLC.Application.Features.Activities.Commands.ActivitiesAddCommand
{
    public class ActivitiesAddRequest : IRequest
    {
		public string Description { get; set; }
		public int Order { get; set; }
	}
}
