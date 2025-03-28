using MediatR;
using NeftchiLLC.Application.Repositories;

namespace NeftchiLLC.Application.Features.Equipment.Commands.EquipmentEditCommand
{
	class EquipmentEditRequestHandler(IEquipmentRepository equipmentRepository) : IRequestHandler<EquipmentEditRequest>
	{
		public async Task Handle(EquipmentEditRequest request, CancellationToken cancellationToken)
		{
			var value = await equipmentRepository.GetAsync(d => d.Id == request.Id && d.DeletedAt == null, cancellationToken: cancellationToken);
			value.Description = request.Description;
			value.Name = request.Name;
			value.Quantity = request.Quantity;
			value.Model = request.Model;
			await equipmentRepository.SaveAsync(cancellationToken);
		}
	}
}
