using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Core.Cache.Providers
{
    public class CacheProvider
    {
        private readonly ConcurrentDictionary<string, MemoryCache> Caches;

        public CacheProvider() =>
            Caches = new();

        private IMemoryCache CreateMemeoryCacheInstance() =>
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
