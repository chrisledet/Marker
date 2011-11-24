namespace Marker
{
    partial class MainWindow
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.splitContainer = new System.Windows.Forms.SplitContainer();
            this.markdownTextBox = new System.Windows.Forms.TextBox();
            this.markdownPreview = new System.Windows.Forms.WebBrowser();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).BeginInit();
            this.splitContainer.Panel1.SuspendLayout();
            this.splitContainer.Panel2.SuspendLayout();
            this.splitContainer.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer
            // 
            this.splitContainer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitContainer.Location = new System.Drawing.Point(12, 12);
            this.splitContainer.Name = "splitContainer";
            // 
            // splitContainer.Panel1
            // 
            this.splitContainer.Panel1.Controls.Add(this.markdownTextBox);
            // 
            // splitContainer.Panel2
            // 
            this.splitContainer.Panel2.Controls.Add(this.markdownPreview);
            this.splitContainer.Size = new System.Drawing.Size(783, 546);
            this.splitContainer.SplitterDistance = 375;
            this.splitContainer.TabIndex = 1;
            // 
            // markdownTextBox
            // 
            this.markdownTextBox.Location = new System.Drawing.Point(-1, -1);
            this.markdownTextBox.Multiline = true;
            this.markdownTextBox.Name = "markdownTextBox";
            this.markdownTextBox.Size = new System.Drawing.Size(378, 547);
            this.markdownTextBox.TabIndex = 0;
            this.markdownTextBox.TextChanged += new System.EventHandler(this.markdownTextBox_TextChanged);
            // 
            // markdownPreview
            // 
            this.markdownPreview.AllowWebBrowserDrop = false;
            this.markdownPreview.Dock = System.Windows.Forms.DockStyle.Fill;
            this.markdownPreview.Location = new System.Drawing.Point(0, 0);
            this.markdownPreview.MinimumSize = new System.Drawing.Size(20, 20);
            this.markdownPreview.Name = "markdownPreview";
            this.markdownPreview.Size = new System.Drawing.Size(402, 544);
            this.markdownPreview.TabIndex = 0;
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(807, 570);
            this.Controls.Add(this.splitContainer);
            this.Name = "MainWindow";
            this.Text = "Marker";
            this.splitContainer.Panel1.ResumeLayout(false);
            this.splitContainer.Panel1.PerformLayout();
            this.splitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).EndInit();
            this.splitContainer.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer;
        private System.Windows.Forms.TextBox markdownTextBox;
        private System.Windows.Forms.WebBrowser markdownPreview;
    }
}

