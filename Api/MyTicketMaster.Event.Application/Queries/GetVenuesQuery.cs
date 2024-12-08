using MediatR;
using MyTicketMaster.Core.Requests;
using MyTicketMaster.Event.Contracts.Venues;
using MyTicketMaster.Event.Domain.Repositories;

namespace MyTicketMaster.Event.Application.Queries
{
    public class GetVenuesQuery : IRequest<PagedResponse<VenueResponse>>
    {
    }

    public class GetVenuesQueryHandler(IVenueRepository eventRepository) : IRequestHandler<GetVenuesQuery, PagedResponse<VenueResponse>>
    {
        public async Task<PagedResponse<VenueResponse>> Handle(GetVenuesQuery request, CancellationToken cancellationToken)
        {
            var events = eventRepository.GetAll().OrderBy(i=>i.Name);
            var list = events.Select(e => new VenueResponse(e.Name));
            await Task.CompletedTask;
            return new PagedResponse<VenueResponse>(list);
        }
    }
}
