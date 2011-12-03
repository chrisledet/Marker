#region LICENSE
/*
 * Marker - Markdown Editor for Windows 
 * Copyright (c) 2011 Chris Ledet
 * http://github.com/chrisledet/Marker
 * 
 * Markdown is a text-to-HTML conversion tool for web writers
 * Copyright (c) 2004 John Gruber
 * http://daringfireball.net/projects/markdown/
 * 
 * Markdown.NET
 * Copyright (c) 2004-2009 Milan Negovan
 * http://www.aspnetresources.com
 * http://aspnetresources.com/blog/markdown_announced.aspx
 * 
 * MarkdownSharp
 * Copyright (c) 2009-2010 Jeff Atwood
 * http://stackoverflow.com
 * http://www.codinghorror.com/blog/
 * http://code.google.com/p/markdownsharp/
 * 
 */

#endregion

using System;
using System.Drawing;
using MarkdownSharp;

namespace Marker
{
    public class MarkdownConverter
    {

        private Font font;
        private Markdown markdown;

        public Font Font
        {
            get { return this.font; }
            set { this.font = value; } 
        }

        public MarkdownConverter()
        {
            markdown = new Markdown();
        }

        public String ToHtml(String text)
        {
            return String.Format("{0}{1}{2}", HtmlHead(), markdown.Transform(text), HtmlFoot());
        }

        private String HtmlHead()
        {
            return String.Format("<html>\n<body style='font: {0}px {1}'>", Font.Size, Font.FontFamily.Name);
        }

        private String HtmlFoot()
        {
            return "</body>\n</html>";
        }
    }
}
