﻿using Core.Cache.LRU;
using Core.Cache.Providers;
using Core.SSE;

namespace UI.Configuration
{
    public static class CacheExtensions
    {
        public static void RegisterCache(this WebApplicationBuilder builder)
        {
            builder.Services.AddSingleton(typeof(CacheProvider), typeof(CacheProvider));
            builder.Services.AddSingleton(typeof(CacheLRU<,>), typeof(CacheLRU<,>));
        }
    }
}
