namespace MyCTS.Presentation
{
    partial class ucInternationalPaxInfo
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
            this.lblDescription = new System.Windows.Forms.Label();
            this.lblAirLine1 = new System.Windows.Forms.Label();
            this.txtAirline = new MyCTS.Forms.UI.SmartTextBox();
            this.lblsurname = new System.Windows.Forms.Label();
            this.txtSurname = new MyCTS.Forms.UI.SmartTextBox();
            this.lblName = new System.Windows.Forms.Label();
            this.txtName = new MyCTS.Forms.UI.SmartTextBox();
            this.lblPaxNumber = new System.Windows.Forms.Label();
            this.txtPaxNumber = new MyCTS.Forms.UI.SmartTextBox();
            this.lblBirthday = new System.Windows.Forms.Label();
            this.txtBirthday = new MyCTS.Forms.UI.SmartTextBox();
            this.lblPassport = new System.Windows.Forms.Label();
            this.txtPassport = new MyCTS.Forms.UI.SmartTextBox();
            this.lblNationality = new System.Windows.Forms.Label();
            this.txtNationality = new MyCTS.Forms.UI.SmartTextBox();
            this.lblFormatDate = new System.Windows.Forms.Label();
            this.lblFamilyInfo = new System.Windows.Forms.Label();
            this.lblFamiliarName = new System.Windows.Forms.Label();
            this.txtFamiliarName = new MyCTS.Forms.UI.SmartTextBox();
            this.lblCountry = new System.Windows.Forms.Label();
            this.txtCountry = new MyCTS.Forms.UI.SmartTextBox();
            this.lblPhone = new System.Windows.Forms.Label();
            this.txtPhone = new MyCTS.Forms.UI.SmartTextBox();
            this.btnAccept = new System.Windows.Forms.Button();
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
            this.lblTitle.Text = "Datos de Pax Vuelos Internacionales";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.ForeColor = System.Drawing.Color.Blue;
            this.lblDescription.Location = new System.Drawing.Point(23, 35);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(232, 13);
            this.lblDescription.TabIndex = 0;
            this.lblDescription.Text = "Información necesaria para vuelos internacional";
            // 
            // lblAirLine1
            // 
            this.lblAirLine1.AutoSize = true;
            this.lblAirLine1.ForeColor = System.Drawing.Color.Black;
            this.lblAirLine1.Location = new System.Drawing.Point(23, 69);
            this.lblAirLine1.Name = "lblAirLine1";
            this.lblAirLine1.Size = new System.Drawing.Size(62, 13);
            this.lblAirLine1.TabIndex = 0;
            this.lblAirLine1.Text = "Aereolínea:";
            // 
            // txtAirline
            // 
            this.txtAirline.AllowBlankSpaces = false;
            this.txtAirline.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtAirline.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.NumbersOrLetters;
            this.txtAirline.CustomExpression = ".*";
            this.txtAirline.EnterColor = System.Drawing.Color.Empty;
            this.txtAirline.LeaveColor = System.Drawing.Color.Empty;
            this.txtAirline.Location = new System.Drawing.Point(148, 66);
            this.txtAirline.MaxLength = 2;
            this.txtAirline.Name = "txtAirline";
            this.txtAirline.Size = new System.Drawing.Size(25, 20);
            this.txtAirline.TabIndex = 1;
            this.txtAirline.TextChanged += new System.EventHandler(this.txtControls_TextChanged);
            this.txtAirline.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // lblsurname
            // 
            this.lblsurname.AutoSize = true;
            this.lblsurname.ForeColor = System.Drawing.Color.Black;
            this.lblsurname.Location = new System.Drawing.Point(23, 100);
            this.lblsurname.Name = "lblsurname";
            this.lblsurname.Size = new System.Drawing.Size(47, 13);
            this.lblsurname.TabIndex = 0;
            this.lblsurname.Text = "Apellido:";
            // 
            // txtSurname
            // 
            this.txtSurname.AllowBlankSpaces = false;
            this.txtSurname.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtSurname.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.OnlyLetters;
            this.txtSurname.CustomExpression = ".*";
            this.txtSurname.EnterColor = System.Drawing.Color.Empty;
            this.txtSurname.LeaveColor = System.Drawing.Color.Empty;
            this.txtSurname.Location = new System.Drawing.Point(148, 97);
            this.txtSurname.MaxLength = 18;
            this.txtSurname.Name = "txtSurname";
            this.txtSurname.Size = new System.Drawing.Size(181, 20);
            this.txtSurname.TabIndex = 2;
            this.txtSurname.TextChanged += new System.EventHandler(this.txtControls_TextChanged);
            this.txtSurname.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.ForeColor = System.Drawing.Color.Black;
            this.lblName.Location = new System.Drawing.Point(23, 134);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(47, 13);
            this.lblName.TabIndex = 0;
            this.lblName.Text = "Nombre:";
            // 
            // txtName
            // 
            this.txtName.AllowBlankSpaces = false;
            this.txtName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtName.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.OnlyLetters;
            this.txtName.CustomExpression = ".*";
            this.txtName.EnterColor = System.Drawing.Color.Empty;
            this.txtName.LeaveColor = System.Drawing.Color.Empty;
            this.txtName.Location = new System.Drawing.Point(148, 131);
            this.txtName.MaxLength = 18;
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(181, 20);
            this.txtName.TabIndex = 3;
            this.txtName.TextChanged += new System.EventHandler(this.txtControls_TextChanged);
            this.txtName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // lblPaxNumber
            // 
            this.lblPaxNumber.AutoSize = true;
            this.lblPaxNumber.Location = new System.Drawing.Point(23, 168);
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
            this.txtPaxNumber.Location = new System.Drawing.Point(148, 165);
            this.txtPaxNumber.MaxLength = 4;
            this.txtPaxNumber.Name = "txtPaxNumber";
            this.txtPaxNumber.Size = new System.Drawing.Size(35, 20);
            this.txtPaxNumber.TabIndex = 4;
            this.txtPaxNumber.TextChanged += new System.EventHandler(this.txtControls_TextChanged);
            this.txtPaxNumber.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // lblBirthday
            // 
            this.lblBirthday.AutoSize = true;
            this.lblBirthday.Location = new System.Drawing.Point(23, 199);
            this.lblBirthday.Name = "lblBirthday";
            this.lblBirthday.Size = new System.Drawing.Size(111, 13);
            this.lblBirthday.TabIndex = 0;
            this.lblBirthday.Text = "Fecha de Nacimiento:";
            // 
            // txtBirthday
            // 
            this.txtBirthday.AllowBlankSpaces = false;
            this.txtBirthday.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtBirthday.CharsNoIncluded = new char[0];
            this.txtBirthday.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.NumbersOrLetters;
            this.txtBirthday.CustomExpression = ".*";
            this.txtBirthday.EnterColor = System.Drawing.Color.Empty;
            this.txtBirthday.HideSelection = false;
            this.txtBirthday.LeaveColor = System.Drawing.Color.Empty;
            this.txtBirthday.Location = new System.Drawing.Point(148, 196);
            this.txtBirthday.MaxLength = 7;
            this.txtBirthday.Name = "txtBirthday";
            this.txtBirthday.Size = new System.Drawing.Size(62, 20);
            this.txtBirthday.TabIndex = 5;
            this.txtBirthday.TextChanged += new System.EventHandler(this.txtControls_TextChanged);
            this.txtBirthday.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // lblPassport
            // 
            this.lblPassport.AutoSize = true;
            this.lblPassport.Location = new System.Drawing.Point(23, 233);
            this.lblPassport.Name = "lblPassport";
            this.lblPassport.Size = new System.Drawing.Size(58, 13);
            this.lblPassport.TabIndex = 0;
            this.lblPassport.Text = "Pasaporte:";
            // 
            // txtPassport
            // 
            this.txtPassport.AllowBlankSpaces = false;
            this.txtPassport.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtPassport.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.OnlyNumbers;
            this.txtPassport.CustomExpression = ".*";
            this.txtPassport.EnterColor = System.Drawing.Color.Empty;
            this.txtPassport.LeaveColor = System.Drawing.Color.Empty;
            this.txtPassport.Location = new System.Drawing.Point(148, 230);
            this.txtPassport.MaxLength = 16;
            this.txtPassport.Name = "txtPassport";
            this.txtPassport.Size = new System.Drawing.Size(181, 20);
            this.txtPassport.TabIndex = 6;
            this.txtPassport.TextChanged += new System.EventHandler(this.txtControls_TextChanged);
            this.txtPassport.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // lblNationality
            // 
            this.lblNationality.AutoSize = true;
            this.lblNationality.Location = new System.Drawing.Point(23, 268);
            this.lblNationality.Name = "lblNationality";
            this.lblNationality.Size = new System.Drawing.Size(72, 13);
            this.lblNationality.TabIndex = 0;
            this.lblNationality.Text = "Nacionalidad:";
            // 
            // txtNationality
            // 
            this.txtNationality.AllowBlankSpaces = false;
            this.txtNationality.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtNationality.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.OnlyLetters;
            this.txtNationality.CustomExpression = ".*";
            this.txtNationality.EnterColor = System.Drawing.Color.Empty;
            this.txtNationality.LeaveColor = System.Drawing.Color.Empty;
            this.txtNationality.Location = new System.Drawing.Point(148, 265);
            this.txtNationality.MaxLength = 2;
            this.txtNationality.Name = "txtNationality";
            this.txtNationality.Size = new System.Drawing.Size(25, 20);
            this.txtNationality.TabIndex = 7;
            this.txtNationality.TextChanged += new System.EventHandler(this.txtControls_TextChanged);
            this.txtNationality.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // lblFormatDate
            // 
            this.lblFormatDate.AutoSize = true;
            this.lblFormatDate.ForeColor = System.Drawing.Color.Blue;
            this.lblFormatDate.Location = new System.Drawing.Point(216, 199);
            this.lblFormatDate.Name = "lblFormatDate";
            this.lblFormatDate.Size = new System.Drawing.Size(68, 13);
            this.lblFormatDate.TabIndex = 0;
            this.lblFormatDate.Text = "Ej: 25APR86";
            // 
            // lblFamilyInfo
            // 
            this.lblFamilyInfo.AutoSize = true;
            this.lblFamilyInfo.ForeColor = System.Drawing.Color.Blue;
            this.lblFamilyInfo.Location = new System.Drawing.Point(23, 302);
            this.lblFamilyInfo.Name = "lblFamilyInfo";
            this.lblFamilyInfo.Size = new System.Drawing.Size(166, 13);
            this.lblFamilyInfo.TabIndex = 0;
            this.lblFamilyInfo.Text = "Información de Familiar o Relativo";
            // 
            // lblFamiliarName
            // 
            this.lblFamiliarName.AutoSize = true;
            this.lblFamiliarName.ForeColor = System.Drawing.Color.DarkCyan;
            this.lblFamiliarName.Location = new System.Drawing.Point(23, 335);
            this.lblFamiliarName.Name = "lblFamiliarName";
            this.lblFamiliarName.Size = new System.Drawing.Size(47, 13);
            this.lblFamiliarName.TabIndex = 0;
            this.lblFamiliarName.Text = "Nombre:";
            // 
            // txtFamiliarName
            // 
            this.txtFamiliarName.AllowBlankSpaces = false;
            this.txtFamiliarName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtFamiliarName.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.NumbersOrLetters;
            this.txtFamiliarName.CustomExpression = ".*";
            this.txtFamiliarName.EnterColor = System.Drawing.Color.Empty;
            this.txtFamiliarName.LeaveColor = System.Drawing.Color.Empty;
            this.txtFamiliarName.Location = new System.Drawing.Point(148, 332);
            this.txtFamiliarName.MaxLength = 18;
            this.txtFamiliarName.Name = "txtFamiliarName";
            this.txtFamiliarName.Size = new System.Drawing.Size(181, 20);
            this.txtFamiliarName.TabIndex = 8;
            this.txtFamiliarName.TextChanged += new System.EventHandler(this.txtControls_TextChanged);
            this.txtFamiliarName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // lblCountry
            // 
            this.lblCountry.AutoSize = true;
            this.lblCountry.ForeColor = System.Drawing.Color.DarkCyan;
            this.lblCountry.Location = new System.Drawing.Point(23, 366);
            this.lblCountry.Name = "lblCountry";
            this.lblCountry.Size = new System.Drawing.Size(30, 13);
            this.lblCountry.TabIndex = 0;
            this.lblCountry.Text = "Páis:";
            // 
            // txtCountry
            // 
            this.txtCountry.AllowBlankSpaces = false;
            this.txtCountry.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtCountry.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.NumbersOrLetters;
            this.txtCountry.CustomExpression = ".*";
            this.txtCountry.EnterColor = System.Drawing.Color.Empty;
            this.txtCountry.LeaveColor = System.Drawing.Color.Empty;
            this.txtCountry.Location = new System.Drawing.Point(148, 363);
            this.txtCountry.MaxLength = 2;
            this.txtCountry.Name = "txtCountry";
            this.txtCountry.Size = new System.Drawing.Size(25, 20);
            this.txtCountry.TabIndex = 9;
            this.txtCountry.TextChanged += new System.EventHandler(this.txtControls_TextChanged);
            this.txtCountry.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // lblPhone
            // 
            this.lblPhone.AutoSize = true;
            this.lblPhone.ForeColor = System.Drawing.Color.DarkCyan;
            this.lblPhone.Location = new System.Drawing.Point(23, 396);
            this.lblPhone.Name = "lblPhone";
            this.lblPhone.Size = new System.Drawing.Size(52, 13);
            this.lblPhone.TabIndex = 0;
            this.lblPhone.Text = "Telefono:";
            // 
            // txtPhone
            // 
            this.txtPhone.AllowBlankSpaces = false;
            this.txtPhone.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtPhone.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.OnlyNumbers;
            this.txtPhone.CustomExpression = ".*";
            this.txtPhone.EnterColor = System.Drawing.Color.Empty;
            this.txtPhone.LeaveColor = System.Drawing.Color.Empty;
            this.txtPhone.Location = new System.Drawing.Point(148, 393);
            this.txtPhone.MaxLength = 18;
            this.txtPhone.Name = "txtPhone";
            this.txtPhone.Size = new System.Drawing.Size(181, 20);
            this.txtPhone.TabIndex = 10;
            this.txtPhone.TextChanged += new System.EventHandler(this.txtControls_TextChanged);
            this.txtPhone.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // btnAccept
            // 
            this.btnAccept.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnAccept.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAccept.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAccept.Location = new System.Drawing.Point(249, 438);
            this.btnAccept.Name = "btnAccept";
            this.btnAccept.Size = new System.Drawing.Size(100, 23);
            this.btnAccept.TabIndex = 11;
            this.btnAccept.Text = "Aceptar";
            this.btnAccept.UseVisualStyleBackColor = false;
            this.btnAccept.Click += new System.EventHandler(this.btnAccept_Click);
            // 
            // ucInternationalPaxInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.btnAccept);
            this.Controls.Add(this.txtPhone);
            this.Controls.Add(this.lblPhone);
            this.Controls.Add(this.txtCountry);
            this.Controls.Add(this.lblCountry);
            this.Controls.Add(this.txtFamiliarName);
            this.Controls.Add(this.lblFamiliarName);
            this.Controls.Add(this.lblFamilyInfo);
            this.Controls.Add(this.lblFormatDate);
            this.Controls.Add(this.txtNationality);
            this.Controls.Add(this.lblNationality);
            this.Controls.Add(this.txtPassport);
            this.Controls.Add(this.lblPassport);
            this.Controls.Add(this.txtBirthday);
            this.Controls.Add(this.lblBirthday);
            this.Controls.Add(this.txtPaxNumber);
            this.Controls.Add(this.lblPaxNumber);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.txtSurname);
            this.Controls.Add(this.lblsurname);
            this.Controls.Add(this.txtAirline);
            this.Controls.Add(this.lblAirLine1);
            this.Controls.Add(this.lblDescription);
            this.Controls.Add(this.lblTitle);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "ucInternationalPaxInfo";
            this.Size = new System.Drawing.Size(411, 580);
            this.Load += new System.EventHandler(this.ucInternationalPaxInfo_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.Label lblAirLine1;
        private MyCTS.Forms.UI.SmartTextBox txtAirline;
        private System.Windows.Forms.Label lblsurname;
        private MyCTS.Forms.UI.SmartTextBox txtSurname;
        private System.Windows.Forms.Label lblName;
        private MyCTS.Forms.UI.SmartTextBox txtName;
        private System.Windows.Forms.Label lblPaxNumber;
        private MyCTS.Forms.UI.SmartTextBox txtPaxNumber;
        private System.Windows.Forms.Label lblBirthday;
        internal MyCTS.Forms.UI.SmartTextBox txtBirthday;
        private System.Windows.Forms.Label lblPassport;
        private MyCTS.Forms.UI.SmartTextBox txtPassport;
        private System.Windows.Forms.Label lblNationality;
        private MyCTS.Forms.UI.SmartTextBox txtNationality;
        private System.Windows.Forms.Label lblFormatDate;
        private System.Windows.Forms.Label lblFamilyInfo;
        private System.Windows.Forms.Label lblFamiliarName;
        private MyCTS.Forms.UI.SmartTextBox txtFamiliarName;
        private System.Windows.Forms.Label lblCountry;
        private MyCTS.Forms.UI.SmartTextBox txtCountry;
        private System.Windows.Forms.Label lblPhone;
        private MyCTS.Forms.UI.SmartTextBox txtPhone;
        private System.Windows.Forms.Button btnAccept;
    }
}
