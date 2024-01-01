using Core.Models.Serilog;
using Microsoft.AspNetCore.Mvc;
using Serilog;

namespace Server.Controllers
{
    public static class ControllerRegistry
    {
        public static void RegisterControllers(this WebApplication application)
        {
            application.Index();
            application.RegisterHealthCheckApplication();
        }

        private static void Index(this WebApplication application) =>
            application.MapPost("/", ([FromBody] LogEventRequest[] events) =>
            {
                Parallel.ForEach(events, @event =>
                {
                    var instanceLogContext = Log.ForContext("Server", "ip");

                    if (@event.Properties.TryGetValue("Application", out var application))
                    {
                        instanceLogContext = instanceLogContext.ForContext("Application", application);
                    }

                    if (@event.Properties.TryGetValue("RequestId", out var requestId))
                    {
                        instanceLogContext = instanceLogContext.ForContext("RequestId", requestId);
                    }

                    if (@event.Properties.TryGetValue("RequestPath", out var requestPath))
                    {
                        instanceLogContext = instanceLogContext.ForContext("RequestPath", requestPath);
                    }

                    if (@event.Properties.TryGetValue("ConnectionId", out var connectionId))
                    {
                        instanceLogContext = instanceLogContext.ForContext("ConnectionId", connectionId);
                    }

                    if (@event.Exception != null)
                    {
                        instanceLogContext = instanceLogContext.ForContext("Details", @event.Exception);
                    }
                    
                    instanceLogContext.Error(@event.RenderedMessage);
                });
            });

        private static void RegisterHealthCheckApplication(this WebApplication application) =>
            application.MapPost("/", ([FromBody] dynamic _) =>
            {

            });
    }
}
