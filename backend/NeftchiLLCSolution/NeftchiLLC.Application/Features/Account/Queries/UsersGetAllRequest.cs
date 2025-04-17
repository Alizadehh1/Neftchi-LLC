using MediatR;

namespace NeftchiLLC.Application.Features.Account.Queries
{
	public class UserGetAllRequest : IRequest<List<UserDto>>
	{
	}
}
