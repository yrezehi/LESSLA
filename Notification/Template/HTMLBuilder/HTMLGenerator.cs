using Core.Utils;
using Notification.Template.HTMLBuilder.Elements;
using System.Reflection;

namespace Notification.Template.HTMLBuilder
{
    public static class HTMLGenerator
    {
        public static string Generate<T>(IEnumerable<T> objectProperties)
        {
            IEnumerable<PropertyInfo> properties = ReflectionUtil.GetObjectProperties(typeof(T));

            using (HTMLTable table = new HTMLTable())
            {
                foreach (var property in properties)
                {
                    using (HTMLRow row = table.AddRow())
                    {
                        row.AddCell(property.Name);
                    }
                }

                foreach (var objectProperty in objectProperties)
                {
                    using (HTMLRow row = table.AddRow())
                    {
                        row.AddCell();
                    }
                }

                return table;
            }

        }
    }
}
