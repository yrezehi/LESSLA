using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utils
{
    public static class HTTPUtils
    {
        private readonly static int REQUEST_TIMEOUT = 10;

        public static bool IsPingable(string endpoint) =>
            new Ping().Send(endpoint, REQUEST_TIMEOUT).Status == IPStatus.Success;
    }
}
