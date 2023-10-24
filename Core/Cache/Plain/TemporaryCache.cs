using Core.Cache.Configuration;
using Microsoft.Extensions.Caching.Memory;

namespace Core.Cache.Plain
{
    public class TemporaryCache
    {
        private IMemoryCache Cache { get; set; }
        private CacheConfiguration Configuration { get; set; }

        public TemporaryCache(IMemoryCache cache) =>
            Cache = cache;

        public bool Contains(string key) =>
            Cache.TryGetValue(key, out _);

        public void Remove(string key) =>
            Cache.Remove(key);

        public void Set<T>(string key, T value) =>
            Cache.Set(key, value);

        public T? Get<T>(string key) =>
            Cache.TryGetValue(key, out T? value) ? value : default;

        public int Increment(string key)
        {
            Cache.CreateEntry(key);
            if (this.Contains(key))
            {
                int previousValue = this.Get<int>(key);
                this.Set<int>(key, previousValue + 1);
                return previousValue + 1;
            }
            return 1;
        }
    }
}
