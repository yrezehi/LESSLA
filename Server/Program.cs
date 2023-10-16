using Server.Controllers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var app = builder.Build();

app.RegisterControllers();

app.Run("http://+:1111");