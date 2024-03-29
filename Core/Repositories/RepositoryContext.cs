﻿using Core.Hooks.Models;
using Core.Models;
using Core.Models.Health;
using Core.Models.Serilog;
using Microsoft.EntityFrameworkCore;

namespace Core.Repositories
{
    public class RepositoryContext : DbContext
    {
        public RepositoryContext(DbContextOptions options) : base(options) { }

        public virtual DbSet<EventLog> EventLogs { get; set; }
        public virtual DbSet<Application> Applications { get; set; }
        public virtual DbSet<HealthCheckLog> HealthCheckLogs { get; set; }
        public virtual DbSet<HealthCheckRegistry> HealthCheckRegistries { get; set; }
        public virtual DbSet<HealthCheckNotification> HealthCheckNotifications { get; set; }
        public virtual DbSet<HealthCheckApplication> HealthCheckApplications { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<User>().HasData(User.Create("admin@gmail.com").WithId(1));

            builder.Entity<Application>().HasData(Application.Create("Sample", "Just a sample website").WithId(1).WithAPIKey("SECRET"));

            builder.Entity<HealthCheckApplication>().HasData(HealthCheckApplication.Create("Google", "http://www.google.com").WithId(1));

            builder.Entity<HealthCheckApplication>().HasData(HealthCheckApplication.Create("Google", "http://www.google.com").WithId(2));

            builder.Entity<EventLog>().HasData(EventLog.Create("Error on validation", "Sample", "No valid transaction", "234234lejfw", "/getall", "weporwpeojrwpeor").WithId(1));
        }

    }
}