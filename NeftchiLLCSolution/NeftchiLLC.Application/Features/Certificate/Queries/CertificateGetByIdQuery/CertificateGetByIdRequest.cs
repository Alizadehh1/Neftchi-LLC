using MediatR;
using NeftchiLLC.Application.Dtos;

namespace NeftchiLLC.Application.Features.Certificate.Queries.CertificateGetByIdQuery
{
	public class CertificateGetByIdRequest : IRequest<DocumentGetByIdDto>
	{
		public int Id { get; set; }
	}
}
