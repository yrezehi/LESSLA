# LESSLA

<h1 align="center">
  <br>
  <img src="banner.png" width="200">
  <br>
</h1>

<h4 align="center">Lessla is a central logging system to unify logging across multiple applications with actual insightful data.</h4>

<br/>

## Deployment Checklist

- Deploy Server Instance
- Deploy UI Instance

<br/>

## Hooking up with the server

To be able to integerate with the server, install below `Nuget` packages

- `Serilog.AspNetCore`
- `Serilog.Enrichers.Environment`
- `Serilog.Exceptions`
- `Serilog.Sinks.Http`

<br/>

Setup serilog in `Program.cs`

<br/>

```csharp
builder.Host.UseSerilog();
Log.Logger = new LoggerConfiguration()
    .ReadFrom.Configuration(
    new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory())
        .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
        .AddJsonFile($"apsettings.{Environment.GetEnvironmentVariable("DOTNET_ENVIRONMENT") ?? "Production"}.json", optional: true, reloadOnChange: true)
        .AddEnvironmentVariables().Build()
    ).CreateLogger();
```

<br/>

And put below in `appsettings.json`

<br/>

```json
"Serilog": {
    "Using": [ "Serilog.Sinks.Http", "Serilog.Exceptions" ],
    "MinimumLevel": "Error",
    "WriteTo": [
      {
        "Name": "Http",
        "Args": {
          "requestUri": "http://Log-Server-URL",
          "queueLimitBytes": null
        }
      }
    ],
    "Enrich": [ "FromLogContext", "WithExceptionDetails" ],
    "Properties": {
      "Application": "YouApplicationName"
    }
  }
```

<br/>

## Deployment Requirements

- SSMS Server
- .NET 7

<br/>

## Architecture

<h1 align="center">
  <br>
  <img src="architecture.png" width="600">
  <br>
</h1>

<br/>

# Road Map

- [ ] Durable logger on client and server sides
- [ ] Notification center
- [ ] Logger insights for dashboard
- [ ] Health check center
- [ ] LLama integration

<br/>
