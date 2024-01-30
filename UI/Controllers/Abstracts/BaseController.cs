using Core.Services.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace UI.Controllers.Abstracts
{
    public class BaseController<IService, T> : Controller where IService : ServiceBase<T> where T : class
    {
        public IService Service { get; set; }

        public BaseController(IService service) =>
            Service = service;

        [HttpGet("api/{id}")]
        public virtual async Task<IActionResult> Id(int id) =>
            Ok(await Service.FindById(id));

        [HttpGet("api")]
        public virtual async Task<IActionResult> GetAll(int? page) =>
            Ok(await Service.GetAll(page));

        [HttpPost("submit/form")]
        public virtual async Task<IActionResult> Form([FromForm] T entity)
        {
            await Service.Create(entity);

            return Redirect(Request.Headers["Referer"].FirstOrDefault() ?? "/");
        }

        [HttpPost("submit/update/form")]
        public virtual async Task<IActionResult> UpdateForm([FromForm] T entity, int id)
        {
            await Service.UpdateNecessary(entity, id);

            return Redirect(Request.Headers["Referer"].FirstOrDefault() ?? "/");
        }

        [HttpGet("api/[action]")]
        public virtual async Task<IActionResult> Search(string property, string value, int? page) =>
            Ok(await Service.SearchByProperty<string>(property, value, page));

        [HttpGet("[action]")]
        public virtual async Task<IActionResult> ModalView(string viewName, int id) =>
            PartialView(viewName, await Service.FindById(id));
    }
}
