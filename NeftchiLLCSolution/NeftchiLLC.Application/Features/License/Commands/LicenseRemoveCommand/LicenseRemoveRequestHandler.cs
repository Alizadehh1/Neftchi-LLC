using MediatR;
using NeftchiLLC.Application.Repositories;

namespace NeftchiLLC.Application.Features.License.Commands.LicenseRemoveCommand
{
	class LicenseRemoveRequestHandler(IDocumentRepository documentRepository) : IRequestHandler<LicenseRemoveRequest>
	{
		public async Task Handle(LicenseRemoveRequest request, CancellationToken cancellationToken)
		{
			var document = await documentRepository.GetAsync(d => d.DeletedAt == null && d.Type == Domain.Models.StableModels.DocumentType.License && d.Id == request.Id, cancellationToken: cancellationToken);
			var documentFiles = documentRepository.GetFiles(d => d.DocumentId == document.Id && d.DeletedAt == null);
			documentRepository.Remove(document);

			foreach (var file in documentFiles)
				await documentRepository.RemoveFileAsync(file, cancellationToken);
			await documentRepository.SaveAsync(cancellationToken);
		}
	}
}
