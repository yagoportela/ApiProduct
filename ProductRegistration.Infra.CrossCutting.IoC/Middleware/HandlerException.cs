using System.Net;
using System.Text.Json;
using Microsoft.AspNetCore.Http;

namespace ProductRegistration.Infra.CrossCutting.IoC.Middleware;
public static class HandlerException
{
    public static async Task Process(HttpContext context, Exception? exception)
    {
        switch (exception)
        {
            case ArgumentException ae:
                var problemArgumentException = new HttpValidationProblemDetails
                {
                    Title = HttpStatusCode.BadRequest.ToString(),
                    Detail = exception.Message,
                    Status = (int)HttpStatusCode.BadRequest
                };
                context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                await context.Response.WriteAsync(JsonSerializer.Serialize(problemArgumentException));
                break;
            default:
                var problemException = new HttpValidationProblemDetails
                {
                    Title = HttpStatusCode.BadRequest.ToString(),
                    Detail = exception?.Message,
                };
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                await context.Response.WriteAsync(JsonSerializer.Serialize(problemException));
                break;

        }
    }
}