using Core.Models.Health.Responses;
using Microsoft.Extensions.Logging;

namespace HealthCheck.Workers
{
    public class Worker
    {
        public HttpClient HttpClient;
        public ILogger<Worker> Logger;

        public Worker(ILogger<Worker> logger) =>
            (Logger, HttpClient) = (logger, new HttpClient());

        private async Task<HealthCheckResponse> SendHealthCheck(string endpoint)
        {
            return null;
        }


    }
}
