using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models.Abstracts.DTO
{
    public class BriefDTO
    {
        public int ErrorCount { get; set; } = 0;
        public int WarningCount { get; set; } = 0;

        public readonly int IssueCount { get; set; } = 0;

        public BriefDTO(int errorCount = 0, int warningCount = 0) =>
            (ErrorCount, WarningCount, IssueCount) = (errorCount, warningCount, errorCount + warningCount);
    }
}
