using System;
using System.Text;
using System.IO;

namespace Marker
{
    class FileHandler
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

        public String OpenFile(String filePath)
        {
            if (!File.Exists(filePath)) return "";

            String fileContents;
            using (StreamReader sr = new StreamReader(filePath))
            {
                fileContents = sr.ReadToEnd();
            }

            return fileContents;
        }

        public void SaveMarkdown(String filePath)
        {
            SaveFile(filePath, markdownText);
        }

        public void SaveHtml(String filePath)
        {
            SaveFile(filePath, htmlText);
        }

        private void SaveFile(String filePath, String text)
        {
            if (filePath.Trim() == "") return;

            using (StreamWriter file = new StreamWriter(filePath))
            {
                file.Write(text);
            }
        }
    }
}
