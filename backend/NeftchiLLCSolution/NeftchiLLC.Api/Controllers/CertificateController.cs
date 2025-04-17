using Intelect.Domain.Core.Commons;
using Intelect.Infrastructure.Core.Concepts.TransactionalConcept;
using MediatR;
using Microsoft.AspNetCore.Authorization;
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
		[Authorize(Roles = "Admin")]
		public async Task<IActionResult> Add([FromForm] CertificateAddRequest request)
        {
            var response = await mediator.Send(request);
            var dto = ApiResponse.Success(response);
            return Ok(dto);
        }
        [HttpPut("{id:int:min(1)}")]
        [Transaction]
		[Authorize(Roles = "Admin")]
		public async Task<IActionResult> Edit(int id, [FromForm] CertificateEditRequest request)
        {
            request.Id = id;
            await mediator.Send(request);
            return Ok();
        }


        [HttpDelete("remove/{id:int:min(1)}")]
        [Transaction]
		[Authorize(Roles = "Admin")]
		public async Task<IActionResult> Remove(int id, [FromForm] CertificateRemoveRequest request)
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
