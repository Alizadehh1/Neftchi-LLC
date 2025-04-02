using MediatR;
using Microsoft.AspNetCore.Http;

namespace NeftchiLLC.Application.Features.AboutUs.Commands.AboutUsEditCommand
{
    public class AboutUsEditRequest : IRequest
    {
		public int Id { get; set; }
		public string Title { get; set; }
		public string Content { get; set; }
		public IFormFile? File { get; set; }
	}
}
