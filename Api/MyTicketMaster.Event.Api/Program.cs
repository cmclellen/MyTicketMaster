using MediatR;
using Microsoft.EntityFrameworkCore;
using MyTicketMaster.Core.Api.Extensions;
using MyTicketMaster.Event.Application.Queries;
using MyTicketMaster.Event.Domain.Repositories;
using MyTicketMaster.Event.Persistence;
using MyTicketMaster.Event.Persistence.Repositories;
using Scrutor;

var builder = WebApplication.CreateBuilder(args);

builder.AddServiceDefaults();

var services = builder.Services;
services
    .ConfigureJsonOptionsEx()
    .AddGlobalExceptionHandler()
    .AddMediatR(cfg => cfg.RegisterServicesFromAssembly(MyTicketMaster.Event.Application.AssemblyReference.Assembly))
    .AddEndpointsApiExplorer()
    .AddSwaggerEx("Event")
    .AddApiVersioningEx()
    .AddDbContext<EventDbContext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("database")));

services.Scan(scan => scan
    .FromAssemblies(MyTicketMaster.Event.Domain.AssemblyReference.Assembly, MyTicketMaster.Event.Persistence.AssemblyReference.Assembly)
    .AddClasses(false)
    .UsingRegistrationStrategy(RegistrationStrategy.Skip)
    .AsMatchingInterface()
    .WithTransientLifetime());

//builder.AddOpenTelemetry("EventService");

var app = builder.Build();

app.UseSwaggerEx();
if (app.Environment.IsDevelopment())
{   
    app.UseDeveloperExceptionPage();
}

app.MapDefaultEndpoints();

app.UseGlobalExceptionHandler();

app.UseApiVersioningEx();

using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<EventDbContext>();
    var db = dbContext.Database;
    db.Migrate();
}

app.Run();
