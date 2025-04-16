using MediatR;
using NeftchiLLC.Application.Repositories;
using NeftchiLLC.Application.Services;
using NeftchiLLC.Domain.Models.Entities;

namespace NeftchiLLC.Application.Features.Recommendation.Commands.RecommendationEditCommand
{
	class RecommendationEditRequestHandler(IDocumentRepository documentRepository, AzureBlobService azureBlobService) : IRequestHandler<RecommendationEditRequest, string>
	{
		public async Task<string> Handle(RecommendationEditRequest request, CancellationToken cancellationToken)
		{
			var recommendation = await documentRepository.GetAsync(d => d.Type == Domain.Models.StableModels.DocumentType.Recommendation && d.Id == request.Id && d.DeletedAt == null, cancellationToken: cancellationToken);

			recommendation.Name = request.Name;

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
			{
				await documentRepository.RemoveFileAsync(file);
				await azureBlobService.RemoveAsync(file.Path);
			}

			#endregion
			#region Add new files

			var newFiles = await Task.WhenAll(filesToAdd.Select(async m =>
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

			#endregion

			await documentRepository.AddFilesAsync(recommendation, newFiles, cancellationToken);
			await documentRepository.SaveAsync(cancellationToken);

			#endregion

			await documentRepository.SaveAsync(cancellationToken);
			return recommendation.Name;
		}
	}
}
