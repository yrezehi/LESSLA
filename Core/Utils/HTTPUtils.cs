using System.Net.NetworkInformation;

namespace Core.Utils
{
    public static class HTTPUtils
    {
        private readonly static int REQUEST_TIMEOUT = 10;

        public static bool IsPingable(string endpoint) =>
            new Ping().Send(endpoint, REQUEST_TIMEOUT).Status == IPStatus.Success;

        public static async Task<bool> IsReachable(string endpoint) =>
            (await new HttpClient().GetAsync(endpoint)).IsSuccessStatusCode;
    }
}
