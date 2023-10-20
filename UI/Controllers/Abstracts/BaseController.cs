using Core.Services.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace UI.Controllers.Abstracts
{
    public class BaseController<IService, T> : Controller where IService : ServiceBase<T> where T : class
    {
        public IService Service { get; set; }

        public BaseController(IService service) => Service = service;

        [HttpGet("api/{id}")]
        public virtual async Task<IActionResult> Id(int id)
        {
            return Ok(await Service.FindById(id));
        }

        [HttpGet("api")]
        public virtual async Task<IActionResult> GetAll(int? page)
        {
            return Ok(await Service.GetAll(page));
        }

        [HttpGet("api/[action]")]
        public virtual async Task<IActionResult> Search(string property, string value, int? page)
        {
            return Ok(await Service.RDBMSServiceBase.SearchByProperty<string>(property, value, page));
        }

    }
}
