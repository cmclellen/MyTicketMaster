namespace MyTicketMaster.Event.Contracts.Events
{
    public record EventSeatResponse(Guid SeatId, SeatAvailabilityStatusType SeatAvailabilityStatus);
}
