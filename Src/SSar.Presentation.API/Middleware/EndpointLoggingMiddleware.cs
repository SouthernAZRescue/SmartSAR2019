using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Logging;

namespace SSar.Presentation.API.Middleware
{
    public class EndpointLoggingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<EndpointLoggingMiddleware> _logger;
        private readonly LogLevel _logLevel;

        public EndpointLoggingMiddleware(RequestDelegate next, ILogger<EndpointLoggingMiddleware> logger, LogLevel logLevel = LogLevel.Trace)
        {
            _next = next;
            _logger = logger;
            _logLevel = logLevel;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var endpoint = context.GetEndpoint();
            if (endpoint is null)
            {
                _logger.Log(_logLevel, $"Endpoint: <null>");
                await _next(context);
            }

            _logger.Log(_logLevel, $"Endpoint: {endpoint?.DisplayName ?? "Null DisplayName"}");

            if (endpoint is RouteEndpoint routeEndpoint)
            {

                _logger.Log(_logLevel, "Endpoint has route pattern: " +
                                       routeEndpoint.RoutePattern.RawText);
            }

            foreach (var metadata in endpoint.Metadata)
            {
                _logger.Log(_logLevel, $"Endpoint has metadata: {metadata}");
            }

            await _next(context);
        }
    }
}
