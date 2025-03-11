using MediatR;
using NeftchiLLC.Application.Dtos;

namespace NeftchiLLC.Application.Features.License.Queries.LicenseGetByIdQuery
{
	public class CertificateGetByIdRequest : IRequest<DocumentGetByIdDto>
	{
		public int Id { get; set; }
	}
}
