using Core.Authentication.LDAP;
using Core.Models;
using Core.Repositories.Abstracts.Interfaces;
using Core.Services.Abstract;

namespace Core.Services
{
    public class UsersService : ServiceBase<User>
    {
        private readonly LDAPAuthentication Authentication;

        public UsersService(IUnitOfWork unitOfWork, LDAPAuthentication LDAPAuthenticationService) : base(unitOfWork) =>
            Authentication = LDAPAuthenticationService;

        public bool IsAuthenticated(string identifier, string password) =>
            Authentication.IsAuthenticated(identifier, password);
    }
}