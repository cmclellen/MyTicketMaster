using MediatR;
using MyTicketMaster.Event.Domain.Repositories;

namespace MyTicketMaster.Event.Application.Commands
{
    public record DeleteEventCommand(Guid Id) : IRequest;

    public class DeleteEventCommandHandler(IEventRepository eventRepository, IUnitOfWork unitOfWork) : IRequestHandler<DeleteEventCommand>
    {
        public async Task Handle(DeleteEventCommand request, CancellationToken cancellationToken)
        {
            await eventRepository.DeleteAsync(request.Id, cancellationToken);
            await unitOfWork.SaveChangesAsync(cancellationToken);
        }
    }
}
