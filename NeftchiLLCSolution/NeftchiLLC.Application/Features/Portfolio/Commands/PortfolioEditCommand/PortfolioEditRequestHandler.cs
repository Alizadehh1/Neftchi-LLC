using Intelect.Application.Core.Services;
using Intelect.Infrastructure.Core.Services;
using MediatR;
using NeftchiLLC.Application.Repositories;
using NeftchiLLC.Application.Services;
using NeftchiLLC.Domain.Models.Entities;

namespace NeftchiLLC.Application.Features.Portfolio.Commands.PortfolioEditCommand
{
	class PortfolioEditRequestHandler(IPortfolioRepository portfolioRepository, IFileService fileService, FtpFileService ftpFileService) : IRequestHandler<PortfolioEditRequest, string>
	{
		public async Task<string> Handle(PortfolioEditRequest request, CancellationToken cancellationToken)
		{
			var portfolio = await portfolioRepository.GetAsync(d => d.Id == request.Id && d.DeletedAt == null, cancellationToken: cancellationToken);

			portfolio.Name = request.Name;
			portfolio.Description = request.Description;

			#region Files

			var existingFiles = portfolioRepository.GetFiles(d => d.PortfolioId == request.Id && d.DeletedAt == null).ToList();

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
						await portfolioRepository.SaveAsync(cancellationToken);
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
				await portfolioRepository.RemoveFileAsync(file);

			#endregion
			#region Add new files

			var newFiles = filesToAdd.Select(m =>
			{
				var uploadedPath = ftpFileService.Upload(m.File);
				return new PortfolioFile
				{
					Name = Path.GetFileNameWithoutExtension(uploadedPath),
					PortfolioId = portfolio.Id,
					IsMain = m.IsMain,
					Path = uploadedPath,
				};
		});

			#endregion

			await portfolioRepository.AddFilesAsync(portfolio, newFiles, cancellationToken);
			await portfolioRepository.SaveAsync(cancellationToken);

			#endregion

			await portfolioRepository.SaveAsync(cancellationToken);
			return portfolio.Name;
		}
	}
}
