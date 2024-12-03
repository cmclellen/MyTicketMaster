using MediatR;
using MyTicketMaster.Event.Domain.DomainEvents;

namespace MyTicketMaster.Event.Application.Events
{
    internal sealed class EventCreatedDomainEventHandler : INotificationHandler<EventCreatedDomainEvent>
    {
        public Task Handle(EventCreatedDomainEvent notification, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
