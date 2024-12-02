namespace MyTicketMaster.Event.Contracts.Types
{
    public struct SeatId
    {
        public SeatId(int value)
        {
            Value = value;
        }

        public int Value { get; }

        public static implicit operator int(SeatId seatId)
        {
            return seatId.Value;
        }

        public static implicit operator SeatId(int val)
        {
            return new SeatId(val);
        }
    }
}
