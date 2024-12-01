
namespace MyTicketMaster.Contracts.Common
{
    public record PagedResponse<T>(IEnumerable<T> Items);
}
