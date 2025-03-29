using MediatR;

namespace NeftchiLLC.Application.Features.Service.Commands.ServiceEditCommand
{
	public class ServiceEditRequest : IRequest
	{
		public int Id { get; set; }
		public int Rank { get; set; }
		public string Name { get; set; }
	}
}
