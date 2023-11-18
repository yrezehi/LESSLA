using Core.Models.DTO;
using Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace UI.Controllers
{
    [Route("[controller]")]
    public class AccountController : Controller
    {
        private readonly UsersService Service;

        public AccountController(UsersService service) =>
            Service = service;

        [HttpGet("[action]")]
        public IActionResult Login() =>
            View();

        [HttpPost("[action]")]
        public IActionResult Authenticate(CredentialsDTO credentials) => 
            Ok(Service.IsAuthenticated(credentials));
    }
}
