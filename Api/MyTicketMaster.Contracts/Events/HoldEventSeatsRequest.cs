
using MyTicketMaster.Contracts.Types;

namespace MyTicketMaster.Contracts.Events
{
    public record HoldEventSeatsRequest(IList<SeatId> SeatIds);
}
