using MediatR;
using NeftchiLLC.Application.Dtos;

namespace NeftchiLLC.Application.Features.Recommendation.Commands.RecommendationAddCommand
{
    public class RecommendationAddRequest : IRequest<Domain.Models.Entities.Document>
    {
        public string Name { get; set; }
        public required List<DocumentAddFileDto> Files { get; set; }
    }
}
