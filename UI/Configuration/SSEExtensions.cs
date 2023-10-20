using Core.SSE;

namespace UI.Configuration
{
    public static class SSEExtensions
    {
        public static void RegisterSSE(this WebApplicationBuilder builder) =>
            builder.Services.AddSingleton(typeof(SSEProvider), typeof(SSEProvider));       
    }
}
