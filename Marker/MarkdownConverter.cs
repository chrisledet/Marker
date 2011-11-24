using System;
using System.Text;
using MarkdownSharp;

namespace Marker
{
    class MarkdownConverter
    {
        private static Markdown markdown = new Markdown();
        const String body = "<html><body style=\"font: 14px helvetica,arial,freesans,clean,sans-serif\">{0}</body></html>";

        public static String convert(String text)
        {
            return String.Format(body, markdown.Transform(text));
        }
    }
}
