using MediatR;
using Microsoft.AspNetCore.Http;

namespace NeftchiLLC.Application.Features.Partner.Commands.PartnerEditCommand
{
    public class PartnerEditRequest : IRequest
    {
		public int Id { get; set; }
		public string? Name { get; set; }
		public string? WebsiteUrl { get; set; }
		public int Order { get; set; }
		public IFormFile? File { get; set; }
	}
}
