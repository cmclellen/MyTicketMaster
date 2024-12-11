using MediatR;
using MyTicketMaster.Event.Domain.Repositories;

namespace MyTicketMaster.Event.Application.Commands
{
    public record UpdateEventCommand(Guid Id, string Name, Guid VenueId) : IRequest;

    public class UpdateEventCommandHandler(IEventRepository eventRepository, IUnitOfWork unitOfWork) : IRequestHandler<UpdateEventCommand>
    {
        public async Task Handle(UpdateEventCommand request, CancellationToken cancellationToken)
        {
            var eventItem = await eventRepository.GetByIdAsync(request.Id, cancellationToken);
            if(eventItem is null)
            {
                throw new Exception("Event doesn't exist.");
            }

            eventItem.Name = request.Name;
            eventItem.VenueId = request.VenueId;
            eventRepository.Update(eventItem);
            await unitOfWork.SaveChangesAsync(cancellationToken);
        }
    }
}
