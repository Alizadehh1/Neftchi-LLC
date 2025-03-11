using NeftchiLLC.Application.Dtos;
using System.Reflection.Metadata;
using MediatR;

namespace NeftchiLLC.Application.Features.Recommendation.Commands.RecommendationAddCommand
{
    public class RecommendationAddRequest : IRequest<Document>
    {
        public string Name { get; set; }
        public required List<DocumentAddFileDto> Files { get; set; }
    }
}
