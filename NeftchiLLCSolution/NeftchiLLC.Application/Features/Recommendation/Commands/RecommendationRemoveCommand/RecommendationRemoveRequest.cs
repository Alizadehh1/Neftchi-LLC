using MediatR;

namespace NeftchiLLC.Application.Features.Recommendation.Commands.RecommendationRemoveCommand
{
	public class RecommendationRemoveRequest : IRequest
	{
		public int Id { get; set; }
	}
}
