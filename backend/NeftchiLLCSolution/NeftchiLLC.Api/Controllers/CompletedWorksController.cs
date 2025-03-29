using Intelect.Domain.Core.Commons;
using Intelect.Infrastructure.Core.Concepts.TransactionalConcept;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NeftchiLLC.Application.Features.CompletedWork.Commands.CompletedWorkAddCommand;
using NeftchiLLC.Application.Features.CompletedWork.Commands.CompletedWorkEditCommand;
using NeftchiLLC.Application.Features.CompletedWork.Commands.CompletedWorkRemoveCommand;
using NeftchiLLC.Application.Features.CompletedWork.Queries.CompletedWorkGetAllQuery;
using NeftchiLLC.Application.Features.CompletedWork.Queries.CompletedWorkGetByIdQuery;

namespace NeftchiLLC.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompletedWorksController(IMediator mediator) : ControllerBase
    {
		[HttpGet]
		public async Task<IActionResult> GetAll(CompletedWorkGetAllRequest request)
		{
			var response = await mediator.Send(request);
			var dto = ApiResponse.Success(response);
			return Ok(dto);
		}
		[HttpGet("{id:int:min(1)}")]
		public async Task<IActionResult> GetById([FromRoute] CompletedWorkGetByIdRequest request)
		{
			var response = await mediator.Send(request);
			var dto = ApiResponse.Success(response);
			return Ok(dto);
		}
		[HttpPost]
		[Transaction]
		[Authorize(Roles = "Admin")]
		public async Task<IActionResult> Add([FromForm] CompletedWorkAddRequest request)
		{
			await mediator.Send(request);
			return Ok();
		}
		[HttpPut("{id:int:min(1)}")]
		[Transaction]
		[Authorize(Roles = "Admin")]
		public async Task<IActionResult> Edit(int id, [FromForm] CompletedWorkEditRequest request)
		{
			request.Id = id;
			await mediator.Send(request);
			return Ok();
		}
		[HttpDelete("remove/{id:int:min(1)}")]
		[Transaction]
		[Authorize(Roles = "Admin")]
		public async Task<IActionResult> Remove(int id, [FromForm] CompletedWorkRemoveRequest request)
		{
			request.Id = id;
			await mediator.Send(request);
			return Ok();
		}
	}
}
