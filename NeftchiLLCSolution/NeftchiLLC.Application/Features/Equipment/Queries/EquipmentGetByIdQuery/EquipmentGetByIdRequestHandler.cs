using MediatR;
using NeftchiLLC.Application.Repositories;

namespace NeftchiLLC.Application.Features.Equipment.Queries.EquipmentGetByIdQuery
{
	class EquipmentGetByIdRequestHandler(IEquipmentRepository equipmentRepository) : IRequestHandler<EquipmentGetByIdRequest, EquipmentGetByIdDto>
	{
		public async Task<EquipmentGetByIdDto> Handle(EquipmentGetByIdRequest request, CancellationToken cancellationToken)
		{
			var value = await equipmentRepository.GetAsync(d => d.Id == request.Id && d.DeletedAt == null, cancellationToken: cancellationToken);
			return new EquipmentGetByIdDto
			{
				Description = value.Description,
				Id = request.Id,
				Model = value.Model,
				Name = value.Name,
				Quantity = value.Quantity,
			};
		}
	}
}
