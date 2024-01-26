using Core.Hooks.Models;
using Core.Models;
using Core.Models.Serilog;
using Microsoft.EntityFrameworkCore;

namespace Core.Repositories
{
    public class RepositoryContext : DbContext
    {
        public RepositoryContext(DbContextOptions options) : base(options) { }

        public virtual DbSet<EventLog> EventLogs { get; set; }
        public virtual DbSet<Application> Applications { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<User>().HasData(User.Create("admin@admin.com").WithId(2));

            builder.Entity<#>().HasOne("#");
            builder.Entity<#>().Navigation("#").AutoInclude();
        }

    }
}