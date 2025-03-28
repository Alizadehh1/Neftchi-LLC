using MediatR;

namespace NeftchiLLC.Application.Features.Equipment.Queries.EquipmentGetByIdQuery
{
    public class EquipmentGetByIdRequest : IRequest<EquipmentGetByIdDto>
    {
		public int Id { get; set; }
	}
}
