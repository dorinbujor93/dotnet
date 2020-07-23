using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace BikeStoreClient.Handlers
{
    public class LoggingDelegatingHandler : DelegatingHandler
    {
        private readonly ILogger<LoggingDelegatingHandler> _logger;

        public LoggingDelegatingHandler(ILogger<LoggingDelegatingHandler> logger)
        {
            _logger = logger;
        }

        protected override async Task<HttpResponseMessage> SendAsync(
            HttpRequestMessage request,
            CancellationToken cancellationToken)
        {
            _logger.LogInformation($"Request: {request}");

            try
            {
                var response = await base.SendAsync(request, cancellationToken);
                _logger.LogInformation($"Response: {response}");
                return response;
            }
            catch (Exception ex)
            {
                _logger.LogInformation($"Failed to get response: {ex}");
                throw;
            }
        }
    }
}