using Microsoft.Extensions.Options;
using Serilog;

namespace Server.Extensions
{
    public static class ConfigurationExtensions
    {
        public static void RegisterConfiguration(this WebApplicationBuilder builder)
        {
            builder.RegisterLogger();
            builder.InstateLogger();
        }

        private static void RegisterLogger(this WebApplicationBuilder builder) =>
            builder.Host.UseSerilog();

        private static void InstateLogger(this WebApplicationBuilder builder) =>
            Log.Logger = new LoggerConfiguration()
                .ReadFrom.Configuration(
                new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                    .AddJsonFile($"apsettings.{Environment.GetEnvironmentVariable("DOTNET_ENVIRONMENT") ?? "Production"}.json", optional: true, reloadOnChange: true)
                    .AddEnvironmentVariables().Build()
                ).CreateLogger();
    }
}
