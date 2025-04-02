using MediatR;
using Microsoft.AspNetCore.Identity;
using NeftchiLLC.Domain.Models.Membership;

namespace NeftchiLLC.Application.Features.Account.Commands.AccountSignOutCommand
{
	class AccountSignOutRequestHandler(SignInManager<NeftchiUser> signInManager) : IRequestHandler<AccountSignOutRequest>
	{
		public async Task Handle(AccountSignOutRequest request, CancellationToken cancellationToken)
		{
			await signInManager.SignOutAsync();
		}
	}
}
