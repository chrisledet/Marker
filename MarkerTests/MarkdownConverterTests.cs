using Xunit;
using Marker;
using System;

namespace MarkerTests
{
    public class MarkdownConverterTests
    {
        private MarkdownConverter converter;

        public MarkdownConverterTests()
        {
            converter = new MarkdownConverter();
        }

        [Fact]
        public void TestMe()
        {
            String markdownText = "### Hello World";
            String htmlText = "<h3>Hello World</h3>";
            Assert.True( converter.convert(markdownText).Contains(htmlText) );
        }
    }
}
