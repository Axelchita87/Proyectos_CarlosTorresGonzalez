namespace MyCTS.Presentation
{
    partial class ucOSIMessageFOID
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
            this.lblByPassportNumbre = new System.Windows.Forms.Label();
            this.lblEmisorCountry = new System.Windows.Forms.Label();
            this.txtEmisorCountry = new MyCTS.Forms.UI.SmartTextBox();
            this.txtPassport = new MyCTS.Forms.UI.SmartTextBox();
            this.lblPassport = new System.Windows.Forms.Label();
            this.lblByCreditCard = new System.Windows.Forms.Label();
            this.lblEmisorBank = new System.Windows.Forms.Label();
            this.txtEmisorBank = new MyCTS.Forms.UI.SmartTextBox();
            this.lblCardNumber = new System.Windows.Forms.Label();
            this.txtCardNumber = new MyCTS.Forms.UI.SmartTextBox();
            this.btnAccept = new System.Windows.Forms.Button();
            this.lblPaxNumber = new System.Windows.Forms.Label();
            this.txtPaxNumber = new MyCTS.Forms.UI.SmartTextBox();
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
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Mensaje OSI: FOID";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblByPassportNumbre
            // 
            this.lblByPassportNumbre.AutoSize = true;
            this.lblByPassportNumbre.ForeColor = System.Drawing.Color.Blue;
            this.lblByPassportNumbre.Location = new System.Drawing.Point(18, 48);
            this.lblByPassportNumbre.Name = "lblByPassportNumbre";
            this.lblByPassportNumbre.Size = new System.Drawing.Size(129, 13);
            this.lblByPassportNumbre.TabIndex = 0;
            this.lblByPassportNumbre.Text = "Por Número de Pasaporte";
            // 
            // lblEmisorCountry
            // 
            this.lblEmisorCountry.AutoSize = true;
            this.lblEmisorCountry.ForeColor = System.Drawing.Color.Black;
            this.lblEmisorCountry.Location = new System.Drawing.Point(18, 83);
            this.lblEmisorCountry.Name = "lblEmisorCountry";
            this.lblEmisorCountry.Size = new System.Drawing.Size(134, 13);
            this.lblEmisorCountry.TabIndex = 0;
            this.lblEmisorCountry.Text = "País Emisor del Pasaporte:";
            // 
            // txtEmisorCountry
            // 
            this.txtEmisorCountry.AllowBlankSpaces = false;
            this.txtEmisorCountry.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtEmisorCountry.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.OnlyLetters;
            this.txtEmisorCountry.CustomExpression = ".*";
            this.txtEmisorCountry.EnterColor = System.Drawing.Color.Empty;
            this.txtEmisorCountry.LeaveColor = System.Drawing.Color.Empty;
            this.txtEmisorCountry.Location = new System.Drawing.Point(168, 80);
            this.txtEmisorCountry.MaxLength = 2;
            this.txtEmisorCountry.Name = "txtEmisorCountry";
            this.txtEmisorCountry.Size = new System.Drawing.Size(25, 20);
            this.txtEmisorCountry.TabIndex = 1;
            this.txtEmisorCountry.TextChanged += new System.EventHandler(this.txtControls_TextChanged);
            this.txtEmisorCountry.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // txtPassport
            // 
            this.txtPassport.AllowBlankSpaces = false;
            this.txtPassport.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtPassport.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.OnlyNumbers;
            this.txtPassport.CustomExpression = ".*";
            this.txtPassport.EnterColor = System.Drawing.Color.Empty;
            this.txtPassport.LeaveColor = System.Drawing.Color.Empty;
            this.txtPassport.Location = new System.Drawing.Point(168, 107);
            this.txtPassport.MaxLength = 16;
            this.txtPassport.Name = "txtPassport";
            this.txtPassport.Size = new System.Drawing.Size(181, 20);
            this.txtPassport.TabIndex = 2;
            this.txtPassport.TextChanged += new System.EventHandler(this.txtControls_TextChanged);
            this.txtPassport.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // lblPassport
            // 
            this.lblPassport.AutoSize = true;
            this.lblPassport.Location = new System.Drawing.Point(18, 110);
            this.lblPassport.Name = "lblPassport";
            this.lblPassport.Size = new System.Drawing.Size(113, 13);
            this.lblPassport.TabIndex = 0;
            this.lblPassport.Text = "Número de Pasaporte:";
            // 
            // lblByCreditCard
            // 
            this.lblByCreditCard.AutoSize = true;
            this.lblByCreditCard.ForeColor = System.Drawing.Color.Blue;
            this.lblByCreditCard.Location = new System.Drawing.Point(18, 156);
            this.lblByCreditCard.Name = "lblByCreditCard";
            this.lblByCreditCard.Size = new System.Drawing.Size(114, 13);
            this.lblByCreditCard.TabIndex = 0;
            this.lblByCreditCard.Text = "Por Número de Tarjeta";
            // 
            // lblEmisorBank
            // 
            this.lblEmisorBank.AutoSize = true;
            this.lblEmisorBank.ForeColor = System.Drawing.Color.Black;
            this.lblEmisorBank.Location = new System.Drawing.Point(18, 190);
            this.lblEmisorBank.Name = "lblEmisorBank";
            this.lblEmisorBank.Size = new System.Drawing.Size(75, 13);
            this.lblEmisorBank.TabIndex = 0;
            this.lblEmisorBank.Text = "Banco Emisor:";
            // 
            // txtEmisorBank
            // 
            this.txtEmisorBank.AllowBlankSpaces = false;
            this.txtEmisorBank.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtEmisorBank.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.OnlyLetters;
            this.txtEmisorBank.CustomExpression = ".*";
            this.txtEmisorBank.EnterColor = System.Drawing.Color.Empty;
            this.txtEmisorBank.LeaveColor = System.Drawing.Color.Empty;
            this.txtEmisorBank.Location = new System.Drawing.Point(168, 187);
            this.txtEmisorBank.MaxLength = 2;
            this.txtEmisorBank.Name = "txtEmisorBank";
            this.txtEmisorBank.Size = new System.Drawing.Size(25, 20);
            this.txtEmisorBank.TabIndex = 3;
            this.txtEmisorBank.TextChanged += new System.EventHandler(this.txtControls_TextChanged);
            this.txtEmisorBank.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // lblCardNumber
            // 
            this.lblCardNumber.AutoSize = true;
            this.lblCardNumber.ForeColor = System.Drawing.Color.Black;
            this.lblCardNumber.Location = new System.Drawing.Point(18, 219);
            this.lblCardNumber.Name = "lblCardNumber";
            this.lblCardNumber.Size = new System.Drawing.Size(98, 13);
            this.lblCardNumber.TabIndex = 0;
            this.lblCardNumber.Text = "Número de Tarjeta:";
            // 
            // txtCardNumber
            // 
            this.txtCardNumber.AllowBlankSpaces = false;
            this.txtCardNumber.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtCardNumber.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.OnlyNumbers;
            this.txtCardNumber.CustomExpression = ".*";
            this.txtCardNumber.EnterColor = System.Drawing.Color.Empty;
            this.txtCardNumber.LeaveColor = System.Drawing.Color.Empty;
            this.txtCardNumber.Location = new System.Drawing.Point(168, 216);
            this.txtCardNumber.MaxLength = 16;
            this.txtCardNumber.Name = "txtCardNumber";
            this.txtCardNumber.Size = new System.Drawing.Size(181, 20);
            this.txtCardNumber.TabIndex = 4;
            this.txtCardNumber.TextChanged += new System.EventHandler(this.txtControls_TextChanged);
            this.txtCardNumber.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // btnAccept
            // 
            this.btnAccept.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnAccept.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAccept.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAccept.Location = new System.Drawing.Point(277, 311);
            this.btnAccept.Name = "btnAccept";
            this.btnAccept.Size = new System.Drawing.Size(100, 23);
            this.btnAccept.TabIndex = 6;
            this.btnAccept.Text = "Aceptar";
            this.btnAccept.UseVisualStyleBackColor = false;
            this.btnAccept.Click += new System.EventHandler(this.btnAccept_Click);
            // 
            // lblPaxNumber
            // 
            this.lblPaxNumber.AutoSize = true;
            this.lblPaxNumber.ForeColor = System.Drawing.Color.DarkCyan;
            this.lblPaxNumber.Location = new System.Drawing.Point(18, 264);
            this.lblPaxNumber.Name = "lblPaxNumber";
            this.lblPaxNumber.Size = new System.Drawing.Size(68, 13);
            this.lblPaxNumber.TabIndex = 0;
            this.lblPaxNumber.Text = "Num de Pax:";
            // 
            // txtPaxNumber
            // 
            this.txtPaxNumber.AllowBlankSpaces = false;
            this.txtPaxNumber.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtPaxNumber.CharsIncluded = new char[] {
        '.'};
            this.txtPaxNumber.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.OnlyNumbers;
            this.txtPaxNumber.CustomExpression = ".*";
            this.txtPaxNumber.EnterColor = System.Drawing.Color.Empty;
            this.txtPaxNumber.LeaveColor = System.Drawing.Color.Empty;
            this.txtPaxNumber.Location = new System.Drawing.Point(168, 261);
            this.txtPaxNumber.MaxLength = 4;
            this.txtPaxNumber.Name = "txtPaxNumber";
            this.txtPaxNumber.Size = new System.Drawing.Size(35, 20);
            this.txtPaxNumber.TabIndex = 5;
            this.txtPaxNumber.TextChanged += new System.EventHandler(this.txtControls_TextChanged);
            this.txtPaxNumber.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // ucOSIMessageFOID
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.txtPaxNumber);
            this.Controls.Add(this.lblPaxNumber);
            this.Controls.Add(this.btnAccept);
            this.Controls.Add(this.txtCardNumber);
            this.Controls.Add(this.lblCardNumber);
            this.Controls.Add(this.txtEmisorBank);
            this.Controls.Add(this.lblEmisorBank);
            this.Controls.Add(this.lblByCreditCard);
            this.Controls.Add(this.txtPassport);
            this.Controls.Add(this.lblPassport);
            this.Controls.Add(this.txtEmisorCountry);
            this.Controls.Add(this.lblEmisorCountry);
            this.Controls.Add(this.lblByPassportNumbre);
            this.Controls.Add(this.lblTitle);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "ucOSIMessageFOID";
            this.Size = new System.Drawing.Size(411, 580);
            this.Load += new System.EventHandler(this.ucOSIMessageFOID_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblByPassportNumbre;
        private System.Windows.Forms.Label lblEmisorCountry;
        private MyCTS.Forms.UI.SmartTextBox txtEmisorCountry;
        private MyCTS.Forms.UI.SmartTextBox txtPassport;
        private System.Windows.Forms.Label lblPassport;
        private System.Windows.Forms.Label lblByCreditCard;
        private System.Windows.Forms.Label lblEmisorBank;
        private MyCTS.Forms.UI.SmartTextBox txtEmisorBank;
        private System.Windows.Forms.Label lblCardNumber;
        private MyCTS.Forms.UI.SmartTextBox txtCardNumber;
        private System.Windows.Forms.Button btnAccept;
        private System.Windows.Forms.Label lblPaxNumber;
        private MyCTS.Forms.UI.SmartTextBox txtPaxNumber;
    }
}
