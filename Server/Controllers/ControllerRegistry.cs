using Core.Models.Serilog;
using Microsoft.AspNetCore.Mvc;
using Serilog;

namespace Server.Controllers
{
    public static class ControllerRegistry
    {
        public static void RegisterControllers(this WebApplication application) =>
            application.Index();

        private static void Index(this WebApplication application) =>
            application.MapPost("/", ([FromBody] LogEventRequest[] events) =>
                Parallel.ForEach(events, @event =>
                    Log.Error(@event.RenderedMessage)
                )
            );
    }
}
