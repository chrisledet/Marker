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
        private bool markdownTextChanged;
        private Font markdownFont, htmlFont;

        #region Constructors
        public MainWindow(String filePath)
        {
            InitializeWindow();
            OpenFile(filePath);
        }

        public MainWindow()
        {
            InitializeWindow();
        }
        #endregion

        private void InitializeWindow()
        {
            this.Icon = Properties.Resources.Marker;
            InitializeComponent();

            appName = Application.ProductName;
 
            markdownFont = Properties.Settings.Default.MarkdownFont;
            htmlFont = Properties.Settings.Default.HtmlFont;

            converter = new MarkdownConverter();
            converter.Font = htmlFont;

            fileHandler = new FileHandler();

            lastSavedFilename = "";
            lastSavedFilePath = "";

            markdownTextChanged = false;
        }

        private void markdownTextBox_TextChanged(object sender, EventArgs e)
        {
            markdownTextChanged = true;
            markdownPreview.DocumentText = converter.ToHtml(markdownTextBox.Text);
        }


        #region Menu Events
        private void newMenuItem_Click(object sender, EventArgs e)
        {
            NewMarkdownDocument();
        }

        private void openMenuItem_Click(object sender, EventArgs e)
        {
            OpenMarkdownDocument();
        }
        
        private void saveMenuItem_Click(object sender, EventArgs e)
        {
            SaveMarkdownDocument();
        }

        private void saveAsMenuItem_Click(object sender, EventArgs e)
        {
            String filePath = SaveMarkdownDialog();
            SaveFile(filePath);
            markdownTextChanged = false;
        }

        private void exportToHTMLToolMenuItem_Click(object sender, EventArgs e)
        {
            String filePath = SaveHtmlDialog();
            ExportHtml(filePath);
        }

        private void exitMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void aboutMenuItem_Click(object sender, EventArgs e)
        {
            ShowAboutBox();
        }
        #endregion

        #region Dialogs
        /// <summary>
        /// Shows SaveFileDialog with Markdown filter
        /// </summary>
        /// <returns>filePath - Path to which user selected </returns>
        private String SaveMarkdownDialog()
        {
            SaveFileDialog saveDialog = new SaveFileDialog();
            saveDialog.Filter = "Markdown (*.md)|*.md";
            saveDialog.ShowDialog();
            return saveDialog.FileName;
        }

        /// <summary>
        /// Shows SaveFileDialog with HTML filter
        /// </summary>
        /// <returns>filePath - Path to file which user selected</returns>
        private String SaveHtmlDialog()
        {
            SaveFileDialog saveDialog = new SaveFileDialog();
            saveDialog.Filter = "HTML (*.html)|*html";
            saveDialog.DefaultExt = "html";
            saveDialog.FileName = "Untitled.html";
            saveDialog.ShowDialog();
            return saveDialog.FileName;
        }
        
        /// <summary>
        /// Shows OpenFileDialog with Markdown filter
        /// </summary>
        /// <returns>filePath - Path to which user selected</returns>
        private String OpenMarkdownDialog()
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Filter = "Markdown (*.md)|*md";
            fileDialog.Title  = "Open Markdown file";
            fileDialog.RestoreDirectory = true;
            fileDialog.ShowDialog();
            return fileDialog.FileName;
        }

        /// <summary>
        /// Shows About Box
        /// </summary>
        private void ShowAboutBox()
        {
            using (AboutBox aboutBox = new AboutBox())
            {
                aboutBox.ShowDialog(this);
            }
        }
        #endregion

        /// <summary>
        /// Appends last saved filename to Main window's title
        /// </summary>
        private void RefreshTitle()
        {
            if (lastSavedFilename.Trim().Length > 0)
                this.Text = String.Format("{0} - {1}", lastSavedFilename, appName);
            else
                this.Text = appName;
        }

        /// <summary>
        /// Setter for the lastSavedFilePath and lastSavedFilename
        /// </summary>
        private void SetLastSavedFile(String filePath)
        {
            lastSavedFilePath = filePath;
            int startOfFileName = lastSavedFilePath.LastIndexOf("\\") + 1;
            int length = lastSavedFilePath.Length - startOfFileName;
            lastSavedFilename = lastSavedFilePath.Substring(startOfFileName, length);
        }
        
        /// <summary> 
        /// Opens file from filePath and puts it into markdown TextBox 
        /// </summary>
        /// <param name="filePath">File path to Markdown file</param
        private void OpenFile(String filePath)
        {
            markdownTextBox.Text = fileHandler.OpenFile(filePath);
            SetLastSavedFile(filePath);
            RefreshTitle();
        }

        /// <summary>
        /// Takes Markdown text and sends it to the fileHandler for saving.
        /// </summary>
        /// <param name="filePath">File path to save the Markdown file</param>
        private void SaveFile(String filePath)
        {
            if (filePath.Trim() == "") return;
            fileHandler.MarkdownText = markdownTextBox.Text;
            fileHandler.SaveMarkdown(filePath);
            SetLastSavedFile(filePath);
            RefreshTitle();
        }

        /// <summary>
        /// Takes the HTML from the preview and sends it to the 
        /// fileHandler for saving.
        /// </summary>
        /// <param name="filePath">File path to save the HTML file</param>
        private void ExportHtml(String filePath)
        {
            if (filePath.Trim() == "") return;
            fileHandler.HtmlText = markdownPreview.DocumentText;
            fileHandler.SaveHtml(filePath);
        }

        private DialogResult PromptUserToSave()
        {
            String promptMessage = 
                    String.Format("Do you want to save changes to {0}", lastSavedFilePath);
            return MessageBox.Show(
                    promptMessage, "Save Changes", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
        }

        private void NewMarkdownDocument()
        {
            if (PromptForUnsavedChanges())
            {
                SetLastSavedFile("");
                markdownTextChanged = false;
                RefreshTitle();
                Clear();
            }
        }
        private void SaveMarkdownDocument()
        {
            String filePath = lastSavedFilePath != "" ? lastSavedFilePath : SaveMarkdownDialog();
            SaveFile(filePath);
            markdownTextChanged = false;
        }

        private void OpenMarkdownDocument()
        {
            if (PromptForUnsavedChanges())
            {
                String openPath = OpenMarkdownDialog();
                OpenFile(openPath);
            }
        }

        /// <summary>
        /// Checks if there are any unsaved changes and prompts
        /// the user accordingly.
        /// </summary>
        /// <returns>Returns false if the user presses cancel</returns>
        private bool PromptForUnsavedChanges()
        {
            if (!markdownTextChanged) return true;
            DialogResult result = PromptUserToSave();
            if (result == DialogResult.Cancel) return false;
            if (result == DialogResult.Yes) SaveMarkdownDocument();
            return true;
        }

        /// <summary>
        /// Clears the MarkdownTextBox and MarkdownPreview
        /// </summary>
        private void Clear()
        {
            markdownTextBox.Text = "";
            markdownPreview.DocumentText = "";
        }
    }
}
