using Core.Cache.LRU;
using Core.Cache.Providers;
using Core.SSE;
using Microsoft.EntityFrameworkCore;

namespace UI.Configuration
{
    public static class DatabaseExtensions
    {
        public static void RegisterDatabase(this WebApplicationBuilder builder)
        {
            builder.Services.AddDbContext<DbContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("ConnectionString"))
            );
        }
    }
}
