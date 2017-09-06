namespace MyCTS.Presentation
{
    partial class ucAPISPassportMessage
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
            this.btnAccept = new System.Windows.Forms.Button();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblSegments = new System.Windows.Forms.Label();
            this.lblEmissionCountry = new System.Windows.Forms.Label();
            this.lblPassaportNumber = new System.Windows.Forms.Label();
            this.lblNationality = new System.Windows.Forms.Label();
            this.lblBirthday = new System.Windows.Forms.Label();
            this.lblSex = new System.Windows.Forms.Label();
            this.lblDateExpired = new System.Windows.Forms.Label();
            this.lblLastName = new System.Windows.Forms.Label();
            this.lblFirstName = new System.Windows.Forms.Label();
            this.lblSecondName = new System.Windows.Forms.Label();
            this.lblNumberPax = new System.Windows.Forms.Label();
            this.txtSegment1 = new MyCTS.Forms.UI.SmartTextBox();
            this.txtSegment4 = new MyCTS.Forms.UI.SmartTextBox();
            this.txtSegment3 = new MyCTS.Forms.UI.SmartTextBox();
            this.txtSegment2 = new MyCTS.Forms.UI.SmartTextBox();
            this.txtCountryEmission = new MyCTS.Forms.UI.SmartTextBox();
            this.txtPassportNumber = new MyCTS.Forms.UI.SmartTextBox();
            this.txtNationality = new MyCTS.Forms.UI.SmartTextBox();
            this.txtBirthday = new MyCTS.Forms.UI.SmartTextBox();
            this.rdoFemale = new System.Windows.Forms.RadioButton();
            this.rdoMale = new System.Windows.Forms.RadioButton();
            this.txtExpiredDate = new MyCTS.Forms.UI.SmartTextBox();
            this.lblDate = new System.Windows.Forms.Label();
            this.txtLastName = new MyCTS.Forms.UI.SmartTextBox();
            this.txtFirstName = new MyCTS.Forms.UI.SmartTextBox();
            this.txtSecondName = new MyCTS.Forms.UI.SmartTextBox();
            this.txtNumberPax = new MyCTS.Forms.UI.SmartTextBox();
            this.lblExpirated = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnAccept
            // 
            this.btnAccept.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnAccept.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAccept.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAccept.Location = new System.Drawing.Point(248, 401);
            this.btnAccept.Name = "btnAccept";
            this.btnAccept.Size = new System.Drawing.Size(100, 23);
            this.btnAccept.TabIndex = 16;
            this.btnAccept.Text = "Aceptar";
            this.btnAccept.UseVisualStyleBackColor = false;
            this.btnAccept.Click += new System.EventHandler(this.btnAccept_Click);
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
            this.lblTitle.Text = "Mensaje SSR: APIS Pasaporte";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblSegments
            // 
            this.lblSegments.AutoSize = true;
            this.lblSegments.Location = new System.Drawing.Point(24, 40);
            this.lblSegments.Name = "lblSegments";
            this.lblSegments.Size = new System.Drawing.Size(63, 13);
            this.lblSegments.TabIndex = 0;
            this.lblSegments.Text = "Segmentos:";
            // 
            // lblEmissionCountry
            // 
            this.lblEmissionCountry.AutoSize = true;
            this.lblEmissionCountry.Location = new System.Drawing.Point(24, 72);
            this.lblEmissionCountry.Name = "lblEmissionCountry";
            this.lblEmissionCountry.Size = new System.Drawing.Size(86, 13);
            this.lblEmissionCountry.TabIndex = 0;
            this.lblEmissionCountry.Text = "País de Emisión:";
            // 
            // lblPassaportNumber
            // 
            this.lblPassaportNumber.AutoSize = true;
            this.lblPassaportNumber.Location = new System.Drawing.Point(24, 106);
            this.lblPassaportNumber.Name = "lblPassaportNumber";
            this.lblPassaportNumber.Size = new System.Drawing.Size(113, 13);
            this.lblPassaportNumber.TabIndex = 0;
            this.lblPassaportNumber.Text = "Número de Pasaporte:";
            // 
            // lblNationality
            // 
            this.lblNationality.AutoSize = true;
            this.lblNationality.Location = new System.Drawing.Point(24, 135);
            this.lblNationality.Name = "lblNationality";
            this.lblNationality.Size = new System.Drawing.Size(72, 13);
            this.lblNationality.TabIndex = 0;
            this.lblNationality.Text = "Nacionalidad:";
            // 
            // lblBirthday
            // 
            this.lblBirthday.AutoSize = true;
            this.lblBirthday.Location = new System.Drawing.Point(24, 164);
            this.lblBirthday.Name = "lblBirthday";
            this.lblBirthday.Size = new System.Drawing.Size(111, 13);
            this.lblBirthday.TabIndex = 0;
            this.lblBirthday.Text = "Fecha de Nacimiento:";
            // 
            // lblSex
            // 
            this.lblSex.AutoSize = true;
            this.lblSex.Location = new System.Drawing.Point(24, 196);
            this.lblSex.Name = "lblSex";
            this.lblSex.Size = new System.Drawing.Size(34, 13);
            this.lblSex.TabIndex = 0;
            this.lblSex.Text = "Sexo:";
            // 
            // lblDateExpired
            // 
            this.lblDateExpired.AutoSize = true;
            this.lblDateExpired.Location = new System.Drawing.Point(24, 221);
            this.lblDateExpired.Name = "lblDateExpired";
            this.lblDateExpired.Size = new System.Drawing.Size(107, 13);
            this.lblDateExpired.TabIndex = 0;
            this.lblDateExpired.Text = "Fecha de Expiración:";
            // 
            // lblLastName
            // 
            this.lblLastName.AutoSize = true;
            this.lblLastName.Location = new System.Drawing.Point(24, 252);
            this.lblLastName.Name = "lblLastName";
            this.lblLastName.Size = new System.Drawing.Size(44, 13);
            this.lblLastName.TabIndex = 0;
            this.lblLastName.Text = "Apellido";
            // 
            // lblFirstName
            // 
            this.lblFirstName.AutoSize = true;
            this.lblFirstName.Location = new System.Drawing.Point(24, 282);
            this.lblFirstName.Name = "lblFirstName";
            this.lblFirstName.Size = new System.Drawing.Size(82, 13);
            this.lblFirstName.TabIndex = 0;
            this.lblFirstName.Text = "Primero Nombre";
            // 
            // lblSecondName
            // 
            this.lblSecondName.AutoSize = true;
            this.lblSecondName.ForeColor = System.Drawing.Color.DarkCyan;
            this.lblSecondName.Location = new System.Drawing.Point(24, 312);
            this.lblSecondName.Name = "lblSecondName";
            this.lblSecondName.Size = new System.Drawing.Size(123, 13);
            this.lblSecondName.TabIndex = 0;
            this.lblSecondName.Text = "Inicial Segundo Nombre:";
            // 
            // lblNumberPax
            // 
            this.lblNumberPax.AutoSize = true;
            this.lblNumberPax.Location = new System.Drawing.Point(24, 341);
            this.lblNumberPax.Name = "lblNumberPax";
            this.lblNumberPax.Size = new System.Drawing.Size(71, 13);
            this.lblNumberPax.TabIndex = 0;
            this.lblNumberPax.Text = "Num. de Pax:";
            // 
            // txtSegment1
            // 
            this.txtSegment1.AllowBlankSpaces = false;
            this.txtSegment1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtSegment1.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.OnlyNumbers;
            this.txtSegment1.CustomExpression = ".*";
            this.txtSegment1.EnterColor = System.Drawing.Color.Empty;
            this.txtSegment1.LeaveColor = System.Drawing.Color.Empty;
            this.txtSegment1.Location = new System.Drawing.Point(168, 37);
            this.txtSegment1.MaxLength = 2;
            this.txtSegment1.Name = "txtSegment1";
            this.txtSegment1.Size = new System.Drawing.Size(25, 20);
            this.txtSegment1.TabIndex = 1;
            this.txtSegment1.TextChanged += new System.EventHandler(this.txtSegment1_TextChanged);
            this.txtSegment1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // txtSegment4
            // 
            this.txtSegment4.AllowBlankSpaces = false;
            this.txtSegment4.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtSegment4.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.OnlyNumbers;
            this.txtSegment4.CustomExpression = ".*";
            this.txtSegment4.EnterColor = System.Drawing.Color.Empty;
            this.txtSegment4.LeaveColor = System.Drawing.Color.Empty;
            this.txtSegment4.Location = new System.Drawing.Point(289, 37);
            this.txtSegment4.MaxLength = 2;
            this.txtSegment4.Name = "txtSegment4";
            this.txtSegment4.Size = new System.Drawing.Size(25, 20);
            this.txtSegment4.TabIndex = 4;
            this.txtSegment4.TextChanged += new System.EventHandler(this.txtSegment4_TextChanged);
            this.txtSegment4.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // txtSegment3
            // 
            this.txtSegment3.AllowBlankSpaces = false;
            this.txtSegment3.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtSegment3.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.OnlyNumbers;
            this.txtSegment3.CustomExpression = ".*";
            this.txtSegment3.EnterColor = System.Drawing.Color.Empty;
            this.txtSegment3.LeaveColor = System.Drawing.Color.Empty;
            this.txtSegment3.Location = new System.Drawing.Point(249, 37);
            this.txtSegment3.MaxLength = 2;
            this.txtSegment3.Name = "txtSegment3";
            this.txtSegment3.Size = new System.Drawing.Size(25, 20);
            this.txtSegment3.TabIndex = 3;
            this.txtSegment3.TextChanged += new System.EventHandler(this.txtSegment3_TextChanged);
            this.txtSegment3.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // txtSegment2
            // 
            this.txtSegment2.AllowBlankSpaces = false;
            this.txtSegment2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtSegment2.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.OnlyNumbers;
            this.txtSegment2.CustomExpression = ".*";
            this.txtSegment2.EnterColor = System.Drawing.Color.Empty;
            this.txtSegment2.LeaveColor = System.Drawing.Color.Empty;
            this.txtSegment2.Location = new System.Drawing.Point(209, 37);
            this.txtSegment2.MaxLength = 2;
            this.txtSegment2.Name = "txtSegment2";
            this.txtSegment2.Size = new System.Drawing.Size(25, 20);
            this.txtSegment2.TabIndex = 2;
            this.txtSegment2.TextChanged += new System.EventHandler(this.txtSegment2_TextChanged);
            this.txtSegment2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // txtCountryEmission
            // 
            this.txtCountryEmission.AllowBlankSpaces = false;
            this.txtCountryEmission.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtCountryEmission.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.OnlyLetters;
            this.txtCountryEmission.CustomExpression = ".*";
            this.txtCountryEmission.EnterColor = System.Drawing.Color.Empty;
            this.txtCountryEmission.LeaveColor = System.Drawing.Color.Empty;
            this.txtCountryEmission.Location = new System.Drawing.Point(168, 65);
            this.txtCountryEmission.MaxLength = 2;
            this.txtCountryEmission.Name = "txtCountryEmission";
            this.txtCountryEmission.Size = new System.Drawing.Size(25, 20);
            this.txtCountryEmission.TabIndex = 5;
            this.txtCountryEmission.TextChanged += new System.EventHandler(this.txtCountryEmission_TextChanged);
            this.txtCountryEmission.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // txtPassportNumber
            // 
            this.txtPassportNumber.AllowBlankSpaces = false;
            this.txtPassportNumber.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtPassportNumber.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.NumbersOrLetters;
            this.txtPassportNumber.CustomExpression = ".*";
            this.txtPassportNumber.EnterColor = System.Drawing.Color.Empty;
            this.txtPassportNumber.LeaveColor = System.Drawing.Color.Empty;
            this.txtPassportNumber.Location = new System.Drawing.Point(168, 99);
            this.txtPassportNumber.MaxLength = 12;
            this.txtPassportNumber.Name = "txtPassportNumber";
            this.txtPassportNumber.Size = new System.Drawing.Size(146, 20);
            this.txtPassportNumber.TabIndex = 6;
            this.txtPassportNumber.TextChanged += new System.EventHandler(this.txtPassportNumber_TextChanged);
            this.txtPassportNumber.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // txtNationality
            // 
            this.txtNationality.AllowBlankSpaces = false;
            this.txtNationality.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtNationality.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.OnlyLetters;
            this.txtNationality.CustomExpression = ".*";
            this.txtNationality.EnterColor = System.Drawing.Color.Empty;
            this.txtNationality.LeaveColor = System.Drawing.Color.Empty;
            this.txtNationality.Location = new System.Drawing.Point(168, 128);
            this.txtNationality.MaxLength = 2;
            this.txtNationality.Name = "txtNationality";
            this.txtNationality.Size = new System.Drawing.Size(25, 20);
            this.txtNationality.TabIndex = 7;
            this.txtNationality.TextChanged += new System.EventHandler(this.txtNationality_TextChanged);
            this.txtNationality.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // txtBirthday
            // 
            this.txtBirthday.AllowBlankSpaces = false;
            this.txtBirthday.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtBirthday.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.NumbersOrLetters;
            this.txtBirthday.CustomExpression = ".*";
            this.txtBirthday.EnterColor = System.Drawing.Color.Empty;
            this.txtBirthday.LeaveColor = System.Drawing.Color.Empty;
            this.txtBirthday.Location = new System.Drawing.Point(168, 157);
            this.txtBirthday.MaxLength = 7;
            this.txtBirthday.Name = "txtBirthday";
            this.txtBirthday.NextControl = this.rdoFemale;
            this.txtBirthday.Size = new System.Drawing.Size(79, 20);
            this.txtBirthday.TabIndex = 8;
            this.txtBirthday.TextChanged += new System.EventHandler(this.txtBirthday_TextChanged);
            this.txtBirthday.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            this.txtBirthday.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtBirthday_KeyUp);
            // 
            // rdoFemale
            // 
            this.rdoFemale.AutoSize = true;
            this.rdoFemale.Location = new System.Drawing.Point(168, 191);
            this.rdoFemale.Name = "rdoFemale";
            this.rdoFemale.Size = new System.Drawing.Size(71, 17);
            this.rdoFemale.TabIndex = 9;
            this.rdoFemale.TabStop = true;
            this.rdoFemale.Text = "Femenino";
            this.rdoFemale.UseVisualStyleBackColor = true;
            this.rdoFemale.KeyUp += new System.Windows.Forms.KeyEventHandler(this.rdoFemale_KeyUp);
            this.rdoFemale.CheckedChanged += new System.EventHandler(this.rdoFemale_CheckedChanged);
            this.rdoFemale.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // rdoMale
            // 
            this.rdoMale.AutoSize = true;
            this.rdoMale.Location = new System.Drawing.Point(241, 191);
            this.rdoMale.Name = "rdoMale";
            this.rdoMale.Size = new System.Drawing.Size(73, 17);
            this.rdoMale.TabIndex = 10;
            this.rdoMale.TabStop = true;
            this.rdoMale.Text = "Masculino";
            this.rdoMale.UseVisualStyleBackColor = true;
            this.rdoMale.KeyUp += new System.Windows.Forms.KeyEventHandler(this.rdoMale_KeyUp);
            this.rdoMale.CheckedChanged += new System.EventHandler(this.rdoMale_CheckedChanged);
            this.rdoMale.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // txtExpiredDate
            // 
            this.txtExpiredDate.AllowBlankSpaces = false;
            this.txtExpiredDate.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtExpiredDate.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.NumbersOrLetters;
            this.txtExpiredDate.CustomExpression = ".*";
            this.txtExpiredDate.EnterColor = System.Drawing.Color.Empty;
            this.txtExpiredDate.LeaveColor = System.Drawing.Color.Empty;
            this.txtExpiredDate.Location = new System.Drawing.Point(168, 218);
            this.txtExpiredDate.MaxLength = 7;
            this.txtExpiredDate.Name = "txtExpiredDate";
            this.txtExpiredDate.Size = new System.Drawing.Size(79, 20);
            this.txtExpiredDate.TabIndex = 11;
            this.txtExpiredDate.TextChanged += new System.EventHandler(this.txtExpiredDate_TextChanged);
            this.txtExpiredDate.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.ForeColor = System.Drawing.Color.Blue;
            this.lblDate.Location = new System.Drawing.Point(253, 160);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(64, 13);
            this.lblDate.TabIndex = 0;
            this.lblDate.Text = "DDMMMYY";
            // 
            // txtLastName
            // 
            this.txtLastName.AllowBlankSpaces = false;
            this.txtLastName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtLastName.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.OnlyLetters;
            this.txtLastName.CustomExpression = ".*";
            this.txtLastName.EnterColor = System.Drawing.Color.Empty;
            this.txtLastName.LeaveColor = System.Drawing.Color.Empty;
            this.txtLastName.Location = new System.Drawing.Point(168, 249);
            this.txtLastName.MaxLength = 15;
            this.txtLastName.Name = "txtLastName";
            this.txtLastName.Size = new System.Drawing.Size(106, 20);
            this.txtLastName.TabIndex = 12;
            this.txtLastName.TextChanged += new System.EventHandler(this.txtLastName_TextChanged);
            this.txtLastName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // txtFirstName
            // 
            this.txtFirstName.AllowBlankSpaces = false;
            this.txtFirstName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtFirstName.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.OnlyLetters;
            this.txtFirstName.CustomExpression = ".*";
            this.txtFirstName.EnterColor = System.Drawing.Color.Empty;
            this.txtFirstName.LeaveColor = System.Drawing.Color.Empty;
            this.txtFirstName.Location = new System.Drawing.Point(168, 279);
            this.txtFirstName.MaxLength = 15;
            this.txtFirstName.Name = "txtFirstName";
            this.txtFirstName.Size = new System.Drawing.Size(106, 20);
            this.txtFirstName.TabIndex = 13;
            this.txtFirstName.TextChanged += new System.EventHandler(this.txtFirstName_TextChanged);
            this.txtFirstName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // txtSecondName
            // 
            this.txtSecondName.AllowBlankSpaces = false;
            this.txtSecondName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtSecondName.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.OnlyLetters;
            this.txtSecondName.CustomExpression = ".*";
            this.txtSecondName.EnterColor = System.Drawing.Color.Empty;
            this.txtSecondName.LeaveColor = System.Drawing.Color.Empty;
            this.txtSecondName.Location = new System.Drawing.Point(168, 308);
            this.txtSecondName.MaxLength = 1;
            this.txtSecondName.Name = "txtSecondName";
            this.txtSecondName.Size = new System.Drawing.Size(25, 20);
            this.txtSecondName.TabIndex = 14;
            this.txtSecondName.TextChanged += new System.EventHandler(this.txtSecondName_TextChanged);
            this.txtSecondName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // txtNumberPax
            // 
            this.txtNumberPax.AllowBlankSpaces = false;
            this.txtNumberPax.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtNumberPax.CharsIncluded = new char[] {
        '.'};
            this.txtNumberPax.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.OnlyNumbers;
            this.txtNumberPax.CustomExpression = ".*";
            this.txtNumberPax.EnterColor = System.Drawing.Color.Empty;
            this.txtNumberPax.LeaveColor = System.Drawing.Color.Empty;
            this.txtNumberPax.Location = new System.Drawing.Point(168, 337);
            this.txtNumberPax.MaxLength = 4;
            this.txtNumberPax.Name = "txtNumberPax";
            this.txtNumberPax.Size = new System.Drawing.Size(44, 20);
            this.txtNumberPax.TabIndex = 15;
            this.txtNumberPax.TextChanged += new System.EventHandler(this.txtNumberPax_TextChanged);
            this.txtNumberPax.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // lblExpirated
            // 
            this.lblExpirated.AutoSize = true;
            this.lblExpirated.ForeColor = System.Drawing.Color.Blue;
            this.lblExpirated.Location = new System.Drawing.Point(253, 218);
            this.lblExpirated.Name = "lblExpirated";
            this.lblExpirated.Size = new System.Drawing.Size(64, 13);
            this.lblExpirated.TabIndex = 0;
            this.lblExpirated.Text = "DDMMMYY";
            // 
            // ucAPISPassportMessage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.lblExpirated);
            this.Controls.Add(this.txtNumberPax);
            this.Controls.Add(this.txtSecondName);
            this.Controls.Add(this.txtFirstName);
            this.Controls.Add(this.txtLastName);
            this.Controls.Add(this.lblDate);
            this.Controls.Add(this.txtExpiredDate);
            this.Controls.Add(this.rdoMale);
            this.Controls.Add(this.rdoFemale);
            this.Controls.Add(this.txtBirthday);
            this.Controls.Add(this.txtNationality);
            this.Controls.Add(this.txtPassportNumber);
            this.Controls.Add(this.txtCountryEmission);
            this.Controls.Add(this.txtSegment2);
            this.Controls.Add(this.txtSegment3);
            this.Controls.Add(this.txtSegment4);
            this.Controls.Add(this.txtSegment1);
            this.Controls.Add(this.lblNumberPax);
            this.Controls.Add(this.lblSecondName);
            this.Controls.Add(this.lblFirstName);
            this.Controls.Add(this.lblLastName);
            this.Controls.Add(this.lblDateExpired);
            this.Controls.Add(this.lblSex);
            this.Controls.Add(this.lblBirthday);
            this.Controls.Add(this.lblNationality);
            this.Controls.Add(this.lblPassaportNumber);
            this.Controls.Add(this.lblEmissionCountry);
            this.Controls.Add(this.lblSegments);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.btnAccept);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "ucAPISPassportMessage";
            this.Size = new System.Drawing.Size(411, 580);
            this.Load += new System.EventHandler(this.ucAPISPassportMessage_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnAccept;
        internal System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblSegments;
        private System.Windows.Forms.Label lblEmissionCountry;
        private System.Windows.Forms.Label lblPassaportNumber;
        private System.Windows.Forms.Label lblNationality;
        private System.Windows.Forms.Label lblBirthday;
        private System.Windows.Forms.Label lblSex;
        private System.Windows.Forms.Label lblDateExpired;
        private System.Windows.Forms.Label lblLastName;
        private System.Windows.Forms.Label lblFirstName;
        private System.Windows.Forms.Label lblSecondName;
        private System.Windows.Forms.Label lblNumberPax;
        private MyCTS.Forms.UI.SmartTextBox txtSegment1;
        private MyCTS.Forms.UI.SmartTextBox txtSegment4;
        private MyCTS.Forms.UI.SmartTextBox txtSegment3;
        private MyCTS.Forms.UI.SmartTextBox txtSegment2;
        private MyCTS.Forms.UI.SmartTextBox txtCountryEmission;
        private MyCTS.Forms.UI.SmartTextBox txtPassportNumber;
        private MyCTS.Forms.UI.SmartTextBox txtNationality;
        private MyCTS.Forms.UI.SmartTextBox txtBirthday;
        private System.Windows.Forms.RadioButton rdoFemale;
        private System.Windows.Forms.RadioButton rdoMale;
        private MyCTS.Forms.UI.SmartTextBox txtExpiredDate;
        private System.Windows.Forms.Label lblDate;
        private MyCTS.Forms.UI.SmartTextBox txtLastName;
        private MyCTS.Forms.UI.SmartTextBox txtFirstName;
        private MyCTS.Forms.UI.SmartTextBox txtSecondName;
        private MyCTS.Forms.UI.SmartTextBox txtNumberPax;
        private System.Windows.Forms.Label lblExpirated;
    }
}
