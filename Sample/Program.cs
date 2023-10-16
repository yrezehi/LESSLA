using Serilog;

var builder = WebApplication.CreateBuilder(args);

builder.RegisterConfiguration();

var app = builder.Build();

app.Run();