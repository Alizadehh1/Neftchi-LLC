using MediatR;

namespace NeftchiLLC.Application.Features.CompletedWork.Commands.CompletedWorkRemoveCommand
{
    public class CompletedWorkRemoveRequest : IRequest
    {
		public int Id { get; set; }
	}
}
