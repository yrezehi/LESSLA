using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Authentication.Passwordless.Configuration
{
    public static class PasswordlessAuthenticationConfiguration
    {
        private static TimeSpan LINK_VALIDITY_TIME = TimeSpan.FromMinutes(2);
    }
}
