using Core.Models.Serilog;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Serilog;
using System;

namespace Server.Controllers
{
    public static class ControllerRegistry
    {
        public static void RegisterControllers(this WebApplication application) =>
            application.Index();

        private static void Index(this WebApplication application) =>
            application.MapPost("/", ([FromBody] LogEventRequest[] events) => {
                var instanceLogContext = Log.ForContext("Server", "ip");

                Parallel.ForEach(events, @event => {
                    @event.Properties.ToList().ForEach(property =>
                    {
                        instanceLogContext = instanceLogContext.ForContext(property.Key, property.Value);
                    });

                    instanceLogContext.Error(@event.RenderedMessage);
                });
               
            });
    }
}
