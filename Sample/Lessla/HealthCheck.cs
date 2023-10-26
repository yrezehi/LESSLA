using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace Sample.Lessla
{
    public class HealthCheck : IHealthCheck
    {
        private readonly HttpClient HttpClient;

        public async Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context, CancellationToken cancellationToken = default)
        {
            IList<string> services = new List<string>();
            IList<string> connections = new List<string>();

            IEnumerable<Task<bool>> concurrentResponses = services.Select(IsHeadRequestReachable);

            if (await AnyUnreachableRequest(concurrentResponses))
            {
                return HealthCheckResult.Unhealthy();
            }

            IEnumerable<Task<bool>> concurrentConnections = connections.Select(IsDatabaseReachable);

            if (await AnyUnreachableDatabase(concurrentConnections))
            {
                return HealthCheckResult.Unhealthy();
            }

            return HealthCheckResult.Healthy();
        }

        private async Task<bool> AnyUnreachableDatabase(IEnumerable<Task<bool>> concurrentResponses)
        {
            var responses = await Task.WhenAll(concurrentResponses);

            return responses.ToList().Exists(response => !response);
        }

        private async Task<bool> IsDatabaseReachable(string connectionString)
        {
            return false;
        }

        private async Task<bool> AnyUnreachableRequest(IEnumerable<Task<bool>> concurrentResponses)
        {
            var responses = await Task.WhenAll(concurrentResponses);

            return responses.ToList().Exists(response => !response);
        }

        private async Task<bool> IsHeadRequestReachable(string url)
        {
            HttpResponseMessage response = await HttpClient.SendAsync(new HttpRequestMessage(HttpMethod.Head, url));

            return response.IsSuccessStatusCode;
        }
    }
}
