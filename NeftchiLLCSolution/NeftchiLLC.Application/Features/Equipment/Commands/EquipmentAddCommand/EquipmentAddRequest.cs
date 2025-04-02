using MediatR;

namespace NeftchiLLC.Application.Features.Equipment.Commands.EquipmentAddCommand
{
    public class EquipmentAddRequest : IRequest
    {
		public string Name { get; set; }
		public int Quantity { get; set; }
		public string Model { get; set; }
		public string Description { get; set; }
	}
}
