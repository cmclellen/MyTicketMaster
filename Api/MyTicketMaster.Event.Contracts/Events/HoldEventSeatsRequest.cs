using MyTicketMaster.Event.Contracts.Types;

namespace MyTicketMaster.Event.Contracts.Events
{
    public record HoldEventSeatsRequest(IList<SeatId> SeatIds);
}
