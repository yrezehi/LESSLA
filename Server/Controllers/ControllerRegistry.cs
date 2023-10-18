using Core.Models;
using Microsoft.AspNetCore.Mvc;
using Serilog;

namespace Server.Controllers
{
    public static class ControllerRegistry
    {
        public static void RegisterControllers(this WebApplication application) =>
            application.Index();

        private static void Index(this WebApplication application) =>
            application.MapPost("/log-events", ([FromBody] Event[] events) =>
                Parallel.ForEach(events, @event =>
                    Log.Error(@event.RenderedMessage)
                )
            );
    }
}
