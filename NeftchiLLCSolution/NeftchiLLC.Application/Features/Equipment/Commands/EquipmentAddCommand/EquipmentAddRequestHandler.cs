using MediatR;
using NeftchiLLC.Application.Repositories;

namespace NeftchiLLC.Application.Features.Equipment.Commands.EquipmentAddCommand
{
	class EquipmentAddRequestHandler(IEquipmentRepository equipmentRepository) : IRequestHandler<EquipmentAddRequest>
	{
		public async Task Handle(EquipmentAddRequest request, CancellationToken cancellationToken)
		{
			var value = new Domain.Models.Entities.Equipment
			{
				Name = request.Name,
				Model = request.Model,
				Quantity = request.Quantity,
				Description = request.Description,
			};
			await equipmentRepository.AddAsync(value, cancellationToken);
			await equipmentRepository.SaveAsync(cancellationToken);
		}
	}
}
