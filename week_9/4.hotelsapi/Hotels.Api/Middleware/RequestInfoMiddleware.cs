using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace Hotels.Api.Middleware
{
    public class RequestInfoMiddleware
    {
        private readonly ILogger logger;
        private readonly RequestDelegate next;

        public RequestInfoMiddleware(RequestDelegate next, ILoggerFactory loggerFactory)
        {
            this.next = next;
            logger = loggerFactory.CreateLogger<RequestInfoMiddleware>();
        }

        public async Task Invoke(HttpContext context)
        {
            DateTime startTime = DateTime.Now;
            logger.LogInformation("Handling request: " + context.Request.Path);
            await next.Invoke(context);

            DateTime endTime = DateTime.Now;
            logger.LogInformation($"Finished handling request. It took: {endTime.Subtract(startTime).TotalMinutes} minutes");
        }
    }
}