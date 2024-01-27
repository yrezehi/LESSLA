using Core.Models;
using Core.Models.DTO;
using Core.Services;
using Core.SSE;
using Microsoft.AspNetCore.Mvc;
using UI.Controllers.Abstracts;

namespace UI.Controllers
{
    [Route("[controller]")]
    public class AccountController : BaseController<UsersService, User>
    {
        public AccountController(UsersService Service) : base(Service) { }

        [HttpGet("[action]")]
        public IActionResult Login() =>
            View();

        [HttpGet("[action]")]
        public IActionResult Logout() =>
            RedirectToAction("Login");

        [HttpPost("[action]")]
        public async Task<IActionResult> Authenticate(CredentialsDTO credentials) {

            if(await Service.IsAuthenticated(credentials))
            {
                return RedirectToAction("Index", "Home");
            }

            return RedirectToAction("Login", "Account");
        }

        [HttpGet("[action]")]
        public IActionResult AccessDenied() =>
            View();
    }
}
