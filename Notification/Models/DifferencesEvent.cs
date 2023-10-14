using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeqNotification.Models
{
    public class DifferencesEvent
    {
        public string ApplicationName { get; set; }
        public List<ExceptionEvent> ExceptionEvents { get; set; } = new List<ExceptionEvent>();
        public int DifferencesCount { get; set; } = 1;
    }
}
