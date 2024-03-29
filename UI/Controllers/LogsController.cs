﻿using Core.Models.Serilog;
using Core.Services;
using Core.SSE;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UI.Controllers.Abstracts;

namespace UI.Controllers
{
    [Authorize]
    [Route("[controller]")]
    public class LogsController : BaseController<EventLogsService, EventLog>
    {
        private readonly SSEProvider SSEProvider;

        public LogsController(EventLogsService Service, SSEProvider sseProvider) : base(Service) => 
            SSEProvider = sseProvider;

        public async Task<IActionResult> Index(int page = 0) =>
            View(await Service.Paginate(page));

        [HttpGet("[action]")]
        public IActionResult Live() =>
            View();

        [HttpGet("[action]")]
        public async Task Listen(CancellationToken cancellationToken)
        {
            await HttpContext.Response.SetSSEHeaders();
            SSEProvider.Register(HttpContext);
            await HttpContext.Response.KeepSSEAlive(cancellationToken);
        }
    }
}
