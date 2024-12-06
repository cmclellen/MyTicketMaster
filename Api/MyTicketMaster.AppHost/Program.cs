var builder = DistributedApplication.CreateBuilder(args);

var sqlPassword = builder.AddParameter("myticketmaster-db-password", secret: true);
var sql = builder.AddSqlServer("myticketmaster-db", password: sqlPassword, port: 63814)
    .WithLifetime(ContainerLifetime.Persistent)
    .WithContainerName("myticketmaster-db")
    .WithDataVolume();

var db = sql.AddDatabase("database", "MyTicketMaster");

builder.AddProject<Projects.MyTicketMaster_Event_Api>("myticketmaster-event-api")
    .WithReference(db)
    .WaitFor(db);

builder.AddProject<Projects.MyTicketMaster_Booking_Api>("myticketmaster-booking-api")
    .WithReference(db)
    .WaitFor(db);

builder.AddProject<Projects.MyTicketMaster_Web>("myticketmaster-web");

builder.Build().Run();
