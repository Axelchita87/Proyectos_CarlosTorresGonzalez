namespace MyCTS.Presentation
{
    partial class frmLogin
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
            this.Label4 = new System.Windows.Forms.Label();
            this.btnStart = new System.Windows.Forms.Button();
            this.Label6 = new System.Windows.Forms.Label();
            this.LinkLabel1 = new System.Windows.Forms.LinkLabel();
            this.txtUserId = new MyCTS.Forms.UI.SmartTextBox();
            this.Panel1 = new System.Windows.Forms.Panel();
            this.txtSabrePass = new MyCTS.Forms.UI.SmartTextBox();
            this.Label3 = new System.Windows.Forms.Label();
            this.Label2 = new System.Windows.Forms.Label();
            this.txtPCC = new MyCTS.Forms.UI.SmartTextBox();
            this.Label1 = new System.Windows.Forms.Label();
            this.lblVersion = new System.Windows.Forms.Label();
            this.Panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // Label4
            // 
            this.Label4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(139)))), ((int)(((byte)(208)))));
            this.Label4.Dock = System.Windows.Forms.DockStyle.Top;
            this.Label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label4.ForeColor = System.Drawing.SystemColors.Window;
            this.Label4.Location = new System.Drawing.Point(0, 0);
            this.Label4.Name = "Label4";
            this.Label4.Size = new System.Drawing.Size(250, 23);
            this.Label4.TabIndex = 0;
            this.Label4.Text = " Inicio de sesión";
            this.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(118, 127);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(120, 23);
            this.btnStart.TabIndex = 4;
            this.btnStart.Text = "Iniciar sesión";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // Label6
            // 
            this.Label6.AutoSize = true;
            this.Label6.BackColor = System.Drawing.Color.Transparent;
            this.Label6.ForeColor = System.Drawing.Color.Gray;
            this.Label6.Location = new System.Drawing.Point(128, 512);
            this.Label6.Name = "Label6";
            this.Label6.Size = new System.Drawing.Size(411, 13);
            this.Label6.TabIndex = 0;
            this.Label6.Text = "Copyright © Corporate Travel Services, S.A. de C.V. Todos los Derechos Reservados" +
    "";
            // 
            // LinkLabel1
            // 
            this.LinkLabel1.AutoSize = true;
            this.LinkLabel1.BackColor = System.Drawing.Color.Transparent;
            this.LinkLabel1.Location = new System.Drawing.Point(539, 432);
            this.LinkLabel1.Name = "LinkLabel1";
            this.LinkLabel1.Size = new System.Drawing.Size(27, 13);
            this.LinkLabel1.TabIndex = 5;
            this.LinkLabel1.TabStop = true;
            this.LinkLabel1.Text = "Salir";
            this.LinkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LinkLabel1_LinkClicked);
            // 
            // txtUserId
            // 
            this.txtUserId.AllowBlankSpaces = true;
            this.txtUserId.BackColor = System.Drawing.Color.White;
            this.txtUserId.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtUserId.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.OnlyNumbers;
            this.txtUserId.CustomExpression = ".*";
            this.txtUserId.EnterColor = System.Drawing.Color.Empty;
            this.txtUserId.LeaveColor = System.Drawing.Color.Empty;
            this.txtUserId.Location = new System.Drawing.Point(118, 35);
            this.txtUserId.MaxLength = 5;
            this.txtUserId.Name = "txtUserId";
            this.txtUserId.Size = new System.Drawing.Size(120, 20);
            this.txtUserId.TabIndex = 1;
            this.txtUserId.KeyDown += new System.Windows.Forms.KeyEventHandler(this.enterControls_KeyDown);
            // 
            // Panel1
            // 
            this.Panel1.BackColor = System.Drawing.Color.Transparent;
            this.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Panel1.Controls.Add(this.btnStart);
            this.Panel1.Controls.Add(this.Label4);
            this.Panel1.Controls.Add(this.txtSabrePass);
            this.Panel1.Controls.Add(this.Label3);
            this.Panel1.Controls.Add(this.Label2);
            this.Panel1.Controls.Add(this.txtPCC);
            this.Panel1.Controls.Add(this.Label1);
            this.Panel1.Controls.Add(this.txtUserId);
            this.Panel1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Panel1.Location = new System.Drawing.Point(314, 184);
            this.Panel1.Name = "Panel1";
            this.Panel1.Size = new System.Drawing.Size(252, 181);
            this.Panel1.TabIndex = 0;
            // 
            // txtSabrePass
            // 
            this.txtSabrePass.AllowBlankSpaces = true;
            this.txtSabrePass.BackColor = System.Drawing.Color.White;
            this.txtSabrePass.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtSabrePass.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.AnyCharacter;
            this.txtSabrePass.CustomExpression = ".*";
            this.txtSabrePass.EnterColor = System.Drawing.Color.Empty;
            this.txtSabrePass.LeaveColor = System.Drawing.Color.Empty;
            this.txtSabrePass.Location = new System.Drawing.Point(118, 63);
            this.txtSabrePass.MaxLength = 20;
            this.txtSabrePass.Name = "txtSabrePass";
            this.txtSabrePass.Size = new System.Drawing.Size(120, 20);
            this.txtSabrePass.TabIndex = 2;
            this.txtSabrePass.UseSystemPasswordChar = true;
            this.txtSabrePass.KeyDown += new System.Windows.Forms.KeyEventHandler(this.enterControls_KeyDown);
            // 
            // Label3
            // 
            this.Label3.AutoSize = true;
            this.Label3.BackColor = System.Drawing.Color.Transparent;
            this.Label3.ForeColor = System.Drawing.Color.Black;
            this.Label3.Location = new System.Drawing.Point(79, 94);
            this.Label3.Name = "Label3";
            this.Label3.Size = new System.Drawing.Size(31, 13);
            this.Label3.TabIndex = 0;
            this.Label3.Text = "PCC:";
            // 
            // Label2
            // 
            this.Label2.AutoSize = true;
            this.Label2.BackColor = System.Drawing.Color.Transparent;
            this.Label2.ForeColor = System.Drawing.Color.Black;
            this.Label2.Location = new System.Drawing.Point(56, 66);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(56, 13);
            this.Label2.TabIndex = 0;
            this.Label2.Text = "Password:";
            // 
            // txtPCC
            // 
            this.txtPCC.AllowBlankSpaces = true;
            this.txtPCC.BackColor = System.Drawing.Color.White;
            this.txtPCC.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtPCC.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.AnyCharacter;
            this.txtPCC.CustomExpression = ".*";
            this.txtPCC.EnterColor = System.Drawing.Color.Empty;
            this.txtPCC.LeaveColor = System.Drawing.Color.Empty;
            this.txtPCC.Location = new System.Drawing.Point(118, 91);
            this.txtPCC.MaxLength = 6;
            this.txtPCC.Name = "txtPCC";
            this.txtPCC.Size = new System.Drawing.Size(120, 20);
            this.txtPCC.TabIndex = 3;
            this.txtPCC.KeyDown += new System.Windows.Forms.KeyEventHandler(this.enterControls_KeyDown);
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.BackColor = System.Drawing.Color.Transparent;
            this.Label1.ForeColor = System.Drawing.Color.Black;
            this.Label1.Location = new System.Drawing.Point(75, 38);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(35, 13);
            this.Label1.TabIndex = 0;
            this.Label1.Text = "Firma:";
            // 
            // lblVersion
            // 
            this.lblVersion.AutoSize = true;
            this.lblVersion.BackColor = System.Drawing.Color.Transparent;
            this.lblVersion.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVersion.ForeColor = System.Drawing.Color.White;
            this.lblVersion.Location = new System.Drawing.Point(225, 475);
            this.lblVersion.Name = "lblVersion";
            this.lblVersion.Size = new System.Drawing.Size(193, 13);
            this.lblVersion.TabIndex = 6;
            this.lblVersion.Text = "Versión: 1.0.0.0 - Junio 02, 2009";
            // 
            // frmLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::MyCTS.Presentation.Properties.Resources.Inicio4_MyCTS2;
            this.ClientSize = new System.Drawing.Size(658, 534);
            this.Controls.Add(this.Panel1);
            this.Controls.Add(this.lblVersion);
            this.Controls.Add(this.Label6);
            this.Controls.Add(this.LinkLabel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "frmLogin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MyCTS2-Corporate Travel Services";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmLogin_FormClosing);
            this.Load += new System.EventHandler(this.frmLogin_Load);
            this.Panel1.ResumeLayout(false);
            this.Panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

      
        #endregion

        internal System.Windows.Forms.Label Label4;
        internal System.Windows.Forms.Button btnStart;
        internal System.Windows.Forms.Label Label6;
        internal System.Windows.Forms.LinkLabel LinkLabel1;
        internal MyCTS.Forms.UI.SmartTextBox txtUserId;
        internal System.Windows.Forms.Panel Panel1;
        internal MyCTS.Forms.UI.SmartTextBox txtSabrePass;
        internal System.Windows.Forms.Label Label3;
        internal System.Windows.Forms.Label Label2;
        internal MyCTS.Forms.UI.SmartTextBox txtPCC;
        internal System.Windows.Forms.Label Label1;
        private System.Windows.Forms.Label lblVersion;
    }
}