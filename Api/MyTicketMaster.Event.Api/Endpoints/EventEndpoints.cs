using Carter;
using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using MyTicketMaster.Core.Requests;
using MyTicketMaster.Event.Application.Commands;
using MyTicketMaster.Event.Application.Queries;
using MyTicketMaster.Event.Contracts.Events;

namespace MyTicketMaster.Event.Api.Endpoints
{
    public class EventEndpoints() : CarterModule("/events")
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

            app.MapPost("/", CreateEvent)
                .WithName(nameof(CreateEvent))
                .MapToApiVersion(1)
                .WithTags(nameof(CreateEvent));

            app.MapGet("/{eventId:guid}/seats", GetEventSeats)
                .WithName(nameof(GetEventSeats))
                .MapToApiVersion(1)
                .WithTags(nameof(GetEventSeats));

            app.MapDelete("/{id:guid}", DeleteEvent)
                .WithName(nameof(DeleteEvent))
                .MapToApiVersion(1)
                //.Produces(StatusCodes.Status500InternalServerError)
                .WithTags(nameof(DeleteEvent));
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
        public async Task<Results<Ok<PagedResponse<EventResponse>>, InternalServerError<string>>> GetEvents(ISender sender)
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
        public async Task<Results<Ok<PagedResponse<EventSeatResponse>>, InternalServerError<string>>> GetEventSeats(Guid eventId, ISender sender)
        {
            var response = await sender.Send(new GetEventSeatsQuery());
            return TypedResults.Ok(response);
        }

        /// <summary>
        /// Deletes an event.
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     DELETE /event/{id:guid}
        ///
        /// </remarks>
        /// <response code="204"></response>
        /// <response code="500">An unexpected error has occurred</response>
        public async Task<Results<NoContent, InternalServerError<string>>> DeleteEvent(Guid id, ISender sender)
        {
            await sender.Send(new DeleteEventCommand(id));
            return TypedResults.NoContent();
        }

        /// <summary>
        /// Creates an event.
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST /event
        ///
        /// </remarks>
        /// <response code="201"></response>
        /// <response code="500">An unexpected error has occurred</response>
        public async Task<Results<Ok, InternalServerError<string>>> CreateEvent(CreateEventRequest request, ISender sender)
        {
            await sender.Send(new CreateEventCommand(request.Name));
            return TypedResults.Ok();
        }
    }
}
