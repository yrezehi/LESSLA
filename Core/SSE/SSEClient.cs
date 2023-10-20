using Microsoft.AspNetCore.Http;
namespace Core.SSE
{
    public class SSEClient
    {
        public string Id { get; set; }
        public HttpResponse Response { get; set; }
        public DateTime JoinTime { get; set; }

        private SSEClient(HttpResponse response) =>
            (Id, Response, JoinTime) = (Guid.NewGuid().ToString(), response, DateTime.Now);

        public static SSEClient New(HttpResponse response) =>
            new SSEClient(response);
    }
}
