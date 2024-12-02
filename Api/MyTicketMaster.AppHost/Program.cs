var builder = DistributedApplication.CreateBuilder(args);

builder.AddProject<Projects.MyTicketMaster_Event_Api>("myticketmaster-api");

builder.Build().Run();
