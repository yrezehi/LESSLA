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
                    instanceLogContext.Error(@event.RenderedMessage);
                });
            });
    }
}
