namespace MyTicketMaster.Event.Contracts.Events
{
    public record EventResponse(Guid Id, string Name, Guid VenueId, string VenueName);
}
