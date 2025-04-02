using MediatR;
using NeftchiLLC.Application.Dtos;
using NeftchiLLC.Application.Repositories;

namespace NeftchiLLC.Application.Features.Certificate.Queries.CertificateGetByIdQuery
{
	class CertificateGetByIdRequestHandler(IDocumentRepository documentRepository) : IRequestHandler<CertificateGetByIdRequest, DocumentGetByIdDto>
	{
		public async Task<DocumentGetByIdDto> Handle(CertificateGetByIdRequest request, CancellationToken cancellationToken)
		{
			var certificate = await documentRepository.GetAsync(d => d.Type == Domain.Models.StableModels.DocumentType.Certification && d.DeletedAt == null && d.Id == request.Id, cancellationToken: cancellationToken);

			var files = documentRepository.GetFiles(d => d.DeletedAt == null && d.IsMain && d.DocumentId == certificate.Id);

			var result = new DocumentGetByIdDto
			{
				Id = certificate.Id,
				Name = certificate.Name,
				Files = files.Select(d => new DocumentFileGetByIdDto
				{
					Id = d.Id,
					Name = d.Name,
					Path = d.Path,
					IsMain = d.IsMain
				}).ToList()
			};

			return result;
		}
	}
}
