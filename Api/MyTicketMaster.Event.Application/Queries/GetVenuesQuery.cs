using MediatR;
using MyTicketMaster.Core.Requests;
using MyTicketMaster.Event.Contracts.Venues;

namespace MyTicketMaster.Event.Application.Queries
{
    public class GetVenuesQuery : IRequest<PagedResponse<VenueResponse>>
    {
    }
}
