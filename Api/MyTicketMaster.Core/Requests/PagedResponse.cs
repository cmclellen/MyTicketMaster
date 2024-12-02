namespace MyTicketMaster.Core.Requests
{
    public record PagedResponse<T>(IEnumerable<T> Items);
}
