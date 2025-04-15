using MediatR;
using NeftchiLLC.Application.Repositories;
using NeftchiLLC.Application.Services;
using NeftchiLLC.Domain.Models.Entities;
using NeftchiLLC.Domain.Models.StableModels;
using Document = NeftchiLLC.Domain.Models.Entities.Document;

namespace NeftchiLLC.Application.Features.Recommendation.Commands.RecommendationAddCommand
{
	class RecommendationAddRequestHandler(IDocumentRepository documentRepository, AzureBlobService azureBlobService) : IRequestHandler<RecommendationAddRequest, Document>
	{
		public async Task<Document> Handle(RecommendationAddRequest request, CancellationToken cancellationToken)
		{
			var recommendation = new Document
			{
				Name = request.Name,
				Type = DocumentType.Recommendation,
			};

			await documentRepository.AddAsync(recommendation, cancellationToken);
			await documentRepository.SaveAsync(cancellationToken);

			var files = await Task.WhenAll(request.Files.Select(async m =>
			{
				var uploadedPath = await azureBlobService.UploadAsync(m.File);

				return new DocumentFile
				{
					Name = Path.GetFileNameWithoutExtension(uploadedPath),
					DocumentId = recommendation.Id,
					IsMain = m.IsMain,
					Path = uploadedPath
				};
			}));

			await documentRepository.AddFilesAsync(recommendation, files, cancellationToken);
			await documentRepository.SaveAsync(cancellationToken);

			return recommendation;
		}
	}
}
