namespace MyCTS.Presentation
{
    partial class ucEnableDisableFirm
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
            this.txtPasswordTemp = new MyCTS.Forms.UI.SmartTextBox();
            this.lblPasswordTemp = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtAuthorization = new MyCTS.Forms.UI.SmartTextBox();
            this.txtNumberFirm = new MyCTS.Forms.UI.SmartTextBox();
            this.lblFirmNumber = new System.Windows.Forms.Label();
            this.btnAccept = new System.Windows.Forms.Button();
            this.txtPCC = new MyCTS.Forms.UI.SmartTextBox();
            this.lblPCC = new System.Windows.Forms.Label();
            this.lbPCC = new System.Windows.Forms.ListBox();
            this.rdoEnable = new System.Windows.Forms.RadioButton();
            this.rdoDisable = new System.Windows.Forms.RadioButton();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(139)))), ((int)(((byte)(208)))));
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(3, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(411, 17);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Habilitar y Deshabilitar Firma";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // txtPasswordTemp
            // 
            this.txtPasswordTemp.AllowBlankSpaces = true;
            this.txtPasswordTemp.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtPasswordTemp.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.AnyCharacter;
            this.txtPasswordTemp.CustomExpression = ".*";
            this.txtPasswordTemp.EnterColor = System.Drawing.Color.Empty;
            this.txtPasswordTemp.LeaveColor = System.Drawing.Color.Empty;
            this.txtPasswordTemp.Location = new System.Drawing.Point(112, 149);
            this.txtPasswordTemp.MaxLength = 8;
            this.txtPasswordTemp.Name = "txtPasswordTemp";
            this.txtPasswordTemp.Size = new System.Drawing.Size(100, 20);
            this.txtPasswordTemp.TabIndex = 6;
            this.txtPasswordTemp.Text = "TMP1234";
            this.txtPasswordTemp.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // lblPasswordTemp
            // 
            this.lblPasswordTemp.AutoSize = true;
            this.lblPasswordTemp.Location = new System.Drawing.Point(5, 152);
            this.lblPasswordTemp.Name = "lblPasswordTemp";
            this.lblPasswordTemp.Size = new System.Drawing.Size(100, 13);
            this.lblPasswordTemp.TabIndex = 0;
            this.lblPasswordTemp.Text = "Password Temporal";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(5, 126);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Autorizado por";
            // 
            // txtAuthorization
            // 
            this.txtAuthorization.AllowBlankSpaces = true;
            this.txtAuthorization.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtAuthorization.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.AnyCharacter;
            this.txtAuthorization.CustomExpression = ".*";
            this.txtAuthorization.EnterColor = System.Drawing.Color.Empty;
            this.txtAuthorization.LeaveColor = System.Drawing.Color.Empty;
            this.txtAuthorization.Location = new System.Drawing.Point(111, 121);
            this.txtAuthorization.MaxLength = 15;
            this.txtAuthorization.Name = "txtAuthorization";
            this.txtAuthorization.Size = new System.Drawing.Size(100, 20);
            this.txtAuthorization.TabIndex = 5;
            this.txtAuthorization.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // txtNumberFirm
            // 
            this.txtNumberFirm.AllowBlankSpaces = true;
            this.txtNumberFirm.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtNumberFirm.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.OnlyNumbers;
            this.txtNumberFirm.CustomExpression = ".*";
            this.txtNumberFirm.EnterColor = System.Drawing.Color.Empty;
            this.txtNumberFirm.LeaveColor = System.Drawing.Color.Empty;
            this.txtNumberFirm.Location = new System.Drawing.Point(110, 64);
            this.txtNumberFirm.MaxLength = 4;
            this.txtNumberFirm.Name = "txtNumberFirm";
            this.txtNumberFirm.Size = new System.Drawing.Size(68, 20);
            this.txtNumberFirm.TabIndex = 3;
            this.txtNumberFirm.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // lblFirmNumber
            // 
            this.lblFirmNumber.AutoSize = true;
            this.lblFirmNumber.Location = new System.Drawing.Point(6, 67);
            this.lblFirmNumber.Name = "lblFirmNumber";
            this.lblFirmNumber.Size = new System.Drawing.Size(67, 13);
            this.lblFirmNumber.TabIndex = 0;
            this.lblFirmNumber.Text = "No. de Firma";
            // 
            // btnAccept
            // 
            this.btnAccept.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnAccept.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAccept.Location = new System.Drawing.Point(199, 222);
            this.btnAccept.Name = "btnAccept";
            this.btnAccept.Size = new System.Drawing.Size(100, 23);
            this.btnAccept.TabIndex = 7;
            this.btnAccept.Text = "Aceptar";
            this.btnAccept.UseVisualStyleBackColor = false;
            this.btnAccept.Click += new System.EventHandler(this.btnAccept_Click);
            // 
            // txtPCC
            // 
            this.txtPCC.AllowBlankSpaces = true;
            this.txtPCC.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtPCC.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.AnyCharacter;
            this.txtPCC.CustomExpression = ".*";
            this.txtPCC.EnterColor = System.Drawing.Color.Empty;
            this.txtPCC.LeaveColor = System.Drawing.Color.Empty;
            this.txtPCC.Location = new System.Drawing.Point(110, 90);
            this.txtPCC.MaxLength = 4;
            this.txtPCC.Name = "txtPCC";
            this.txtPCC.Size = new System.Drawing.Size(280, 20);
            this.txtPCC.TabIndex = 4;
            this.txtPCC.TextChanged += new System.EventHandler(this.txtPCC_TextChanged);
            this.txtPCC.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // lblPCC
            // 
            this.lblPCC.AutoSize = true;
            this.lblPCC.Location = new System.Drawing.Point(6, 97);
            this.lblPCC.Name = "lblPCC";
            this.lblPCC.Size = new System.Drawing.Size(28, 13);
            this.lblPCC.TabIndex = 0;
            this.lblPCC.Text = "PCC";
            // 
            // lbPCC
            // 
            this.lbPCC.DisplayMember = "Text";
            this.lbPCC.FormattingEnabled = true;
            this.lbPCC.Location = new System.Drawing.Point(110, 108);
            this.lbPCC.Name = "lbPCC";
            this.lbPCC.Size = new System.Drawing.Size(281, 95);
            this.lbPCC.TabIndex = 43;
            this.lbPCC.ValueMember = "Value";
            this.lbPCC.Visible = false;
            this.lbPCC.MouseClick += new System.Windows.Forms.MouseEventHandler(this.ListBox_MouseClick);
            this.lbPCC.KeyDown += new System.Windows.Forms.KeyEventHandler(this.lbPCC_KeyDown);
            // 
            // rdoEnable
            // 
            this.rdoEnable.AutoSize = true;
            this.rdoEnable.Location = new System.Drawing.Point(16, 31);
            this.rdoEnable.Name = "rdoEnable";
            this.rdoEnable.Size = new System.Drawing.Size(63, 17);
            this.rdoEnable.TabIndex = 1;
            this.rdoEnable.TabStop = true;
            this.rdoEnable.Text = "Habilitar";
            this.rdoEnable.UseVisualStyleBackColor = true;
            this.rdoEnable.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // rdoDisable
            // 
            this.rdoDisable.AutoSize = true;
            this.rdoDisable.Location = new System.Drawing.Point(122, 31);
            this.rdoDisable.Name = "rdoDisable";
            this.rdoDisable.Size = new System.Drawing.Size(80, 17);
            this.rdoDisable.TabIndex = 2;
            this.rdoDisable.TabStop = true;
            this.rdoDisable.Text = "Deshabilitar";
            this.rdoDisable.UseVisualStyleBackColor = true;
            this.rdoDisable.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // ucEnableDisableFirm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.rdoDisable);
            this.Controls.Add(this.rdoEnable);
            this.Controls.Add(this.txtPCC);
            this.Controls.Add(this.lblPCC);
            this.Controls.Add(this.btnAccept);
            this.Controls.Add(this.txtPasswordTemp);
            this.Controls.Add(this.lblPasswordTemp);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtAuthorization);
            this.Controls.Add(this.txtNumberFirm);
            this.Controls.Add(this.lblFirmNumber);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.lbPCC);
            this.Name = "ucEnableDisableFirm";
            this.Size = new System.Drawing.Size(411, 580);
            this.Load += new System.EventHandler(this.ucEnableDisableFirm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.Label lblTitle;
        private MyCTS.Forms.UI.SmartTextBox txtPasswordTemp;
        private System.Windows.Forms.Label lblPasswordTemp;
        private System.Windows.Forms.Label label1;
        private MyCTS.Forms.UI.SmartTextBox txtAuthorization;
        private MyCTS.Forms.UI.SmartTextBox txtNumberFirm;
        private System.Windows.Forms.Label lblFirmNumber;
        private System.Windows.Forms.Button btnAccept;
        private MyCTS.Forms.UI.SmartTextBox txtPCC;
        private System.Windows.Forms.Label lblPCC;
        private System.Windows.Forms.ListBox lbPCC;
        private System.Windows.Forms.RadioButton rdoEnable;
        private System.Windows.Forms.RadioButton rdoDisable;
    }
}
