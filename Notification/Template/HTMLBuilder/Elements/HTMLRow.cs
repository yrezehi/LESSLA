using System.Text;

namespace Notification.Template.HTMLBuilder.Elements
{
    public class HTMLRow : IDisposable
    {
        private StringBuilder HTMLStringBuilder;
        private bool _isHeader;

        public HTMLRow(StringBuilder stringBuilder, bool isHeader = false)
        {
            HTMLStringBuilder = stringBuilder;
            _isHeader = isHeader;
            if (_isHeader)
            {
                HTMLStringBuilder.Append("<thead>");
            }
            HTMLStringBuilder.Append("<tr>");
        }

        public void Dispose()
        {
            HTMLStringBuilder.Append("</tr>");
            if (_isHeader)
            {
                HTMLStringBuilder.Append("</thead>");
            }
        }

        public void AddCell(string innerText)
        {
            HTMLStringBuilder.Append("<td>");
            HTMLStringBuilder.Append("" + innerText);
            HTMLStringBuilder.Append("</td>");
        }
    }
}
