namespace HealthChecker.Configurations
{
    public static class WorkerConfiguration
    {
        public const int THROTTLING_INTERVAL = 10;

        // 15 minutes in milliseconds
        public const int POLLING_INTERVAL_IN_MILLISECONDS = 60000 * 15;

        public const int MAX_CONCURRENT_COUNT = 1;
        public const int WORKERS_COUNT = 10;
    }
}
