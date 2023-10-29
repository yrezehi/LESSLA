using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using System.Collections.Generic;
using System.Collections.ObjectModel;

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
            IList<string> Services = new List<string>();
            IList<string> Connections = new List<string>();

            Dictionary<string, object> result = new();

            IEnumerable<Task<(string, bool)>> concurrentResponses = Services.Select(IsURLReachable);

            var responses = await Task.WhenAll(concurrentResponses);

            responses.ToList().ForEach(response => {
                result.Add(response.Item1, response.Item2);
            });

            return new HealthCheckResult(HealthStatus.Healthy, data: result);
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
