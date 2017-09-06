namespace MyCTS.Presentation
{
    partial class ucMPDVirtual
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
            this.cmbServices = new System.Windows.Forms.ComboBox();
            this.lblServices = new System.Windows.Forms.Label();
            this.btnAccept = new System.Windows.Forms.Button();
            this.txtTicketorKilos = new MyCTS.Forms.UI.SmartTextBox();
            this.lblTicketorKilos = new System.Windows.Forms.Label();
            this.txtMail = new MyCTS.Forms.UI.SmartTextBox();
            this.txtRequest = new MyCTS.Forms.UI.SmartTextBox();
            this.txtOffers = new MyCTS.Forms.UI.SmartTextBox();
            this.txtIssuingBank = new MyCTS.Forms.UI.SmartTextBox();
            this.txtExpiration = new MyCTS.Forms.UI.SmartTextBox();
            this.txtNumberCard = new MyCTS.Forms.UI.SmartTextBox();
            this.lblMail = new System.Windows.Forms.Label();
            this.lblRequest = new System.Windows.Forms.Label();
            this.lblOffers = new System.Windows.Forms.Label();
            this.lblIssuingBank = new System.Windows.Forms.Label();
            this.lblExpiration = new System.Windows.Forms.Label();
            this.lblNumberCard = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.txtExchangeRate = new MyCTS.Forms.UI.SmartTextBox();
            this.txtUSD = new MyCTS.Forms.UI.SmartTextBox();
            this.txtIVA = new MyCTS.Forms.UI.SmartTextBox();
            this.lblExchangeRate = new System.Windows.Forms.Label();
            this.lblIVA = new System.Windows.Forms.Label();
            this.txtMXNorKG = new MyCTS.Forms.UI.SmartTextBox();
            this.lblMXNorKG = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.cmbRate = new System.Windows.Forms.ComboBox();
            this.rdoInternational = new System.Windows.Forms.RadioButton();
            this.rdoNational = new System.Windows.Forms.RadioButton();
            this.lblUSD = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.cmbTypeCard = new System.Windows.Forms.ComboBox();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmbServices
            // 
            this.cmbServices.DisplayMember = "Text";
            this.cmbServices.Location = new System.Drawing.Point(106, 31);
            this.cmbServices.Name = "cmbServices";
            this.cmbServices.Size = new System.Drawing.Size(202, 21);
            this.cmbServices.TabIndex = 0;
            this.cmbServices.ValueMember = "value";
            this.cmbServices.SelectedIndexChanged += new System.EventHandler(this.cmbServices_SelectedIndexChanged);
            // 
            // lblServices
            // 
            this.lblServices.AutoSize = true;
            this.lblServices.Location = new System.Drawing.Point(10, 34);
            this.lblServices.Name = "lblServices";
            this.lblServices.Size = new System.Drawing.Size(88, 13);
            this.lblServices.TabIndex = 34;
            this.lblServices.Text = "Elegir el  Servicio";
            // 
            // btnAccept
            // 
            this.btnAccept.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnAccept.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAccept.Location = new System.Drawing.Point(292, 464);
            this.btnAccept.Name = "btnAccept";
            this.btnAccept.Size = new System.Drawing.Size(100, 23);
            this.btnAccept.TabIndex = 30;
            this.btnAccept.Text = "Aceptar";
            this.btnAccept.UseVisualStyleBackColor = false;
            this.btnAccept.Click += new System.EventHandler(this.btnAccept_Click);
            // 
            // txtTicketorKilos
            // 
            this.txtTicketorKilos.AllowBlankSpaces = true;
            this.txtTicketorKilos.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtTicketorKilos.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.AnyCharacter;
            this.txtTicketorKilos.CustomExpression = ".*";
            this.txtTicketorKilos.EnterColor = System.Drawing.Color.Empty;
            this.txtTicketorKilos.LeaveColor = System.Drawing.Color.Empty;
            this.txtTicketorKilos.Location = new System.Drawing.Point(302, 150);
            this.txtTicketorKilos.MaxLength = 13;
            this.txtTicketorKilos.Name = "txtTicketorKilos";
            this.txtTicketorKilos.Size = new System.Drawing.Size(100, 20);
            this.txtTicketorKilos.TabIndex = 12;
            this.txtTicketorKilos.Visible = false;
            this.txtTicketorKilos.TextChanged += new System.EventHandler(this.txtTicketorKilos_TextChanged);
            this.txtTicketorKilos.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // lblTicketorKilos
            // 
            this.lblTicketorKilos.AutoSize = true;
            this.lblTicketorKilos.Location = new System.Drawing.Point(218, 154);
            this.lblTicketorKilos.Name = "lblTicketorKilos";
            this.lblTicketorKilos.Size = new System.Drawing.Size(0, 13);
            this.lblTicketorKilos.TabIndex = 0;
            this.lblTicketorKilos.Visible = false;
            // 
            // txtMail
            // 
            this.txtMail.AllowBlankSpaces = true;
            this.txtMail.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtMail.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.AnyCharacter;
            this.txtMail.CustomExpression = ".*";
            this.txtMail.EnterColor = System.Drawing.Color.Empty;
            this.txtMail.LeaveColor = System.Drawing.Color.Empty;
            this.txtMail.Location = new System.Drawing.Point(96, 371);
            this.txtMail.MaxLength = 40;
            this.txtMail.Name = "txtMail";
            this.txtMail.Size = new System.Drawing.Size(304, 20);
            this.txtMail.TabIndex = 29;
            this.txtMail.TextChanged += new System.EventHandler(this.txtMail_TextChanged);
            this.txtMail.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // txtRequest
            // 
            this.txtRequest.AllowBlankSpaces = true;
            this.txtRequest.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtRequest.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.AnyCharacter;
            this.txtRequest.CustomExpression = ".*";
            this.txtRequest.EnterColor = System.Drawing.Color.Empty;
            this.txtRequest.LeaveColor = System.Drawing.Color.Empty;
            this.txtRequest.Location = new System.Drawing.Point(96, 344);
            this.txtRequest.MaxLength = 40;
            this.txtRequest.Name = "txtRequest";
            this.txtRequest.Size = new System.Drawing.Size(304, 20);
            this.txtRequest.TabIndex = 28;
            this.txtRequest.TextChanged += new System.EventHandler(this.txtRequest_TextChanged);
            this.txtRequest.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // txtOffers
            // 
            this.txtOffers.AllowBlankSpaces = true;
            this.txtOffers.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtOffers.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.AnyCharacter;
            this.txtOffers.CustomExpression = ".*";
            this.txtOffers.Enabled = false;
            this.txtOffers.EnterColor = System.Drawing.Color.Empty;
            this.txtOffers.LeaveColor = System.Drawing.Color.Empty;
            this.txtOffers.Location = new System.Drawing.Point(194, 303);
            this.txtOffers.MaxLength = 30;
            this.txtOffers.Name = "txtOffers";
            this.txtOffers.Size = new System.Drawing.Size(206, 20);
            this.txtOffers.TabIndex = 27;
            this.txtOffers.TextChanged += new System.EventHandler(this.txtOffers_TextChanged);
            this.txtOffers.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // txtIssuingBank
            // 
            this.txtIssuingBank.AllowBlankSpaces = true;
            this.txtIssuingBank.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtIssuingBank.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.OnlyLetters;
            this.txtIssuingBank.CustomExpression = ".*";
            this.txtIssuingBank.Enabled = false;
            this.txtIssuingBank.EnterColor = System.Drawing.Color.Empty;
            this.txtIssuingBank.LeaveColor = System.Drawing.Color.Empty;
            this.txtIssuingBank.Location = new System.Drawing.Point(300, 280);
            this.txtIssuingBank.MaxLength = 20;
            this.txtIssuingBank.Name = "txtIssuingBank";
            this.txtIssuingBank.Size = new System.Drawing.Size(100, 20);
            this.txtIssuingBank.TabIndex = 26;
            this.txtIssuingBank.TextChanged += new System.EventHandler(this.txtIssuingBank_TextChanged);
            this.txtIssuingBank.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // txtExpiration
            // 
            this.txtExpiration.AllowBlankSpaces = true;
            this.txtExpiration.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtExpiration.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.OnlyNumbers;
            this.txtExpiration.CustomExpression = ".*";
            this.txtExpiration.Enabled = false;
            this.txtExpiration.EnterColor = System.Drawing.Color.Empty;
            this.txtExpiration.LeaveColor = System.Drawing.Color.Empty;
            this.txtExpiration.Location = new System.Drawing.Point(300, 255);
            this.txtExpiration.MaxLength = 20;
            this.txtExpiration.Name = "txtExpiration";
            this.txtExpiration.Size = new System.Drawing.Size(100, 20);
            this.txtExpiration.TabIndex = 23;
            this.txtExpiration.TextChanged += new System.EventHandler(this.txtExpiration_TextChanged);
            this.txtExpiration.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // txtNumberCard
            // 
            this.txtNumberCard.AllowBlankSpaces = false;
            this.txtNumberCard.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtNumberCard.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.OnlyNumbers;
            this.txtNumberCard.CustomExpression = ".*";
            this.txtNumberCard.Enabled = false;
            this.txtNumberCard.EnterColor = System.Drawing.Color.Empty;
            this.txtNumberCard.LeaveColor = System.Drawing.Color.Empty;
            this.txtNumberCard.Location = new System.Drawing.Point(300, 230);
            this.txtNumberCard.MaxLength = 16;
            this.txtNumberCard.Name = "txtNumberCard";
            this.txtNumberCard.Size = new System.Drawing.Size(100, 20);
            this.txtNumberCard.TabIndex = 22;
            this.txtNumberCard.TextChanged += new System.EventHandler(this.txtNumberCard_TextChanged);
            this.txtNumberCard.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // lblMail
            // 
            this.lblMail.AutoSize = true;
            this.lblMail.Location = new System.Drawing.Point(16, 370);
            this.lblMail.Name = "lblMail";
            this.lblMail.Size = new System.Drawing.Size(29, 13);
            this.lblMail.TabIndex = 0;
            this.lblMail.Text = "Mail:";
            // 
            // lblRequest
            // 
            this.lblRequest.AutoSize = true;
            this.lblRequest.Location = new System.Drawing.Point(8, 347);
            this.lblRequest.Name = "lblRequest";
            this.lblRequest.Size = new System.Drawing.Size(84, 13);
            this.lblRequest.TabIndex = 0;
            this.lblRequest.Text = "¿Quien Solicita?";
            // 
            // lblOffers
            // 
            this.lblOffers.AutoSize = true;
            this.lblOffers.ForeColor = System.Drawing.Color.DarkCyan;
            this.lblOffers.Location = new System.Drawing.Point(99, 306);
            this.lblOffers.Name = "lblOffers";
            this.lblOffers.Size = new System.Drawing.Size(59, 13);
            this.lblOffers.TabIndex = 0;
            this.lblOffers.Text = "Promoción:";
            // 
            // lblIssuingBank
            // 
            this.lblIssuingBank.AutoSize = true;
            this.lblIssuingBank.Location = new System.Drawing.Point(99, 282);
            this.lblIssuingBank.Name = "lblIssuingBank";
            this.lblIssuingBank.Size = new System.Drawing.Size(74, 13);
            this.lblIssuingBank.TabIndex = 0;
            this.lblIssuingBank.Text = "Banco emisor:";
            // 
            // lblExpiration
            // 
            this.lblExpiration.AutoSize = true;
            this.lblExpiration.Location = new System.Drawing.Point(99, 257);
            this.lblExpiration.Name = "lblExpiration";
            this.lblExpiration.Size = new System.Drawing.Size(68, 13);
            this.lblExpiration.TabIndex = 0;
            this.lblExpiration.Text = "Vencimiento:";
            // 
            // lblNumberCard
            // 
            this.lblNumberCard.AutoSize = true;
            this.lblNumberCard.Location = new System.Drawing.Point(99, 233);
            this.lblNumberCard.Name = "lblNumberCard";
            this.lblNumberCard.Size = new System.Drawing.Size(94, 13);
            this.lblNumberCard.TabIndex = 0;
            this.lblNumberCard.Text = "Número de tarjeta:";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(6, 208);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(78, 13);
            this.label13.TabIndex = 0;
            this.label13.Text = "Forma de pago";
            // 
            // txtExchangeRate
            // 
            this.txtExchangeRate.AllowBlankSpaces = true;
            this.txtExchangeRate.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtExchangeRate.CharsIncluded = new char[] {
        '.'};
            this.txtExchangeRate.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.OnlyNumbers;
            this.txtExchangeRate.CustomExpression = ".*";
            this.txtExchangeRate.Enabled = false;
            this.txtExchangeRate.EnterColor = System.Drawing.Color.Empty;
            this.txtExchangeRate.LeaveColor = System.Drawing.Color.Empty;
            this.txtExchangeRate.Location = new System.Drawing.Point(302, 124);
            this.txtExchangeRate.MaxLength = 9;
            this.txtExchangeRate.Name = "txtExchangeRate";
            this.txtExchangeRate.Size = new System.Drawing.Size(100, 20);
            this.txtExchangeRate.TabIndex = 10;
            this.txtExchangeRate.TextChanged += new System.EventHandler(this.txtExchangeRate_TextChanged);
            this.txtExchangeRate.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // txtUSD
            // 
            this.txtUSD.AllowBlankSpaces = true;
            this.txtUSD.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtUSD.CharsIncluded = new char[] {
        '.'};
            this.txtUSD.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.OnlyNumbers;
            this.txtUSD.CustomExpression = ".*";
            this.txtUSD.Enabled = false;
            this.txtUSD.EnterColor = System.Drawing.Color.Empty;
            this.txtUSD.LeaveColor = System.Drawing.Color.Empty;
            this.txtUSD.Location = new System.Drawing.Point(302, 99);
            this.txtUSD.MaxLength = 8;
            this.txtUSD.Name = "txtUSD";
            this.txtUSD.Size = new System.Drawing.Size(90, 20);
            this.txtUSD.TabIndex = 8;
            this.txtUSD.TextChanged += new System.EventHandler(this.txtUSD_TextChanged);
            this.txtUSD.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // txtIVA
            // 
            this.txtIVA.AllowBlankSpaces = true;
            this.txtIVA.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtIVA.CharsIncluded = new char[] {
        '.'};
            this.txtIVA.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.OnlyNumbers;
            this.txtIVA.CustomExpression = ".*";
            this.txtIVA.EnterColor = System.Drawing.Color.Empty;
            this.txtIVA.LeaveColor = System.Drawing.Color.Empty;
            this.txtIVA.Location = new System.Drawing.Point(78, 125);
            this.txtIVA.MaxLength = 7;
            this.txtIVA.Name = "txtIVA";
            this.txtIVA.Size = new System.Drawing.Size(100, 20);
            this.txtIVA.TabIndex = 11;
            this.txtIVA.TextChanged += new System.EventHandler(this.txtIVA_TextChanged);
            this.txtIVA.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // lblExchangeRate
            // 
            this.lblExchangeRate.AutoSize = true;
            this.lblExchangeRate.Location = new System.Drawing.Point(215, 127);
            this.lblExchangeRate.Name = "lblExchangeRate";
            this.lblExchangeRate.Size = new System.Drawing.Size(81, 13);
            this.lblExchangeRate.TabIndex = 0;
            this.lblExchangeRate.Text = "Tipo de Cambio";
            // 
            // lblIVA
            // 
            this.lblIVA.AutoSize = true;
            this.lblIVA.Location = new System.Drawing.Point(6, 127);
            this.lblIVA.Name = "lblIVA";
            this.lblIVA.Size = new System.Drawing.Size(24, 13);
            this.lblIVA.TabIndex = 0;
            this.lblIVA.Text = "IVA";
            // 
            // txtMXNorKG
            // 
            this.txtMXNorKG.AllowBlankSpaces = true;
            this.txtMXNorKG.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtMXNorKG.CharsIncluded = new char[] {
        '.'};
            this.txtMXNorKG.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.OnlyNumbers;
            this.txtMXNorKG.CustomExpression = ".*";
            this.txtMXNorKG.EnterColor = System.Drawing.Color.Empty;
            this.txtMXNorKG.LeaveColor = System.Drawing.Color.Empty;
            this.txtMXNorKG.Location = new System.Drawing.Point(78, 99);
            this.txtMXNorKG.MaxLength = 8;
            this.txtMXNorKG.Name = "txtMXNorKG";
            this.txtMXNorKG.Size = new System.Drawing.Size(115, 20);
            this.txtMXNorKG.TabIndex = 7;
            this.txtMXNorKG.TextChanged += new System.EventHandler(this.txtMXNorKG_TextChanged);
            this.txtMXNorKG.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // lblMXNorKG
            // 
            this.lblMXNorKG.AutoSize = true;
            this.lblMXNorKG.Location = new System.Drawing.Point(3, 108);
            this.lblMXNorKG.Name = "lblMXNorKG";
            this.lblMXNorKG.Size = new System.Drawing.Size(0, 13);
            this.lblMXNorKG.TabIndex = 0;
            // 
            // lblTitle
            // 
            this.lblTitle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(139)))), ((int)(((byte)(208)))));
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(3, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(405, 18);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Solicitud EMD";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.cmbRate);
            this.panel2.Controls.Add(this.rdoInternational);
            this.panel2.Controls.Add(this.rdoNational);
            this.panel2.Controls.Add(this.lblUSD);
            this.panel2.Location = new System.Drawing.Point(3, 67);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(408, 127);
            this.panel2.TabIndex = 32;
            // 
            // cmbRate
            // 
            this.cmbRate.FormattingEnabled = true;
            this.cmbRate.Items.AddRange(new object[] {
            "",
            "USD",
            "EUR",
            "GBP",
            "JPY",
            "CAD       ",
            "ARS",
            "AUD",
            "INR",
            "COP",
            "CNY"});
            this.cmbRate.Location = new System.Drawing.Point(215, 32);
            this.cmbRate.Name = "cmbRate";
            this.cmbRate.Size = new System.Drawing.Size(78, 21);
            this.cmbRate.TabIndex = 7;
            // 
            // rdoInternational
            // 
            this.rdoInternational.AutoSize = true;
            this.rdoInternational.Location = new System.Drawing.Point(90, 2);
            this.rdoInternational.Name = "rdoInternational";
            this.rdoInternational.Size = new System.Drawing.Size(86, 17);
            this.rdoInternational.TabIndex = 6;
            this.rdoInternational.TabStop = true;
            this.rdoInternational.Text = "Internacional";
            this.rdoInternational.UseVisualStyleBackColor = true;
            this.rdoInternational.CheckedChanged += new System.EventHandler(this.rdoInternational_CheckedChanged);
            this.rdoInternational.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            this.rdoInternational.KeyUp += new System.Windows.Forms.KeyEventHandler(this.rdoInternational_KeyUp);
            // 
            // rdoNational
            // 
            this.rdoNational.AutoSize = true;
            this.rdoNational.Location = new System.Drawing.Point(10, 2);
            this.rdoNational.Name = "rdoNational";
            this.rdoNational.Size = new System.Drawing.Size(67, 17);
            this.rdoNational.TabIndex = 5;
            this.rdoNational.TabStop = true;
            this.rdoNational.Text = "Nacional";
            this.rdoNational.UseVisualStyleBackColor = true;
            this.rdoNational.CheckedChanged += new System.EventHandler(this.rdoNational_CheckedChanged);
            this.rdoNational.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // lblUSD
            // 
            this.lblUSD.AutoSize = true;
            this.lblUSD.Location = new System.Drawing.Point(218, 15);
            this.lblUSD.Name = "lblUSD";
            this.lblUSD.Size = new System.Drawing.Size(37, 13);
            this.lblUSD.TabIndex = 0;
            this.lblUSD.Text = "Tarifa:";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.cmbTypeCard);
            this.panel3.Location = new System.Drawing.Point(93, 201);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(318, 135);
            this.panel3.TabIndex = 33;
            // 
            // cmbTypeCard
            // 
            this.cmbTypeCard.DisplayMember = "Text";
            this.cmbTypeCard.FormattingEnabled = true;
            this.cmbTypeCard.Items.AddRange(new object[] {
            "",
            "VISA",
            "UATP",
            "MASTER CARD",
            "AMERICAN EXPRESS",
            "MCO AEROMEXICO",
            "EFECTIVO"});
            this.cmbTypeCard.Location = new System.Drawing.Point(3, 4);
            this.cmbTypeCard.Name = "cmbTypeCard";
            this.cmbTypeCard.Size = new System.Drawing.Size(226, 21);
            this.cmbTypeCard.TabIndex = 165;
            this.cmbTypeCard.ValueMember = "Value";
            this.cmbTypeCard.SelectedIndexChanged += new System.EventHandler(this.cmbTypeCard_SelectedIndexChanged);
            // 
            // ucMPDVirtual
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.cmbServices);
            this.Controls.Add(this.lblServices);
            this.Controls.Add(this.btnAccept);
            this.Controls.Add(this.txtTicketorKilos);
            this.Controls.Add(this.lblTicketorKilos);
            this.Controls.Add(this.txtMail);
            this.Controls.Add(this.txtRequest);
            this.Controls.Add(this.txtOffers);
            this.Controls.Add(this.txtIssuingBank);
            this.Controls.Add(this.txtExpiration);
            this.Controls.Add(this.txtNumberCard);
            this.Controls.Add(this.lblMail);
            this.Controls.Add(this.lblRequest);
            this.Controls.Add(this.lblOffers);
            this.Controls.Add(this.lblIssuingBank);
            this.Controls.Add(this.lblExpiration);
            this.Controls.Add(this.lblNumberCard);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.txtExchangeRate);
            this.Controls.Add(this.txtUSD);
            this.Controls.Add(this.txtIVA);
            this.Controls.Add(this.lblExchangeRate);
            this.Controls.Add(this.lblIVA);
            this.Controls.Add(this.txtMXNorKG);
            this.Controls.Add(this.lblMXNorKG);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel3);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "ucMPDVirtual";
            this.Size = new System.Drawing.Size(411, 525);
            this.Load += new System.EventHandler(this.ucMPDVirtual_Load);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.RadioButton rdoNational;
        private System.Windows.Forms.RadioButton rdoInternational;
        private System.Windows.Forms.Label lblMXNorKG;
        private MyCTS.Forms.UI.SmartTextBox txtMXNorKG;
        private System.Windows.Forms.Label lblIVA;
        private System.Windows.Forms.Label lblExchangeRate;
        private MyCTS.Forms.UI.SmartTextBox txtIVA;
        private MyCTS.Forms.UI.SmartTextBox txtUSD;
        private MyCTS.Forms.UI.SmartTextBox txtExchangeRate;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label lblNumberCard;
        private System.Windows.Forms.Label lblExpiration;
        private System.Windows.Forms.Label lblIssuingBank;
        private System.Windows.Forms.Label lblOffers;
        private System.Windows.Forms.Label lblRequest;
        private System.Windows.Forms.Label lblMail;
        private MyCTS.Forms.UI.SmartTextBox txtNumberCard;
        private MyCTS.Forms.UI.SmartTextBox txtExpiration;
        private MyCTS.Forms.UI.SmartTextBox txtIssuingBank;
        private MyCTS.Forms.UI.SmartTextBox txtOffers;
        private MyCTS.Forms.UI.SmartTextBox txtRequest;
        private MyCTS.Forms.UI.SmartTextBox txtMail;
        private System.Windows.Forms.Label lblTicketorKilos;
        private MyCTS.Forms.UI.SmartTextBox txtTicketorKilos;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btnAccept;
        private System.Windows.Forms.Label lblServices;
        private System.Windows.Forms.ComboBox cmbServices;
        private System.Windows.Forms.ComboBox cmbTypeCard;
        private System.Windows.Forms.ComboBox cmbRate;
        private System.Windows.Forms.Label lblUSD;
    }
}
