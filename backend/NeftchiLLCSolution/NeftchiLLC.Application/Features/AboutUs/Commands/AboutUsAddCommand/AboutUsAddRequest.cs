using MediatR;
using Microsoft.AspNetCore.Http;

namespace NeftchiLLC.Application.Features.AboutUs.Commands.AboutUsAddCommand
{
    public class AboutUsAddRequest : IRequest
    {
		public string Title { get; set; }
		public string Content { get; set; }
		public IFormFile File { get; set; }
	}
}
