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
using MarkdownSharp;

namespace Marker
{
    public class MarkdownConverter
    {

        private String font;
        private Markdown markdown;

        public String Font
        {
            get { return this.font; }
            set { this.font = value; } 
        }

        public MarkdownConverter()
        {
            markdown = new Markdown();
        }

        public String Convert(String text)
        {
            return String.Format(HtmlBody(), markdown.Transform(text));
        }

        private String HtmlBody()
        {
            return "<html><body style=\"font: 14px " + Font + "\">{0}</body></html>";
        }
    }
}
