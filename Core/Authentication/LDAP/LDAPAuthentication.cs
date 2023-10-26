using Core.Authentication.LDAP.Configuration;
using System;
using System.Collections.Generic;
using System.DirectoryServices.AccountManagement;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Core.Authentication.LDAP
{
    public class LDAPAuthentication
    {
        private PrincipalContext Context { get; set; }

        private LDAPAuthentication()
        {
            if (!RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                throw new PlatformNotSupportedException("Only windows is supported at the moment for LDAP connection");
            }

            Context = new PrincipalContext(LDAPConfiguration.CONTEXT_TYPE, LDAPConfiguration.LDAP_DOMAIN);
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Interoperability", "CA1416:Validate platform compatibility", Justification = "<Pending>")]
        public bool IsAuthenticated (string email, string password) => 
            Context.ValidateCredentials(email, password);
    }
}
