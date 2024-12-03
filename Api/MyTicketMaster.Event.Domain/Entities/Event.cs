using MyTicketMaster.Core.Domain.Primitives;
using MyTicketMaster.Event.Domain.DomainEvents;

namespace MyTicketMaster.Event.Domain.Entities
{
    public class Event : AggregateRoot
    {
        private Event(Guid id) : base(id) { }

        public static Event Create()
        {
            var ev = new Event(Guid.NewGuid());
            ev.RaiseDomainEvent(new EventCreatedDomainEvent());
            return ev;
        }
    }
}
