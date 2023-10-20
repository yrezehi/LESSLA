using Microsoft.AspNetCore.Http;

namespace Core.SSE
{
    public static class SSEExtensions
    {
        public static async Task SetSSEHeaders(this HttpResponse response)
        {
            response.Headers.Add("Cache-Control", "no-cache");
            response.Headers.Add("Content-Type", "text/event-stream");
            response.Headers.Add("X-Accel-Buffering", "no");
            response.Headers.Add("Connection", "keep-alive");
            
            await response.Body.FlushAsync();
        }

        public static async Task KeepSSEAlive(this HttpResponse _, CancellationToken cancellationToken) {
            while (!cancellationToken.IsCancellationRequested)
                await Task.Delay(3000, cancellationToken);
        }

        public static async Task SendSEEEvent(this HttpResponse response, string @event)
        {
            await response.WriteAsync($"data: {@event}\r\r");
            await response.Body.FlushAsync();
        }
    }
}
