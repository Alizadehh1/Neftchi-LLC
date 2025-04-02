using NeftchiLLC.Application.Dtos;
using System.Reflection.Metadata;
using MediatR;

namespace NeftchiLLC.Application.Features.Certificate.Commands.CertificateAddCommand
{
    public class RecommendationAddRequest : IRequest<Domain.Models.Entities.Document>
    {
        public string Name { get; set; }
        public required List<DocumentAddFileDto> Files { get; set; }
    }
}
