using Library.LESSLA;
using Sample.Controllers;
using Sample.Exceptions;
using Sample.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.RegisterLogger();
builder.RegisterLESSLAHealthCheck();

var app = builder.Build();

app.UseMiddleware<GlobalErrorHandler>();

app.MapLESSLAHealthCheck();

app.RegisterControllers();

app.Run();