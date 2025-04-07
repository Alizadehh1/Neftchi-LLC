using MediatR;
using Microsoft.AspNetCore.Identity;
using NeftchiLLC.Domain.Models.Membership;

namespace NeftchiLLC.Application.Features.Account.Commands.AccountLoginCommand
{
	class AccountLoginRequestHandler(UserManager<NeftchiUser> userManager, SignInManager<NeftchiUser> signInManager) : IRequestHandler<AccountLoginRequest>
	{
		public async Task Handle(AccountLoginRequest request, CancellationToken cancellationToken)
		{
			var user = await userManager.FindByEmailAsync(request.Email);
			if (user == null) throw new UnauthorizedAccessException("Invalid credentials");

			var result = await signInManager.PasswordSignInAsync(user, request.Password, false, false);
			if (!result.Succeeded) throw new UnauthorizedAccessException("Invalid credentials");
		}
	}
}
