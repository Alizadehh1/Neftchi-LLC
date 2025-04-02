
using Intelect.Application.Core.Services;
using Intelect.Infrastructure.Core.Services;
using MediatR;
using NeftchiLLC.Application.Repositories;
using NeftchiLLC.Application.Services;
using NeftchiLLC.Domain.Models.Entities;
using NeftchiLLC.Domain.Models.StableModels;
using System.ComponentModel;
using Document = NeftchiLLC.Domain.Models.Entities.Document;

namespace NeftchiLLC.Application.Features.Certificate.Commands.CertificateAddCommand
{
     class RecommendationAddRequestHandler : IRequestHandler<RecommendationAddRequest, Document>
    {
        private readonly IFileService fileService;
        private readonly IDocumentRepository documentRepository;
        private readonly FtpFileService ftpFileService;

        public RecommendationAddRequestHandler(IFileService fileService, IDocumentRepository documentRepository, FtpFileService ftpFileService)
        {
            this.fileService = fileService;
            this.documentRepository = documentRepository;
            this.ftpFileService = ftpFileService;
        }

        public async Task<Document> Handle(RecommendationAddRequest request, CancellationToken cancellationToken)
        {
            var certificate = new Document
            {
                Name = request.Name,
                Type = DocumentType.Certification,
            };

            await documentRepository.AddAsync(certificate, cancellationToken);
            await documentRepository.SaveAsync(cancellationToken);

			var files = request.Files.Select(m =>
			{
				var uploadedPath = ftpFileService.Upload(m.File);

				return new DocumentFile
				{
					Name = Path.GetFileNameWithoutExtension(uploadedPath),
					DocumentId = certificate.Id,
					IsMain = m.IsMain,
					Path = uploadedPath
				};
			});

			await documentRepository.AddFilesAsync(certificate, files, cancellationToken);
            await documentRepository.SaveAsync(cancellationToken);

            return certificate;
        }
    }
}
