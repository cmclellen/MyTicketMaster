using MediatR;
using MyTicketMaster.Event.Domain.Repositories;

namespace MyTicketMaster.Event.Application.Commands
{
    public record CreateEventCommand(string Name, Guid VenueId) : IRequest;

    public class CreateEventCommandHandler(IEventRepository eventRepository, IUnitOfWork unitOfWork) : IRequestHandler<CreateEventCommand>
    {
        public async Task Handle(CreateEventCommand request, CancellationToken cancellationToken)
        {
            var venue = Domain.Entities.Event.Create(Guid.NewGuid(), request.Name, request.VenueId);
            eventRepository.Create(venue);
            await unitOfWork.SaveChangesAsync(cancellationToken);
        }
    }
}
