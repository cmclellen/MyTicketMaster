using MyTicketMaster.Core.Domain.Primitives;
using MyTicketMaster.Event.Domain.DomainEvents;

namespace MyTicketMaster.Event.Domain.Entities
{
    public class Venue : AggregateRoot //, IAuditableEntity
    {
        private Venue(Guid id) : base(id)
        {
        }

        public required string Name { get; set; }
        //public DateTime CreatedAtUtc { get; set; }
        //public DateTime ModifiedAtUtc { get; set; }

        public static Venue Create(Guid id, string name)
        {
            var venue = new Venue(id) { Name = name };
            venue.RaiseDomainEvent(new VenueCreatedDomainEvent());
            return venue;
        }
    }
}
