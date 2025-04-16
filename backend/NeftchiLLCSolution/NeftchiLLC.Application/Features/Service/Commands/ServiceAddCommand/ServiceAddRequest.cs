using MediatR;

namespace NeftchiLLC.Application.Features.Service.Commands.ServiceAddCommand
{
	public class ServiceAddRequest : IRequest<Domain.Models.Entities.Service>
	{
		public int Rank { get; set; }
		public required string Name { get; set; }
	}
}
