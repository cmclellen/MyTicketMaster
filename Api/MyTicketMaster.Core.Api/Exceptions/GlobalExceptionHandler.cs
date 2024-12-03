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

            return await problemDetailsService.TryWriteAsync(
                new ProblemDetailsContext { 
                    HttpContext = httpContext,
                    Exception = exception,
                    ProblemDetails = new ProblemDetails
                    {
                        Type = exception.GetType().Name,
                        Title = "An error occured",
                        Detail = exception.Message,
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
