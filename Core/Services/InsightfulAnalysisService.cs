using Core.Models.DTO;
using Core.Models.Serilog;
using Core.Repositories.Abstracts.Interfaces;
using Core.Services.Abstract;
using Core.Utils.Extenstions;

namespace Core.Services
{
    public class InsightfulAnalysisService : ServiceBase<EventLog>
    {
        public InsightfulAnalysisService(IUnitOfWork unitOfWork) : base(unitOfWork) { }


        public async Task<int> ErrorsComparedToLastWeekInsight(int errorCount) =>
            await ErrorsComparedTo(-14, -7, errorCount);

        public async Task<int> ErrorsComparedToLastDayInsight(int errorCount) =>
            await ErrorsComparedTo(-1, 0, errorCount);

        private async Task<int> ErrorsComparedTo(int start, int end, int errorCount) =>
            MathExtenstions.PercentageBetween(errorCount, await ErrorsBetween(start, end));

        private async Task<int> ErrorsBetween(int start, int end) =>
            await Count(log => log.TimeStamp <= DateTime.Now.AddDays(start) && log.TimeStamp >= DateTime.Now.AddDays(end));

        public IEnumerable<EventLog> SimilarLogs(EventLog log) =>
            this.Find(@log => @log.Application != null && @log.Application.Equals(log.Application) && log.IsSimilarTo(@log));

        public async Task<BriefDTO> Brief()
        {
            BriefDTO brief = new(errorsCount: await this.Count(log => log.Level.Equals("Error")));

            brief.WithLastDayPercent(await ErrorsComparedToLastDayInsight(brief.ErrorsCount));
            brief.WithLastWeekPercent(await ErrorsComparedToLastWeekInsight(brief.ErrorsCount));

            return brief;
        }
    }
}
