var builder = DistributedApplication.CreateBuilder(args);

var sql = builder.AddSqlServer("myticketmaster-db", port: 58267)
    .WithLifetime(ContainerLifetime.Persistent)
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
