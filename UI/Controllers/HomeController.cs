using Core.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using UI.Models;

namespace UI.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly EventLogsService LogsService;
        private readonly InsightfulAnalysisService AnalysisService;

        public HomeController(InsightfulAnalysisService analysisService, EventLogsService logsService) =>
            (AnalysisService, LogsService) = (analysisService, logsService);

        public async Task<IActionResult> Index() =>
            View(await AnalysisService.Brief());

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error() =>
            View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}