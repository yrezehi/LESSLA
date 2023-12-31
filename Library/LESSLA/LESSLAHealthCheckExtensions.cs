﻿using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Library.LESSLA
{
    public static class LESSLAHealthCheckExtensions
    {
        private static string DEFAULT_CHECK_NAME = "DEFAULT";
        private static string DEFAULT_HEALTH_CHECK_ENDPOINT = "/Health";
        private static string CONFIGURATION_ROOT = "Lessla:HealthCheck";

        private static string CONFIGURATION_APPLICATION_NAME = ":Application";
        private static string CONFIGURATION_EXTERNAL_ENDPOINTS = ":ExternalEndpoints";

        private static readonly IConfigurationSection LESSLAConfigurationSection;

        private static JsonSerializerOptions JsonSettings => new()
        {
            WriteIndented = true,
            DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase
        };

        private static HealthCheckOptions HealthSettings => new()
        {
            ResponseWriter = HealthResponse
        };

        public static void RegisterLESSLA<T>(this WebApplicationBuilder builder) where T : DbContext
        {
            if (builder.Configuration.GetSection(CONFIGURATION_ROOT).Exists())
            {
                builder.Services.AddHealthChecks()
                    .AddCheck<LESSLAHealthCheck>(DEFAULT_CHECK_NAME)
                        .AddDbContextCheck<T>();
            }
        }

        public static void RegisterLESSLAHealthCheck(this WebApplicationBuilder builder)
        {
            if (builder.Configuration.GetSection(CONFIGURATION_ROOT).Exists())
            {
                builder.Services.AddHealthChecks()
                    .AddCheck<LESSLAHealthCheck>(DEFAULT_CHECK_NAME);
            }
        }

        public static void MapLESSLAHealthCheck(this WebApplication app) =>
            app.MapHealthChecks(DEFAULT_HEALTH_CHECK_ENDPOINT, HealthSettings);

        public static Task HealthResponse(HttpContext context, HealthReport report)
        {
            context.Response.ContentType = "application/json; charset=utf-8";

            return context.Response.WriteAsJsonAsync(JsonSerializer.Serialize(new
            {
                Status = report.Status.ToString(),
                Report = report.Entries.Select(entery => new
                {
                    Status = entery.Value.Status.ToString(),
                    Exception = entery.Value.Exception?.Message ?? "No Exception Message Was Provided",
                    Duration = entery.Value.Duration.ToString(),
                    entery.Value.Description,
                    entery.Value.Data
                })
            }, JsonSettings));
        }
    }
}
