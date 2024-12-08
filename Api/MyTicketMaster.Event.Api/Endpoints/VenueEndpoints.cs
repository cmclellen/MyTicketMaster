using Carter;
using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using MyTicketMaster.Core.Requests;
using MyTicketMaster.Event.Application.Commands;
using MyTicketMaster.Event.Application.Queries;
using MyTicketMaster.Event.Contracts.Venues;

namespace MyTicketMaster.Event.Api.Endpoints
{
    public class VenueEndpoints() : CarterModule("/venues")
    {
        public override void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapGet("/", GetVenues)
                .WithName(nameof(GetVenues))
                .MapToApiVersion(1)
                //.Produces(StatusCodes.Status500InternalServerError)
                .WithTags(nameof(GetVenues));
            //.WithOpenApi(op =>
            //{
            //    op.RequestBody.Required = false;
            //    return op;
            //});

            app.MapPost("/", CreateVenue)
                .WithName(nameof(CreateVenue))
                .MapToApiVersion(1)
                //.Produces(StatusCodes.Status500InternalServerError)
                .WithTags(nameof(CreateVenue));
        }

        /// <summary>
        /// Gets all venues.
        /// </summary>
        /// <returns>A list of venues</returns>
        /// <remarks>
        /// Sample request:
        ///
        ///     GET /venues
        ///
        /// </remarks>
        /// <response code="200">Returns the list of venues</response>
        /// <response code="500">An unexpected error has occurred</response>
        [Produces("application/json")]
        public async Task<Results<Ok<PagedResponse<VenueResponse>>, InternalServerError<string>>> GetVenues(ISender sender)
        {
            var response = await sender.Send(new GetVenuesQuery());
            return TypedResults.Ok(response);
        }

        /// <summary>
        /// Creates a venue.
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST /venue
        ///
        /// </remarks>
        /// <response code="201"></response>
        /// <response code="500">An unexpected error has occurred</response>
        public async Task<Results<Ok, InternalServerError<string>>> CreateVenue(CreateVenueRequest request, ISender sender)
        {
            await sender.Send(new CreateVenueCommand(request.Name));
            return TypedResults.Ok();
        }
    }
}
