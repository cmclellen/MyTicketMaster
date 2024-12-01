﻿using Carter;
using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using MyTicketMaster.Application.Queries;
using MyTicketMaster.Common.Events;
using MyTicketMaster.Contracts.Common;

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
        }

        /// <summary>
        /// Gets all events.
        /// </summary>
        /// <returns>A list of events</returns>
        /// <remarks>
        /// Sample request:
        ///
        ///     GET /Events
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
    }
}
