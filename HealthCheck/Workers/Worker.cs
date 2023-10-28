using Core.Models;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace HealthCheck.Workers
{
    public class Worker
    {
        public HttpClient HttpClient;
        public ILogger<Worker> Logger;

        public Worker(ILogger<Worker> logger) =>
            (Logger, HttpClient) = (logger, new HttpClient());

        private HttpResponseMessage SendHealthCheck(Application application)
        {
            return null;
        }
    }
}
