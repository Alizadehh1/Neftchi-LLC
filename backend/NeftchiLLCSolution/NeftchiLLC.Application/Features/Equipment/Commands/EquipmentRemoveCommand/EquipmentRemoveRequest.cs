using MediatR;

namespace NeftchiLLC.Application.Features.Equipment.Commands.EquipmentRemoveCommand
{
    public class EquipmentRemoveRequest : IRequest
    {
		public int Id { get; set; }
	}
}
