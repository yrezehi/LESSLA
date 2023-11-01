using Newtonsoft.Json;

namespace Core.Utils.Extenstions
{
    public static class JSONExtenstions
    {
        public static bool TryParseJSON<T>(this string serializedContent, out T? dserializedContent)
        {
            bool isSuccess = true;

            dserializedContent = JsonConvert.DeserializeObject<T>(serializedContent, new JsonSerializerSettings()
            {
                Error = (_, arguments) => { isSuccess = false; arguments.ErrorContext.Handled = true; },
                MissingMemberHandling = MissingMemberHandling.Error
            });

            return isSuccess;
        }
    }
}
