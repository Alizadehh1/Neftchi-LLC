using MediatR;
using NeftchiLLC.Application.Repositories;

namespace NeftchiLLC.Application.Features.Service.Commands.ServiceRemoveCommand
{
	class ServiceRemoveRequestHandler(IServiceRepository serviceRepository) : IRequestHandler<ServiceRemoveRequest>
	{
		public async Task Handle(ServiceRemoveRequest request, CancellationToken cancellationToken)
		{
			var entity = await serviceRepository.GetAsync(d => d.DeletedAt == null && d.Id == request.Id, cancellationToken: cancellationToken);

			serviceRepository.Remove(entity);
			await serviceRepository.SaveAsync(cancellationToken);
		}
	}
}
