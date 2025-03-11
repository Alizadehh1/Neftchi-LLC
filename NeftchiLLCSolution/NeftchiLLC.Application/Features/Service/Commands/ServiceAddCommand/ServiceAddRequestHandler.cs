using MediatR;
using NeftchiLLC.Application.Repositories;

namespace NeftchiLLC.Application.Features.Service.Commands.ServiceAddCommand
{
	class ServiceAddRequestHandler(IServiceRepository serviceRepository) : IRequestHandler<ServiceAddRequest, Domain.Models.Entities.Service>
	{
		public async Task<Domain.Models.Entities.Service> Handle(ServiceAddRequest request, CancellationToken cancellationToken)
		{
			var service = new Domain.Models.Entities.Service
			{
				Name = request.Name,
				Rank = request.Rank,
			};

			await serviceRepository.AddAsync(service, cancellationToken);
			await serviceRepository.SaveAsync(cancellationToken);

			return service;
		}
	}
}
