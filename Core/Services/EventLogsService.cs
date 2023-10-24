using Core.Models.Abstracts.DTO;
using Core.Models.Serilog;
using Core.Repositories.Abstracts.Interfaces;
using Core.Services.Abstract;
using Core.Utils.Extenstions;

namespace Core.Services
{
    public class EventLogsService : ServiceBase<EventLog>
    {
        public EventLogsService(IUnitOfWork unitOfWork) : base(unitOfWork) { }

        public IEnumerable<EventLog> Live() =>
            new List<EventLog>();

        public async Task<PaginateDTO<EventLog>> History(int page) =>
            await this.Paginate(page);

        public async Task<BriefDTO> Brief()
        {
            BriefDTO briefDTO = new(
                errorCount: await this.Count(log => log.Level.Equals("Error"))
            );

            if (briefDTO.ErrorCount > 0)
            {
                int lastWeekErrorsCount = await this.Count(log => log.TimeStamp <= DateTime.Now.AddDays(-7) && log.TimeStamp >= DateTime.Now.AddDays(-14));

                if (lastWeekErrorsCount > 0)
                {
                    if (briefDTO.ErrorCount > lastWeekErrorsCount)
                    {
                        briefDTO.ErrorBrief = $"{MathExtenstions.PercentageBetween(briefDTO.ErrorCount, lastWeekErrorsCount)}% More errors than the week before!";
                    }
                    else
                    {
                        briefDTO.ErrorBrief = $"{MathExtenstions.PercentageBetween(briefDTO.ErrorCount, lastWeekErrorsCount)}% Less errors than a week before!";
                    }
                }
            }

            return briefDTO;
        }
    }
}
