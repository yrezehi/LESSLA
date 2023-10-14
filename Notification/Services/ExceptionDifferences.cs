using F23.StringSimilarity;
using Notification.Extension;
using SEQ.Models;
using SeqNotification.Models;

namespace SeqNotification.Services
{
    public class ExceptionDifferences
    {
        public static readonly JaroWinkler DifferanceCalculator = new JaroWinkler();

        public static readonly double SIMILARITY_THRESHOLD = 0.80;

        public static bool IsSimilar(string firstException, string secondException) =>
            DifferanceCalculator.Similarity(firstException, secondException) > SIMILARITY_THRESHOLD;

        public List<DifferencesEvent> GetDifferences(List<ExceptionEvent> events)
        {
            List<ExceptionEvent> distinctEvents = events.Distinct(new ExceptionEventComparer()).ToList();
            List<DifferencesEvent> exceptions = new List<DifferencesEvent>();

            foreach (ExceptionEvent @event in distinctEvents)
            {
                foreach (ExceptionEvent targetEvent in events.ExceptThis(@event).WithSameApplicationName(@event))
                {
                    if(IsSimilar(targetEvent.Exception, @event.Exception))
                    {
                        exceptions.AppendExceptionEvent(targetEvent);
                        //exceptionOccurrences[@event.Exception] = exceptionOccurrences.ContainsKey(@event.Exception) ? exceptionOccurrences[@event.Exception] + 1 : 1;
                        //IncreamentAndAddEvent();
                    }
                }
            }
             
            return exceptions;
        }

    }
}
