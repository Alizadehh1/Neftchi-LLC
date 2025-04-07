using Intelect.Application.Core.Services;
using MediatR;
using NeftchiLLC.Application.Repositories;
using NeftchiLLC.Domain.Models.Entities;
using NeftchiLLC.Domain.Models.StableModels;

namespace NeftchiLLC.Application.Features.License.Commands.LicenseAddCommand
{
	class LicenseAddRequestHandler(IDocumentRepository documentRepository, LocalFileService localFileService) : IRequestHandler<LicenseAddRequest, Document>
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

			var files = await Task.WhenAll(request.Files.Select(async m =>
			{
				var uploadedPath = await localFileService.UploadAsync(m.File);
				return new DocumentFile
				{
					Name = Path.GetFileNameWithoutExtension(uploadedPath),
					DocumentId = license.Id,
					IsMain = m.IsMain,
					Path = uploadedPath
				};
			}));

			await documentRepository.AddFilesAsync(license, files, cancellationToken);
			await documentRepository.SaveAsync(cancellationToken);

			return license;
		}
	}
}
