using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System.Net;
using System.Text.Json;
using ContactManagement.API.Models;
using ContactManagement.API.Exceptions;

namespace ContactManagement.API.Middleware
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionMiddleware> _logger;

        public ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred");

                await HandleExceptionAsync(context, ex);
            }
        }

        private static Task HandleExceptionAsync(HttpContext context, Exception ex)
        {
            HttpStatusCode status = HttpStatusCode.InternalServerError;
            string message = "Something went wrong";

            switch (ex)
            {
                case NotFoundException:
                    status = HttpStatusCode.NotFound;
                    message = ex.Message;
                    break;

                case ValidationException:
                    status = HttpStatusCode.BadRequest;
                    message = ex.Message;
                    break;
            }

            var response = new ErrorResponse
            {
                Message = message,
                StatusCode = (int)status,
                Timestamp = DateTime.UtcNow
            };

            var json = JsonSerializer.Serialize(response);

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)status;

            return context.Response.WriteAsync(json);
        }
    }
}