namespace Core.Models.Health
{
    public class HealthCheckRegistry
    {
        public string ApplicationName { get; set; }
        public int MinutesInterval { get; set; } = 60;
        public string URL { get; set; }
    }
}
