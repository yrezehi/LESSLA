using Core.Repositories;
using Core.Repositories.Abstracts;
using Core.Repositories.Abstracts.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace UI.Configurations
{
    public static class DatabaseExtensions
    {
        public static void RegisterDatabase(this WebApplicationBuilder builder)
        {
            builder.RegisterInMemoryContext();
            builder.RegisterUnitOfWork();
        }

        private static void RegisterContext(this WebApplicationBuilder builder) =>
            builder.Services.AddDbContext<RepositoryContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("Default"))
            );

        private static void RegisterInMemoryContext(this WebApplicationBuilder builder) =>
            builder.Services.AddDbContext<RepositoryContext>(options =>
                options.UseInMemoryDatabase("Default")
            );

        private static void RegisterUnitOfWork(this WebApplicationBuilder builder) =>
            builder.Services.AddTransient<IUnitOfWork, UnitOfWork<RepositoryContext>>();
    }
}
