using Sample.Extensions;
using Server.Controllers;
using System.Diagnostics;

var builder = WebApplication.CreateBuilder(args);

Serilog.Debugging.SelfLog.Enable(TextWriter.Synchronized(File.CreateText("C:\\Users\\Administrator\\Documents\\Projects\\LESSLA\\logs.txt")));

builder.RegisterConfiguration();

// Add services to the container.
var app = builder.Build();

app.RegisterControllers();

app.Run("http://+:1111");