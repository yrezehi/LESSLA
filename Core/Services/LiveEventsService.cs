using Core.Events.SQL;
using Core.Models.Serilog;
using Core.Utils.Queue;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services
{
    public class LiveEventsService
    {
        public SQLDepedencyAdapter<EventLog> Adapter { get; set; }
        private CircularQueue<EventLog> LogQueue { get; set; }

        private const int QUEUE_LIMIT = 20;

        public LiveEventsService(SQLDepedencyAdapter<EventLog> adapter) =>
            (Adapter, LogQueue) = (adapter, new CircularQueue<EventLog>(QUEUE_LIMIT));
    }
}
