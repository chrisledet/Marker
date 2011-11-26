﻿using System;
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
        private MarkdownConverter m;
        private Exporter exporter;
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

            autoSizeSplitContainer();
            autoSizeMarkdownTextbox();

            appName = "Marker";

            m = new MarkdownConverter();
            m.Font = "Segoe UI";

            exporter = new Exporter();

            lastSavedFilename = "";
            lastSavedFilePath = "";
        }

        private void markdownTextBox_TextChanged(object sender, EventArgs e)
        {
            markdownPreview.DocumentText = m.convert(markdownTextBox.Text);
        }

        private void openMenuItem_Click(object sender, EventArgs e)
        {
            String openPath = openMarkdownDialog();
            openFile(openPath);
        }
        
        private void saveMenuItem_Click(object sender, EventArgs e)
        {
            String savePath = lastSavedFilePath != "" ? lastSavedFilePath : saveMarkdownDialog();

            if (savePath != "")
            {
                exporter.MarkdownText = markdownTextBox.Text;
                exporter.saveMarkdown(savePath);
                setLastSavedFile(savePath);
                refreshTitle();
            }
        }

        private void exitMenuItem_Click(object sender, EventArgs e)
        {
            #region TODO
            /*
             *  1) check if user wants to save markdown
             */
            #endregion

            Application.Exit();
        }

        private void autoSizeSplitContainer()
        {
            splitContainer.AutoSize = true;
            splitContainer.Dock = DockStyle.Fill;
            splitContainer.Parent = this;
            splitContainer.Margin = new Padding(5, 5, 5, 5);
        }

        private void autoSizeMarkdownTextbox()
        {
            markdownTextBox.Dock = DockStyle.Fill;
            markdownTextBox.Parent = splitContainer.Panel1;
        }

        /*
         * displays a save dialog and returns the file path the user selects
         */
        private String saveMarkdownDialog()
        {
            SaveFileDialog saveDialog = new SaveFileDialog();
            saveDialog.Filter = "Markdown (*.md)|*.md";
            saveDialog.Title  = "Save Markdown File";
            saveDialog.ShowDialog();
            return saveDialog.FileName;
        }

        private String openMarkdownDialog()
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Filter = "Markdown (*.md)|*md";
            fileDialog.Title  = "Open Markdown file";
            fileDialog.RestoreDirectory = true;
            fileDialog.ShowDialog();
            return fileDialog.FileName;
        }

        /*
         *  appends last saved filename to Main window's title
         */
        private void refreshTitle()
        {
            this.Text = String.Format("{0} - {1}", lastSavedFilename, appName);
        }

        /*
         * setter for the lastSavedFilePath and lastSavedFilename
         */
        private void setLastSavedFile(String filePath)
        {
            lastSavedFilePath = filePath;

            int startOfFileName = lastSavedFilePath.LastIndexOf("\\") + 1;
            lastSavedFilename = 
                lastSavedFilePath.Substring(startOfFileName, lastSavedFilePath.Length - startOfFileName);

            Console.WriteLine("Saving to {0}", lastSavedFilePath);
            Console.WriteLine("Saved file: {0}", lastSavedFilename);
        }

        /*
         * opens file from filePath and puts it into markdown TextBox
         */
        private void openFile(String filePath)
        {
            markdownTextBox.Text = exporter.openFile(filePath);
            setLastSavedFile(filePath);
            refreshTitle();
        }

    }
}
