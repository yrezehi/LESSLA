using SeqNotification.Services;

namespace SeqNotification.Models.Extension
{
    public static class DifferencesEventExtension
    {
        public static List<DifferencesEvent> AppendExceptionEvent(this List<DifferencesEvent> events, ExceptionEvent @event)
        {
            DifferencesEvent targetEvent = events.FirstOrDefault(exception => 
                exception.ApplicationName.Equals(@event.ApplicationName)
                    &&
                exception.ExceptionEvents.Any(property => ExceptionDifferences.IsSimilar(property.Exception, @event.Exception))
            );

            if(targetEvent != null)
            {
                targetEvent.DifferencesCount++;
                targetEvent.ExceptionEvents.Add(@event);
            } else
            {
                events.Add(new DifferencesEvent
                {
                    ApplicationName = @event.ApplicationName,
                    ExceptionEvents = new List<ExceptionEvent>() { @event }
                });
            }

            return events;
        }
    }
}
