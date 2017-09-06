namespace MyCTS.Presentation
//.Reservations.Tickets.TicketsEmission
{
    partial class ucCalculateServiceCharge
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
            this.lblChargePerService = new System.Windows.Forms.Label();
            this.lblPax1 = new System.Windows.Forms.Label();
            this.lblPax2 = new System.Windows.Forms.Label();
            this.lblPax3 = new System.Windows.Forms.Label();
            this.lblPax4 = new System.Windows.Forms.Label();
            this.lblPax5 = new System.Windows.Forms.Label();
            this.lblPax7 = new System.Windows.Forms.Label();
            this.lblPax6 = new System.Windows.Forms.Label();
            this.lblPax8 = new System.Windows.Forms.Label();
            this.lblPax9 = new System.Windows.Forms.Label();
            this.btnAccept = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.lblEsperar = new System.Windows.Forms.Label();
            this.btnCreateNewRule = new System.Windows.Forms.Button();
            this.PictureBoxBanner = new System.Windows.Forms.PictureBox();
            this.toolTipBanner = new System.Windows.Forms.ToolTip(this.components);
            this.TimerBanerImages = new System.Windows.Forms.Timer(this.components);
            this.tableLayoutPanel9 = new System.Windows.Forms.TableLayoutPanel();
            this.radioButton15 = new System.Windows.Forms.RadioButton();
            this.radioButton16 = new System.Windows.Forms.RadioButton();
            this.defaultToolTipController1 = new DevExpress.Utils.DefaultToolTipController(this.components);
            this.txtNombreTarjetahabiente = new System.Windows.Forms.TextBox();
            this.lblDigitoSeguridad = new System.Windows.Forms.Label();
            this.lblNombreTarjetahabiente = new System.Windows.Forms.Label();
            this.cmbAnioVencimiento = new System.Windows.Forms.ComboBox();
            this.cmbMesVencimiento = new System.Windows.Forms.ComboBox();
            this.lblAnioVencimiento = new System.Windows.Forms.Label();
            this.lblMesVencimiento = new System.Windows.Forms.Label();
            this.cmbTypeCard = new System.Windows.Forms.ComboBox();
            this.lblCardTypeCTS = new System.Windows.Forms.Label();
            this.lblCardNumberCTS = new System.Windows.Forms.Label();
            this.lblImport = new System.Windows.Forms.Label();
            this.txtDigitoSeguridad = new MyCTS.Forms.UI.SmartTextBox();
            this.txtNumberCardCTS = new MyCTS.Forms.UI.SmartTextBox();
            this.smartTextBox1 = new MyCTS.Forms.UI.SmartTextBox();
            this.txtPax1 = new MyCTS.Forms.UI.SmartTextBox();
            this.txtPax3 = new MyCTS.Forms.UI.SmartTextBox();
            this.txtPax4 = new MyCTS.Forms.UI.SmartTextBox();
            this.txtPax5 = new MyCTS.Forms.UI.SmartTextBox();
            this.txtPax6 = new MyCTS.Forms.UI.SmartTextBox();
            this.txtPax7 = new MyCTS.Forms.UI.SmartTextBox();
            this.txtPax8 = new MyCTS.Forms.UI.SmartTextBox();
            this.txtPax9 = new MyCTS.Forms.UI.SmartTextBox();
            this.txtPax2 = new MyCTS.Forms.UI.SmartTextBox();
            this.chkSameForAll = new System.Windows.Forms.CheckBox();
            this.btnContinue = new System.Windows.Forms.Button();
            this.loadingPictureBox = new System.Windows.Forms.PictureBox();
            this.lblLeyendaIva = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBoxBanner)).BeginInit();
            this.tableLayoutPanel9.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.loadingPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // lblChargePerService
            // 
            this.defaultToolTipController1.SetAllowHtmlText(this.lblChargePerService, DevExpress.Utils.DefaultBoolean.Default);
            this.lblChargePerService.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(139)))), ((int)(((byte)(208)))));
            this.lblChargePerService.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblChargePerService.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblChargePerService.ForeColor = System.Drawing.Color.White;
            this.lblChargePerService.Location = new System.Drawing.Point(0, 0);
            this.lblChargePerService.Name = "lblChargePerService";
            this.lblChargePerService.Size = new System.Drawing.Size(420, 17);
            this.lblChargePerService.TabIndex = 40;
            this.lblChargePerService.Text = "Cobro en Línea - Cargo por Servicio";
            this.lblChargePerService.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblPax1
            // 
            this.defaultToolTipController1.SetAllowHtmlText(this.lblPax1, DevExpress.Utils.DefaultBoolean.Default);
            this.lblPax1.AutoSize = true;
            this.lblPax1.Location = new System.Drawing.Point(5, 44);
            this.lblPax1.Name = "lblPax1";
            this.lblPax1.Size = new System.Drawing.Size(28, 13);
            this.lblPax1.TabIndex = 11;
            this.lblPax1.Text = "Pax:";
            this.lblPax1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblPax2
            // 
            this.defaultToolTipController1.SetAllowHtmlText(this.lblPax2, DevExpress.Utils.DefaultBoolean.Default);
            this.lblPax2.AutoSize = true;
            this.lblPax2.Location = new System.Drawing.Point(5, 68);
            this.lblPax2.Name = "lblPax2";
            this.lblPax2.Size = new System.Drawing.Size(28, 13);
            this.lblPax2.TabIndex = 14;
            this.lblPax2.Text = "Pax:";
            this.lblPax2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblPax3
            // 
            this.defaultToolTipController1.SetAllowHtmlText(this.lblPax3, DevExpress.Utils.DefaultBoolean.Default);
            this.lblPax3.AutoSize = true;
            this.lblPax3.Location = new System.Drawing.Point(5, 92);
            this.lblPax3.Name = "lblPax3";
            this.lblPax3.Size = new System.Drawing.Size(28, 13);
            this.lblPax3.TabIndex = 17;
            this.lblPax3.Text = "Pax:";
            this.lblPax3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblPax4
            // 
            this.defaultToolTipController1.SetAllowHtmlText(this.lblPax4, DevExpress.Utils.DefaultBoolean.Default);
            this.lblPax4.AutoSize = true;
            this.lblPax4.Location = new System.Drawing.Point(5, 116);
            this.lblPax4.Name = "lblPax4";
            this.lblPax4.Size = new System.Drawing.Size(28, 13);
            this.lblPax4.TabIndex = 20;
            this.lblPax4.Text = "Pax:";
            this.lblPax4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblPax5
            // 
            this.defaultToolTipController1.SetAllowHtmlText(this.lblPax5, DevExpress.Utils.DefaultBoolean.Default);
            this.lblPax5.AutoSize = true;
            this.lblPax5.Location = new System.Drawing.Point(5, 141);
            this.lblPax5.Name = "lblPax5";
            this.lblPax5.Size = new System.Drawing.Size(28, 13);
            this.lblPax5.TabIndex = 23;
            this.lblPax5.Text = "Pax:";
            this.lblPax5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblPax7
            // 
            this.defaultToolTipController1.SetAllowHtmlText(this.lblPax7, DevExpress.Utils.DefaultBoolean.Default);
            this.lblPax7.AutoSize = true;
            this.lblPax7.Location = new System.Drawing.Point(5, 190);
            this.lblPax7.Name = "lblPax7";
            this.lblPax7.Size = new System.Drawing.Size(28, 13);
            this.lblPax7.TabIndex = 29;
            this.lblPax7.Text = "Pax:";
            this.lblPax7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblPax6
            // 
            this.defaultToolTipController1.SetAllowHtmlText(this.lblPax6, DevExpress.Utils.DefaultBoolean.Default);
            this.lblPax6.AutoSize = true;
            this.lblPax6.Location = new System.Drawing.Point(5, 165);
            this.lblPax6.Name = "lblPax6";
            this.lblPax6.Size = new System.Drawing.Size(28, 13);
            this.lblPax6.TabIndex = 26;
            this.lblPax6.Text = "Pax:";
            this.lblPax6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblPax8
            // 
            this.defaultToolTipController1.SetAllowHtmlText(this.lblPax8, DevExpress.Utils.DefaultBoolean.Default);
            this.lblPax8.AutoSize = true;
            this.lblPax8.Location = new System.Drawing.Point(5, 214);
            this.lblPax8.Name = "lblPax8";
            this.lblPax8.Size = new System.Drawing.Size(28, 13);
            this.lblPax8.TabIndex = 32;
            this.lblPax8.Text = "Pax:";
            this.lblPax8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblPax9
            // 
            this.defaultToolTipController1.SetAllowHtmlText(this.lblPax9, DevExpress.Utils.DefaultBoolean.Default);
            this.lblPax9.AutoSize = true;
            this.lblPax9.Location = new System.Drawing.Point(5, 239);
            this.lblPax9.Name = "lblPax9";
            this.lblPax9.Size = new System.Drawing.Size(28, 13);
            this.lblPax9.TabIndex = 35;
            this.lblPax9.Text = "Pax:";
            this.lblPax9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnAccept
            // 
            this.defaultToolTipController1.SetAllowHtmlText(this.btnAccept, DevExpress.Utils.DefaultBoolean.Default);
            this.btnAccept.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnAccept.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAccept.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAccept.Location = new System.Drawing.Point(298, 323);
            this.btnAccept.Name = "btnAccept";
            this.btnAccept.Size = new System.Drawing.Size(110, 47);
            this.btnAccept.TabIndex = 19;
            this.btnAccept.Text = "Aceptar";
            this.btnAccept.UseVisualStyleBackColor = false;
            this.btnAccept.Click += new System.EventHandler(this.btnAccept_Click);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // lblEsperar
            // 
            this.defaultToolTipController1.SetAllowHtmlText(this.lblEsperar, DevExpress.Utils.DefaultBoolean.Default);
            this.lblEsperar.AutoSize = true;
            this.lblEsperar.Location = new System.Drawing.Point(7, 290);
            this.lblEsperar.Name = "lblEsperar";
            this.lblEsperar.Size = new System.Drawing.Size(0, 13);
            this.lblEsperar.TabIndex = 97;
            this.lblEsperar.Visible = false;
            // 
            // btnCreateNewRule
            // 
            this.defaultToolTipController1.SetAllowHtmlText(this.btnCreateNewRule, DevExpress.Utils.DefaultBoolean.Default);
            this.btnCreateNewRule.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnCreateNewRule.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCreateNewRule.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCreateNewRule.Location = new System.Drawing.Point(101, 584);
            this.btnCreateNewRule.Name = "btnCreateNewRule";
            this.btnCreateNewRule.Size = new System.Drawing.Size(210, 39);
            this.btnCreateNewRule.TabIndex = 18;
            this.btnCreateNewRule.Text = "Crear nueva regla de cargo por servicio";
            this.btnCreateNewRule.UseVisualStyleBackColor = false;
            this.btnCreateNewRule.Click += new System.EventHandler(this.btnCreateNewRule_Click);
            // 
            // PictureBoxBanner
            // 
            this.defaultToolTipController1.SetAllowHtmlText(this.PictureBoxBanner, DevExpress.Utils.DefaultBoolean.Default);
            this.PictureBoxBanner.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.PictureBoxBanner.Cursor = System.Windows.Forms.Cursors.Hand;
            this.PictureBoxBanner.InitialImage = null;
            this.PictureBoxBanner.Location = new System.Drawing.Point(27, 388);
            this.PictureBoxBanner.Name = "PictureBoxBanner";
            this.PictureBoxBanner.Size = new System.Drawing.Size(335, 190);
            this.PictureBoxBanner.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PictureBoxBanner.TabIndex = 98;
            this.PictureBoxBanner.TabStop = false;
            this.PictureBoxBanner.Tag = "Da Doble Click Sobre la Imagen para ver los Detalles";
            this.PictureBoxBanner.DoubleClick += new System.EventHandler(this.PictureBoxBanner_DoubleClick);
            // 
            // TimerBanerImages
            // 
            this.TimerBanerImages.Tick += new System.EventHandler(this.TimerBanerImages_Tick);
            // 
            // tableLayoutPanel9
            // 
            this.defaultToolTipController1.SetAllowHtmlText(this.tableLayoutPanel9, DevExpress.Utils.DefaultBoolean.Default);
            this.tableLayoutPanel9.ColumnCount = 2;
            this.tableLayoutPanel9.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 48.83721F));
            this.tableLayoutPanel9.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 51.16279F));
            this.tableLayoutPanel9.Controls.Add(this.radioButton15, 0, 0);
            this.tableLayoutPanel9.Location = new System.Drawing.Point(0, -6);
            this.tableLayoutPanel9.Name = "tableLayoutPanel9";
            this.tableLayoutPanel9.RowCount = 1;
            this.tableLayoutPanel9.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel9.Size = new System.Drawing.Size(200, 100);
            this.tableLayoutPanel9.TabIndex = 0;
            this.tableLayoutPanel9.TabStop = true;
            // 
            // radioButton15
            // 
            this.defaultToolTipController1.SetAllowHtmlText(this.radioButton15, DevExpress.Utils.DefaultBoolean.Default);
            this.radioButton15.AutoSize = true;
            this.radioButton15.Location = new System.Drawing.Point(3, 3);
            this.radioButton15.Name = "radioButton15";
            this.radioButton15.Size = new System.Drawing.Size(34, 17);
            this.radioButton15.TabIndex = 0;
            this.radioButton15.TabStop = true;
            this.radioButton15.Text = "Si";
            this.radioButton15.UseVisualStyleBackColor = true;
            // 
            // radioButton16
            // 
            this.defaultToolTipController1.SetAllowHtmlText(this.radioButton16, DevExpress.Utils.DefaultBoolean.Default);
            this.radioButton16.AutoSize = true;
            this.radioButton16.Location = new System.Drawing.Point(44, -3);
            this.radioButton16.Name = "radioButton16";
            this.radioButton16.Size = new System.Drawing.Size(39, 17);
            this.radioButton16.TabIndex = 1;
            this.radioButton16.TabStop = true;
            this.radioButton16.Text = "No";
            this.radioButton16.UseVisualStyleBackColor = true;
            // 
            // txtNombreTarjetahabiente
            // 
            this.defaultToolTipController1.SetAllowHtmlText(this.txtNombreTarjetahabiente, DevExpress.Utils.DefaultBoolean.Default);
            this.txtNombreTarjetahabiente.Location = new System.Drawing.Point(227, 181);
            this.txtNombreTarjetahabiente.MaxLength = 100;
            this.txtNombreTarjetahabiente.Name = "txtNombreTarjetahabiente";
            this.txtNombreTarjetahabiente.Size = new System.Drawing.Size(180, 20);
            this.txtNombreTarjetahabiente.TabIndex = 15;
            this.txtNombreTarjetahabiente.Leave += new System.EventHandler(this.txtNombreTarjetahabiente_Leave);
            // 
            // lblDigitoSeguridad
            // 
            this.defaultToolTipController1.SetAllowHtmlText(this.lblDigitoSeguridad, DevExpress.Utils.DefaultBoolean.Default);
            this.lblDigitoSeguridad.AutoSize = true;
            this.lblDigitoSeguridad.Location = new System.Drawing.Point(111, 110);
            this.lblDigitoSeguridad.Name = "lblDigitoSeguridad";
            this.lblDigitoSeguridad.Size = new System.Drawing.Size(99, 13);
            this.lblDigitoSeguridad.TabIndex = 216;
            this.lblDigitoSeguridad.Text = "Códigos Seguridad:";
            // 
            // lblNombreTarjetahabiente
            // 
            this.defaultToolTipController1.SetAllowHtmlText(this.lblNombreTarjetahabiente, DevExpress.Utils.DefaultBoolean.Default);
            this.lblNombreTarjetahabiente.AutoSize = true;
            this.lblNombreTarjetahabiente.Location = new System.Drawing.Point(111, 184);
            this.lblNombreTarjetahabiente.Name = "lblNombreTarjetahabiente";
            this.lblNombreTarjetahabiente.Size = new System.Drawing.Size(79, 13);
            this.lblNombreTarjetahabiente.TabIndex = 215;
            this.lblNombreTarjetahabiente.Text = "Nombre Titular:";
            // 
            // cmbAnioVencimiento
            // 
            this.defaultToolTipController1.SetAllowHtmlText(this.cmbAnioVencimiento, DevExpress.Utils.DefaultBoolean.Default);
            this.cmbAnioVencimiento.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbAnioVencimiento.FormattingEnabled = true;
            this.cmbAnioVencimiento.Location = new System.Drawing.Point(228, 156);
            this.cmbAnioVencimiento.Name = "cmbAnioVencimiento";
            this.cmbAnioVencimiento.Size = new System.Drawing.Size(179, 21);
            this.cmbAnioVencimiento.TabIndex = 14;
            this.cmbAnioVencimiento.SelectedIndexChanged += new System.EventHandler(this.cmbGenerico_SelectedIndexChanged);
            // 
            // cmbMesVencimiento
            // 
            this.defaultToolTipController1.SetAllowHtmlText(this.cmbMesVencimiento, DevExpress.Utils.DefaultBoolean.Default);
            this.cmbMesVencimiento.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMesVencimiento.FormattingEnabled = true;
            this.cmbMesVencimiento.Location = new System.Drawing.Point(228, 131);
            this.cmbMesVencimiento.Name = "cmbMesVencimiento";
            this.cmbMesVencimiento.Size = new System.Drawing.Size(179, 21);
            this.cmbMesVencimiento.TabIndex = 13;
            this.cmbMesVencimiento.SelectedIndexChanged += new System.EventHandler(this.cmbGenerico_SelectedIndexChanged);
            // 
            // lblAnioVencimiento
            // 
            this.defaultToolTipController1.SetAllowHtmlText(this.lblAnioVencimiento, DevExpress.Utils.DefaultBoolean.Default);
            this.lblAnioVencimiento.AutoSize = true;
            this.lblAnioVencimiento.Location = new System.Drawing.Point(111, 159);
            this.lblAnioVencimiento.Name = "lblAnioVencimiento";
            this.lblAnioVencimiento.Size = new System.Drawing.Size(90, 13);
            this.lblAnioVencimiento.TabIndex = 212;
            this.lblAnioVencimiento.Text = "Año Vencimiento:";
            // 
            // lblMesVencimiento
            // 
            this.defaultToolTipController1.SetAllowHtmlText(this.lblMesVencimiento, DevExpress.Utils.DefaultBoolean.Default);
            this.lblMesVencimiento.AutoSize = true;
            this.lblMesVencimiento.Location = new System.Drawing.Point(111, 134);
            this.lblMesVencimiento.Name = "lblMesVencimiento";
            this.lblMesVencimiento.Size = new System.Drawing.Size(91, 13);
            this.lblMesVencimiento.TabIndex = 211;
            this.lblMesVencimiento.Text = "Mes Vencimiento:";
            // 
            // cmbTypeCard
            // 
            this.defaultToolTipController1.SetAllowHtmlText(this.cmbTypeCard, DevExpress.Utils.DefaultBoolean.Default);
            this.cmbTypeCard.DisplayMember = "Text";
            this.cmbTypeCard.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTypeCard.FormattingEnabled = true;
            this.cmbTypeCard.Items.AddRange(new object[] {
            "- Selecciona Forma de Pago -"});
            this.cmbTypeCard.Location = new System.Drawing.Point(227, 60);
            this.cmbTypeCard.Name = "cmbTypeCard";
            this.cmbTypeCard.Size = new System.Drawing.Size(180, 21);
            this.cmbTypeCard.TabIndex = 10;
            this.cmbTypeCard.ValueMember = "Value";
            this.cmbTypeCard.SelectionChangeCommitted += new System.EventHandler(this.cmbTypeCard_SelectionChangeCommitted);
            // 
            // lblCardTypeCTS
            // 
            this.defaultToolTipController1.SetAllowHtmlText(this.lblCardTypeCTS, DevExpress.Utils.DefaultBoolean.Default);
            this.lblCardTypeCTS.AutoSize = true;
            this.lblCardTypeCTS.Location = new System.Drawing.Point(111, 63);
            this.lblCardTypeCTS.Name = "lblCardTypeCTS";
            this.lblCardTypeCTS.Size = new System.Drawing.Size(81, 13);
            this.lblCardTypeCTS.TabIndex = 208;
            this.lblCardTypeCTS.Text = "Forma de pago:";
            this.lblCardTypeCTS.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblCardNumberCTS
            // 
            this.defaultToolTipController1.SetAllowHtmlText(this.lblCardNumberCTS, DevExpress.Utils.DefaultBoolean.Default);
            this.lblCardNumberCTS.AutoSize = true;
            this.lblCardNumberCTS.Location = new System.Drawing.Point(111, 87);
            this.lblCardNumberCTS.Name = "lblCardNumberCTS";
            this.lblCardNumberCTS.Size = new System.Drawing.Size(94, 13);
            this.lblCardNumberCTS.TabIndex = 207;
            this.lblCardNumberCTS.Text = "Número de tarjeta:";
            this.lblCardNumberCTS.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblImport
            // 
            this.defaultToolTipController1.SetAllowHtmlText(this.lblImport, DevExpress.Utils.DefaultBoolean.Default);
            this.lblImport.BackColor = System.Drawing.Color.Transparent;
            this.lblImport.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblImport.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblImport.ForeColor = System.Drawing.Color.Black;
            this.lblImport.Location = new System.Drawing.Point(114, 40);
            this.lblImport.Name = "lblImport";
            this.lblImport.Size = new System.Drawing.Size(294, 17);
            this.lblImport.TabIndex = 206;
            this.lblImport.Text = "Cargo por servicio Pax 1.1";
            this.lblImport.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtDigitoSeguridad
            // 
            this.txtDigitoSeguridad.AllowBlankSpaces = false;
            this.defaultToolTipController1.SetAllowHtmlText(this.txtDigitoSeguridad, DevExpress.Utils.DefaultBoolean.Default);
            this.txtDigitoSeguridad.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtDigitoSeguridad.CharsIncluded = new char[0];
            this.txtDigitoSeguridad.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.OnlyNumbers;
            this.txtDigitoSeguridad.CustomExpression = ".*";
            this.txtDigitoSeguridad.EnterColor = System.Drawing.Color.Empty;
            this.txtDigitoSeguridad.Font = new System.Drawing.Font("Symbol", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            this.txtDigitoSeguridad.LeaveColor = System.Drawing.Color.Empty;
            this.txtDigitoSeguridad.Location = new System.Drawing.Point(228, 107);
            this.txtDigitoSeguridad.MaxLength = 4;
            this.txtDigitoSeguridad.Name = "txtDigitoSeguridad";
            this.txtDigitoSeguridad.PasswordChar = '·';
            this.txtDigitoSeguridad.Size = new System.Drawing.Size(179, 22);
            this.txtDigitoSeguridad.TabIndex = 12;
            this.txtDigitoSeguridad.LostFocus += new System.EventHandler(this.txtGenerico_LostFocus);
            // 
            // txtNumberCardCTS
            // 
            this.txtNumberCardCTS.AllowBlankSpaces = false;
            this.defaultToolTipController1.SetAllowHtmlText(this.txtNumberCardCTS, DevExpress.Utils.DefaultBoolean.Default);
            this.txtNumberCardCTS.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtNumberCardCTS.CharsIncluded = new char[0];
            this.txtNumberCardCTS.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.OnlyNumbers;
            this.txtNumberCardCTS.CustomExpression = ".*";
            this.txtNumberCardCTS.EnterColor = System.Drawing.Color.Empty;
            this.txtNumberCardCTS.Font = new System.Drawing.Font("Symbol", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            this.txtNumberCardCTS.LeaveColor = System.Drawing.Color.Empty;
            this.txtNumberCardCTS.Location = new System.Drawing.Point(227, 84);
            this.txtNumberCardCTS.MaxLength = 16;
            this.txtNumberCardCTS.Name = "txtNumberCardCTS";
            this.txtNumberCardCTS.Size = new System.Drawing.Size(180, 22);
            this.txtNumberCardCTS.TabIndex = 11;
            // 
            // smartTextBox1
            // 
            this.smartTextBox1.AllowBlankSpaces = false;
            this.defaultToolTipController1.SetAllowHtmlText(this.smartTextBox1, DevExpress.Utils.DefaultBoolean.Default);
            this.smartTextBox1.BackColor = System.Drawing.SystemColors.Window;
            this.smartTextBox1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.smartTextBox1.CharsIncluded = new char[] {
        '.'};
            this.smartTextBox1.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.AnyCharacter;
            this.smartTextBox1.CustomExpression = ".*";
            this.smartTextBox1.EnterColor = System.Drawing.Color.Empty;
            this.smartTextBox1.LeaveColor = System.Drawing.Color.Empty;
            this.smartTextBox1.Location = new System.Drawing.Point(47, 377);
            this.smartTextBox1.Multiline = true;
            this.smartTextBox1.Name = "smartTextBox1";
            this.smartTextBox1.ReadOnly = true;
            this.smartTextBox1.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.smartTextBox1.Size = new System.Drawing.Size(306, 161);
            this.smartTextBox1.TabIndex = 71;
            this.smartTextBox1.Visible = false;
            // 
            // txtPax1
            // 
            this.txtPax1.AllowBlankSpaces = false;
            this.defaultToolTipController1.SetAllowHtmlText(this.txtPax1, DevExpress.Utils.DefaultBoolean.Default);
            this.txtPax1.BackColor = System.Drawing.SystemColors.Window;
            this.txtPax1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtPax1.CharsIncluded = new char[] {
        '.'};
            this.txtPax1.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.OnlyNumbers;
            this.txtPax1.CustomExpression = ".*";
            this.txtPax1.Enabled = false;
            this.txtPax1.EnterColor = System.Drawing.Color.White;
            this.txtPax1.LeaveColor = System.Drawing.Color.Empty;
            this.txtPax1.Location = new System.Drawing.Point(51, 40);
            this.txtPax1.MaxLength = 8;
            this.txtPax1.Name = "txtPax1";
            this.txtPax1.Size = new System.Drawing.Size(57, 20);
            this.txtPax1.TabIndex = 1;
            this.txtPax1.GotFocus += new System.EventHandler(this.txtGenerico_GotFocus);
            this.txtPax1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            this.txtPax1.LostFocus += new System.EventHandler(this.txtGenerico_LostFocus);
            // 
            // txtPax3
            // 
            this.txtPax3.AllowBlankSpaces = false;
            this.defaultToolTipController1.SetAllowHtmlText(this.txtPax3, DevExpress.Utils.DefaultBoolean.Default);
            this.txtPax3.BackColor = System.Drawing.SystemColors.Window;
            this.txtPax3.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtPax3.CharsIncluded = new char[] {
        '.'};
            this.txtPax3.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.OnlyNumbers;
            this.txtPax3.CustomExpression = ".*";
            this.txtPax3.Enabled = false;
            this.txtPax3.EnterColor = System.Drawing.Color.Empty;
            this.txtPax3.LeaveColor = System.Drawing.Color.Empty;
            this.txtPax3.Location = new System.Drawing.Point(51, 88);
            this.txtPax3.MaxLength = 8;
            this.txtPax3.Name = "txtPax3";
            this.txtPax3.Size = new System.Drawing.Size(57, 20);
            this.txtPax3.TabIndex = 3;
            this.txtPax3.GotFocus += new System.EventHandler(this.txtGenerico_GotFocus);
            this.txtPax3.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            this.txtPax3.LostFocus += new System.EventHandler(this.txtGenerico_LostFocus);
            // 
            // txtPax4
            // 
            this.txtPax4.AllowBlankSpaces = false;
            this.defaultToolTipController1.SetAllowHtmlText(this.txtPax4, DevExpress.Utils.DefaultBoolean.Default);
            this.txtPax4.BackColor = System.Drawing.SystemColors.Window;
            this.txtPax4.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtPax4.CharsIncluded = new char[] {
        '.'};
            this.txtPax4.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.OnlyNumbers;
            this.txtPax4.CustomExpression = ".*";
            this.txtPax4.Enabled = false;
            this.txtPax4.EnterColor = System.Drawing.Color.Empty;
            this.txtPax4.LeaveColor = System.Drawing.Color.Empty;
            this.txtPax4.Location = new System.Drawing.Point(51, 112);
            this.txtPax4.MaxLength = 8;
            this.txtPax4.Name = "txtPax4";
            this.txtPax4.Size = new System.Drawing.Size(57, 20);
            this.txtPax4.TabIndex = 4;
            this.txtPax4.GotFocus += new System.EventHandler(this.txtGenerico_GotFocus);
            this.txtPax4.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            this.txtPax4.LostFocus += new System.EventHandler(this.txtGenerico_LostFocus);
            // 
            // txtPax5
            // 
            this.txtPax5.AllowBlankSpaces = false;
            this.defaultToolTipController1.SetAllowHtmlText(this.txtPax5, DevExpress.Utils.DefaultBoolean.Default);
            this.txtPax5.BackColor = System.Drawing.SystemColors.Window;
            this.txtPax5.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtPax5.CharsIncluded = new char[] {
        '.'};
            this.txtPax5.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.OnlyNumbers;
            this.txtPax5.CustomExpression = ".*";
            this.txtPax5.Enabled = false;
            this.txtPax5.EnterColor = System.Drawing.Color.Empty;
            this.txtPax5.LeaveColor = System.Drawing.Color.Empty;
            this.txtPax5.Location = new System.Drawing.Point(51, 136);
            this.txtPax5.MaxLength = 8;
            this.txtPax5.Name = "txtPax5";
            this.txtPax5.Size = new System.Drawing.Size(57, 20);
            this.txtPax5.TabIndex = 5;
            this.txtPax5.GotFocus += new System.EventHandler(this.txtGenerico_GotFocus);
            this.txtPax5.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            this.txtPax5.LostFocus += new System.EventHandler(this.txtGenerico_LostFocus);
            // 
            // txtPax6
            // 
            this.txtPax6.AllowBlankSpaces = false;
            this.defaultToolTipController1.SetAllowHtmlText(this.txtPax6, DevExpress.Utils.DefaultBoolean.Default);
            this.txtPax6.BackColor = System.Drawing.SystemColors.Window;
            this.txtPax6.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtPax6.CharsIncluded = new char[] {
        '.'};
            this.txtPax6.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.OnlyNumbers;
            this.txtPax6.CustomExpression = ".*";
            this.txtPax6.Enabled = false;
            this.txtPax6.EnterColor = System.Drawing.Color.Empty;
            this.txtPax6.LeaveColor = System.Drawing.Color.Empty;
            this.txtPax6.Location = new System.Drawing.Point(51, 161);
            this.txtPax6.MaxLength = 8;
            this.txtPax6.Name = "txtPax6";
            this.txtPax6.Size = new System.Drawing.Size(57, 20);
            this.txtPax6.TabIndex = 6;
            this.txtPax6.GotFocus += new System.EventHandler(this.txtGenerico_GotFocus);
            this.txtPax6.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            this.txtPax6.LostFocus += new System.EventHandler(this.txtGenerico_LostFocus);
            // 
            // txtPax7
            // 
            this.txtPax7.AllowBlankSpaces = false;
            this.defaultToolTipController1.SetAllowHtmlText(this.txtPax7, DevExpress.Utils.DefaultBoolean.Default);
            this.txtPax7.BackColor = System.Drawing.SystemColors.Window;
            this.txtPax7.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtPax7.CharsIncluded = new char[] {
        '.'};
            this.txtPax7.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.OnlyNumbers;
            this.txtPax7.CustomExpression = ".*";
            this.txtPax7.Enabled = false;
            this.txtPax7.EnterColor = System.Drawing.Color.Empty;
            this.txtPax7.LeaveColor = System.Drawing.Color.Empty;
            this.txtPax7.Location = new System.Drawing.Point(51, 186);
            this.txtPax7.MaxLength = 8;
            this.txtPax7.Name = "txtPax7";
            this.txtPax7.Size = new System.Drawing.Size(57, 20);
            this.txtPax7.TabIndex = 7;
            this.txtPax7.GotFocus += new System.EventHandler(this.txtGenerico_GotFocus);
            this.txtPax7.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            this.txtPax7.LostFocus += new System.EventHandler(this.txtGenerico_LostFocus);
            // 
            // txtPax8
            // 
            this.txtPax8.AllowBlankSpaces = false;
            this.defaultToolTipController1.SetAllowHtmlText(this.txtPax8, DevExpress.Utils.DefaultBoolean.Default);
            this.txtPax8.BackColor = System.Drawing.SystemColors.Window;
            this.txtPax8.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtPax8.CharsIncluded = new char[] {
        '.'};
            this.txtPax8.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.OnlyNumbers;
            this.txtPax8.CustomExpression = ".*";
            this.txtPax8.Enabled = false;
            this.txtPax8.EnterColor = System.Drawing.Color.Empty;
            this.txtPax8.LeaveColor = System.Drawing.Color.Empty;
            this.txtPax8.Location = new System.Drawing.Point(51, 210);
            this.txtPax8.MaxLength = 8;
            this.txtPax8.Name = "txtPax8";
            this.txtPax8.Size = new System.Drawing.Size(57, 20);
            this.txtPax8.TabIndex = 8;
            this.txtPax8.GotFocus += new System.EventHandler(this.txtGenerico_GotFocus);
            this.txtPax8.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            this.txtPax8.LostFocus += new System.EventHandler(this.txtGenerico_LostFocus);
            // 
            // txtPax9
            // 
            this.txtPax9.AllowBlankSpaces = false;
            this.defaultToolTipController1.SetAllowHtmlText(this.txtPax9, DevExpress.Utils.DefaultBoolean.Default);
            this.txtPax9.BackColor = System.Drawing.SystemColors.Window;
            this.txtPax9.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtPax9.CharsIncluded = new char[] {
        '.'};
            this.txtPax9.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.OnlyNumbers;
            this.txtPax9.CustomExpression = ".*";
            this.txtPax9.Enabled = false;
            this.txtPax9.EnterColor = System.Drawing.Color.Empty;
            this.txtPax9.LeaveColor = System.Drawing.Color.Empty;
            this.txtPax9.Location = new System.Drawing.Point(51, 235);
            this.txtPax9.MaxLength = 8;
            this.txtPax9.Name = "txtPax9";
            this.txtPax9.Size = new System.Drawing.Size(57, 20);
            this.txtPax9.TabIndex = 9;
            this.txtPax9.GotFocus += new System.EventHandler(this.txtGenerico_GotFocus);
            this.txtPax9.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            this.txtPax9.LostFocus += new System.EventHandler(this.txtGenerico_LostFocus);
            // 
            // txtPax2
            // 
            this.txtPax2.AllowBlankSpaces = false;
            this.defaultToolTipController1.SetAllowHtmlText(this.txtPax2, DevExpress.Utils.DefaultBoolean.Default);
            this.txtPax2.BackColor = System.Drawing.SystemColors.Window;
            this.txtPax2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtPax2.CharsIncluded = new char[] {
        '.'};
            this.txtPax2.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.OnlyNumbers;
            this.txtPax2.CustomExpression = ".*";
            this.txtPax2.Enabled = false;
            this.txtPax2.EnterColor = System.Drawing.Color.Empty;
            this.txtPax2.LeaveColor = System.Drawing.Color.Empty;
            this.txtPax2.Location = new System.Drawing.Point(51, 64);
            this.txtPax2.MaxLength = 8;
            this.txtPax2.Name = "txtPax2";
            this.txtPax2.Size = new System.Drawing.Size(57, 20);
            this.txtPax2.TabIndex = 2;
            this.txtPax2.GotFocus += new System.EventHandler(this.txtGenerico_GotFocus);
            this.txtPax2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            this.txtPax2.LostFocus += new System.EventHandler(this.txtGenerico_LostFocus);
            // 
            // chkSameForAll
            // 
            this.defaultToolTipController1.SetAllowHtmlText(this.chkSameForAll, DevExpress.Utils.DefaultBoolean.Default);
            this.chkSameForAll.AutoSize = true;
            this.chkSameForAll.Location = new System.Drawing.Point(158, 214);
            this.chkSameForAll.Name = "chkSameForAll";
            this.chkSameForAll.Size = new System.Drawing.Size(249, 17);
            this.chkSameForAll.TabIndex = 16;
            this.chkSameForAll.Text = "Misma Forma de Pago para todos los Pasajeros";
            this.chkSameForAll.UseVisualStyleBackColor = true;
            this.chkSameForAll.Click += new System.EventHandler(this.chkSameForAll_Click);
            // 
            // btnContinue
            // 
            this.defaultToolTipController1.SetAllowHtmlText(this.btnContinue, DevExpress.Utils.DefaultBoolean.Default);
            this.btnContinue.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnContinue.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnContinue.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnContinue.Location = new System.Drawing.Point(181, 323);
            this.btnContinue.Name = "btnContinue";
            this.btnContinue.Size = new System.Drawing.Size(110, 47);
            this.btnContinue.TabIndex = 17;
            this.btnContinue.Text = "Continuar sin aplicar cargo";
            this.btnContinue.UseVisualStyleBackColor = false;
            this.btnContinue.Click += new System.EventHandler(this.btnContinue_Click);
            // 
            // loadingPictureBox
            // 
            this.defaultToolTipController1.SetAllowHtmlText(this.loadingPictureBox, DevExpress.Utils.DefaultBoolean.Default);
            this.loadingPictureBox.Image = global::MyCTS.Presentation.Properties.Resources.loadingBlue;
            this.loadingPictureBox.Location = new System.Drawing.Point(84, 261);
            this.loadingPictureBox.Name = "loadingPictureBox";
            this.loadingPictureBox.Size = new System.Drawing.Size(256, 25);
            this.loadingPictureBox.TabIndex = 217;
            this.loadingPictureBox.TabStop = false;
            this.loadingPictureBox.Visible = false;
            // 
            // lblLeyendaIva
            // 
            this.defaultToolTipController1.SetAllowHtmlText(this.lblLeyendaIva, DevExpress.Utils.DefaultBoolean.Default);
            this.lblLeyendaIva.AutoSize = true;
            this.lblLeyendaIva.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLeyendaIva.ForeColor = System.Drawing.Color.Red;
            this.lblLeyendaIva.Location = new System.Drawing.Point(8, 21);
            this.lblLeyendaIva.Name = "lblLeyendaIva";
            this.lblLeyendaIva.Size = new System.Drawing.Size(367, 13);
            this.lblLeyendaIva.TabIndex = 219;
            this.lblLeyendaIva.Text = "EL SISTEMA AUTOMATICAMENTE INCLUIRA EL IVA DEL 16%";
            this.lblLeyendaIva.Visible = false;
            // 
            // ucCalculateServiceCharge
            // 
            this.defaultToolTipController1.SetAllowHtmlText(this, DevExpress.Utils.DefaultBoolean.Default);
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.lblLeyendaIva);
            this.Controls.Add(this.lblEsperar);
            this.Controls.Add(this.loadingPictureBox);
            this.Controls.Add(this.btnContinue);
            this.Controls.Add(this.chkSameForAll);
            this.Controls.Add(this.txtNombreTarjetahabiente);
            this.Controls.Add(this.txtDigitoSeguridad);
            this.Controls.Add(this.lblDigitoSeguridad);
            this.Controls.Add(this.lblNombreTarjetahabiente);
            this.Controls.Add(this.cmbAnioVencimiento);
            this.Controls.Add(this.cmbMesVencimiento);
            this.Controls.Add(this.lblAnioVencimiento);
            this.Controls.Add(this.lblMesVencimiento);
            this.Controls.Add(this.cmbTypeCard);
            this.Controls.Add(this.lblCardTypeCTS);
            this.Controls.Add(this.lblCardNumberCTS);
            this.Controls.Add(this.txtNumberCardCTS);
            this.Controls.Add(this.lblImport);
            this.Controls.Add(this.btnCreateNewRule);
            this.Controls.Add(this.btnAccept);
            this.Controls.Add(this.PictureBoxBanner);
            this.Controls.Add(this.lblChargePerService);
            this.Controls.Add(this.smartTextBox1);
            this.Controls.Add(this.lblPax9);
            this.Controls.Add(this.lblPax8);
            this.Controls.Add(this.txtPax1);
            this.Controls.Add(this.lblPax6);
            this.Controls.Add(this.txtPax3);
            this.Controls.Add(this.lblPax7);
            this.Controls.Add(this.txtPax4);
            this.Controls.Add(this.lblPax5);
            this.Controls.Add(this.txtPax5);
            this.Controls.Add(this.lblPax4);
            this.Controls.Add(this.txtPax6);
            this.Controls.Add(this.lblPax3);
            this.Controls.Add(this.txtPax7);
            this.Controls.Add(this.lblPax2);
            this.Controls.Add(this.txtPax8);
            this.Controls.Add(this.lblPax1);
            this.Controls.Add(this.txtPax9);
            this.Controls.Add(this.txtPax2);
            this.Name = "ucCalculateServiceCharge";
            this.Size = new System.Drawing.Size(420, 623);
            this.Load += new System.EventHandler(this.ucCalculateServiceCharge_Load);
            ((System.ComponentModel.ISupportInitialize)(this.PictureBoxBanner)).EndInit();
            this.tableLayoutPanel9.ResumeLayout(false);
            this.tableLayoutPanel9.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.loadingPictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.Label lblChargePerService;
        private System.Windows.Forms.Label lblPax1;
        private System.Windows.Forms.Label lblPax2;
        private System.Windows.Forms.Label lblPax3;
        private System.Windows.Forms.Label lblPax4;
        private System.Windows.Forms.Label lblPax5;
        private System.Windows.Forms.Label lblPax7;
        private System.Windows.Forms.Label lblPax6;
        private System.Windows.Forms.Label lblPax8;
        private System.Windows.Forms.Label lblPax9;
        private System.Windows.Forms.Button btnAccept;
        private MyCTS.Forms.UI.SmartTextBox txtPax1;
        private MyCTS.Forms.UI.SmartTextBox txtPax3;
        private MyCTS.Forms.UI.SmartTextBox txtPax4;
        private MyCTS.Forms.UI.SmartTextBox txtPax5;
        private MyCTS.Forms.UI.SmartTextBox txtPax6;
        private MyCTS.Forms.UI.SmartTextBox txtPax7;
        private MyCTS.Forms.UI.SmartTextBox txtPax8;
        private MyCTS.Forms.UI.SmartTextBox txtPax9;
        private MyCTS.Forms.UI.SmartTextBox txtPax2;
        private MyCTS.Forms.UI.SmartTextBox smartTextBox1;
        //private System.Windows.Forms.Button btnNewFeeRule;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label lblEsperar;
        private System.Windows.Forms.Button btnCreateNewRule;
        private System.Windows.Forms.PictureBox PictureBoxBanner;
        private System.Windows.Forms.ToolTip toolTipBanner;
        private System.Windows.Forms.Timer TimerBanerImages;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel9;
        private System.Windows.Forms.RadioButton radioButton15;
        private System.Windows.Forms.RadioButton radioButton16;
        private DevExpress.Utils.DefaultToolTipController defaultToolTipController1;
        private System.Windows.Forms.TextBox txtNombreTarjetahabiente;
        private MyCTS.Forms.UI.SmartTextBox txtDigitoSeguridad;
        private System.Windows.Forms.Label lblDigitoSeguridad;
        private System.Windows.Forms.Label lblNombreTarjetahabiente;
        private System.Windows.Forms.ComboBox cmbAnioVencimiento;
        private System.Windows.Forms.ComboBox cmbMesVencimiento;
        private System.Windows.Forms.Label lblAnioVencimiento;
        private System.Windows.Forms.Label lblMesVencimiento;
        private System.Windows.Forms.ComboBox cmbTypeCard;
        private System.Windows.Forms.Label lblCardTypeCTS;
        private System.Windows.Forms.Label lblCardNumberCTS;
        private MyCTS.Forms.UI.SmartTextBox txtNumberCardCTS;
        private System.Windows.Forms.Label lblImport;
        private System.Windows.Forms.CheckBox chkSameForAll;
        private System.Windows.Forms.Button btnContinue;
        private System.Windows.Forms.PictureBox loadingPictureBox;
        private System.Windows.Forms.Label lblLeyendaIva;
    }
}
