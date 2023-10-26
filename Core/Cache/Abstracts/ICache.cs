namespace Core.Cache.Abstracts
{
    public interface ICache<in E, T> where T : class
    {
        void Set(E key, T value);
        T? Get(E key);
        void Remove(E key);
        bool Contains(E key);
    }
}
