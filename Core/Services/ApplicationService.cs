using Core.Models;
using Core.Services.Abstract;
using System.Security.Claims;

namespace Core.Services
{
    public class ApplicationService : ServiceBase<Application>
    {
        // Interface it with generic authentiucation as provider...
        private readonly ADAuthentication ADAuthentication;
        private readonly IHttpContextAccessor HttpContextAccessor;

        public ApplicationService(IHttpContextAccessor httpContextAccessor, ADAuthentication adAuthentication, ServiceBase<Account> RDBMSServiceBase, PGVServiceBase<VectorEmbedding> PGVServiceBase)
            : base(RDBMSServiceBase, PGVServiceBase) =>
            (ADAuthentication, HttpContextAccessor) = (adAuthentication, httpContextAccessor);

        public async Task<Account> SignIn(CredentialsDTO credentials)
        {
            if (!ADAuthentication.IsAuthenticated(credentials))
                throw new ArgumentException("Invalid authentication attempt!");

            return await this.RDBMSServiceBase.FindByProperty(entity => entity.Email!, credentials.Identifier)
                .Then(CookieAuthenticationSignIn).Then(account => account.Result);
        }

        public async Task SignOut() =>
            await HttpContextAccessor.HttpContext.SignOutAsync();

        private async Task<Account> CookieAuthenticationSignIn(Account account)
        {
            await HttpContextAccessor.HttpContext.SignInAsync(GenerateClaimsPrincipal(account));

            return account;
        }

        private ClaimsPrincipal GenerateClaimsPrincipal(Account account) =>
            new ClaimsPrincipal(GenerateClaimsIdentity(account));


        private ClaimsIdentity GenerateClaimsIdentity(Account account) =>
            new ClaimsIdentity(GenerateClaims(account), CookieAuthenticationDefaults.AuthenticationScheme);


        private List<Claim> GenerateClaims(Account account) =>
            new() {
                new Claim(ClaimTypes.Email, account.Email!),
            };

    }
}