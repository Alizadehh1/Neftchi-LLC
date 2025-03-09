using Intelect.Domain.Core.Commons;
using Intelect.Infrastructure.Core.Concepts.TransactionalConcept;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using NeftchiLLC.Application.Dtos;
using NeftchiLLC.Application.Features.License.Commands.LicenseAddCommand;
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
		[HttpGet()]
		public async Task<IActionResult> GetAll([FromQuery] LicensesGetAllRequest request)
		{
			var response = await mediator.Send(request);
			var dto = ApiResponse.Success(response);
			return Ok(dto);
		}
	}
}
