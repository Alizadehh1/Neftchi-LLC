using MediatR;

namespace NeftchiLLC.Application.Features.Equipment.Commands.EquipmentEditCommand
{
    public class EquipmentEditRequest : IRequest
    {
		public int Id { get; set; }
		public string Name { get; set; }
		public int Quantity { get; set; }
		public string Model { get; set; }
		public string Description { get; set; }
	}
}
