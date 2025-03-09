using MediatR;

namespace NeftchiLLC.Application.Features.License.Queries.LicensesGetAllRequest
{
	public class LicensesGetAllRequest : IRequest<IEnumerable<LicensesGetAllDto>>
	{
	}
}
