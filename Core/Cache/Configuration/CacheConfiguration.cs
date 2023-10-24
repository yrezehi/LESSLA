using Microsoft.Extensions.Caching.Memory;

namespace Core.Cache.Configuration
{
    public class CacheConfiguration
    {
        public MemoryCacheOptions Configuration { get; set; }

        public CacheConfiguration() =>
            Configuration = new MemoryCacheOptions();

        public MemoryCacheOptions Default => new()
        {
            SizeLimit = -1,
            TrackLinkedCacheEntries = false,
            TrackStatistics = false,
        };

    }
}
