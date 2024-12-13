using Asp.Versioning;
using Carter;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using MyTicketMaster.Core.Api.Exceptions;
using System.Diagnostics;
using System.Reflection;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace MyTicketMaster.Core.Api.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddSwaggerEx(this IServiceCollection services, string apiName)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1",
                    new OpenApiInfo
                    {
                        Title = apiName,
                        Version = "v1",
                        Description = "My ticket master API",
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

                var xmlFilename = $"{Assembly.GetEntryAssembly()!.GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFilename);
                c.IncludeXmlComments(xmlPath);

                var authServerUrl = "http://localhost:8080/";
                var realm = "MyTicketMaster";
                var openIdConnectUrl = $"{authServerUrl}realms/{realm}/.well-known/openid-configuration";
                var securityScheme = new OpenApiSecurityScheme
                {
                    Name = "Auth",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.OpenIdConnect,
                    OpenIdConnectUrl = new Uri(openIdConnectUrl),
                    Scheme = "bearer",
                    BearerFormat = "JWT",
                    Reference = new OpenApiReference
                    {
                        Id = "Bearer",
                        Type = ReferenceType.SecurityScheme
                    }
                };
                c.AddSecurityDefinition(securityScheme.Reference.Id, securityScheme);
                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                    {
                        {securityScheme, Array.Empty<string>()}
                    });
            });
            return services;
        }

        public static IServiceCollection AddAuthNZ(this IServiceCollection services)
        {
            services
                .AddAuthorization()
                .AddAuthentication()
                .AddKeycloakJwtBearer("keycloak", realm: "MyTicketMaster", options =>
                {
                    options.RequireHttpsMetadata = false;
                    options.Audience = "account";
                });
            return services;
        }

        public static IServiceCollection AddApiVersioningEx(this IServiceCollection services)
        {
            services
                .AddCarter()
                .AddApiVersioning(options => {
                     options.DefaultApiVersion = new ApiVersion(1);
                     options.ApiVersionReader = new UrlSegmentApiVersionReader();
                 })
                .AddApiExplorer(options => {
                     options.GroupNameFormat = "'v'V";
                     options.SubstituteApiVersionInUrl = true;
                 });
            return services;
        }

        public static IServiceCollection ConfigureJsonOptionsEx(this IServiceCollection services)
        {
            services.ConfigureHttpJsonOptions(options =>
            {
                options.SerializerOptions.Converters.Add(new JsonStringEnumConverter());
                options.SerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
            });
            return services;
        }

        public static IServiceCollection AddGlobalExceptionHandler(this IServiceCollection services)
        {
            //services.AddTransient<GlobalExceptionHandlingMiddleware>();
            services.AddProblemDetails(o => {
                o.CustomizeProblemDetails = context =>
                {
                    var httpContext = context.HttpContext;
                    Activity? activity = httpContext.Features.Get<IHttpActivityFeature>()?.Activity;
                    context.ProblemDetails.Instance = $"{httpContext.Request.Method} {httpContext.Request.Path}";
                    context.ProblemDetails.Extensions.Add("requestId", httpContext.TraceIdentifier);
                    //context.ProblemDetails.Extensions.Add("traceId", activity?.Id);
                };
            });
            services.AddExceptionHandler<GlobalExceptionHandler>();
            return services;
        }
    }
}
