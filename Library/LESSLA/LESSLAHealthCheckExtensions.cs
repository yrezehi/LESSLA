using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Library.LESSLA
{
    public static class LESSLAHealthCheckExtensions
    {
        private static string DEFAULT_HEALTH_CHECK_ENDPOINT = "/Health";
        private static string WHITELISTED_HOST = "*:9111";

        private static string CONFIGURATION_ROOT_HEALTH_CHECK_PATH = "Lessla.HealthCheck";
        private static string CONFIGURATION_ROOT_HEALTH_CHECK_CONNECTION_STRING_PATH = "Lessla.HealthCheck.ConnectionString";


        private static JsonSerializerOptions JsonSettings => new()
        {
            WriteIndented = true,
            DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase
        };

        private static HealthCheckOptions HealthSettings => new()
        {
            ResponseWriter = HealthResponse
        };

        public static void RegisterLESSLA<T>(this WebApplicationBuilder builder) where T : DbContext
        {
            if (builder.Configuration.GetSection(CONFIGURATION_ROOT_HEALTH_CHECK_PATH).Exists())
            {
                builder.Services.AddHealthChecks()
                    .AddCheck<LESSLAHealthCheck>("LESSLA")
                        .AddDbContextCheck<T>();
            }
        }

        public static void RegisterLESSLA(this WebApplicationBuilder builder)
        {
            if (builder.Configuration.GetSection(CONFIGURATION_ROOT_HEALTH_CHECK_PATH).Exists())
            {
                builder.Services.AddHealthChecks();
            }
        }

        public static void RegisterLESSLA<TDBContext>(this WebApplicationBuilder builder) where TDBContext : DbContext
        {
            if (builder.Configuration.GetSection(CONFIGURATION_ROOT_HEALTH_CHECK_PATH).Exists())
            {
                builder.Services.AddHealthChecks()
                    .AddCheck<LESSLAHealthCheck>("LESSLA");
            }
        }

        public static void MapLESSLA(this WebApplication app)
        {
            app.MapHealthChecks(DEFAULT_HEALTH_CHECK_ENDPOINT, HealthSettings)
                .RequireHost(WHITELISTED_HOST)
                    .RequireAuthorization();
        }

        public static Task HealthResponse(HttpContext context, HealthReport report)
        {
            context.Response.ContentType = "application/json; charset=utf-8";

            return context.Response.WriteAsJsonAsync(JsonSerializer.Serialize(new
            {
                Status = report.Status.ToString(),
                Report = report.Entries.Select(entery => new
                {
                    Status = entery.Value.Status.ToString(),
                    Exception = entery.Value.Exception?.Message ?? "No Exception Message Was Provided",
                    Duration = entery.Value.Duration.ToString(),
                    entery.Value.Description,
                    entery.Value.Data
                })
            }, JsonSettings));
        }

        public static void AppendconcurrentResponses()
        {

        }
    }
}
