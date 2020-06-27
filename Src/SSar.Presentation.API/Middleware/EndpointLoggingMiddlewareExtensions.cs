using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Logging;

namespace SSar.Presentation.API.Middleware
{
    public static class EndpointLoggingMiddlewareExtensions
    {
        public static IApplicationBuilder UseEndpointLogging(this IApplicationBuilder builder, LogLevel logLevel = LogLevel.Trace)
        {
            return builder.UseMiddleware<EndpointLoggingMiddleware>(logLevel);
        }
    }
}
