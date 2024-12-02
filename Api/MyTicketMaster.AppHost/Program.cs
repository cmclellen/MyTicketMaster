var builder = DistributedApplication.CreateBuilder(args);

builder.AddProject<Projects.MyTicketMaster_Event_Api>("myticketmaster-event-api");

builder.AddProject<Projects.MyTicketMaster_Booking_Api>("myticketmaster-booking-api");

builder.Build().Run();
