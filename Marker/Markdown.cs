using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sundown;

namespace Marker
{
    class Markdown
    {
        const String body = "<html><body style=\"font: 13.34px helvetica,arial,freesans,clean,sans-serif\">{0}</body></html>";
        public static String convert(String markdownText)
        {
            return String.Format(body, MoonShine.Markdownify(markdownText));
        }
    }
}
