namespace MyCTS.Presentation
{
    partial class ucChangeCode
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
            this.lbPCC = new System.Windows.Forms.ListBox();
            this.lblAuthorization = new System.Windows.Forms.Label();
            this.txtAuthorization = new MyCTS.Forms.UI.SmartTextBox();
            this.txtAgentCode = new MyCTS.Forms.UI.SmartTextBox();
            this.lblAgentCode = new System.Windows.Forms.Label();
            this.txtPCC = new MyCTS.Forms.UI.SmartTextBox();
            this.lblPCC = new System.Windows.Forms.Label();
            this.txtNumberFirm = new MyCTS.Forms.UI.SmartTextBox();
            this.lblNumberFirm = new System.Windows.Forms.Label();
            this.btnAccept = new System.Windows.Forms.Button();
            this.lblTitle = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lbPCC
            // 
            this.lbPCC.DisplayMember = "Text";
            this.lbPCC.FormattingEnabled = true;
            this.lbPCC.Location = new System.Drawing.Point(110, 77);
            this.lbPCC.Name = "lbPCC";
            this.lbPCC.Size = new System.Drawing.Size(282, 95);
            this.lbPCC.TabIndex = 40;
            this.lbPCC.ValueMember = "Value";
            this.lbPCC.Visible = false;
            this.lbPCC.MouseClick += new System.Windows.Forms.MouseEventHandler(this.ListBox_MouseClick);
            this.lbPCC.KeyDown += new System.Windows.Forms.KeyEventHandler(this.lbPCC_KeyDown);
            // 
            // lblAuthorization
            // 
            this.lblAuthorization.AutoSize = true;
            this.lblAuthorization.Location = new System.Drawing.Point(14, 91);
            this.lblAuthorization.Name = "lblAuthorization";
            this.lblAuthorization.Size = new System.Drawing.Size(75, 13);
            this.lblAuthorization.TabIndex = 0;
            this.lblAuthorization.Text = "Autorizado por";
            this.lblAuthorization.Click += new System.EventHandler(this.lblAuthorization_Click);
            // 
            // txtAuthorization
            // 
            this.txtAuthorization.AllowBlankSpaces = true;
            this.txtAuthorization.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtAuthorization.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.OnlyLetters;
            this.txtAuthorization.CustomExpression = ".*";
            this.txtAuthorization.EnterColor = System.Drawing.Color.Empty;
            this.txtAuthorization.LeaveColor = System.Drawing.Color.Empty;
            this.txtAuthorization.Location = new System.Drawing.Point(111, 88);
            this.txtAuthorization.MaxLength = 20;
            this.txtAuthorization.Name = "txtAuthorization";
            this.txtAuthorization.Size = new System.Drawing.Size(144, 20);
            this.txtAuthorization.TabIndex = 3;
            this.txtAuthorization.TextChanged += new System.EventHandler(this.txtAuthorization_TextChanged);
            this.txtAuthorization.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // txtAgentCode
            // 
            this.txtAgentCode.AllowBlankSpaces = true;
            this.txtAgentCode.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtAgentCode.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.OnlyLetters;
            this.txtAgentCode.CustomExpression = ".*";
            this.txtAgentCode.EnterColor = System.Drawing.Color.Empty;
            this.txtAgentCode.LeaveColor = System.Drawing.Color.Empty;
            this.txtAgentCode.Location = new System.Drawing.Point(111, 114);
            this.txtAgentCode.MaxLength = 2;
            this.txtAgentCode.Name = "txtAgentCode";
            this.txtAgentCode.Size = new System.Drawing.Size(50, 20);
            this.txtAgentCode.TabIndex = 4;
            this.txtAgentCode.TextChanged += new System.EventHandler(this.txtAgentCode_TextChanged);
            this.txtAgentCode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // lblAgentCode
            // 
            this.lblAgentCode.AutoSize = true;
            this.lblAgentCode.Location = new System.Drawing.Point(14, 117);
            this.lblAgentCode.Name = "lblAgentCode";
            this.lblAgentCode.Size = new System.Drawing.Size(92, 13);
            this.lblAgentCode.TabIndex = 0;
            this.lblAgentCode.Text = "Código de Agente";
            // 
            // txtPCC
            // 
            this.txtPCC.AllowBlankSpaces = true;
            this.txtPCC.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtPCC.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.AnyCharacter;
            this.txtPCC.CustomExpression = ".*";
            this.txtPCC.EnterColor = System.Drawing.Color.Empty;
            this.txtPCC.LeaveColor = System.Drawing.Color.Empty;
            this.txtPCC.Location = new System.Drawing.Point(110, 59);
            this.txtPCC.MaxLength = 4;
            this.txtPCC.Name = "txtPCC";
            this.txtPCC.Size = new System.Drawing.Size(281, 20);
            this.txtPCC.TabIndex = 2;
            this.txtPCC.TextChanged += new System.EventHandler(this.txtPCC_TextChanged);
            this.txtPCC.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // lblPCC
            // 
            this.lblPCC.AutoSize = true;
            this.lblPCC.Location = new System.Drawing.Point(14, 66);
            this.lblPCC.Name = "lblPCC";
            this.lblPCC.Size = new System.Drawing.Size(28, 13);
            this.lblPCC.TabIndex = 0;
            this.lblPCC.Text = "PCC";
            this.lblPCC.Click += new System.EventHandler(this.lblPCC_Click);
            // 
            // txtNumberFirm
            // 
            this.txtNumberFirm.AllowBlankSpaces = true;
            this.txtNumberFirm.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtNumberFirm.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.OnlyNumbers;
            this.txtNumberFirm.CustomExpression = ".*";
            this.txtNumberFirm.EnterColor = System.Drawing.Color.Empty;
            this.txtNumberFirm.LeaveColor = System.Drawing.Color.Empty;
            this.txtNumberFirm.Location = new System.Drawing.Point(111, 29);
            this.txtNumberFirm.MaxLength = 4;
            this.txtNumberFirm.Name = "txtNumberFirm";
            this.txtNumberFirm.Size = new System.Drawing.Size(60, 20);
            this.txtNumberFirm.TabIndex = 1;
            this.txtNumberFirm.TextChanged += new System.EventHandler(this.txtNumberFirm_TextChanged);
            this.txtNumberFirm.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // lblNumberFirm
            // 
            this.lblNumberFirm.AutoSize = true;
            this.lblNumberFirm.Location = new System.Drawing.Point(14, 36);
            this.lblNumberFirm.Name = "lblNumberFirm";
            this.lblNumberFirm.Size = new System.Drawing.Size(67, 13);
            this.lblNumberFirm.TabIndex = 0;
            this.lblNumberFirm.Text = "No. de Firma";
            this.lblNumberFirm.Click += new System.EventHandler(this.lblNumberFirm_Click);
            // 
            // btnAccept
            // 
            this.btnAccept.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnAccept.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAccept.Location = new System.Drawing.Point(261, 149);
            this.btnAccept.Name = "btnAccept";
            this.btnAccept.Size = new System.Drawing.Size(100, 23);
            this.btnAccept.TabIndex = 5;
            this.btnAccept.Text = "Aceptar";
            this.btnAccept.UseVisualStyleBackColor = false;
            this.btnAccept.Click += new System.EventHandler(this.btnAccept_Click);
            // 
            // lblTitle
            // 
            this.lblTitle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(139)))), ((int)(((byte)(208)))));
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(-3, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(411, 17);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Cambiar Código de Agente";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // ucChangeCode
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.lblAuthorization);
            this.Controls.Add(this.txtAuthorization);
            this.Controls.Add(this.txtAgentCode);
            this.Controls.Add(this.lblAgentCode);
            this.Controls.Add(this.txtPCC);
            this.Controls.Add(this.lblPCC);
            this.Controls.Add(this.txtNumberFirm);
            this.Controls.Add(this.lblNumberFirm);
            this.Controls.Add(this.btnAccept);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.lbPCC);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "ucChangeCode";
            this.Size = new System.Drawing.Size(411, 580);
            this.Load += new System.EventHandler(this.ucChangeCode_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lbPCC;
        private System.Windows.Forms.Label lblAuthorization;
        private MyCTS.Forms.UI.SmartTextBox txtAuthorization;
        private MyCTS.Forms.UI.SmartTextBox txtAgentCode;
        private System.Windows.Forms.Label lblAgentCode;
        private MyCTS.Forms.UI.SmartTextBox txtPCC;
        private System.Windows.Forms.Label lblPCC;
        private MyCTS.Forms.UI.SmartTextBox txtNumberFirm;
        private System.Windows.Forms.Label lblNumberFirm;
        private System.Windows.Forms.Button btnAccept;
        internal System.Windows.Forms.Label lblTitle;
    }
}
