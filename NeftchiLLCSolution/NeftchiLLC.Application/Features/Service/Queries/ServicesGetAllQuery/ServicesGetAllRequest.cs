using MediatR;

namespace NeftchiLLC.Application.Features.Service.Queries.ServicesGetAllQuery
{
	public class ServicesGetAllRequest : IRequest<IEnumerable<ServicesGetAllDto>>
	{
	}
}
