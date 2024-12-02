using MediatR;
using MyTicketMaster.Event.Contracts.Common;
using MyTicketMaster.Event.Contracts.Venues;

namespace MyTicketMaster.Event.Application.Queries
{
    public class GetVenuesQuery : IRequest<PagedResponse<VenueResponse>>
    {
    }
}
