using Microsoft.Extensions.Logging;
using Polly;

namespace HealthChecker.Workers.HTTP
{
    public class PollyHTTPClient
    {
        private readonly static int DEFAULT_MAX_RETRY_ATTEMPTS = 3;
        private readonly static TimeSpan DEFAULT_WAIT_BEFORE_RETRY = TimeSpan.FromSeconds(1);

        private readonly static TimeSpan DEFAULT_TIME_OUT = TimeSpan.FromSeconds(60);

        private readonly ILogger<PollyHTTPClient> Logger;
        private readonly HttpClient HttpClient;

        public PollyHTTPClient(ILogger<PollyHTTPClient> logger) =>
            (HttpClient, Logger) = (new HttpClient(), logger);

        public IAsyncPolicy<HttpResponseMessage> RetryPolicy =>
            Policy.Handle<HttpRequestException>()
                .OrResult<HttpResponseMessage>(response => !response.IsSuccessStatusCode)
                    .WaitAndRetryAsync(DEFAULT_MAX_RETRY_ATTEMPTS, sleepProvider => DEFAULT_WAIT_BEFORE_RETRY, OnRetry);

        public IAsyncPolicy<HttpResponseMessage> TimeoutPolicy =>
            Policy.TimeoutAsync<HttpResponseMessage>(DEFAULT_TIME_OUT);

        private void OnRetry(DelegateResult<HttpResponseMessage> result, TimeSpan span, int retryCount, Context context) =>
            Logger.LogWarning($"Retrey: #{retryCount} with reason: {result.Exception.Message}");


    }
}
