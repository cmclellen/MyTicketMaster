using Carter;
using Microsoft.AspNetCore.Http.HttpResults;
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
                .WithName("GetEvents")
                .MapToApiVersion(1)
                //.Produces(StatusCodes.Status500InternalServerError)
                .WithTags("Get123")
                .WithOpenApi(op =>
                {
                    op.Summary = "Get all events";

                    return op;
                }); ;
        }

        public static async Task<Results<Ok<EventDto>, InternalServerError<string>>> GetEvents()
        {
            await Task.CompletedTask;
            var ev = new EventDto("Coldplay");
            return TypedResults.Ok(ev);
        }
    }
}
