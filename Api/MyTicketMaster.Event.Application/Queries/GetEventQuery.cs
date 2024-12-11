using MediatR;
using MyTicketMaster.Event.Contracts.Events;
using MyTicketMaster.Event.Domain.Repositories;

namespace MyTicketMaster.Event.Application.Queries
{
    public record GetEventQuery(Guid eventId) : IRequest<EventResponse?>;

    public class GetEventQueryHandler(IEventRepository eventRepository) : IRequestHandler<GetEventQuery, EventResponse?>
    {
        public async Task<EventResponse?> Handle(GetEventQuery request, CancellationToken cancellationToken)
        {
            var eventItem = await eventRepository.GetByIdAsync(request.eventId, cancellationToken);
            if (eventItem != null)
            {
                return new EventResponse(eventItem.Id, eventItem.Name, eventItem.VenueId);
            }
            return null;
        }
    }
}
