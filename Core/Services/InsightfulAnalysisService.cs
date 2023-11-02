using Core.Models.Abstracts.DTO;
using Core.Models.Serilog;
using Core.Repositories.Abstracts.Interfaces;
using Core.Services.Abstract;
using Core.Utils.Extenstions;

namespace Core.Services
{
    public class InsightfulAnalysisService : ServiceBase<EventLog>
    {
        public InsightfulAnalysisService(IUnitOfWork unitOfWork) : base(unitOfWork) { }
        public async Task<string> ErrorsComparedToLastWeekInsight(int errorCount) =>
            $"{await ErrorsComparedTo(-14, -7, errorCount)}% errors than the week before!";

        public async Task<string> ErrorsComparedToLastDayInsight(int errorCount) =>
            $"{await ErrorsComparedTo(-1, 0, errorCount)}% errors than the day before!";

        private async Task<int> ErrorsComparedTo(int start, int end, int errorCount) =>
            MathExtenstions.PercentageBetween(errorCount, await ErrorsBetween(start, end));

        private async Task<int> ErrorsBetween(int start, int end) =>
            await Count(log => log.TimeStamp <= DateTime.Now.AddDays(start) && log.TimeStamp >= DateTime.Now.AddDays(end));

        private async Task<IEnumerable<EventLog>> SimilarLogs(EventLog log) {
            var relatedLogs = this.Find(@log => @log.Application != null && @log.Application.Equals(log.Application));

            relatedLogs
            return relatedLogs;
        }

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
