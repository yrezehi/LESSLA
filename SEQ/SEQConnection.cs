using Seq.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEQ
{
    public static class SEQConnection
    {
        public static SeqConnection Connection = new SeqConnection(SEQConfiguration.SEQ_SERVER_ADDRESS);

        public static async Task Initlize() =>
            await Connection.Users.LoginAsync(SEQConfiguration.SEQ_LOGIN_USERNAME, SEQConfiguration.SEQ_LOGIN_PASSWORD);

        public static SeqConnection GetInstance() =>
            Connection;
    }
}
