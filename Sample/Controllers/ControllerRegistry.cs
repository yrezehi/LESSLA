﻿namespace Sample.Controllers
{
    public static class ControllerRegistry
    {
        public static void RegisterControllers(this WebApplication application) =>
            application.Index();

        private static void Index(this WebApplication application) =>
            application.MapGet("", (_) => throw new NotImplementedException("Sample Not Implemented Exception!"));
    }
}
