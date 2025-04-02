using Intelect.Domain.Core.Commons;
using Intelect.Infrastructure.Core.Concepts.TransactionalConcept;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NeftchiLLC.Application.Features.Project.Commands.ProjectAddCommand;
using NeftchiLLC.Application.Features.Project.Commands.ProjectEditCommand;
using NeftchiLLC.Application.Features.Project.Commands.ProjectRemoveCommand;
using NeftchiLLC.Application.Features.Project.Queries.ProjectGetByIdQuery;
using NeftchiLLC.Application.Features.Project.Queries.ProjectsGetAllQuery;

namespace NeftchiLLC.Api.Controllers
{
	[Route("api/projects")]
	[ApiController]
	public class ProjectController(IMediator mediator) : ControllerBase
	{
		[HttpPost]
		[Transaction]
		[Authorize(Roles = "Admin")]
		public async Task<IActionResult> Add([FromForm] ProjectAddRequest request)
		{
			var response = await mediator.Send(request);
			var dto = ApiResponse.Success(response);
			return Ok(dto);
		}
		[HttpPut("{id:int:min(1)}")]
		[Transaction]
		[Authorize(Roles = "Admin")]
		public async Task<IActionResult> Edit(int id, [FromForm] ProjectEditRequest request)
		{
			request.Id = id;
			await mediator.Send(request);
			return Ok();
		}
		[HttpDelete("remove/{id:int:min(1)}")]
		[Transaction]
		[Authorize(Roles = "Admin")]
		public async Task<IActionResult> Remove(int id, [FromForm] ProjectRemoveRequest request)
		{
			request.Id = id;
			await mediator.Send(request);
			return Ok();
		}
		[HttpGet()]
		public async Task<IActionResult> GetAll([FromQuery] ProjectsGetAllRequest request)
		{
			var response = await mediator.Send(request);
			var dto = ApiResponse.Success(response);
			return Ok(dto);
		}
		[HttpGet("{id:int:min(1)}")]
		public async Task<IActionResult> GetById([FromRoute] ProjectGetByIdRequest request)
		{
			var response = await mediator.Send(request);
			var dto = ApiResponse.Success(response);
			return Ok(dto);
		}
	}
}
