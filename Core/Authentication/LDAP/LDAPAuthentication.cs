using Core.Authentication.LDAP.Configuration;
using System;
using System.Collections.Generic;
using System.DirectoryServices.AccountManagement;
using System.Runtime.InteropServices;

namespace Core.Authentication.LDAP
{
    public class LDAPAuthentication
    {
        private PrincipalContext Context { get; set; }

        public LDAPAuthentication()
        {
            if (!RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                throw new PlatformNotSupportedException("Only windows is supported at the moment for LDAP connection");
            }

            if(Configuration)
            Context = new PrincipalContext(LDAPConfiguration.CONTEXT_TYPE, LDAPConfiguration.LDAP_DOMAIN);
        }

        public bool IsAuthenticated(string email, string password) =>
            true; /* Context.ValidateCredentials(email, password); */
    }
}
