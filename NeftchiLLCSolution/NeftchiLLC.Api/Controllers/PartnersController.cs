using Intelect.Domain.Core.Commons;
using Intelect.Infrastructure.Core.Concepts.TransactionalConcept;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NeftchiLLC.Application.Features.Partner.Commands.PartnerAddCommand;
using NeftchiLLC.Application.Features.Partner.Commands.PartnerEditCommand;
using NeftchiLLC.Application.Features.Partner.Commands.PartnerRemoveCommand;
using NeftchiLLC.Application.Features.Partner.Queries.PartnerGetAllQuery;
using NeftchiLLC.Application.Features.Partner.Queries.PartnerGetByIdQuery;

namespace NeftchiLLC.Api.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class PartnersController(IMediator mediator) : ControllerBase
	{
		[HttpGet]
		public async Task<IActionResult> GetAll(PartnerGetAllRequest request)
		{
			var response = await mediator.Send(request);
			var dto = ApiResponse.Success(response);
			return Ok(dto);
		}
		[HttpGet("{id:int:min(1)}")]
		public async Task<IActionResult> GetById([FromRoute] PartnerGetByIdRequest request)
		{
			var response = await mediator.Send(request);
			var dto = ApiResponse.Success(response);
			return Ok(dto);
		}
		[HttpPost]
		[Transaction]
		//[Authorize(Roles = "Admin")]
		public async Task<IActionResult> Add([FromForm] PartnerAddRequest request)
		{
			await mediator.Send(request);
			return Ok();
		}
		[HttpPut("{id:int:min(1)}")]
		[Transaction]
		[Authorize(Roles = "Admin")]
		public async Task<IActionResult> Edit(int id, [FromForm] PartnerEditRequest request)
		{
			request.Id = id;
			await mediator.Send(request);
			return Ok();
		}
		[HttpDelete("remove/{id:int:min(1)}")]
		[Transaction]
		[Authorize(Roles = "Admin")]
		public async Task<IActionResult> Remove(int id, [FromForm] PartnerRemoveRequest request)
		{
			request.Id = id;
			await mediator.Send(request);
			return Ok();
		}
	}
}
