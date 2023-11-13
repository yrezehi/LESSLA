using Library.LESSLA;
using Sample.Controllers;
using Sample.Exceptions;
using Sample.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.RegisterLogger();
builder.RegisterLESSLA();

var app = builder.Build();

app.UseMiddleware<GlobalErrorHandler>();

app.MapLESSLA();

app.RegisterControllers();

app.Run("http://+:1112");