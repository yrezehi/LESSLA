namespace Core.Models.Health.Request
{
    internal class HealthCheckRequestReport
    {
        public IReadOnlyDictionary<string, object>? Data { get; set; }
        public string Status { get; set; } = string.Empty;
        public string Exception { get; set; } = string.Empty;
        public string Duration { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
    }
}
