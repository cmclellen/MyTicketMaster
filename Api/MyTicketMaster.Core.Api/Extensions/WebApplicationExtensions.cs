﻿using Asp.Versioning;
using Carter;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Hosting;

namespace MyTicketMaster.Core.Api.Extensions
{
    public static class WebApplicationExtensions
    {
        public static WebApplication UseSwaggerEx(this WebApplication app)
        {
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "My Ticket Master V1");
                    c.RoutePrefix = string.Empty;
                });
            }
            return app;
        }

        public static WebApplication UseAuthNZ(this WebApplication app)
        {
            //app.UseCors();
            app.UseAuthentication();
            app.UseAuthorization();
            return app;
        }

        public static WebApplication UseApiVersioningEx(this WebApplication app)
        {
            var apiVersionSet = app.NewApiVersionSet()
                .HasApiVersion(new ApiVersion(1))
                .Build();
            var apiMapGroup = app.MapGroup("api/v{version:apiVersion}")
                .WithApiVersionSet(apiVersionSet);
            apiMapGroup.RequireAuthorization();
            apiMapGroup.MapCarter();
            return app;
        }

        public static WebApplication UseGlobalExceptionHandler(this WebApplication app)
        {
            //app.UseMiddleware<GlobalExceptionHandlingMiddleware>();
            app.UseExceptionHandler();
            app.UseStatusCodePages();
            return app;
        }
    }
}
