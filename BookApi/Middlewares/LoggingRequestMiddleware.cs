

namespace BookApi.Middlewares
{
    public class LoggingRequestMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<LoggingRequestMiddleware> _logger;
        public LoggingRequestMiddleware(RequestDelegate next, ILoggerFactory loggerFactory)
        {
            _next = next;
            _logger = loggerFactory?.CreateLogger<LoggingRequestMiddleware>() ??
                      throw new ArgumentNullException(nameof(loggerFactory));
        }
        public async Task InvokeAsync(HttpContext context)
        {

            _logger.LogInformation("Http Method " + context.Request.Method);
            _logger.LogInformation("Http Query Parameters " + context.Request.QueryString);
            _logger.LogInformation("Http Request Headers " + JoinFormattedHeaders(context.Request.Headers));
            _logger.LogInformation("Http Request Body " + await GetRequestBody(context));

            await _next(context);
        }
        private string JoinFormattedHeaders(IHeaderDictionary headers)
        {
            var formattedHeader = headers.Select(x => $"{x.Key} = {x.Value}");
            return string.Join(";", formattedHeader);
        }
        private async Task<string> GetRequestBody(HttpContext context)
        {
            context.Request.EnableBuffering();
            context.Request.Body.Seek(0, SeekOrigin.Begin);
            using var streamReader = new StreamReader(context.Request.Body, leaveOpen: true);
            var requestBody = await streamReader.ReadToEndAsync();
            context.Request.Body.Seek(0, SeekOrigin.Begin);
            return requestBody;
        }
    }

    public static class LoggingRequestMiddlewareExtension
    {
        public static IApplicationBuilder UseLoggingRequest(this IApplicationBuilder app)
        {
            return app.UseMiddleware<LoggingRequestMiddleware>();
        }
    }


}
