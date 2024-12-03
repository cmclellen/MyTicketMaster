namespace MyTicketMaster.Core.Domain.Primitives
{
    public abstract class AggregateRoot : Entity
    {
        private readonly List<IDomainEvent> _domainEvent = new();

        protected AggregateRoot(Guid id) : base(id)
        {
            
        }

        protected void RaiseDomainEvent(IDomainEvent domainEvent) 
        {
            _domainEvent.Add(domainEvent);
        }
    }
}
