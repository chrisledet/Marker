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
            this.markdownPreview = new System.Windows.Forms.WebBrowser();
            this.markdownTextBox = new System.Windows.Forms.TextBox();
            this.splitContainer = new System.Windows.Forms.SplitContainer();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).BeginInit();
            this.splitContainer.Panel1.SuspendLayout();
            this.splitContainer.Panel2.SuspendLayout();
            this.splitContainer.SuspendLayout();
            this.SuspendLayout();
            // 
            // markdownPreview
            // 
            this.markdownPreview.AllowWebBrowserDrop = false;
            this.markdownPreview.Dock = System.Windows.Forms.DockStyle.Fill;
            this.markdownPreview.Location = new System.Drawing.Point(0, 0);
            this.markdownPreview.MinimumSize = new System.Drawing.Size(20, 20);
            this.markdownPreview.Name = "markdownPreview";
            this.markdownPreview.Size = new System.Drawing.Size(388, 529);
            this.markdownPreview.TabIndex = 0;
            // 
            // markdownTextBox
            // 
            this.markdownTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.markdownTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.markdownTextBox.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.markdownTextBox.Location = new System.Drawing.Point(0, 0);
            this.markdownTextBox.Margin = new System.Windows.Forms.Padding(5);
            this.markdownTextBox.Multiline = true;
            this.markdownTextBox.Name = "markdownTextBox";
            this.markdownTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.markdownTextBox.Size = new System.Drawing.Size(358, 529);
            this.markdownTextBox.TabIndex = 0;
            this.markdownTextBox.TextChanged += new System.EventHandler(this.markdownTextBox_TextChanged);
            // 
            // splitContainer
            // 
            this.splitContainer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitContainer.Dock = System.Windows.Forms.DockStyle.Top;
            this.splitContainer.Location = new System.Drawing.Point(0, 0);
            this.splitContainer.Margin = new System.Windows.Forms.Padding(5);
            this.splitContainer.Name = "splitContainer";
            // 
            // splitContainer.Panel1
            // 
            this.splitContainer.Panel1.Controls.Add(this.markdownTextBox);
            // 
            // splitContainer.Panel2
            // 
            this.splitContainer.Panel2.Controls.Add(this.markdownPreview);
            this.splitContainer.Size = new System.Drawing.Size(754, 531);
            this.splitContainer.SplitterDistance = 360;
            this.splitContainer.TabIndex = 1;
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(754, 531);
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

        private System.Windows.Forms.WebBrowser markdownPreview;
        private System.Windows.Forms.TextBox markdownTextBox;
        private System.Windows.Forms.SplitContainer splitContainer;
    }
}

