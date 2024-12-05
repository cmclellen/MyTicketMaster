using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace MyTicketMaster.Event.Persistence
{
    public class EventDesignTimeDbContextFactory : IDesignTimeDbContextFactory<EventDbContext>
    {
        public EventDbContext CreateDbContext(string[] args)
        {
            //var connectionString = Environment.GetEnvironmentVariable("EFCORETOOLSDB");
            
            var connectionString = "Server=127.0.0.1,58267;User Id=sa;Password=fq0Dk}JQtjE5n0Q0r1dpn1;Database=MyTicketMaster;TrustServerCertificate=true";
            if (string.IsNullOrEmpty(connectionString))
                throw new InvalidOperationException("The connection string was not set " +
                "in the 'EFCORETOOLSDB' environment variable.");

            var options = new DbContextOptionsBuilder<EventDbContext>()
               .UseSqlServer(connectionString)
               .Options;
            return new EventDbContext(options);
        }
    }
}
