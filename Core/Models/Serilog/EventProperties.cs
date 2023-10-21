using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models.Serilog
{
    public class EventProperties
    {
        public KeyValuePair<string, string> RequestId { get; set; }
        public KeyValuePair<string, string> RequestPath { get; set; }
        public KeyValuePair<string, string> ConnectionId { get; set; }
        public KeyValuePair<string, string> ExceptionDetail { get; set; }
        public KeyValuePair<string, string> Application { get; set; }
    }
}
