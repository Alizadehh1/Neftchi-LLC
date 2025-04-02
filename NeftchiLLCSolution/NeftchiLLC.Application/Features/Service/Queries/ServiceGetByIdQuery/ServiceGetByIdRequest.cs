using MediatR;

namespace NeftchiLLC.Application.Features.Service.Queries.ServiceGetByIdQuery
{
	public class ServiceGetByIdRequest : IRequest<ServiceGetByIdDto>
	{
		public int Id { get; set; }
	}
}
