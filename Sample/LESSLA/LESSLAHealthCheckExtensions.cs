using System.Text.Json;
using System.Text.Json.Serialization;

namespace Sample.Lessla
{
    public static class LESSLAHealthCheckExtensions
    {
        private static string DEFAULT_HEALTH_CHECK_ENDPOINT = "/Health";
        private static string CONFIGURATION_ROOT_HEALTH_CHECK_PATH = "Lessla.HealthCheck";

        private static JsonSerializerOptions JsonSettings => new()
        {
            WriteIndented = true,
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            DefaultIgnoreCondition = JsonIgnoreCondition.Never
        };

        public static void RegisterLESSLA(this WebApplicationBuilder builder)
        {
            if (builder.Configuration.GetSection(CONFIGURATION_ROOT_HEALTH_CHECK_PATH).Exists())
            {
                builder.Services.AddHealthChecks().AddCheck<LESSLAHealthCheck>("LESSLA");
            }
        }

        public static void MapLESSLA(this WebApplication app)
        {
            app.MapHealthChecks(DEFAULT_HEALTH_CHECK_ENDPOINT);
        }

        public static Task HealthResponse(this HttpContext httpContext)
        {
            return httpContext.Response.WriteAsJsonAsync(JsonSerializer.Serialize(new {
                
            }, JsonSettings));
        }
    }
}
