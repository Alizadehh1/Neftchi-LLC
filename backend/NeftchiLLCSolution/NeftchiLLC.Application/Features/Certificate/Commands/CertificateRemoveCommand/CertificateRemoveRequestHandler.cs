using MediatR;
using NeftchiLLC.Application.Repositories;
using NeftchiLLC.Application.Services;

namespace NeftchiLLC.Application.Features.Certificate.Commands.CertificateRemoveCommand
{
	class CertificateRemoveRequestHandler(IDocumentRepository documentRepository,AzureBlobService azureBlobService) : IRequestHandler<CertificateRemoveRequest>
	{
		public async Task Handle(CertificateRemoveRequest request, CancellationToken cancellationToken)
		{
			var document = await documentRepository.GetAsync(d => d.DeletedAt == null && d.Type == Domain.Models.StableModels.DocumentType.Certification && d.Id == request.Id, cancellationToken: cancellationToken);
			var documentFiles = documentRepository.GetFiles(d => d.DocumentId == document.Id && d.DeletedAt == null).ToList();
			foreach (var file in documentFiles)
			{
				await documentRepository.RemoveFileAsync(file, cancellationToken);
				await azureBlobService.RemoveAsync(file.Path);
			}
			documentRepository.Remove(document);

			await documentRepository.SaveAsync(cancellationToken);
		}
	}
}
