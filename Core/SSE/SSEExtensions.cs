using Microsoft.AspNetCore.Http;

namespace Core.SSE
{
    public static class SSEExtensions
    {
        public static async Task SetSSEHeaders(this HttpContext context)
        {
            context.Response.Headers.Add("Cache-Control", "no-cache");
            context.Response.Headers.Add("Content-Type", "text/event-stream");
            context.Response.Headers.Add("X-Accel-Buffering", "no");
            context.Response.Headers.Add("Connection", "keep-alive");
            
            await context.Response.Body.FlushAsync();
        }

        public static async Task KeepAlive(CancellationToken cancellationToken) =>
            await Task.Delay(3000, cancellationToken);
    }
}
