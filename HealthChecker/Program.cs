using Core.Repositories.Abstracts.Interfaces;
using Core.Repositories.Abstracts;
using Core.Repositories;
using Core.Services.Health;
using HealthChecker.Workers;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices(services =>
    {
        services.AddDbContext<RepositoryContext>(options =>
            options.UseInMemoryDatabase("Default")
        );

        services.AddTransient<IUnitOfWork, UnitOfWork<RepositoryContext>>();
        services.AddTransient(typeof(HealthService), typeof(HealthService));

        services.AddHostedService<Worker>();
    })
    .Build();

host.Run();