namespace Core.Models.Health.Request
{
    internal class HealthCheckRequestReport
    {
        public IReadOnlyDictionary<string, object> Data { get; set; }
        public string Status { get; set; }
        public string Exception { get; set; }
        public string Duration { get; set; }
        public string Description { get; set; }
    }
}
