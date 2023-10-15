using Notification.Services.HTMLBuilder;
using SEQ;
using SEQ.Models;
using SeqNotification.Models;

namespace SeqNotification.Services
{
    public class ReportGenerator
    {
        public readonly SeqClient _seqClient;
        public readonly ExceptionDifferences _exceptionDifferences;
        public readonly EmailSender _emailSender;
        public readonly ActiveDirectory _activeDirectory;

        public ReportGenerator(SeqClient seqClient, EmailSender emailSender, ExceptionDifferences exceptionDifferences, ActiveDirectory activeDirectory)
        {
            _seqClient = seqClient;
            _exceptionDifferences = exceptionDifferences;
            _emailSender = emailSender;
            _activeDirectory = activeDirectory;
        }

        public async Task Generate()
        {
            List<ExceptionEvent> events = _seqClient.EventEntityToExceptionEventList(await _seqClient.GetLastDayLogs());

            if(events.Count > 0)
            {
                //_emailSender.SendEmails(_activeDirectory.TargetEmails("GROUPNAMEHERE"), GenerateHTMLTable(_exceptionDifferences.GetDifferences(events).ToList()));
                var x = GenerateHTMLTable(_exceptionDifferences.GetDifferences(events));
            }
        }

        public string GenerateHTMLTable(List<DifferencesEvent> events)
        {
            using (HTMLTable table = new HTMLTable())
            {

                using (HTMLRow row = table.AddRow())
                {
                    row.AddCell("System");
                    row.AddCell("Exception");
                    row.AddCell("Count");
                }

                foreach (DifferencesEvent @event in events)
                {
                    using (HTMLRow row = table.AddRow())
                    {
                        row.AddCell(@event.ApplicationName);
                        row.AddCell(@event.ExceptionEvents.FirstOrDefault().Exception + "...");
                        row.AddCell(@event.DifferencesCount.ToString());
                    }
                }

                return table.RenderTable();
            }
        }
    }
}
