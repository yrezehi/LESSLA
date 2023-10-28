namespace Library.Request
{
    internal class HealthCheckRequest
    {
        public string Status { get; set; }
        public HealthCheckRequestReport Report { get; set; }
    }
}
