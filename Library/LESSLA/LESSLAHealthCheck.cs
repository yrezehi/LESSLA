using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace Library.LESSLA
{
    public class LESSLAHealthCheck : IHealthCheck
    {
        private readonly HttpClient HttpClient;

        public LESSLAHealthCheck()
        {
            HttpClient = new HttpClient();
        }

        public async Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context, CancellationToken cancellationToken = default)
        {
            IList<string> services = new List<string>();
            IList<string> connections = new List<string>();

            Dictionary<string, object> result = new();

            /*IEnumerable<Task<bool>> concurrentResponses = services.Select(IsHeadRequestReachable);

            if (await AnyUnreachableRequest(concurrentResponses))
            {
                return HealthCheckResult.Unhealthy();
            }

            IEnumerable<Task<bool>> concurrentConnections = connections.Select(IsDatabaseReachable);

            if (await AnyUnreachableDatabase(concurrentConnections))
            {
                return HealthCheckResult.Unhealthy();
            }*/

            return HealthCheckResult.Healthy();
        }

        private async Task<bool> AnyUnreachableDatabase(IEnumerable<Task<bool>> concurrentResponses)
        {
            var responses = await Task.WhenAll(concurrentResponses);

            return responses.ToList().Exists(response => !response);
        }

        private async Task<(string, bool)> IsDBReachable(string connectionString)
        {
            try
            {
                using var Connection = new SqlConnection(connectionString).OpenAsync();
                return (connectionString, true);
            }
            catch (Exception _) { return (connectionString, false); }
        }

        private async Task<(string, bool)> IsURLReachable(string url)
        {
            HttpResponseMessage response = await HttpClient.SendAsync(new HttpRequestMessage(HttpMethod.Head, url));

            return (url, response.IsSuccessStatusCode);
        }
    }
}
