using Microsoft.AspNetCore.Mvc;
using Server.Models;

namespace Server.Controllers
{
    public static class ControllerRegistry
    {
        public static void RegisterControllers(this WebApplication application) =>
            application.Index();

        private static void Index(this WebApplication application) =>
            application.MapPost("/log-events", ([FromBody] Event[] events) =>
                events.ToList().ForEach(@event =>
                {
                    Console.WriteLine(@event);
                })
            );
    }
}
