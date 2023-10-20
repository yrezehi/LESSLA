using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Concurrent;

namespace Core.SSE
{
    public class SSEProvider
    {
        public readonly ConcurrentBag<HttpResponse> Clients;

        public SSEProvider() =>
            Clients = new ConcurrentBag<HttpResponse>();
        
        public void Brodcast(string @event)
        {
            Parallel.ForEach(Clients, ParallelOptions, client =>
            {
                client.SendSEEEvent(@event).Wait();
            });
        }

        private ParallelOptions ParallelOptions => new ParallelOptions() { MaxDegreeOfParallelism = 5 };
    }
}
