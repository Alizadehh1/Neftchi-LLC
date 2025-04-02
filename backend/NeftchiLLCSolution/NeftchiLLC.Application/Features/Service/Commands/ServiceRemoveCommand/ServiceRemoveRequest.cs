using MediatR;

namespace NeftchiLLC.Application.Features.Service.Commands.ServiceRemoveCommand
{
	public class ServiceRemoveRequest : IRequest
	{
		public int Id { get; set; }
	}
}
