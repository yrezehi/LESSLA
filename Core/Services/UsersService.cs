using Core.Authentication.LDAP;
using Core.Models;
using Core.Models.DTO;
using Core.Repositories.Abstracts.Interfaces;
using Core.Services.Abstract;
using Core.Utils.Extenstions;
using Microsoft.AspNetCore.Http;

namespace Core.Services
{
    public class UsersService : ServiceBase<User>
    {
        private readonly LDAPAuthentication Authentication;
        private readonly IHttpContextAccessor HttpContextAccessor;

        public UsersService(IHttpContextAccessor httpContextAccessor, IUnitOfWork unitOfWork, LDAPAuthentication LDAPAuthenticationService) : base(unitOfWork) =>
            (HttpContextAccessor, Authentication) = (httpContextAccessor, LDAPAuthenticationService);

        public async Task<bool> IsAuthenticated(CredentialsDTO credentials)
        {
            if(Authentication.IsAuthenticated(credentials.Identifier, credentials.Password))
            {
                User? user = await FindOneOrDefault(entity => entity.Email == credentials.Identifier);

                if(user != null)
                {
                    await HttpContextAccessor.SignIn(user);
                    return true;
                }
            }

            return false;
        }
    }
}