using Application.Models;

namespace BookApi.Middlewares
{
    public class GlobalHandlerMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<GlobalHandlerMiddleware> _logger;
        public GlobalHandlerMiddleware(RequestDelegate next, ILogger<GlobalHandlerMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                await HandleExceptionAsync(httpContext, ex);
            }
        }

        private async Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            Response<EmptyValue> internalResponse = FailureResponses.InternalError("Internal Server Error.");
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)internalResponse.StatusCode;
            await context.Response.WriteAsync(internalResponse.ToString());
        }
    }

    public static class GlobalHandlerMiddlewareExtension
    {
        public static IApplicationBuilder UseGlobalHandler(this IApplicationBuilder app)
        {
            return app.UseMiddleware<GlobalHandlerMiddleware>();
        }
    }
}
