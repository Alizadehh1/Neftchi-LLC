using MediatR;
using NeftchiLLC.Application.Repositories;

namespace NeftchiLLC.Application.Features.Equipment.Commands.EquipmentRemoveCommand
{
	class EquipmentRemoveRequestHandler(IEquipmentRepository equipmentRepository) : IRequestHandler<EquipmentRemoveRequest>
	{
		public async Task Handle(EquipmentRemoveRequest request, CancellationToken cancellationToken)
		{
			var value = await equipmentRepository.GetAsync(d => d.Id == request.Id && d.DeletedAt == null, cancellationToken: cancellationToken);
			equipmentRepository.Remove(value);
			await equipmentRepository.SaveAsync(cancellationToken);
		}
	}
}
