using System.Diagnostics.CodeAnalysis;

namespace SeqNotification.Models.Extension
{
    public class ExceptionEventApplicationNameComparer : IEqualityComparer<ExceptionEvent>
    {
        public bool Equals(ExceptionEvent firstEvent, ExceptionEvent secondEvent)
        {
            if (object.ReferenceEquals(firstEvent, secondEvent))
                return true;

            if (firstEvent == null || secondEvent == null)
                return false;

            return firstEvent.ApplicationName.Equals(secondEvent.ApplicationName);
        }

        public int GetHashCode([DisallowNull] ExceptionEvent @event)
        {
            if (@event == null)
                return 0;

            return @event.ApplicationName.GetHashCode();
        }
    }
}
