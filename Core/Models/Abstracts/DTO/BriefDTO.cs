namespace Core.Models.Abstracts.DTO
{
    public class BriefDTO
    {
        public int ErrorCount { get; set; } = 0;
        public string ErrorBrief { get; set; } = "No Past Data Available";

        public int WarningCount { get; set; } = 0;

        public int IssueCount { get; private set; } = 0;

        public BriefDTO(int errorCount = 0, int warningCount = 0) =>
            (ErrorCount, WarningCount, IssueCount) 
                = 
            (errorCount, warningCount, errorCount + warningCount);
    }
}
