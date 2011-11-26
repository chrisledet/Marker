using System;
using System.IO;

namespace Marker
{
    class Exporter
    {
        private String htmlText, markdownText;

        public String HtmlText
        {
            get { return this.htmlText;  }
            set { this.htmlText = value; }
        }

        public String MarkdownText
        {
            get { return this.markdownText;  }
            set { this.markdownText = value; }
        }

        public void saveMarkdown(String pathToFile)
        {
            saveFile(pathToFile, markdownText);
        }

        public void saveHtml(String pathToFile)
        {
            saveFile(pathToFile, htmlText);
        }

        private void saveFile(String pathToFile, String text)
        {
            if (pathToFile.Trim() != "")
            {
                StreamWriter file = new StreamWriter(pathToFile);
                file.Write(text);
                file.Close();
            }
        }
    }
}
