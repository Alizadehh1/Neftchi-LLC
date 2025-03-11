using MediatR;
using NeftchiLLC.Application.Dtos;
using NeftchiLLC.Application.Repositories;
using NeftchiLLC.Domain.Models.StableModels;

namespace NeftchiLLC.Application.Features.Recommendation.Queries.RecommendationGetAllRequest
{
	class CertificateGetAllRequestHandler(IDocumentRepository documentRepository) : IRequestHandler<RecommendationGetAllRequest, IEnumerable<DocumentGetAllDto>>
	{
		public async Task<IEnumerable<DocumentGetAllDto>> Handle(RecommendationGetAllRequest request, CancellationToken cancellationToken)
		{
			var documents = documentRepository.GetAll(d => d.DeletedAt == null && d.Type == DocumentType.Letter);
			var files = documentRepository.GetFiles(d => d.DeletedAt == null && d.IsMain);

			var query = from d in documents
						join f in files on d.Id equals f.DocumentId
						select new DocumentGetAllDto
						{
							Id = d.Id,
							Name = d.Name,
							File = new DocumentFileGetAllDto
							{
								Id = f.Id,
								Name = f.Name,
								Path = f.Path,
							},
						};

			return query;
		}
	}
}
