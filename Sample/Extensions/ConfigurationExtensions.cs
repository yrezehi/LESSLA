using Serilog;

namespace Sample.Extensions
{
    public static class ConfigurationExtensions
    {
        public static void RegisterLogger(this WebApplicationBuilder builder)
        {
            builder.RegisterSerilog();
            builder.InstateSerilog();
        }

        private static void RegisterSerilog(this WebApplicationBuilder builder) =>
            builder.Host.UseSerilog();

        private static void InstateSerilog(this WebApplicationBuilder builder) =>
            Log.Logger = new LoggerConfiguration()
                .ReadFrom.Configuration(
                new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                    .AddJsonFile($"apsettings.{Environment.GetEnvironmentVariable("DOTNET_ENVIRONMENT") ?? "Production"}.json", optional: true, reloadOnChange: true)
                    .AddEnvironmentVariables().Build()
                ).CreateLogger();
    }
}
