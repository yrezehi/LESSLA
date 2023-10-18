using Microsoft.Extensions.Configuration;
using Server.Controllers;
using Server.Extensions;
using System.Diagnostics;

var builder = WebApplication.CreateBuilder(args);

Serilog.Debugging.SelfLog.Enable(TextWriter.Synchronized(File.CreateText(builder.Configuration.GetValue<string>("SelfLog")!)));

builder.RegisterConfiguration();

// Add services to the container.
var app = builder.Build();

app.RegisterControllers();

app.Run("http://+:1111");