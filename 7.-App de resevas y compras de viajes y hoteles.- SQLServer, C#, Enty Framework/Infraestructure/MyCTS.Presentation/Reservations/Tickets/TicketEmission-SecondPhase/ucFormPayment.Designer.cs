namespace MyCTS.Presentation
{
    partial class ucFormPayment
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
            this.lblFormPay = new System.Windows.Forms.Label();
            this.cmbBank = new System.Windows.Forms.ComboBox();
            this.lblBank = new System.Windows.Forms.Label();
            this.txtSecurityCode = new MyCTS.Forms.UI.SmartTextBox();
            this.lblSecurityCode = new System.Windows.Forms.Label();
            this.chkCTS = new System.Windows.Forms.CheckBox();
            this.lblCard = new System.Windows.Forms.Label();
            this.chkClient = new System.Windows.Forms.CheckBox();
            this.lblMonth = new System.Windows.Forms.Label();
            this.lblYear = new System.Windows.Forms.Label();
            this.lblCardType = new System.Windows.Forms.Label();
            this.lblNumberCard = new System.Windows.Forms.Label();
            this.lblDateExpired = new System.Windows.Forms.Label();
            this.lblAuthorizationCode = new System.Windows.Forms.Label();
            this.lblCardAmount = new System.Windows.Forms.Label();
            this.btnAccept = new System.Windows.Forms.Button();
            this.chkExtendetPayment = new System.Windows.Forms.CheckBox();
            this.txtTypeCard = new MyCTS.Forms.UI.SmartTextBox();
            this.txtNumberCard = new MyCTS.Forms.UI.SmartTextBox();
            this.txtMonth = new MyCTS.Forms.UI.SmartTextBox();
            this.txtYear = new MyCTS.Forms.UI.SmartTextBox();
            this.txtAuthorizationCode = new MyCTS.Forms.UI.SmartTextBox();
            this.txtCardAmount = new MyCTS.Forms.UI.SmartTextBox();
            this.lblSlash = new System.Windows.Forms.Label();
            this.lblMonths1 = new System.Windows.Forms.Label();
            this.txtMonths = new MyCTS.Forms.UI.SmartTextBox();
            this.lblMonths = new System.Windows.Forms.Label();
            this.lblAX = new System.Windows.Forms.Label();
            this.lbTypeCard = new System.Windows.Forms.ListBox();
            this.lbSystem = new System.Windows.Forms.ListBox();
            this.btnShow = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.lnLHInfo = new System.Windows.Forms.LinkLabel();
            this.lblMessageLink = new System.Windows.Forms.Label();
            this.lblMessage = new System.Windows.Forms.Label();
            this.lblAmount = new System.Windows.Forms.Label();
            this.lblFormaPagoCTS = new System.Windows.Forms.Label();
            this.btnShowCTS = new System.Windows.Forms.Button();
            this.lblCardTypeCTS = new System.Windows.Forms.Label();
            this.lblCardNumberCTS = new System.Windows.Forms.Label();
            this.txtNumberCardCTS = new MyCTS.Forms.UI.SmartTextBox();
            this.cmbTypeCard = new System.Windows.Forms.ComboBox();
            this.cmbMonths = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // lblFormPay
            // 
            this.lblFormPay.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(139)))), ((int)(((byte)(208)))));
            this.lblFormPay.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblFormPay.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFormPay.ForeColor = System.Drawing.Color.White;
            this.lblFormPay.Location = new System.Drawing.Point(0, 0);
            this.lblFormPay.Name = "lblFormPay";
            this.lblFormPay.Size = new System.Drawing.Size(411, 16);
            this.lblFormPay.TabIndex = 0;
            this.lblFormPay.Text = "Forma de Pago";
            this.lblFormPay.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cmbBank
            // 
            this.cmbBank.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBank.Location = new System.Drawing.Point(148, 234);
            this.cmbBank.Name = "cmbBank";
            this.cmbBank.Size = new System.Drawing.Size(121, 21);
            this.cmbBank.TabIndex = 78;
            this.cmbBank.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // lblBank
            // 
            this.lblBank.AutoSize = true;
            this.lblBank.Location = new System.Drawing.Point(29, 237);
            this.lblBank.Name = "lblBank";
            this.lblBank.Size = new System.Drawing.Size(38, 13);
            this.lblBank.TabIndex = 84;
            this.lblBank.Text = "Banco";
            // 
            // txtSecurityCode
            // 
            this.txtSecurityCode.AllowBlankSpaces = true;
            this.txtSecurityCode.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtSecurityCode.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.OnlyNumbers;
            this.txtSecurityCode.CustomExpression = ".*";
            this.txtSecurityCode.EnterColor = System.Drawing.Color.Empty;
            this.txtSecurityCode.Font = new System.Drawing.Font("Symbol", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            this.txtSecurityCode.LeaveColor = System.Drawing.Color.Empty;
            this.txtSecurityCode.Location = new System.Drawing.Point(148, 173);
            this.txtSecurityCode.MaxLength = 6;
            this.txtSecurityCode.Name = "txtSecurityCode";
            this.txtSecurityCode.PasswordChar = '·';
            this.txtSecurityCode.Size = new System.Drawing.Size(49, 22);
            this.txtSecurityCode.TabIndex = 74;
            this.txtSecurityCode.Visible = false;
            this.txtSecurityCode.TextChanged += new System.EventHandler(this.txtSecurityCode_TextChanged);
            this.txtSecurityCode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // lblSecurityCode
            // 
            this.lblSecurityCode.AutoSize = true;
            this.lblSecurityCode.Location = new System.Drawing.Point(29, 177);
            this.lblSecurityCode.Name = "lblSecurityCode";
            this.lblSecurityCode.Size = new System.Drawing.Size(106, 13);
            this.lblSecurityCode.TabIndex = 83;
            this.lblSecurityCode.Text = "Codigo de Seguridad";
            this.lblSecurityCode.Visible = false;
            // 
            // chkCTS
            // 
            this.chkCTS.AutoSize = true;
            this.chkCTS.Location = new System.Drawing.Point(212, 46);
            this.chkCTS.Name = "chkCTS";
            this.chkCTS.Size = new System.Drawing.Size(47, 17);
            this.chkCTS.TabIndex = 68;
            this.chkCTS.Text = "CTS";
            this.chkCTS.UseVisualStyleBackColor = true;
            this.chkCTS.CheckedChanged += new System.EventHandler(this.chkCTS_CheckedChanged);
            // 
            // lblCard
            // 
            this.lblCard.AutoSize = true;
            this.lblCard.Location = new System.Drawing.Point(32, 50);
            this.lblCard.Name = "lblCard";
            this.lblCard.Size = new System.Drawing.Size(69, 13);
            this.lblCard.TabIndex = 65;
            this.lblCard.Text = "Es tarjeta de:";
            // 
            // chkClient
            // 
            this.chkClient.AutoSize = true;
            this.chkClient.Location = new System.Drawing.Point(148, 46);
            this.chkClient.Name = "chkClient";
            this.chkClient.Size = new System.Drawing.Size(58, 17);
            this.chkClient.TabIndex = 67;
            this.chkClient.Text = "Cliente";
            this.chkClient.UseVisualStyleBackColor = true;
            this.chkClient.CheckedChanged += new System.EventHandler(this.chkClient_CheckedChanged);
            // 
            // lblMonth
            // 
            this.lblMonth.AutoSize = true;
            this.lblMonth.Location = new System.Drawing.Point(145, 150);
            this.lblMonth.Name = "lblMonth";
            this.lblMonth.Size = new System.Drawing.Size(27, 13);
            this.lblMonth.TabIndex = 63;
            this.lblMonth.Text = "Mes";
            // 
            // lblYear
            // 
            this.lblYear.AutoSize = true;
            this.lblYear.Location = new System.Drawing.Point(203, 150);
            this.lblYear.Name = "lblYear";
            this.lblYear.Size = new System.Drawing.Size(26, 13);
            this.lblYear.TabIndex = 58;
            this.lblYear.Text = "Año";
            // 
            // lblCardType
            // 
            this.lblCardType.AutoSize = true;
            this.lblCardType.Location = new System.Drawing.Point(29, 78);
            this.lblCardType.Name = "lblCardType";
            this.lblCardType.Size = new System.Drawing.Size(79, 13);
            this.lblCardType.TabIndex = 57;
            this.lblCardType.Text = "Tipo de Tarjeta";
            this.lblCardType.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblNumberCard
            // 
            this.lblNumberCard.AutoSize = true;
            this.lblNumberCard.Location = new System.Drawing.Point(29, 105);
            this.lblNumberCard.Name = "lblNumberCard";
            this.lblNumberCard.Size = new System.Drawing.Size(91, 13);
            this.lblNumberCard.TabIndex = 56;
            this.lblNumberCard.Text = "Número de tarjeta";
            this.lblNumberCard.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblDateExpired
            // 
            this.lblDateExpired.AutoSize = true;
            this.lblDateExpired.Location = new System.Drawing.Point(29, 134);
            this.lblDateExpired.Name = "lblDateExpired";
            this.lblDateExpired.Size = new System.Drawing.Size(97, 13);
            this.lblDateExpired.TabIndex = 64;
            this.lblDateExpired.Text = "Fecha vencimiento";
            this.lblDateExpired.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblAuthorizationCode
            // 
            this.lblAuthorizationCode.AutoSize = true;
            this.lblAuthorizationCode.Location = new System.Drawing.Point(25, 177);
            this.lblAuthorizationCode.Name = "lblAuthorizationCode";
            this.lblAuthorizationCode.Size = new System.Drawing.Size(101, 13);
            this.lblAuthorizationCode.TabIndex = 62;
            this.lblAuthorizationCode.Text = "Codigo Autorización";
            this.lblAuthorizationCode.Visible = false;
            // 
            // lblCardAmount
            // 
            this.lblCardAmount.AutoSize = true;
            this.lblCardAmount.Location = new System.Drawing.Point(29, 207);
            this.lblCardAmount.Name = "lblCardAmount";
            this.lblCardAmount.Size = new System.Drawing.Size(94, 13);
            this.lblCardAmount.TabIndex = 61;
            this.lblCardAmount.Text = "Monto con Tarjeta";
            this.lblCardAmount.Visible = false;
            // 
            // btnAccept
            // 
            this.btnAccept.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnAccept.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAccept.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAccept.Location = new System.Drawing.Point(296, 490);
            this.btnAccept.Name = "btnAccept";
            this.btnAccept.Size = new System.Drawing.Size(110, 24);
            this.btnAccept.TabIndex = 80;
            this.btnAccept.Text = "Aceptar";
            this.btnAccept.UseVisualStyleBackColor = false;
            this.btnAccept.Click += new System.EventHandler(this.btnAccept_Click);
            // 
            // chkExtendetPayment
            // 
            this.chkExtendetPayment.AutoSize = true;
            this.chkExtendetPayment.ForeColor = System.Drawing.Color.DarkCyan;
            this.chkExtendetPayment.Location = new System.Drawing.Point(28, 285);
            this.chkExtendetPayment.Name = "chkExtendetPayment";
            this.chkExtendetPayment.Size = new System.Drawing.Size(112, 17);
            this.chkExtendetPayment.TabIndex = 76;
            this.chkExtendetPayment.Text = "¿Pago extendido?";
            this.chkExtendetPayment.UseVisualStyleBackColor = true;
            this.chkExtendetPayment.Visible = false;
            this.chkExtendetPayment.CheckedChanged += new System.EventHandler(this.chkExtendetPayment_CheckedChanged);
            // 
            // txtTypeCard
            // 
            this.txtTypeCard.AllowBlankSpaces = true;
            this.txtTypeCard.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtTypeCard.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.OnlyLetters;
            this.txtTypeCard.CustomExpression = ".*";
            this.txtTypeCard.EnterColor = System.Drawing.Color.Empty;
            this.txtTypeCard.LeaveColor = System.Drawing.Color.Empty;
            this.txtTypeCard.Location = new System.Drawing.Point(148, 75);
            this.txtTypeCard.Name = "txtTypeCard";
            this.txtTypeCard.Size = new System.Drawing.Size(224, 20);
            this.txtTypeCard.TabIndex = 69;
            this.txtTypeCard.TextChanged += new System.EventHandler(this.txtTypeCard_TextChanged);
            this.txtTypeCard.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // txtNumberCard
            // 
            this.txtNumberCard.AllowBlankSpaces = false;
            this.txtNumberCard.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtNumberCard.CharsIncluded = new char[0];
            this.txtNumberCard.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.OnlyNumbers;
            this.txtNumberCard.CustomExpression = ".*";
            this.txtNumberCard.EnterColor = System.Drawing.Color.Empty;
            this.txtNumberCard.Font = new System.Drawing.Font("Symbol", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            this.txtNumberCard.LeaveColor = System.Drawing.Color.Empty;
            this.txtNumberCard.Location = new System.Drawing.Point(148, 102);
            this.txtNumberCard.MaxLength = 16;
            this.txtNumberCard.Name = "txtNumberCard";
            this.txtNumberCard.PasswordChar = '·';
            this.txtNumberCard.Size = new System.Drawing.Size(117, 22);
            this.txtNumberCard.TabIndex = 70;
            this.txtNumberCard.TextChanged += new System.EventHandler(this.txtNumberCard_TextChanged);
            this.txtNumberCard.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // txtMonth
            // 
            this.txtMonth.AllowBlankSpaces = true;
            this.txtMonth.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtMonth.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.OnlyNumbers;
            this.txtMonth.CustomExpression = ".*";
            this.txtMonth.EnterColor = System.Drawing.Color.Empty;
            this.txtMonth.LeaveColor = System.Drawing.Color.Empty;
            this.txtMonth.Location = new System.Drawing.Point(148, 127);
            this.txtMonth.MaxLength = 2;
            this.txtMonth.Name = "txtMonth";
            this.txtMonth.Size = new System.Drawing.Size(31, 20);
            this.txtMonth.TabIndex = 71;
            this.txtMonth.TextChanged += new System.EventHandler(this.txtMonth_TextChanged);
            this.txtMonth.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // txtYear
            // 
            this.txtYear.AllowBlankSpaces = true;
            this.txtYear.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtYear.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.OnlyNumbers;
            this.txtYear.CustomExpression = ".*";
            this.txtYear.EnterColor = System.Drawing.Color.Empty;
            this.txtYear.LeaveColor = System.Drawing.Color.Empty;
            this.txtYear.Location = new System.Drawing.Point(203, 127);
            this.txtYear.MaxLength = 2;
            this.txtYear.Name = "txtYear";
            this.txtYear.Size = new System.Drawing.Size(29, 20);
            this.txtYear.TabIndex = 72;
            this.txtYear.TextChanged += new System.EventHandler(this.txtYear_TextChanged);
            this.txtYear.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // txtAuthorizationCode
            // 
            this.txtAuthorizationCode.AllowBlankSpaces = true;
            this.txtAuthorizationCode.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtAuthorizationCode.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.OnlyNumbers;
            this.txtAuthorizationCode.CustomExpression = ".*";
            this.txtAuthorizationCode.EnterColor = System.Drawing.Color.Empty;
            this.txtAuthorizationCode.Font = new System.Drawing.Font("Symbol", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            this.txtAuthorizationCode.LeaveColor = System.Drawing.Color.Empty;
            this.txtAuthorizationCode.Location = new System.Drawing.Point(148, 174);
            this.txtAuthorizationCode.MaxLength = 6;
            this.txtAuthorizationCode.Name = "txtAuthorizationCode";
            this.txtAuthorizationCode.PasswordChar = '·';
            this.txtAuthorizationCode.Size = new System.Drawing.Size(49, 22);
            this.txtAuthorizationCode.TabIndex = 73;
            this.txtAuthorizationCode.Visible = false;
            this.txtAuthorizationCode.TextChanged += new System.EventHandler(this.txtAuthorizationCode_TextChanged);
            this.txtAuthorizationCode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // txtCardAmount
            // 
            this.txtCardAmount.AllowBlankSpaces = true;
            this.txtCardAmount.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtCardAmount.CharsIncluded = new char[0];
            this.txtCardAmount.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.OnlyNumbers;
            this.txtCardAmount.CustomExpression = ".*";
            this.txtCardAmount.EnterColor = System.Drawing.Color.Empty;
            this.txtCardAmount.LeaveColor = System.Drawing.Color.Empty;
            this.txtCardAmount.Location = new System.Drawing.Point(148, 204);
            this.txtCardAmount.MaxLength = 8;
            this.txtCardAmount.Name = "txtCardAmount";
            this.txtCardAmount.Size = new System.Drawing.Size(68, 20);
            this.txtCardAmount.TabIndex = 75;
            this.txtCardAmount.TextChanged += new System.EventHandler(this.txtCardAmount_TextChanged);
            this.txtCardAmount.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // lblSlash
            // 
            this.lblSlash.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSlash.AutoSize = true;
            this.lblSlash.Location = new System.Drawing.Point(185, 130);
            this.lblSlash.Name = "lblSlash";
            this.lblSlash.Size = new System.Drawing.Size(12, 13);
            this.lblSlash.TabIndex = 81;
            this.lblSlash.Text = "/";
            this.lblSlash.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblMonths1
            // 
            this.lblMonths1.AutoSize = true;
            this.lblMonths1.Location = new System.Drawing.Point(203, 286);
            this.lblMonths1.Name = "lblMonths1";
            this.lblMonths1.Size = new System.Drawing.Size(38, 13);
            this.lblMonths1.TabIndex = 59;
            this.lblMonths1.Text = "Meses";
            this.lblMonths1.Visible = false;
            // 
            // txtMonths
            // 
            this.txtMonths.AllowBlankSpaces = true;
            this.txtMonths.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtMonths.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.OnlyNumbers;
            this.txtMonths.CustomExpression = ".*";
            this.txtMonths.EnterColor = System.Drawing.Color.Empty;
            this.txtMonths.LeaveColor = System.Drawing.Color.Empty;
            this.txtMonths.Location = new System.Drawing.Point(247, 283);
            this.txtMonths.MaxLength = 2;
            this.txtMonths.Name = "txtMonths";
            this.txtMonths.Size = new System.Drawing.Size(30, 20);
            this.txtMonths.TabIndex = 77;
            this.txtMonths.Visible = false;
            this.txtMonths.TextChanged += new System.EventHandler(this.cmbMonths_TextChanged);
            this.txtMonths.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // lblMonths
            // 
            this.lblMonths.AutoSize = true;
            this.lblMonths.Location = new System.Drawing.Point(283, 287);
            this.lblMonths.Name = "lblMonths";
            this.lblMonths.Size = new System.Drawing.Size(94, 13);
            this.lblMonths.TabIndex = 60;
            this.lblMonths.Text = "3,6,9,12,18 meses";
            this.lblMonths.Visible = false;
            // 
            // lblAX
            // 
            this.lblAX.AutoSize = true;
            this.lblAX.ForeColor = System.Drawing.Color.Red;
            this.lblAX.Location = new System.Drawing.Point(36, 319);
            this.lblAX.Name = "lblAX";
            this.lblAX.Size = new System.Drawing.Size(315, 13);
            this.lblAX.TabIndex = 66;
            this.lblAX.Text = "Para 6 meses sin intereses con AX se debe ingresar el número 24";
            this.lblAX.Visible = false;
            // 
            // lbTypeCard
            // 
            this.lbTypeCard.DisplayMember = "Text";
            this.lbTypeCard.FormattingEnabled = true;
            this.lbTypeCard.Location = new System.Drawing.Point(148, 93);
            this.lbTypeCard.Name = "lbTypeCard";
            this.lbTypeCard.Size = new System.Drawing.Size(224, 95);
            this.lbTypeCard.TabIndex = 79;
            this.lbTypeCard.ValueMember = "Value";
            this.lbTypeCard.Visible = false;
            this.lbTypeCard.MouseClick += new System.Windows.Forms.MouseEventHandler(this.lbTypeCard_MouseClick);
            this.lbTypeCard.KeyDown += new System.Windows.Forms.KeyEventHandler(this.lbTypeCard_KeyDown);
            // 
            // lbSystem
            // 
            this.lbSystem.FormattingEnabled = true;
            this.lbSystem.Items.AddRange(new object[] {
            "AX AMERICAN EXPRESS",
            "TP UATP- AIR TRAVEL CARD",
            "DC DINERS CLUB",
            "VI VISA",
            "CA MASTERCARD"});
            this.lbSystem.Location = new System.Drawing.Point(148, 93);
            this.lbSystem.Name = "lbSystem";
            this.lbSystem.Size = new System.Drawing.Size(224, 95);
            this.lbSystem.TabIndex = 82;
            this.lbSystem.Visible = false;
            this.lbSystem.MouseClick += new System.Windows.Forms.MouseEventHandler(this.lbSystem_MouseClick);
            this.lbSystem.KeyDown += new System.Windows.Forms.KeyEventHandler(this.lbSystem_KeyDown);
            // 
            // btnShow
            // 
            this.btnShow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnShow.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnShow.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnShow.Image = global::MyCTS.Presentation.Properties.Resources._1327964141_find;
            this.btnShow.Location = new System.Drawing.Point(271, 102);
            this.btnShow.Name = "btnShow";
            this.btnShow.Size = new System.Drawing.Size(23, 20);
            this.btnShow.TabIndex = 85;
            this.btnShow.UseVisualStyleBackColor = false;
            this.btnShow.Visible = false;
            this.btnShow.Click += new System.EventHandler(this.btnShow_Click);
            // 
            // lnLHInfo
            // 
            this.lnLHInfo.AutoSize = true;
            this.lnLHInfo.Location = new System.Drawing.Point(9, 380);
            this.lnLHInfo.Name = "lnLHInfo";
            this.lnLHInfo.Size = new System.Drawing.Size(326, 13);
            this.lnLHInfo.TabIndex = 91;
            this.lnLHInfo.TabStop = true;
            this.lnLHInfo.Text = "http://201.149.13.14:5498/MyCTS/OB_FEE_Grupo_Lufthansa.pdf";
            this.lnLHInfo.Visible = false;
            this.lnLHInfo.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnLHInfo_LinkClicked);
            // 
            // lblMessageLink
            // 
            this.lblMessageLink.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMessageLink.ForeColor = System.Drawing.Color.RoyalBlue;
            this.lblMessageLink.Location = new System.Drawing.Point(9, 365);
            this.lblMessageLink.Name = "lblMessageLink";
            this.lblMessageLink.Size = new System.Drawing.Size(356, 15);
            this.lblMessageLink.TabIndex = 90;
            this.lblMessageLink.Text = "Para Consultar el Detalle Ingrese al Siguiente Link:";
            this.lblMessageLink.Visible = false;
            // 
            // lblMessage
            // 
            this.lblMessage.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMessage.ForeColor = System.Drawing.Color.RoyalBlue;
            this.lblMessage.Location = new System.Drawing.Point(9, 337);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(392, 43);
            this.lblMessage.TabIndex = 89;
            this.lblMessage.Text = "El Monto a Pagar  Contiene el Cargo del OB FEE del grupo Lufthansa de Acuerdo a l" +
                "os Parámetros de Emisión Ingresados. ";
            this.lblMessage.Visible = false;
            // 
            // lblAmount
            // 
            this.lblAmount.AutoSize = true;
            this.lblAmount.Location = new System.Drawing.Point(220, 208);
            this.lblAmount.Name = "lblAmount";
            this.lblAmount.Size = new System.Drawing.Size(0, 13);
            this.lblAmount.TabIndex = 92;
            this.lblAmount.Visible = false;
            // 
            // lblFormaPagoCTS
            // 
            this.lblFormaPagoCTS.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(139)))), ((int)(((byte)(208)))));
            this.lblFormaPagoCTS.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFormaPagoCTS.ForeColor = System.Drawing.Color.White;
            this.lblFormaPagoCTS.Location = new System.Drawing.Point(-3, 402);
            this.lblFormaPagoCTS.Name = "lblFormaPagoCTS";
            this.lblFormaPagoCTS.Size = new System.Drawing.Size(411, 16);
            this.lblFormaPagoCTS.TabIndex = 93;
            this.lblFormaPagoCTS.Text = "Forma de Pago del Cliente a CTS";
            this.lblFormaPagoCTS.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblFormaPagoCTS.Visible = false;
            // 
            // btnShowCTS
            // 
            this.btnShowCTS.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnShowCTS.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnShowCTS.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnShowCTS.Image = global::MyCTS.Presentation.Properties.Resources._1327964141_find;
            this.btnShowCTS.Location = new System.Drawing.Point(274, 456);
            this.btnShowCTS.Name = "btnShowCTS";
            this.btnShowCTS.Size = new System.Drawing.Size(23, 20);
            this.btnShowCTS.TabIndex = 98;
            this.btnShowCTS.UseVisualStyleBackColor = false;
            this.btnShowCTS.Visible = false;
            this.btnShowCTS.Click += new System.EventHandler(this.btnShowCTS_Click);
            // 
            // lblCardTypeCTS
            // 
            this.lblCardTypeCTS.AutoSize = true;
            this.lblCardTypeCTS.Location = new System.Drawing.Point(32, 432);
            this.lblCardTypeCTS.Name = "lblCardTypeCTS";
            this.lblCardTypeCTS.Size = new System.Drawing.Size(79, 13);
            this.lblCardTypeCTS.TabIndex = 95;
            this.lblCardTypeCTS.Text = "Tipo de Tarjeta";
            this.lblCardTypeCTS.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblCardTypeCTS.Visible = false;
            // 
            // lblCardNumberCTS
            // 
            this.lblCardNumberCTS.AutoSize = true;
            this.lblCardNumberCTS.Location = new System.Drawing.Point(32, 459);
            this.lblCardNumberCTS.Name = "lblCardNumberCTS";
            this.lblCardNumberCTS.Size = new System.Drawing.Size(91, 13);
            this.lblCardNumberCTS.TabIndex = 94;
            this.lblCardNumberCTS.Text = "Número de tarjeta";
            this.lblCardNumberCTS.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblCardNumberCTS.Visible = false;
            // 
            // txtNumberCardCTS
            // 
            this.txtNumberCardCTS.AllowBlankSpaces = false;
            this.txtNumberCardCTS.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtNumberCardCTS.CharsIncluded = new char[0];
            this.txtNumberCardCTS.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.OnlyNumbers;
            this.txtNumberCardCTS.CustomExpression = ".*";
            this.txtNumberCardCTS.EnterColor = System.Drawing.Color.Empty;
            this.txtNumberCardCTS.Font = new System.Drawing.Font("Symbol", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            this.txtNumberCardCTS.LeaveColor = System.Drawing.Color.Empty;
            this.txtNumberCardCTS.Location = new System.Drawing.Point(151, 456);
            this.txtNumberCardCTS.MaxLength = 16;
            this.txtNumberCardCTS.Name = "txtNumberCardCTS";
            this.txtNumberCardCTS.PasswordChar = '·';
            this.txtNumberCardCTS.Size = new System.Drawing.Size(117, 22);
            this.txtNumberCardCTS.TabIndex = 97;
            this.txtNumberCardCTS.Visible = false;
            // 
            // cmbTypeCard
            // 
            this.cmbTypeCard.DisplayMember = "Text";
            this.cmbTypeCard.FormattingEnabled = true;
            this.cmbTypeCard.Items.AddRange(new object[] {
            "- Selecciona Forma de Pago -"});
            this.cmbTypeCard.Location = new System.Drawing.Point(151, 429);
            this.cmbTypeCard.Name = "cmbTypeCard";
            this.cmbTypeCard.Size = new System.Drawing.Size(226, 21);
            this.cmbTypeCard.TabIndex = 164;
            this.cmbTypeCard.ValueMember = "Value";
            this.cmbTypeCard.Visible = false;
            this.cmbTypeCard.SelectedIndexChanged += new System.EventHandler(this.cmbTypeCard_SelectedIndexChanged);
            this.cmbTypeCard.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbTypeCard_KeyDown);
            // 
            // cmbMonths
            // 
            this.cmbMonths.FormattingEnabled = true;
            this.cmbMonths.Items.AddRange(new object[] {
            "03",
            "06",
            "09",
            "12"});
            this.cmbMonths.Location = new System.Drawing.Point(157, 283);
            this.cmbMonths.Name = "cmbMonths";
            this.cmbMonths.Size = new System.Drawing.Size(40, 21);
            this.cmbMonths.TabIndex = 165;
            // 
            // ucFormPayment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.cmbMonths);
            this.Controls.Add(this.cmbTypeCard);
            this.Controls.Add(this.btnShowCTS);
            this.Controls.Add(this.lblCardTypeCTS);
            this.Controls.Add(this.lblCardNumberCTS);
            this.Controls.Add(this.txtNumberCardCTS);
            this.Controls.Add(this.lblFormaPagoCTS);
            this.Controls.Add(this.lblAmount);
            this.Controls.Add(this.lnLHInfo);
            this.Controls.Add(this.lblMessageLink);
            this.Controls.Add(this.lblMessage);
            this.Controls.Add(this.btnShow);
            this.Controls.Add(this.cmbBank);
            this.Controls.Add(this.lblBank);
            this.Controls.Add(this.txtSecurityCode);
            this.Controls.Add(this.lblSecurityCode);
            this.Controls.Add(this.chkCTS);
            this.Controls.Add(this.lblCard);
            this.Controls.Add(this.chkClient);
            this.Controls.Add(this.lblMonth);
            this.Controls.Add(this.lblYear);
            this.Controls.Add(this.lblCardType);
            this.Controls.Add(this.lblNumberCard);
            this.Controls.Add(this.lblDateExpired);
            this.Controls.Add(this.lblAuthorizationCode);
            this.Controls.Add(this.lblCardAmount);
            this.Controls.Add(this.btnAccept);
            this.Controls.Add(this.chkExtendetPayment);
            this.Controls.Add(this.txtTypeCard);
            this.Controls.Add(this.txtNumberCard);
            this.Controls.Add(this.txtMonth);
            this.Controls.Add(this.txtYear);
            this.Controls.Add(this.txtAuthorizationCode);
            this.Controls.Add(this.txtCardAmount);
            this.Controls.Add(this.lblSlash);
            this.Controls.Add(this.lblMonths1);
            this.Controls.Add(this.txtMonths);
            this.Controls.Add(this.lblMonths);
            this.Controls.Add(this.lblAX);
            this.Controls.Add(this.lbTypeCard);
            this.Controls.Add(this.lbSystem);
            this.Controls.Add(this.lblFormPay);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "ucFormPayment";
            this.Size = new System.Drawing.Size(411, 580);
            this.Load += new System.EventHandler(this.ucFormPayment_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.Label lblFormPay;
        private System.Windows.Forms.ComboBox cmbBank;
        private System.Windows.Forms.Label lblBank;
        private MyCTS.Forms.UI.SmartTextBox txtSecurityCode;
        private System.Windows.Forms.Label lblSecurityCode;
        private System.Windows.Forms.CheckBox chkCTS;
        private System.Windows.Forms.Label lblCard;
        private System.Windows.Forms.CheckBox chkClient;
        private System.Windows.Forms.Label lblMonth;
        private System.Windows.Forms.Label lblYear;
        private System.Windows.Forms.Label lblCardType;
        private System.Windows.Forms.Label lblNumberCard;
        private System.Windows.Forms.Label lblDateExpired;
        private System.Windows.Forms.Label lblAuthorizationCode;
        private System.Windows.Forms.Label lblCardAmount;
        private System.Windows.Forms.Button btnAccept;
        private System.Windows.Forms.CheckBox chkExtendetPayment;
        private MyCTS.Forms.UI.SmartTextBox txtTypeCard;
        private MyCTS.Forms.UI.SmartTextBox txtNumberCard;
        private MyCTS.Forms.UI.SmartTextBox txtMonth;
        private MyCTS.Forms.UI.SmartTextBox txtYear;
        private MyCTS.Forms.UI.SmartTextBox txtAuthorizationCode;
        private MyCTS.Forms.UI.SmartTextBox txtCardAmount;
        private System.Windows.Forms.Label lblSlash;
        private System.Windows.Forms.Label lblMonths1;
        private MyCTS.Forms.UI.SmartTextBox txtMonths;
        private System.Windows.Forms.Label lblMonths;
        private System.Windows.Forms.Label lblAX;
        private System.Windows.Forms.ListBox lbTypeCard;
        private System.Windows.Forms.ListBox lbSystem;
        private System.Windows.Forms.Button btnShow;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.LinkLabel lnLHInfo;
        private System.Windows.Forms.Label lblMessageLink;
        private System.Windows.Forms.Label lblMessage;
        private System.Windows.Forms.Label lblAmount;
        internal System.Windows.Forms.Label lblFormaPagoCTS;
        private System.Windows.Forms.Button btnShowCTS;
        private System.Windows.Forms.Label lblCardTypeCTS;
        private System.Windows.Forms.Label lblCardNumberCTS;
        private MyCTS.Forms.UI.SmartTextBox txtNumberCardCTS;
        private System.Windows.Forms.ComboBox cmbTypeCard;
        private System.Windows.Forms.ComboBox cmbMonths;

    }
}
