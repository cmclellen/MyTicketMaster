using MyTicketMaster.Core.Domain.Primitives;

namespace MyTicketMaster.Booking.Domain.Entities
{
    public class Booking : AggregateRoot
    {
        public Booking(Guid id) : base(id)
        {

        }

        public Guid EventId { get; set; }
        public DateTime CreatedAtUtc {  get; set; }
        public DateTime UpdatedAtUtc { get; set; }
    }
}
