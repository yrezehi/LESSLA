namespace Core.Models
{
    public class Event
    {
        public DateTime Timestamp { get; set; }
        public string Level { get; set; }
        public string RenderedMessage { get; set; }
        public IDictionary<string, object> Properties { get; set; }
    }
}