using MediatR;
using Microsoft.EntityFrameworkCore;
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
			var files = documentRepository.GetFiles(d => d.DeletedAt == null);

			return await documents.Select(f => new DocumentGetAllDto
			{
				Files = files.Where(x => x.DocumentId == f.Id).Select(d => new DocumentFileGetAllDto
				{
					IsMain = d.IsMain,
					Name = d.Name,
					Path = d.Path,
					Id = d.Id,
				}).ToList(),
				Name = f.Name,
				Id = f.Id,
			}).ToListAsync(cancellationToken);
		}
	}
}
