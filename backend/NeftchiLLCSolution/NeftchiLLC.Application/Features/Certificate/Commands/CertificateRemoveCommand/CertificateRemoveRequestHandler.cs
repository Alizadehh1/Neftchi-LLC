using MediatR;
using NeftchiLLC.Application.Repositories;

namespace NeftchiLLC.Application.Features.Certificate.Commands.CertificateRemoveCommand
{
	class RecommendationRemoveRequestHandler(IDocumentRepository documentRepository) : IRequestHandler<RecommendationRemoveRequest>
	{
		public async Task Handle(RecommendationRemoveRequest request, CancellationToken cancellationToken)
		{
			var document = await documentRepository.GetAsync(d => d.DeletedAt == null && d.Type == Domain.Models.StableModels.DocumentType.Certification && d.Id == request.Id, cancellationToken: cancellationToken);
			var documentFiles = documentRepository.GetFiles(d => d.DocumentId == document.Id && d.DeletedAt == null);
			foreach (var file in documentFiles)
				await documentRepository.RemoveFileAsync(file, cancellationToken);
			documentRepository.Remove(document);

			await documentRepository.SaveAsync(cancellationToken);
		}
	}
}
