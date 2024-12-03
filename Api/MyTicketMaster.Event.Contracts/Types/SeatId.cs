namespace MyTicketMaster.Event.Contracts.Types
{
    public struct SeatId
    {
        public SeatId(Guid value)
        {
            Value = value;
        }

        public Guid Value { get; }

        public static implicit operator Guid(SeatId seatId)
        {
            return seatId.Value;
        }

        public static implicit operator SeatId(Guid val)
        {
            return new SeatId(val);
        }
    }
}
