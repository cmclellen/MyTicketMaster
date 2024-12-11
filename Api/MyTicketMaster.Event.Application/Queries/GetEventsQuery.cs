using MediatR;
using MyTicketMaster.Core.Requests;
using MyTicketMaster.Event.Contracts.Events;
using MyTicketMaster.Event.Domain.Repositories;

namespace MyTicketMaster.Event.Application.Queries
{
    public class GetEventsQuery : IRequest<PagedResponse<EventResponse>>
    {
    }

    public class GetEventsQueryHandler(IEventRepository eventRepository) : IRequestHandler<GetEventsQuery, PagedResponse<EventResponse>>
    {
        public async Task<PagedResponse<EventResponse>> Handle(GetEventsQuery request, CancellationToken cancellationToken)
        {
            var events = await eventRepository.GetAllAsync(cancellationToken);
            var list = events.Select(e=> new EventResponse(e.Id, e.Name, e.VenueId, e.Venue.Name));
            return new PagedResponse<EventResponse>(list);
        }
    }
}
