using MediatR;

namespace NeftchiLLC.Application.Features.CompletedWork.Commands.CompletedWorkAddCommand
{
    public class CompletedWorkAddRequest : IRequest
    {
		public string Description { get; set; }
		public int Order { get; set; }
	}
}
