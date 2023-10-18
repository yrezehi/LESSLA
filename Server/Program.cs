using Sample.Extensions;
using Server.Controllers;

var builder = WebApplication.CreateBuilder(args);

builder.RegisterConfiguration();

// Add services to the container.
var app = builder.Build();

app.RegisterControllers();

app.Run("http://+:1111");