using MediatR;

namespace NeftchiLLC.Application.Features.AboutUs.Commands.AboutUsRemoveCommand
{
    public class AboutUsRemoveRequest: IRequest
    {
		public int Id { get; set; }
	}
}
