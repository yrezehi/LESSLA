using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Models.Serilog
{
    [Table("logs")]
    public class EventLog
    {
        public int Id { get; set; }
        public string? Message { get; set; }
        public string Level { get; set; } = "Error";
        public DateTime TimeStamp { get; set; }
        public string? Application { get; set; }
        public string? Details { get; set; }
        public string? RequestId { get; set; }
        public string? RequestPath { get; set; }
        public string? ConnectionId { get; set; }

        public EventLog() { }
    }
}
