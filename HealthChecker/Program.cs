using Core.Repositories.Abstracts.Interfaces;
using Core.Repositories.Abstracts;
using Core.Repositories;
using Core.Services.Health;
using HealthChecker.Workers;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Serilog;

IHost host = Host.CreateDefaultBuilder(args)
    .UseSerilog((hostContext, services, configuration) =>
        configuration.ReadFrom.Configuration(
                new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                    .AddJsonFile($"apsettings.{Environment.GetEnvironmentVariable("DOTNET_ENVIRONMENT") ?? "Production"}.json", optional: true, reloadOnChange: true)
                    .AddEnvironmentVariables().Build()
                )
    ).ConfigureServices(services =>
    {
        services.AddDbContext< RepositoryContext>(options =>
            options.UseInMemoryDatabase("Default")
        );

        using (var scope = services.BuildServiceProvider().CreateScope())
        using (var context = scope.ServiceProvider.GetService<RepositoryContext>())
            context!.Database.EnsureCreated();

        services.AddTransient<IUnitOfWork, UnitOfWork<RepositoryContext>>();

        services.AddTransient(typeof(HealthLogService), typeof(HealthLogService));
        services.AddTransient(typeof(HealthService), typeof(HealthService));

        services.AddHostedService<Worker>();
    })
    .Build();

host.Run();