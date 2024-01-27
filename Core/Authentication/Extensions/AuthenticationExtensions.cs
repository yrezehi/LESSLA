using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Core.Authentication.Extensions
{
    public static class AuthenticationExtensions
    {
        public static List<Claim> GetClaims(this User user) =>
            new() {
                new Claim(ClaimTypes.Email, user.Email),
            };
    }
}
