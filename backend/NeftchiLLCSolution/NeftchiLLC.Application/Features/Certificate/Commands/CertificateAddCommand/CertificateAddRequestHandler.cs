using MediatR;
using NeftchiLLC.Application.Repositories;
using NeftchiLLC.Application.Services;
using NeftchiLLC.Domain.Models.Entities;
using NeftchiLLC.Domain.Models.StableModels;
using Document = NeftchiLLC.Domain.Models.Entities.Document;

namespace NeftchiLLC.Application.Features.Certificate.Commands.CertificateAddCommand
{
	class CertificateAddRequestHandler : IRequestHandler<CertificateAddRequest, Document>
	{
		private readonly IDocumentRepository documentRepository;
		private readonly AzureBlobService azureBlobService;

		public CertificateAddRequestHandler(IDocumentRepository documentRepository, AzureBlobService azureBlobService)
		{
			this.documentRepository = documentRepository;
			this.azureBlobService = azureBlobService;
		}

		public async Task<Document> Handle(CertificateAddRequest request, CancellationToken cancellationToken)
		{
			var certificate = new Document
			{
				Name = request.Name,
				Type = DocumentType.Certification,
			};

			await documentRepository.AddAsync(certificate, cancellationToken);
			await documentRepository.SaveAsync(cancellationToken);

			var files = await Task.WhenAll(request.Files.Select(async m =>
			{
				var uploadedPath = await azureBlobService.UploadAsync(m.File);

				return new DocumentFile
				{
					Name = Path.GetFileNameWithoutExtension(uploadedPath),
					DocumentId = certificate.Id,
					IsMain = m.IsMain,
					Path = uploadedPath
				};
			}));

			await documentRepository.AddFilesAsync(certificate, files, cancellationToken);
			await documentRepository.SaveAsync(cancellationToken);

			return certificate;
		}
	}
}
