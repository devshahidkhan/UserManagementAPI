using Microsoft.AspNetCore.Mvc;
using System.Net;
using static System.Net.Mime.MediaTypeNames;

namespace UserManagementWebAPI.Middlewares
{
    public class GlobalExceptionHandlingMiddleware(RequestDelegate next)
    {
        private readonly RequestDelegate _next = next;
        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        private async Task HandleExceptionAsync(HttpContext context, Exception ex)
        {
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

            ProblemDetails problemDetails = new()
            {
                Status = (int)HttpStatusCode.InternalServerError,
                // A brief, human-readable title for the error.
                Title = "Internal Server Error",
                // A detailed description of the error to help the client understand the issue.
                Detail = "An internal server error has occurred. Please try again later.",
                // A URI that provides further details about the error type (e.g., HTTP status code).
                Type = "https://httpstatuses.com/500",
                // The URI of the request path that caused the error, helping with debugging.
                Instance = context.Request.Path,
            };

            await context.Response.WriteAsJsonAsync(problemDetails);
        }
    }
}
