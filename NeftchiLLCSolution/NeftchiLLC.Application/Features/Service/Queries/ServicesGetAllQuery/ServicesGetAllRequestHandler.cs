using MediatR;
using NeftchiLLC.Application.Repositories;

namespace NeftchiLLC.Application.Features.Service.Queries.ServicesGetAllQuery
{
	class ServicesGetAllRequestHandler(IServiceRepository serviceRepository) : IRequestHandler<ServicesGetAllRequest, IEnumerable<ServicesGetAllDto>>
	{
		public async Task<IEnumerable<ServicesGetAllDto>> Handle(ServicesGetAllRequest request, CancellationToken cancellationToken)
		{
			var services = serviceRepository.GetAll(d => d.DeletedAt == null);

			var result = services.Select(d => new ServicesGetAllDto
			{
				Id = d.Id,
				Name = d.Name,
				Rank = d.Rank,
			}).OrderBy(d => d.Rank);

			return result;
		}
	}
}
