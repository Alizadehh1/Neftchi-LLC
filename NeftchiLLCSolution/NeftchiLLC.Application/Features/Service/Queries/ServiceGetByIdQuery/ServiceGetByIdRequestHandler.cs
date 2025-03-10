using MediatR;
using NeftchiLLC.Application.Repositories;

namespace NeftchiLLC.Application.Features.Service.Queries.ServiceGetByIdQuery
{
	class ServiceGetByIdRequestHandler(IServiceRepository serviceRepository) : IRequestHandler<ServiceGetByIdRequest, ServiceGetByIdDto>
	{
		public async Task<ServiceGetByIdDto> Handle(ServiceGetByIdRequest request, CancellationToken cancellationToken)
		{
			var entity = await serviceRepository.GetAsync(d => d.Id == request.Id && d.DeletedAt == null, cancellationToken: cancellationToken);

			return new ServiceGetByIdDto
			{
				Id = entity.Id,
				Name = entity.Name,
				Rank = entity.Rank,
			};
		}
	}
}
