using BklyOnboardingAPI.Domain.Shared.Responses;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Serilog;
using System.Collections.Generic;
using System.Net;

namespace BklyOnboardingAPI
{
    public static class ServiceExtensions
    {
        public static void ConfigureExceptionHandler(this IApplicationBuilder app)
        {
            app.UseExceptionHandler(appError =>
            {
                appError.Run(async context =>
                {
                    context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                    context.Response.ContentType = "application/json";

                    var contextFeature = context.Features.Get<IExceptionHandlerFeature>();

                    if (contextFeature != null)
                    {
                        Log.Error($"Something went wrong in {contextFeature.Error}");

                        await context.Response.WriteAsync(new ResponseDto<object>
                        {
                            Code = HttpStatusCode.BadRequest.ToString(),
                            Message = "An unexpected error occurred, please try again later.",
                            Errors = new List<string> { contextFeature.Error.Message }
                        }.ToString());
                    }
                });
            });
        }
    }
}
