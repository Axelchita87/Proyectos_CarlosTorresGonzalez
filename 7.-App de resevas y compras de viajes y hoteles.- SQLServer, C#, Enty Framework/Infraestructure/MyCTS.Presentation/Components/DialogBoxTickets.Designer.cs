namespace MyCTS.Presentation.Components
{
    partial class DialogBoxTickets
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        #region Dispose

        /// <summary>
        /// Clean up any resources being used.
        ///
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (components != null)
                {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
        }

        #endregion



        #region Windows Form Designer generated code
        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        ///
        private void InitializeComponent()
        {
            this.lblPrompt = new System.Windows.Forms.Label();
            this.btnOK = new System.Windows.Forms.Button();
            this.txtSolicitorName = new System.Windows.Forms.TextBox();
            this.lblSolicitorName = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblPrompt
            // 
            this.lblPrompt.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lblPrompt.BackColor = System.Drawing.Color.LightBlue;
            this.lblPrompt.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPrompt.Location = new System.Drawing.Point(12, 9);
            this.lblPrompt.Name = "lblPrompt";
            this.lblPrompt.Size = new System.Drawing.Size(374, 18);
            this.lblPrompt.TabIndex = 3;
            this.lblPrompt.Text = "6 de Recibido";
            // 
            // btnOK
            // 
            this.btnOK.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOK.Location = new System.Drawing.Point(286, 67);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(100, 23);
            this.btnOK.TabIndex = 1;
            this.btnOK.Text = "&Aceptar";
            this.btnOK.UseVisualStyleBackColor = false;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // txtSolicitorName
            // 
            this.txtSolicitorName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtSolicitorName.Location = new System.Drawing.Point(123, 41);
            this.txtSolicitorName.Name = "txtSolicitorName";
            this.txtSolicitorName.Size = new System.Drawing.Size(263, 20);
            this.txtSolicitorName.TabIndex = 0;
            // 
            // lblSolicitorName
            // 
            this.lblSolicitorName.AutoSize = true;
            this.lblSolicitorName.Location = new System.Drawing.Point(12, 41);
            this.lblSolicitorName.Name = "lblSolicitorName";
            this.lblSolicitorName.Size = new System.Drawing.Size(96, 13);
            this.lblSolicitorName.TabIndex = 4;
            this.lblSolicitorName.Text = "Nombre Solicitante";
            this.lblSolicitorName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // DialogBoxTickets
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.BackColor = System.Drawing.Color.LightBlue;
            this.ClientSize = new System.Drawing.Size(398, 96);
            this.Controls.Add(this.lblSolicitorName);
            this.Controls.Add(this.txtSolicitorName);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.lblPrompt);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DialogBoxTickets";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "::.MyCTS.::";
            this.Load += new System.EventHandler(this.DialogBoxTickets_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.DialogBoxTickets_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

      

        #endregion

        private System.Windows.Forms.Label lblSolicitorName;
    }
}