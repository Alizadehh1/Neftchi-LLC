using Intelect.Domain.Core.Commons;
using Intelect.Infrastructure.Core.Concepts.TransactionalConcept;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NeftchiLLC.Application.Features.Service.Commands.ServiceAddCommand;
using NeftchiLLC.Application.Features.Service.Commands.ServiceEditCommand;
using NeftchiLLC.Application.Features.Service.Commands.ServiceRemoveCommand;
using NeftchiLLC.Application.Features.Service.Queries.ServiceGetByIdQuery;
using NeftchiLLC.Application.Features.Service.Queries.ServicesGetAllQuery;

namespace NeftchiLLC.Api.Controllers
{
	[Route("api/services")]
	[ApiController]
	public class ServiceController(IMediator mediator) : ControllerBase
	{
		[HttpPost]
		[Transaction]
		[Authorize(Roles = "Admin")]
		public async Task<IActionResult> Add([FromForm] ServiceAddRequest request)
		{
			var response = await mediator.Send(request);
			var dto = ApiResponse.Success(response);
			return Ok(dto);
		}
		[HttpPut("{id:int:min(1)}")]
		[Transaction]
		[Authorize(Roles = "Admin")]
		public async Task<IActionResult> Edit(int id, [FromForm] ServiceEditRequest request)
		{
			request.Id = id;
			await mediator.Send(request);
			return Ok();
		}
		[HttpDelete("remove/{id:int:min(1)}")]
		[Transaction]
		[Authorize(Roles = "Admin")]
		public async Task<IActionResult> Remove(int id, [FromForm] ServiceRemoveRequest request)
		{
			request.Id = id;
			await mediator.Send(request);
			return Ok();
		}
		[HttpGet()]
		public async Task<IActionResult> GetAll([FromQuery] ServicesGetAllRequest request)
		{
			var response = await mediator.Send(request);
			var dto = ApiResponse.Success(response);
			return Ok(dto);
		}
		[HttpGet("{id:int:min(1)}")]
		public async Task<IActionResult> GetById([FromRoute] ServiceGetByIdRequest request)
		{
			var response = await mediator.Send(request);
			var dto = ApiResponse.Success(response);
			return Ok(dto);
		}
	}
}
