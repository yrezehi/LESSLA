using Microsoft.AspNetCore.Http;
using System.Collections.Concurrent;

namespace Core.SSE
{
    public class SSEProvider
    {
        public readonly ConcurrentBag<SSEClient> Clients;

        public SSEProvider() =>
            Clients = new ConcurrentBag<SSEClient>();

        private ParallelOptions ParallelOptions => 
            new () { MaxDegreeOfParallelism = 5 };

        public void Brodcast(string @event) =>
            Parallel.ForEach(Clients, ParallelOptions, client =>
            {
                client.Response.SendSEEEvent(@event).Wait();
            });

        public void Register(HttpContext context) =>
            Clients.Add(SSEClient.New(context.Response));
    }
}
