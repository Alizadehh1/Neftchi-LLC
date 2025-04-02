using MediatR;

namespace NeftchiLLC.Application.Features.Equipment.Queries.EquipmentGetAllQuery
{
    public class EquipmentGetAllRequest : IRequest<List<EquipmentGetAllDto>>
    {
		public string? SearchTerm { get; set; }
	}
}
