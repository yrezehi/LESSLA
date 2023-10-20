using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Cache.LRU
{
    public class LRUEntry<E, T> where T : class
    {
        private E Key { get; set; }
        private T Previous { get; set; }
        private T Next { get; set; }
        private T Entry { get; set; }

        private LRUEntry(E key, T entry) =>
            (Key, Entry) = (key, entry);

        public static LRUEntry<E, T> Of(E key, T entry) =>
            new LRUEntry<E, T>(key, entry);

        public LRUEntry<E, T> WithPrevious(T previous)
        {
            Previous = previous;
            return this;
        }

        public LRUEntry<E, T> WithNext(T next)
        {
            Next = next;
            return this;
        }
    }
}
