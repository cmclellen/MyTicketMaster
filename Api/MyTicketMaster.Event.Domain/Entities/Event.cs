using MyTicketMaster.Core.Domain.Primitives;
using MyTicketMaster.Event.Domain.DomainEvents;

namespace MyTicketMaster.Event.Domain.Entities
{
    public class Event : AggregateRoot, IAuditableEntity
    {
        private Event(Guid id) : base(id) { }

        public required string Name { get; set; }
        public required Guid VenueId { get; set; }
        public DateTime CreatedAtUtc { get; set; }
        public DateTime ModifiedAtUtc { get; set; }

        public Venue Venue { get; set; }

        public static Event Create(Guid id, string name, Guid venueId)
        {
            var ev = new Event(id) { Name = name, VenueId = venueId };
            ev.RaiseDomainEvent(new EventCreatedDomainEvent());
            return ev;
        }
    }
}
