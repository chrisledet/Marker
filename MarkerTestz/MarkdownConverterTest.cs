using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Drawing;
using Marker;

namespace MarkerTests
{
    [TestClass]
    public class MarkdownConverterTest
    {
        private MarkdownConverter converter;

        public MarkdownConverterTest()
        {
            converter = new MarkdownConverter();
        }

        [TestMethod]
        public void TestConvert()
        {
            String convertedMarkdown = converter.ToHtml("### Hello World");
            String htmlText = "<h3>Hello World</h3>";
            Assert.IsTrue( convertedMarkdown.Contains(htmlText) );
        }

        [TestMethod]
        public void TestFont()
        {
            Font font = SystemFonts.DefaultFont;
            converter.Font = font;
            Assert.AreEqual(font, converter.Font);
        }
    }
}
