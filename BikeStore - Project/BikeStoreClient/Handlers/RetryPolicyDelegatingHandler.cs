using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace BikeStoreClient.Handlers
{
    public class RetryPolicyDelegatingHandler : DelegatingHandler
    {
        private readonly ILogger<RetryPolicyDelegatingHandler> _logger;
        private readonly int _maximumAmountOfRetries;

        public RetryPolicyDelegatingHandler(ILogger<RetryPolicyDelegatingHandler> logger) : this(10)
        {
            _logger = logger;
        }

        public RetryPolicyDelegatingHandler(int maximumAmountOfRetries)
        {
            _maximumAmountOfRetries = maximumAmountOfRetries;
        }

        public RetryPolicyDelegatingHandler(HttpMessageHandler innerHandler,
            int maximumAmountOfRetries)
            : base(innerHandler)
        {
            _maximumAmountOfRetries = maximumAmountOfRetries;
        }

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request,
            CancellationToken cancellationToken)
        {
            HttpResponseMessage response = null;
            for (var i = 0; i < _maximumAmountOfRetries; i++)
            {
                response = await base.SendAsync(request, cancellationToken);

                if (response.IsSuccessStatusCode)
                {
                    return response;
                }

                _logger.LogInformation($"Retry {i}...");
            }

            return response;
        }
    }
}