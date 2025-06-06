﻿using Intelect.Domain.Core.Commons;
using Intelect.Infrastructure.Core.Concepts.TransactionalConcept;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NeftchiLLC.Application.Features.Recommendation.Commands.RecommendationAddCommand;
using NeftchiLLC.Application.Features.Recommendation.Commands.RecommendationEditCommand;
using NeftchiLLC.Application.Features.Recommendation.Commands.RecommendationRemoveCommand;
using NeftchiLLC.Application.Features.Recommendation.Queries.RecommendationGetAllRequest;
using NeftchiLLC.Application.Features.Recommendation.Queries.RecommendationGetByIdQuery;


namespace NeftchiLLC.Api.Controllers
{
    [Route("api/recommendations")]
    [ApiController]
    public class RecommendationController(IMediator mediator) : ControllerBase
    {
        [HttpPost]
        [Transaction]
		[Authorize(Roles = "Admin")]
		public async Task<IActionResult> Add([FromForm] RecommendationAddRequest request)
        {
            var response = await mediator.Send(request);
            var dto = ApiResponse.Success(response);
            return Ok(dto);
        }
        [HttpPut("{id:int:min(1)}")]
        [Transaction]
		[Authorize(Roles = "Admin")]
		public async Task<IActionResult> Edit(int id, [FromForm] RecommendationEditRequest request)
        {
            request.Id = id;
            await mediator.Send(request);
            return Ok();
        }
        [HttpDelete("remove/{id:int:min(1)}")]
        [Transaction]
		[Authorize(Roles = "Admin")]
		public async Task<IActionResult> Remove(int id, [FromForm] RecommendationRemoveRequest request)
        {
            request.Id = id;
            await mediator.Send(request);
            return Ok();
        }
        [HttpGet()]
        public async Task<IActionResult> GetAll([FromQuery] RecommendationGetAllRequest request)
        {
            var response = await mediator.Send(request);
            var dto = ApiResponse.Success(response);
            return Ok(dto);
        }
        [HttpGet("{id:int:min(1)}")]
        public async Task<IActionResult> GetById([FromRoute] RecommendationGetByIdRequest request)
        {
            var response = await mediator.Send(request);
            var dto = ApiResponse.Success(response);
            return Ok(dto);
        }
    }
}
