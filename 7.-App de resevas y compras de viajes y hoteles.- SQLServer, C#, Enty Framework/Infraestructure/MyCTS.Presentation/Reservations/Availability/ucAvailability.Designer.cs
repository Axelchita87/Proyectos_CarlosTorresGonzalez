namespace MyCTS.Presentation
{
    partial class ucAvailability
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucAvailability));
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.defaultLookAndFeel1 = new DevExpress.LookAndFeel.DefaultLookAndFeel(this.components);
            this.kayakCheckBox = new System.Windows.Forms.CheckBox();
            this.infantComboBox = new DevExpress.XtraEditors.ComboBoxEdit();
            this.seniorComboBox = new DevExpress.XtraEditors.ComboBoxEdit();
            this.childComboBox = new DevExpress.XtraEditors.ComboBoxEdit();
            this.adultComboBox = new DevExpress.XtraEditors.ComboBoxEdit();
            this.returningDatePanel = new System.Windows.Forms.Panel();
            this.returningDate = new DevExpress.XtraEditors.DateEdit();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.label6 = new System.Windows.Forms.Label();
            this.roundTripRadioButton = new System.Windows.Forms.RadioButton();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label5 = new System.Windows.Forms.Label();
            this.departureTime = new DevExpress.XtraEditors.DateEdit();
            this.singleTripRadioButton = new System.Windows.Forms.RadioButton();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.interjetCheckBox = new System.Windows.Forms.CheckBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.lbAirlines = new System.Windows.Forms.ListBox();
            this.cmbHours = new System.Windows.Forms.ComboBox();
            this.btnAccept = new System.Windows.Forms.Button();
            this.cmbExitArrival = new System.Windows.Forms.ComboBox();
            this.tblLayoutMain = new System.Windows.Forms.TableLayoutPanel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.chkShortcuts = new System.Windows.Forms.CheckBox();
            this.chkDirectFlights = new System.Windows.Forms.CheckBox();
            this.txtConection = new MyCTS.Forms.UI.SmartTextBox();
            this.lblConection = new System.Windows.Forms.Label();
            this.cmbClassOfService = new System.Windows.Forms.ComboBox();
            this.lblClassOfService = new System.Windows.Forms.Label();
            this.txtAirLine6 = new MyCTS.Forms.UI.SmartTextBox();
            this.txtAirLine5 = new MyCTS.Forms.UI.SmartTextBox();
            this.txtAirLine4 = new MyCTS.Forms.UI.SmartTextBox();
            this.txtAirLine3 = new MyCTS.Forms.UI.SmartTextBox();
            this.txtAirLine2 = new MyCTS.Forms.UI.SmartTextBox();
            this.chkExclude = new System.Windows.Forms.CheckBox();
            this.txtAirLine1 = new MyCTS.Forms.UI.SmartTextBox();
            this.lblAirLine = new System.Windows.Forms.Label();
            this.lblSchedule = new System.Windows.Forms.Label();
            this.txtDestination = new MyCTS.Forms.UI.SmartTextBox();
            this.lblDestination = new System.Windows.Forms.Label();
            this.txtOrigin = new MyCTS.Forms.UI.SmartTextBox();
            this.lblOrigin = new System.Windows.Forms.Label();
            this.lbCities = new System.Windows.Forms.ListBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.lblComment = new System.Windows.Forms.Label();
            this.lblPassword = new System.Windows.Forms.Label();
            this.lblEmail = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.infantComboBox.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.seniorComboBox.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.childComboBox.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.adultComboBox.Properties)).BeginInit();
            this.returningDatePanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.returningDate.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.returningDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.departureTime.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.departureTime.Properties)).BeginInit();
            this.tblLayoutMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // bindingSource1
            // 
            this.bindingSource1.DataSource = typeof(MyCTS.Entities.AirLinesFare);
            // 
            // defaultLookAndFeel1
            // 
            this.defaultLookAndFeel1.LookAndFeel.SkinName = "Office 2010 Blue";
            // 
            // kayakCheckBox
            // 
            this.kayakCheckBox.AutoSize = true;
            this.kayakCheckBox.Checked = true;
            this.kayakCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.kayakCheckBox.Location = new System.Drawing.Point(97, 16);
            this.kayakCheckBox.Name = "kayakCheckBox";
            this.kayakCheckBox.Size = new System.Drawing.Size(93, 17);
            this.kayakCheckBox.TabIndex = 123;
            this.kayakCheckBox.Text = "Google Flights";
            this.kayakCheckBox.UseVisualStyleBackColor = true;
            // 
            // infantComboBox
            // 
            this.infantComboBox.Location = new System.Drawing.Point(327, 99);
            this.infantComboBox.Name = "infantComboBox";
            this.infantComboBox.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.infantComboBox.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.infantComboBox.Size = new System.Drawing.Size(34, 20);
            this.infantComboBox.TabIndex = 122;
            this.infantComboBox.ToolTip = "SELECCIONE EL NUMERO DE INFANTES";
            // 
            // seniorComboBox
            // 
            this.seniorComboBox.Location = new System.Drawing.Point(327, 73);
            this.seniorComboBox.Name = "seniorComboBox";
            this.seniorComboBox.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.seniorComboBox.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.seniorComboBox.Size = new System.Drawing.Size(34, 20);
            this.seniorComboBox.TabIndex = 121;
            this.seniorComboBox.ToolTip = "SELECCIONE EL NUMERO DE  ADULTOS MAYORES";
            this.seniorComboBox.ToolTipIconType = DevExpress.Utils.ToolTipIconType.Information;
            // 
            // childComboBox
            // 
            this.childComboBox.Location = new System.Drawing.Point(327, 46);
            this.childComboBox.Name = "childComboBox";
            this.childComboBox.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.childComboBox.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.childComboBox.Size = new System.Drawing.Size(34, 20);
            this.childComboBox.TabIndex = 120;
            this.childComboBox.ToolTip = "SELECCIONE EL NUMERO DE MENORES";
            this.childComboBox.ToolTipIconType = DevExpress.Utils.ToolTipIconType.Information;
            // 
            // adultComboBox
            // 
            this.adultComboBox.Location = new System.Drawing.Point(327, 17);
            this.adultComboBox.Name = "adultComboBox";
            this.adultComboBox.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.adultComboBox.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.adultComboBox.Size = new System.Drawing.Size(34, 20);
            this.adultComboBox.TabIndex = 119;
            this.adultComboBox.ToolTip = "SELECCION EN EL NUMERO DE PASAJEROS ADULTOS";
            this.adultComboBox.ToolTipIconType = DevExpress.Utils.ToolTipIconType.Information;
            // 
            // returningDatePanel
            // 
            this.returningDatePanel.Controls.Add(this.returningDate);
            this.returningDatePanel.Controls.Add(this.pictureBox2);
            this.returningDatePanel.Controls.Add(this.label6);
            this.returningDatePanel.Location = new System.Drawing.Point(7, 160);
            this.returningDatePanel.Name = "returningDatePanel";
            this.returningDatePanel.Size = new System.Drawing.Size(289, 27);
            this.returningDatePanel.TabIndex = 118;
            this.returningDatePanel.Visible = false;
            // 
            // returningDate
            // 
            this.returningDate.EditValue = null;
            this.returningDate.Location = new System.Drawing.Point(107, 4);
            this.returningDate.Name = "returningDate";
            this.returningDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.returningDate.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.returningDate.Properties.DisplayFormat.FormatString = "ddMMM";
            this.returningDate.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.returningDate.Properties.EditValueChangedFiringMode = DevExpress.XtraEditors.Controls.EditValueChangedFiringMode.Buffered;
            this.returningDate.Properties.Mask.EditMask = "ddMMM";
            this.returningDate.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.returningDate.Size = new System.Drawing.Size(100, 20);
            this.returningDate.TabIndex = 4;
            this.returningDate.ToolTip = "SELECCION LA FECHA DE REGRESO";
            this.returningDate.ToolTipIconType = DevExpress.Utils.ToolTipIconType.Information;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(213, 4);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(20, 20);
            this.pictureBox2.TabIndex = 117;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Click += new System.EventHandler(this.pictureBox2_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(8, 7);
            this.label6.Margin = new System.Windows.Forms.Padding(0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(101, 13);
            this.label6.TabIndex = 116;
            this.label6.Text = " Fecha de Regreso:";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // roundTripRadioButton
            // 
            this.roundTripRadioButton.AutoSize = true;
            this.roundTripRadioButton.Location = new System.Drawing.Point(94, 47);
            this.roundTripRadioButton.Name = "roundTripRadioButton";
            this.roundTripRadioButton.Size = new System.Drawing.Size(69, 17);
            this.roundTripRadioButton.TabIndex = 113;
            this.roundTripRadioButton.TabStop = true;
            this.roundTripRadioButton.Text = "Redondo";
            this.roundTripRadioButton.UseVisualStyleBackColor = true;
            this.roundTripRadioButton.CheckedChanged += new System.EventHandler(this.roundTripRadioButton_CheckedChanged_1);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(220, 134);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(20, 20);
            this.pictureBox1.TabIndex = 112;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(12, 134);
            this.label5.Margin = new System.Windows.Forms.Padding(0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(90, 13);
            this.label5.TabIndex = 111;
            this.label5.Text = " Fecha de Salida:";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // departureTime
            // 
            this.departureTime.EditValue = null;
            this.departureTime.Location = new System.Drawing.Point(114, 131);
            this.departureTime.Name = "departureTime";
            this.departureTime.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.departureTime.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.departureTime.Properties.DisplayFormat.FormatString = "ddMMM";
            this.departureTime.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.departureTime.Properties.EditValueChangedFiringMode = DevExpress.XtraEditors.Controls.EditValueChangedFiringMode.Buffered;
            this.departureTime.Properties.Mask.EditMask = "ddMMM";
            this.departureTime.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.departureTime.Size = new System.Drawing.Size(100, 20);
            this.departureTime.TabIndex = 3;
            this.departureTime.ToolTip = "SELECCIONA LA FECHA DE SALIDA";
            this.departureTime.ToolTipIconType = DevExpress.Utils.ToolTipIconType.Information;
            // 
            // singleTripRadioButton
            // 
            this.singleTripRadioButton.AutoSize = true;
            this.singleTripRadioButton.Location = new System.Drawing.Point(11, 46);
            this.singleTripRadioButton.Name = "singleTripRadioButton";
            this.singleTripRadioButton.Size = new System.Drawing.Size(62, 17);
            this.singleTripRadioButton.TabIndex = 108;
            this.singleTripRadioButton.TabStop = true;
            this.singleTripRadioButton.Text = "Sencillo";
            this.singleTripRadioButton.UseVisualStyleBackColor = true;
            this.singleTripRadioButton.CheckedChanged += new System.EventHandler(this.singleTripRadioButton_CheckedChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(282, 99);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(40, 13);
            this.label4.TabIndex = 106;
            this.label4.Text = "Infante";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(253, 75);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 13);
            this.label3.TabIndex = 104;
            this.label3.Text = "Adulto Mayor";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(285, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 13);
            this.label2.TabIndex = 103;
            this.label2.Text = "Menor";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(285, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 13);
            this.label1.TabIndex = 102;
            this.label1.Text = "Adulto";
            // 
            // interjetCheckBox
            // 
            this.interjetCheckBox.AutoSize = true;
            this.interjetCheckBox.Location = new System.Drawing.Point(11, 16);
            this.interjetCheckBox.Name = "interjetCheckBox";
            this.interjetCheckBox.Size = new System.Drawing.Size(80, 17);
            this.interjetCheckBox.TabIndex = 96;
            this.interjetCheckBox.Text = " Bajo Costo";
            this.interjetCheckBox.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.interjetCheckBox.UseVisualStyleBackColor = true;
            this.interjetCheckBox.CheckedChanged += new System.EventHandler(this.interjetCheckBox_CheckedChanged);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(18, 535);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(233, 108);
            this.textBox1.TabIndex = 95;
            this.textBox1.Visible = false;
            // 
            // lbAirlines
            // 
            this.lbAirlines.DisplayMember = "Text";
            this.lbAirlines.FormattingEnabled = true;
            this.lbAirlines.Location = new System.Drawing.Point(111, 302);
            this.lbAirlines.Name = "lbAirlines";
            this.lbAirlines.Size = new System.Drawing.Size(195, 95);
            this.lbAirlines.TabIndex = 88;
            this.lbAirlines.ValueMember = "Value";
            this.lbAirlines.MouseClick += new System.Windows.Forms.MouseEventHandler(this.ListBox_MouseClick);
            this.lbAirlines.KeyDown += new System.Windows.Forms.KeyEventHandler(this.lbAirlines_KeyDown);
            // 
            // cmbHours
            // 
            this.cmbHours.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbHours.FormattingEnabled = true;
            this.cmbHours.Items.AddRange(new object[] {
            "",
            "00:00",
            "01:00",
            "02:00",
            "03:00",
            "04:00",
            "05:00",
            "06:00",
            "07:00",
            "08:00",
            "09:00",
            "10:00",
            "11:00",
            "12:00",
            "13:00",
            "14:00",
            "15:00",
            "16:00",
            "17:00",
            "18:00",
            "19:00",
            "20:00",
            "21:00",
            "22:00",
            "23:00"});
            this.cmbHours.Location = new System.Drawing.Point(113, 249);
            this.cmbHours.Name = "cmbHours";
            this.cmbHours.Size = new System.Drawing.Size(57, 21);
            this.cmbHours.TabIndex = 7;
            this.cmbHours.DropDown += new System.EventHandler(this.cmbHours_DropDown);
            this.cmbHours.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // btnAccept
            // 
            this.btnAccept.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnAccept.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAccept.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAccept.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAccept.ForeColor = System.Drawing.Color.Black;
            this.btnAccept.Location = new System.Drawing.Point(268, 531);
            this.btnAccept.Name = "btnAccept";
            this.btnAccept.Size = new System.Drawing.Size(100, 23);
            this.btnAccept.TabIndex = 20;
            this.btnAccept.Text = "Aceptar";
            this.btnAccept.UseVisualStyleBackColor = false;
            this.btnAccept.Click += new System.EventHandler(this.btnAccept_Click_1);
            // 
            // cmbExitArrival
            // 
            this.cmbExitArrival.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbExitArrival.FormattingEnabled = true;
            this.cmbExitArrival.Items.AddRange(new object[] {
            "",
            "SALIDA",
            "LLEGADA"});
            this.cmbExitArrival.Location = new System.Drawing.Point(176, 249);
            this.cmbExitArrival.Name = "cmbExitArrival";
            this.cmbExitArrival.Size = new System.Drawing.Size(74, 21);
            this.cmbExitArrival.TabIndex = 8;
            this.cmbExitArrival.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // tblLayoutMain
            // 
            this.tblLayoutMain.BackColor = System.Drawing.Color.White;
            this.tblLayoutMain.ColumnCount = 1;
            this.tblLayoutMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 411F));
            this.tblLayoutMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tblLayoutMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tblLayoutMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tblLayoutMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tblLayoutMain.Controls.Add(this.lblTitle, 0, 0);
            this.tblLayoutMain.Location = new System.Drawing.Point(0, 0);
            this.tblLayoutMain.Margin = new System.Windows.Forms.Padding(0);
            this.tblLayoutMain.Name = "tblLayoutMain";
            this.tblLayoutMain.RowCount = 1;
            this.tblLayoutMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 15F));
            this.tblLayoutMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 15F));
            this.tblLayoutMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 15F));
            this.tblLayoutMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 15F));
            this.tblLayoutMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 15F));
            this.tblLayoutMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 15F));
            this.tblLayoutMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 15F));
            this.tblLayoutMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 15F));
            this.tblLayoutMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 15F));
            this.tblLayoutMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 15F));
            this.tblLayoutMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 15F));
            this.tblLayoutMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 15F));
            this.tblLayoutMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 15F));
            this.tblLayoutMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 15F));
            this.tblLayoutMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 15F));
            this.tblLayoutMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 15F));
            this.tblLayoutMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 15F));
            this.tblLayoutMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 15F));
            this.tblLayoutMain.Size = new System.Drawing.Size(411, 13);
            this.tblLayoutMain.TabIndex = 87;
            this.tblLayoutMain.TabStop = true;
            // 
            // lblTitle
            // 
            this.lblTitle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTitle.AutoSize = true;
            this.lblTitle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(139)))), ((int)(((byte)(208)))));
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(3, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(405, 13);
            this.lblTitle.TabIndex = 13;
            this.lblTitle.Text = "Disponibilidad";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // chkShortcuts
            // 
            this.chkShortcuts.AutoSize = true;
            this.chkShortcuts.BackColor = System.Drawing.Color.Transparent;
            this.chkShortcuts.ForeColor = System.Drawing.Color.DarkCyan;
            this.chkShortcuts.Location = new System.Drawing.Point(268, 522);
            this.chkShortcuts.Name = "chkShortcuts";
            this.chkShortcuts.Size = new System.Drawing.Size(99, 17);
            this.chkShortcuts.TabIndex = 19;
            this.chkShortcuts.Text = "Acceso Directo";
            this.chkShortcuts.UseVisualStyleBackColor = false;
            this.chkShortcuts.CheckedChanged += new System.EventHandler(this.chkShortcuts_CheckedChanged);
            this.chkShortcuts.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // chkDirectFlights
            // 
            this.chkDirectFlights.AutoSize = true;
            this.chkDirectFlights.BackColor = System.Drawing.Color.Transparent;
            this.chkDirectFlights.ForeColor = System.Drawing.Color.DarkCyan;
            this.chkDirectFlights.Location = new System.Drawing.Point(268, 485);
            this.chkDirectFlights.Name = "chkDirectFlights";
            this.chkDirectFlights.Size = new System.Drawing.Size(100, 17);
            this.chkDirectFlights.TabIndex = 18;
            this.chkDirectFlights.Text = "Vuelos Directos";
            this.chkDirectFlights.UseVisualStyleBackColor = false;
            this.chkDirectFlights.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // txtConection
            // 
            this.txtConection.AllowBlankSpaces = true;
            this.txtConection.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtConection.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.NumbersOrLetters;
            this.txtConection.CustomExpression = ".*";
            this.txtConection.EnterColor = System.Drawing.Color.Empty;
            this.txtConection.LeaveColor = System.Drawing.Color.Empty;
            this.txtConection.Location = new System.Drawing.Point(113, 459);
            this.txtConection.MaxLength = 22;
            this.txtConection.Name = "txtConection";
            this.txtConection.Size = new System.Drawing.Size(255, 20);
            this.txtConection.TabIndex = 17;
            this.txtConection.TextChanged += new System.EventHandler(this.txtOrigin_TextChanged);
            this.txtConection.KeyDown += new System.Windows.Forms.KeyEventHandler(this.citiesActions_KeyDown);
            // 
            // lblConection
            // 
            this.lblConection.AutoSize = true;
            this.lblConection.BackColor = System.Drawing.Color.Transparent;
            this.lblConection.ForeColor = System.Drawing.Color.DarkCyan;
            this.lblConection.Location = new System.Drawing.Point(14, 462);
            this.lblConection.Margin = new System.Windows.Forms.Padding(0);
            this.lblConection.Name = "lblConection";
            this.lblConection.Size = new System.Drawing.Size(65, 13);
            this.lblConection.TabIndex = 83;
            this.lblConection.Text = "Conexiones:";
            this.lblConection.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cmbClassOfService
            // 
            this.cmbClassOfService.DisplayMember = "Text";
            this.cmbClassOfService.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbClassOfService.FormattingEnabled = true;
            this.cmbClassOfService.Items.AddRange(new object[] {
            ""});
            this.cmbClassOfService.Location = new System.Drawing.Point(113, 432);
            this.cmbClassOfService.Name = "cmbClassOfService";
            this.cmbClassOfService.Size = new System.Drawing.Size(195, 21);
            this.cmbClassOfService.TabIndex = 16;
            this.cmbClassOfService.ValueMember = "Value";
            this.cmbClassOfService.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // lblClassOfService
            // 
            this.lblClassOfService.AutoSize = true;
            this.lblClassOfService.BackColor = System.Drawing.Color.Transparent;
            this.lblClassOfService.ForeColor = System.Drawing.Color.DarkCyan;
            this.lblClassOfService.Location = new System.Drawing.Point(14, 435);
            this.lblClassOfService.Margin = new System.Windows.Forms.Padding(0);
            this.lblClassOfService.Name = "lblClassOfService";
            this.lblClassOfService.Size = new System.Drawing.Size(90, 13);
            this.lblClassOfService.TabIndex = 81;
            this.lblClassOfService.Text = "Clase de servicio:";
            this.lblClassOfService.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtAirLine6
            // 
            this.txtAirLine6.AllowBlankSpaces = true;
            this.txtAirLine6.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtAirLine6.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.NumbersOrLetters;
            this.txtAirLine6.CustomExpression = ".*";
            this.txtAirLine6.EnterColor = System.Drawing.Color.Empty;
            this.txtAirLine6.LeaveColor = System.Drawing.Color.Empty;
            this.txtAirLine6.Location = new System.Drawing.Point(113, 406);
            this.txtAirLine6.MaxLength = 52;
            this.txtAirLine6.Name = "txtAirLine6";
            this.txtAirLine6.Size = new System.Drawing.Size(195, 20);
            this.txtAirLine6.TabIndex = 15;
            this.txtAirLine6.TextChanged += new System.EventHandler(this.txtAirLine_TextChanged);
            this.txtAirLine6.KeyDown += new System.Windows.Forms.KeyEventHandler(this.AirlinesActions_KeyDown);
            // 
            // txtAirLine5
            // 
            this.txtAirLine5.AllowBlankSpaces = true;
            this.txtAirLine5.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtAirLine5.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.NumbersOrLetters;
            this.txtAirLine5.CustomExpression = ".*";
            this.txtAirLine5.EnterColor = System.Drawing.Color.Empty;
            this.txtAirLine5.LeaveColor = System.Drawing.Color.Empty;
            this.txtAirLine5.Location = new System.Drawing.Point(113, 380);
            this.txtAirLine5.MaxLength = 52;
            this.txtAirLine5.Name = "txtAirLine5";
            this.txtAirLine5.Size = new System.Drawing.Size(195, 20);
            this.txtAirLine5.TabIndex = 14;
            this.txtAirLine5.TextChanged += new System.EventHandler(this.txtAirLine_TextChanged);
            this.txtAirLine5.KeyDown += new System.Windows.Forms.KeyEventHandler(this.AirlinesActions_KeyDown);
            // 
            // txtAirLine4
            // 
            this.txtAirLine4.AllowBlankSpaces = true;
            this.txtAirLine4.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtAirLine4.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.NumbersOrLetters;
            this.txtAirLine4.CustomExpression = ".*";
            this.txtAirLine4.EnterColor = System.Drawing.Color.Empty;
            this.txtAirLine4.LeaveColor = System.Drawing.Color.Empty;
            this.txtAirLine4.Location = new System.Drawing.Point(113, 354);
            this.txtAirLine4.MaxLength = 52;
            this.txtAirLine4.Name = "txtAirLine4";
            this.txtAirLine4.Size = new System.Drawing.Size(195, 20);
            this.txtAirLine4.TabIndex = 13;
            this.txtAirLine4.TextChanged += new System.EventHandler(this.txtAirLine_TextChanged);
            this.txtAirLine4.KeyDown += new System.Windows.Forms.KeyEventHandler(this.AirlinesActions_KeyDown);
            // 
            // txtAirLine3
            // 
            this.txtAirLine3.AllowBlankSpaces = true;
            this.txtAirLine3.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtAirLine3.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.NumbersOrLetters;
            this.txtAirLine3.CustomExpression = ".*";
            this.txtAirLine3.EnterColor = System.Drawing.Color.Empty;
            this.txtAirLine3.LeaveColor = System.Drawing.Color.Empty;
            this.txtAirLine3.Location = new System.Drawing.Point(114, 328);
            this.txtAirLine3.MaxLength = 52;
            this.txtAirLine3.Name = "txtAirLine3";
            this.txtAirLine3.Size = new System.Drawing.Size(194, 20);
            this.txtAirLine3.TabIndex = 12;
            this.txtAirLine3.TextChanged += new System.EventHandler(this.txtAirLine_TextChanged);
            this.txtAirLine3.KeyDown += new System.Windows.Forms.KeyEventHandler(this.AirlinesActions_KeyDown);
            // 
            // txtAirLine2
            // 
            this.txtAirLine2.AllowBlankSpaces = true;
            this.txtAirLine2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtAirLine2.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.NumbersOrLetters;
            this.txtAirLine2.CustomExpression = ".*";
            this.txtAirLine2.EnterColor = System.Drawing.Color.Empty;
            this.txtAirLine2.LeaveColor = System.Drawing.Color.Empty;
            this.txtAirLine2.Location = new System.Drawing.Point(113, 302);
            this.txtAirLine2.MaxLength = 52;
            this.txtAirLine2.Name = "txtAirLine2";
            this.txtAirLine2.Size = new System.Drawing.Size(195, 20);
            this.txtAirLine2.TabIndex = 11;
            this.txtAirLine2.TextChanged += new System.EventHandler(this.txtAirLine_TextChanged);
            this.txtAirLine2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.AirlinesActions_KeyDown);
            // 
            // chkExclude
            // 
            this.chkExclude.AutoSize = true;
            this.chkExclude.Location = new System.Drawing.Point(314, 276);
            this.chkExclude.Name = "chkExclude";
            this.chkExclude.Size = new System.Drawing.Size(57, 17);
            this.chkExclude.TabIndex = 10;
            this.chkExclude.Text = "Excluir";
            this.chkExclude.UseVisualStyleBackColor = true;
            // 
            // txtAirLine1
            // 
            this.txtAirLine1.AllowBlankSpaces = true;
            this.txtAirLine1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtAirLine1.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.NumbersOrLetters;
            this.txtAirLine1.CustomExpression = ".*";
            this.txtAirLine1.EnterColor = System.Drawing.Color.Empty;
            this.txtAirLine1.LeaveColor = System.Drawing.Color.Empty;
            this.txtAirLine1.Location = new System.Drawing.Point(113, 276);
            this.txtAirLine1.MaxLength = 52;
            this.txtAirLine1.Name = "txtAirLine1";
            this.txtAirLine1.Size = new System.Drawing.Size(195, 20);
            this.txtAirLine1.TabIndex = 9;
            this.txtAirLine1.TextChanged += new System.EventHandler(this.txtAirLine_TextChanged);
            this.txtAirLine1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.AirlinesActions_KeyDown);
            // 
            // lblAirLine
            // 
            this.lblAirLine.AutoSize = true;
            this.lblAirLine.BackColor = System.Drawing.Color.Transparent;
            this.lblAirLine.ForeColor = System.Drawing.Color.DarkCyan;
            this.lblAirLine.Location = new System.Drawing.Point(14, 277);
            this.lblAirLine.Margin = new System.Windows.Forms.Padding(0);
            this.lblAirLine.Name = "lblAirLine";
            this.lblAirLine.Size = new System.Drawing.Size(62, 13);
            this.lblAirLine.TabIndex = 72;
            this.lblAirLine.Text = "Aereolínea:";
            this.lblAirLine.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblSchedule
            // 
            this.lblSchedule.AutoSize = true;
            this.lblSchedule.BackColor = System.Drawing.Color.Transparent;
            this.lblSchedule.ForeColor = System.Drawing.Color.DarkCyan;
            this.lblSchedule.Location = new System.Drawing.Point(14, 252);
            this.lblSchedule.Margin = new System.Windows.Forms.Padding(0);
            this.lblSchedule.Name = "lblSchedule";
            this.lblSchedule.Size = new System.Drawing.Size(44, 13);
            this.lblSchedule.TabIndex = 70;
            this.lblSchedule.Text = "Horario:";
            this.lblSchedule.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtDestination
            // 
            this.txtDestination.AllowBlankSpaces = true;
            this.txtDestination.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtDestination.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.OnlyLetters;
            this.txtDestination.CustomExpression = ".*";
            this.txtDestination.EnterColor = System.Drawing.Color.Empty;
            this.txtDestination.LeaveColor = System.Drawing.Color.Empty;
            this.txtDestination.Location = new System.Drawing.Point(113, 219);
            this.txtDestination.MaxLength = 22;
            this.txtDestination.Name = "txtDestination";
            this.txtDestination.Size = new System.Drawing.Size(255, 20);
            this.txtDestination.TabIndex = 6;
            this.txtDestination.TextChanged += new System.EventHandler(this.txtOrigin_TextChanged);
            this.txtDestination.KeyDown += new System.Windows.Forms.KeyEventHandler(this.citiesActions_KeyDown);
            // 
            // lblDestination
            // 
            this.lblDestination.AutoSize = true;
            this.lblDestination.BackColor = System.Drawing.Color.Transparent;
            this.lblDestination.ForeColor = System.Drawing.Color.Black;
            this.lblDestination.Location = new System.Drawing.Point(12, 223);
            this.lblDestination.Margin = new System.Windows.Forms.Padding(0);
            this.lblDestination.Name = "lblDestination";
            this.lblDestination.Size = new System.Drawing.Size(46, 13);
            this.lblDestination.TabIndex = 68;
            this.lblDestination.Text = "Destino:";
            this.lblDestination.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtOrigin
            // 
            this.txtOrigin.AllowBlankSpaces = true;
            this.txtOrigin.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtOrigin.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.OnlyLetters;
            this.txtOrigin.CustomExpression = ".*";
            this.txtOrigin.EnterColor = System.Drawing.Color.Empty;
            this.txtOrigin.LeaveColor = System.Drawing.Color.Empty;
            this.txtOrigin.Location = new System.Drawing.Point(113, 193);
            this.txtOrigin.MaxLength = 22;
            this.txtOrigin.Name = "txtOrigin";
            this.txtOrigin.Size = new System.Drawing.Size(255, 20);
            this.txtOrigin.TabIndex = 5;
            this.txtOrigin.TextChanged += new System.EventHandler(this.txtOrigin_TextChanged);
            this.txtOrigin.KeyDown += new System.Windows.Forms.KeyEventHandler(this.citiesActions_KeyDown);
            // 
            // lblOrigin
            // 
            this.lblOrigin.AutoSize = true;
            this.lblOrigin.BackColor = System.Drawing.Color.Transparent;
            this.lblOrigin.ForeColor = System.Drawing.Color.Black;
            this.lblOrigin.Location = new System.Drawing.Point(12, 197);
            this.lblOrigin.Margin = new System.Windows.Forms.Padding(0);
            this.lblOrigin.Name = "lblOrigin";
            this.lblOrigin.Size = new System.Drawing.Size(41, 13);
            this.lblOrigin.TabIndex = 66;
            this.lblOrigin.Text = "Origen:";
            this.lblOrigin.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbCities
            // 
            this.lbCities.DisplayMember = "Text";
            this.lbCities.FormattingEnabled = true;
            this.lbCities.Location = new System.Drawing.Point(113, 211);
            this.lbCities.Name = "lbCities";
            this.lbCities.Size = new System.Drawing.Size(255, 69);
            this.lbCities.TabIndex = 94;
            this.lbCities.Tag = "";
            this.lbCities.ValueMember = "Value";
            this.lbCities.MouseClick += new System.Windows.Forms.MouseEventHandler(this.ListBox_MouseClick);
            this.lbCities.KeyDown += new System.Windows.Forms.KeyEventHandler(this.lbCities_KeyDown);
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(111, 109);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(138, 20);
            this.txtPassword.TabIndex = 128;
            this.txtPassword.UseSystemPasswordChar = true;
            this.txtPassword.Visible = false;
            // 
            // lblComment
            // 
            this.lblComment.AutoSize = true;
            this.lblComment.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblComment.ForeColor = System.Drawing.Color.Blue;
            this.lblComment.Location = new System.Drawing.Point(11, 68);
            this.lblComment.Name = "lblComment";
            this.lblComment.Size = new System.Drawing.Size(220, 13);
            this.lblComment.TabIndex = 124;
            this.lblComment.Text = "Solo para Interjet - Acceso de Cliente";
            this.lblComment.Visible = false;
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.Location = new System.Drawing.Point(42, 111);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(61, 13);
            this.lblPassword.TabIndex = 125;
            this.lblPassword.Text = "Contraseña";
            this.lblPassword.Visible = false;
            // 
            // lblEmail
            // 
            this.lblEmail.AutoSize = true;
            this.lblEmail.Location = new System.Drawing.Point(11, 90);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(94, 13);
            this.lblEmail.TabIndex = 126;
            this.lblEmail.Text = "Correo Electronico";
            this.lblEmail.Visible = false;
            // 
            // ucAvailability
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.AutoSize = true;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnablePreventFocusChange;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.lblComment);
            this.Controls.Add(this.lblPassword);
            this.Controls.Add(this.lblEmail);
            this.Controls.Add(this.kayakCheckBox);
            this.Controls.Add(this.infantComboBox);
            this.Controls.Add(this.seniorComboBox);
            this.Controls.Add(this.childComboBox);
            this.Controls.Add(this.adultComboBox);
            this.Controls.Add(this.returningDatePanel);
            this.Controls.Add(this.roundTripRadioButton);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.departureTime);
            this.Controls.Add(this.singleTripRadioButton);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.interjetCheckBox);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.lbAirlines);
            this.Controls.Add(this.cmbHours);
            this.Controls.Add(this.btnAccept);
            this.Controls.Add(this.cmbExitArrival);
            this.Controls.Add(this.tblLayoutMain);
            this.Controls.Add(this.chkShortcuts);
            this.Controls.Add(this.chkDirectFlights);
            this.Controls.Add(this.txtConection);
            this.Controls.Add(this.lblConection);
            this.Controls.Add(this.cmbClassOfService);
            this.Controls.Add(this.lblClassOfService);
            this.Controls.Add(this.txtAirLine6);
            this.Controls.Add(this.txtAirLine5);
            this.Controls.Add(this.txtAirLine4);
            this.Controls.Add(this.txtAirLine3);
            this.Controls.Add(this.txtAirLine2);
            this.Controls.Add(this.chkExclude);
            this.Controls.Add(this.txtAirLine1);
            this.Controls.Add(this.lblAirLine);
            this.Controls.Add(this.lblSchedule);
            this.Controls.Add(this.txtDestination);
            this.Controls.Add(this.lblDestination);
            this.Controls.Add(this.txtOrigin);
            this.Controls.Add(this.lblOrigin);
            this.Controls.Add(this.lbCities);
            this.ForeColor = System.Drawing.Color.DarkCyan;
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "ucAvailability";
            this.Size = new System.Drawing.Size(417, 676);
            this.Load += new System.EventHandler(this.ucAvailability_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.infantComboBox.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.seniorComboBox.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.childComboBox.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.adultComboBox.Properties)).EndInit();
            this.returningDatePanel.ResumeLayout(false);
            this.returningDatePanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.returningDate.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.returningDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.departureTime.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.departureTime.Properties)).EndInit();
            this.tblLayoutMain.ResumeLayout(false);
            this.tblLayoutMain.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.BindingSource bindingSource1;
        private System.Windows.Forms.Label lblTitle;
        internal System.Windows.Forms.Label lblOrigin;
        private MyCTS.Forms.UI.SmartTextBox txtOrigin;
        internal System.Windows.Forms.Label lblDestination;
        private MyCTS.Forms.UI.SmartTextBox txtDestination;
        internal System.Windows.Forms.Label lblSchedule;
        private System.Windows.Forms.ComboBox cmbHours;
        private System.Windows.Forms.ComboBox cmbExitArrival;
        internal System.Windows.Forms.Label lblAirLine;
        internal MyCTS.Forms.UI.SmartTextBox txtAirLine1;
        private System.Windows.Forms.CheckBox chkExclude;
        internal MyCTS.Forms.UI.SmartTextBox txtAirLine2;
        internal MyCTS.Forms.UI.SmartTextBox txtAirLine3;
        internal MyCTS.Forms.UI.SmartTextBox txtAirLine4;
        internal MyCTS.Forms.UI.SmartTextBox txtAirLine5;
        internal MyCTS.Forms.UI.SmartTextBox txtAirLine6;
        internal System.Windows.Forms.Label lblClassOfService;
        private System.Windows.Forms.ComboBox cmbClassOfService;
        internal System.Windows.Forms.Label lblConection;
        internal MyCTS.Forms.UI.SmartTextBox txtConection;
        internal System.Windows.Forms.CheckBox chkDirectFlights;
        internal System.Windows.Forms.CheckBox chkShortcuts;
        internal System.Windows.Forms.TableLayoutPanel tblLayoutMain;
        private System.Windows.Forms.Button btnAccept;
        private System.Windows.Forms.ListBox lbAirlines;
        private System.Windows.Forms.ListBox lbCities;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.CheckBox interjetCheckBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.RadioButton singleTripRadioButton;
        private DevExpress.XtraEditors.DateEdit departureTime;
        internal System.Windows.Forms.Label label5;
        internal System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.RadioButton roundTripRadioButton;
        internal System.Windows.Forms.PictureBox pictureBox2;
        private DevExpress.XtraEditors.DateEdit returningDate;
        internal System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel returningDatePanel;
        private DevExpress.XtraEditors.ComboBoxEdit adultComboBox;
        private DevExpress.XtraEditors.ComboBoxEdit childComboBox;
        private DevExpress.XtraEditors.ComboBoxEdit seniorComboBox;
        private DevExpress.XtraEditors.ComboBoxEdit infantComboBox;
        private DevExpress.LookAndFeel.DefaultLookAndFeel defaultLookAndFeel1;
        private System.Windows.Forms.CheckBox kayakCheckBox;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label lblComment;
        private Forms.UI.SmartTextBox txtEmail;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.Label lblEmail;
        
    }
}
