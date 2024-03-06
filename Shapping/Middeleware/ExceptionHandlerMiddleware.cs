using Microsoft.AspNetCore.Http;
using System.Net;
using System.Net.Http;
using System.Text.Json;

namespace Shapping.Middeleware
{
    public class ExceptionHandlerMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionHandlerMiddleware(RequestDelegate next)
        {

            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (ExceptionLogic ex)
            {
                context.Response.ContentType = "application/json";
                context.Response.StatusCode = (int)HttpStatusCode.BadRequest;

                var ee = JsonSerializer.Serialize(new { Message = ex.Message });

                await context.Response.WriteAsync(ee);

            }
            catch (Exception ex)
            {

                // _logger.LogError(ex, "An exception occurred: {Message}", ex.Message);

                await HandleExceptionAsync(context, ex);
            }
        }

        private static async Task HandleExceptionAsync(HttpContext httpContext, Exception exception)
        {
            httpContext.Response.ContentType = "application/json";

            httpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

            var response = new
            {
                Message = exception.Message.ToString(),
            };

            await httpContext.Response.WriteAsync(JsonSerializer.Serialize(response));
        }
    }
}
    public class ExceptionLogic : Exception
    {
        public string Message { get; set; }

        public ExceptionLogic(string message)
        {
            Message = message;
        }
    }

