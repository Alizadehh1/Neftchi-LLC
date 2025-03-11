using Intelect.Domain.Core.Commons;
using Intelect.Infrastructure.Core.Concepts.TransactionalConcept;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using NeftchiLLC.Application.Features.Portfolio.Commands.PortfolioAddCommand;
using NeftchiLLC.Application.Features.Portfolio.Commands.PortfolioEditCommand;
using NeftchiLLC.Application.Features.Portfolio.Commands.PortfolioRemoveCommand;
using NeftchiLLC.Application.Features.Portfolio.Queries.PortfolioGetByIdQuery;
using NeftchiLLC.Application.Features.Portfolio.Queries.PortfoliosGetAllRequest;

namespace NeftchiLLC.Api.Controllers
{
	[Route("api/portfolios")]
	[ApiController]
	public class PortfolioController(IMediator mediator) : ControllerBase
	{
		[HttpPost]
		[Transaction]
		public async Task<IActionResult> Add([FromForm] PortfolioAddRequest request)
		{
			var response = await mediator.Send(request);
			var dto = ApiResponse.Success(response);
			return Ok(dto);
		}
		[HttpPut("{id:int:min(1)}")]
		[Transaction]
		public async Task<IActionResult> Edit(int id, [FromForm] PortfolioEditRequest request)
		{
			request.Id = id;
			await mediator.Send(request);
			return Ok();
		}
		[HttpDelete("remove/{id:int:min(1)}")]
		[Transaction]
		public async Task<IActionResult> Remove(int id, [FromForm] PortfolioRemoveRequest request)
		{
			request.Id = id;
			await mediator.Send(request);
			return Ok();
		}
		[HttpGet()]
		public async Task<IActionResult> GetAll([FromQuery] PortfoliosGetAllRequest request)
		{
			var response = await mediator.Send(request);
			var dto = ApiResponse.Success(response);
			return Ok(dto);
		}
		[HttpGet("{id:int:min(1)}")]
		public async Task<IActionResult> GetById([FromRoute] PortfolioGetByIdRequest request)
		{
			var response = await mediator.Send(request);
			var dto = ApiResponse.Success(response);
			return Ok(dto);
		}
	}
}
