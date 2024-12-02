namespace MyTicketMaster.Event.Contracts.Common
{
    public record PagedResponse<T>(IEnumerable<T> Items);
}
