using Sample.Controllers;
using Sample.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.RegisterConfiguration();

var app = builder.Build();

app.RegisterControllers();

app.Run("http://+:1112");