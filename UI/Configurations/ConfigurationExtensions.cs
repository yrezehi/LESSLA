using Core.Configurations;

namespace UI.Configurations
{
    public static class ConfigurationExtensions
    {
        public static void RegisterConfiguration(this WebApplicationBuilder builder) =>
            Configuration.Register(builder.Configuration);
    }
}
