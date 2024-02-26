using Core.Models.Health;
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

        public EventLog(string message, string application, string details, string requestId, string requestPath, string connectionId) {
            Message = message;
            Application = application;
            Details = details;
            RequestId = requestId;
            RequestPath = requestPath;
            ConnectionId = connectionId;
        }

        public static EventLog Create(string message, string application, string details, string requestId, string requestPath, string connectionId) =>
            new EventLog(message, application, details, requestId, requestPath, connectionId);

        public EventLog WithId(int id)
        {
            Id = id;
            return this;
        }
    }
}
