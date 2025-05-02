using MediatR;
using NeftchiLLC.Application.Dtos;

namespace NeftchiLLC.Application.Features.Certificate.Commands.CertificateEditCommand
{
	public class CertificateEditRequest : IRequest<string>
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public List<DocumentFileEditDto> Files { get; set; }
	}
}
