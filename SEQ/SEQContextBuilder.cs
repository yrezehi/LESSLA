using Seq.Api;

namespace SEQ
{
    public class SEQContextBuilder
    {
        public SeqConnection SeqConnection { get; set; }

        public SEQContextBuilder(SeqConnection connection) =>
            SeqConnection = connection;

        public static async Task<SEQContextBuilder> Build() =>
            new (await SEQConnection.GetInstance());

        public async Task StreamTailEvents() =>
            await SeqConnection.Events.StreamAsync<dynamic>();

        public async Task Events() =>
            await SeqConnection.Events.ListAsync();
    }
}
