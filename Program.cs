using SeqNotification;
using SeqNotification.Services;

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices(services =>
    {
        services.AddHostedService<Worker>();
        services.AddSingleton<SeqClient>();
        services.AddSingleton<ReportGenerator>();
        services.AddSingleton<ExceptionDifferences>();
        services.AddSingleton<EmailSender>();
        services.AddSingleton<ActiveDirectory>();
    })
    .UseWindowsService()
    .Build();

await host.RunAsync();
