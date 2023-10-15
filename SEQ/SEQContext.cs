using Seq.Api;

namespace SEQ
{
    public class SEQContext
    {
        public SeqConnection SeqConnection { get; set; }

        public SEQContext(SeqConnection connection) =>
            SeqConnection = connection;

        public static async Task<SEQContext> Instance() =>
            new (await SEQConnection.GetInstance());

        public async Task StreamTailEvents() =>
            await SeqConnection.Events.StreamAsync<dynamic>();

        public async Task Events() =>
            await SeqConnection.Events.ListAsync();
    }
}
