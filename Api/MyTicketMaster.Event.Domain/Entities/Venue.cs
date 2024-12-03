using MyTicketMaster.Core.Domain.Primitives;
using MyTicketMaster.Event.Domain.DomainEvents;

namespace MyTicketMaster.Event.Domain.Entities
{
    public class Venue : AggregateRoot, IAuditableEntity
    {
        private Venue(Guid id) : base(id)
        {
        }

        public required string Name { get; set; }
        public DateTime CreatedAtUtc { get; set; }
        public DateTime ModifiedAtUtc { get; set; }

        public static Venue Create(string name)
        {
            var venue = new Venue(Guid.NewGuid()) { Name = name };
            venue.RaiseDomainEvent(new VenueCreatedDomainEvent());
            return venue;
        }
    }
}
