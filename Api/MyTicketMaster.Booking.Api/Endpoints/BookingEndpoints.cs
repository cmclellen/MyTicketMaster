using Carter;
using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
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
                //.Produces(StatusCodes.Status500InternalServerError)
                .WithTags(nameof(GetBookings));
        }

        /// <summary>
        /// Gets all events.
        /// </summary>
        /// <returns>A list of events</returns>
        /// <remarks>
        /// Sample request:
        ///
        ///     GET /events
        ///
        /// </remarks>
        /// <response code="200">Returns the list of events</response>
        /// <response code="500">An unexpected error has occurred</response>
        /// [ApiConventionMethod(typeof(DefaultApiConventions))]
        [Produces("application/json")]
        public async Task<Results<Ok<PagedResponse<BookingResponse>>, InternalServerError<string>>> GetBookings()
        {
            var response = await sender.Send(new GetBookingsQuery());
            return TypedResults.Ok(response);
        }
    }
}
