using Core.Models.Serilog;
using Core.Services;
using Core.SSE;
using Microsoft.AspNetCore.Mvc;
using UI.Controllers.Abstracts;

namespace UI.Controllers
{
    [Route("[controller]")]
    public class HealthController : Controller
    {
        private readonly HealthService Service;

        public HealthController(HealthService service) =>
            Service = service;
    }
}
