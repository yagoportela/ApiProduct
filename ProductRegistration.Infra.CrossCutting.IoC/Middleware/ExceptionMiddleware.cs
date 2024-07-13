using System.Net.Mime;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;

namespace ProductRegistration.Infra.CrossCutting.IoC.Middleware;

public static class ExceptionMiddleware
{
    public static void UseExceptionMiddleware(this IApplicationBuilder app)
    {
        app.UseExceptionHandler(handler => handler.Run(async value =>
        {
            var context = value;
            if (context != null)
            {
                var exceptions = context.Features.Get<IExceptionHandlerFeature>()?.Error;
                value.Response.ContentType = MediaTypeNames.Application.Json;
                await HandlerException.Process(context, exceptions);
            }
        }));
    }
}
