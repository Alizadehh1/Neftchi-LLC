using Intelect.Application.Core.Services;
using Intelect.Infrastructure.Core.Services;
using MediatR;
using Microsoft.AspNetCore.Hosting;
using NeftchiLLC.Application.Extensions;
using NeftchiLLC.Application.Repositories;
using NeftchiLLC.Domain.Models.Entities;
using NeftchiLLC.Domain.Models.StableModels;

namespace NeftchiLLC.Application.Features.License.Commands.LicenseAddCommand
{
	class LicenseAddRequestHandler : IRequestHandler<LicenseAddRequest, Document>
	{
		private readonly IFileService fileService;
		private readonly IDocumentRepository documentRepository;
		private readonly LocalFileService localFileService;

		public LicenseAddRequestHandler(IFileService fileService, IDocumentRepository documentRepository, LocalFileService localFileService)
		{
			this.fileService = fileService;
			this.documentRepository = documentRepository;
			this.localFileService = localFileService;
		}
		public async Task<Document> Handle(LicenseAddRequest request, CancellationToken cancellationToken)
		{
			var license = new Document
			{
				Name = request.Name,
				Type = DocumentType.License,
			};

			await documentRepository.AddAsync(license, cancellationToken);
			await documentRepository.SaveAsync(cancellationToken);

			var files = await Task.WhenAll(request.Files.Select(async m => new DocumentFile
			{
				Name = Path.GetFileNameWithoutExtension(fileService.UploadAsync(m.File).Result),
				DocumentId = license.Id,
				IsMain = m.IsMain,
				Path = await localFileService.UploadAsync(m.File),
			}));

			await documentRepository.AddFilesAsync(license, files, cancellationToken);
			await documentRepository.SaveAsync(cancellationToken);

			return license;
		}
	}
}
