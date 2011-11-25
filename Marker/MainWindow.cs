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
        private MarkdownConverter m;

        public MainWindow()
        {
            InitializeComponent();
            autoSizeSplitContainer();
            autoSizeMarkdownTextbox();
            m = new MarkdownConverter();
            m.Font = "Segoe UI";
        }

        private void markdownTextBox_TextChanged(object sender, EventArgs e)
        {
            markdownPreview.DocumentText = m.convert(markdownTextBox.Text);
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
    }
}
