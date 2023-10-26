using Sample.Controllers;
using Sample.Exceptions;
using Sample.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.RegisterLogger();

var app = builder.Build();

app.UseMiddleware<GlobalErrorHandler>();

app.RegisterControllers();

app.Run("http://+:1112");