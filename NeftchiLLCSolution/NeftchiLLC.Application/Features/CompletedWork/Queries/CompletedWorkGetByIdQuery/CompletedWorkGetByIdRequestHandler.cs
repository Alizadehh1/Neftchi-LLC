using MediatR;
using NeftchiLLC.Application.Repositories;

namespace NeftchiLLC.Application.Features.CompletedWork.Queries.CompletedWorkGetByIdQuery
{
	class CompletedWorkGetByIdRequestHandler(ICompletedWorkRepository completedWorkRepository) : IRequestHandler<CompletedWorkGetByIdRequest, CompletedWorkGetByIdDto>
	{
		public async Task<CompletedWorkGetByIdDto> Handle(CompletedWorkGetByIdRequest request, CancellationToken cancellationToken)
		{
			var value = await completedWorkRepository.GetAsync(d => d.Id == request.Id && d.DeletedAt == null, cancellationToken: cancellationToken);
			return new CompletedWorkGetByIdDto
			{
				Id = value.Id,
				Description = value.Description,
				Order = value.Order,
			};
		}
	}
}
