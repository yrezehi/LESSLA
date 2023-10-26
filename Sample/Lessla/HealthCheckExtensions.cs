﻿namespace Sample.Lessla
{
    public static class HealthCheckExtensions
    {
        private static string CONFIGURATION_ROOT_HEALTH_CHECK_PATH = "Lessla.HealthCheck";

        private static string CONFIGURATION_HEALTH_CHECK_CONNECTION_STRINGS_KEY = "ConnectionStrings";
        private static string CONFIGURATION_HEALTH_CHECK_EXTERNAL_ENDPOINTS_KEY = "ExternalEndpoints";

        public static void RegisterDependencies(this WebApplicationBuilder builder)
        {
            if (builder.Configuration.GetSection(CONFIGURATION_ROOT_HEALTH_CHECK_PATH).Exists())
            {

            }
        }
    }
}