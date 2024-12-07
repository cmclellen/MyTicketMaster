using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using OpenTelemetry.Resources;
using OpenTelemetry.Trace;

namespace MyTicketMaster.Core.Api.Extensions
{
    public static class WebApplicationBuilderExtensions
    {
        //public static WebApplicationBuilder AddOpenTelemetry(this WebApplicationBuilder builder, string serviceName) {
        //    builder.Logging.AddOpenTelemetry(logging => 
        //    {
        //        logging.IncludeFormattedMessage = true;
        //        logging.IncludeScopes = true;
        //    });
        //    builder.Services.AddOpenTelemetry()
        //        .ConfigureResource(resource => resource.AddService(serviceName))
        //        .WithTracing(builder => builder
        //            .AddHttpClientInstrumentation()
        //            .AddAspNetCoreInstrumentation());
        //        //.UseOtlpExporter();
        //    return builder;
        //}
    }
}
