namespace SeqNotification.Models
{
    public class DifferencesEvent
    {
        public string ApplicationName { get; set; }
        public List<ExceptionEvent> ExceptionEvents { get; set; } = new List<ExceptionEvent>();
        public int DifferencesCount { get; set; } = 1;
    }
}
