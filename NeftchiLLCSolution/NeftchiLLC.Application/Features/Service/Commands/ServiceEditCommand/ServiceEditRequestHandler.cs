using MediatR;
using NeftchiLLC.Application.Repositories;

namespace NeftchiLLC.Application.Features.Service.Commands.ServiceEditCommand
{
	class ServiceEditRequestHandler(IServiceRepository serviceRepository) : IRequestHandler<ServiceEditRequest>
	{
		public async Task Handle(ServiceEditRequest request, CancellationToken cancellationToken)
		{
			var entity = await serviceRepository.GetAsync(d => d.Id == request.Id && d.DeletedAt == null,cancellationToken:cancellationToken);

			entity.Name = request.Name;
			entity.Rank = request.Rank;

			await serviceRepository.SaveAsync(cancellationToken);
		}
	}
}
