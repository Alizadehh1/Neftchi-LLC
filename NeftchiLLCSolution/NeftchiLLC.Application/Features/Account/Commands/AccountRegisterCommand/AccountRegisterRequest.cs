using MediatR;

namespace NeftchiLLC.Application.Features.Account.Commands.AccountRegisterCommand
{
    public class AccountRegisterRequest : IRequest
    {
		public string Email { get; set; }
		public string Password { get; set; }
	}
}
