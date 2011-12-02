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

        public String openFile(String filePath)
        {
            if (!File.Exists(filePath)) return "";

            StringBuilder fileContents = new StringBuilder();
            using (StreamReader sr = new StreamReader(filePath))
            {
                String line;
                while ((line = sr.ReadLine()) != null)
                {
                    fileContents.AppendFormat("{0}\r\n", line);
                }
            }

            return fileContents.ToString();
        }

        public void saveMarkdown(String filePath)
        {
            saveFile(filePath, markdownText);
        }

        public void saveHtml(String filePath)
        {
            saveFile(filePath, htmlText);
        }

        private void saveFile(String filePath, String text)
        {
            if (filePath.Trim() == "") return;

            using (StreamWriter file = new StreamWriter(filePath))
            {
                file.Write(text);
            }
        }
    }
}
