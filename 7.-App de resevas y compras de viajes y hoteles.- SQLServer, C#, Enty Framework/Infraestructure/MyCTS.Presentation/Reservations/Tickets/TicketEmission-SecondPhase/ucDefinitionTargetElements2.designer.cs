namespace MyCTS.Presentation
{
    partial class ucDefinitionTargetElements2
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
            this.lblChargePerService = new System.Windows.Forms.Label();
            this.lblOrigenOfSale = new System.Windows.Forms.Label();
            this.cmbOriginOfSale = new System.Windows.Forms.ComboBox();
            this.txtFareType = new MyCTS.Forms.UI.SmartTextBox();
            this.lblFareType = new System.Windows.Forms.Label();
            this.txtFareBasis = new MyCTS.Forms.UI.SmartTextBox();
            this.lblFareBasis = new System.Windows.Forms.Label();
            this.txtAirline = new MyCTS.Forms.UI.SmartTextBox();
            this.lblAirline = new System.Windows.Forms.Label();
            this.txtBaseFare2 = new MyCTS.Forms.UI.SmartTextBox();
            this.lblBaseFare = new System.Windows.Forms.Label();
            this.cmbPayForm = new System.Windows.Forms.ComboBox();
            this.lblPayForm = new System.Windows.Forms.Label();
            this.smartTextBox1 = new MyCTS.Forms.UI.SmartTextBox();
            this.lblSegmentCount = new System.Windows.Forms.Label();
            this.txtTourCode = new MyCTS.Forms.UI.SmartTextBox();
            this.lblTourCode = new System.Windows.Forms.Label();
            this.txtPCC = new MyCTS.Forms.UI.SmartTextBox();
            this.lblPCC = new System.Windows.Forms.Label();
            this.lblHorario = new System.Windows.Forms.Label();
            this.txtHora1 = new MyCTS.Forms.UI.SmartTextBox();
            this.btnAccept = new System.Windows.Forms.Button();
            this.txtHora2 = new MyCTS.Forms.UI.SmartTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lbAirline = new System.Windows.Forms.ListBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtBaseFare = new MyCTS.Forms.UI.SmartTextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lbFareType = new System.Windows.Forms.ListBox();
            this.lbPCCs = new System.Windows.Forms.ListBox();
            this.label7 = new System.Windows.Forms.Label();
            this.cmbOperativeUnit = new System.Windows.Forms.ComboBox();
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
            this.lblChargePerService.TabIndex = 43;
            this.lblChargePerService.Text = "Definición de los criterios para la regla de cargo por servicio";
            this.lblChargePerService.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblOrigenOfSale
            // 
            this.lblOrigenOfSale.AutoSize = true;
            this.lblOrigenOfSale.ForeColor = System.Drawing.Color.DarkCyan;
            this.lblOrigenOfSale.Location = new System.Drawing.Point(29, 77);
            this.lblOrigenOfSale.Name = "lblOrigenOfSale";
            this.lblOrigenOfSale.Size = new System.Drawing.Size(97, 13);
            this.lblOrigenOfSale.TabIndex = 44;
            this.lblOrigenOfSale.Text = "Origen de la venta:";
            // 
            // cmbOriginOfSale
            // 
            this.cmbOriginOfSale.FormattingEnabled = true;
            this.cmbOriginOfSale.Items.AddRange(new object[] {
            "Seleccione el valor deseado:"});
            this.cmbOriginOfSale.Location = new System.Drawing.Point(133, 69);
            this.cmbOriginOfSale.Name = "cmbOriginOfSale";
            this.cmbOriginOfSale.Size = new System.Drawing.Size(249, 21);
            this.cmbOriginOfSale.TabIndex = 13;
            this.cmbOriginOfSale.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // txtFareType
            // 
            this.txtFareType.AllowBlankSpaces = false;
            this.txtFareType.BackColor = System.Drawing.SystemColors.Window;
            this.txtFareType.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtFareType.CharsIncluded = new char[0];
            this.txtFareType.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.OnlyLetters;
            this.txtFareType.CustomExpression = ".*";
            this.txtFareType.EnterColor = System.Drawing.Color.White;
            this.txtFareType.LeaveColor = System.Drawing.Color.Empty;
            this.txtFareType.Location = new System.Drawing.Point(133, 147);
            this.txtFareType.MaxLength = 52;
            this.txtFareType.Name = "txtFareType";
            this.txtFareType.Size = new System.Drawing.Size(184, 20);
            this.txtFareType.TabIndex = 14;
            this.txtFareType.TextChanged += new System.EventHandler(this.txtFareType_TextChanged);
            this.txtFareType.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FareTypeActions_KeyDown);
            // 
            // lblFareType
            // 
            this.lblFareType.AutoSize = true;
            this.lblFareType.ForeColor = System.Drawing.Color.DarkCyan;
            this.lblFareType.Location = new System.Drawing.Point(29, 150);
            this.lblFareType.Name = "lblFareType";
            this.lblFareType.Size = new System.Drawing.Size(72, 13);
            this.lblFareType.TabIndex = 44;
            this.lblFareType.Text = "Tipo de tarifa:";
            // 
            // txtFareBasis
            // 
            this.txtFareBasis.AllowBlankSpaces = true;
            this.txtFareBasis.BackColor = System.Drawing.SystemColors.Window;
            this.txtFareBasis.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtFareBasis.CharsIncluded = new char[0];
            this.txtFareBasis.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.NumbersOrLetters;
            this.txtFareBasis.CustomExpression = ".*";
            this.txtFareBasis.EnterColor = System.Drawing.Color.White;
            this.txtFareBasis.LeaveColor = System.Drawing.Color.Empty;
            this.txtFareBasis.Location = new System.Drawing.Point(133, 182);
            this.txtFareBasis.MaxLength = 25;
            this.txtFareBasis.Name = "txtFareBasis";
            this.txtFareBasis.Size = new System.Drawing.Size(214, 20);
            this.txtFareBasis.TabIndex = 15;
            this.txtFareBasis.TextChanged += new System.EventHandler(this.txtControls_TextChanged);
            this.txtFareBasis.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // lblFareBasis
            // 
            this.lblFareBasis.AutoSize = true;
            this.lblFareBasis.ForeColor = System.Drawing.Color.DarkCyan;
            this.lblFareBasis.Location = new System.Drawing.Point(29, 185);
            this.lblFareBasis.Name = "lblFareBasis";
            this.lblFareBasis.Size = new System.Drawing.Size(59, 13);
            this.lblFareBasis.TabIndex = 44;
            this.lblFareBasis.Text = "Fare Basis:";
            // 
            // txtAirline
            // 
            this.txtAirline.AllowBlankSpaces = false;
            this.txtAirline.BackColor = System.Drawing.SystemColors.Window;
            this.txtAirline.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtAirline.CharsIncluded = new char[0];
            this.txtAirline.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.NumbersOrLetters;
            this.txtAirline.CustomExpression = ".*";
            this.txtAirline.EnterColor = System.Drawing.Color.White;
            this.txtAirline.LeaveColor = System.Drawing.Color.Empty;
            this.txtAirline.Location = new System.Drawing.Point(133, 220);
            this.txtAirline.MaxLength = 52;
            this.txtAirline.Name = "txtAirline";
            this.txtAirline.Size = new System.Drawing.Size(184, 20);
            this.txtAirline.TabIndex = 16;
            this.txtAirline.TextChanged += new System.EventHandler(this.txtAirline_TextChanged);
            this.txtAirline.KeyDown += new System.Windows.Forms.KeyEventHandler(this.AirlineActions_KeyDown);
            // 
            // lblAirline
            // 
            this.lblAirline.AutoSize = true;
            this.lblAirline.ForeColor = System.Drawing.Color.DarkCyan;
            this.lblAirline.Location = new System.Drawing.Point(29, 223);
            this.lblAirline.Name = "lblAirline";
            this.lblAirline.Size = new System.Drawing.Size(56, 13);
            this.lblAirline.TabIndex = 44;
            this.lblAirline.Text = "Aerolínea:";
            // 
            // txtBaseFare2
            // 
            this.txtBaseFare2.AllowBlankSpaces = false;
            this.txtBaseFare2.BackColor = System.Drawing.SystemColors.Window;
            this.txtBaseFare2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtBaseFare2.CharsIncluded = new char[] {
        '.'};
            this.txtBaseFare2.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.OnlyNumbers;
            this.txtBaseFare2.CustomExpression = ".*";
            this.txtBaseFare2.EnterColor = System.Drawing.Color.White;
            this.txtBaseFare2.LeaveColor = System.Drawing.Color.Empty;
            this.txtBaseFare2.Location = new System.Drawing.Point(255, 256);
            this.txtBaseFare2.MaxLength = 10;
            this.txtBaseFare2.Name = "txtBaseFare2";
            this.txtBaseFare2.Size = new System.Drawing.Size(92, 20);
            this.txtBaseFare2.TabIndex = 17;
            this.txtBaseFare2.TextChanged += new System.EventHandler(this.txtControls_TextChanged);
            this.txtBaseFare2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // lblBaseFare
            // 
            this.lblBaseFare.AutoSize = true;
            this.lblBaseFare.ForeColor = System.Drawing.Color.DarkCyan;
            this.lblBaseFare.Location = new System.Drawing.Point(29, 259);
            this.lblBaseFare.Name = "lblBaseFare";
            this.lblBaseFare.Size = new System.Drawing.Size(64, 13);
            this.lblBaseFare.TabIndex = 44;
            this.lblBaseFare.Text = "Tarifa Base:";
            // 
            // cmbPayForm
            // 
            this.cmbPayForm.FormattingEnabled = true;
            this.cmbPayForm.Items.AddRange(new object[] {
            "Seleccione el valor deseado:",
            "Tarjeta de crédito (Aut. Sistema).",
            "Tarjeta de crédito (Aut. Manual).",
            "Efectivo.",
            "Pago Mixto.",
            "Miscelaneo o Electrónico."});
            this.cmbPayForm.Location = new System.Drawing.Point(133, 293);
            this.cmbPayForm.Name = "cmbPayForm";
            this.cmbPayForm.Size = new System.Drawing.Size(249, 21);
            this.cmbPayForm.TabIndex = 18;
            this.cmbPayForm.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // lblPayForm
            // 
            this.lblPayForm.AutoSize = true;
            this.lblPayForm.ForeColor = System.Drawing.Color.DarkCyan;
            this.lblPayForm.Location = new System.Drawing.Point(29, 296);
            this.lblPayForm.Name = "lblPayForm";
            this.lblPayForm.Size = new System.Drawing.Size(81, 13);
            this.lblPayForm.TabIndex = 44;
            this.lblPayForm.Text = "Forma de pago:";
            // 
            // smartTextBox1
            // 
            this.smartTextBox1.AllowBlankSpaces = false;
            this.smartTextBox1.BackColor = System.Drawing.SystemColors.Window;
            this.smartTextBox1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.smartTextBox1.CharsIncluded = new char[0];
            this.smartTextBox1.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.OnlyNumbers;
            this.smartTextBox1.CustomExpression = ".*";
            this.smartTextBox1.EnterColor = System.Drawing.Color.White;
            this.smartTextBox1.LeaveColor = System.Drawing.Color.Empty;
            this.smartTextBox1.Location = new System.Drawing.Point(133, 330);
            this.smartTextBox1.MaxLength = 2;
            this.smartTextBox1.Name = "smartTextBox1";
            this.smartTextBox1.Size = new System.Drawing.Size(45, 20);
            this.smartTextBox1.TabIndex = 19;
            this.smartTextBox1.TextChanged += new System.EventHandler(this.txtControls_TextChanged);
            this.smartTextBox1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // lblSegmentCount
            // 
            this.lblSegmentCount.ForeColor = System.Drawing.Color.DarkCyan;
            this.lblSegmentCount.Location = new System.Drawing.Point(29, 330);
            this.lblSegmentCount.Name = "lblSegmentCount";
            this.lblSegmentCount.Size = new System.Drawing.Size(81, 28);
            this.lblSegmentCount.TabIndex = 44;
            this.lblSegmentCount.Text = "Número de segmentos:";
            // 
            // txtTourCode
            // 
            this.txtTourCode.AllowBlankSpaces = false;
            this.txtTourCode.BackColor = System.Drawing.SystemColors.Window;
            this.txtTourCode.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtTourCode.CharsIncluded = new char[0];
            this.txtTourCode.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.NumbersOrLetters;
            this.txtTourCode.CustomExpression = ".*";
            this.txtTourCode.EnterColor = System.Drawing.Color.White;
            this.txtTourCode.LeaveColor = System.Drawing.Color.Empty;
            this.txtTourCode.Location = new System.Drawing.Point(133, 363);
            this.txtTourCode.MaxLength = 10;
            this.txtTourCode.Name = "txtTourCode";
            this.txtTourCode.Size = new System.Drawing.Size(115, 20);
            this.txtTourCode.TabIndex = 20;
            this.txtTourCode.TextChanged += new System.EventHandler(this.txtControls_TextChanged);
            this.txtTourCode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // lblTourCode
            // 
            this.lblTourCode.AutoSize = true;
            this.lblTourCode.ForeColor = System.Drawing.Color.DarkCyan;
            this.lblTourCode.Location = new System.Drawing.Point(29, 370);
            this.lblTourCode.Name = "lblTourCode";
            this.lblTourCode.Size = new System.Drawing.Size(60, 13);
            this.lblTourCode.TabIndex = 44;
            this.lblTourCode.Text = "Tour Code:";
            // 
            // txtPCC
            // 
            this.txtPCC.AllowBlankSpaces = false;
            this.txtPCC.BackColor = System.Drawing.SystemColors.Window;
            this.txtPCC.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtPCC.CharsIncluded = new char[0];
            this.txtPCC.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.NumbersOrLetters;
            this.txtPCC.CustomExpression = ".*";
            this.txtPCC.EnterColor = System.Drawing.Color.White;
            this.txtPCC.LeaveColor = System.Drawing.Color.Empty;
            this.txtPCC.Location = new System.Drawing.Point(133, 398);
            this.txtPCC.MaxLength = 20;
            this.txtPCC.Name = "txtPCC";
            this.txtPCC.Size = new System.Drawing.Size(184, 20);
            this.txtPCC.TabIndex = 21;
            this.txtPCC.TextChanged += new System.EventHandler(this.txtPCC_TextChanged);
            this.txtPCC.KeyDown += new System.Windows.Forms.KeyEventHandler(this.PCCActions_KeyDown);
            // 
            // lblPCC
            // 
            this.lblPCC.AutoSize = true;
            this.lblPCC.ForeColor = System.Drawing.Color.DarkCyan;
            this.lblPCC.Location = new System.Drawing.Point(29, 401);
            this.lblPCC.Name = "lblPCC";
            this.lblPCC.Size = new System.Drawing.Size(31, 13);
            this.lblPCC.TabIndex = 44;
            this.lblPCC.Text = "PCC:";
            // 
            // lblHorario
            // 
            this.lblHorario.ForeColor = System.Drawing.Color.DarkCyan;
            this.lblHorario.Location = new System.Drawing.Point(29, 429);
            this.lblHorario.Name = "lblHorario";
            this.lblHorario.Size = new System.Drawing.Size(64, 32);
            this.lblHorario.TabIndex = 44;
            this.lblHorario.Text = "Horario de emisión:";
            // 
            // txtHora1
            // 
            this.txtHora1.AllowBlankSpaces = true;
            this.txtHora1.BackColor = System.Drawing.SystemColors.Window;
            this.txtHora1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtHora1.CharsIncluded = new char[] {
        ':'};
            this.txtHora1.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.OnlyNumbers;
            this.txtHora1.CustomExpression = ".*";
            this.txtHora1.EnterColor = System.Drawing.Color.White;
            this.txtHora1.LeaveColor = System.Drawing.Color.Empty;
            this.txtHora1.Location = new System.Drawing.Point(133, 431);
            this.txtHora1.MaxLength = 5;
            this.txtHora1.Name = "txtHora1";
            this.txtHora1.Size = new System.Drawing.Size(64, 20);
            this.txtHora1.TabIndex = 22;
            this.txtHora1.TextChanged += new System.EventHandler(this.txtControls_TextChanged);
            this.txtHora1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // btnAccept
            // 
            this.btnAccept.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnAccept.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAccept.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAccept.Location = new System.Drawing.Point(272, 497);
            this.btnAccept.Name = "btnAccept";
            this.btnAccept.Size = new System.Drawing.Size(110, 24);
            this.btnAccept.TabIndex = 45;
            this.btnAccept.Text = "Aceptar";
            this.btnAccept.UseVisualStyleBackColor = false;
            this.btnAccept.Click += new System.EventHandler(this.btnAccept_Click);
            // 
            // txtHora2
            // 
            this.txtHora2.AllowBlankSpaces = true;
            this.txtHora2.BackColor = System.Drawing.SystemColors.Window;
            this.txtHora2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtHora2.CharsIncluded = new char[] {
        ':'};
            this.txtHora2.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.OnlyNumbers;
            this.txtHora2.CustomExpression = ".*";
            this.txtHora2.EnterColor = System.Drawing.Color.White;
            this.txtHora2.LeaveColor = System.Drawing.Color.Empty;
            this.txtHora2.Location = new System.Drawing.Point(224, 431);
            this.txtHora2.MaxLength = 5;
            this.txtHora2.Name = "txtHora2";
            this.txtHora2.Size = new System.Drawing.Size(64, 20);
            this.txtHora2.TabIndex = 23;
            this.txtHora2.TextChanged += new System.EventHandler(this.txtControls_TextChanged);
            this.txtHora2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.DarkCyan;
            this.label1.Location = new System.Drawing.Point(106, 434);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(21, 13);
            this.label1.TabIndex = 44;
            this.label1.Text = "De";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.DarkCyan;
            this.label2.Location = new System.Drawing.Point(203, 434);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(14, 13);
            this.label2.TabIndex = 44;
            this.label2.Text = "A";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.DarkCyan;
            this.label3.Location = new System.Drawing.Point(294, 434);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(88, 13);
            this.label3.TabIndex = 44;
            this.label3.Text = "Ej. 08:00 a 17:30";
            // 
            // lbAirline
            // 
            this.lbAirline.DisplayMember = "Text";
            this.lbAirline.FormattingEnabled = true;
            this.lbAirline.Location = new System.Drawing.Point(32, 469);
            this.lbAirline.Name = "lbAirline";
            this.lbAirline.Size = new System.Drawing.Size(184, 95);
            this.lbAirline.TabIndex = 46;
            this.lbAirline.MouseClick += new System.Windows.Forms.MouseEventHandler(this.ListBox_MouseClick);
            this.lbAirline.KeyDown += new System.Windows.Forms.KeyEventHandler(this.lbAirline_KeyDown);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.DarkCyan;
            this.label4.Location = new System.Drawing.Point(278, 41);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(69, 16);
            this.label4.TabIndex = 47;
            this.label4.Text = "Paso 3/3";
            // 
            // txtBaseFare
            // 
            this.txtBaseFare.AllowBlankSpaces = false;
            this.txtBaseFare.BackColor = System.Drawing.SystemColors.Window;
            this.txtBaseFare.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtBaseFare.CharsIncluded = new char[] {
        '.'};
            this.txtBaseFare.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.OnlyNumbers;
            this.txtBaseFare.CustomExpression = ".*";
            this.txtBaseFare.EnterColor = System.Drawing.Color.White;
            this.txtBaseFare.LeaveColor = System.Drawing.Color.Empty;
            this.txtBaseFare.Location = new System.Drawing.Point(133, 256);
            this.txtBaseFare.MaxLength = 10;
            this.txtBaseFare.Name = "txtBaseFare";
            this.txtBaseFare.Size = new System.Drawing.Size(92, 20);
            this.txtBaseFare.TabIndex = 17;
            this.txtBaseFare.TextChanged += new System.EventHandler(this.txtControls_TextChanged);
            this.txtBaseFare.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.DarkCyan;
            this.label5.Location = new System.Drawing.Point(234, 259);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(14, 13);
            this.label5.TabIndex = 44;
            this.label5.Text = "A";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.Color.DarkCyan;
            this.label6.Location = new System.Drawing.Point(106, 259);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(21, 13);
            this.label6.TabIndex = 44;
            this.label6.Text = "De";
            // 
            // lbFareType
            // 
            this.lbFareType.DisplayMember = "Text";
            this.lbFareType.FormattingEnabled = true;
            this.lbFareType.Location = new System.Drawing.Point(33, 469);
            this.lbFareType.Name = "lbFareType";
            this.lbFareType.Size = new System.Drawing.Size(184, 95);
            this.lbFareType.TabIndex = 48;
            this.lbFareType.MouseClick += new System.Windows.Forms.MouseEventHandler(this.ListBox_MouseClick);
            this.lbFareType.KeyDown += new System.Windows.Forms.KeyEventHandler(this.lbFareType_KeyDown);
            // 
            // lbPCCs
            // 
            this.lbPCCs.DisplayMember = "Text";
            this.lbPCCs.FormattingEnabled = true;
            this.lbPCCs.Location = new System.Drawing.Point(33, 469);
            this.lbPCCs.Name = "lbPCCs";
            this.lbPCCs.Size = new System.Drawing.Size(184, 95);
            this.lbPCCs.TabIndex = 49;
            this.lbPCCs.MouseClick += new System.Windows.Forms.MouseEventHandler(this.ListBox_MouseClick);
            this.lbPCCs.KeyDown += new System.Windows.Forms.KeyEventHandler(this.lbPCCs_KeyDown);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.ForeColor = System.Drawing.Color.DarkCyan;
            this.label7.Location = new System.Drawing.Point(30, 110);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(93, 13);
            this.label7.TabIndex = 44;
            this.label7.Text = "Unidad Operativa:";
            // 
            // cmbOperativeUnit
            // 
            this.cmbOperativeUnit.FormattingEnabled = true;
            this.cmbOperativeUnit.Items.AddRange(new object[] {
            "Seleccione el valor deseado:"});
            this.cmbOperativeUnit.Location = new System.Drawing.Point(133, 107);
            this.cmbOperativeUnit.Name = "cmbOperativeUnit";
            this.cmbOperativeUnit.Size = new System.Drawing.Size(249, 21);
            this.cmbOperativeUnit.TabIndex = 14;
            this.cmbOperativeUnit.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // ucDefinitionTargetElements2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.lbPCCs);
            this.Controls.Add(this.lbFareType);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lbAirline);
            this.Controls.Add(this.btnAccept);
            this.Controls.Add(this.cmbPayForm);
            this.Controls.Add(this.cmbOperativeUnit);
            this.Controls.Add(this.cmbOriginOfSale);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblHorario);
            this.Controls.Add(this.lblPCC);
            this.Controls.Add(this.lblTourCode);
            this.Controls.Add(this.lblSegmentCount);
            this.Controls.Add(this.lblPayForm);
            this.Controls.Add(this.lblBaseFare);
            this.Controls.Add(this.lblAirline);
            this.Controls.Add(this.lblFareBasis);
            this.Controls.Add(this.lblFareType);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.lblOrigenOfSale);
            this.Controls.Add(this.txtHora2);
            this.Controls.Add(this.txtHora1);
            this.Controls.Add(this.txtPCC);
            this.Controls.Add(this.txtTourCode);
            this.Controls.Add(this.smartTextBox1);
            this.Controls.Add(this.txtBaseFare);
            this.Controls.Add(this.txtBaseFare2);
            this.Controls.Add(this.txtAirline);
            this.Controls.Add(this.txtFareBasis);
            this.Controls.Add(this.txtFareType);
            this.Controls.Add(this.lblChargePerService);
            this.Name = "ucDefinitionTargetElements2";
            this.Size = new System.Drawing.Size(411, 580);
            this.Load += new System.EventHandler(this.ucDefinitionTargetElements2_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.Label lblChargePerService;
        private System.Windows.Forms.Label lblOrigenOfSale;
        private System.Windows.Forms.ComboBox cmbOriginOfSale;
        private MyCTS.Forms.UI.SmartTextBox txtFareType;
        private System.Windows.Forms.Label lblFareType;
        private MyCTS.Forms.UI.SmartTextBox txtFareBasis;
        private System.Windows.Forms.Label lblFareBasis;
        private MyCTS.Forms.UI.SmartTextBox txtAirline;
        private System.Windows.Forms.Label lblAirline;
        private MyCTS.Forms.UI.SmartTextBox txtBaseFare2;
        private System.Windows.Forms.Label lblBaseFare;
        private System.Windows.Forms.ComboBox cmbPayForm;
        private System.Windows.Forms.Label lblPayForm;
        private MyCTS.Forms.UI.SmartTextBox smartTextBox1;
        private System.Windows.Forms.Label lblSegmentCount;
        private MyCTS.Forms.UI.SmartTextBox txtTourCode;
        private System.Windows.Forms.Label lblTourCode;
        private MyCTS.Forms.UI.SmartTextBox txtPCC;
        private System.Windows.Forms.Label lblPCC;
        private System.Windows.Forms.Label lblHorario;
        private MyCTS.Forms.UI.SmartTextBox txtHora1;
        private System.Windows.Forms.Button btnAccept;
        private MyCTS.Forms.UI.SmartTextBox txtHora2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ListBox lbAirline;
        private System.Windows.Forms.Label label4;
        private MyCTS.Forms.UI.SmartTextBox txtBaseFare;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ListBox lbFareType;
        private System.Windows.Forms.ListBox lbPCCs;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cmbOperativeUnit;
    }
}
