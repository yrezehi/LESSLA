using Server.Controllers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var app = builder.Build();

app.RegisterControllers();

// Configure the HTTP request pipeline.
app.UseHttpsRedirection();

app.Run();