using MediatR;
using NeftchiLLC.Application.Dtos;

namespace NeftchiLLC.Application.Features.Certificate.Queries.CertificateGetAllRequest
{
	public class CertificateGetAllRequest : IRequest<IEnumerable<DocumentGetAllDto>>
	{
	}
}
