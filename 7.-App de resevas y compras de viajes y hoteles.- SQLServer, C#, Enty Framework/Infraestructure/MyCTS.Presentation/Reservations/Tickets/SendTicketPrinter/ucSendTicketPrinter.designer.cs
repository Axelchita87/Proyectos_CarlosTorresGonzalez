namespace MyCTS.Presentation
{
    partial class ucSendTicketPrinter
    {
        /// <summary> 
        /// Variable del diseñador requerida.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Limpiar los recursos que se estén utilizando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben eliminar; false en caso contrario, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de componentes

        /// <summary> 
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido del método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblTitle = new System.Windows.Forms.Label();
            this.txtNumberTicket = new MyCTS.Forms.UI.SmartTextBox();
            this.lblNumberTicket = new System.Windows.Forms.Label();
            this.txtCCMail = new MyCTS.Forms.UI.SmartTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblInfo = new System.Windows.Forms.Label();
            this.btnAccept = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(139)))), ((int)(((byte)(208)))));
            this.lblTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(0, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(411, 15);
            this.lblTitle.TabIndex = 3;
            this.lblTitle.Text = "Regenerar Electronic Ticket";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // txtNumberTicket
            // 
            this.txtNumberTicket.AllowBlankSpaces = false;
            this.txtNumberTicket.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtNumberTicket.CharsIncluded = new char[0];
            this.txtNumberTicket.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.OnlyNumbers;
            this.txtNumberTicket.CustomExpression = ".*";
            this.txtNumberTicket.EnterColor = System.Drawing.Color.Empty;
            this.txtNumberTicket.LeaveColor = System.Drawing.Color.Empty;
            this.txtNumberTicket.Location = new System.Drawing.Point(126, 97);
            this.txtNumberTicket.MaxLength = 13;
            this.txtNumberTicket.Name = "txtNumberTicket";
            this.txtNumberTicket.Size = new System.Drawing.Size(142, 20);
            this.txtNumberTicket.TabIndex = 1;
            this.txtNumberTicket.TextChanged += new System.EventHandler(this.txtNumberTicket_TextChanged);
            this.txtNumberTicket.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // lblNumberTicket
            // 
            this.lblNumberTicket.AutoSize = true;
            this.lblNumberTicket.Location = new System.Drawing.Point(25, 100);
            this.lblNumberTicket.Name = "lblNumberTicket";
            this.lblNumberTicket.Size = new System.Drawing.Size(95, 13);
            this.lblNumberTicket.TabIndex = 4;
            this.lblNumberTicket.Text = "Número de Boleto:";
            // 
            // txtCCMail
            // 
            this.txtCCMail.AllowBlankSpaces = false;
            this.txtCCMail.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtCCMail.CharsIncluded = new char[0];
            this.txtCCMail.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.AnyCharacter;
            this.txtCCMail.CustomExpression = ".*";
            this.txtCCMail.EnterColor = System.Drawing.Color.Empty;
            this.txtCCMail.LeaveColor = System.Drawing.Color.Empty;
            this.txtCCMail.Location = new System.Drawing.Point(126, 175);
            this.txtCCMail.MaxLength = 200;
            this.txtCCMail.Name = "txtCCMail";
            this.txtCCMail.Size = new System.Drawing.Size(247, 20);
            this.txtCCMail.TabIndex = 2;
            this.txtCCMail.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.DarkCyan;
            this.label1.Location = new System.Drawing.Point(86, 178);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(30, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "CC...";
            // 
            // lblInfo
            // 
            this.lblInfo.Location = new System.Drawing.Point(34, 42);
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Size = new System.Drawing.Size(360, 29);
            this.lblInfo.TabIndex = 6;
            this.lblInfo.Text = "Los documentos serán enviados a la dirección de correo de quien solicite el servi" +
                "cio";
            // 
            // btnAccept
            // 
            this.btnAccept.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnAccept.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAccept.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAccept.Location = new System.Drawing.Point(273, 220);
            this.btnAccept.Name = "btnAccept";
            this.btnAccept.Size = new System.Drawing.Size(100, 23);
            this.btnAccept.TabIndex = 7;
            this.btnAccept.Text = "Aceptar";
            this.btnAccept.UseVisualStyleBackColor = false;
            this.btnAccept.Click += new System.EventHandler(this.btnAccept_Click);
            // 
            // label2
            // 
            this.label2.ForeColor = System.Drawing.Color.DarkCyan;
            this.label2.Location = new System.Drawing.Point(34, 139);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(339, 28);
            this.label2.TabIndex = 8;
            this.label2.Text = "Ingrese dirección de correo adicional para el envío de los documentos si así lo r" +
                "equiere";
            // 
            // ucSendTicketPrinter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnAccept);
            this.Controls.Add(this.lblInfo);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblNumberTicket);
            this.Controls.Add(this.txtCCMail);
            this.Controls.Add(this.txtNumberTicket);
            this.Controls.Add(this.lblTitle);
            this.Name = "ucSendTicketPrinter";
            this.Size = new System.Drawing.Size(411, 580);
            this.Load += new System.EventHandler(this.ucSendTicketPrinter_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.Label lblTitle;
        private MyCTS.Forms.UI.SmartTextBox txtNumberTicket;
        private System.Windows.Forms.Label lblNumberTicket;
        private MyCTS.Forms.UI.SmartTextBox txtCCMail;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblInfo;
        private System.Windows.Forms.Button btnAccept;
        private System.Windows.Forms.Label label2;
    }
}
