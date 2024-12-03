using MediatR;
using MyTicketMaster.Booking.Contracts.Bookings;
using MyTicketMaster.Core.Requests;
using System.Diagnostics;

namespace MyTicketMaster.Booking.Application.Queries
{
    public record GetBookingsQuery : IRequest<PagedResponse<BookingResponse>>;

    public class GetBookingsQueryHandler : IRequestHandler<GetBookingsQuery, PagedResponse<BookingResponse>>
    {
        ActivitySource source = new("MyApp.Source");

        public async Task<PagedResponse<BookingResponse>> Handle(GetBookingsQuery request, CancellationToken cancellationToken)
        {
            var min = -20;
            var max = 55;

            using var activity = source.StartActivity("Calculating weather with temperature between {Min} and {Max}");

            activity?.SetTag("Min", min);
            activity?.SetTag("Max", max);

            await Task.CompletedTask;

            return new PagedResponse<BookingResponse>([
                new BookingResponse()
            ]);

        }
    }
}
