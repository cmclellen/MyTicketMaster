using Carter;
using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using MyTicketMaster.Application.Queries;
using MyTicketMaster.Common.Events;
using MyTicketMaster.Contracts.Common;
using MyTicketMaster.Contracts.Events;

namespace MyTicketMaster.Api.Endpoints
{
    public class EventEndpoints(ISender sender) : CarterModule("/events")
    {
        public override void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapGet("/", GetEvents)
                .WithName(nameof(GetEvents))
                .MapToApiVersion(1)
                //.Produces(StatusCodes.Status500InternalServerError)
                .WithTags(nameof(GetEvents));
            //.WithOpenApi(op =>
            //{
            //    op.RequestBody.Required = false;
            //    return op;
            //});

            app.MapGet("/{eventId:guid}/seats", GetEventSeats)
                .WithName(nameof(GetEventSeats))
                .MapToApiVersion(1)
                .WithTags(nameof(GetEventSeats));
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
        public async Task<Results<Ok<PagedResponse<EventResponse>>, InternalServerError<string>>> GetEvents()
        {
            var response = await sender.Send(new GetEventsQuery());
            return TypedResults.Ok(response);
        }

        /// <summary>
        /// Gets all event seats.
        /// </summary>
        /// <param name="eventId">The ID of the event to retrieve seats for</param>
        /// <returns>A list of event seats</returns>
        /// <remarks>
        /// Sample request:
        ///
        ///     GET /events/{eventId}/seats
        ///
        /// </remarks>
        /// <response code="200">Returns the list of events</response>
        /// <response code="500">An unexpected error has occurred</response>
        [Produces("application/json")]
        public async Task<Results<Ok<PagedResponse<EventSeatResponse>>, InternalServerError<string>>> GetEventSeats(Guid eventId)
        {
            var response = await sender.Send(new GetEventSeatsQuery());
            return TypedResults.Ok(response);
        }
        
    }
}
