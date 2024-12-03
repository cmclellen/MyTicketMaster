namespace MyTicketMaster.Booking.Domain.Entities
{
    public class BookingSeat
    {
        public Guid SeatId { get; set; }
        public Guid EventId { get; set; }
        public Guid BookingId { get; set; }
    }
}
