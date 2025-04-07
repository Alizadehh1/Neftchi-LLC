using MediatR;
using Microsoft.AspNetCore.Identity;
using NeftchiLLC.Domain.Models.Membership;

namespace NeftchiLLC.Application.Features.Account.Commands.AccountRegisterCommand
{
	class AccountRegisterRequestHandler(UserManager<NeftchiUser> userManager, SignInManager<NeftchiUser> signInManager) : IRequestHandler<AccountRegisterRequest>
	{
		public async Task Handle(AccountRegisterRequest request, CancellationToken cancellationToken)
		{
			var user = new NeftchiUser { UserName = request.Email, Email = request.Email };
			var result = await userManager.CreateAsync(user, request.Password);
			if (!result.Succeeded) throw new Exception(string.Join(", ", result.Errors.Select(e => e.Description)));

			await userManager.AddToRoleAsync(user, "Admin");
		}
	}
}
