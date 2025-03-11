using Intelect.Application.Core.Services;
using Intelect.Infrastructure.Core.Services;
using MediatR;
using NeftchiLLC.Application.Repositories;
using NeftchiLLC.Domain.Models.Entities;
using NeftchiLLC.Domain.Models.StableModels;
using Document = NeftchiLLC.Domain.Models.Entities.Document;

namespace NeftchiLLC.Application.Features.Recommendation.Commands.RecommendationAddCommand
{
    public class RecommendationAddRequestHandler : IRequestHandler<RecommendationAddRequest, Document>
    {
        private readonly IFileService fileService;
        private readonly IDocumentRepository documentRepository;
        private readonly LocalFileService localFileService;

        public RecommendationAddRequestHandler(IFileService fileService, IDocumentRepository documentRepository, LocalFileService localFileService)
        {
            this.fileService = fileService;
            this.documentRepository = documentRepository;
            this.localFileService = localFileService;
        }

        public async Task<Document> Handle(RecommendationAddRequest request, CancellationToken cancellationToken)
        {
            var recommendation = new Document
            {
                Name = request.Name,
                Type = DocumentType.Letter,
            };

            await documentRepository.AddAsync(recommendation, cancellationToken);
            await documentRepository.SaveAsync(cancellationToken);

            var files = new List<DocumentFile>();
            foreach (var m in request.Files)
            {
                var uploadedFilePath = await localFileService.UploadAsync(m.File);
                files.Add(new DocumentFile
                {
                    Name = Path.GetFileNameWithoutExtension(uploadedFilePath),
                    DocumentId = recommendation.Id,
                    IsMain = m.IsMain,
                    Path = uploadedFilePath
                });
            }

            await documentRepository.AddFilesAsync(recommendation, files, cancellationToken);
            await documentRepository.SaveAsync(cancellationToken);

            return recommendation;
        }
    }
}
