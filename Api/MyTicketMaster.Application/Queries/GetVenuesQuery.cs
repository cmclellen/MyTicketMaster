using MediatR;
using MyTicketMaster.Common.Venues;
using MyTicketMaster.Contracts.Common;

namespace MyTicketMaster.Application.Queries
{
    public class GetVenuesQuery : IRequest<PagedResponse<VenueResponse>>
    {
    }
}
