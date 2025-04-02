using MediatR;
using Microsoft.EntityFrameworkCore;
using NeftchiLLC.Application.Repositories;

namespace NeftchiLLC.Application.Features.Equipment.Queries.EquipmentGetAllQuery
{
	class EquipmentGetAllRequestHandler(IEquipmentRepository equipmentRepository) : IRequestHandler<EquipmentGetAllRequest, List<EquipmentGetAllDto>>
	{
		public async Task<List<EquipmentGetAllDto>> Handle(EquipmentGetAllRequest request, CancellationToken cancellationToken)
		{
			var values = equipmentRepository.GetAll(d => d.DeletedAt == null);
			if (!string.IsNullOrWhiteSpace(request.SearchTerm))
			{
				string search = request.SearchTerm.ToLower();
				values = values.Where(e =>
					e.Description.ToLower().Contains(search) ||
					e.Model.ToLower().Contains(search) ||
					e.Name.ToLower().Contains(search));
			}
			return await values.Select(d => new EquipmentGetAllDto
			{
				Name = d.Name,
				Description = d.Description,
				Id = d.Id,
				Model = d.Model,
				Quantity = d.Quantity
			}).ToListAsync(cancellationToken);
		}
	}
}
