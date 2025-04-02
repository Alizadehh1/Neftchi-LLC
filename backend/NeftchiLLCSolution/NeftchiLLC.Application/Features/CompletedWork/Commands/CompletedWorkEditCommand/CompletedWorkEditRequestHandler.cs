using MediatR;
using NeftchiLLC.Application.Repositories;

namespace NeftchiLLC.Application.Features.CompletedWork.Commands.CompletedWorkEditCommand
{
	public class CompletedWorkEditRequestHandler(ICompletedWorkRepository completedWorkRepository) : IRequestHandler<CompletedWorkEditRequest>
	{
		public async Task Handle(CompletedWorkEditRequest request, CancellationToken cancellationToken)
		{
			var value = await completedWorkRepository.GetAsync(d => d.Id == request.Id && d.DeletedAt == null, cancellationToken: cancellationToken);
			value.Description = request.Description;
			value.Order = request.Order;
			await completedWorkRepository.SaveAsync(cancellationToken);
		}
	}
}
