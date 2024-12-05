using Microsoft.EntityFrameworkCore;
using MyTicketMaster.Core.Api.Extensions;
using MyTicketMaster.Event.Application.Queries;
using MyTicketMaster.Event.Persistence;
using System.Configuration;

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
//.AddDbContext<EventDbContext>(options =>
//        options.UseSqlServer(builder.Configuration.GetConnectionString("database")));

builder.AddSqlServerDbContext<EventDbContext>(connectionName: "database");

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
