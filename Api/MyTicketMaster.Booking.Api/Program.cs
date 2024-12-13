using MyTicketMaster.Booking.Application.Queries;
using MyTicketMaster.Core.Api.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.AddServiceDefaults();

var services = builder.Services;
services
    .ConfigureJsonOptionsEx()
    .AddGlobalExceptionHandler()
    .AddMediatR(cfg => cfg.RegisterServicesFromAssemblyContaining<GetBookingsQuery>())
    .AddEndpointsApiExplorer()
    .AddSwaggerEx("Booking")
    .AddApiVersioningEx()
    .AddAuthNZ();

//builder.AddOpenTelemetry("BookingService");

var app = builder.Build();

app.UseSwaggerEx();
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app
    .MapDefaultEndpoints()
    .UseGlobalExceptionHandler()
    .UseApiVersioningEx()
    .UseAuthNZ();

app.Run();
