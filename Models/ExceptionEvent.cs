using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeqNotification.Models
{
    public class ExceptionEvent
    {
        public string Id { get; set; }
        public string Exception { get; set; }
        public string ApplicationName { get; set; }
    }
}
