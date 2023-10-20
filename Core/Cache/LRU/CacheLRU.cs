using Core.Cache.Abstracts;
using Microsoft.Extensions.Caching.Memory;

namespace Core.Cache.LRU
{
    public class CacheLRU<E, T> : ICache<E, T> where T : class
    {
        private readonly IMemoryCache CacheInstance;

        private int Length { get; set; }

        public LRUEntry<E, T> Head;
        public LRUEntry<E, T> Tail;

        private readonly static int LRU_CAPACITY = 50;

        public CacheLRU(IMemoryCache cache) =>
            CacheInstance = cache;

        public void Set(E key, T value)
        {
            LRUEntry<E, T> entry = LRUEntry<E, T>.Of(key, value);

            if (Length < LRU_CAPACITY)
            {
                Length++;
            }
            else
            {
                this.Remove(Tail.Key);

                if (Tail.Previous == null)
                {
                    Head = Tail.Next;
                }
                else
                {
                    Tail.Previous.SetNext(Tail.Next);
                }

                if (Tail.Next == null)
                {
                    if (Tail.Previous != null)
                    {
                        Tail = Tail.Previous;
                    }
                } else
                {
                    if (Tail.Previous != null)
                    {
                        Tail.Next.SetPrevious(Tail.Previous);
                    }
                }
            }

            SetAsHead(ref entry);
            CacheInstance.Set(key!, value);
        }

        private void SetAsHead(ref LRUEntry<E, T> entry)
        {
            if(Head == null)
            {
                Head = entry;
                Tail = entry;
            } else
            {
                Head.SetPrevious(entry);
                entry.SetNext(Head);
                Head = entry;
            }
        }

        public bool Contains(E key) =>
            CacheInstance.TryGetValue(key!, out var value);

        public T? Get(E key) =>
            CacheInstance.TryGetValue(key!, out T? value) ? value : default;

        public void Remove(E key) =>
            CacheInstance.Remove(key!);
    }
}
