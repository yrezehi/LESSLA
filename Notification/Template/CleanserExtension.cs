using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Notification.Template
{
    public static class CleanserExtension
    {
        public static string ToCamelCase(this string @string) =>
            JsonNamingPolicy.CamelCase.ConvertName(@string);
    }
}
