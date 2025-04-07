using Intelect.Domain.Core.Commons;
using Intelect.Infrastructure.Core.Concepts.TransactionalConcept;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NeftchiLLC.Application.Features.Activities.Commands.ActivitiesAddCommand;
using NeftchiLLC.Application.Features.Activities.Commands.ActivitiesEditCommand;
using NeftchiLLC.Application.Features.Activities.Commands.ActivitiesRemoveCommand;
using NeftchiLLC.Application.Features.Activities.Queries.ActivitiesGetAllQuery;
using NeftchiLLC.Application.Features.Activities.Queries.ActivitiesGetByIdQuery;
namespace NeftchiLLC.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActivitiesController(IMediator mediator) : ControllerBase
    {
		[HttpGet]
		public async Task<IActionResult> GetAll(ActivitiesGetAllRequest request)
		{
			var response = await mediator.Send(request);
			var dto = ApiResponse.Success(response);
			return Ok(dto);
		}
		[HttpGet("{id:int:min(1)}")]
		public async Task<IActionResult> GetById([FromRoute] ActivitiesGetByIdRequest request)
		{
			var response = await mediator.Send(request);
			var dto = ApiResponse.Success(response);
			return Ok(dto);
		}
		[HttpPost]
		[Transaction]
		[Authorize(Roles = "Admin")]
		public async Task<IActionResult> Add([FromForm] ActivitiesAddRequest request)
		{
			await mediator.Send(request);
			return Ok();
		}
		[HttpPut("{id:int:min(1)}")]
		[Transaction]
		[Authorize(Roles = "Admin")]
		public async Task<IActionResult> Edit(int id, [FromForm] ActivitiesEditRequest request)
		{
			request.Id = id;
			await mediator.Send(request);
			return Ok();
		}
		[HttpDelete("remove/{id:int:min(1)}")]
		[Transaction]
		[Authorize(Roles = "Admin")]
		public async Task<IActionResult> Remove(int id, [FromForm] ActivitiesRemoveRequest request)
		{
			request.Id = id;
			await mediator.Send(request);
			return Ok();
		}
	}
}
