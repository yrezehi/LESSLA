using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Cache.Abstracts
{
    public interface ICache<T> where T : class
    {
        void Set(T value);
        T? Get(string key);
        void Remove(string key);
        int Increment(string key);
        bool Contains(string key);
    }
}
