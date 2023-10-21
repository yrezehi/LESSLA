namespace Core.Models.Serilog
{
    public class LogEventRequest
    {
        public DateTime Timestamp { get; set; }
        public string Level { get; set; }
        public string RenderedMessage { get; set; }
        public IDictionary<string, object> Properties { get; set; }
        public string? Logger { get; set; }
        public string? Exception { get; set; }
        public string? SourceContext { get; set; }
    }
}