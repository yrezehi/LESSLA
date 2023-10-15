using Seq.Api;
using SEQ.Query;

namespace SEQ
{
    public class SEQContext
    {
        public SeqConnection SeqConnection { get; set; }

        public SEQContext(SeqConnection connection) =>
            SeqConnection = connection;

        public static async Task<SEQContext> Instance() =>
            new (await SEQConnection.GetInstance());

        public async Task StreamTailEvents(SEQQueryBuilder query) =>
            await SeqConnection.Events.StreamAsync<dynamic>(filter: query.Build());

        public async Task Events(SEQQueryBuilder query) =>
            await SeqConnection.Events.ListAsync(filter: query.Build());
    }
}
