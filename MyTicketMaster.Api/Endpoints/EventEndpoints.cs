using Carter;

namespace MyTicketMaster.Api.Endpoints
{
    public class EventEndpoints : CarterModule
    {
        public override void AddRoutes(IEndpointRouteBuilder app)
        {
            var eventsMapGroup = app.MapGroup("/events");
            
            eventsMapGroup.MapGet("/", () => "Hello World!")
                .WithName("GetEvents")
                .MapToApiVersion(1)
                .Produces(StatusCodes.Status500InternalServerError)
                .WithTags("Get123")
                .WithOpenApi(op =>
                {
                    op.Summary = "Get all events";

                    return op;
                }); ;
        }
    }
}
