namespace MyTicketMaster.Contracts.Types
{
    public class SeatId
    {
        private readonly int _value;

        public SeatId(int value)
        {
            _value = value;
        }

        public static implicit operator int(SeatId seatId)
        {
            return seatId._value;
        }

        public static implicit operator SeatId(int val)
        {
            return new SeatId(val);
        }
    }
}
