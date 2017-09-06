namespace MyCTS.Presentation
{
    partial class ucSecureFlightPassengerData
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
            this.lblSegmentAssign = new System.Windows.Forms.Label();
            this.txtSegmentAssign1 = new MyCTS.Forms.UI.SmartTextBox();
            this.txtSegmentAssign2 = new MyCTS.Forms.UI.SmartTextBox();
            this.txtSegmentAssign3 = new MyCTS.Forms.UI.SmartTextBox();
            this.txtSegmentAssign4 = new MyCTS.Forms.UI.SmartTextBox();
            this.txtSegmentAssign5 = new MyCTS.Forms.UI.SmartTextBox();
            this.txtSegmentAssign6 = new MyCTS.Forms.UI.SmartTextBox();
            this.txtSegmentAssign7 = new MyCTS.Forms.UI.SmartTextBox();
            this.txtSegmentAssign8 = new MyCTS.Forms.UI.SmartTextBox();
            this.chkSegmentAll = new System.Windows.Forms.CheckBox();
            this.lblBirthDay = new System.Windows.Forms.Label();
            this.txtBirthday = new MyCTS.Forms.UI.SmartTextBox();
            this.lblSex = new System.Windows.Forms.Label();
            this.rdoMale = new System.Windows.Forms.RadioButton();
            this.rdoMaleInfant = new System.Windows.Forms.RadioButton();
            this.rdoFemale = new System.Windows.Forms.RadioButton();
            this.rdoFemaleInfant = new System.Windows.Forms.RadioButton();
            this.lblLastName = new System.Windows.Forms.Label();
            this.txtLastName = new MyCTS.Forms.UI.SmartTextBox();
            this.lblFirstName = new System.Windows.Forms.Label();
            this.txtFirstName = new MyCTS.Forms.UI.SmartTextBox();
            this.txtSecondName = new MyCTS.Forms.UI.SmartTextBox();
            this.lblSecondName = new System.Windows.Forms.Label();
            this.lblPositionPassenger = new System.Windows.Forms.Label();
            this.txtPositionPassenger = new MyCTS.Forms.UI.SmartTextBox();
            this.chkAmericanAirLines = new System.Windows.Forms.CheckBox();
            this.lblExampleBirthDate = new System.Windows.Forms.Label();
            this.txtLastName2 = new MyCTS.Forms.UI.SmartTextBox();
            this.lblLastName2 = new System.Windows.Forms.Label();
            this.chkAAandOthers = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(139)))), ((int)(((byte)(208)))));
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(3, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(405, 16);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Securete Flight Passenger Data";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // btnAccept
            // 
            this.btnAccept.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnAccept.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAccept.Location = new System.Drawing.Point(279, 440);
            this.btnAccept.Name = "btnAccept";
            this.btnAccept.Size = new System.Drawing.Size(100, 23);
            this.btnAccept.TabIndex = 22;
            this.btnAccept.Text = "Aceptar";
            this.btnAccept.UseVisualStyleBackColor = false;
            this.btnAccept.Click += new System.EventHandler(this.btnAccept_Click);
            // 
            // lblSegmentAssign
            // 
            this.lblSegmentAssign.AutoSize = true;
            this.lblSegmentAssign.ForeColor = System.Drawing.Color.DarkCyan;
            this.lblSegmentAssign.Location = new System.Drawing.Point(17, 29);
            this.lblSegmentAssign.Name = "lblSegmentAssign";
            this.lblSegmentAssign.Size = new System.Drawing.Size(109, 13);
            this.lblSegmentAssign.TabIndex = 0;
            this.lblSegmentAssign.Text = "Segmentos a asignar:";
            this.lblSegmentAssign.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtSegmentAssign1
            // 
            this.txtSegmentAssign1.AllowBlankSpaces = true;
            this.txtSegmentAssign1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtSegmentAssign1.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.OnlyNumbers;
            this.txtSegmentAssign1.CustomExpression = ".*";
            this.txtSegmentAssign1.EnterColor = System.Drawing.Color.Empty;
            this.txtSegmentAssign1.LeaveColor = System.Drawing.Color.Empty;
            this.txtSegmentAssign1.Location = new System.Drawing.Point(20, 45);
            this.txtSegmentAssign1.MaxLength = 2;
            this.txtSegmentAssign1.Name = "txtSegmentAssign1";
            this.txtSegmentAssign1.NextControl = this.txtSegmentAssign2;
            this.txtSegmentAssign1.Size = new System.Drawing.Size(33, 20);
            this.txtSegmentAssign1.TabIndex = 1;
            this.txtSegmentAssign1.TextChanged += new System.EventHandler(this.txtOption_Changed);
            this.txtSegmentAssign1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // txtSegmentAssign2
            // 
            this.txtSegmentAssign2.AllowBlankSpaces = true;
            this.txtSegmentAssign2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtSegmentAssign2.CharsIncluded = new char[0];
            this.txtSegmentAssign2.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.OnlyNumbers;
            this.txtSegmentAssign2.CustomExpression = ".*";
            this.txtSegmentAssign2.EnterColor = System.Drawing.Color.Empty;
            this.txtSegmentAssign2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.txtSegmentAssign2.LeaveColor = System.Drawing.Color.Empty;
            this.txtSegmentAssign2.Location = new System.Drawing.Point(59, 45);
            this.txtSegmentAssign2.MaxLength = 2;
            this.txtSegmentAssign2.Name = "txtSegmentAssign2";
            this.txtSegmentAssign2.NextControl = this.txtSegmentAssign3;
            this.txtSegmentAssign2.Size = new System.Drawing.Size(33, 20);
            this.txtSegmentAssign2.TabIndex = 2;
            this.txtSegmentAssign2.TextChanged += new System.EventHandler(this.txtOption_Changed);
            this.txtSegmentAssign2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // txtSegmentAssign3
            // 
            this.txtSegmentAssign3.AllowBlankSpaces = true;
            this.txtSegmentAssign3.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtSegmentAssign3.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.OnlyNumbers;
            this.txtSegmentAssign3.CustomExpression = ".*";
            this.txtSegmentAssign3.EnterColor = System.Drawing.Color.Empty;
            this.txtSegmentAssign3.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.txtSegmentAssign3.LeaveColor = System.Drawing.Color.Empty;
            this.txtSegmentAssign3.Location = new System.Drawing.Point(98, 45);
            this.txtSegmentAssign3.MaxLength = 2;
            this.txtSegmentAssign3.Name = "txtSegmentAssign3";
            this.txtSegmentAssign3.NextControl = this.txtSegmentAssign4;
            this.txtSegmentAssign3.Size = new System.Drawing.Size(33, 20);
            this.txtSegmentAssign3.TabIndex = 3;
            this.txtSegmentAssign3.TextChanged += new System.EventHandler(this.txtOption_Changed);
            this.txtSegmentAssign3.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // txtSegmentAssign4
            // 
            this.txtSegmentAssign4.AllowBlankSpaces = true;
            this.txtSegmentAssign4.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtSegmentAssign4.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.OnlyNumbers;
            this.txtSegmentAssign4.CustomExpression = ".*";
            this.txtSegmentAssign4.EnterColor = System.Drawing.Color.Empty;
            this.txtSegmentAssign4.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.txtSegmentAssign4.LeaveColor = System.Drawing.Color.Empty;
            this.txtSegmentAssign4.Location = new System.Drawing.Point(137, 45);
            this.txtSegmentAssign4.MaxLength = 2;
            this.txtSegmentAssign4.Name = "txtSegmentAssign4";
            this.txtSegmentAssign4.NextControl = this.txtSegmentAssign5;
            this.txtSegmentAssign4.Size = new System.Drawing.Size(33, 20);
            this.txtSegmentAssign4.TabIndex = 4;
            this.txtSegmentAssign4.TextChanged += new System.EventHandler(this.txtOption_Changed);
            this.txtSegmentAssign4.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // txtSegmentAssign5
            // 
            this.txtSegmentAssign5.AllowBlankSpaces = true;
            this.txtSegmentAssign5.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtSegmentAssign5.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.OnlyNumbers;
            this.txtSegmentAssign5.CustomExpression = ".*";
            this.txtSegmentAssign5.EnterColor = System.Drawing.Color.Empty;
            this.txtSegmentAssign5.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.txtSegmentAssign5.LeaveColor = System.Drawing.Color.Empty;
            this.txtSegmentAssign5.Location = new System.Drawing.Point(178, 45);
            this.txtSegmentAssign5.MaxLength = 2;
            this.txtSegmentAssign5.Name = "txtSegmentAssign5";
            this.txtSegmentAssign5.NextControl = this.txtSegmentAssign6;
            this.txtSegmentAssign5.Size = new System.Drawing.Size(33, 20);
            this.txtSegmentAssign5.TabIndex = 5;
            this.txtSegmentAssign5.TextChanged += new System.EventHandler(this.txtOption_Changed);
            this.txtSegmentAssign5.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // txtSegmentAssign6
            // 
            this.txtSegmentAssign6.AllowBlankSpaces = true;
            this.txtSegmentAssign6.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtSegmentAssign6.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.OnlyNumbers;
            this.txtSegmentAssign6.CustomExpression = ".*";
            this.txtSegmentAssign6.EnterColor = System.Drawing.Color.Empty;
            this.txtSegmentAssign6.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.txtSegmentAssign6.LeaveColor = System.Drawing.Color.Empty;
            this.txtSegmentAssign6.Location = new System.Drawing.Point(217, 45);
            this.txtSegmentAssign6.MaxLength = 2;
            this.txtSegmentAssign6.Name = "txtSegmentAssign6";
            this.txtSegmentAssign6.NextControl = this.txtSegmentAssign7;
            this.txtSegmentAssign6.Size = new System.Drawing.Size(33, 20);
            this.txtSegmentAssign6.TabIndex = 6;
            this.txtSegmentAssign6.TextChanged += new System.EventHandler(this.txtOption_Changed);
            this.txtSegmentAssign6.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // txtSegmentAssign7
            // 
            this.txtSegmentAssign7.AllowBlankSpaces = true;
            this.txtSegmentAssign7.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtSegmentAssign7.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.OnlyNumbers;
            this.txtSegmentAssign7.CustomExpression = ".*";
            this.txtSegmentAssign7.EnterColor = System.Drawing.Color.Empty;
            this.txtSegmentAssign7.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.txtSegmentAssign7.LeaveColor = System.Drawing.Color.Empty;
            this.txtSegmentAssign7.Location = new System.Drawing.Point(256, 45);
            this.txtSegmentAssign7.MaxLength = 2;
            this.txtSegmentAssign7.Name = "txtSegmentAssign7";
            this.txtSegmentAssign7.NextControl = this.txtSegmentAssign8;
            this.txtSegmentAssign7.Size = new System.Drawing.Size(33, 20);
            this.txtSegmentAssign7.TabIndex = 7;
            this.txtSegmentAssign7.TextChanged += new System.EventHandler(this.txtOption_Changed);
            this.txtSegmentAssign7.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // txtSegmentAssign8
            // 
            this.txtSegmentAssign8.AllowBlankSpaces = true;
            this.txtSegmentAssign8.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtSegmentAssign8.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.OnlyNumbers;
            this.txtSegmentAssign8.CustomExpression = ".*";
            this.txtSegmentAssign8.EnterColor = System.Drawing.Color.Empty;
            this.txtSegmentAssign8.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.txtSegmentAssign8.LeaveColor = System.Drawing.Color.Empty;
            this.txtSegmentAssign8.Location = new System.Drawing.Point(295, 45);
            this.txtSegmentAssign8.MaxLength = 2;
            this.txtSegmentAssign8.Name = "txtSegmentAssign8";
            this.txtSegmentAssign8.Size = new System.Drawing.Size(33, 20);
            this.txtSegmentAssign8.TabIndex = 8;
            this.txtSegmentAssign8.TextChanged += new System.EventHandler(this.txtOption_Changed);
            this.txtSegmentAssign8.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // chkSegmentAll
            // 
            this.chkSegmentAll.AutoSize = true;
            this.chkSegmentAll.ForeColor = System.Drawing.Color.DarkCyan;
            this.chkSegmentAll.Location = new System.Drawing.Point(20, 74);
            this.chkSegmentAll.Name = "chkSegmentAll";
            this.chkSegmentAll.Size = new System.Drawing.Size(99, 17);
            this.chkSegmentAll.TabIndex = 9;
            this.chkSegmentAll.Text = "Aplicar a todos ";
            this.chkSegmentAll.UseVisualStyleBackColor = true;
            this.chkSegmentAll.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // lblBirthDay
            // 
            this.lblBirthDay.AutoSize = true;
            this.lblBirthDay.Location = new System.Drawing.Point(20, 99);
            this.lblBirthDay.Name = "lblBirthDay";
            this.lblBirthDay.Size = new System.Drawing.Size(96, 13);
            this.lblBirthDay.TabIndex = 0;
            this.lblBirthDay.Text = "Fecha Nacimiento:";
            // 
            // txtBirthday
            // 
            this.txtBirthday.AllowBlankSpaces = false;
            this.txtBirthday.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtBirthday.CharsIncluded = new char[0];
            this.txtBirthday.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.NumbersOrLetters;
            this.txtBirthday.CustomExpression = ".*";
            this.txtBirthday.EnterColor = System.Drawing.Color.Empty;
            this.txtBirthday.LeaveColor = System.Drawing.Color.Empty;
            this.txtBirthday.Location = new System.Drawing.Point(114, 98);
            this.txtBirthday.MaxLength = 7;
            this.txtBirthday.Name = "txtBirthday";
            this.txtBirthday.Size = new System.Drawing.Size(97, 20);
            this.txtBirthday.TabIndex = 10;
            this.txtBirthday.TextChanged += new System.EventHandler(this.txtBirthday_TextChanged);
            this.txtBirthday.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // lblSex
            // 
            this.lblSex.AutoSize = true;
            this.lblSex.Location = new System.Drawing.Point(23, 121);
            this.lblSex.Name = "lblSex";
            this.lblSex.Size = new System.Drawing.Size(34, 13);
            this.lblSex.TabIndex = 0;
            this.lblSex.Text = "Sexo:";
            // 
            // rdoMale
            // 
            this.rdoMale.AutoSize = true;
            this.rdoMale.Location = new System.Drawing.Point(59, 138);
            this.rdoMale.Name = "rdoMale";
            this.rdoMale.Size = new System.Drawing.Size(73, 17);
            this.rdoMale.TabIndex = 11;
            this.rdoMale.TabStop = true;
            this.rdoMale.Text = "Masculino";
            this.rdoMale.UseVisualStyleBackColor = true;
            this.rdoMale.CheckedChanged += new System.EventHandler(this.rdoMale_CheckedChanged);
            this.rdoMale.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // rdoMaleInfant
            // 
            this.rdoMaleInfant.AutoSize = true;
            this.rdoMaleInfant.Location = new System.Drawing.Point(59, 162);
            this.rdoMaleInfant.Name = "rdoMaleInfant";
            this.rdoMaleInfant.Size = new System.Drawing.Size(109, 17);
            this.rdoMaleInfant.TabIndex = 12;
            this.rdoMaleInfant.TabStop = true;
            this.rdoMaleInfant.Text = "Masculino Infante";
            this.rdoMaleInfant.UseVisualStyleBackColor = true;
            this.rdoMaleInfant.CheckedChanged += new System.EventHandler(this.rdoMaleInfant_CheckedChanged);
            this.rdoMaleInfant.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // rdoFemale
            // 
            this.rdoFemale.AutoSize = true;
            this.rdoFemale.Location = new System.Drawing.Point(59, 186);
            this.rdoFemale.Name = "rdoFemale";
            this.rdoFemale.Size = new System.Drawing.Size(71, 17);
            this.rdoFemale.TabIndex = 13;
            this.rdoFemale.TabStop = true;
            this.rdoFemale.Text = "Femenino";
            this.rdoFemale.UseVisualStyleBackColor = true;
            this.rdoFemale.CheckedChanged += new System.EventHandler(this.rdoFemale_CheckedChanged);
            this.rdoFemale.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // rdoFemaleInfant
            // 
            this.rdoFemaleInfant.AutoSize = true;
            this.rdoFemaleInfant.Location = new System.Drawing.Point(59, 210);
            this.rdoFemaleInfant.Name = "rdoFemaleInfant";
            this.rdoFemaleInfant.Size = new System.Drawing.Size(107, 17);
            this.rdoFemaleInfant.TabIndex = 14;
            this.rdoFemaleInfant.TabStop = true;
            this.rdoFemaleInfant.Text = "Femenino Infante";
            this.rdoFemaleInfant.UseVisualStyleBackColor = true;
            this.rdoFemaleInfant.CheckedChanged += new System.EventHandler(this.rdoFemaleInfant_CheckedChanged);
            this.rdoFemaleInfant.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // lblLastName
            // 
            this.lblLastName.AutoSize = true;
            this.lblLastName.ForeColor = System.Drawing.Color.Black;
            this.lblLastName.Location = new System.Drawing.Point(17, 250);
            this.lblLastName.Name = "lblLastName";
            this.lblLastName.Size = new System.Drawing.Size(87, 13);
            this.lblLastName.TabIndex = 0;
            this.lblLastName.Text = "Apellido Paterno:";
            // 
            // txtLastName
            // 
            this.txtLastName.AllowBlankSpaces = true;
            this.txtLastName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtLastName.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.OnlyLetters;
            this.txtLastName.CustomExpression = ".*";
            this.txtLastName.EnterColor = System.Drawing.Color.Empty;
            this.txtLastName.LeaveColor = System.Drawing.Color.Empty;
            this.txtLastName.Location = new System.Drawing.Point(114, 247);
            this.txtLastName.MaxLength = 20;
            this.txtLastName.Name = "txtLastName";
            this.txtLastName.Size = new System.Drawing.Size(183, 20);
            this.txtLastName.TabIndex = 15;
            this.txtLastName.TextChanged += new System.EventHandler(this.txtLastName_TextChanged);
            this.txtLastName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // lblFirstName
            // 
            this.lblFirstName.AutoSize = true;
            this.lblFirstName.Location = new System.Drawing.Point(17, 298);
            this.lblFirstName.Name = "lblFirstName";
            this.lblFirstName.Size = new System.Drawing.Size(79, 13);
            this.lblFirstName.TabIndex = 0;
            this.lblFirstName.Text = "Primer Nombre:";
            // 
            // txtFirstName
            // 
            this.txtFirstName.AllowBlankSpaces = true;
            this.txtFirstName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtFirstName.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.OnlyLetters;
            this.txtFirstName.CustomExpression = ".*";
            this.txtFirstName.EnterColor = System.Drawing.Color.Empty;
            this.txtFirstName.LeaveColor = System.Drawing.Color.Empty;
            this.txtFirstName.Location = new System.Drawing.Point(114, 295);
            this.txtFirstName.MaxLength = 20;
            this.txtFirstName.Name = "txtFirstName";
            this.txtFirstName.Size = new System.Drawing.Size(183, 20);
            this.txtFirstName.TabIndex = 17;
            this.txtFirstName.TextChanged += new System.EventHandler(this.txtFirstName_TextChanged);
            this.txtFirstName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // txtSecondName
            // 
            this.txtSecondName.AllowBlankSpaces = true;
            this.txtSecondName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtSecondName.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.OnlyLetters;
            this.txtSecondName.CustomExpression = ".*";
            this.txtSecondName.EnterColor = System.Drawing.Color.Empty;
            this.txtSecondName.LeaveColor = System.Drawing.Color.Empty;
            this.txtSecondName.Location = new System.Drawing.Point(114, 321);
            this.txtSecondName.MaxLength = 20;
            this.txtSecondName.Name = "txtSecondName";
            this.txtSecondName.Size = new System.Drawing.Size(183, 20);
            this.txtSecondName.TabIndex = 18;
            this.txtSecondName.TextChanged += new System.EventHandler(this.txtSecondName_TextChanged);
            this.txtSecondName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // lblSecondName
            // 
            this.lblSecondName.AutoSize = true;
            this.lblSecondName.ForeColor = System.Drawing.Color.DarkCyan;
            this.lblSecondName.Location = new System.Drawing.Point(17, 324);
            this.lblSecondName.Name = "lblSecondName";
            this.lblSecondName.Size = new System.Drawing.Size(93, 13);
            this.lblSecondName.TabIndex = 0;
            this.lblSecondName.Text = "Segundo Nombre:";
            // 
            // lblPositionPassenger
            // 
            this.lblPositionPassenger.AutoSize = true;
            this.lblPositionPassenger.Location = new System.Drawing.Point(17, 350);
            this.lblPositionPassenger.Name = "lblPositionPassenger";
            this.lblPositionPassenger.Size = new System.Drawing.Size(94, 13);
            this.lblPositionPassenger.TabIndex = 0;
            this.lblPositionPassenger.Text = "Posición Pasajero:";
            // 
            // txtPositionPassenger
            // 
            this.txtPositionPassenger.AllowBlankSpaces = false;
            this.txtPositionPassenger.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtPositionPassenger.CharsIncluded = new char[] {
        '.'};
            this.txtPositionPassenger.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.OnlyNumbers;
            this.txtPositionPassenger.CustomExpression = ".*";
            this.txtPositionPassenger.EnterColor = System.Drawing.Color.Empty;
            this.txtPositionPassenger.LeaveColor = System.Drawing.Color.Empty;
            this.txtPositionPassenger.Location = new System.Drawing.Point(114, 347);
            this.txtPositionPassenger.MaxLength = 4;
            this.txtPositionPassenger.Name = "txtPositionPassenger";
            this.txtPositionPassenger.Size = new System.Drawing.Size(52, 20);
            this.txtPositionPassenger.TabIndex = 19;
            this.txtPositionPassenger.TextChanged += new System.EventHandler(this.txtPositionPassenger_TextChanged);
            this.txtPositionPassenger.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // chkAmericanAirLines
            // 
            this.chkAmericanAirLines.AutoSize = true;
            this.chkAmericanAirLines.ForeColor = System.Drawing.Color.DarkCyan;
            this.chkAmericanAirLines.Location = new System.Drawing.Point(20, 378);
            this.chkAmericanAirLines.Name = "chkAmericanAirLines";
            this.chkAmericanAirLines.Size = new System.Drawing.Size(181, 17);
            this.chkAmericanAirLines.TabIndex = 20;
            this.chkAmericanAirLines.Text = "¿Aplicar para American AirLines?";
            this.chkAmericanAirLines.UseVisualStyleBackColor = true;
            this.chkAmericanAirLines.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // lblExampleBirthDate
            // 
            this.lblExampleBirthDate.AutoSize = true;
            this.lblExampleBirthDate.Location = new System.Drawing.Point(214, 101);
            this.lblExampleBirthDate.Name = "lblExampleBirthDate";
            this.lblExampleBirthDate.Size = new System.Drawing.Size(67, 13);
            this.lblExampleBirthDate.TabIndex = 21;
            this.lblExampleBirthDate.Text = "Ej. 10JUN02";
            this.lblExampleBirthDate.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtLastName2
            // 
            this.txtLastName2.AllowBlankSpaces = true;
            this.txtLastName2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtLastName2.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.OnlyLetters;
            this.txtLastName2.CustomExpression = ".*";
            this.txtLastName2.EnterColor = System.Drawing.Color.Empty;
            this.txtLastName2.LeaveColor = System.Drawing.Color.Empty;
            this.txtLastName2.Location = new System.Drawing.Point(114, 271);
            this.txtLastName2.MaxLength = 20;
            this.txtLastName2.Name = "txtLastName2";
            this.txtLastName2.Size = new System.Drawing.Size(183, 20);
            this.txtLastName2.TabIndex = 16;
            this.txtLastName2.TextChanged += new System.EventHandler(this.txtLastName2_TextChanged);
            // 
            // lblLastName2
            // 
            this.lblLastName2.AutoSize = true;
            this.lblLastName2.ForeColor = System.Drawing.Color.DarkCyan;
            this.lblLastName2.Location = new System.Drawing.Point(17, 274);
            this.lblLastName2.Name = "lblLastName2";
            this.lblLastName2.Size = new System.Drawing.Size(89, 13);
            this.lblLastName2.TabIndex = 22;
            this.lblLastName2.Text = "Apellido Materno:";
            // 
            // chkAAandOthers
            // 
            this.chkAAandOthers.AutoSize = true;
            this.chkAAandOthers.ForeColor = System.Drawing.Color.DarkCyan;
            this.chkAAandOthers.Location = new System.Drawing.Point(20, 402);
            this.chkAAandOthers.Name = "chkAAandOthers";
            this.chkAAandOthers.Size = new System.Drawing.Size(271, 17);
            this.chkAAandOthers.TabIndex = 21;
            this.chkAAandOthers.Text = "¿Aplicar para American AirLines y Otras Aerolíneas?";
            this.chkAAandOthers.UseVisualStyleBackColor = true;
            // 
            // ucSecureFlightPassengerData
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.chkAAandOthers);
            this.Controls.Add(this.txtLastName2);
            this.Controls.Add(this.lblLastName2);
            this.Controls.Add(this.lblExampleBirthDate);
            this.Controls.Add(this.chkAmericanAirLines);
            this.Controls.Add(this.txtPositionPassenger);
            this.Controls.Add(this.lblPositionPassenger);
            this.Controls.Add(this.lblSecondName);
            this.Controls.Add(this.txtSecondName);
            this.Controls.Add(this.txtFirstName);
            this.Controls.Add(this.lblFirstName);
            this.Controls.Add(this.txtLastName);
            this.Controls.Add(this.lblLastName);
            this.Controls.Add(this.rdoFemaleInfant);
            this.Controls.Add(this.rdoFemale);
            this.Controls.Add(this.rdoMaleInfant);
            this.Controls.Add(this.rdoMale);
            this.Controls.Add(this.lblSex);
            this.Controls.Add(this.txtBirthday);
            this.Controls.Add(this.lblBirthDay);
            this.Controls.Add(this.chkSegmentAll);
            this.Controls.Add(this.txtSegmentAssign1);
            this.Controls.Add(this.txtSegmentAssign2);
            this.Controls.Add(this.txtSegmentAssign3);
            this.Controls.Add(this.txtSegmentAssign4);
            this.Controls.Add(this.txtSegmentAssign5);
            this.Controls.Add(this.txtSegmentAssign6);
            this.Controls.Add(this.txtSegmentAssign7);
            this.Controls.Add(this.txtSegmentAssign8);
            this.Controls.Add(this.lblSegmentAssign);
            this.Controls.Add(this.btnAccept);
            this.Controls.Add(this.lblTitle);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "ucSecureFlightPassengerData";
            this.Size = new System.Drawing.Size(411, 580);
            this.Load += new System.EventHandler(this.ucSecureFlightPassengerData_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Button btnAccept;
        private System.Windows.Forms.Label lblSegmentAssign;
        private MyCTS.Forms.UI.SmartTextBox txtSegmentAssign1;
        private MyCTS.Forms.UI.SmartTextBox txtSegmentAssign2;
        private MyCTS.Forms.UI.SmartTextBox txtSegmentAssign3;
        private MyCTS.Forms.UI.SmartTextBox txtSegmentAssign4;
        private MyCTS.Forms.UI.SmartTextBox txtSegmentAssign5;
        private MyCTS.Forms.UI.SmartTextBox txtSegmentAssign6;
        private MyCTS.Forms.UI.SmartTextBox txtSegmentAssign7;
        private MyCTS.Forms.UI.SmartTextBox txtSegmentAssign8;
        private System.Windows.Forms.CheckBox chkSegmentAll;
        private System.Windows.Forms.Label lblBirthDay;
        private MyCTS.Forms.UI.SmartTextBox txtBirthday;
        private System.Windows.Forms.Label lblSex;
        private System.Windows.Forms.RadioButton rdoMale;
        private System.Windows.Forms.RadioButton rdoMaleInfant;
        private System.Windows.Forms.RadioButton rdoFemale;
        private System.Windows.Forms.RadioButton rdoFemaleInfant;
        private System.Windows.Forms.Label lblLastName;
        private MyCTS.Forms.UI.SmartTextBox txtLastName;
        private System.Windows.Forms.Label lblFirstName;
        private MyCTS.Forms.UI.SmartTextBox txtFirstName;
        private MyCTS.Forms.UI.SmartTextBox txtSecondName;
        private System.Windows.Forms.Label lblSecondName;
        private System.Windows.Forms.Label lblPositionPassenger;
        private MyCTS.Forms.UI.SmartTextBox txtPositionPassenger;
        private System.Windows.Forms.CheckBox chkAmericanAirLines;
        private System.Windows.Forms.Label lblExampleBirthDate;
        private MyCTS.Forms.UI.SmartTextBox txtLastName2;
        private System.Windows.Forms.Label lblLastName2;
        private System.Windows.Forms.CheckBox chkAAandOthers;
    }
}
