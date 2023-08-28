using SeqNotification.Services;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeqNotification.Models.Extension
{
    public class ExceptionEventComparer : IEqualityComparer<ExceptionEvent>
    {
        public bool Equals(ExceptionEvent firstEvent, ExceptionEvent secondEvent)
        {
            if (object.ReferenceEquals(firstEvent, secondEvent))
                return true;

            if (firstEvent == null || secondEvent == null)
                return false;

            return ExceptionDifferences.IsSimilar(firstEvent.Exception, secondEvent.Exception)
                        && firstEvent.ApplicationName.Equals(secondEvent.ApplicationName);
        }

        public int GetHashCode([DisallowNull] ExceptionEvent @event)
        {
            if (@event == null)
                return 0;

            return @event.Exception.GetHashCode();
        }
    }
}
