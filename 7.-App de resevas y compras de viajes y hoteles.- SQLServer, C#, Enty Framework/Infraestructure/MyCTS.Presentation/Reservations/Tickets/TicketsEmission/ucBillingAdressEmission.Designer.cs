namespace MyCTS.Presentation
{
    partial class ucBillingAdressEmission
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
            this.components = new System.ComponentModel.Container();
            this.lblShow = new System.Windows.Forms.Label();
            this.lblInformative = new System.Windows.Forms.Label();
            this.txtDescription1 = new MyCTS.Forms.UI.SmartTextBox();
            this.txtDescription2 = new MyCTS.Forms.UI.SmartTextBox();
            this.lblDescription = new System.Windows.Forms.Label();
            this.txtRFC3 = new MyCTS.Forms.UI.SmartTextBox();
            this.txtRFC2 = new MyCTS.Forms.UI.SmartTextBox();
            this.txtRFC1 = new MyCTS.Forms.UI.SmartTextBox();
            this.lblRFC = new System.Windows.Forms.Label();
            this.txtState = new MyCTS.Forms.UI.SmartTextBox();
            this.lblState = new System.Windows.Forms.Label();
            this.txtCity = new MyCTS.Forms.UI.SmartTextBox();
            this.lblCity = new System.Windows.Forms.Label();
            this.txtCP = new MyCTS.Forms.UI.SmartTextBox();
            this.txtDelegation = new MyCTS.Forms.UI.SmartTextBox();
            this.lblDelegation = new System.Windows.Forms.Label();
            this.txtColony = new MyCTS.Forms.UI.SmartTextBox();
            this.lblColony = new System.Windows.Forms.Label();
            this.txtNumberInt = new MyCTS.Forms.UI.SmartTextBox();
            this.lblBillingAdress = new System.Windows.Forms.Label();
            this.lblSocialReason = new System.Windows.Forms.Label();
            this.lblStreet = new System.Windows.Forms.Label();
            this.txtSocialReason = new MyCTS.Forms.UI.SmartTextBox();
            this.txtStreet = new MyCTS.Forms.UI.SmartTextBox();
            this.txtNumberExt = new MyCTS.Forms.UI.SmartTextBox();
            this.btnAcept = new System.Windows.Forms.Button();
            this.lblNumberExt = new System.Windows.Forms.Label();
            this.lblNumberInt = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.lblCP = new System.Windows.Forms.Label();
            this.lblCountry = new System.Windows.Forms.Label();
            this.txtCountry = new MyCTS.Forms.UI.SmartTextBox();
            this.lbCountries = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // lblShow
            // 
            this.lblShow.AutoSize = true;
            this.lblShow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblShow.ForeColor = System.Drawing.Color.Blue;
            this.lblShow.Location = new System.Drawing.Point(133, 318);
            this.lblShow.Name = "lblShow";
            this.lblShow.Size = new System.Drawing.Size(114, 19);
            this.lblShow.TabIndex = 0;
            this.lblShow.Text = "IMPORTANTE";
            // 
            // lblInformative
            // 
            this.lblInformative.AutoSize = true;
            this.lblInformative.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInformative.ForeColor = System.Drawing.Color.Blue;
            this.lblInformative.Location = new System.Drawing.Point(7, 347);
            this.lblInformative.Name = "lblInformative";
            this.lblInformative.Size = new System.Drawing.Size(388, 48);
            this.lblInformative.TabIndex = 0;
            this.lblInformative.Text = "Si la dirección del cliente excede los límites en caracteres \r\ndefinidos por polí" +
    "tica, es  necesario  dar  de alta  el DK en \r\nINTEGRA para que la factura salga " +
    "con los datos completos.\r\n";
            // 
            // txtDescription1
            // 
            this.txtDescription1.AllowBlankSpaces = true;
            this.txtDescription1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtDescription1.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.NumbersOrLetters;
            this.txtDescription1.CustomExpression = ".*";
            this.txtDescription1.EnterColor = System.Drawing.Color.Empty;
            this.txtDescription1.LeaveColor = System.Drawing.Color.Empty;
            this.txtDescription1.Location = new System.Drawing.Point(6, 240);
            this.txtDescription1.MaxLength = 50;
            this.txtDescription1.Name = "txtDescription1";
            this.txtDescription1.Size = new System.Drawing.Size(390, 20);
            this.txtDescription1.TabIndex = 14;
            this.txtDescription1.Tag = "";
            this.txtDescription1.TextChanged += new System.EventHandler(this.txtDescription1_TextChanged);
            this.txtDescription1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // txtDescription2
            // 
            this.txtDescription2.AllowBlankSpaces = true;
            this.txtDescription2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtDescription2.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.NumbersOrLetters;
            this.txtDescription2.CustomExpression = ".*";
            this.txtDescription2.EnterColor = System.Drawing.Color.Empty;
            this.txtDescription2.LeaveColor = System.Drawing.Color.Empty;
            this.txtDescription2.Location = new System.Drawing.Point(6, 266);
            this.txtDescription2.MaxLength = 50;
            this.txtDescription2.Name = "txtDescription2";
            this.txtDescription2.Size = new System.Drawing.Size(390, 20);
            this.txtDescription2.TabIndex = 15;
            this.txtDescription2.Tag = "";
            this.txtDescription2.TextChanged += new System.EventHandler(this.txtDescription2_TextChanged);
            this.txtDescription2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.ForeColor = System.Drawing.Color.DarkCyan;
            this.lblDescription.Location = new System.Drawing.Point(6, 223);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(181, 13);
            this.lblDescription.TabIndex = 0;
            this.lblDescription.Text = "Descripción Extendida (Facturación):";
            // 
            // txtRFC3
            // 
            this.txtRFC3.AllowBlankSpaces = true;
            this.txtRFC3.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtRFC3.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.NumbersOrLetters;
            this.txtRFC3.CustomExpression = ".*";
            this.txtRFC3.EnterColor = System.Drawing.Color.Empty;
            this.txtRFC3.LeaveColor = System.Drawing.Color.Empty;
            this.txtRFC3.Location = new System.Drawing.Point(339, 199);
            this.txtRFC3.MaxLength = 3;
            this.txtRFC3.Name = "txtRFC3";
            this.txtRFC3.Size = new System.Drawing.Size(58, 20);
            this.txtRFC3.TabIndex = 13;
            this.txtRFC3.Tag = "RFC Generico XAXX010101000";
            this.txtRFC3.TextChanged += new System.EventHandler(this.txtRFC3_TextChanged);
            this.txtRFC3.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // txtRFC2
            // 
            this.txtRFC2.AllowBlankSpaces = true;
            this.txtRFC2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtRFC2.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.OnlyNumbers;
            this.txtRFC2.CustomExpression = ".*";
            this.txtRFC2.EnterColor = System.Drawing.Color.Empty;
            this.txtRFC2.LeaveColor = System.Drawing.Color.Empty;
            this.txtRFC2.Location = new System.Drawing.Point(266, 199);
            this.txtRFC2.MaxLength = 6;
            this.txtRFC2.Name = "txtRFC2";
            this.txtRFC2.Size = new System.Drawing.Size(65, 20);
            this.txtRFC2.TabIndex = 12;
            this.txtRFC2.Tag = "RFC Generico XAXX010101000";
            this.txtRFC2.TextChanged += new System.EventHandler(this.txtRFC2_TextChanged);
            this.txtRFC2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // txtRFC1
            // 
            this.txtRFC1.AllowBlankSpaces = true;
            this.txtRFC1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtRFC1.CharsIncluded = new char[0];
            this.txtRFC1.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.OnlyLetters;
            this.txtRFC1.CustomExpression = ".*";
            this.txtRFC1.EnterColor = System.Drawing.Color.Empty;
            this.txtRFC1.LeaveColor = System.Drawing.Color.Empty;
            this.txtRFC1.Location = new System.Drawing.Point(200, 200);
            this.txtRFC1.MaxLength = 4;
            this.txtRFC1.Name = "txtRFC1";
            this.txtRFC1.Size = new System.Drawing.Size(59, 20);
            this.txtRFC1.TabIndex = 11;
            this.txtRFC1.Tag = "RFC Generico XAXX010101000";
            this.txtRFC1.TextChanged += new System.EventHandler(this.txtRFC1_TextChanged);
            this.txtRFC1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // lblRFC
            // 
            this.lblRFC.AutoSize = true;
            this.lblRFC.ForeColor = System.Drawing.Color.Black;
            this.lblRFC.Location = new System.Drawing.Point(199, 184);
            this.lblRFC.Name = "lblRFC";
            this.lblRFC.Size = new System.Drawing.Size(31, 13);
            this.lblRFC.TabIndex = 0;
            this.lblRFC.Text = "RFC:";
            // 
            // txtState
            // 
            this.txtState.AllowBlankSpaces = true;
            this.txtState.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtState.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.NumbersOrLetters;
            this.txtState.CustomExpression = ".*";
            this.txtState.EnterColor = System.Drawing.Color.Empty;
            this.txtState.LeaveColor = System.Drawing.Color.Empty;
            this.txtState.Location = new System.Drawing.Point(6, 199);
            this.txtState.MaxLength = 18;
            this.txtState.Name = "txtState";
            this.txtState.Size = new System.Drawing.Size(145, 20);
            this.txtState.TabIndex = 10;
            this.txtState.TextChanged += new System.EventHandler(this.txtState_TextChanged);
            this.txtState.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // lblState
            // 
            this.lblState.AutoSize = true;
            this.lblState.Location = new System.Drawing.Point(3, 184);
            this.lblState.Name = "lblState";
            this.lblState.Size = new System.Drawing.Size(43, 13);
            this.lblState.TabIndex = 22;
            this.lblState.Text = "Estado:";
            // 
            // txtCity
            // 
            this.txtCity.AllowBlankSpaces = true;
            this.txtCity.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtCity.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.NumbersOrLetters;
            this.txtCity.CustomExpression = ".*";
            this.txtCity.EnterColor = System.Drawing.Color.Empty;
            this.txtCity.LeaveColor = System.Drawing.Color.Empty;
            this.txtCity.Location = new System.Drawing.Point(238, 161);
            this.txtCity.MaxLength = 20;
            this.txtCity.Name = "txtCity";
            this.txtCity.Size = new System.Drawing.Size(149, 20);
            this.txtCity.TabIndex = 9;
            this.txtCity.TextChanged += new System.EventHandler(this.txtCity_TextChanged);
            this.txtCity.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // lblCity
            // 
            this.lblCity.AutoSize = true;
            this.lblCity.Location = new System.Drawing.Point(235, 145);
            this.lblCity.Name = "lblCity";
            this.lblCity.Size = new System.Drawing.Size(43, 13);
            this.lblCity.TabIndex = 0;
            this.lblCity.Text = "Ciudad:";
            // 
            // txtCP
            // 
            this.txtCP.AllowBlankSpaces = true;
            this.txtCP.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtCP.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.OnlyNumbers;
            this.txtCP.CustomExpression = ".*";
            this.txtCP.EnterColor = System.Drawing.Color.Empty;
            this.txtCP.LeaveColor = System.Drawing.Color.Empty;
            this.txtCP.Location = new System.Drawing.Point(6, 161);
            this.txtCP.MaxLength = 6;
            this.txtCP.Name = "txtCP";
            this.txtCP.Size = new System.Drawing.Size(59, 20);
            this.txtCP.TabIndex = 7;
            this.txtCP.TextChanged += new System.EventHandler(this.txtCP_TextChanged);
            this.txtCP.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // txtDelegation
            // 
            this.txtDelegation.AllowBlankSpaces = true;
            this.txtDelegation.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtDelegation.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.NumbersOrLetters;
            this.txtDelegation.CustomExpression = ".*";
            this.txtDelegation.EnterColor = System.Drawing.Color.Empty;
            this.txtDelegation.LeaveColor = System.Drawing.Color.Empty;
            this.txtDelegation.Location = new System.Drawing.Point(84, 161);
            this.txtDelegation.MaxLength = 15;
            this.txtDelegation.Name = "txtDelegation";
            this.txtDelegation.Size = new System.Drawing.Size(115, 20);
            this.txtDelegation.TabIndex = 8;
            this.txtDelegation.TextChanged += new System.EventHandler(this.txtDelegation_TextChanged);
            this.txtDelegation.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // lblDelegation
            // 
            this.lblDelegation.AutoSize = true;
            this.lblDelegation.Location = new System.Drawing.Point(81, 145);
            this.lblDelegation.Name = "lblDelegation";
            this.lblDelegation.Size = new System.Drawing.Size(121, 13);
            this.lblDelegation.TabIndex = 0;
            this.lblDelegation.Text = "Delegación o Municipio:";
            // 
            // txtColony
            // 
            this.txtColony.AllowBlankSpaces = true;
            this.txtColony.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtColony.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.NumbersOrLetters;
            this.txtColony.CustomExpression = ".*";
            this.txtColony.EnterColor = System.Drawing.Color.Empty;
            this.txtColony.LeaveColor = System.Drawing.Color.Empty;
            this.txtColony.Location = new System.Drawing.Point(6, 122);
            this.txtColony.MaxLength = 30;
            this.txtColony.Name = "txtColony";
            this.txtColony.Size = new System.Drawing.Size(221, 20);
            this.txtColony.TabIndex = 5;
            this.txtColony.TextChanged += new System.EventHandler(this.txtColony_TextChanged);
            this.txtColony.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // lblColony
            // 
            this.lblColony.AutoSize = true;
            this.lblColony.Location = new System.Drawing.Point(3, 106);
            this.lblColony.Name = "lblColony";
            this.lblColony.Size = new System.Drawing.Size(45, 13);
            this.lblColony.TabIndex = 0;
            this.lblColony.Text = "Colonia:";
            // 
            // txtNumberInt
            // 
            this.txtNumberInt.AllowBlankSpaces = true;
            this.txtNumberInt.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtNumberInt.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.NumbersOrLetters;
            this.txtNumberInt.CustomExpression = ".*";
            this.txtNumberInt.EnterColor = System.Drawing.Color.Empty;
            this.txtNumberInt.LeaveColor = System.Drawing.Color.Empty;
            this.txtNumberInt.Location = new System.Drawing.Point(238, 83);
            this.txtNumberInt.MaxLength = 5;
            this.txtNumberInt.Name = "txtNumberInt";
            this.txtNumberInt.Size = new System.Drawing.Size(60, 20);
            this.txtNumberInt.TabIndex = 4;
            this.txtNumberInt.TextChanged += new System.EventHandler(this.txtNumberInt_TextChanged);
            this.txtNumberInt.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // lblBillingAdress
            // 
            this.lblBillingAdress.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(139)))), ((int)(((byte)(208)))));
            this.lblBillingAdress.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblBillingAdress.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBillingAdress.ForeColor = System.Drawing.Color.White;
            this.lblBillingAdress.Location = new System.Drawing.Point(0, 0);
            this.lblBillingAdress.Name = "lblBillingAdress";
            this.lblBillingAdress.Size = new System.Drawing.Size(411, 17);
            this.lblBillingAdress.TabIndex = 0;
            this.lblBillingAdress.Text = "Dirección de Facturación";
            this.lblBillingAdress.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblSocialReason
            // 
            this.lblSocialReason.AutoSize = true;
            this.lblSocialReason.Location = new System.Drawing.Point(3, 28);
            this.lblSocialReason.Name = "lblSocialReason";
            this.lblSocialReason.Size = new System.Drawing.Size(73, 13);
            this.lblSocialReason.TabIndex = 0;
            this.lblSocialReason.Text = "Razón Social:";
            this.lblSocialReason.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblStreet
            // 
            this.lblStreet.AutoSize = true;
            this.lblStreet.Location = new System.Drawing.Point(3, 67);
            this.lblStreet.Name = "lblStreet";
            this.lblStreet.Size = new System.Drawing.Size(33, 13);
            this.lblStreet.TabIndex = 0;
            this.lblStreet.Text = "Calle:";
            // 
            // txtSocialReason
            // 
            this.txtSocialReason.AllowBlankSpaces = true;
            this.txtSocialReason.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtSocialReason.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.NumbersOrLetters;
            this.txtSocialReason.CustomExpression = ".*";
            this.txtSocialReason.EnterColor = System.Drawing.Color.Empty;
            this.txtSocialReason.LeaveColor = System.Drawing.Color.Empty;
            this.txtSocialReason.Location = new System.Drawing.Point(6, 44);
            this.txtSocialReason.MaxLength = 65;
            this.txtSocialReason.Name = "txtSocialReason";
            this.txtSocialReason.Size = new System.Drawing.Size(390, 20);
            this.txtSocialReason.TabIndex = 1;
            this.txtSocialReason.TabStop = false;
            this.txtSocialReason.TextChanged += new System.EventHandler(this.txtSocialReason_TextChanged);
            this.txtSocialReason.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // txtStreet
            // 
            this.txtStreet.AllowBlankSpaces = true;
            this.txtStreet.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtStreet.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.NumbersOrLetters;
            this.txtStreet.CustomExpression = ".*";
            this.txtStreet.EnterColor = System.Drawing.Color.Empty;
            this.txtStreet.LeaveColor = System.Drawing.Color.Empty;
            this.txtStreet.Location = new System.Drawing.Point(6, 83);
            this.txtStreet.MaxLength = 21;
            this.txtStreet.Name = "txtStreet";
            this.txtStreet.Size = new System.Drawing.Size(150, 20);
            this.txtStreet.TabIndex = 2;
            this.txtStreet.TextChanged += new System.EventHandler(this.txtStreet_TextChanged);
            this.txtStreet.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // txtNumberExt
            // 
            this.txtNumberExt.AllowBlankSpaces = true;
            this.txtNumberExt.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtNumberExt.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.NumbersOrLetters;
            this.txtNumberExt.CustomExpression = ".*";
            this.txtNumberExt.EnterColor = System.Drawing.Color.Empty;
            this.txtNumberExt.LeaveColor = System.Drawing.Color.Empty;
            this.txtNumberExt.Location = new System.Drawing.Point(164, 82);
            this.txtNumberExt.MaxLength = 5;
            this.txtNumberExt.Name = "txtNumberExt";
            this.txtNumberExt.Size = new System.Drawing.Size(60, 20);
            this.txtNumberExt.TabIndex = 3;
            this.txtNumberExt.TextChanged += new System.EventHandler(this.txtNumberExt_TextChanged);
            this.txtNumberExt.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // btnAcept
            // 
            this.btnAcept.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnAcept.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAcept.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAcept.Location = new System.Drawing.Point(278, 450);
            this.btnAcept.Name = "btnAcept";
            this.btnAcept.Size = new System.Drawing.Size(110, 24);
            this.btnAcept.TabIndex = 16;
            this.btnAcept.Text = "Aceptar";
            this.btnAcept.UseVisualStyleBackColor = false;
            this.btnAcept.Click += new System.EventHandler(this.btnAcept_Click);
            // 
            // lblNumberExt
            // 
            this.lblNumberExt.AutoSize = true;
            this.lblNumberExt.Location = new System.Drawing.Point(159, 66);
            this.lblNumberExt.Name = "lblNumberExt";
            this.lblNumberExt.Size = new System.Drawing.Size(29, 13);
            this.lblNumberExt.TabIndex = 0;
            this.lblNumberExt.Text = "#Ext";
            // 
            // lblNumberInt
            // 
            this.lblNumberInt.AutoSize = true;
            this.lblNumberInt.ForeColor = System.Drawing.Color.DarkCyan;
            this.lblNumberInt.Location = new System.Drawing.Point(237, 67);
            this.lblNumberInt.Name = "lblNumberInt";
            this.lblNumberInt.Size = new System.Drawing.Size(26, 13);
            this.lblNumberInt.TabIndex = 0;
            this.lblNumberInt.Text = "#Int";
            // 
            // lblCP
            // 
            this.lblCP.AutoSize = true;
            this.lblCP.Location = new System.Drawing.Point(3, 144);
            this.lblCP.Name = "lblCP";
            this.lblCP.Size = new System.Drawing.Size(24, 13);
            this.lblCP.TabIndex = 0;
            this.lblCP.Text = "CP:";
            // 
            // lblCountry
            // 
            this.lblCountry.AutoSize = true;
            this.lblCountry.ForeColor = System.Drawing.Color.Black;
            this.lblCountry.Location = new System.Drawing.Point(237, 106);
            this.lblCountry.Name = "lblCountry";
            this.lblCountry.Size = new System.Drawing.Size(29, 13);
            this.lblCountry.TabIndex = 0;
            this.lblCountry.Text = "País";
            // 
            // txtCountry
            // 
            this.txtCountry.AllowBlankSpaces = true;
            this.txtCountry.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtCountry.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.OnlyLetters;
            this.txtCountry.CustomExpression = ".*";
            this.txtCountry.EnterColor = System.Drawing.Color.Empty;
            this.txtCountry.LeaveColor = System.Drawing.Color.Empty;
            this.txtCountry.Location = new System.Drawing.Point(238, 121);
            this.txtCountry.MaxLength = 18;
            this.txtCountry.Name = "txtCountry";
            this.txtCountry.Size = new System.Drawing.Size(145, 20);
            this.txtCountry.TabIndex = 6;
            this.txtCountry.TextChanged += new System.EventHandler(this.txtCountry_TextChanged);
            this.txtCountry.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCountry_KeyDown);
            // 
            // lbCountries
            // 
            this.lbCountries.DisplayMember = "Text2";
            this.lbCountries.FormattingEnabled = true;
            this.lbCountries.Location = new System.Drawing.Point(238, 141);
            this.lbCountries.Name = "lbCountries";
            this.lbCountries.Size = new System.Drawing.Size(145, 95);
            this.lbCountries.TabIndex = 54;
            this.lbCountries.ValueMember = "Value";
            this.lbCountries.Visible = false;
            this.lbCountries.MouseClick += new System.Windows.Forms.MouseEventHandler(this.lbCountries_MouseClick);
            this.lbCountries.KeyDown += new System.Windows.Forms.KeyEventHandler(this.lbCountries_KeyDown);
            // 
            // ucBillingAdressEmission
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.lbCountries);
            this.Controls.Add(this.lblCountry);
            this.Controls.Add(this.txtCountry);
            this.Controls.Add(this.lblCP);
            this.Controls.Add(this.lblShow);
            this.Controls.Add(this.lblInformative);
            this.Controls.Add(this.txtDescription1);
            this.Controls.Add(this.txtDescription2);
            this.Controls.Add(this.lblDescription);
            this.Controls.Add(this.txtRFC3);
            this.Controls.Add(this.txtRFC2);
            this.Controls.Add(this.txtRFC1);
            this.Controls.Add(this.lblRFC);
            this.Controls.Add(this.txtState);
            this.Controls.Add(this.lblState);
            this.Controls.Add(this.txtCity);
            this.Controls.Add(this.lblCity);
            this.Controls.Add(this.txtCP);
            this.Controls.Add(this.txtDelegation);
            this.Controls.Add(this.lblDelegation);
            this.Controls.Add(this.txtColony);
            this.Controls.Add(this.lblColony);
            this.Controls.Add(this.txtNumberInt);
            this.Controls.Add(this.lblBillingAdress);
            this.Controls.Add(this.lblSocialReason);
            this.Controls.Add(this.lblStreet);
            this.Controls.Add(this.txtSocialReason);
            this.Controls.Add(this.txtStreet);
            this.Controls.Add(this.txtNumberExt);
            this.Controls.Add(this.btnAcept);
            this.Controls.Add(this.lblNumberExt);
            this.Controls.Add(this.lblNumberInt);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "ucBillingAdressEmission";
            this.Size = new System.Drawing.Size(411, 580);
            this.Load += new System.EventHandler(this.ucBillingAdressEmission_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblShow;
        private System.Windows.Forms.Label lblInformative;
        private MyCTS.Forms.UI.SmartTextBox txtDescription1;
        private MyCTS.Forms.UI.SmartTextBox txtDescription2;
        private System.Windows.Forms.Label lblDescription;
        private MyCTS.Forms.UI.SmartTextBox txtRFC3;
        private MyCTS.Forms.UI.SmartTextBox txtRFC2;
        private MyCTS.Forms.UI.SmartTextBox txtRFC1;
        private System.Windows.Forms.Label lblRFC;
        private MyCTS.Forms.UI.SmartTextBox txtState;
        private System.Windows.Forms.Label lblState;
        private MyCTS.Forms.UI.SmartTextBox txtCity;
        private System.Windows.Forms.Label lblCity;
        private MyCTS.Forms.UI.SmartTextBox txtCP;
        private MyCTS.Forms.UI.SmartTextBox txtDelegation;
        private System.Windows.Forms.Label lblDelegation;
        private MyCTS.Forms.UI.SmartTextBox txtColony;
        private System.Windows.Forms.Label lblColony;
        private MyCTS.Forms.UI.SmartTextBox txtNumberInt;
        internal System.Windows.Forms.Label lblBillingAdress;
        private System.Windows.Forms.Label lblSocialReason;
        private System.Windows.Forms.Label lblStreet;
        private MyCTS.Forms.UI.SmartTextBox txtSocialReason;
        private MyCTS.Forms.UI.SmartTextBox txtStreet;
        private MyCTS.Forms.UI.SmartTextBox txtNumberExt;
        private System.Windows.Forms.Button btnAcept;
        private System.Windows.Forms.Label lblNumberExt;
        private System.Windows.Forms.Label lblNumberInt;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Label lblCP;
        private System.Windows.Forms.Label lblCountry;
        private MyCTS.Forms.UI.SmartTextBox txtCountry;
        private System.Windows.Forms.ListBox lbCountries;
    }
}
