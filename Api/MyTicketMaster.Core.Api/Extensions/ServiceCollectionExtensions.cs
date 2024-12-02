using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using System.Reflection;
using Asp.Versioning;
using Carter;
using System.Text.Json.Serialization;
using System.Text.Json;
using MyTicketMaster.Core.Api.Middlewares;

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
            services.AddTransient<GlobalExceptionHandlingMiddleware>();
            return services;
        }
    }
}
