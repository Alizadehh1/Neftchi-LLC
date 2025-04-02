using MediatR;

namespace NeftchiLLC.Application.Features.CompletedWork.Commands.CompletedWorkEditCommand
{
    public class CompletedWorkEditRequest : IRequest
    {
		public int Id { get; set; }
		public string Description { get; set; }
		public int Order { get; set; }
	}
}
