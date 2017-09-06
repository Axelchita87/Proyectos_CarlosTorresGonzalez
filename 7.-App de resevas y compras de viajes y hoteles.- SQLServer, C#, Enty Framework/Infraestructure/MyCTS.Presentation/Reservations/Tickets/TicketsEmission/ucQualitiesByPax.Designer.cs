namespace MyCTS.Presentation
{
    partial class ucQualitiesByPax
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
            this.lblConfirm = new System.Windows.Forms.Label();
            this.rdoNo = new System.Windows.Forms.RadioButton();
            this.rdoYes = new System.Windows.Forms.RadioButton();
            this.btnAccept = new System.Windows.Forms.Button();
            this.txtName1 = new MyCTS.Forms.UI.SmartTextBox();
            this.lbl8 = new System.Windows.Forms.Label();
            this.txtName2 = new MyCTS.Forms.UI.SmartTextBox();
            this.lbl9 = new System.Windows.Forms.Label();
            this.txtName3 = new MyCTS.Forms.UI.SmartTextBox();
            this.txtName4 = new MyCTS.Forms.UI.SmartTextBox();
            this.lblNumberPassanger = new System.Windows.Forms.Label();
            this.chkCTS = new System.Windows.Forms.CheckBox();
            this.lblCard = new System.Windows.Forms.Label();
            this.chkClient = new System.Windows.Forms.CheckBox();
            this.pnlCreditCardType = new System.Windows.Forms.Panel();
            this.lbl10 = new System.Windows.Forms.Label();
            this.txtDescription1 = new MyCTS.Forms.UI.SmartTextBox();
            this.txtDescription2 = new MyCTS.Forms.UI.SmartTextBox();
            this.lblDescription = new System.Windows.Forms.Label();
            this.pnlCreditCardType.SuspendLayout();
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
            this.lblTitle.TabIndex = 1;
            this.lblTitle.Text = "Emisión de Boleto";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblConfirm
            // 
            this.lblConfirm.AutoSize = true;
            this.lblConfirm.Location = new System.Drawing.Point(12, 30);
            this.lblConfirm.Name = "lblConfirm";
            this.lblConfirm.Size = new System.Drawing.Size(194, 13);
            this.lblConfirm.TabIndex = 2;
            this.lblConfirm.Text = "¿Emitir Boleto para todos los pasajeros?";
            // 
            // rdoNo
            // 
            this.rdoNo.AutoSize = true;
            this.rdoNo.Location = new System.Drawing.Point(101, 57);
            this.rdoNo.Name = "rdoNo";
            this.rdoNo.Size = new System.Drawing.Size(39, 17);
            this.rdoNo.TabIndex = 2;
            this.rdoNo.TabStop = true;
            this.rdoNo.Text = "No";
            this.rdoNo.UseVisualStyleBackColor = true;
            this.rdoNo.CheckedChanged += new System.EventHandler(this.rdoNo_CheckedChanged);
            this.rdoNo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // rdoYes
            // 
            this.rdoYes.AutoSize = true;
            this.rdoYes.Location = new System.Drawing.Point(41, 57);
            this.rdoYes.Name = "rdoYes";
            this.rdoYes.Size = new System.Drawing.Size(34, 17);
            this.rdoYes.TabIndex = 1;
            this.rdoYes.TabStop = true;
            this.rdoYes.Text = "Si";
            this.rdoYes.UseVisualStyleBackColor = true;
            this.rdoYes.CheckedChanged += new System.EventHandler(this.rdoYes_CheckedChanged);
            this.rdoYes.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // btnAccept
            // 
            this.btnAccept.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnAccept.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAccept.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAccept.Location = new System.Drawing.Point(286, 293);
            this.btnAccept.Name = "btnAccept";
            this.btnAccept.Size = new System.Drawing.Size(100, 23);
            this.btnAccept.TabIndex = 10;
            this.btnAccept.Text = "Aceptar";
            this.btnAccept.UseVisualStyleBackColor = false;
            this.btnAccept.Click += new System.EventHandler(this.btnAccept_Click);
            // 
            // txtName1
            // 
            this.txtName1.AllowBlankSpaces = false;
            this.txtName1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtName1.CharsIncluded = new char[] {
        '.'};
            this.txtName1.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.OnlyNumbers;
            this.txtName1.CustomExpression = ".*";
            this.txtName1.EnterColor = System.Drawing.Color.Empty;
            this.txtName1.LeaveColor = System.Drawing.Color.Empty;
            this.txtName1.Location = new System.Drawing.Point(170, 89);
            this.txtName1.MaxLength = 4;
            this.txtName1.Name = "txtName1";
            this.txtName1.Size = new System.Drawing.Size(35, 20);
            this.txtName1.TabIndex = 3;
            this.txtName1.Visible = false;
            this.txtName1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // lbl8
            // 
            this.lbl8.AutoSize = true;
            this.lbl8.Location = new System.Drawing.Point(208, 92);
            this.lbl8.Name = "lbl8";
            this.lbl8.Size = new System.Drawing.Size(10, 13);
            this.lbl8.TabIndex = 84;
            this.lbl8.Text = "-";
            this.lbl8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl8.Visible = false;
            // 
            // txtName2
            // 
            this.txtName2.AllowBlankSpaces = false;
            this.txtName2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtName2.CharsIncluded = new char[] {
        '.'};
            this.txtName2.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.OnlyNumbers;
            this.txtName2.CustomExpression = ".*";
            this.txtName2.EnterColor = System.Drawing.Color.Empty;
            this.txtName2.LeaveColor = System.Drawing.Color.Empty;
            this.txtName2.Location = new System.Drawing.Point(224, 89);
            this.txtName2.MaxLength = 4;
            this.txtName2.Name = "txtName2";
            this.txtName2.Size = new System.Drawing.Size(35, 20);
            this.txtName2.TabIndex = 4;
            this.txtName2.Visible = false;
            this.txtName2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // lbl9
            // 
            this.lbl9.AutoSize = true;
            this.lbl9.Location = new System.Drawing.Point(267, 92);
            this.lbl9.Name = "lbl9";
            this.lbl9.Size = new System.Drawing.Size(12, 13);
            this.lbl9.TabIndex = 86;
            this.lbl9.Text = "/";
            this.lbl9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl9.Visible = false;
            // 
            // txtName3
            // 
            this.txtName3.AllowBlankSpaces = false;
            this.txtName3.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtName3.CharsIncluded = new char[] {
        '.'};
            this.txtName3.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.OnlyNumbers;
            this.txtName3.CustomExpression = ".*";
            this.txtName3.EnterColor = System.Drawing.Color.Empty;
            this.txtName3.LeaveColor = System.Drawing.Color.Empty;
            this.txtName3.Location = new System.Drawing.Point(286, 89);
            this.txtName3.MaxLength = 4;
            this.txtName3.Name = "txtName3";
            this.txtName3.Size = new System.Drawing.Size(34, 20);
            this.txtName3.TabIndex = 5;
            this.txtName3.Visible = false;
            this.txtName3.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // txtName4
            // 
            this.txtName4.AllowBlankSpaces = false;
            this.txtName4.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtName4.CharsIncluded = new char[] {
        '.'};
            this.txtName4.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.OnlyNumbers;
            this.txtName4.CustomExpression = ".*";
            this.txtName4.EnterColor = System.Drawing.Color.Empty;
            this.txtName4.LeaveColor = System.Drawing.Color.Empty;
            this.txtName4.Location = new System.Drawing.Point(343, 89);
            this.txtName4.MaxLength = 4;
            this.txtName4.Name = "txtName4";
            this.txtName4.Size = new System.Drawing.Size(35, 20);
            this.txtName4.TabIndex = 6;
            this.txtName4.Visible = false;
            this.txtName4.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // lblNumberPassanger
            // 
            this.lblNumberPassanger.AutoSize = true;
            this.lblNumberPassanger.ForeColor = System.Drawing.Color.Black;
            this.lblNumberPassanger.Location = new System.Drawing.Point(12, 92);
            this.lblNumberPassanger.Name = "lblNumberPassanger";
            this.lblNumberPassanger.Size = new System.Drawing.Size(143, 13);
            this.lblNumberPassanger.TabIndex = 87;
            this.lblNumberPassanger.Text = "Indique número de pasajeros";
            this.lblNumberPassanger.Visible = false;
            // 
            // chkCTS
            // 
            this.chkCTS.AutoSize = true;
            this.chkCTS.Location = new System.Drawing.Point(305, 21);
            this.chkCTS.Name = "chkCTS";
            this.chkCTS.Size = new System.Drawing.Size(47, 17);
            this.chkCTS.TabIndex = 9;
            this.chkCTS.Text = "CTS";
            this.chkCTS.UseVisualStyleBackColor = true;
            this.chkCTS.CheckedChanged += new System.EventHandler(this.CreditCardType_CheckedChanged);
            // 
            // lblCard
            // 
            this.lblCard.AutoSize = true;
            this.lblCard.ForeColor = System.Drawing.Color.DarkCyan;
            this.lblCard.Location = new System.Drawing.Point(9, 21);
            this.lblCard.Name = "lblCard";
            this.lblCard.Size = new System.Drawing.Size(208, 13);
            this.lblCard.TabIndex = 0;
            this.lblCard.Text = "Forma de Pago para Tarjeta de Credito de:";
            // 
            // chkClient
            // 
            this.chkClient.AutoSize = true;
            this.chkClient.Location = new System.Drawing.Point(228, 21);
            this.chkClient.Name = "chkClient";
            this.chkClient.Size = new System.Drawing.Size(71, 17);
            this.chkClient.TabIndex = 8;
            this.chkClient.Text = "CLIENTE";
            this.chkClient.UseVisualStyleBackColor = true;
            this.chkClient.CheckedChanged += new System.EventHandler(this.CreditCardType_CheckedChanged);
            // 
            // pnlCreditCardType
            // 
            this.pnlCreditCardType.Controls.Add(this.chkClient);
            this.pnlCreditCardType.Controls.Add(this.lblCard);
            this.pnlCreditCardType.Controls.Add(this.chkCTS);
            this.pnlCreditCardType.Location = new System.Drawing.Point(3, 115);
            this.pnlCreditCardType.Name = "pnlCreditCardType";
            this.pnlCreditCardType.Size = new System.Drawing.Size(363, 64);
            this.pnlCreditCardType.TabIndex = 7;
            this.pnlCreditCardType.TabStop = true;
            // 
            // lbl10
            // 
            this.lbl10.AutoSize = true;
            this.lbl10.Location = new System.Drawing.Point(327, 92);
            this.lbl10.Name = "lbl10";
            this.lbl10.Size = new System.Drawing.Size(12, 13);
            this.lbl10.TabIndex = 0;
            this.lbl10.Text = "/";
            this.lbl10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl10.Visible = false;
            // 
            // txtDescription1
            // 
            this.txtDescription1.AllowBlankSpaces = true;
            this.txtDescription1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtDescription1.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.AnyCharacter;
            this.txtDescription1.CustomExpression = ".*";
            this.txtDescription1.EnterColor = System.Drawing.Color.Empty;
            this.txtDescription1.LeaveColor = System.Drawing.Color.Empty;
            this.txtDescription1.Location = new System.Drawing.Point(12, 210);
            this.txtDescription1.MaxLength = 50;
            this.txtDescription1.Name = "txtDescription1";
            this.txtDescription1.Size = new System.Drawing.Size(390, 20);
            this.txtDescription1.TabIndex = 89;
            this.txtDescription1.Tag = "";
            this.txtDescription1.Visible = false;
            // 
            // txtDescription2
            // 
            this.txtDescription2.AllowBlankSpaces = true;
            this.txtDescription2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtDescription2.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.AnyCharacter;
            this.txtDescription2.CustomExpression = ".*";
            this.txtDescription2.EnterColor = System.Drawing.Color.Empty;
            this.txtDescription2.LeaveColor = System.Drawing.Color.Empty;
            this.txtDescription2.Location = new System.Drawing.Point(12, 236);
            this.txtDescription2.MaxLength = 50;
            this.txtDescription2.Name = "txtDescription2";
            this.txtDescription2.Size = new System.Drawing.Size(390, 20);
            this.txtDescription2.TabIndex = 90;
            this.txtDescription2.Tag = "";
            this.txtDescription2.Visible = false;
            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.ForeColor = System.Drawing.Color.DarkCyan;
            this.lblDescription.Location = new System.Drawing.Point(12, 193);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(181, 13);
            this.lblDescription.TabIndex = 88;
            this.lblDescription.Text = "Descripción Extendida (Facturación):";
            this.lblDescription.Visible = false;
            // 
            // ucQualitiesByPax
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.txtDescription1);
            this.Controls.Add(this.txtDescription2);
            this.Controls.Add(this.lblDescription);
            this.Controls.Add(this.lbl10);
            this.Controls.Add(this.pnlCreditCardType);
            this.Controls.Add(this.lblNumberPassanger);
            this.Controls.Add(this.lbl8);
            this.Controls.Add(this.txtName1);
            this.Controls.Add(this.lbl9);
            this.Controls.Add(this.txtName2);
            this.Controls.Add(this.txtName4);
            this.Controls.Add(this.txtName3);
            this.Controls.Add(this.rdoYes);
            this.Controls.Add(this.rdoNo);
            this.Controls.Add(this.btnAccept);
            this.Controls.Add(this.lblConfirm);
            this.Controls.Add(this.lblTitle);
            this.Name = "ucQualitiesByPax";
            this.Size = new System.Drawing.Size(411, 580);
            this.Load += new System.EventHandler(this.ucQualitiesByPax_Load);
            this.pnlCreditCardType.ResumeLayout(false);
            this.pnlCreditCardType.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblConfirm;
        private System.Windows.Forms.RadioButton rdoNo;
        private System.Windows.Forms.RadioButton rdoYes;
        private System.Windows.Forms.Button btnAccept;
        private MyCTS.Forms.UI.SmartTextBox txtName1;
        private System.Windows.Forms.Label lbl8;
        private MyCTS.Forms.UI.SmartTextBox txtName2;
        private System.Windows.Forms.Label lbl9;
        private MyCTS.Forms.UI.SmartTextBox txtName3;
        private MyCTS.Forms.UI.SmartTextBox txtName4;
        private System.Windows.Forms.Label lblNumberPassanger;
        private System.Windows.Forms.CheckBox chkCTS;
        private System.Windows.Forms.Label lblCard;
        private System.Windows.Forms.CheckBox chkClient;
        private System.Windows.Forms.Panel pnlCreditCardType;
        private System.Windows.Forms.Label lbl10;
        private MyCTS.Forms.UI.SmartTextBox txtDescription1;
        private MyCTS.Forms.UI.SmartTextBox txtDescription2;
        private System.Windows.Forms.Label lblDescription;
    }
}
