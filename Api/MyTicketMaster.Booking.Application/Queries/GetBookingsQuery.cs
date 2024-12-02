using MediatR;
using MyTicketMaster.Booking.Contracts.Bookings;
using MyTicketMaster.Core.Requests;

namespace MyTicketMaster.Booking.Application.Queries
{
    public record GetBookingsQuery : IRequest<PagedResponse<BookingResponse>>;
}
