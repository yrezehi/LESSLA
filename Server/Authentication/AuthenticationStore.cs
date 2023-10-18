using Microsoft.Extensions.Caching.Memory;

namespace Server.Authentication
{
    public class AuthenticationStore
    {
        private readonly IMemoryCache Cache;

        public AuthenticationStore(IMemoryCache cache) =>        
            Cache = cache;
        
        public void SetValue<T>(string key, T value, int ExpirationInSeconds) =>
            Cache.Set(key, value, TimeSpan.FromSeconds(ExpirationInSeconds));
        public bool ContainsKey(string key) =>
            Cache.TryGetValue(key, out var value);
        public T? GetValue<T>(string key) =>
            Cache.TryGetValue(key, out T value) ? value : default;
        public void RemoveValue(string key) => 
            Cache.Remove(key);
    }
}
