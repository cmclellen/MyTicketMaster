using Carter;
using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using MyTicketMaster.Application.Queries;
using MyTicketMaster.Common.Venues;
using MyTicketMaster.Contracts.Common;

namespace MyTicketMaster.Api.Endpoints
{
    public class VenueEndpoints(ISender sender) : CarterModule("/venue")
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
        public async Task<Results<Ok<PagedResponse<VenueResponse>>, InternalServerError<string>>> GetVenues()
        {
            var response = await sender.Send(new GetVenuesQuery());
            return TypedResults.Ok(response);
        }
    }
}
