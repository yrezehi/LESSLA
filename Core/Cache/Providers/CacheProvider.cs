using Microsoft.Extensions.Caching.Memory;
using System.Collections.Concurrent;

namespace Core.Cache.Providers
{
    public class CacheProvider
    {
        private readonly ConcurrentDictionary<string, MemoryCache> Caches;

        public CacheProvider() =>
            Caches = new();

        private MemoryCache CreateMemeoryCacheInstance() =>
            new MemoryCache(new MemoryCacheOptions());

        public IMemoryCache GetCache(string name)
        {
            if (Caches.ContainsKey(name))
                return Caches[name];

            throw new ArgumentException($"{name} is not initialized.");
        }

        public void CreateCache(string name)
        {
            if (!Caches.TryAdd(name, CreateMemeoryCacheInstance()))
                throw new ArgumentException($"Was not able to create a cache instance for {name}");
        }
    }
}
