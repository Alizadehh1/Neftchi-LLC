using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NeftchiLLC.Application.Features.Account.Commands.AccountLoginCommand;
using NeftchiLLC.Application.Features.Account.Commands.AccountRegisterCommand;
using NeftchiLLC.Application.Features.Account.Commands.AccountSignOutCommand;

namespace NeftchiLLC.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController(IMediator mediator) : ControllerBase
    {
		[HttpPost("login")]
		public async Task<IActionResult> Login([FromBody] AccountLoginRequest request)
		{
			try
			{
				await mediator.Send(request);
				return Ok("Giriş uğurludur!");
			}
			catch (UnauthorizedAccessException ex)
			{
				return Unauthorized(ex.Message);
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}
		}

		[Authorize(Roles = "Admin")]
		[HttpPost("register")]
		public async Task<IActionResult> CreateAdmin([FromBody] AccountRegisterRequest request)
		{
			try
			{
				await mediator.Send(request);
				return Ok("Admin istifadəçi uğurla yaradıldı!");
			}
			catch (UnauthorizedAccessException ex)
			{
				return Unauthorized(ex.Message);
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}
		}
		[Authorize]
		[HttpPost("signout")]
		public async Task<IActionResult> SignOut()
		{
			await mediator.Send(new AccountSignOutRequest());
			return Ok("Çıxış uğurludur!");
		}

	}
}
