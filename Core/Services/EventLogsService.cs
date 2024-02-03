using Core.Cache.LRU;
using Core.Models.DTO;
using Core.Models.Serilog;
using Core.Repositories.Abstracts.Interfaces;
using Core.Services.Abstract;
using Core.Utils.Extenstions;
using Core.Utils.Queue;

namespace Core.Services
{
    public class EventLogsService : ServiceBase<EventLog>
    {
        public EventLogsService(IUnitOfWork unitOfWork) : base(unitOfWork) { }
    }
}
