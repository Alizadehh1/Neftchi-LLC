using Intelect.Application.Core.Services;
using Intelect.Infrastructure.Core.Services;
using MediatR;
using NeftchiLLC.Application.Repositories;
using NeftchiLLC.Domain.Models.Entities;

namespace NeftchiLLC.Application.Features.License.Commands.LicenseEditCommand
{
	class CertificateEditRequestHandler(IDocumentRepository documentRepository, IFileService fileService, LocalFileService localFileService) : IRequestHandler<CertificateEditRequest, string>
	{
		public async Task<string> Handle(CertificateEditRequest request, CancellationToken cancellationToken)
		{
			var license = await documentRepository.GetAsync(d => d.Type == Domain.Models.StableModels.DocumentType.License && d.Id == request.Id && d.DeletedAt == null, cancellationToken: cancellationToken);

			license.Name = request.Name;

			#region Files

			var existingFiles = documentRepository.GetFiles(d => d.DocumentId == request.Id && d.DeletedAt == null).ToList();

			foreach (var requestFile in request.Files)
			{
				var existingFile = existingFiles.FirstOrDefault(ef => ef.Id == requestFile.Id);

				if (existingFile != null)
				{
					bool needsUpdate = false;

					if (existingFile.IsMain != requestFile.IsMain)
					{
						existingFile.IsMain = requestFile.IsMain;
						needsUpdate = true;
					}

					if (needsUpdate)
					{
						await documentRepository.SaveAsync(cancellationToken);
					}
				}
			}

			var filesToAdd = request.Files.Where(newFile => !existingFiles.Any(existingFile => existingFile.Id == newFile.Id)).ToList();
			// Fetch existing files into memory
			var existingFilesList = existingFiles.ToList();

			// Compute files to delete in memory
			var filesToDelete = existingFilesList
				.Where(existingFile => !request.Files.Any(newFile => newFile.Id == existingFile.Id))
				.ToList();


			#region RemoveUnnecessaryFiles

			foreach (var file in filesToDelete)
				await documentRepository.RemoveFileAsync(file);

			#endregion
			#region Add new files

			var newFiles = await Task.WhenAll(filesToAdd.Select(async m => new DocumentFile
			{
				Name = Path.GetFileNameWithoutExtension(fileService.UploadAsync(m.File).Result),
				DocumentId = license.Id,
				IsMain = m.IsMain,
				Path = await localFileService.UploadAsync(m.File),
			}));

			#endregion

			await documentRepository.AddFilesAsync(license, newFiles, cancellationToken);
			await documentRepository.SaveAsync(cancellationToken);

			#endregion

			await documentRepository.SaveAsync(cancellationToken);
			return license.Name;
		}
	}
}
