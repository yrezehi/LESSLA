using Core.Models;
using Core.Repositories.Abstracts.Interfaces;
using Core.Services.Abstract;

namespace Core.Services
{
    public class EventLogsService : ServiceBase<EventLog>
    {
        public EventLogsService(IUnitOfWork unitOfWork) : base(unitOfWork) { }

        public IEnumerable<EventLog> Live() => 
            new List<EventLog>();

        public IEnumerable<EventLog> History(int page) => 
            this.Paginate(page);
    }
}
