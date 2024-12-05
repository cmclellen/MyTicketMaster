﻿using MyTicketMaster.Core.Domain.Primitives;
using MyTicketMaster.Event.Domain.DomainEvents;

namespace MyTicketMaster.Event.Domain.Entities
{
    public class Event : AggregateRoot, IAuditableEntity
    {
        private Event(Guid id) : base(id) { }

        public required string Name { get; set; }
        public DateTime CreatedAtUtc { get; set; }
        public DateTime ModifiedAtUtc { get; set; }

        public static Event Create(string name)
        {
            var ev = new Event(Guid.NewGuid()) { Name = name };
            ev.RaiseDomainEvent(new EventCreatedDomainEvent());
            return ev;
        }
    }
}