using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Cache.LRU
{
    public class LRUEntry<T> where T : class
    {
        public T Previous { get; set; }
        public T Next { get; set; }
        public T Entry { get; set; }

        public LRUEntry(T entry) =>
            Entry = entry;

        public static Of(T entry) =>
            new LRUEntry<T>(entry);
    }
}
