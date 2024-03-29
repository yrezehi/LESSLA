﻿using Core.Models.Abstracts.Interfaces;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Models.Health
{
    [Table("health_application")]
    public class HealthCheckApplication : IEntity
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }
        [Column("application_name")]
        public string ApplicationName { get; set; }
        [Column("minutes_interval")]
        public int MinutesInterval { get; set; } = 60;
        [Column("url")]
        public string URL { get; set; }
        [Column("enabled")]
        public bool Enabled { get; set; } = false;

        public HealthCheckApplication() { }

        public HealthCheckApplication(string applicationName, string url) =>
            (ApplicationName, URL) = (applicationName, url);

        public static HealthCheckApplication Create(string applicationName, string url) =>
            new HealthCheckApplication(applicationName, url);

        public HealthCheckApplication WithId(int id)
        {
            Id = id;
            return this;
        }
    }
}
