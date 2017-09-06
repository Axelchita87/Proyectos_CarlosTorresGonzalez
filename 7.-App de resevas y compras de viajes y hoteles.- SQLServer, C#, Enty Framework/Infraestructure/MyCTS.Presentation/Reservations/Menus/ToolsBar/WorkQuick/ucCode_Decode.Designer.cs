namespace MyCTS.Presentation
{
    partial class ucCode_Decode
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
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.rdoAerline = new System.Windows.Forms.RadioButton();
            this.rdoAirplane = new System.Windows.Forms.RadioButton();
            this.rdoEatAir = new System.Windows.Forms.RadioButton();
            this.rdoAirpot = new System.Windows.Forms.RadioButton();
            this.rdoBus = new System.Windows.Forms.RadioButton();
            this.rdoAutomobile = new System.Windows.Forms.RadioButton();
            this.rdoDigitVerifier = new System.Windows.Forms.RadioButton();
            this.rdoCity = new System.Windows.Forms.RadioButton();
            this.rdoClassService = new System.Windows.Forms.RadioButton();
            this.rdoCountry = new System.Windows.Forms.RadioButton();
            this.rdoCreditCard = new System.Windows.Forms.RadioButton();
            this.rdoAgreementsTKT = new System.Windows.Forms.RadioButton();
            this.rdoHotels = new System.Windows.Forms.RadioButton();
            this.rdoDistanceAirports = new System.Windows.Forms.RadioButton();
            this.rdoNearCitiesAirport = new System.Windows.Forms.RadioButton();
            this.rdoLineCruices = new System.Windows.Forms.RadioButton();
            this.rdoStates = new System.Windows.Forms.RadioButton();
            this.rdoAgreementsFF = new System.Windows.Forms.RadioButton();
            this.rdoStatusCode = new System.Windows.Forms.RadioButton();
            this.rdoCurrencies = new System.Windows.Forms.RadioButton();
            this.btnAccept = new System.Windows.Forms.Button();
            this.txtAgreements1 = new MyCTS.Forms.UI.SmartTextBox();
            this.txtAgreements2 = new MyCTS.Forms.UI.SmartTextBox();
            this.lbGeneric = new System.Windows.Forms.ListBox();
            this.lblComment = new System.Windows.Forms.Label();
            this.lblOrigin = new System.Windows.Forms.Label();
            this.lblDestiny = new System.Windows.Forms.Label();
            this.rdoVendorsCode = new System.Windows.Forms.RadioButton();
            this.rdoTypeCard = new System.Windows.Forms.RadioButton();
            this.rdoEquipment = new System.Windows.Forms.RadioButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.rdoAirportNearCities = new System.Windows.Forms.RadioButton();
            this.txtAirportNearCities = new MyCTS.Forms.UI.SmartTextBox();
            this.btnAdvancePag = new System.Windows.Forms.Button();
            this.btnReturnPag = new System.Windows.Forms.Button();
            this.txtOption = new MyCTS.Forms.UI.SmartTextBox();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label15
            // 
            this.label15.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(139)))), ((int)(((byte)(208)))));
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.ForeColor = System.Drawing.Color.White;
            this.label15.Location = new System.Drawing.Point(3, 0);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(405, 13);
            this.label15.TabIndex = 0;
            this.label15.Text = "Codificar/Decodificar";
            this.label15.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(20, 26);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(156, 13);
            this.label16.TabIndex = 0;
            this.label16.Text = "Selecciona la opción  deseada:";
            this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // rdoAerline
            // 
            this.rdoAerline.AutoSize = true;
            this.rdoAerline.Location = new System.Drawing.Point(23, 56);
            this.rdoAerline.Name = "rdoAerline";
            this.rdoAerline.Size = new System.Drawing.Size(71, 17);
            this.rdoAerline.TabIndex = 1;
            this.rdoAerline.Text = "Aerolínea";
            this.rdoAerline.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rdoAerline.UseVisualStyleBackColor = true;
            this.rdoAerline.CheckedChanged += new System.EventHandler(this.ShowTextBox_CheckedChanged);
            this.rdoAerline.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // rdoAirplane
            // 
            this.rdoAirplane.AutoSize = true;
            this.rdoAirplane.Location = new System.Drawing.Point(23, 78);
            this.rdoAirplane.Name = "rdoAirplane";
            this.rdoAirplane.Size = new System.Drawing.Size(52, 17);
            this.rdoAirplane.TabIndex = 2;
            this.rdoAirplane.Text = "Avión";
            this.rdoAirplane.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rdoAirplane.UseVisualStyleBackColor = true;
            this.rdoAirplane.CheckedChanged += new System.EventHandler(this.ShowTextBox_CheckedChanged);
            this.rdoAirplane.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // rdoEatAir
            // 
            this.rdoEatAir.AutoSize = true;
            this.rdoEatAir.Location = new System.Drawing.Point(23, 103);
            this.rdoEatAir.Name = "rdoEatAir";
            this.rdoEatAir.Size = new System.Drawing.Size(101, 17);
            this.rdoEatAir.TabIndex = 3;
            this.rdoEatAir.Text = "Comidas Aéreas";
            this.rdoEatAir.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rdoEatAir.UseVisualStyleBackColor = true;
            this.rdoEatAir.CheckedChanged += new System.EventHandler(this.ShowTextBox_CheckedChanged);
            this.rdoEatAir.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // rdoAirpot
            // 
            this.rdoAirpot.AutoSize = true;
            this.rdoAirpot.Location = new System.Drawing.Point(23, 126);
            this.rdoAirpot.Name = "rdoAirpot";
            this.rdoAirpot.Size = new System.Drawing.Size(77, 17);
            this.rdoAirpot.TabIndex = 4;
            this.rdoAirpot.Text = "Aeropuerto";
            this.rdoAirpot.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rdoAirpot.UseVisualStyleBackColor = true;
            this.rdoAirpot.CheckedChanged += new System.EventHandler(this.ShowTextBox_CheckedChanged);
            this.rdoAirpot.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // rdoBus
            // 
            this.rdoBus.AutoSize = true;
            this.rdoBus.Location = new System.Drawing.Point(23, 151);
            this.rdoBus.Name = "rdoBus";
            this.rdoBus.Size = new System.Drawing.Size(64, 17);
            this.rdoBus.TabIndex = 5;
            this.rdoBus.Text = "Autobus";
            this.rdoBus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rdoBus.UseVisualStyleBackColor = true;
            this.rdoBus.CheckedChanged += new System.EventHandler(this.ShowTextBox_CheckedChanged);
            this.rdoBus.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // rdoAutomobile
            // 
            this.rdoAutomobile.AutoSize = true;
            this.rdoAutomobile.Location = new System.Drawing.Point(23, 289);
            this.rdoAutomobile.Name = "rdoAutomobile";
            this.rdoAutomobile.Size = new System.Drawing.Size(71, 17);
            this.rdoAutomobile.TabIndex = 11;
            this.rdoAutomobile.Text = "Automovil";
            this.rdoAutomobile.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rdoAutomobile.UseVisualStyleBackColor = true;
            this.rdoAutomobile.CheckedChanged += new System.EventHandler(this.rdoAutomobile_CheckedChanged);
            this.rdoAutomobile.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // rdoDigitVerifier
            // 
            this.rdoDigitVerifier.AutoSize = true;
            this.rdoDigitVerifier.Location = new System.Drawing.Point(23, 173);
            this.rdoDigitVerifier.Name = "rdoDigitVerifier";
            this.rdoDigitVerifier.Size = new System.Drawing.Size(105, 17);
            this.rdoDigitVerifier.TabIndex = 6;
            this.rdoDigitVerifier.Text = "Digito Verificador";
            this.rdoDigitVerifier.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rdoDigitVerifier.UseVisualStyleBackColor = true;
            this.rdoDigitVerifier.CheckedChanged += new System.EventHandler(this.ShowTextBox_CheckedChanged);
            this.rdoDigitVerifier.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // rdoCity
            // 
            this.rdoCity.AutoSize = true;
            this.rdoCity.Location = new System.Drawing.Point(23, 196);
            this.rdoCity.Name = "rdoCity";
            this.rdoCity.Size = new System.Drawing.Size(58, 17);
            this.rdoCity.TabIndex = 7;
            this.rdoCity.Text = "Ciudad";
            this.rdoCity.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rdoCity.UseVisualStyleBackColor = true;
            this.rdoCity.CheckedChanged += new System.EventHandler(this.ShowTextBox_CheckedChanged);
            this.rdoCity.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // rdoClassService
            // 
            this.rdoClassService.AutoSize = true;
            this.rdoClassService.Location = new System.Drawing.Point(23, 221);
            this.rdoClassService.Name = "rdoClassService";
            this.rdoClassService.Size = new System.Drawing.Size(105, 17);
            this.rdoClassService.TabIndex = 8;
            this.rdoClassService.Text = "Clase de servicio";
            this.rdoClassService.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rdoClassService.UseVisualStyleBackColor = true;
            this.rdoClassService.CheckedChanged += new System.EventHandler(this.ShowTextBox_CheckedChanged);
            this.rdoClassService.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // rdoCountry
            // 
            this.rdoCountry.AutoSize = true;
            this.rdoCountry.Location = new System.Drawing.Point(23, 245);
            this.rdoCountry.Name = "rdoCountry";
            this.rdoCountry.Size = new System.Drawing.Size(47, 17);
            this.rdoCountry.TabIndex = 9;
            this.rdoCountry.Text = "País";
            this.rdoCountry.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rdoCountry.UseVisualStyleBackColor = true;
            this.rdoCountry.CheckedChanged += new System.EventHandler(this.ShowTextBox_CheckedChanged);
            this.rdoCountry.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // rdoCreditCard
            // 
            this.rdoCreditCard.AutoSize = true;
            this.rdoCreditCard.Location = new System.Drawing.Point(23, 266);
            this.rdoCreditCard.Name = "rdoCreditCard";
            this.rdoCreditCard.Size = new System.Drawing.Size(109, 17);
            this.rdoCreditCard.TabIndex = 10;
            this.rdoCreditCard.Text = "Tarjeta de Crédito";
            this.rdoCreditCard.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rdoCreditCard.UseVisualStyleBackColor = true;
            this.rdoCreditCard.CheckedChanged += new System.EventHandler(this.ShowTextBox_CheckedChanged);
            this.rdoCreditCard.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // rdoAgreementsTKT
            // 
            this.rdoAgreementsTKT.AutoSize = true;
            this.rdoAgreementsTKT.Location = new System.Drawing.Point(196, 273);
            this.rdoAgreementsTKT.Name = "rdoAgreementsTKT";
            this.rdoAgreementsTKT.Size = new System.Drawing.Size(105, 17);
            this.rdoAgreementsTKT.TabIndex = 23;
            this.rdoAgreementsTKT.Text = "Convenios eTKT";
            this.rdoAgreementsTKT.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rdoAgreementsTKT.UseVisualStyleBackColor = true;
            this.rdoAgreementsTKT.CheckedChanged += new System.EventHandler(this.rdoAgreementsTKT_CheckedChanged);
            this.rdoAgreementsTKT.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // rdoHotels
            // 
            this.rdoHotels.AutoSize = true;
            this.rdoHotels.Location = new System.Drawing.Point(196, 56);
            this.rdoHotels.Name = "rdoHotels";
            this.rdoHotels.Size = new System.Drawing.Size(61, 17);
            this.rdoHotels.TabIndex = 15;
            this.rdoHotels.Text = "Hoteles";
            this.rdoHotels.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rdoHotels.UseVisualStyleBackColor = true;
            this.rdoHotels.CheckedChanged += new System.EventHandler(this.ShowTextBox_CheckedChanged);
            this.rdoHotels.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // rdoDistanceAirports
            // 
            this.rdoDistanceAirports.AutoSize = true;
            this.rdoDistanceAirports.Location = new System.Drawing.Point(196, 78);
            this.rdoDistanceAirports.Name = "rdoDistanceAirports";
            this.rdoDistanceAirports.Size = new System.Drawing.Size(157, 17);
            this.rdoDistanceAirports.TabIndex = 16;
            this.rdoDistanceAirports.Text = "Distancia entre aeropuestos";
            this.rdoDistanceAirports.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rdoDistanceAirports.UseVisualStyleBackColor = true;
            this.rdoDistanceAirports.CheckedChanged += new System.EventHandler(this.rdoDistanceAirports_CheckedChanged);
            this.rdoDistanceAirports.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // rdoNearCitiesAirport
            // 
            this.rdoNearCitiesAirport.AutoSize = true;
            this.rdoNearCitiesAirport.Location = new System.Drawing.Point(196, 103);
            this.rdoNearCitiesAirport.Name = "rdoNearCitiesAirport";
            this.rdoNearCitiesAirport.Size = new System.Drawing.Size(194, 17);
            this.rdoNearCitiesAirport.TabIndex = 17;
            this.rdoNearCitiesAirport.Text = "Ciudades cercanas a un aeropuerto";
            this.rdoNearCitiesAirport.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rdoNearCitiesAirport.UseVisualStyleBackColor = true;
            this.rdoNearCitiesAirport.CheckedChanged += new System.EventHandler(this.rdoNearCitiesAirport_CheckedChanged);
            this.rdoNearCitiesAirport.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // rdoLineCruices
            // 
            this.rdoLineCruices.AutoSize = true;
            this.rdoLineCruices.Location = new System.Drawing.Point(196, 151);
            this.rdoLineCruices.Name = "rdoLineCruices";
            this.rdoLineCruices.Size = new System.Drawing.Size(113, 17);
            this.rdoLineCruices.TabIndex = 18;
            this.rdoLineCruices.Text = "Línea de Cruceros";
            this.rdoLineCruices.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rdoLineCruices.UseVisualStyleBackColor = true;
            this.rdoLineCruices.CheckedChanged += new System.EventHandler(this.ShowTextBox_CheckedChanged);
            this.rdoLineCruices.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // rdoStates
            // 
            this.rdoStates.AutoSize = true;
            this.rdoStates.Location = new System.Drawing.Point(196, 176);
            this.rdoStates.Name = "rdoStates";
            this.rdoStates.Size = new System.Drawing.Size(94, 17);
            this.rdoStates.TabIndex = 19;
            this.rdoStates.Text = "Estados (USA)";
            this.rdoStates.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rdoStates.UseVisualStyleBackColor = true;
            this.rdoStates.CheckedChanged += new System.EventHandler(this.ShowTextBox_CheckedChanged);
            this.rdoStates.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // rdoAgreementsFF
            // 
            this.rdoAgreementsFF.AutoSize = true;
            this.rdoAgreementsFF.Location = new System.Drawing.Point(196, 249);
            this.rdoAgreementsFF.Name = "rdoAgreementsFF";
            this.rdoAgreementsFF.Size = new System.Drawing.Size(145, 17);
            this.rdoAgreementsFF.TabIndex = 22;
            this.rdoAgreementsFF.Text = "Convenios Frecuent Flyer";
            this.rdoAgreementsFF.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rdoAgreementsFF.UseVisualStyleBackColor = true;
            this.rdoAgreementsFF.CheckedChanged += new System.EventHandler(this.ShowTextBox_CheckedChanged);
            this.rdoAgreementsFF.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // rdoStatusCode
            // 
            this.rdoStatusCode.AutoSize = true;
            this.rdoStatusCode.Location = new System.Drawing.Point(196, 198);
            this.rdoStatusCode.Name = "rdoStatusCode";
            this.rdoStatusCode.Size = new System.Drawing.Size(111, 17);
            this.rdoStatusCode.TabIndex = 20;
            this.rdoStatusCode.Text = "Código de Estatus";
            this.rdoStatusCode.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rdoStatusCode.UseVisualStyleBackColor = true;
            this.rdoStatusCode.CheckedChanged += new System.EventHandler(this.ShowTextBox_CheckedChanged);
            this.rdoStatusCode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // rdoCurrencies
            // 
            this.rdoCurrencies.AutoSize = true;
            this.rdoCurrencies.Location = new System.Drawing.Point(196, 224);
            this.rdoCurrencies.Name = "rdoCurrencies";
            this.rdoCurrencies.Size = new System.Drawing.Size(69, 17);
            this.rdoCurrencies.TabIndex = 21;
            this.rdoCurrencies.Text = "Monedas";
            this.rdoCurrencies.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rdoCurrencies.UseVisualStyleBackColor = true;
            this.rdoCurrencies.CheckedChanged += new System.EventHandler(this.ShowTextBox_CheckedChanged);
            this.rdoCurrencies.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // btnAccept
            // 
            this.btnAccept.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnAccept.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAccept.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAccept.Location = new System.Drawing.Point(270, 525);
            this.btnAccept.Name = "btnAccept";
            this.btnAccept.Size = new System.Drawing.Size(100, 24);
            this.btnAccept.TabIndex = 28;
            this.btnAccept.Text = "Aceptar";
            this.btnAccept.UseVisualStyleBackColor = false;
            this.btnAccept.Click += new System.EventHandler(this.btnAccept_Click);
            // 
            // txtAgreements1
            // 
            this.txtAgreements1.AllowBlankSpaces = true;
            this.txtAgreements1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtAgreements1.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.AnyCharacter;
            this.txtAgreements1.CustomExpression = ".*";
            this.txtAgreements1.EnterColor = System.Drawing.Color.Empty;
            this.txtAgreements1.LeaveColor = System.Drawing.Color.Empty;
            this.txtAgreements1.Location = new System.Drawing.Point(23, 397);
            this.txtAgreements1.MaxLength = 3;
            this.txtAgreements1.Name = "txtAgreements1";
            this.txtAgreements1.Size = new System.Drawing.Size(58, 20);
            this.txtAgreements1.TabIndex = 25;
            this.txtAgreements1.Visible = false;
            this.txtAgreements1.TextChanged += new System.EventHandler(this.txtAgreements1_TextChanged);
            this.txtAgreements1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // txtAgreements2
            // 
            this.txtAgreements2.AllowBlankSpaces = true;
            this.txtAgreements2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtAgreements2.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.AnyCharacter;
            this.txtAgreements2.CustomExpression = ".*";
            this.txtAgreements2.EnterColor = System.Drawing.Color.Empty;
            this.txtAgreements2.LeaveColor = System.Drawing.Color.Empty;
            this.txtAgreements2.Location = new System.Drawing.Point(92, 397);
            this.txtAgreements2.MaxLength = 3;
            this.txtAgreements2.Name = "txtAgreements2";
            this.txtAgreements2.Size = new System.Drawing.Size(56, 20);
            this.txtAgreements2.TabIndex = 26;
            this.txtAgreements2.Visible = false;
            this.txtAgreements2.TextChanged += new System.EventHandler(this.txtAgreements2_TextChanged);
            this.txtAgreements2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // lbGeneric
            // 
            this.lbGeneric.DisplayMember = "Text";
            this.lbGeneric.FormattingEnabled = true;
            this.lbGeneric.Location = new System.Drawing.Point(23, 391);
            this.lbGeneric.Name = "lbGeneric";
            this.lbGeneric.Size = new System.Drawing.Size(255, 95);
            this.lbGeneric.TabIndex = 27;
            this.lbGeneric.ValueMember = "Value";
            this.lbGeneric.Visible = false;
            this.lbGeneric.MouseClick += new System.Windows.Forms.MouseEventHandler(this.ListBox_MouseClick);
            this.lbGeneric.KeyDown += new System.Windows.Forms.KeyEventHandler(this.lbGeneric_KeyDown);
            // 
            // lblComment
            // 
            this.lblComment.AutoSize = true;
            this.lblComment.Location = new System.Drawing.Point(23, 350);
            this.lblComment.Name = "lblComment";
            this.lblComment.Size = new System.Drawing.Size(0, 13);
            this.lblComment.TabIndex = 27;
            this.lblComment.Visible = false;
            // 
            // lblOrigin
            // 
            this.lblOrigin.AutoSize = true;
            this.lblOrigin.Location = new System.Drawing.Point(23, 381);
            this.lblOrigin.Name = "lblOrigin";
            this.lblOrigin.Size = new System.Drawing.Size(38, 13);
            this.lblOrigin.TabIndex = 0;
            this.lblOrigin.Text = "Origen";
            this.lblOrigin.Visible = false;
            // 
            // lblDestiny
            // 
            this.lblDestiny.AutoSize = true;
            this.lblDestiny.Location = new System.Drawing.Point(89, 381);
            this.lblDestiny.Name = "lblDestiny";
            this.lblDestiny.Size = new System.Drawing.Size(43, 13);
            this.lblDestiny.TabIndex = 0;
            this.lblDestiny.Text = "Destino";
            this.lblDestiny.Visible = false;
            // 
            // rdoVendorsCode
            // 
            this.rdoVendorsCode.AutoSize = true;
            this.rdoVendorsCode.Location = new System.Drawing.Point(3, 3);
            this.rdoVendorsCode.Name = "rdoVendorsCode";
            this.rdoVendorsCode.Size = new System.Drawing.Size(83, 17);
            this.rdoVendorsCode.TabIndex = 12;
            this.rdoVendorsCode.TabStop = true;
            this.rdoVendorsCode.Text = "Arrendadora";
            this.rdoVendorsCode.UseVisualStyleBackColor = true;
            this.rdoVendorsCode.Visible = false;
            this.rdoVendorsCode.CheckedChanged += new System.EventHandler(this.rdoVendorsCode_CheckedChanged);
            // 
            // rdoTypeCard
            // 
            this.rdoTypeCard.AutoSize = true;
            this.rdoTypeCard.Location = new System.Drawing.Point(92, 3);
            this.rdoTypeCard.Name = "rdoTypeCard";
            this.rdoTypeCard.Size = new System.Drawing.Size(86, 17);
            this.rdoTypeCard.TabIndex = 13;
            this.rdoTypeCard.TabStop = true;
            this.rdoTypeCard.Text = "Tipo de Auto";
            this.rdoTypeCard.UseVisualStyleBackColor = true;
            this.rdoTypeCard.Visible = false;
            this.rdoTypeCard.CheckedChanged += new System.EventHandler(this.rdoTypeCard_CheckedChanged);
            // 
            // rdoEquipment
            // 
            this.rdoEquipment.AutoSize = true;
            this.rdoEquipment.Location = new System.Drawing.Point(184, 3);
            this.rdoEquipment.Name = "rdoEquipment";
            this.rdoEquipment.Size = new System.Drawing.Size(87, 17);
            this.rdoEquipment.TabIndex = 14;
            this.rdoEquipment.TabStop = true;
            this.rdoEquipment.Text = "Eq. Adicional";
            this.rdoEquipment.UseVisualStyleBackColor = true;
            this.rdoEquipment.Visible = false;
            this.rdoEquipment.CheckedChanged += new System.EventHandler(this.rdoEquipment_CheckedChanged);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.rdoVendorsCode);
            this.panel1.Controls.Add(this.rdoEquipment);
            this.panel1.Controls.Add(this.rdoTypeCard);
            this.panel1.Location = new System.Drawing.Point(64, 312);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(289, 34);
            this.panel1.TabIndex = 33;
            // 
            // rdoAirportNearCities
            // 
            this.rdoAirportNearCities.AutoSize = true;
            this.rdoAirportNearCities.Location = new System.Drawing.Point(196, 127);
            this.rdoAirportNearCities.Name = "rdoAirportNearCities";
            this.rdoAirportNearCities.Size = new System.Drawing.Size(195, 17);
            this.rdoAirportNearCities.TabIndex = 34;
            this.rdoAirportNearCities.TabStop = true;
            this.rdoAirportNearCities.Text = "Aeropuertos cercanos a una Ciudad";
            this.rdoAirportNearCities.UseVisualStyleBackColor = true;
            this.rdoAirportNearCities.CheckedChanged += new System.EventHandler(this.rdoAirportNearCities_CheckedChanged);
            // 
            // txtAirportNearCities
            // 
            this.txtAirportNearCities.AllowBlankSpaces = true;
            this.txtAirportNearCities.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtAirportNearCities.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.OnlyLetters;
            this.txtAirportNearCities.CustomExpression = ".*";
            this.txtAirportNearCities.EnterColor = System.Drawing.Color.Empty;
            this.txtAirportNearCities.LeaveColor = System.Drawing.Color.Empty;
            this.txtAirportNearCities.Location = new System.Drawing.Point(23, 397);
            this.txtAirportNearCities.MaxLength = 20;
            this.txtAirportNearCities.Name = "txtAirportNearCities";
            this.txtAirportNearCities.Size = new System.Drawing.Size(164, 20);
            this.txtAirportNearCities.TabIndex = 35;
            this.txtAirportNearCities.Visible = false;
            this.txtAirportNearCities.TextChanged += new System.EventHandler(this.txtAirportNearCities_TextChanged);
            this.txtAirportNearCities.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // btnAdvancePag
            // 
            this.btnAdvancePag.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnAdvancePag.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdvancePag.Location = new System.Drawing.Point(33, 523);
            this.btnAdvancePag.Name = "btnAdvancePag";
            this.btnAdvancePag.Size = new System.Drawing.Size(95, 26);
            this.btnAdvancePag.TabIndex = 36;
            this.btnAdvancePag.Text = "Av.Pág.";
            this.btnAdvancePag.UseVisualStyleBackColor = false;
            this.btnAdvancePag.Visible = false;
            this.btnAdvancePag.Click += new System.EventHandler(this.btnAdvancePag_Click);
            // 
            // btnReturnPag
            // 
            this.btnReturnPag.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnReturnPag.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReturnPag.Location = new System.Drawing.Point(150, 523);
            this.btnReturnPag.Name = "btnReturnPag";
            this.btnReturnPag.Size = new System.Drawing.Size(92, 26);
            this.btnReturnPag.TabIndex = 37;
            this.btnReturnPag.Text = "Reg.Pág.";
            this.btnReturnPag.UseVisualStyleBackColor = false;
            this.btnReturnPag.Visible = false;
            this.btnReturnPag.Click += new System.EventHandler(this.btnReturnPag_Click);
            // 
            // txtOption
            // 
            this.txtOption.AllowBlankSpaces = true;
            this.txtOption.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtOption.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.AnyCharacter;
            this.txtOption.CustomExpression = ".*";
            this.txtOption.EnterColor = System.Drawing.Color.Empty;
            this.txtOption.LeaveColor = System.Drawing.Color.Empty;
            this.txtOption.Location = new System.Drawing.Point(23, 374);
            this.txtOption.Name = "txtOption";
            this.txtOption.Size = new System.Drawing.Size(255, 20);
            this.txtOption.TabIndex = 38;
            this.txtOption.Visible = false;
            this.txtOption.TextChanged += new System.EventHandler(this.txtOption_TextChanged);
            this.txtOption.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // ucCode_Decode
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.btnAdvancePag);
            this.Controls.Add(this.btnReturnPag);
            this.Controls.Add(this.txtAirportNearCities);
            this.Controls.Add(this.rdoAirportNearCities);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lblDestiny);
            this.Controls.Add(this.lblOrigin);
            this.Controls.Add(this.lblComment);
            this.Controls.Add(this.txtAgreements1);
            this.Controls.Add(this.txtAgreements2);
            this.Controls.Add(this.btnAccept);
            this.Controls.Add(this.rdoAgreementsTKT);
            this.Controls.Add(this.rdoHotels);
            this.Controls.Add(this.rdoDistanceAirports);
            this.Controls.Add(this.rdoNearCitiesAirport);
            this.Controls.Add(this.rdoLineCruices);
            this.Controls.Add(this.rdoStates);
            this.Controls.Add(this.rdoAgreementsFF);
            this.Controls.Add(this.rdoStatusCode);
            this.Controls.Add(this.rdoCurrencies);
            this.Controls.Add(this.rdoAerline);
            this.Controls.Add(this.rdoAirplane);
            this.Controls.Add(this.rdoEatAir);
            this.Controls.Add(this.rdoAirpot);
            this.Controls.Add(this.rdoBus);
            this.Controls.Add(this.rdoAutomobile);
            this.Controls.Add(this.rdoDigitVerifier);
            this.Controls.Add(this.rdoCity);
            this.Controls.Add(this.rdoClassService);
            this.Controls.Add(this.rdoCountry);
            this.Controls.Add(this.rdoCreditCard);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.lbGeneric);
            this.Controls.Add(this.txtOption);
            this.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "ucCode_Decode";
            this.Size = new System.Drawing.Size(411, 580);
            this.Load += new System.EventHandler(this.ucCode_Decode_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.RadioButton rdoAerline;
        private System.Windows.Forms.RadioButton rdoAirplane;
        private System.Windows.Forms.RadioButton rdoEatAir;
        private System.Windows.Forms.RadioButton rdoAirpot;
        private System.Windows.Forms.RadioButton rdoBus;
        private System.Windows.Forms.RadioButton rdoAutomobile;
        private System.Windows.Forms.RadioButton rdoDigitVerifier;
        private System.Windows.Forms.RadioButton rdoCity;
        private System.Windows.Forms.RadioButton rdoClassService;
        private System.Windows.Forms.RadioButton rdoCountry;
        private System.Windows.Forms.RadioButton rdoCreditCard;
        private System.Windows.Forms.RadioButton rdoAgreementsTKT;
        private System.Windows.Forms.RadioButton rdoHotels;
        private System.Windows.Forms.RadioButton rdoDistanceAirports;
        private System.Windows.Forms.RadioButton rdoNearCitiesAirport;
        private System.Windows.Forms.RadioButton rdoLineCruices;
        private System.Windows.Forms.RadioButton rdoStates;
        private System.Windows.Forms.RadioButton rdoAgreementsFF;
        private System.Windows.Forms.RadioButton rdoStatusCode;
        private System.Windows.Forms.RadioButton rdoCurrencies;
        private System.Windows.Forms.Button btnAccept;
        private MyCTS.Forms.UI.SmartTextBox txtAgreements1;
        private MyCTS.Forms.UI.SmartTextBox txtAgreements2;
        private System.Windows.Forms.ListBox lbGeneric;
        private System.Windows.Forms.Label lblComment;
        private System.Windows.Forms.Label lblOrigin;
        private System.Windows.Forms.Label lblDestiny;
        private System.Windows.Forms.RadioButton rdoVendorsCode;
        private System.Windows.Forms.RadioButton rdoTypeCard;
        private System.Windows.Forms.RadioButton rdoEquipment;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RadioButton rdoAirportNearCities;
        private MyCTS.Forms.UI.SmartTextBox txtAirportNearCities;
        private System.Windows.Forms.Button btnAdvancePag;
        private System.Windows.Forms.Button btnReturnPag;
        private MyCTS.Forms.UI.SmartTextBox txtOption;

    }
}
