namespace Core.Models.DTO
{
    public class BriefDTO
    {
        public int ErrorsCount { get; set; } = 0;
        
        public int ErrorsComparedToLastWeekInsight { get; set; } = 0;
        public int ErrorsComparedToLastDayInsight { get; set; } = 0;

        public BriefDTO(int errorsCount = 0) =>
            (ErrorsCount) = (errorsCount);

        public BriefDTO WithLastWeekPercent(int percent)
        {
            ErrorsComparedToLastWeekInsight = percent;
            return this;
        }

        public BriefDTO WithLastDayPercent(int percent)
        {
            ErrorsComparedToLastDayInsight = percent;
            return this;
        }
    }
}
