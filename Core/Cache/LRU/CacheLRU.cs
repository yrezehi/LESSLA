using Core.Cache.Abstracts;
using Microsoft.Extensions.Caching.Memory;

namespace Core.Cache.LRU
{
    public class CacheLRU<T> : ICache<T> where T : class
    {
        private readonly IMemoryCache CacheInstance;

        public CacheLRU(IMemoryCache cache) =>
            CacheInstance = cache;

        public void Set(string key, T value) =>
            CacheInstance.Set(key, value);

        public bool Contains(string key) =>
            CacheInstance.TryGetValue(key, out var value);

        public T? Get(string key) =>
            CacheInstance.TryGetValue(key, out T? value) ? value : default;

        public void Remove(string key) =>
            CacheInstance.Remove(key);
    }
}
