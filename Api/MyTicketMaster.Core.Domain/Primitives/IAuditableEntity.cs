namespace MyTicketMaster.Core.Domain.Primitives
{
    public interface IAuditableEntity
    {
        public DateTime CreatedAtUtc { get; set; }
        public DateTime ModifiedAtUtc { get; set; }
    }
}
