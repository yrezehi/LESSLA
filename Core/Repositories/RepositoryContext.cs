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
    }
}