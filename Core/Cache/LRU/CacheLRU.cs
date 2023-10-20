using Core.Cache.Abstracts;
using Microsoft.Extensions.Caching.Memory;

namespace Core.Cache.LRU
{
    public class CacheLRU<E, T> : ICache<E, T> where T : class
    {
        private readonly IMemoryCache CacheInstance;

        private int Length { get; set; }

        public T Head;
        public T Tail;

        private readonly static int LRU_CAPACITY = 25;

        public CacheLRU(IMemoryCache cache) =>
            CacheInstance = cache;

        public void Set(E key, T value)
        {
            if(Length < LRU_CAPACITY)
            {
                LRUEntry<E, T> entry = LRUEntry<E, T>.Of(key, value);
            }
          
            CacheInstance.Set(key!, value);
        }

        public bool Contains(E key) =>
            CacheInstance.TryGetValue(key!, out var value);

        public T? Get(E key) =>
            CacheInstance.TryGetValue(key!, out T? value) ? value : default;

        public void Remove(E key) =>
            CacheInstance.Remove(key!);
    }
}
