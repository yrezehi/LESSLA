using System.Text;

namespace SeqNotification.Services
{
    public class HtmlBuilder
    {
        public class HTMLTable : IDisposable
        {
            private StringBuilder HTMLStringBuilder;

            public HTMLTable()
            {
                HTMLStringBuilder = new StringBuilder();
                HTMLStringBuilder.Append($"<table>");
            }

            public void Dispose()
            {
                HTMLStringBuilder.Append("</table>");
            }

            public HTMLRow AddRow()
            {
                return new HTMLRow(HTMLStringBuilder);
            }

            public HTMLRow AddHeaderRow()
            {
                return new HTMLRow(HTMLStringBuilder, true);
            }

            public void StartTableBody()
            {
                HTMLStringBuilder.Append("<tbody>");
            }

            public void EndTableBody()
            {
                HTMLStringBuilder.Append("</tbody>");
            }

            public string RenderTable()
            {
                return HTMLStringBuilder.ToString();
            }
        }

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

        public class HTMLParagraph
        {
            public static string RenderParagraph(string paragraph)
            {
                return $"<p>{paragraph}</p>";
            }
        }
    }
}
