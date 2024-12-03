using MyTicketMaster.Core.Api.Extensions;
using MyTicketMaster.Event.Application.Queries;

var builder = WebApplication.CreateBuilder(args);

builder.AddServiceDefaults();

var services = builder.Services;
services
    .ConfigureJsonOptionsEx()
    .AddGlobalExceptionHandler()
    .AddMediatR(cfg => cfg.RegisterServicesFromAssemblyContaining<GetEventsQuery>())
    .AddEndpointsApiExplorer()
    .AddSwaggerEx("Event")
    .AddApiVersioningEx();

builder.AddOpenTelemetry("EventService");

var app = builder.Build();

app.UseSwaggerEx();
if (app.Environment.IsDevelopment())
{   
    app.UseDeveloperExceptionPage();
}

app.MapDefaultEndpoints();

app.UseGlobalExceptionHandler();

app.UseApiVersioningEx();

app.Run();
