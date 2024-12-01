using Carter;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using MyTicketMaster.Application.Dtos;

namespace MyTicketMaster.Api.Endpoints
{
    public class EventEndpoints : CarterModule
    {
        public EventEndpoints() : base("/events")
        {
            
        }

        public override void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapGet("/", GetEvents)
                .WithName("Get111")
                .MapToApiVersion(1)
                //.Produces(StatusCodes.Status500InternalServerError)
                .WithTags("GetEvents");
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
        public static async Task<Results<Ok<EventDto>, InternalServerError<string>>> GetEvents()
        {
            await Task.CompletedTask;
            var ev = new EventDto("Coldplay");
            return TypedResults.Ok(ev);
        }
    }
}
