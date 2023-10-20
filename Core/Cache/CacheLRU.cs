using Core.Cache.Abstracts;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Cache
{
    public class CacheLRU<T> : ICache<T> where T : class
    {
        private readonly IMemoryCache CacheInstance;

        public CacheLRU(IMemoryCache cache) =>
            CacheInstance = cache;

        public void Set(string key, T value) =>
            CacheInstance.Set(key, value);

        public bool Contains(string key)
        {
            if (CacheInstance.TryGetValue(key, out var value))
                return true;
            return false;
        }

        public T? Get(string key)
        {
            if (CacheInstance.TryGetValue(key, out T? value))
                return value;

            return default;
        }

        public void Remove(string key)
        {
            CacheInstance.Remove(key);
        }
    }
}
