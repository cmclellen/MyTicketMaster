
namespace MyTicketMaster.Event.Contracts.Types
{
    public struct EventId
    {
        public EventId(Guid value)
        {
            Value = value;
        }

        public Guid Value { get; }

        public static implicit operator EventId(Guid value)
        {
            return new EventId(value);
        }

        public static implicit operator Guid(EventId value) { return value.Value; }
    }
}
