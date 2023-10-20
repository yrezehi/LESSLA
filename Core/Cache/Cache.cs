using Core.Cache.Abstracts;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Cache
{
    public class Cache<T> : ICache<T> where T : class
    {
        private IMemoryCache Cache;

        public void Cache(IMemoryCache cache) =>
            Cache = cache;

        public void Set(string key, T value) =>
            Cache.Set(key, value);

        public int Increment(string key)
        {
            if (ContainsKey(key))
            {
                int previousValue = GetValue<int>(key);
                this.Set<int>(key, previousValue + 1);
                return previousValue + 1;
            }

            return 1;
        }

        public bool ContainsKey(string key)
        {
            if (Cache.TryGetValue(key, out var value))
                return true;
            return false;
        }

        public T? Get(string key)
        {
            if (Cache.TryGetValue(key, out T? value))
                return value;

            return default;
        }

        public void Remove(string key)
        {
            Cache.Remove(key);
        }
    }
}
