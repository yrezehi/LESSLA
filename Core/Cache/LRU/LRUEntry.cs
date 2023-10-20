using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Cache.LRU
{
    public class LRUEntry<T> where T : class
    {
        private int Key { get; set; }
        private T Previous { get; set; }
        private T Next { get; set; }
        private T Entry { get; set; }

        public LRUEntry(int key, T entry) =>
            (Key, Entry) = (key, entry);

        public static Of(int key, T entry) =>
            new LRUEntry<T>(key, entry);

        public LRUEntry<T> WithPrevious(T previous)
        {
            Previous = previous;
            return this;
        }

        public LRUEntry<T> WithNext(T next)
        {
            Next = next;
            return this;
        }
    }
}
