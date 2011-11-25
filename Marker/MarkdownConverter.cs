using System;
using System.Text;
using MarkdownSharp;

namespace Marker
{
    class MarkdownConverter
    {

        private String font;
        private static Markdown markdown;

        public String Font
        {
            get { return this.font; }
            set { this.font = value; } 
        }

        public MarkdownConverter()
        {
            markdown = new Markdown();
        }

        public String convert(String text)
        {
            return String.Format(htmlBody(), markdown.Transform(text));
        }

        private String htmlBody()
        {
            return "<html><body style=\"font: 14px " + Font + "\">{0}</body></html>";
        }
    }
}
