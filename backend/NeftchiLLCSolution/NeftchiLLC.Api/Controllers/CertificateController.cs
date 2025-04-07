using Intelect.Domain.Core.Commons;
using Intelect.Infrastructure.Core.Concepts.TransactionalConcept;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using NeftchiLLC.Application.Features.Certificate.Commands.CertificateAddCommand;
using NeftchiLLC.Application.Features.Certificate.Commands.CertificateEditCommand;
using NeftchiLLC.Application.Features.Certificate.Commands.CertificateRemoveCommand;
using NeftchiLLC.Application.Features.Certificate.Queries.CertificateGetAllRequest;
using NeftchiLLC.Application.Features.Certificate.Queries.CertificateGetByIdQuery;


namespace NeftchiLLC.Api.Controllers
{
    [Route("api/certificates")]
    [ApiController]
    public class CertificateController(IMediator mediator) : ControllerBase
    {
        [HttpPost]
        [Transaction]
        public async Task<IActionResult> Add([FromForm] RecommendationAddRequest request)
        {
            var response = await mediator.Send(request);
            var dto = ApiResponse.Success(response);
            return Ok(dto);
        }
        [HttpPut("{id:int:min(1)}")]
        [Transaction]
        public async Task<IActionResult> Edit(int id, [FromForm] RecommendationEditRequest request)
        {
            request.Id = id;
            await mediator.Send(request);
            return Ok();
        }


        [HttpDelete("remove/{id:int:min(1)}")]
        [Transaction]
        public async Task<IActionResult> Remove(int id, [FromForm] RecommendationRemoveRequest request)
        {
            request.Id = id;
            await mediator.Send(request);
            return Ok();
        }
        
        [HttpGet()]
        public async Task<IActionResult> GetAll([FromQuery] CertificateGetAllRequest request)
        {
            var response = await mediator.Send(request);
            var dto = ApiResponse.Success(response);
            return Ok(dto);
        }
        [HttpGet("{id:int:min(1)}")]
        public async Task<IActionResult> GetById([FromRoute] CertificateGetByIdRequest request)
        {
            var response = await mediator.Send(request);
            var dto = ApiResponse.Success(response);
            return Ok(dto);
        }
    }
}
