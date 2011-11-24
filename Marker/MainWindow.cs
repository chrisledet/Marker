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
        public MainWindow()
        {
            InitializeComponent();
        }

        private void markdownTextBox_TextChanged(object sender, EventArgs e)
        {
            markdownPreview.DocumentText =
                MarkdownConverter.convert(markdownTextBox.Text);
        }
    }
}
