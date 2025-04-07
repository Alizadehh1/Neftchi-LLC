using MediatR;
using NeftchiLLC.Application.Dtos;

namespace NeftchiLLC.Application.Features.Recommendation.Queries.RecommendationGetByIdQuery
{
	public class RecommendationGetByIdRequest : IRequest<DocumentGetByIdDto>
	{
		public int Id { get; set; }
	}
}
