using MediatR;
using Microsoft.AspNetCore.Identity;
using NeftchiLLC.Domain.Models.Membership;

namespace NeftchiLLC.Application.Features.Account.Queries
{
	class UserGetAllRequestHandler(UserManager<NeftchiUser> userManager) : IRequestHandler<UserGetAllRequest, List<UserDto>>
	{

		public async Task<List<UserDto>> Handle(UserGetAllRequest request, CancellationToken cancellationToken)
		{
			var users = userManager.Users.ToList(); 

			var result = users.Select(u => new UserDto
			{
				Id = u.Id,
				Email = u.Email
			}).ToList();

			return await Task.FromResult(result);
		}
	}
}
