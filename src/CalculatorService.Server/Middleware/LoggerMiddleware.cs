using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace CalculatorService.Server.Middleware
{
    /// <summary>
    ///     Middleware handling logging every request (
    /// </summary>
    public class LoggerMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger _logger;

        public LoggerMiddleware(RequestDelegate requestDelegate, ILoggerFactory loggerFactory)
        {
            _next = requestDelegate;
            _logger = loggerFactory.CreateLogger(typeof(LoggerMiddleware));
        }

        public async Task Invoke(HttpContext context)
        {
            var stopWatch = Stopwatch.StartNew();
            var traceId = Guid.NewGuid();
            _logger.LogInformation($"[INFO] Request {traceId} started");

            await _next(context);

            var elapsed = stopWatch.Elapsed;
            var elapsedTime = string.Format("{0:00}:{1:00}:{2:00}.{3:00}", elapsed.Hours, elapsed.Minutes, elapsed.Seconds, elapsed.Milliseconds / 10);

            // TODO: Improve logging messages
            switch (context.Response.StatusCode)
            {
                case StatusCodes.Status400BadRequest:
                    _logger.LogWarning($"[WARN][400] Request {traceId} finished in {elapsedTime}: Bad request data");
                    break;
                case StatusCodes.Status500InternalServerError:
                    _logger.LogError($"[ERROR][500] Request {traceId} finished in {elapsedTime}: Internal server error");
                    break;
                default:
                    _logger.LogInformation($"[INFO] Request {traceId} finished in {elapsedTime}");
                    break;
            }
        }
    }
}
