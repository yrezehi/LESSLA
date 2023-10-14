using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeqNotification.Models.Extension
{
    public static class ExceptionEventExtension
    {
        public static List<ExceptionEvent> ExceptThis(this List<ExceptionEvent> events, ExceptionEvent @event)
        {
            return events.Where(property => !property.Id.Equals(@event.Id)).ToList();
        }

        public static List<ExceptionEvent> WithSameApplicationName(this List<ExceptionEvent> events, ExceptionEvent @event)
        {
            return events.Where(property => property.ApplicationName.Equals(@event.ApplicationName)).ToList();
        }
    }
}
