using System.Text;

namespace SeqNotification.Services
{
    public class HtmlBuilder
    {
        

        

        public class HTMLParagraph
        {
            public static string RenderParagraph(string paragraph) =>
                $"<p>{paragraph}</p>";
        }
    }
}
