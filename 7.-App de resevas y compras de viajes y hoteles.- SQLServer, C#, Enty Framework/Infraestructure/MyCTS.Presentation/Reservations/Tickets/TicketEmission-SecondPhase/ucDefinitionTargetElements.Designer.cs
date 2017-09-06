namespace MyCTS.Presentation
{
    partial class ucDefinitionTargetElements
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucDefinitionTargetElements));
            this.lblChargePerService = new System.Windows.Forms.Label();
            this.txtOrigin = new MyCTS.Forms.UI.SmartTextBox();
            this.btnAccept = new System.Windows.Forms.Button();
            this.lblOrigin = new System.Windows.Forms.Label();
            this.txtDestino = new MyCTS.Forms.UI.SmartTextBox();
            this.txtTravelDate = new MyCTS.Forms.UI.SmartTextBox();
            this.txtEmissionDate = new MyCTS.Forms.UI.SmartTextBox();
            this.txtAdvancePurche = new MyCTS.Forms.UI.SmartTextBox();
            this.lblDestino = new System.Windows.Forms.Label();
            this.lblTravelDate = new System.Windows.Forms.Label();
            this.lblLocation = new System.Windows.Forms.Label();
            this.lblpaxType = new System.Windows.Forms.Label();
            this.lblEmitionDate = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbDays = new System.Windows.Forms.ComboBox();
            this.lblDayEmission = new System.Windows.Forms.Label();
            this.lblTicketType = new System.Windows.Forms.Label();
            this.cmbTicketType = new System.Windows.Forms.ComboBox();
            this.cmbPaxType = new System.Windows.Forms.ComboBox();
            this.monthCalendar1 = new System.Windows.Forms.MonthCalendar();
            this.picCalendar = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.monthCalendar2 = new System.Windows.Forms.MonthCalendar();
            this.lbCityCode = new System.Windows.Forms.ListBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbLocationDK = new System.Windows.Forms.ComboBox();
            this.cmbLocationDKNoAllow = new System.Windows.Forms.ComboBox();
            this.lblAgent = new System.Windows.Forms.Label();
            this.txtAgent = new MyCTS.Forms.UI.SmartTextBox();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.picCalendar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // lblChargePerService
            // 
            this.lblChargePerService.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(139)))), ((int)(((byte)(208)))));
            this.lblChargePerService.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblChargePerService.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblChargePerService.ForeColor = System.Drawing.Color.White;
            this.lblChargePerService.Location = new System.Drawing.Point(0, 0);
            this.lblChargePerService.Name = "lblChargePerService";
            this.lblChargePerService.Size = new System.Drawing.Size(411, 17);
            this.lblChargePerService.TabIndex = 44;
            this.lblChargePerService.Text = "Definición de los criterios para la regla de cargo por servicio";
            this.lblChargePerService.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtOrigin
            // 
            this.txtOrigin.AllowBlankSpaces = false;
            this.txtOrigin.BackColor = System.Drawing.SystemColors.Window;
            this.txtOrigin.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtOrigin.CharsIncluded = new char[0];
            this.txtOrigin.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.OnlyLetters;
            this.txtOrigin.CustomExpression = ".*";
            this.txtOrigin.EnterColor = System.Drawing.Color.White;
            this.txtOrigin.LeaveColor = System.Drawing.Color.Empty;
            this.txtOrigin.Location = new System.Drawing.Point(132, 56);
            this.txtOrigin.MaxLength = 52;
            this.txtOrigin.Name = "txtOrigin";
            this.txtOrigin.Size = new System.Drawing.Size(171, 20);
            this.txtOrigin.TabIndex = 1;
            this.txtOrigin.TextChanged += new System.EventHandler(this.txtOrigin_TextChanged);
            this.txtOrigin.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CityCodeActions_KeyDown);
            // 
            // btnAccept
            // 
            this.btnAccept.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnAccept.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAccept.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAccept.Location = new System.Drawing.Point(264, 488);
            this.btnAccept.Name = "btnAccept";
            this.btnAccept.Size = new System.Drawing.Size(110, 24);
            this.btnAccept.TabIndex = 14;
            this.btnAccept.Text = "Siguiente →";
            this.btnAccept.UseVisualStyleBackColor = false;
            this.btnAccept.Click += new System.EventHandler(this.btnAccept_Click);
            // 
            // lblOrigin
            // 
            this.lblOrigin.AutoSize = true;
            this.lblOrigin.ForeColor = System.Drawing.Color.DarkCyan;
            this.lblOrigin.Location = new System.Drawing.Point(24, 62);
            this.lblOrigin.Name = "lblOrigin";
            this.lblOrigin.Size = new System.Drawing.Size(41, 13);
            this.lblOrigin.TabIndex = 45;
            this.lblOrigin.Text = "Origen:";
            // 
            // txtDestino
            // 
            this.txtDestino.AllowBlankSpaces = false;
            this.txtDestino.BackColor = System.Drawing.SystemColors.Window;
            this.txtDestino.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtDestino.CharsIncluded = new char[0];
            this.txtDestino.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.OnlyLetters;
            this.txtDestino.CustomExpression = ".*";
            this.txtDestino.EnterColor = System.Drawing.Color.White;
            this.txtDestino.LeaveColor = System.Drawing.Color.Empty;
            this.txtDestino.Location = new System.Drawing.Point(132, 91);
            this.txtDestino.MaxLength = 52;
            this.txtDestino.Name = "txtDestino";
            this.txtDestino.Size = new System.Drawing.Size(171, 20);
            this.txtDestino.TabIndex = 2;
            this.txtDestino.TextChanged += new System.EventHandler(this.txtOrigin_TextChanged);
            this.txtDestino.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CityCodeActions_KeyDown);
            // 
            // txtTravelDate
            // 
            this.txtTravelDate.AllowBlankSpaces = false;
            this.txtTravelDate.BackColor = System.Drawing.SystemColors.Window;
            this.txtTravelDate.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtTravelDate.CharsIncluded = new char[0];
            this.txtTravelDate.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.NumbersOrLetters;
            this.txtTravelDate.CustomExpression = ".*";
            this.txtTravelDate.EnterColor = System.Drawing.Color.White;
            this.txtTravelDate.LeaveColor = System.Drawing.Color.Empty;
            this.txtTravelDate.Location = new System.Drawing.Point(132, 127);
            this.txtTravelDate.MaxLength = 7;
            this.txtTravelDate.Name = "txtTravelDate";
            this.txtTravelDate.Size = new System.Drawing.Size(88, 20);
            this.txtTravelDate.TabIndex = 3;
            this.txtTravelDate.TextChanged += new System.EventHandler(this.txtControls_TextChanged);
            this.txtTravelDate.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // txtEmissionDate
            // 
            this.txtEmissionDate.AllowBlankSpaces = false;
            this.txtEmissionDate.BackColor = System.Drawing.SystemColors.Window;
            this.txtEmissionDate.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtEmissionDate.CharsIncluded = new char[0];
            this.txtEmissionDate.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.NumbersOrLetters;
            this.txtEmissionDate.CustomExpression = ".*";
            this.txtEmissionDate.EnterColor = System.Drawing.Color.White;
            this.txtEmissionDate.LeaveColor = System.Drawing.Color.Empty;
            this.txtEmissionDate.Location = new System.Drawing.Point(132, 241);
            this.txtEmissionDate.MaxLength = 7;
            this.txtEmissionDate.Name = "txtEmissionDate";
            this.txtEmissionDate.Size = new System.Drawing.Size(88, 20);
            this.txtEmissionDate.TabIndex = 8;
            this.txtEmissionDate.TextChanged += new System.EventHandler(this.txtControls_TextChanged);
            this.txtEmissionDate.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // txtAdvancePurche
            // 
            this.txtAdvancePurche.AllowBlankSpaces = false;
            this.txtAdvancePurche.BackColor = System.Drawing.SystemColors.Window;
            this.txtAdvancePurche.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtAdvancePurche.CharsIncluded = new char[0];
            this.txtAdvancePurche.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.OnlyNumbers;
            this.txtAdvancePurche.CustomExpression = ".*";
            this.txtAdvancePurche.EnterColor = System.Drawing.Color.White;
            this.txtAdvancePurche.LeaveColor = System.Drawing.Color.Empty;
            this.txtAdvancePurche.Location = new System.Drawing.Point(132, 277);
            this.txtAdvancePurche.MaxLength = 2;
            this.txtAdvancePurche.Name = "txtAdvancePurche";
            this.txtAdvancePurche.Size = new System.Drawing.Size(42, 20);
            this.txtAdvancePurche.TabIndex = 9;
            this.txtAdvancePurche.TextChanged += new System.EventHandler(this.txtControls_TextChanged);
            this.txtAdvancePurche.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // lblDestino
            // 
            this.lblDestino.AutoSize = true;
            this.lblDestino.ForeColor = System.Drawing.Color.DarkCyan;
            this.lblDestino.Location = new System.Drawing.Point(24, 97);
            this.lblDestino.Name = "lblDestino";
            this.lblDestino.Size = new System.Drawing.Size(46, 13);
            this.lblDestino.TabIndex = 46;
            this.lblDestino.Text = "Destino:";
            // 
            // lblTravelDate
            // 
            this.lblTravelDate.AutoSize = true;
            this.lblTravelDate.ForeColor = System.Drawing.Color.DarkCyan;
            this.lblTravelDate.Location = new System.Drawing.Point(24, 133);
            this.lblTravelDate.Name = "lblTravelDate";
            this.lblTravelDate.Size = new System.Drawing.Size(80, 13);
            this.lblTravelDate.TabIndex = 47;
            this.lblTravelDate.Text = "Fecha de viaje:";
            // 
            // lblLocation
            // 
            this.lblLocation.AutoSize = true;
            this.lblLocation.ForeColor = System.Drawing.Color.DarkCyan;
            this.lblLocation.Location = new System.Drawing.Point(24, 169);
            this.lblLocation.Name = "lblLocation";
            this.lblLocation.Size = new System.Drawing.Size(69, 13);
            this.lblLocation.TabIndex = 48;
            this.lblLocation.Text = "Location DK:";
            // 
            // lblpaxType
            // 
            this.lblpaxType.AutoSize = true;
            this.lblpaxType.ForeColor = System.Drawing.Color.DarkCyan;
            this.lblpaxType.Location = new System.Drawing.Point(24, 206);
            this.lblpaxType.Name = "lblpaxType";
            this.lblpaxType.Size = new System.Drawing.Size(89, 13);
            this.lblpaxType.TabIndex = 49;
            this.lblpaxType.Text = "Tipo de pasajero:";
            // 
            // lblEmitionDate
            // 
            this.lblEmitionDate.AutoSize = true;
            this.lblEmitionDate.ForeColor = System.Drawing.Color.DarkCyan;
            this.lblEmitionDate.Location = new System.Drawing.Point(24, 248);
            this.lblEmitionDate.Name = "lblEmitionDate";
            this.lblEmitionDate.Size = new System.Drawing.Size(93, 13);
            this.lblEmitionDate.TabIndex = 51;
            this.lblEmitionDate.Text = "Fecha de emisión:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.DarkCyan;
            this.label1.Location = new System.Drawing.Point(24, 281);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 13);
            this.label1.TabIndex = 52;
            this.label1.Text = "Precompra:";
            // 
            // cmbDays
            // 
            this.cmbDays.FormattingEnabled = true;
            this.cmbDays.Items.AddRange(new object[] {
            "Seleccione el valor desado:",
            "Domingo",
            "Lunes",
            "Martes",
            "Miercoles",
            "Jueves",
            "Viernes",
            "Sabado"});
            this.cmbDays.Location = new System.Drawing.Point(132, 313);
            this.cmbDays.Name = "cmbDays";
            this.cmbDays.Size = new System.Drawing.Size(171, 21);
            this.cmbDays.TabIndex = 10;
            this.cmbDays.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // lblDayEmission
            // 
            this.lblDayEmission.AutoSize = true;
            this.lblDayEmission.ForeColor = System.Drawing.Color.DarkCyan;
            this.lblDayEmission.Location = new System.Drawing.Point(24, 321);
            this.lblDayEmission.Name = "lblDayEmission";
            this.lblDayEmission.Size = new System.Drawing.Size(106, 13);
            this.lblDayEmission.TabIndex = 53;
            this.lblDayEmission.Text = "Día en que se emite:";
            // 
            // lblTicketType
            // 
            this.lblTicketType.AutoSize = true;
            this.lblTicketType.ForeColor = System.Drawing.Color.DarkCyan;
            this.lblTicketType.Location = new System.Drawing.Point(26, 358);
            this.lblTicketType.Name = "lblTicketType";
            this.lblTicketType.Size = new System.Drawing.Size(78, 13);
            this.lblTicketType.TabIndex = 54;
            this.lblTicketType.Text = "Tipo de boleto:";
            // 
            // cmbTicketType
            // 
            this.cmbTicketType.FormattingEnabled = true;
            this.cmbTicketType.Items.AddRange(new object[] {
            "Seleccione el valor desado:",
            "Boleto Normal",
            "Fase 3.5 y 3.75",
            "Fase IV"});
            this.cmbTicketType.Location = new System.Drawing.Point(132, 350);
            this.cmbTicketType.Name = "cmbTicketType";
            this.cmbTicketType.Size = new System.Drawing.Size(171, 21);
            this.cmbTicketType.TabIndex = 11;
            this.cmbTicketType.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // cmbPaxType
            // 
            this.cmbPaxType.FormattingEnabled = true;
            this.cmbPaxType.Items.AddRange(new object[] {
            "Seleccione el valor deseado:",
            "ADT   Adulto",
            "CNN   Menor (de 2 a 11 años)",
            "INF   Bebe",
            "NEG   Tarifas negociadas",
            "PFA   Tarifas netas ",
            "JCB   Contract Bulk Adult",
            "WEB   Tarifas WEB",
            "YTH   Juvenil o estudiante",
            "------ADULTOS",
            "ADT   Adult",
            "ASB   Adult Standby",
            "BNN   Adult with Age Restriction",
            "ADD   Adult with Discount",
            "------MENORES-NIÑOS-JOVENES",
            "CSB   Child Standby ",
            "INY   Infant Accompanied By a Youth",
            "INS   Infant with a Seat",
            "INF   Infant without a Seat",
            "YTH   Youth Confirmed",
            "YSB   Youth Standby",
            "UNN   Unaccompanied Child",
            "CNN   Accompanied Child",
            "------SENECTOS",
            "SNN   Restricted Senior Citizen With Multiple Age",
            "SRC   Senior Citizen",
            "YCB   Senior Citizen Standby",
            "SCC   Senior Discounted Companion",
            "------NEGOCIADAS",
            "JNN   Contract Bulk Child",
            "JNF   Contract Bulk Infant",
            "------AGENTES",
            "AGT   Agent",
            "ADN   Agent Discount AD50N1",
            "ADA   Agent Discount AD75N1",
            "UDN   Agent Discount UD50N1",
            "UDA   Agent Discount UD75N1",
            "------AEROLINEAS",
            "BUD   Airline Buddy Standby",
            "AST   Airline Staff Standby",
            "NSB   Non-revenue Standby",
            "------EQUIPAJE",
            "BAG   Cabin Baggage",
            "------TARJETAS",
            "CCH   Card Carrying Holder",
            "CCM   Card Carrying Member",
            "CFM   Cardholders within France",
            "CEV   Leisure Cardholders within France",
            "CDT   Discount Cardholder France and Overseas",
            "MCS   Mastercard Purchase Only",
            "------CHARTER",
            "PCR   Charter Adult Passenger",
            "PNN   Charter Child Passenger",
            "YCR   Charter Youth Passenger",
            "------ACOMPANIANTES",
            "ANN   Age restricted Companion",
            "CMP   Companion",
            "CMA   Adult with Companion",
            "ACC   Accompanied Passenger",
            "------CUPONES - CERTIFICADOS",
            "CPN   Coupon",
            "CNT   Carnet Coupon Travel",
            "ICP   Incentives Certificates",
            "------ESTUDIANTES",
            "STU   Student",
            "SDB   Student Standby",
            "TEA   Teacher",
            "UNV   University Employee",
            "------BOLETO ELECTRONICO - INTERNET - WEB",
            "EDT   Electronic Ticket discount Adult",
            "ECH   Electronic Ticket discount Child",
            "ENF   Electronic Ticket discount Infant",
            "WEB   Internet Fares",
            "------EUROPA",
            "DNN   Child of European Parliament",
            "OEB   Official of European Cabinet",
            "OEC   Official of European Committee",
            "OEI   Official of European Committee Institute",
            "OEP   Official of European Parliament",
            "JEB   Journalist of European Cabinet",
            "JEC   Journalist of European Committee",
            "JEP   Journalist of European Parliament",
            "MEP   Member of European Parliament",
            "AEP   Assistants of European Parliament Member",
            "SEP   Spouse of European",
            "------FAMILIA",
            "HOF   Head of Family",
            "SPH   Head of Family Spouse",
            "FIF   Family Intra-France",
            "FNN   Family Plan Child",
            "FNF   Family Plan Infant",
            "SPA   Accompanied Spouse",
            "SPS   Spouse",
            "------VIAJEROS FRECUENTES",
            "FFY   Frequent Flyer",
            "FFP   Frequent Flyer - Preferred",
            "TNN   Frequent Flyer Child",
            "------GOBIERNO",
            "GCT   City/County Government Travel",
            "GCF   Government Contract Passenger",
            "GDP   Government Employee Dependent",
            "LTC   Government Employee on Leave",
            "GEX   Government Exchange",
            "GVT   Government Travel",
            "YNN   Government Travel Child",
            "GST   State Government Passenger",
            "DOD   Department of Defense Passenger",
            "MSG   Multi State Government Passenger",
            "GV1   GOVT HARD CODE LOWEST GOV/CTZ fare for SATO offices",
            "------GRUPOS",
            "GRP   Group",
            "GNN   Group Child",
            "GIT   Group Inclusive Tour",
            "ENN   Group Inclusive Tour Child",
            "GSP   Group School Party",
            "VAG   Group Visit Another Country Adult",
            "ZNN   Group Visit Another Country Child",
            "------SALUD",
            "BLD   Blind Passenger",
            "DIS   Disabled Person",
            "MED   Patients Traveling for Medical Treatment",
            "------Labor",
            "LBR   Laborer/Worker",
            "LNN   Laborer/Worker Child",
            "LIF   Laborer/Worker Infant",
            "------MILITARES",
            "MRE   Retired Military/ Military Dependent",
            "MBT   Military  Basic Training Graduate",
            "MIL   Military  Confirmed",
            "MCR   Military Charter Passenger",
            "MNN   Military Child",
            "MPA   Military Parents/ Parents In Law",
            "REC   Military Recruit",
            "MIR   Military Reserves on Active Duty",
            "MSB   Military Standby",
            "MUS   Military/ DOD based in USA",
            "MXS   Military/ DOD not based in USA",
            "MDP   Spouse/Dependent Children of Military Personnel",
            "------RELIGIOSOS",
            "CLG   Clergy",
            "MIS   Missionary",
            "------TOURS",
            "ITX   Individual Inclusive Tour",
            "INN   Individual Inclusive Tour Child",
            "TUX   Restricted Tour Conductor",
            "TUR   Tour Conductor",
            "------VISITAS",
            "VAC   Visit Another Country Adult",
            "VNN   Visit Another Country Child",
            "VFR   Visit Friends/Relatives",
            "------DIVERSOS TIPOS",
            "ASF   Air-Sea Fare",
            "BRV   Bereavement Passenger",
            "CTZ   Category Z",
            "CMM   Commuter",
            "CNV   Convention",
            "EMI   Emigrant",
            "NAT   NATO Passenger",
            "OTS   Passengers Occupying Two Seats",
            "PIL   Pilgrim",
            "REF   Refugee",
            "SEA   Seaman",
            "SPT   Sports Passenger",
            "STR   State Resident",
            "TIM   Timesaver"});
            this.cmbPaxType.Location = new System.Drawing.Point(132, 203);
            this.cmbPaxType.Name = "cmbPaxType";
            this.cmbPaxType.Size = new System.Drawing.Size(171, 21);
            this.cmbPaxType.TabIndex = 5;
            this.cmbPaxType.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // monthCalendar1
            // 
            this.monthCalendar1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.monthCalendar1.Location = new System.Drawing.Point(132, 151);
            this.monthCalendar1.Name = "monthCalendar1";
            this.monthCalendar1.TabIndex = 77;
            this.monthCalendar1.Visible = false;
            this.monthCalendar1.DateSelected += new System.Windows.Forms.DateRangeEventHandler(this.monthCalendar1_DateSelected);
            this.monthCalendar1.Leave += new System.EventHandler(this.monthCalendar1_Leave);
            this.monthCalendar1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.monthCalendar1_KeyDown);
            // 
            // picCalendar
            // 
            this.picCalendar.BackColor = System.Drawing.Color.Transparent;
            this.picCalendar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picCalendar.Image = ((System.Drawing.Image)(resources.GetObject("picCalendar.Image")));
            this.picCalendar.Location = new System.Drawing.Point(226, 127);
            this.picCalendar.Name = "picCalendar";
            this.picCalendar.Size = new System.Drawing.Size(17, 20);
            this.picCalendar.TabIndex = 78;
            this.picCalendar.TabStop = false;
            this.picCalendar.Click += new System.EventHandler(this.picCalendar_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(226, 241);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(17, 20);
            this.pictureBox1.TabIndex = 78;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.picCalendar_Click2);
            // 
            // monthCalendar2
            // 
            this.monthCalendar2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.monthCalendar2.Location = new System.Drawing.Point(132, 268);
            this.monthCalendar2.Name = "monthCalendar2";
            this.monthCalendar2.TabIndex = 77;
            this.monthCalendar2.Visible = false;
            this.monthCalendar2.DateSelected += new System.Windows.Forms.DateRangeEventHandler(this.monthCalendar1_DateSelected2);
            this.monthCalendar2.Leave += new System.EventHandler(this.monthCalendar2_Leave);
            this.monthCalendar2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.monthCalendar2_KeyDown);
            // 
            // lbCityCode
            // 
            this.lbCityCode.DisplayMember = "Text";
            this.lbCityCode.FormattingEnabled = true;
            this.lbCityCode.Location = new System.Drawing.Point(29, 467);
            this.lbCityCode.Name = "lbCityCode";
            this.lbCityCode.Size = new System.Drawing.Size(171, 95);
            this.lbCityCode.TabIndex = 79;
            this.lbCityCode.MouseClick += new System.Windows.Forms.MouseEventHandler(this.ListBox_MouseClick);
            this.lbCityCode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.lbCityCode_KeyDown);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.DarkCyan;
            this.label3.Location = new System.Drawing.Point(322, 56);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 16);
            this.label3.TabIndex = 80;
            this.label3.Text = "Paso 2/3";
            // 
            // label2
            // 
            this.label2.ForeColor = System.Drawing.Color.DarkCyan;
            this.label2.Location = new System.Drawing.Point(26, 390);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(106, 42);
            this.label2.TabIndex = 54;
            this.label2.Text = "Location DK Excluyente:";
            // 
            // cmbLocationDK
            // 
            this.cmbLocationDK.FormattingEnabled = true;
            this.cmbLocationDK.Location = new System.Drawing.Point(132, 166);
            this.cmbLocationDK.Name = "cmbLocationDK";
            this.cmbLocationDK.Size = new System.Drawing.Size(171, 21);
            this.cmbLocationDK.TabIndex = 4;
            this.cmbLocationDK.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // cmbLocationDKNoAllow
            // 
            this.cmbLocationDKNoAllow.FormattingEnabled = true;
            this.cmbLocationDKNoAllow.Location = new System.Drawing.Point(132, 390);
            this.cmbLocationDKNoAllow.Name = "cmbLocationDKNoAllow";
            this.cmbLocationDKNoAllow.Size = new System.Drawing.Size(171, 21);
            this.cmbLocationDKNoAllow.TabIndex = 12;
            this.cmbLocationDKNoAllow.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // lblAgent
            // 
            this.lblAgent.AutoSize = true;
            this.lblAgent.ForeColor = System.Drawing.Color.DarkCyan;
            this.lblAgent.Location = new System.Drawing.Point(24, 438);
            this.lblAgent.Name = "lblAgent";
            this.lblAgent.Size = new System.Drawing.Size(93, 13);
            this.lblAgent.TabIndex = 82;
            this.lblAgent.Text = "Agente que emite:";
            // 
            // txtAgent
            // 
            this.txtAgent.AllowBlankSpaces = false;
            this.txtAgent.BackColor = System.Drawing.SystemColors.Window;
            this.txtAgent.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtAgent.CharsIncluded = new char[0];
            this.txtAgent.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.OnlyLetters;
            this.txtAgent.CustomExpression = ".*";
            this.txtAgent.EnterColor = System.Drawing.Color.White;
            this.txtAgent.LeaveColor = System.Drawing.Color.Empty;
            this.txtAgent.Location = new System.Drawing.Point(132, 435);
            this.txtAgent.MaxLength = 2;
            this.txtAgent.Name = "txtAgent";
            this.txtAgent.Size = new System.Drawing.Size(45, 20);
            this.txtAgent.TabIndex = 13;
            this.txtAgent.TextChanged += new System.EventHandler(this.txtControls_TextChanged);
            this.txtAgent.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.DarkCyan;
            this.label4.Location = new System.Drawing.Point(190, 281);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(30, 13);
            this.label4.TabIndex = 52;
            this.label4.Text = "Días";
            // 
            // ucDefinitionTargetElements
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.lblAgent);
            this.Controls.Add(this.txtAgent);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lbCityCode);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.picCalendar);
            this.Controls.Add(this.monthCalendar2);
            this.Controls.Add(this.monthCalendar1);
            this.Controls.Add(this.cmbLocationDK);
            this.Controls.Add(this.cmbPaxType);
            this.Controls.Add(this.cmbLocationDKNoAllow);
            this.Controls.Add(this.cmbTicketType);
            this.Controls.Add(this.cmbDays);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblTicketType);
            this.Controls.Add(this.lblDayEmission);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblEmitionDate);
            this.Controls.Add(this.lblpaxType);
            this.Controls.Add(this.lblLocation);
            this.Controls.Add(this.lblTravelDate);
            this.Controls.Add(this.lblDestino);
            this.Controls.Add(this.lblOrigin);
            this.Controls.Add(this.btnAccept);
            this.Controls.Add(this.txtAdvancePurche);
            this.Controls.Add(this.txtEmissionDate);
            this.Controls.Add(this.txtTravelDate);
            this.Controls.Add(this.txtDestino);
            this.Controls.Add(this.txtOrigin);
            this.Controls.Add(this.lblChargePerService);
            this.Name = "ucDefinitionTargetElements";
            this.Size = new System.Drawing.Size(411, 580);
            this.Load += new System.EventHandler(this.ucDefinitionTargetElements_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picCalendar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.Label lblChargePerService;
        private MyCTS.Forms.UI.SmartTextBox txtOrigin;
        private System.Windows.Forms.Button btnAccept;
        private System.Windows.Forms.Label lblOrigin;
        private MyCTS.Forms.UI.SmartTextBox txtDestino;
        private MyCTS.Forms.UI.SmartTextBox txtTravelDate;
        private MyCTS.Forms.UI.SmartTextBox txtEmissionDate;
        private MyCTS.Forms.UI.SmartTextBox txtAdvancePurche;
        private System.Windows.Forms.Label lblDestino;
        private System.Windows.Forms.Label lblTravelDate;
        private System.Windows.Forms.Label lblLocation;
        private System.Windows.Forms.Label lblpaxType;
        private System.Windows.Forms.Label lblEmitionDate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbDays;
        private System.Windows.Forms.Label lblDayEmission;
        private System.Windows.Forms.Label lblTicketType;
        private System.Windows.Forms.ComboBox cmbTicketType;
        private System.Windows.Forms.ComboBox cmbPaxType;
        private System.Windows.Forms.MonthCalendar monthCalendar1;
        internal System.Windows.Forms.PictureBox picCalendar;
        internal System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.MonthCalendar monthCalendar2;
        private System.Windows.Forms.ListBox lbCityCode;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbLocationDK;
        private System.Windows.Forms.ComboBox cmbLocationDKNoAllow;
        private System.Windows.Forms.Label lblAgent;
        private MyCTS.Forms.UI.SmartTextBox txtAgent;
        private System.Windows.Forms.Label label4;
    }
}
