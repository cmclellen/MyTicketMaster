using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Net;

namespace MyTicketMaster.Core.Api.Exceptions
{
    internal sealed class GlobalExceptionHandler(IProblemDetailsService problemDetailsService) : IExceptionHandler
    {
        public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
        {
            httpContext.Response.StatusCode = exception switch
            {
                ApplicationException => (int)HttpStatusCode.BadRequest,
                _ => (int)HttpStatusCode.InternalServerError
            };

            Activity? activity = httpContext.Features.Get<IHttpActivityFeature>()?.Activity;

            return await problemDetailsService.TryWriteAsync(
                new ProblemDetailsContext { 
                    HttpContext = httpContext,
                    Exception = exception,
                    ProblemDetails = new ProblemDetails
                    {
                        Type = exception.GetType().Name,
                        Title = "An error occured",
                        Detail = exception.Message,
                        Instance = $"{httpContext.Request.Method} {httpContext.Request.Path}",
                        Extensions = new Dictionary<string, object?>
                        {
                            { "requestId", httpContext.TraceIdentifier },
                            { "traceId", activity?.Id }
                        }
                    }
                });

            //await httpContext.Response.WriteAsJsonAsync(
            //    new ProblemDetails { 
            //        Type = exception.GetType().Name,
            //        Title = "An error occured",
            //        Detail = exception.Message,
            //    }, cancellationToken);

            //return true;
        }
    }
}
