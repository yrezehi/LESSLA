using System.DirectoryServices.AccountManagement;

namespace Core.Authentication.LDAP.Configurations
{
    public static class LDAPConfiguration
    {
        public static string LDAP_DOMAIN = "DOMAIN";
        public static ContextType CONTEXT_TYPE = ContextType.Domain;

        public static string SERVICE_ACCOUNT_USERNAME = "USERNAME";
        public static string SERVICE_ACCOUNT_PASSWORD = "PASSWORD";
    }
}
