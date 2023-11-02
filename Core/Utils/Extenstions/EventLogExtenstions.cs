using Core.Models.Serilog;
using F23.StringSimilarity;

namespace Core.Utils.Extenstions
{
    public static class EventLogExtenstions
    {
        public static readonly JaroWinkler DifferanceCalculator = new JaroWinkler();
        public static readonly double SIMILARITY_THRESHOLD = 0.80;

        public static bool IsSimilarTo(this EventLog currentLog, EventLog secondLog) =>
            DifferanceCalculator.Similarity(currentLog.Details, secondLog.Details) > SIMILARITY_THRESHOLD;
    }
}
