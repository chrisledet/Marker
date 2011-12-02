using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Marker
{
    public partial class MainWindow : Form
    {
        private String appName;
        private MarkdownConverter converter;
        private FileHandler fileHandler;
        private String lastSavedFilename, lastSavedFilePath;

        public MainWindow(String filePath)
        {
            initializeWindow();
            openFile(filePath);
        }

        public MainWindow()
        {
            initializeWindow();
        }

        private void initializeWindow()
        {
            InitializeComponent();

            appName = "Marker";

            converter = new MarkdownConverter();
            converter.Font = "Segoe UI";

            fileHandler = new FileHandler();

            lastSavedFilename = "";
            lastSavedFilePath = "";
        }

        private void markdownTextBox_TextChanged(object sender, EventArgs e)
        {
            markdownPreview.DocumentText = converter.convert(markdownTextBox.Text);
        }

        private void openMenuItem_Click(object sender, EventArgs e)
        {
            String openPath = openMarkdownDialog();
            openFile(openPath);
        }
        
        private void saveMenuItem_Click(object sender, EventArgs e)
        {
            String filePath = lastSavedFilePath != "" ? lastSavedFilePath : saveMarkdownDialog();
            saveFile(filePath);
        }

        private void saveAsMenuItem_Click(object sender, EventArgs e)
        {
            String filePath = saveMarkdownDialog();
            saveFile(filePath);
        }

        private void exportToHTMLToolMenuItem_Click(object sender, EventArgs e)
        {
            String filePath = saveHtmlDialog();
            exportHtml(filePath);
        }

        private void exitMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        /// <summary>
        /// Shows SaveFileDialog with Markdown filter
        /// </summary>
        /// <returns>filePath - Path to which user selected </returns>
        private String saveMarkdownDialog()
        {
            SaveFileDialog saveDialog = new SaveFileDialog();
            saveDialog.Filter = "Markdown (*.md)|*.md";
            saveDialog.ShowDialog();
            return saveDialog.FileName;
        }

        /// <summary>
        /// Shows OpenFileDialog with Markdown filter
        /// </summary>
        /// <returns>filePath - Path to which user selected</returns>
        private String openMarkdownDialog()
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Filter = "Markdown (*.md)|*md";
            fileDialog.Title  = "Open Markdown file";
            fileDialog.RestoreDirectory = true;
            fileDialog.ShowDialog();
            return fileDialog.FileName;
        }

        /// <summary>
        /// Shows SaveFileDialog with HTML filter
        /// </summary>
        /// <returns>filePath - Path to file which user selected</returns>
        private String saveHtmlDialog()
        {
            SaveFileDialog saveDialog = new SaveFileDialog();
            saveDialog.Filter = "HTML (*.html)|*html";
            saveDialog.DefaultExt = "html";
            saveDialog.FileName = "Untitled.html";
            saveDialog.ShowDialog();
            return saveDialog.FileName;
        }

        /// <summary>
        /// Appends last saved filename to Main window's title
        /// </summary>
        private void refreshTitle()
        {
            this.Text = String.Format("{0} - {1}", lastSavedFilename, appName);
        }

        /// <summary>
        /// Setter for the lastSavedFilePath and lastSavedFilename
        /// </summary>
        private void setLastSavedFile(String filePath)
        {
            lastSavedFilePath = filePath;

            int startOfFileName = lastSavedFilePath.LastIndexOf("\\") + 1;
            lastSavedFilename = 
                lastSavedFilePath.Substring(startOfFileName, lastSavedFilePath.Length - startOfFileName);

            Console.WriteLine("Saving to {0}", lastSavedFilePath);
            Console.WriteLine("Saved file: {0}", lastSavedFilename);
        }
        
        /// <summary> 
        /// Opens file from filePath and puts it into markdown TextBox 
        /// </summary>
        /// <param name="filePath">File path to Markdown file</param
        private void openFile(String filePath)
        {
            markdownTextBox.Text = fileHandler.openFile(filePath);
            setLastSavedFile(filePath);
            refreshTitle();
        }

        /// <summary>
        /// Takes Markdown text and sends it to the fileHandler for saving.
        /// </summary>
        /// <param name="filePath">File path to save the Markdown file</param>
        private void saveFile(String filePath)
        {
            if (filePath.Trim() == "") return;

            fileHandler.MarkdownText = markdownTextBox.Text;
            fileHandler.saveMarkdown(filePath);
            setLastSavedFile(filePath);
            refreshTitle();
        }

        /// <summary>
        /// Takes the HTML from the preview and sends it to the 
        /// fileHandler for saving.
        /// </summary>
        /// <param name="filePath">File path to save the HTML file</param>
        private void exportHtml(String filePath)
        {
            if (filePath.Trim() == "") return;
            fileHandler.HtmlText = markdownPreview.DocumentText;
            fileHandler.saveHtml(filePath);
        }
    }
}
