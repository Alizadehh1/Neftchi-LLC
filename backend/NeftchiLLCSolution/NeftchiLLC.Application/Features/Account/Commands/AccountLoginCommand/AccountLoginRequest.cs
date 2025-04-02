using MediatR;

namespace NeftchiLLC.Application.Features.Account.Commands.AccountLoginCommand
{
    public class AccountLoginRequest : IRequest
    {
		public string Email { get; set; }
		public string Password { get; set; }
	}
}
