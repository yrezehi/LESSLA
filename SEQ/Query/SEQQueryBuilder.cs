namespace SEQ.Query
{
    public class SEQQueryBuilder
    {
        public IList<string> Query { get; set; } = new List<string>();

        public static SEQQueryBuilder Builder() =>
            new();

        public SEQQueryBuilder WithEnvironment(string environment)
        {
            Query.Add(QueryTemplate("Environment", environment));
            return this;
        }

        public SEQQueryBuilder WithApplication(string environment)
        {
            Query.Add(QueryTemplate("Application", environment));
            return this;
        }

        public SEQQueryBuilder WithLevel(string level)
        {
            Query.Add(QueryTemplate("@Level", level));
            return this;
        }

        private string QueryTemplate(string key, string value) =>
            $"{key} = {value}";
    }
}
