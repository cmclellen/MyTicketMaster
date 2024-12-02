namespace MyTicketMaster.Booking.Domain.Entities
{
    public class Booking
    {
        public Guid Id { get; set; }
        public Guid EventId { get; set; }
        public DateTime CreatedAtUtc {  get; set; }
        public DateTime CreatedById { get; set; }
        public DateTime UpdatedAtUtc { get; set; }
        public DateTime UpdatedById { get; set; }
    }
}
