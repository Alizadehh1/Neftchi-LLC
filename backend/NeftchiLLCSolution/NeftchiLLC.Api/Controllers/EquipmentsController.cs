using Intelect.Domain.Core.Commons;
using Intelect.Infrastructure.Core.Concepts.TransactionalConcept;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NeftchiLLC.Application.Features.Equipment.Commands.EquipmentAddCommand;
using NeftchiLLC.Application.Features.Equipment.Commands.EquipmentEditCommand;
using NeftchiLLC.Application.Features.Equipment.Commands.EquipmentRemoveCommand;
using NeftchiLLC.Application.Features.Equipment.Queries.EquipmentGetAllQuery;
using NeftchiLLC.Application.Features.Equipment.Queries.EquipmentGetByIdQuery;
namespace NeftchiLLC.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EquipmentsController(IMediator mediator) : ControllerBase
    {
		[HttpGet]
		public async Task<IActionResult> GetAll([FromQuery]EquipmentGetAllRequest request)
		{
			var response = await mediator.Send(request);
			var dto = ApiResponse.Success(response);
			return Ok(dto);
		}
		[HttpGet("{id:int:min(1)}")]
		public async Task<IActionResult> GetById([FromRoute] EquipmentGetByIdRequest request)
		{
			var response = await mediator.Send(request);
			var dto = ApiResponse.Success(response);
			return Ok(dto);
		}
		[HttpPost]
		[Transaction]
		[Authorize(Roles = "Admin")]
		public async Task<IActionResult> Add([FromForm] EquipmentAddRequest request)
		{
			await mediator.Send(request);
			return Ok();
		}
		[HttpPut("{id:int:min(1)}")]
		[Transaction]
		[Authorize(Roles = "Admin")]
		public async Task<IActionResult> Edit(int id, [FromForm] EquipmentEditRequest request)
		{
			request.Id = id;
			await mediator.Send(request);
			return Ok();
		}
		[HttpDelete("remove/{id:int:min(1)}")]
		[Transaction]
		[Authorize(Roles = "Admin")]
		public async Task<IActionResult> Remove(int id, [FromForm] EquipmentRemoveRequest request)
		{
			request.Id = id;
			await mediator.Send(request);
			return Ok();
		}
	}
}
