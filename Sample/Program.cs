using Sample.Controllers;
using Sample.Extensions;
using Static.Exceptions;

var builder = WebApplication.CreateBuilder(args);

builder.RegisterConfiguration();

var app = builder.Build();

app.UseMiddleware<GlobalErrorHandler>();

app.RegisterControllers();

app.Run("http://+:1112");