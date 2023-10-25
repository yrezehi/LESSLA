using Core.Services;
using Core.SSE;

namespace UI.Configuration
{
    public static class ServicesExtensions
    {
        public static void RegisterServices(this WebApplicationBuilder builder)
        {
            builder.Services.AddTransient(typeof(ApplicationsService), typeof(ApplicationsService));
            builder.Services.AddTransient(typeof(EventLogsService), typeof(EventLogsService));
            builder.Services.AddTransient(typeof(HealthService), typeof(HealthService));
        }
    }
}
