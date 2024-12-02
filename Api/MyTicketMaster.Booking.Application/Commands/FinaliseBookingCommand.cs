using MediatR;

namespace MyTicketMaster.Booking.Application.Commands
{
    public record FinaliseBookingCommand(Guid bookingId) : IRequest;
}
