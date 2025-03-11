using MediatR;
using NeftchiLLC.Application.Dtos;
using NeftchiLLC.Application.Repositories;

namespace NeftchiLLC.Application.Features.License.Queries.LicenseGetByIdQuery
{
	class CertificateGetByIdRequestHandler(IDocumentRepository documentRepository) : IRequestHandler<CertificateGetByIdRequest, DocumentGetByIdDto>
	{
		public async Task<DocumentGetByIdDto> Handle(CertificateGetByIdRequest request, CancellationToken cancellationToken)
		{
			var license = await documentRepository.GetAsync(d => d.Type == Domain.Models.StableModels.DocumentType.License && d.DeletedAt == null && d.Id == request.Id, cancellationToken: cancellationToken);

			var files = documentRepository.GetFiles(d => d.DeletedAt == null && d.IsMain && d.DocumentId == license.Id);

			var result = new DocumentGetByIdDto
			{
				Id = license.Id,
				Name = license.Name,
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
