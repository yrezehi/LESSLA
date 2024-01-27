﻿using Core.Models;
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
        public IActionResult Authenticate(CredentialsDTO credentials) => 
            Ok(Service.IsAuthenticated(credentials));

        [HttpGet("[action]")]
        public IActionResult AccessDenied() =>
            View();
    }
}
