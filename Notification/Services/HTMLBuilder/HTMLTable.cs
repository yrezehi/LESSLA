using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notification.Services.HTMLBuilder
{
    public class HTMLTable : IDisposable
    {
        private StringBuilder HTMLStringBuilder;
        
        public HTMLTable()
        {
            HTMLStringBuilder = new StringBuilder();
            HTMLStringBuilder.Append($"<table>");
        }

        public void Dispose() =>
            HTMLStringBuilder.Append("</table>");

        public HTMLRow AddRow() =>
            new HTMLRow(HTMLStringBuilder);

        public HTMLRow AddHeaderRow() =>
            new HTMLRow(HTMLStringBuilder, true);

        public void StartTableBody() =>
            HTMLStringBuilder.Append("<tbody>");

        public void EndTableBody() =>
            HTMLStringBuilder.Append("</tbody>");

        public string RenderTable() =>
            HTMLStringBuilder.ToString();
    }
}
