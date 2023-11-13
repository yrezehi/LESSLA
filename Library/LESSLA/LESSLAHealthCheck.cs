using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace Library.LESSLA
{
    public class LESSLAHealthCheck : IHealthCheck
    {
        private readonly HttpClient HttpClient;

        public LESSLAHealthCheck() =>
            HttpClient = new HttpClient();

        // sends check requests to all services registered in app settings
        public async Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context, CancellationToken cancellationToken = default)
        {
            IList<string> Services = new List<string>();
            Dictionary<string, object> result = new();
            IEnumerable<Task<(string, bool)>> concurrentResponses = Services.Select(IsURLReachable);

            var responses = await Task.WhenAll(concurrentResponses);

            responses.ToList().ForEach(response => {
                result.Add(response.Item1, response.Item2);
            });

            return new HealthCheckResult(HealthStatus.Healthy, data: result);
        }

        // checks if url is reachable via head request
        private async Task<(string, bool)> IsURLReachable(string url)
        {
            HttpResponseMessage response = await HttpClient.SendAsync(new HttpRequestMessage(HttpMethod.Head, url));

            return (url, response.IsSuccessStatusCode);
        }
    }
}
