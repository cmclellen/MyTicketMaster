namespace MyTicketMaster.Event.Contracts.Events
{
    public record UpdateEventRequest(Guid Id, string Name, Guid VenueId);
}
