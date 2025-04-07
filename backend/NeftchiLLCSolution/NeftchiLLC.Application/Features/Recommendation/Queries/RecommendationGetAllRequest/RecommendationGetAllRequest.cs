using MediatR;
using NeftchiLLC.Application.Dtos;

namespace NeftchiLLC.Application.Features.Recommendation.Queries.RecommendationGetAllRequest
{
	public class RecommendationGetAllRequest : IRequest<IEnumerable<DocumentGetAllDto>>
	{
	}
}
