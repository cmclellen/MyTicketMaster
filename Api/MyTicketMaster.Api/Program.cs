using Asp.Versioning;
using Carter;
using Microsoft.OpenApi.Models;
using MyTicketMaster.Api.Middlewares;
using MyTicketMaster.Application.Queries;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

builder.AddServiceDefaults();

var services = builder.Services;
services
    .AddTransient<GlobalExceptionHandlingMiddleware>()
    .AddMediatR(cfg => cfg.RegisterServicesFromAssemblyContaining<GetEventsQuery>())
    .AddCarter()
    .AddEndpointsApiExplorer()
    .AddSwaggerGen(c =>
    {
        c.SwaggerDoc("v1", 
            new Microsoft.OpenApi.Models.OpenApiInfo { 
                Title = "My Ticket Master API", 
                Version = "v1",
                Description = "A ticket master type API",
                TermsOfService = new Uri("https://example.com/terms"),
                Contact = new OpenApiContact
                {
                    Name = "Ticketing",
                    Email = "contact@example.com",
                    Url = new Uri("https://example.com"),
                },
                License = new OpenApiLicense
                {
                    Name = "My ticket master LICX",
                    Url = new Uri("https://example.com/license")
                }
            });

        var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
        var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFilename);
        c.IncludeXmlComments(xmlPath);
    })
    .AddApiVersioning(options => {
        options.DefaultApiVersion = new ApiVersion(1);
        options.ApiVersionReader = new UrlSegmentApiVersionReader();
    }).AddApiExplorer(options => {
        options.GroupNameFormat = "'v'V";
        options.SubstituteApiVersionInUrl = true;
    });

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "My Ticket Master V1");
        c.RoutePrefix = string.Empty;
    });
    app.UseDeveloperExceptionPage();
}

app.MapDefaultEndpoints();

app.UseMiddleware<GlobalExceptionHandlingMiddleware>();

var apiVersionSet = app.NewApiVersionSet()
    .HasApiVersion(new ApiVersion(1))
    .Build();
var apiMapGroup = app.MapGroup("api/v{version:apiVersion}")
    .WithApiVersionSet(apiVersionSet);

apiMapGroup.MapCarter();

app.Run();
