using Core.Models;
using Core.Models.Enums;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace Core.Utils.Extenstions
{
    public static class AuthenticationExtensions
    {
        public static List<Claim> GetClaims(this User user) =>
            new() {
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.Role, user.Role.GetDisplayNameById<UserRole>()),
            };

        public static async Task SignIn(this IHttpContextAccessor accessor, User user) =>
            await accessor.HttpContext.SignInAsync(
                CookieAuthenticationDefaults.AuthenticationScheme,
                new ClaimsPrincipal(new ClaimsIdentity(user.GetClaims(), CookieAuthenticationDefaults.AuthenticationScheme)), new AuthenticationProperties { }
            );
    }
}
