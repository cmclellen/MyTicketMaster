using Carter;

namespace MyTicketMaster.Api.Endpoints
{
    public class EventEndpoints : CarterModule
    {
        public override void AddRoutes(IEndpointRouteBuilder app)
        {
            var eventsMapGroup = app.MapGroup("/events");
            
            eventsMapGroup.MapPost("/", () => "Hello World!").MapToApiVersion(1);
        }
    }
}
