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
        private HealthLogService HealthLogService;

        public HealthController(HealthService Service, HealthLogService healthLogService) : base(Service) =>
            (HealthLogService) = (healthLogService);

        [HttpGet("[action]")]
        public async Task<IActionResult> Index() =>
            View(await HealthLogService.Dashboard());

        [HttpGet("[action]")]
        public async Task<IActionResult> Manage(int page = 0) =>
            View(await Service.Paginate(page));
    }
}
