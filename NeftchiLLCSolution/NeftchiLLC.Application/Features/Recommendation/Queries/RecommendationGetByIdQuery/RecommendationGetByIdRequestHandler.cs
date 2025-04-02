using MediatR;
using NeftchiLLC.Application.Dtos;
using NeftchiLLC.Application.Repositories;

namespace NeftchiLLC.Application.Features.Recommendation.Queries.RecommendationGetByIdQuery
{
	class RecommendationGetByIdRequestHandler(IDocumentRepository documentRepository) : IRequestHandler<RecommendationGetByIdRequest, DocumentGetByIdDto>
	{
		public async Task<DocumentGetByIdDto> Handle(RecommendationGetByIdRequest request, CancellationToken cancellationToken)
		{
			var recommendation = await documentRepository.GetAsync(d => d.Type == Domain.Models.StableModels.DocumentType.Letter && d.DeletedAt == null && d.Id == request.Id, cancellationToken: cancellationToken);

			var files = documentRepository.GetFiles(d => d.DeletedAt == null && d.IsMain && d.DocumentId == recommendation.Id);

			var result = new DocumentGetByIdDto
			{
				Id = recommendation.Id,
				Name = recommendation.Name,
				Files = files.Select(d => new DocumentFileGetByIdDto
				{
					Id = d.Id,
					Name = d.Name,
					Path = d.Path,
					IsMain = d.IsMain
				}).ToList()
			};

			return result;
		}
	}
}
