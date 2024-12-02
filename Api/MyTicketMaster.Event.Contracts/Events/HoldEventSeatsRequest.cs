using MyTicketMaster.Event.Contracts.Types;

namespace MyTicketMaster.Event.Contracts.Events
{
    public record HoldEventSeatsRequest(EventId eventId, IList<SeatId> SeatIds);
}
