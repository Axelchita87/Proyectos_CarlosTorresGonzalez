namespace MyCTS.Presentation
{
    partial class ucSearch
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.wbContent = new System.Windows.Forms.WebBrowser();
            this.wbContent2 = new System.Windows.Forms.WebBrowser();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // wbContent
            // 
            this.wbContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.wbContent.Location = new System.Drawing.Point(0, 0);
            this.wbContent.MinimumSize = new System.Drawing.Size(20, 20);
            this.wbContent.Name = "wbContent";
            this.wbContent.ScrollBarsEnabled = false;
            this.wbContent.Size = new System.Drawing.Size(420, 690);
            this.wbContent.TabIndex = 0;
            this.wbContent.Url = new System.Uri("http://201.149.13.14:5498/CTSServices/Pages/Search.html", System.UriKind.Absolute);
            // 
            // wbContent2
            // 
            this.wbContent2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.wbContent2.Location = new System.Drawing.Point(0, 0);
            this.wbContent2.MinimumSize = new System.Drawing.Size(20, 20);
            this.wbContent2.Name = "wbContent2";
            this.wbContent2.ScrollBarsEnabled = false;
            this.wbContent2.Size = new System.Drawing.Size(420, 690);
            this.wbContent2.TabIndex = 1;
            this.wbContent2.Url = new System.Uri("http://201.149.13.14:5498/CTSServices/Pages/Search.html", System.UriKind.Absolute);
            this.wbContent2.Visible = false;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.wbContent);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(420, 690);
            this.panel1.TabIndex = 2;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.wbContent2);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(420, 690);
            this.panel2.TabIndex = 3;
            this.panel2.Visible = false;
            // 
            // ucSearch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "ucSearch";
            this.Size = new System.Drawing.Size(420, 690);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.WebBrowser wbContent;
        private System.Windows.Forms.WebBrowser wbContent2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
    }
}
