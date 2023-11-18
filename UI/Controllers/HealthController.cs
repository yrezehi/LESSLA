using Core.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace UI.Controllers
{
    [Authorize]
    [Route("[controller]")]
    public class HealthController : Controller
    {
        private readonly HealthService Service;

        public HealthController(HealthService service) =>
            Service = service;

        [HttpGet("[action]")]
        public IActionResult Index() =>
            View();
    }
}
