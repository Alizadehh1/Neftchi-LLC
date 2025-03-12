using MediatR;
using NeftchiLLC.Application.Dtos;

namespace NeftchiLLC.Application.Features.License.Queries.LicensesGetAllRequest
{
	public class LicenseGetAllRequest : IRequest<IEnumerable<DocumentGetAllDto>>
	{
	}
}
