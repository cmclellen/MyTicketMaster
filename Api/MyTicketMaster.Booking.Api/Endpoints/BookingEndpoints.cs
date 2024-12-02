using Carter;
using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using MyTicketMaster.Booking.Application.Commands;
using MyTicketMaster.Booking.Application.Queries;
using MyTicketMaster.Booking.Contracts.Bookings;
using MyTicketMaster.Core.Requests;

namespace MyTicketMaster.Booking.Api.Endpoints
{
    public class BookingEndpoints(ISender sender) : CarterModule("/bookings")
    {
        public override void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapGet("/", GetBookings)
                .WithName(nameof(GetBookings))
                .MapToApiVersion(1)
                .WithTags(nameof(GetBookings));

            app.MapPost("/", CreateBooking)
                .WithName(nameof(CreateBooking))
                .WithTags(nameof(CreateBooking));

            app.MapPut("/finalise", FinaliseBooking)
                .WithName(nameof(FinaliseBooking))
                .WithTags(nameof(FinaliseBooking));
        }

        /// <summary>
        /// Gets all bookings.
        /// </summary>
        /// <returns>A list of bookings</returns>
        /// <remarks>
        /// Sample request:
        ///
        ///     GET /bookings
        ///
        /// </remarks>
        /// <response code="200">Returns the list of bookings</response>
        /// <response code="500">An unexpected error has occurred</response>
        [Produces("application/json")]
        public async Task<Results<Ok<PagedResponse<BookingResponse>>, InternalServerError<string>>> GetBookings()
        {
            var response = await sender.Send(new GetBookingsQuery());
            return TypedResults.Ok(response);
        }

        /// <summary>
        /// Creates a booking.
        /// </summary>
        /// <param name="request">The booking request</param>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST /bookings
        ///
        /// </remarks>
        /// <response code="204"></response>
        /// <response code="500">An unexpected error has occurred</response>
        [Produces("application/json")]
        public async Task<Results<NoContent, InternalServerError<string>>> CreateBooking(CreateBookingRequest request)
        {
            await sender.Send(new CreateBookingCommand());
            return TypedResults.NoContent();
        }

        /// <summary>
        /// Creates a booking.
        /// </summary>
        /// <param name="request">The finalise booking request</param>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST /bookings
        ///
        /// </remarks>
        /// <response code="204"></response>
        /// <response code="500">An unexpected error has occurred</response>
        [Produces("application/json")]
        public async Task<Results<NoContent, InternalServerError<string>>> FinaliseBooking(FinaliseBookingRequest request)
        {
            await sender.Send(new FinaliseBookingCommand());
            return TypedResults.NoContent();
        }
    }
}
