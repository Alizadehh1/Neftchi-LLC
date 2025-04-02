using MediatR;
using NeftchiLLC.Application.Repositories;
using NeftchiLLC.Application.Services;
using NeftchiLLC.Domain.Models.Entities;
using NeftchiLLC.Domain.Models.StableModels;

namespace NeftchiLLC.Application.Features.License.Commands.LicenseAddCommand
{
	class LicenseAddRequestHandler(IDocumentRepository documentRepository, FtpFileService ftpFileService) : IRequestHandler<LicenseAddRequest, Document>
	{
		public async Task<Document> Handle(LicenseAddRequest request, CancellationToken cancellationToken)
		{
			var license = new Document
			{
				Name = request.Name,
				Type = DocumentType.License,
			};

			await documentRepository.AddAsync(license, cancellationToken);
			await documentRepository.SaveAsync(cancellationToken);

			var files = request.Files.Select(m =>
			{
				var uploadedPath = ftpFileService.Upload(m.File);

				return new DocumentFile
				{
					Name = Path.GetFileNameWithoutExtension(uploadedPath),
					DocumentId = license.Id,
					IsMain = m.IsMain,
					Path = uploadedPath
				};
			});

			await documentRepository.AddFilesAsync(license, files, cancellationToken);
			await documentRepository.SaveAsync(cancellationToken);

			return license;
		}
	}
}
