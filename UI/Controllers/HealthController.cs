using Core.Models.Health;
using Core.Services.Health;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UI.Controllers.Abstracts;

namespace UI.Controllers
{
    [Authorize]
    [Route("[controller]")]
    public class HealthController : BaseController<HealthService, HealthCheckApplication>
    {
        public HealthController(HealthService Service) : base(Service) { }

        [HttpGet("[action]")]
        public IActionResult Index() =>
            View();

        [HttpGet("[action]")]
        public async Task<IActionResult> Manage(int page = 0) =>
            View(await Service.Paginate(page));
    }
}
