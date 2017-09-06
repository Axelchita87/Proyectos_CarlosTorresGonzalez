namespace MyCTS.Presentation
{
    partial class ucChangeName
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
            this.btnAccept = new System.Windows.Forms.Button();
            this.lblNumberFirm = new System.Windows.Forms.Label();
            this.txtNumberFirm = new MyCTS.Forms.UI.SmartTextBox();
            this.lblPCC = new System.Windows.Forms.Label();
            this.txtPCC = new MyCTS.Forms.UI.SmartTextBox();
            this.lblLastName = new System.Windows.Forms.Label();
            this.txtLastName = new MyCTS.Forms.UI.SmartTextBox();
            this.lblInitial = new System.Windows.Forms.Label();
            this.txtInitial = new MyCTS.Forms.UI.SmartTextBox();
            this.txtAuthorization = new MyCTS.Forms.UI.SmartTextBox();
            this.lblAuthorization = new System.Windows.Forms.Label();
            this.lbPCC = new System.Windows.Forms.ListBox();
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
            this.lblTitle.Text = "Cambiar Nombre";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // btnAccept
            // 
            this.btnAccept.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnAccept.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAccept.Location = new System.Drawing.Point(263, 223);
            this.btnAccept.Name = "btnAccept";
            this.btnAccept.Size = new System.Drawing.Size(100, 23);
            this.btnAccept.TabIndex = 6;
            this.btnAccept.Text = "Aceptar";
            this.btnAccept.UseVisualStyleBackColor = false;
            this.btnAccept.Click += new System.EventHandler(this.btnAccept_Click);
            // 
            // lblNumberFirm
            // 
            this.lblNumberFirm.AutoSize = true;
            this.lblNumberFirm.Location = new System.Drawing.Point(31, 36);
            this.lblNumberFirm.Name = "lblNumberFirm";
            this.lblNumberFirm.Size = new System.Drawing.Size(67, 13);
            this.lblNumberFirm.TabIndex = 0;
            this.lblNumberFirm.Text = "No. de Firma";
            // 
            // txtNumberFirm
            // 
            this.txtNumberFirm.AllowBlankSpaces = true;
            this.txtNumberFirm.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtNumberFirm.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.OnlyNumbers;
            this.txtNumberFirm.CustomExpression = ".*";
            this.txtNumberFirm.EnterColor = System.Drawing.Color.Empty;
            this.txtNumberFirm.LeaveColor = System.Drawing.Color.Empty;
            this.txtNumberFirm.Location = new System.Drawing.Point(110, 29);
            this.txtNumberFirm.MaxLength = 4;
            this.txtNumberFirm.Name = "txtNumberFirm";
            this.txtNumberFirm.Size = new System.Drawing.Size(60, 20);
            this.txtNumberFirm.TabIndex = 1;
            this.txtNumberFirm.TextChanged += new System.EventHandler(this.txtNumberFirm_TextChanged);
            this.txtNumberFirm.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // lblPCC
            // 
            this.lblPCC.AutoSize = true;
            this.lblPCC.Location = new System.Drawing.Point(31, 66);
            this.lblPCC.Name = "lblPCC";
            this.lblPCC.Size = new System.Drawing.Size(28, 13);
            this.lblPCC.TabIndex = 0;
            this.lblPCC.Text = "PCC";
            // 
            // txtPCC
            // 
            this.txtPCC.AllowBlankSpaces = true;
            this.txtPCC.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtPCC.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.AnyCharacter;
            this.txtPCC.CustomExpression = ".*";
            this.txtPCC.EnterColor = System.Drawing.Color.Empty;
            this.txtPCC.LeaveColor = System.Drawing.Color.Empty;
            this.txtPCC.Location = new System.Drawing.Point(108, 59);
            this.txtPCC.MaxLength = 4;
            this.txtPCC.Name = "txtPCC";
            this.txtPCC.Size = new System.Drawing.Size(288, 20);
            this.txtPCC.TabIndex = 2;
            this.txtPCC.TextChanged += new System.EventHandler(this.txtPCC_TextChanged);
            this.txtPCC.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // lblLastName
            // 
            this.lblLastName.AutoSize = true;
            this.lblLastName.Location = new System.Drawing.Point(31, 96);
            this.lblLastName.Name = "lblLastName";
            this.lblLastName.Size = new System.Drawing.Size(44, 13);
            this.lblLastName.TabIndex = 0;
            this.lblLastName.Text = "Apellido";
            // 
            // txtLastName
            // 
            this.txtLastName.AllowBlankSpaces = true;
            this.txtLastName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtLastName.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.OnlyLetters;
            this.txtLastName.CustomExpression = ".*";
            this.txtLastName.EnterColor = System.Drawing.Color.Empty;
            this.txtLastName.LeaveColor = System.Drawing.Color.Empty;
            this.txtLastName.Location = new System.Drawing.Point(109, 89);
            this.txtLastName.MaxLength = 12;
            this.txtLastName.Name = "txtLastName";
            this.txtLastName.Size = new System.Drawing.Size(113, 20);
            this.txtLastName.TabIndex = 3;
            this.txtLastName.TextChanged += new System.EventHandler(this.txtLastName_TextChanged);
            this.txtLastName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // lblInitial
            // 
            this.lblInitial.AutoSize = true;
            this.lblInitial.Location = new System.Drawing.Point(31, 131);
            this.lblInitial.Name = "lblInitial";
            this.lblInitial.Size = new System.Drawing.Size(34, 13);
            this.lblInitial.TabIndex = 0;
            this.lblInitial.Text = "Inicial";
            // 
            // txtInitial
            // 
            this.txtInitial.AllowBlankSpaces = true;
            this.txtInitial.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtInitial.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.OnlyLetters;
            this.txtInitial.CustomExpression = ".*";
            this.txtInitial.EnterColor = System.Drawing.Color.Empty;
            this.txtInitial.LeaveColor = System.Drawing.Color.Empty;
            this.txtInitial.Location = new System.Drawing.Point(109, 124);
            this.txtInitial.MaxLength = 1;
            this.txtInitial.Name = "txtInitial";
            this.txtInitial.Size = new System.Drawing.Size(28, 20);
            this.txtInitial.TabIndex = 4;
            this.txtInitial.TextChanged += new System.EventHandler(this.txtInitial_TextChanged);
            this.txtInitial.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // txtAuthorization
            // 
            this.txtAuthorization.AllowBlankSpaces = true;
            this.txtAuthorization.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtAuthorization.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.OnlyLetters;
            this.txtAuthorization.CustomExpression = ".*";
            this.txtAuthorization.EnterColor = System.Drawing.Color.Empty;
            this.txtAuthorization.LeaveColor = System.Drawing.Color.Empty;
            this.txtAuthorization.Location = new System.Drawing.Point(109, 155);
            this.txtAuthorization.MaxLength = 20;
            this.txtAuthorization.Name = "txtAuthorization";
            this.txtAuthorization.Size = new System.Drawing.Size(144, 20);
            this.txtAuthorization.TabIndex = 5;
            this.txtAuthorization.TextChanged += new System.EventHandler(this.txtAuthorization_TextChanged);
            this.txtAuthorization.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // lblAuthorization
            // 
            this.lblAuthorization.AutoSize = true;
            this.lblAuthorization.Location = new System.Drawing.Point(31, 158);
            this.lblAuthorization.Name = "lblAuthorization";
            this.lblAuthorization.Size = new System.Drawing.Size(75, 13);
            this.lblAuthorization.TabIndex = 0;
            this.lblAuthorization.Text = "Autorizado por";
            // 
            // lbPCC
            // 
            this.lbPCC.DisplayMember = "Text";
            this.lbPCC.FormattingEnabled = true;
            this.lbPCC.Location = new System.Drawing.Point(108, 77);
            this.lbPCC.Name = "lbPCC";
            this.lbPCC.Size = new System.Drawing.Size(289, 95);
            this.lbPCC.TabIndex = 27;
            this.lbPCC.ValueMember = "Value";
            this.lbPCC.Visible = false;
            this.lbPCC.MouseClick += new System.Windows.Forms.MouseEventHandler(this.ListBox_MouseClick);
            this.lbPCC.KeyDown += new System.Windows.Forms.KeyEventHandler(this.lbPCC_KeyDown);
            // 
            // ucChangeName
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.lblAuthorization);
            this.Controls.Add(this.txtAuthorization);
            this.Controls.Add(this.txtInitial);
            this.Controls.Add(this.lblInitial);
            this.Controls.Add(this.txtLastName);
            this.Controls.Add(this.lblLastName);
            this.Controls.Add(this.txtPCC);
            this.Controls.Add(this.lblPCC);
            this.Controls.Add(this.txtNumberFirm);
            this.Controls.Add(this.lblNumberFirm);
            this.Controls.Add(this.btnAccept);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.lbPCC);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "ucChangeName";
            this.Size = new System.Drawing.Size(419, 580);
            this.Load += new System.EventHandler(this.ucChangeName_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Button btnAccept;
        private System.Windows.Forms.Label lblNumberFirm;
        private MyCTS.Forms.UI.SmartTextBox txtNumberFirm;
        private System.Windows.Forms.Label lblPCC;
        private MyCTS.Forms.UI.SmartTextBox txtPCC;
        private System.Windows.Forms.Label lblLastName;
        private MyCTS.Forms.UI.SmartTextBox txtLastName;
        private System.Windows.Forms.Label lblInitial;
        private MyCTS.Forms.UI.SmartTextBox txtInitial;
        private MyCTS.Forms.UI.SmartTextBox txtAuthorization;
        private System.Windows.Forms.Label lblAuthorization;
        private System.Windows.Forms.ListBox lbPCC;
    }
}
