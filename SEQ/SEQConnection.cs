using Seq.Api;

namespace SEQ
{
    public static class SEQConnection
    {
        private static SeqConnection Connection;

        public static async Task Initlize()
        {
            Connection = new SeqConnection(SEQConfiguration.SEQ_SERVER_ADDRESS);

            await Connection.Users.LoginAsync(SEQConfiguration.SEQ_LOGIN_USERNAME, SEQConfiguration.SEQ_LOGIN_PASSWORD);
        }

        public async static Task<SeqConnection> GetInstance()
        {
            if(Connection == null)
            {
                await Initlize();
            }

            return Connection!;
        }
    }
}
