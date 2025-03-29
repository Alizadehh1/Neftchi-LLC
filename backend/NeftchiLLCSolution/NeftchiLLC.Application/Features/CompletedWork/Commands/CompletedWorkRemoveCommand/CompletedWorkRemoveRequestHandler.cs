using MediatR;
using NeftchiLLC.Application.Repositories;

namespace NeftchiLLC.Application.Features.CompletedWork.Commands.CompletedWorkRemoveCommand
{
	class CompletedWorkRemoveRequestHandler(ICompletedWorkRepository completedWorkRepository) : IRequestHandler<CompletedWorkRemoveRequest>
	{
		public async Task Handle(CompletedWorkRemoveRequest request, CancellationToken cancellationToken)
		{
			var value = await completedWorkRepository.GetAsync(d => d.Id == request.Id && d.DeletedAt == null, cancellationToken: cancellationToken);
			completedWorkRepository.Remove(value);
			await completedWorkRepository.SaveAsync(cancellationToken);
		}
	}
}
