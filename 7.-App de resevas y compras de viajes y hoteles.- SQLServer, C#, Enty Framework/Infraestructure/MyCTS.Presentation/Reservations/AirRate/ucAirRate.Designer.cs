namespace MyCTS.Presentation
{
    partial class ucAirRate
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
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.lblTitle = new System.Windows.Forms.Label();
            this.tblLayoutMain = new System.Windows.Forms.TableLayoutPanel();
            this.lbl5 = new System.Windows.Forms.Label();
            this.txtSegment6 = new MyCTS.Forms.UI.SmartTextBox();
            this.cmbAirline = new System.Windows.Forms.ComboBox();
            this.lbl1 = new System.Windows.Forms.Label();
            this.rdoQuoItinerary = new System.Windows.Forms.RadioButton();
            this.rdoSellOtherFly = new System.Windows.Forms.RadioButton();
            this.rdoSaveRate = new System.Windows.Forms.RadioButton();
            this.rdoQuoCheapBut = new System.Windows.Forms.RadioButton();
            this.rdoQuoCheapNonavailable = new System.Windows.Forms.RadioButton();
            this.rdoChangeToMostCheap = new System.Windows.Forms.RadioButton();
            this.rdoSearchFlights = new System.Windows.Forms.RadioButton();
            this.rdoManualRate = new System.Windows.Forms.RadioButton();
            this.rdoRateOptions = new System.Windows.Forms.RadioButton();
            this.rdoBuildQuaDisplayed = new System.Windows.Forms.RadioButton();
            this.rdoQuaWeb = new System.Windows.Forms.RadioButton();
            this.rdoPhase35375 = new System.Windows.Forms.RadioButton();
            this.lbl2 = new System.Windows.Forms.Label();
            this.lbl3 = new System.Windows.Forms.Label();
            this.lbl4 = new System.Windows.Forms.Label();
            this.lbl7 = new System.Windows.Forms.Label();
            this.lbl10 = new System.Windows.Forms.Label();
            this.lbl11 = new System.Windows.Forms.Label();
            this.lbl12 = new System.Windows.Forms.Label();
            this.lbl13 = new System.Windows.Forms.Label();
            this.lbl14 = new System.Windows.Forms.Label();
            this.lbl15 = new System.Windows.Forms.Label();
            this.lbMoneyCode = new System.Windows.Forms.ListBox();
            this.txtMoneyCode = new MyCTS.Forms.UI.SmartTextBox();
            this.lbl16 = new System.Windows.Forms.Label();
            this.tblLayoutPassPosition = new System.Windows.Forms.TableLayoutPanel();
            this.label2 = new System.Windows.Forms.Label();
            this.txtPassenger1 = new MyCTS.Forms.UI.SmartTextBox();
            this.lbl8 = new System.Windows.Forms.Label();
            this.txtPassenger2 = new MyCTS.Forms.UI.SmartTextBox();
            this.lbl9 = new System.Windows.Forms.Label();
            this.txtPassenger3 = new MyCTS.Forms.UI.SmartTextBox();
            this.chkPassPosition = new System.Windows.Forms.CheckBox();
            this.txtPassenger4 = new MyCTS.Forms.UI.SmartTextBox();
            this.tblLayoutBySegments = new System.Windows.Forms.TableLayoutPanel();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtSegment1 = new MyCTS.Forms.UI.SmartTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lbl6 = new System.Windows.Forms.Label();
            this.txtSegment3 = new MyCTS.Forms.UI.SmartTextBox();
            this.txtSegment2 = new MyCTS.Forms.UI.SmartTextBox();
            this.chkBySegments = new System.Windows.Forms.CheckBox();
            this.txtSegment5 = new MyCTS.Forms.UI.SmartTextBox();
            this.txtSegment4 = new MyCTS.Forms.UI.SmartTextBox();
            this.tblLayoutCorporateId = new System.Windows.Forms.TableLayoutPanel();
            this.lbl18 = new System.Windows.Forms.Label();
            this.lbl21 = new System.Windows.Forms.Label();
            this.txtCorporateId = new MyCTS.Forms.UI.SmartTextBox();
            this.chkXC = new System.Windows.Forms.CheckBox();
            this.tblLayoutAccountCode = new System.Windows.Forms.TableLayoutPanel();
            this.lbl19 = new System.Windows.Forms.Label();
            this.lbl20 = new System.Windows.Forms.Label();
            this.txtAccountCode = new MyCTS.Forms.UI.SmartTextBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.chkPassType = new System.Windows.Forms.CheckBox();
            this.cmbPassType = new System.Windows.Forms.ComboBox();
            this.tblLayoutAccept = new System.Windows.Forms.TableLayoutPanel();
            this.lbl17 = new System.Windows.Forms.Label();
            this.chkPublic = new System.Windows.Forms.CheckBox();
            this.chkPrivate = new System.Windows.Forms.CheckBox();
            this.btnAccept = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            this.tblLayoutMain.SuspendLayout();
            this.tblLayoutPassPosition.SuspendLayout();
            this.tblLayoutBySegments.SuspendLayout();
            this.tblLayoutCorporateId.SuspendLayout();
            this.tblLayoutAccountCode.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.tblLayoutAccept.SuspendLayout();
            this.SuspendLayout();
            // 
            // bindingSource1
            // 
            this.bindingSource1.DataSource = typeof(MyCTS.Entities.AirLinesFare);
            // 
            // lblTitle
            // 
            this.lblTitle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(139)))), ((int)(((byte)(208)))));
            this.lblTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(3, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(405, 15);
            this.lblTitle.TabIndex = 63;
            this.lblTitle.Text = "Cotización Aérea";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // tblLayoutMain
            // 
            this.tblLayoutMain.BackColor = System.Drawing.Color.White;
            this.tblLayoutMain.ColumnCount = 1;
            this.tblLayoutMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblLayoutMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tblLayoutMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tblLayoutMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tblLayoutMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tblLayoutMain.Controls.Add(this.lblTitle, 0, 0);
            this.tblLayoutMain.Location = new System.Drawing.Point(0, 0);
            this.tblLayoutMain.Name = "tblLayoutMain";
            this.tblLayoutMain.RowCount = 1;
            this.tblLayoutMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 16F));
            this.tblLayoutMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 16F));
            this.tblLayoutMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 16F));
            this.tblLayoutMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 16F));
            this.tblLayoutMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 16F));
            this.tblLayoutMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 16F));
            this.tblLayoutMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 16F));
            this.tblLayoutMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 16F));
            this.tblLayoutMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 16F));
            this.tblLayoutMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 16F));
            this.tblLayoutMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 16F));
            this.tblLayoutMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 16F));
            this.tblLayoutMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 16F));
            this.tblLayoutMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 16F));
            this.tblLayoutMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 16F));
            this.tblLayoutMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 16F));
            this.tblLayoutMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 16F));
            this.tblLayoutMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 16F));
            this.tblLayoutMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 16F));
            this.tblLayoutMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 16F));
            this.tblLayoutMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 16F));
            this.tblLayoutMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 16F));
            this.tblLayoutMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 16F));
            this.tblLayoutMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 16F));
            this.tblLayoutMain.Size = new System.Drawing.Size(411, 16);
            this.tblLayoutMain.TabIndex = 4;
            // 
            // lbl5
            // 
            this.lbl5.AutoSize = true;
            this.lbl5.Location = new System.Drawing.Point(152, 391);
            this.lbl5.Name = "lbl5";
            this.lbl5.Size = new System.Drawing.Size(10, 13);
            this.lbl5.TabIndex = 1;
            this.lbl5.Text = "-";
            this.lbl5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtSegment6
            // 
            this.txtSegment6.AllowBlankSpaces = false;
            this.txtSegment6.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtSegment6.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.OnlyNumbers;
            this.txtSegment6.CustomExpression = ".*";
            this.txtSegment6.Dock = System.Windows.Forms.DockStyle.Left;
            this.txtSegment6.EnterColor = System.Drawing.Color.Empty;
            this.txtSegment6.LeaveColor = System.Drawing.Color.Empty;
            this.txtSegment6.Location = new System.Drawing.Point(355, 3);
            this.txtSegment6.MaxLength = 2;
            this.txtSegment6.Name = "txtSegment6";
            this.txtSegment6.Size = new System.Drawing.Size(25, 20);
            this.txtSegment6.TabIndex = 23;
            this.txtSegment6.TextChanged += new System.EventHandler(this.txtSegment6_TextChanged);
            this.txtSegment6.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // cmbAirline
            // 
            this.cmbAirline.DisplayMember = "Text";
            this.cmbAirline.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbAirline.ForeColor = System.Drawing.Color.Black;
            this.cmbAirline.FormattingEnabled = true;
            this.cmbAirline.ItemHeight = 13;
            this.cmbAirline.Items.AddRange(new object[] {
            "Selecciona Aerolínea para Validar Cotización"});
            this.cmbAirline.Location = new System.Drawing.Point(18, 361);
            this.cmbAirline.Name = "cmbAirline";
            this.cmbAirline.Size = new System.Drawing.Size(268, 21);
            this.cmbAirline.TabIndex = 14;
            this.cmbAirline.ValueMember = "Value";
            this.cmbAirline.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // lbl1
            // 
            this.lbl1.AutoSize = true;
            this.lbl1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl1.Location = new System.Drawing.Point(3, 19);
            this.lbl1.Name = "lbl1";
            this.lbl1.Size = new System.Drawing.Size(187, 13);
            this.lbl1.TabIndex = 117;
            this.lbl1.Text = "Selecciona la opción a cotizar: ";
            this.lbl1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // rdoQuoItinerary
            // 
            this.rdoQuoItinerary.AutoSize = true;
            this.rdoQuoItinerary.Location = new System.Drawing.Point(3, 70);
            this.rdoQuoItinerary.Name = "rdoQuoItinerary";
            this.rdoQuoItinerary.Size = new System.Drawing.Size(96, 17);
            this.rdoQuoItinerary.TabIndex = 2;
            this.rdoQuoItinerary.TabStop = true;
            this.rdoQuoItinerary.Text = "Cotiza itinerario";
            this.rdoQuoItinerary.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rdoQuoItinerary.UseVisualStyleBackColor = true;
            this.rdoQuoItinerary.CheckedChanged += new System.EventHandler(this.rdoQuoItinerary_CheckedChanged);
            this.rdoQuoItinerary.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // rdoSellOtherFly
            // 
            this.rdoSellOtherFly.AutoSize = true;
            this.rdoSellOtherFly.Location = new System.Drawing.Point(3, 47);
            this.rdoSellOtherFly.Name = "rdoSellOtherFly";
            this.rdoSellOtherFly.Size = new System.Drawing.Size(106, 17);
            this.rdoSellOtherFly.TabIndex = 1;
            this.rdoSellOtherFly.TabStop = true;
            this.rdoSellOtherFly.Text = "Vende otro vuelo";
            this.rdoSellOtherFly.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rdoSellOtherFly.UseVisualStyleBackColor = true;
            this.rdoSellOtherFly.CheckedChanged += new System.EventHandler(this.rdoSellOtherFly_CheckedChanged);
            this.rdoSellOtherFly.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // rdoSaveRate
            // 
            this.rdoSaveRate.AutoSize = true;
            this.rdoSaveRate.Location = new System.Drawing.Point(3, 93);
            this.rdoSaveRate.Name = "rdoSaveRate";
            this.rdoSaveRate.Size = new System.Drawing.Size(130, 17);
            this.rdoSaveRate.TabIndex = 3;
            this.rdoSaveRate.TabStop = true;
            this.rdoSaveRate.Text = "Guarda  y fin de venta";
            this.rdoSaveRate.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rdoSaveRate.UseVisualStyleBackColor = true;
            this.rdoSaveRate.CheckedChanged += new System.EventHandler(this.rdoSaveRate_CheckedChanged);
            this.rdoSaveRate.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // rdoQuoCheapBut
            // 
            this.rdoQuoCheapBut.AutoSize = true;
            this.rdoQuoCheapBut.Location = new System.Drawing.Point(3, 116);
            this.rdoQuoCheapBut.Name = "rdoQuoCheapBut";
            this.rdoQuoCheapBut.Size = new System.Drawing.Size(142, 17);
            this.rdoQuoCheapBut.TabIndex = 4;
            this.rdoQuoCheapBut.TabStop = true;
            this.rdoQuoCheapBut.Text = "Cotiza lo más económico";
            this.rdoQuoCheapBut.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rdoQuoCheapBut.UseVisualStyleBackColor = true;
            this.rdoQuoCheapBut.CheckedChanged += new System.EventHandler(this.rdoQuoCheapBut_CheckedChanged);
            this.rdoQuoCheapBut.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // rdoQuoCheapNonavailable
            // 
            this.rdoQuoCheapNonavailable.AutoSize = true;
            this.rdoQuoCheapNonavailable.Location = new System.Drawing.Point(3, 139);
            this.rdoQuoCheapNonavailable.Name = "rdoQuoCheapNonavailable";
            this.rdoQuoCheapNonavailable.Size = new System.Drawing.Size(207, 17);
            this.rdoQuoCheapNonavailable.TabIndex = 5;
            this.rdoQuoCheapNonavailable.TabStop = true;
            this.rdoQuoCheapNonavailable.Text = "Cotiza lo más económico no disponible";
            this.rdoQuoCheapNonavailable.UseVisualStyleBackColor = true;
            this.rdoQuoCheapNonavailable.CheckedChanged += new System.EventHandler(this.rdoQuoCheapNonavailable_CheckedChanged);
            this.rdoQuoCheapNonavailable.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // rdoChangeToMostCheap
            // 
            this.rdoChangeToMostCheap.AutoSize = true;
            this.rdoChangeToMostCheap.Location = new System.Drawing.Point(3, 162);
            this.rdoChangeToMostCheap.Name = "rdoChangeToMostCheap";
            this.rdoChangeToMostCheap.Size = new System.Drawing.Size(183, 17);
            this.rdoChangeToMostCheap.TabIndex = 6;
            this.rdoChangeToMostCheap.TabStop = true;
            this.rdoChangeToMostCheap.Text = "Cambia a la tarifa más económica";
            this.rdoChangeToMostCheap.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rdoChangeToMostCheap.UseVisualStyleBackColor = true;
            this.rdoChangeToMostCheap.CheckedChanged += new System.EventHandler(this.rdoChangeToMostCheap_CheckedChanged);
            this.rdoChangeToMostCheap.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // rdoSearchFlights
            // 
            this.rdoSearchFlights.AutoSize = true;
            this.rdoSearchFlights.Location = new System.Drawing.Point(3, 185);
            this.rdoSearchFlights.Name = "rdoSearchFlights";
            this.rdoSearchFlights.Size = new System.Drawing.Size(118, 17);
            this.rdoSearchFlights.TabIndex = 7;
            this.rdoSearchFlights.TabStop = true;
            this.rdoSearchFlights.Text = "Busca otros vuelos ";
            this.rdoSearchFlights.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rdoSearchFlights.UseVisualStyleBackColor = true;
            this.rdoSearchFlights.CheckedChanged += new System.EventHandler(this.rdoSearchFlights_CheckedChanged);
            this.rdoSearchFlights.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // rdoManualRate
            // 
            this.rdoManualRate.AutoSize = true;
            this.rdoManualRate.Location = new System.Drawing.Point(3, 208);
            this.rdoManualRate.Name = "rdoManualRate";
            this.rdoManualRate.Size = new System.Drawing.Size(123, 17);
            this.rdoManualRate.TabIndex = 8;
            this.rdoManualRate.TabStop = true;
            this.rdoManualRate.Text = "Guarda tarifa manual";
            this.rdoManualRate.UseVisualStyleBackColor = true;
            this.rdoManualRate.CheckedChanged += new System.EventHandler(this.rdoManualRate_CheckedChanged);
            this.rdoManualRate.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // rdoRateOptions
            // 
            this.rdoRateOptions.AutoSize = true;
            this.rdoRateOptions.Location = new System.Drawing.Point(3, 231);
            this.rdoRateOptions.Name = "rdoRateOptions";
            this.rdoRateOptions.Size = new System.Drawing.Size(153, 17);
            this.rdoRateOptions.TabIndex = 9;
            this.rdoRateOptions.TabStop = true;
            this.rdoRateOptions.Text = "Ver opciones de cotización";
            this.rdoRateOptions.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.rdoRateOptions.UseVisualStyleBackColor = true;
            this.rdoRateOptions.CheckedChanged += new System.EventHandler(this.rdoRateOptions_CheckedChanged);
            this.rdoRateOptions.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // rdoBuildQuaDisplayed
            // 
            this.rdoBuildQuaDisplayed.AutoSize = true;
            this.rdoBuildQuaDisplayed.Location = new System.Drawing.Point(3, 255);
            this.rdoBuildQuaDisplayed.Name = "rdoBuildQuaDisplayed";
            this.rdoBuildQuaDisplayed.Size = new System.Drawing.Size(197, 17);
            this.rdoBuildQuaDisplayed.TabIndex = 10;
            this.rdoBuildQuaDisplayed.TabStop = true;
            this.rdoBuildQuaDisplayed.Text = "Construcción de la tarifa desplegada";
            this.rdoBuildQuaDisplayed.UseVisualStyleBackColor = true;
            this.rdoBuildQuaDisplayed.CheckedChanged += new System.EventHandler(this.rdoBuildQuaDisplayed_CheckedChanged);
            this.rdoBuildQuaDisplayed.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // rdoQuaWeb
            // 
            this.rdoQuaWeb.AutoSize = true;
            this.rdoQuaWeb.Location = new System.Drawing.Point(3, 278);
            this.rdoQuaWeb.Name = "rdoQuaWeb";
            this.rdoQuaWeb.Size = new System.Drawing.Size(103, 17);
            this.rdoQuaWeb.TabIndex = 11;
            this.rdoQuaWeb.TabStop = true;
            this.rdoQuaWeb.Text = "Cotiza tarifa web";
            this.rdoQuaWeb.UseVisualStyleBackColor = true;
            this.rdoQuaWeb.CheckedChanged += new System.EventHandler(this.rdoQuaWeb_CheckedChanged);
            this.rdoQuaWeb.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // rdoPhase35375
            // 
            this.rdoPhase35375.AutoSize = true;
            this.rdoPhase35375.Location = new System.Drawing.Point(3, 300);
            this.rdoPhase35375.Name = "rdoPhase35375";
            this.rdoPhase35375.Size = new System.Drawing.Size(101, 17);
            this.rdoPhase35375.TabIndex = 12;
            this.rdoPhase35375.TabStop = true;
            this.rdoPhase35375.Text = "Fase 3.5 y 3.75 ";
            this.rdoPhase35375.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rdoPhase35375.UseVisualStyleBackColor = true;
            this.rdoPhase35375.CheckedChanged += new System.EventHandler(this.rdoPhase35375_CheckedChanged);
            this.rdoPhase35375.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // lbl2
            // 
            this.lbl2.AutoSize = true;
            this.lbl2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl2.Location = new System.Drawing.Point(15, 345);
            this.lbl2.Name = "lbl2";
            this.lbl2.Size = new System.Drawing.Size(143, 13);
            this.lbl2.TabIndex = 123;
            this.lbl2.Text = "Parámetros Adicionales:";
            this.lbl2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lbl3
            // 
            this.lbl3.AutoSize = true;
            this.lbl3.ForeColor = System.Drawing.Color.Blue;
            this.lbl3.Location = new System.Drawing.Point(247, 72);
            this.lbl3.Name = "lbl3";
            this.lbl3.Size = new System.Drawing.Size(25, 13);
            this.lbl3.TabIndex = 118;
            this.lbl3.Text = "WP";
            this.lbl3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl4
            // 
            this.lbl4.AutoSize = true;
            this.lbl4.ForeColor = System.Drawing.Color.Blue;
            this.lbl4.Location = new System.Drawing.Point(247, 95);
            this.lbl4.Name = "lbl4";
            this.lbl4.Size = new System.Drawing.Size(22, 13);
            this.lbl4.TabIndex = 119;
            this.lbl4.Text = "PQ";
            this.lbl4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl7
            // 
            this.lbl7.AutoSize = true;
            this.lbl7.ForeColor = System.Drawing.Color.Blue;
            this.lbl7.Location = new System.Drawing.Point(247, 118);
            this.lbl7.Name = "lbl7";
            this.lbl7.Size = new System.Drawing.Size(40, 13);
            this.lbl7.TabIndex = 120;
            this.lbl7.Text = "WPNC";
            this.lbl7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl10
            // 
            this.lbl10.AutoSize = true;
            this.lbl10.ForeColor = System.Drawing.Color.Blue;
            this.lbl10.Location = new System.Drawing.Point(247, 141);
            this.lbl10.Name = "lbl10";
            this.lbl10.Size = new System.Drawing.Size(47, 13);
            this.lbl10.TabIndex = 121;
            this.lbl10.Text = "WPNCS";
            this.lbl10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl11
            // 
            this.lbl11.AutoSize = true;
            this.lbl11.ForeColor = System.Drawing.Color.Blue;
            this.lbl11.Location = new System.Drawing.Point(247, 164);
            this.lbl11.Name = "lbl11";
            this.lbl11.Size = new System.Drawing.Size(47, 13);
            this.lbl11.TabIndex = 122;
            this.lbl11.Text = "WPNCB";
            this.lbl11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl12
            // 
            this.lbl12.AutoSize = true;
            this.lbl12.ForeColor = System.Drawing.Color.Blue;
            this.lbl12.Location = new System.Drawing.Point(247, 187);
            this.lbl12.Name = "lbl12";
            this.lbl12.Size = new System.Drawing.Size(36, 13);
            this.lbl12.TabIndex = 124;
            this.lbl12.Text = "WPNI";
            this.lbl12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl13
            // 
            this.lbl13.AutoSize = true;
            this.lbl13.ForeColor = System.Drawing.Color.Blue;
            this.lbl13.Location = new System.Drawing.Point(247, 210);
            this.lbl13.Name = "lbl13";
            this.lbl13.Size = new System.Drawing.Size(34, 13);
            this.lbl13.TabIndex = 125;
            this.lbl13.Text = "PQM-";
            this.lbl13.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl14
            // 
            this.lbl14.AutoSize = true;
            this.lbl14.ForeColor = System.Drawing.Color.Blue;
            this.lbl14.Location = new System.Drawing.Point(247, 233);
            this.lbl14.Name = "lbl14";
            this.lbl14.Size = new System.Drawing.Size(32, 13);
            this.lbl14.TabIndex = 126;
            this.lbl14.Text = "WPA";
            this.lbl14.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl15
            // 
            this.lbl15.AutoSize = true;
            this.lbl15.ForeColor = System.Drawing.Color.Blue;
            this.lbl15.Location = new System.Drawing.Point(247, 257);
            this.lbl15.Name = "lbl15";
            this.lbl15.Size = new System.Drawing.Size(39, 13);
            this.lbl15.TabIndex = 127;
            this.lbl15.Text = "WPDF";
            this.lbl15.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbMoneyCode
            // 
            this.lbMoneyCode.DisplayMember = "Text";
            this.lbMoneyCode.FormattingEnabled = true;
            this.lbMoneyCode.Location = new System.Drawing.Point(110, 336);
            this.lbMoneyCode.Name = "lbMoneyCode";
            this.lbMoneyCode.Size = new System.Drawing.Size(242, 95);
            this.lbMoneyCode.TabIndex = 0;
            this.lbMoneyCode.TabStop = false;
            this.lbMoneyCode.ValueMember = "Value";
            this.lbMoneyCode.MouseClick += new System.Windows.Forms.MouseEventHandler(this.ListBox_MouseClick);
            this.lbMoneyCode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.lbMoneyCode_KeyDown);
            // 
            // txtMoneyCode
            // 
            this.txtMoneyCode.AllowBlankSpaces = true;
            this.txtMoneyCode.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtMoneyCode.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.OnlyLetters;
            this.txtMoneyCode.CustomExpression = ".*";
            this.txtMoneyCode.EnterColor = System.Drawing.Color.Empty;
            this.txtMoneyCode.LeaveColor = System.Drawing.Color.Empty;
            this.txtMoneyCode.Location = new System.Drawing.Point(110, 317);
            this.txtMoneyCode.MaxLength = 32;
            this.txtMoneyCode.Name = "txtMoneyCode";
            this.txtMoneyCode.Size = new System.Drawing.Size(242, 20);
            this.txtMoneyCode.TabIndex = 13;
            this.txtMoneyCode.TextChanged += new System.EventHandler(this.txtMoneyCode_TextChanged);
            this.txtMoneyCode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.moneyCodeActions_KeyDown);
            // 
            // lbl16
            // 
            this.lbl16.AutoSize = true;
            this.lbl16.ForeColor = System.Drawing.Color.DarkCyan;
            this.lbl16.Location = new System.Drawing.Point(5, 320);
            this.lbl16.Name = "lbl16";
            this.lbl16.Size = new System.Drawing.Size(99, 13);
            this.lbl16.TabIndex = 130;
            this.lbl16.Text = "Código de moneda:";
            this.lbl16.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tblLayoutPassPosition
            // 
            this.tblLayoutPassPosition.ColumnCount = 8;
            this.tblLayoutPassPosition.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 104F));
            this.tblLayoutPassPosition.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 71.66666F));
            this.tblLayoutPassPosition.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 28.33333F));
            this.tblLayoutPassPosition.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 43F));
            this.tblLayoutPassPosition.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 17F));
            this.tblLayoutPassPosition.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 38F));
            this.tblLayoutPassPosition.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 19F));
            this.tblLayoutPassPosition.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 104F));
            this.tblLayoutPassPosition.Controls.Add(this.label2, 6, 0);
            this.tblLayoutPassPosition.Controls.Add(this.txtPassenger1, 1, 0);
            this.tblLayoutPassPosition.Controls.Add(this.lbl8, 2, 0);
            this.tblLayoutPassPosition.Controls.Add(this.txtPassenger2, 3, 0);
            this.tblLayoutPassPosition.Controls.Add(this.lbl9, 4, 0);
            this.tblLayoutPassPosition.Controls.Add(this.txtPassenger3, 5, 0);
            this.tblLayoutPassPosition.Controls.Add(this.chkPassPosition, 0, 0);
            this.tblLayoutPassPosition.Controls.Add(this.txtPassenger4, 7, 0);
            this.tblLayoutPassPosition.Location = new System.Drawing.Point(18, 411);
            this.tblLayoutPassPosition.Margin = new System.Windows.Forms.Padding(0);
            this.tblLayoutPassPosition.Name = "tblLayoutPassPosition";
            this.tblLayoutPassPosition.RowCount = 1;
            this.tblLayoutPassPosition.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblLayoutPassPosition.Size = new System.Drawing.Size(385, 25);
            this.tblLayoutPassPosition.TabIndex = 22;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Left;
            this.label2.Location = new System.Drawing.Point(265, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(12, 25);
            this.label2.TabIndex = 131;
            this.label2.Text = "/";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtPassenger1
            // 
            this.txtPassenger1.AllowBlankSpaces = false;
            this.txtPassenger1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtPassenger1.CharsIncluded = new char[] {
        '.'};
            this.txtPassenger1.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.OnlyNumbers;
            this.txtPassenger1.CustomExpression = "@\"^[0-9]{1,2}[.]{1}[0-9]{1}$\"";
            this.txtPassenger1.Dock = System.Windows.Forms.DockStyle.Left;
            this.txtPassenger1.EnterColor = System.Drawing.Color.Empty;
            this.txtPassenger1.LeaveColor = System.Drawing.Color.Empty;
            this.txtPassenger1.Location = new System.Drawing.Point(107, 3);
            this.txtPassenger1.MaxLength = 4;
            this.txtPassenger1.Name = "txtPassenger1";
            this.txtPassenger1.Size = new System.Drawing.Size(35, 20);
            this.txtPassenger1.TabIndex = 24;
            this.txtPassenger1.TextChanged += new System.EventHandler(this.txtPassenger1_TextChanged);
            this.txtPassenger1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // lbl8
            // 
            this.lbl8.AutoSize = true;
            this.lbl8.Dock = System.Windows.Forms.DockStyle.Left;
            this.lbl8.Location = new System.Drawing.Point(150, 0);
            this.lbl8.Name = "lbl8";
            this.lbl8.Size = new System.Drawing.Size(10, 25);
            this.lbl8.TabIndex = 84;
            this.lbl8.Text = "-";
            this.lbl8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtPassenger2
            // 
            this.txtPassenger2.AllowBlankSpaces = false;
            this.txtPassenger2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtPassenger2.CharsIncluded = new char[] {
        '.'};
            this.txtPassenger2.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.OnlyNumbers;
            this.txtPassenger2.CustomExpression = ".*";
            this.txtPassenger2.Dock = System.Windows.Forms.DockStyle.Left;
            this.txtPassenger2.EnterColor = System.Drawing.Color.Empty;
            this.txtPassenger2.LeaveColor = System.Drawing.Color.Empty;
            this.txtPassenger2.Location = new System.Drawing.Point(167, 3);
            this.txtPassenger2.MaxLength = 4;
            this.txtPassenger2.Name = "txtPassenger2";
            this.txtPassenger2.Size = new System.Drawing.Size(35, 20);
            this.txtPassenger2.TabIndex = 25;
            this.txtPassenger2.TextChanged += new System.EventHandler(this.txtPassenger2_TextChanged);
            this.txtPassenger2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // lbl9
            // 
            this.lbl9.AutoSize = true;
            this.lbl9.Dock = System.Windows.Forms.DockStyle.Left;
            this.lbl9.Location = new System.Drawing.Point(210, 0);
            this.lbl9.Name = "lbl9";
            this.lbl9.Size = new System.Drawing.Size(11, 25);
            this.lbl9.TabIndex = 86;
            this.lbl9.Text = "/";
            this.lbl9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtPassenger3
            // 
            this.txtPassenger3.AllowBlankSpaces = false;
            this.txtPassenger3.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtPassenger3.CharsIncluded = new char[] {
        '.'};
            this.txtPassenger3.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.OnlyNumbers;
            this.txtPassenger3.CustomExpression = ".*";
            this.txtPassenger3.Dock = System.Windows.Forms.DockStyle.Left;
            this.txtPassenger3.EnterColor = System.Drawing.Color.Empty;
            this.txtPassenger3.LeaveColor = System.Drawing.Color.Empty;
            this.txtPassenger3.Location = new System.Drawing.Point(227, 3);
            this.txtPassenger3.MaxLength = 4;
            this.txtPassenger3.Name = "txtPassenger3";
            this.txtPassenger3.Size = new System.Drawing.Size(32, 20);
            this.txtPassenger3.TabIndex = 26;
            this.txtPassenger3.TextChanged += new System.EventHandler(this.txtPassenger3_TextChanged);
            this.txtPassenger3.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // chkPassPosition
            // 
            this.chkPassPosition.AutoSize = true;
            this.chkPassPosition.Dock = System.Windows.Forms.DockStyle.Left;
            this.chkPassPosition.ForeColor = System.Drawing.Color.DarkCyan;
            this.chkPassPosition.Location = new System.Drawing.Point(3, 3);
            this.chkPassPosition.Name = "chkPassPosition";
            this.chkPassPosition.Size = new System.Drawing.Size(86, 19);
            this.chkPassPosition.TabIndex = 23;
            this.chkPassPosition.Text = "Posición pax";
            this.chkPassPosition.UseVisualStyleBackColor = true;
            this.chkPassPosition.CheckedChanged += new System.EventHandler(this.chkPassPosition_CheckedChanged);
            this.chkPassPosition.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // txtPassenger4
            // 
            this.txtPassenger4.AllowBlankSpaces = false;
            this.txtPassenger4.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtPassenger4.CharsIncluded = new char[] {
        '.'};
            this.txtPassenger4.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.OnlyNumbers;
            this.txtPassenger4.CustomExpression = ".*";
            this.txtPassenger4.EnterColor = System.Drawing.Color.Empty;
            this.txtPassenger4.LeaveColor = System.Drawing.Color.Empty;
            this.txtPassenger4.Location = new System.Drawing.Point(284, 3);
            this.txtPassenger4.MaxLength = 4;
            this.txtPassenger4.Name = "txtPassenger4";
            this.txtPassenger4.Size = new System.Drawing.Size(35, 20);
            this.txtPassenger4.TabIndex = 27;
            this.txtPassenger4.TextChanged += new System.EventHandler(this.txtPassenger4_TextChanged);
            this.txtPassenger4.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // tblLayoutBySegments
            // 
            this.tblLayoutBySegments.ColumnCount = 12;
            this.tblLayoutBySegments.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 104F));
            this.tblLayoutBySegments.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 66.66666F));
            this.tblLayoutBySegments.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tblLayoutBySegments.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.tblLayoutBySegments.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 19F));
            this.tblLayoutBySegments.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 33F));
            this.tblLayoutBySegments.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 18F));
            this.tblLayoutBySegments.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.tblLayoutBySegments.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 19F));
            this.tblLayoutBySegments.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.tblLayoutBySegments.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 18F));
            this.tblLayoutBySegments.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 41F));
            this.tblLayoutBySegments.Controls.Add(this.label5, 10, 0);
            this.tblLayoutBySegments.Controls.Add(this.label4, 8, 0);
            this.tblLayoutBySegments.Controls.Add(this.label3, 6, 0);
            this.tblLayoutBySegments.Controls.Add(this.txtSegment1, 1, 0);
            this.tblLayoutBySegments.Controls.Add(this.label1, 2, 0);
            this.tblLayoutBySegments.Controls.Add(this.lbl6, 4, 0);
            this.tblLayoutBySegments.Controls.Add(this.txtSegment3, 5, 0);
            this.tblLayoutBySegments.Controls.Add(this.txtSegment2, 3, 0);
            this.tblLayoutBySegments.Controls.Add(this.chkBySegments, 0, 0);
            this.tblLayoutBySegments.Controls.Add(this.txtSegment6, 11, 0);
            this.tblLayoutBySegments.Controls.Add(this.txtSegment5, 9, 0);
            this.tblLayoutBySegments.Controls.Add(this.txtSegment4, 7, 0);
            this.tblLayoutBySegments.Location = new System.Drawing.Point(18, 385);
            this.tblLayoutBySegments.Margin = new System.Windows.Forms.Padding(0);
            this.tblLayoutBySegments.Name = "tblLayoutBySegments";
            this.tblLayoutBySegments.RowCount = 1;
            this.tblLayoutBySegments.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblLayoutBySegments.Size = new System.Drawing.Size(393, 26);
            this.tblLayoutBySegments.TabIndex = 15;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Dock = System.Windows.Forms.DockStyle.Left;
            this.label5.Location = new System.Drawing.Point(337, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(12, 26);
            this.label5.TabIndex = 0;
            this.label5.Text = "/";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Dock = System.Windows.Forms.DockStyle.Left;
            this.label4.Location = new System.Drawing.Point(286, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(12, 26);
            this.label4.TabIndex = 0;
            this.label4.Text = "/";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Left;
            this.label3.Location = new System.Drawing.Point(236, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(12, 26);
            this.label3.TabIndex = 0;
            this.label3.Text = "/";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtSegment1
            // 
            this.txtSegment1.AllowBlankSpaces = false;
            this.txtSegment1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtSegment1.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.OnlyNumbers;
            this.txtSegment1.CustomExpression = ".*";
            this.txtSegment1.Dock = System.Windows.Forms.DockStyle.Left;
            this.txtSegment1.EnterColor = System.Drawing.Color.Empty;
            this.txtSegment1.LeaveColor = System.Drawing.Color.Empty;
            this.txtSegment1.Location = new System.Drawing.Point(107, 3);
            this.txtSegment1.MaxLength = 2;
            this.txtSegment1.Name = "txtSegment1";
            this.txtSegment1.Size = new System.Drawing.Size(24, 20);
            this.txtSegment1.TabIndex = 17;
            this.txtSegment1.TextChanged += new System.EventHandler(this.txtSegment1_TextChanged);
            this.txtSegment1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Left;
            this.label1.Location = new System.Drawing.Point(137, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(9, 26);
            this.label1.TabIndex = 1;
            this.label1.Text = "-";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl6
            // 
            this.lbl6.AutoSize = true;
            this.lbl6.Dock = System.Windows.Forms.DockStyle.Left;
            this.lbl6.Location = new System.Drawing.Point(184, 0);
            this.lbl6.Name = "lbl6";
            this.lbl6.Size = new System.Drawing.Size(12, 26);
            this.lbl6.TabIndex = 3;
            this.lbl6.Text = "/";
            this.lbl6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtSegment3
            // 
            this.txtSegment3.AllowBlankSpaces = false;
            this.txtSegment3.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtSegment3.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.OnlyNumbers;
            this.txtSegment3.CustomExpression = ".*";
            this.txtSegment3.Dock = System.Windows.Forms.DockStyle.Left;
            this.txtSegment3.EnterColor = System.Drawing.Color.Empty;
            this.txtSegment3.LeaveColor = System.Drawing.Color.Empty;
            this.txtSegment3.Location = new System.Drawing.Point(203, 3);
            this.txtSegment3.MaxLength = 2;
            this.txtSegment3.Name = "txtSegment3";
            this.txtSegment3.Size = new System.Drawing.Size(25, 20);
            this.txtSegment3.TabIndex = 18;
            this.txtSegment3.TextChanged += new System.EventHandler(this.txtSegment3_TextChanged);
            this.txtSegment3.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // txtSegment2
            // 
            this.txtSegment2.AllowBlankSpaces = false;
            this.txtSegment2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtSegment2.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.OnlyNumbers;
            this.txtSegment2.CustomExpression = ".*";
            this.txtSegment2.Dock = System.Windows.Forms.DockStyle.Left;
            this.txtSegment2.EnterColor = System.Drawing.Color.Empty;
            this.txtSegment2.LeaveColor = System.Drawing.Color.Empty;
            this.txtSegment2.Location = new System.Drawing.Point(152, 3);
            this.txtSegment2.MaxLength = 2;
            this.txtSegment2.Name = "txtSegment2";
            this.txtSegment2.Size = new System.Drawing.Size(25, 20);
            this.txtSegment2.TabIndex = 17;
            this.txtSegment2.TextChanged += new System.EventHandler(this.txtSegment2_TextChanged);
            this.txtSegment2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // chkBySegments
            // 
            this.chkBySegments.AutoSize = true;
            this.chkBySegments.Dock = System.Windows.Forms.DockStyle.Left;
            this.chkBySegments.ForeColor = System.Drawing.Color.DarkCyan;
            this.chkBySegments.Location = new System.Drawing.Point(3, 3);
            this.chkBySegments.Name = "chkBySegments";
            this.chkBySegments.Size = new System.Drawing.Size(96, 20);
            this.chkBySegments.TabIndex = 16;
            this.chkBySegments.Text = "Por segmentos";
            this.chkBySegments.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkBySegments.UseVisualStyleBackColor = true;
            this.chkBySegments.CheckedChanged += new System.EventHandler(this.chkBySegments_CheckedChanged);
            this.chkBySegments.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // txtSegment5
            // 
            this.txtSegment5.AllowBlankSpaces = false;
            this.txtSegment5.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtSegment5.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.OnlyNumbers;
            this.txtSegment5.CustomExpression = ".*";
            this.txtSegment5.Dock = System.Windows.Forms.DockStyle.Left;
            this.txtSegment5.EnterColor = System.Drawing.Color.Empty;
            this.txtSegment5.LeaveColor = System.Drawing.Color.Empty;
            this.txtSegment5.Location = new System.Drawing.Point(305, 3);
            this.txtSegment5.MaxLength = 2;
            this.txtSegment5.Name = "txtSegment5";
            this.txtSegment5.Size = new System.Drawing.Size(25, 20);
            this.txtSegment5.TabIndex = 20;
            this.txtSegment5.TextChanged += new System.EventHandler(this.txtSegment5_TextChanged);
            this.txtSegment5.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // txtSegment4
            // 
            this.txtSegment4.AllowBlankSpaces = false;
            this.txtSegment4.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtSegment4.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.OnlyNumbers;
            this.txtSegment4.CustomExpression = ".*";
            this.txtSegment4.Dock = System.Windows.Forms.DockStyle.Left;
            this.txtSegment4.EnterColor = System.Drawing.Color.Empty;
            this.txtSegment4.LeaveColor = System.Drawing.Color.Empty;
            this.txtSegment4.Location = new System.Drawing.Point(254, 3);
            this.txtSegment4.MaxLength = 2;
            this.txtSegment4.Name = "txtSegment4";
            this.txtSegment4.Size = new System.Drawing.Size(25, 20);
            this.txtSegment4.TabIndex = 19;
            this.txtSegment4.TextChanged += new System.EventHandler(this.txtSegment4_TextChanged);
            this.txtSegment4.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // tblLayoutCorporateId
            // 
            this.tblLayoutCorporateId.ColumnCount = 4;
            this.tblLayoutCorporateId.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblLayoutCorporateId.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 39F));
            this.tblLayoutCorporateId.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 136F));
            this.tblLayoutCorporateId.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 105F));
            this.tblLayoutCorporateId.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tblLayoutCorporateId.Controls.Add(this.lbl18, 0, 0);
            this.tblLayoutCorporateId.Controls.Add(this.lbl21, 1, 0);
            this.tblLayoutCorporateId.Controls.Add(this.txtCorporateId, 2, 0);
            this.tblLayoutCorporateId.Controls.Add(this.chkXC, 3, 0);
            this.tblLayoutCorporateId.Location = new System.Drawing.Point(18, 464);
            this.tblLayoutCorporateId.Margin = new System.Windows.Forms.Padding(0);
            this.tblLayoutCorporateId.Name = "tblLayoutCorporateId";
            this.tblLayoutCorporateId.RowCount = 1;
            this.tblLayoutCorporateId.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblLayoutCorporateId.Size = new System.Drawing.Size(385, 26);
            this.tblLayoutCorporateId.TabIndex = 32;
            // 
            // lbl18
            // 
            this.lbl18.AutoSize = true;
            this.lbl18.Dock = System.Windows.Forms.DockStyle.Left;
            this.lbl18.ForeColor = System.Drawing.Color.DarkCyan;
            this.lbl18.Location = new System.Drawing.Point(3, 0);
            this.lbl18.Name = "lbl18";
            this.lbl18.Size = new System.Drawing.Size(70, 26);
            this.lbl18.TabIndex = 0;
            this.lbl18.Text = "Corporate ID:";
            this.lbl18.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl21
            // 
            this.lbl21.AutoSize = true;
            this.lbl21.Dock = System.Windows.Forms.DockStyle.Left;
            this.lbl21.ForeColor = System.Drawing.Color.Blue;
            this.lbl21.Location = new System.Drawing.Point(108, 0);
            this.lbl21.Name = "lbl21";
            this.lbl21.Size = new System.Drawing.Size(16, 26);
            this.lbl21.TabIndex = 1;
            this.lbl21.Text = "¥I";
            this.lbl21.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtCorporateId
            // 
            this.txtCorporateId.AllowBlankSpaces = false;
            this.txtCorporateId.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtCorporateId.CharsNoIncluded = new char[] {
        ' '};
            this.txtCorporateId.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.NumbersOrLetters;
            this.txtCorporateId.CustomExpression = ".*";
            this.txtCorporateId.Dock = System.Windows.Forms.DockStyle.Left;
            this.txtCorporateId.EnterColor = System.Drawing.Color.Empty;
            this.txtCorporateId.LeaveColor = System.Drawing.Color.Empty;
            this.txtCorporateId.Location = new System.Drawing.Point(147, 3);
            this.txtCorporateId.MaxLength = 5;
            this.txtCorporateId.Name = "txtCorporateId";
            this.txtCorporateId.Size = new System.Drawing.Size(60, 20);
            this.txtCorporateId.TabIndex = 33;
            this.txtCorporateId.TextChanged += new System.EventHandler(this.txtCorporateId_TextChanged);
            this.txtCorporateId.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // chkXC
            // 
            this.chkXC.AutoSize = true;
            this.chkXC.ForeColor = System.Drawing.Color.DarkCyan;
            this.chkXC.Location = new System.Drawing.Point(283, 3);
            this.chkXC.Name = "chkXC";
            this.chkXC.Size = new System.Drawing.Size(46, 17);
            this.chkXC.TabIndex = 131;
            this.chkXC.Text = "¥XC";
            this.chkXC.UseVisualStyleBackColor = true;
            // 
            // tblLayoutAccountCode
            // 
            this.tblLayoutAccountCode.ColumnCount = 3;
            this.tblLayoutAccountCode.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 72.91666F));
            this.tblLayoutAccountCode.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 27.08333F));
            this.tblLayoutAccountCode.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 241F));
            this.tblLayoutAccountCode.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tblLayoutAccountCode.Controls.Add(this.lbl19, 0, 0);
            this.tblLayoutAccountCode.Controls.Add(this.lbl20, 1, 0);
            this.tblLayoutAccountCode.Controls.Add(this.txtAccountCode, 2, 0);
            this.tblLayoutAccountCode.Location = new System.Drawing.Point(18, 490);
            this.tblLayoutAccountCode.Margin = new System.Windows.Forms.Padding(0);
            this.tblLayoutAccountCode.Name = "tblLayoutAccountCode";
            this.tblLayoutAccountCode.RowCount = 1;
            this.tblLayoutAccountCode.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblLayoutAccountCode.Size = new System.Drawing.Size(385, 27);
            this.tblLayoutAccountCode.TabIndex = 34;
            // 
            // lbl19
            // 
            this.lbl19.AutoSize = true;
            this.lbl19.Dock = System.Windows.Forms.DockStyle.Left;
            this.lbl19.ForeColor = System.Drawing.Color.DarkCyan;
            this.lbl19.Location = new System.Drawing.Point(3, 0);
            this.lbl19.Name = "lbl19";
            this.lbl19.Size = new System.Drawing.Size(78, 27);
            this.lbl19.TabIndex = 0;
            this.lbl19.Text = "Account Code:";
            this.lbl19.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl20
            // 
            this.lbl20.AutoSize = true;
            this.lbl20.Dock = System.Windows.Forms.DockStyle.Left;
            this.lbl20.ForeColor = System.Drawing.Color.Blue;
            this.lbl20.Location = new System.Drawing.Point(108, 0);
            this.lbl20.Name = "lbl20";
            this.lbl20.Size = new System.Drawing.Size(31, 27);
            this.lbl20.TabIndex = 1;
            this.lbl20.Text = "¥AC*";
            this.lbl20.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtAccountCode
            // 
            this.txtAccountCode.AllowBlankSpaces = false;
            this.txtAccountCode.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtAccountCode.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.NumbersOrLetters;
            this.txtAccountCode.CustomExpression = ".*";
            this.txtAccountCode.Dock = System.Windows.Forms.DockStyle.Left;
            this.txtAccountCode.EnterColor = System.Drawing.Color.Empty;
            this.txtAccountCode.LeaveColor = System.Drawing.Color.Empty;
            this.txtAccountCode.Location = new System.Drawing.Point(147, 3);
            this.txtAccountCode.MaxLength = 15;
            this.txtAccountCode.Name = "txtAccountCode";
            this.txtAccountCode.Size = new System.Drawing.Size(134, 20);
            this.txtAccountCode.TabIndex = 35;
            this.txtAccountCode.TextChanged += new System.EventHandler(this.txtAccountCode_TextChanged);
            this.txtAccountCode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 27.01299F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 72.98701F));
            this.tableLayoutPanel1.Controls.Add(this.chkPassType, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.cmbPassType, 1, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(18, 437);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(385, 27);
            this.tableLayoutPanel1.TabIndex = 28;
            // 
            // chkPassType
            // 
            this.chkPassType.AutoSize = true;
            this.chkPassType.Dock = System.Windows.Forms.DockStyle.Left;
            this.chkPassType.ForeColor = System.Drawing.Color.DarkCyan;
            this.chkPassType.Location = new System.Drawing.Point(3, 3);
            this.chkPassType.Name = "chkPassType";
            this.chkPassType.Size = new System.Drawing.Size(97, 21);
            this.chkPassType.TabIndex = 24;
            this.chkPassType.Text = "Por tarifa o pax";
            this.chkPassType.UseVisualStyleBackColor = true;
            this.chkPassType.CheckedChanged += new System.EventHandler(this.chkPassType_CheckedChanged);
            this.chkPassType.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // cmbPassType
            // 
            this.cmbPassType.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cmbPassType.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbPassType.Dock = System.Windows.Forms.DockStyle.Left;
            this.cmbPassType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPassType.FormattingEnabled = true;
            this.cmbPassType.Items.AddRange(new object[] {
            "Selecciona tipo de tarifa o tipo de pasajero:",
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
            this.cmbPassType.Location = new System.Drawing.Point(107, 3);
            this.cmbPassType.MaxLength = 6;
            this.cmbPassType.Name = "cmbPassType";
            this.cmbPassType.Size = new System.Drawing.Size(275, 21);
            this.cmbPassType.TabIndex = 25;
            this.cmbPassType.SelectedIndexChanged += new System.EventHandler(this.cmbPassType_SelectedIndexChanged_1);
            this.cmbPassType.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // tblLayoutAccept
            // 
            this.tblLayoutAccept.ColumnCount = 4;
            this.tblLayoutAccept.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 44F));
            this.tblLayoutAccept.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 67F));
            this.tblLayoutAccept.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 167F));
            this.tblLayoutAccept.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 154F));
            this.tblLayoutAccept.Controls.Add(this.lbl17, 0, 0);
            this.tblLayoutAccept.Controls.Add(this.chkPublic, 1, 0);
            this.tblLayoutAccept.Controls.Add(this.chkPrivate, 2, 0);
            this.tblLayoutAccept.Controls.Add(this.btnAccept, 3, 1);
            this.tblLayoutAccept.Location = new System.Drawing.Point(18, 517);
            this.tblLayoutAccept.Margin = new System.Windows.Forms.Padding(0);
            this.tblLayoutAccept.Name = "tblLayoutAccept";
            this.tblLayoutAccept.RowCount = 2;
            this.tblLayoutAccept.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblLayoutAccept.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.tblLayoutAccept.Size = new System.Drawing.Size(385, 56);
            this.tblLayoutAccept.TabIndex = 36;
            // 
            // lbl17
            // 
            this.lbl17.AutoSize = true;
            this.lbl17.Dock = System.Windows.Forms.DockStyle.Left;
            this.lbl17.ForeColor = System.Drawing.Color.DarkCyan;
            this.lbl17.Location = new System.Drawing.Point(3, 0);
            this.lbl17.Name = "lbl17";
            this.lbl17.Size = new System.Drawing.Size(37, 27);
            this.lbl17.TabIndex = 2;
            this.lbl17.Text = "Tarifa:";
            this.lbl17.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // chkPublic
            // 
            this.chkPublic.AutoSize = true;
            this.chkPublic.Dock = System.Windows.Forms.DockStyle.Left;
            this.chkPublic.ForeColor = System.Drawing.Color.Black;
            this.chkPublic.Location = new System.Drawing.Point(47, 3);
            this.chkPublic.Name = "chkPublic";
            this.chkPublic.Size = new System.Drawing.Size(61, 21);
            this.chkPublic.TabIndex = 37;
            this.chkPublic.Text = "Publica";
            this.chkPublic.UseVisualStyleBackColor = true;
            this.chkPublic.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // chkPrivate
            // 
            this.chkPrivate.AutoSize = true;
            this.chkPrivate.Dock = System.Windows.Forms.DockStyle.Left;
            this.chkPrivate.ForeColor = System.Drawing.Color.Black;
            this.chkPrivate.Location = new System.Drawing.Point(114, 3);
            this.chkPrivate.Name = "chkPrivate";
            this.chkPrivate.Size = new System.Drawing.Size(62, 21);
            this.chkPrivate.TabIndex = 38;
            this.chkPrivate.Text = "Privada";
            this.chkPrivate.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkPrivate.UseVisualStyleBackColor = true;
            this.chkPrivate.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // btnAccept
            // 
            this.btnAccept.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnAccept.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAccept.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnAccept.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAccept.Location = new System.Drawing.Point(281, 30);
            this.btnAccept.Name = "btnAccept";
            this.btnAccept.Size = new System.Drawing.Size(100, 23);
            this.btnAccept.TabIndex = 40;
            this.btnAccept.Text = "Aceptar";
            this.btnAccept.UseVisualStyleBackColor = false;
            this.btnAccept.Click += new System.EventHandler(this.btn1_Click);
            // 
            // ucAirRate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.tblLayoutAccept);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.tblLayoutCorporateId);
            this.Controls.Add(this.tblLayoutAccountCode);
            this.Controls.Add(this.tblLayoutPassPosition);
            this.Controls.Add(this.tblLayoutBySegments);
            this.Controls.Add(this.lbl5);
            this.Controls.Add(this.lbl16);
            this.Controls.Add(this.txtMoneyCode);
            this.Controls.Add(this.cmbAirline);
            this.Controls.Add(this.lbl1);
            this.Controls.Add(this.rdoQuoItinerary);
            this.Controls.Add(this.rdoSellOtherFly);
            this.Controls.Add(this.rdoSaveRate);
            this.Controls.Add(this.rdoQuoCheapBut);
            this.Controls.Add(this.rdoQuoCheapNonavailable);
            this.Controls.Add(this.rdoChangeToMostCheap);
            this.Controls.Add(this.rdoSearchFlights);
            this.Controls.Add(this.rdoManualRate);
            this.Controls.Add(this.rdoRateOptions);
            this.Controls.Add(this.rdoBuildQuaDisplayed);
            this.Controls.Add(this.rdoQuaWeb);
            this.Controls.Add(this.rdoPhase35375);
            this.Controls.Add(this.lbl2);
            this.Controls.Add(this.lbl3);
            this.Controls.Add(this.lbl4);
            this.Controls.Add(this.lbl7);
            this.Controls.Add(this.lbl10);
            this.Controls.Add(this.lbl11);
            this.Controls.Add(this.lbl12);
            this.Controls.Add(this.lbl13);
            this.Controls.Add(this.lbl14);
            this.Controls.Add(this.lbl15);
            this.Controls.Add(this.tblLayoutMain);
            this.Controls.Add(this.lbMoneyCode);
            this.ForeColor = System.Drawing.Color.Black;
            this.Name = "ucAirRate";
            this.Size = new System.Drawing.Size(411, 580);
            this.Load += new System.EventHandler(this.ucAirRate_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            this.tblLayoutMain.ResumeLayout(false);
            this.tblLayoutPassPosition.ResumeLayout(false);
            this.tblLayoutPassPosition.PerformLayout();
            this.tblLayoutBySegments.ResumeLayout(false);
            this.tblLayoutBySegments.PerformLayout();
            this.tblLayoutCorporateId.ResumeLayout(false);
            this.tblLayoutCorporateId.PerformLayout();
            this.tblLayoutAccountCode.ResumeLayout(false);
            this.tblLayoutAccountCode.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tblLayoutAccept.ResumeLayout(false);
            this.tblLayoutAccept.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.BindingSource bindingSource1;
        private System.Windows.Forms.Timer timer1;
        internal System.Windows.Forms.Label lblTitle;
        internal System.Windows.Forms.TableLayoutPanel tblLayoutMain;
        private System.Windows.Forms.Label lbl5;
        private MyCTS.Forms.UI.SmartTextBox txtSegment6;
        private System.Windows.Forms.ComboBox cmbAirline;
        private System.Windows.Forms.Label lbl1;
        private System.Windows.Forms.RadioButton rdoQuoItinerary;
        private System.Windows.Forms.RadioButton rdoSellOtherFly;
        private System.Windows.Forms.RadioButton rdoSaveRate;
        private System.Windows.Forms.RadioButton rdoQuoCheapBut;
        private System.Windows.Forms.RadioButton rdoQuoCheapNonavailable;
        private System.Windows.Forms.RadioButton rdoChangeToMostCheap;
        private System.Windows.Forms.RadioButton rdoSearchFlights;
        private System.Windows.Forms.RadioButton rdoManualRate;
        private System.Windows.Forms.RadioButton rdoRateOptions;
        private System.Windows.Forms.RadioButton rdoBuildQuaDisplayed;
        private System.Windows.Forms.RadioButton rdoQuaWeb;
        private System.Windows.Forms.RadioButton rdoPhase35375;
        private System.Windows.Forms.Label lbl2;
        private System.Windows.Forms.Label lbl3;
        private System.Windows.Forms.Label lbl4;
        private System.Windows.Forms.Label lbl7;
        private System.Windows.Forms.Label lbl10;
        private System.Windows.Forms.Label lbl11;
        private System.Windows.Forms.Label lbl12;
        private System.Windows.Forms.Label lbl13;
        private System.Windows.Forms.Label lbl14;
        private System.Windows.Forms.Label lbl15;
        private System.Windows.Forms.ListBox lbMoneyCode;
        private MyCTS.Forms.UI.SmartTextBox txtMoneyCode;
        private System.Windows.Forms.Label lbl16;
        private System.Windows.Forms.TableLayoutPanel tblLayoutPassPosition;
        private MyCTS.Forms.UI.SmartTextBox txtPassenger1;
        private System.Windows.Forms.Label lbl8;
        private MyCTS.Forms.UI.SmartTextBox txtPassenger2;
        private System.Windows.Forms.Label lbl9;
        private MyCTS.Forms.UI.SmartTextBox txtPassenger3;
        private MyCTS.Forms.UI.SmartTextBox txtPassenger4;
        private System.Windows.Forms.CheckBox chkPassPosition;
        private System.Windows.Forms.TableLayoutPanel tblLayoutBySegments;
        private MyCTS.Forms.UI.SmartTextBox txtSegment1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbl6;
        private MyCTS.Forms.UI.SmartTextBox txtSegment3;
        private MyCTS.Forms.UI.SmartTextBox txtSegment4;
        private MyCTS.Forms.UI.SmartTextBox txtSegment5;
        private MyCTS.Forms.UI.SmartTextBox txtSegment2;
        private System.Windows.Forms.CheckBox chkBySegments;
        private System.Windows.Forms.TableLayoutPanel tblLayoutCorporateId;
        private System.Windows.Forms.Label lbl18;
        private System.Windows.Forms.Label lbl21;
        private MyCTS.Forms.UI.SmartTextBox txtCorporateId;
        private System.Windows.Forms.TableLayoutPanel tblLayoutAccountCode;
        private System.Windows.Forms.Label lbl19;
        private System.Windows.Forms.Label lbl20;
        private MyCTS.Forms.UI.SmartTextBox txtAccountCode;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.CheckBox chkPassType;
        private System.Windows.Forms.ComboBox cmbPassType;
        private System.Windows.Forms.TableLayoutPanel tblLayoutAccept;
        private System.Windows.Forms.Label lbl17;
        private System.Windows.Forms.CheckBox chkPublic;
        private System.Windows.Forms.CheckBox chkPrivate;
        private System.Windows.Forms.Button btnAccept;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox chkXC;

    }
}
