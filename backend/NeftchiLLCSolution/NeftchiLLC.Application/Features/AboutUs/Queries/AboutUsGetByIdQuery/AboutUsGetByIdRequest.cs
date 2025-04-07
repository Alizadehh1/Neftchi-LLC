using MediatR;

namespace NeftchiLLC.Application.Features.AboutUs.Queries.AboutUsGetByIdQuery
{
    public class AboutUsGetByIdRequest : IRequest<AboutUsGetByIdDto>
    {
		public int Id { get; set; }
	}
}
