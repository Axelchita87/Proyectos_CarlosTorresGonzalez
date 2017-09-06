namespace MyCTS.Presentation
{
    partial class ucLoadPassengerProfile
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
            this.lblStar1Name = new System.Windows.Forms.Label();
            this.txtStar1name = new MyCTS.Forms.UI.SmartTextBox();
            this.lblStar2Name = new System.Windows.Forms.Label();
            this.txtStar2Name = new MyCTS.Forms.UI.SmartTextBox();
            this.btnAccept = new System.Windows.Forms.Button();
            this.lbProfileInfo = new System.Windows.Forms.ListBox();
            this.txtPCC = new MyCTS.Forms.UI.SmartTextBox();
            this.lblPCC = new System.Windows.Forms.Label();
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
            this.lblTitle.Text = "Ingresa Perfil de Pasajero";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblStar1Name
            // 
            this.lblStar1Name.AutoSize = true;
            this.lblStar1Name.Location = new System.Drawing.Point(15, 98);
            this.lblStar1Name.Name = "lblStar1Name";
            this.lblStar1Name.Size = new System.Drawing.Size(156, 13);
            this.lblStar1Name.TabIndex = 0;
            this.lblStar1Name.Text = "Ingresa Estrella de Primer Nivel:";
            // 
            // txtStar1name
            // 
            this.txtStar1name.AllowBlankSpaces = true;
            this.txtStar1name.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtStar1name.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.NumbersOrLetters;
            this.txtStar1name.CustomExpression = ".*";
            this.txtStar1name.EnterColor = System.Drawing.Color.Empty;
            this.txtStar1name.LeaveColor = System.Drawing.Color.Empty;
            this.txtStar1name.Location = new System.Drawing.Point(18, 111);
            this.txtStar1name.MaxLength = 50;
            this.txtStar1name.Name = "txtStar1name";
            this.txtStar1name.Size = new System.Drawing.Size(365, 20);
            this.txtStar1name.TabIndex = 2;
            this.txtStar1name.TextChanged += new System.EventHandler(this.txtStar1name_TextChanged);
            // 
            // lblStar2Name
            // 
            this.lblStar2Name.AutoSize = true;
            this.lblStar2Name.Location = new System.Drawing.Point(15, 145);
            this.lblStar2Name.Name = "lblStar2Name";
            this.lblStar2Name.Size = new System.Drawing.Size(170, 13);
            this.lblStar2Name.TabIndex = 0;
            this.lblStar2Name.Text = "Ingresa Estrella de Segundo Nivel:";
            // 
            // txtStar2Name
            // 
            this.txtStar2Name.AllowBlankSpaces = false;
            this.txtStar2Name.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtStar2Name.CharsIncluded = new char[] {
        '/'};
            this.txtStar2Name.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.NumbersOrLetters;
            this.txtStar2Name.CustomExpression = ".*";
            this.txtStar2Name.EnterColor = System.Drawing.Color.Empty;
            this.txtStar2Name.LeaveColor = System.Drawing.Color.Empty;
            this.txtStar2Name.Location = new System.Drawing.Point(18, 161);
            this.txtStar2Name.MaxLength = 50;
            this.txtStar2Name.Name = "txtStar2Name";
            this.txtStar2Name.Size = new System.Drawing.Size(365, 20);
            this.txtStar2Name.TabIndex = 4;
            this.txtStar2Name.TextChanged += new System.EventHandler(this.txtStar2Name_TextChanged);
            // 
            // btnAccept
            // 
            this.btnAccept.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnAccept.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAccept.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAccept.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAccept.ForeColor = System.Drawing.Color.Black;
            this.btnAccept.Location = new System.Drawing.Point(283, 226);
            this.btnAccept.Name = "btnAccept";
            this.btnAccept.Size = new System.Drawing.Size(100, 23);
            this.btnAccept.TabIndex = 19;
            this.btnAccept.Text = "Aceptar";
            this.btnAccept.UseVisualStyleBackColor = false;
            // 
            // lbProfileInfo
            // 
            this.lbProfileInfo.DisplayMember = "Text";
            this.lbProfileInfo.FormattingEnabled = true;
            this.lbProfileInfo.HorizontalScrollbar = true;
            this.lbProfileInfo.Location = new System.Drawing.Point(31, 226);
            this.lbProfileInfo.Name = "lbProfileInfo";
            this.lbProfileInfo.Size = new System.Drawing.Size(195, 95);
            this.lbProfileInfo.TabIndex = 0;
            this.lbProfileInfo.ValueMember = "Value";
            // 
            // txtPCC
            // 
            this.txtPCC.AllowBlankSpaces = true;
            this.txtPCC.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtPCC.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.AnyCharacter;
            this.txtPCC.CustomExpression = ".*";
            this.txtPCC.EnterColor = System.Drawing.Color.Empty;
            this.txtPCC.LeaveColor = System.Drawing.Color.Empty;
            this.txtPCC.Location = new System.Drawing.Point(18, 62);
            this.txtPCC.MaxLength = 30;
            this.txtPCC.Name = "txtPCC";
            this.txtPCC.Size = new System.Drawing.Size(198, 20);
            this.txtPCC.TabIndex = 1;
            this.txtPCC.TextChanged += new System.EventHandler(this.txtPCC_TextChanged);
            // 
            // lblPCC
            // 
            this.lblPCC.AutoSize = true;
            this.lblPCC.Location = new System.Drawing.Point(15, 46);
            this.lblPCC.Name = "lblPCC";
            this.lblPCC.Size = new System.Drawing.Size(69, 13);
            this.lblPCC.TabIndex = 0;
            this.lblPCC.Text = "Ingresa PCC:";
            // 
            // ucLoadPassengerProfile
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.lbProfileInfo);
            this.Controls.Add(this.btnAccept);
            this.Controls.Add(this.lblStar2Name);
            this.Controls.Add(this.txtStar2Name);
            this.Controls.Add(this.lblStar1Name);
            this.Controls.Add(this.txtStar1name);
            this.Controls.Add(this.lblPCC);
            this.Controls.Add(this.txtPCC);
            this.Controls.Add(this.lblTitle);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "ucLoadPassengerProfile";
            this.Size = new System.Drawing.Size(411, 580);
            this.Load += new System.EventHandler(this.ucLoadPassengerProfile_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblStar1Name;
        private MyCTS.Forms.UI.SmartTextBox txtStar1name;
        private System.Windows.Forms.Label lblStar2Name;
        private MyCTS.Forms.UI.SmartTextBox txtStar2Name;
        private System.Windows.Forms.Button btnAccept;
        private System.Windows.Forms.ListBox lbProfileInfo;
        private MyCTS.Forms.UI.SmartTextBox txtPCC;
        private System.Windows.Forms.Label lblPCC;
    }
}
