using Intelect.Domain.Core.Commons;
using Intelect.Infrastructure.Core.Concepts.TransactionalConcept;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NeftchiLLC.Application.Features.AboutUs.Commands.AboutUsAddCommand;
using NeftchiLLC.Application.Features.AboutUs.Commands.AboutUsEditCommand;
using NeftchiLLC.Application.Features.AboutUs.Commands.AboutUsRemoveCommand;
using NeftchiLLC.Application.Features.AboutUs.Queries.AboutUsGetAllQuery;
using NeftchiLLC.Application.Features.AboutUs.Queries.AboutUsGetByIdQuery;
namespace NeftchiLLC.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AboutUsesController(IMediator mediator) : ControllerBase
    {
		[HttpGet]
		public async Task<IActionResult> GetAll([FromQuery] AboutUsGetAllRequest request)
		{
			var response = await mediator.Send(request);
			var dto = ApiResponse.Success(response);
			return Ok(dto);
		}
		[HttpGet("{id:int:min(1)}")]
		public async Task<IActionResult> GetById([FromRoute] AboutUsGetByIdRequest request)
		{
			var response = await mediator.Send(request);
			var dto = ApiResponse.Success(response);
			return Ok(dto);
		}
		[HttpPost]
		[Transaction]
		[Authorize(Roles = "Admin")]
		public async Task<IActionResult> Add([FromForm] AboutUsAddRequest request)
		{
			await mediator.Send(request);
			return Ok();
		}
		[HttpPut("{id:int:min(1)}")]
		[Transaction]
		[Authorize(Roles = "Admin")]
		public async Task<IActionResult> Edit(int id, [FromForm] AboutUsEditRequest request)
		{
			request.Id = id;
			await mediator.Send(request);
			return Ok();
		}
		[HttpDelete("remove/{id:int:min(1)}")]
		[Transaction]
		[Authorize(Roles = "Admin")]
		public async Task<IActionResult> Remove(int id, [FromForm] AboutUsRemoveRequest request)
		{
			request.Id = id;
			await mediator.Send(request);
			return Ok();
		}
	}
}
