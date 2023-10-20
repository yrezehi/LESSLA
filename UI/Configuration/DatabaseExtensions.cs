using Core.Cache.LRU;
using Core.Cache.Providers;
using Core.Repositories;
using Core.Repositories.Abstracts;
using Core.Repositories.Abstracts.Interfaces;
using Core.SSE;
using Microsoft.EntityFrameworkCore;

namespace UI.Configuration
{
    public static class DatabaseExtensions
    {
        public static void RegisterDatabase(this WebApplicationBuilder builder)
        {
            builder.RegisterContext();
            builder.RegisterUnitOfWork();
        }

        private static void RegisterContext(this WebApplicationBuilder builder) =>
            builder.Services.AddDbContext<RepositoryContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("ConnectionString"))
            );

        private static void RegisterUnitOfWork(this WebApplicationBuilder builder) =>
            builder.Services.AddTransient<IUnitOfWork, UnitOfWork<RepositoryContext>>();
    }
}
