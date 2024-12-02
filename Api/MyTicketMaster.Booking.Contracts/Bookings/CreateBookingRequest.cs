namespace MyTicketMaster.Booking.Contracts.Bookings
{
    public record CreateBookingRequest(Guid EventId, IList<Guid> SeatIds);
}
