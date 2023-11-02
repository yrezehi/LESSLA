namespace Core.Models.Health.Responses
{
    public class HealthCheckReportResponse
    {
        public IReadOnlyDictionary<string, object>? Data { get; set; }
        public string Status { get; set; } = string.Empty;
        public string Exception { get; set; } = string.Empty;
        public string Duration { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
    }
}
