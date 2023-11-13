using Core.Hooks.Models;
using Core.Repositories.Abstracts.Interfaces;
using Core.Services.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Hooks
{
    public class WebHooks : ServiceBase<WebHookSubscriber>
    {
        public WebHooks(IUnitOfWork unitOfWork) : base(unitOfWork) { }
    }
}
