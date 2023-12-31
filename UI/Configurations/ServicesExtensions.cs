﻿using Core.Authentication.LDAP;
using Core.Services;
using Core.Services.Health;

namespace UI.Configurations
{
    public static class ServicesExtensions
    {
        public static void RegisterServices(this WebApplicationBuilder builder)
        {
            builder.Services.AddTransient(typeof(ApplicationsService), typeof(ApplicationsService));
            builder.Services.AddTransient(typeof(EventLogsService), typeof(EventLogsService));
            builder.Services.AddTransient(typeof(HealthService), typeof(HealthService));
            builder.Services.AddTransient(typeof(UsersService), typeof(UsersService));

            builder.Services.AddTransient(typeof(LDAPAuthentication), typeof(LDAPAuthentication));
        }
    }
}
