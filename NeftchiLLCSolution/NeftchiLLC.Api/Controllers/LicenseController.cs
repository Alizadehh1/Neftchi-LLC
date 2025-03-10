using Intelect.Domain.Core.Commons;
using Intelect.Infrastructure.Core.Concepts.TransactionalConcept;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using NeftchiLLC.Application.Features.License.Commands.LicenseAddCommand;
using NeftchiLLC.Application.Features.License.Commands.LicenseEditCommand;
using NeftchiLLC.Application.Features.License.Commands.LicenseRemoveCommand;
using NeftchiLLC.Application.Features.License.Queries.LicenseGetByIdQuery;
using NeftchiLLC.Application.Features.License.Queries.LicensesGetAllRequest;

namespace NeftchiLLC.Api.Controllers
{
	[Route("api/licences")]
	[ApiController]
	public class LicenseController(IMediator mediator) : ControllerBase
	{
		[HttpPost]
		[Transaction]
		public async Task<IActionResult> Add([FromForm] LicenseAddRequest request)
		{
			var response = await mediator.Send(request);
			var dto = ApiResponse.Success(response);
			return Ok(dto);
		}
		[HttpPut("{id:int:min(1)}")]
		[Transaction]
		public async Task<IActionResult> Edit(int id, [FromForm] LicenseEditRequest request)
		{
			request.Id = id;
			await mediator.Send(request);
			return Ok();
		}
		[HttpDelete("remove/{id:int:min(1)}")]
		[Transaction]
		public async Task<IActionResult> Remove(int id, [FromForm] LicenseRemoveRequest request)
		{
			request.Id = id;
			await mediator.Send(request);
			return Ok();
		}
		[HttpGet()]
		public async Task<IActionResult> GetAll([FromQuery] LicensesGetAllRequest request)
		{
			var response = await mediator.Send(request);
			var dto = ApiResponse.Success(response);
			return Ok(dto);
		}
		[HttpGet("{id:int:min(1)}")]
		public async Task<IActionResult> GetById([FromRoute] LicenseGetByIdRequest request)
		{
			var response = await mediator.Send(request);
			var dto = ApiResponse.Success(response);
			return Ok(dto);
		}
	}
}
