namespace Core.Models.Health.Responses
{
    public class HealthCheckResponse
    {
        public string Status { get; set; }
        public HealthCheckReportResponse Report { get; set; }
    }
}
