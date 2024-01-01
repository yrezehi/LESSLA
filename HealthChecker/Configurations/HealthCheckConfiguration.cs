namespace HealthCheck
{
    public static class HealthCheckConfiguration
    {
        public const int THROTTLING_INTERVAL = 10;
        public const int POLLING_INTERVAL_IN_MILLISECONDS = 10;

        public const int MAX_CONCURRENT_COUNT = 1;
        public const int WORKERS_COUNT = 10;
    }
}
