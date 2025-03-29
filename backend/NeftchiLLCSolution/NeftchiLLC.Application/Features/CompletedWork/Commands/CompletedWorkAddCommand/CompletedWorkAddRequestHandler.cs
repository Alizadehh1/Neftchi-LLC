using MediatR;
using NeftchiLLC.Application.Repositories;

namespace NeftchiLLC.Application.Features.CompletedWork.Commands.CompletedWorkAddCommand
{
	class CompletedWorkAddRequestHandler(ICompletedWorkRepository completedWorkRepository) : IRequestHandler<CompletedWorkAddRequest>
	{
		public async Task Handle(CompletedWorkAddRequest request, CancellationToken cancellationToken)
		{
			var value = new Domain.Models.Entities.CompletedWork
			{
				Description = request.Description,
				Order = request.Order,
			};
			await completedWorkRepository.AddAsync(value, cancellationToken);
			await completedWorkRepository.SaveAsync(cancellationToken);
		}
	}
}
