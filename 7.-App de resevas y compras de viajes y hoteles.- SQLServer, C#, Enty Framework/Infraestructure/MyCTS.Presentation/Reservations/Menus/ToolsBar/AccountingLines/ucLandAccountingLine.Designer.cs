namespace MyCTS.Presentation
{
    partial class ucLandAccountingLine
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
            this.rdoHotel = new System.Windows.Forms.RadioButton();
            this.rdoTour = new System.Windows.Forms.RadioButton();
            this.rdoAuto = new System.Windows.Forms.RadioButton();
            this.rdoCruise = new System.Windows.Forms.RadioButton();
            this.rdoOthers = new System.Windows.Forms.RadioButton();
            this.rdoBus = new System.Windows.Forms.RadioButton();
            this.rdoInsurance = new System.Windows.Forms.RadioButton();
            this.rdoTrain = new System.Windows.Forms.RadioButton();
            this.lblSegment = new System.Windows.Forms.Label();
            this.txtSegment = new MyCTS.Forms.UI.SmartTextBox();
            this.lblTypeInvoice = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.rdoTotalPay = new System.Windows.Forms.RadioButton();
            this.rdoVoucher = new System.Windows.Forms.RadioButton();
            this.rdoDeposit = new System.Windows.Forms.RadioButton();
            this.rdoFinalPay = new System.Windows.Forms.RadioButton();
            this.lblNumVoucher = new System.Windows.Forms.Label();
            this.txtNumVoucher = new MyCTS.Forms.UI.SmartTextBox();
            this.lblOtherTaxes = new System.Windows.Forms.Label();
            this.lblIva = new System.Windows.Forms.Label();
            this.lblBasisFare = new System.Windows.Forms.Label();
            this.txtIVA = new MyCTS.Forms.UI.SmartTextBox();
            this.txtOtherTaxes = new MyCTS.Forms.UI.SmartTextBox();
            this.txtBasisFare = new MyCTS.Forms.UI.SmartTextBox();
            this.lblCommision = new System.Windows.Forms.Label();
            this.txtCommision = new MyCTS.Forms.UI.SmartTextBox();
            this.lblAplication = new System.Windows.Forms.Label();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.rdoOne = new System.Windows.Forms.RadioButton();
            this.rdoALL = new System.Windows.Forms.RadioButton();
            this.rdoPER = new System.Windows.Forms.RadioButton();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.rdoCC = new System.Windows.Forms.RadioButton();
            this.rdoCX = new System.Windows.Forms.RadioButton();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.rdoCC2 = new System.Windows.Forms.RadioButton();
            this.rdoCA = new System.Windows.Forms.RadioButton();
            this.lblFormPay = new System.Windows.Forms.Label();
            this.lblNumberCard = new System.Windows.Forms.Label();
            this.lblCardCode = new System.Windows.Forms.Label();
            this.txtNumberCard = new MyCTS.Forms.UI.SmartTextBox();
            this.txtCardCode = new MyCTS.Forms.UI.SmartTextBox();
            this.lblInicialName = new System.Windows.Forms.Label();
            this.lblLastname = new System.Windows.Forms.Label();
            this.txtInicialName = new MyCTS.Forms.UI.SmartTextBox();
            this.txtLastname = new MyCTS.Forms.UI.SmartTextBox();
            this.txtNumDoctos = new MyCTS.Forms.UI.SmartTextBox();
            this.txtPaxNumber = new MyCTS.Forms.UI.SmartTextBox();
            this.lblNumDoctos = new System.Windows.Forms.Label();
            this.lblPaxNumber = new System.Windows.Forms.Label();
            this.lblInfo = new System.Windows.Forms.Label();
            this.lbCardCode = new System.Windows.Forms.ListBox();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(139)))), ((int)(((byte)(208)))));
            this.lblTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(0, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(411, 16);
            this.lblTitle.TabIndex = 1;
            this.lblTitle.Text = "Línea Contable Terrestre";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnAccept
            // 
            this.btnAccept.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnAccept.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAccept.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAccept.Location = new System.Drawing.Point(276, 542);
            this.btnAccept.Name = "btnAccept";
            this.btnAccept.Size = new System.Drawing.Size(100, 23);
            this.btnAccept.TabIndex = 30;
            this.btnAccept.Text = "Aceptar";
            this.btnAccept.UseVisualStyleBackColor = false;
            this.btnAccept.Click += new System.EventHandler(this.btnAccept_Click);
            // 
            // rdoHotel
            // 
            this.rdoHotel.AutoSize = true;
            this.rdoHotel.Location = new System.Drawing.Point(30, 53);
            this.rdoHotel.Name = "rdoHotel";
            this.rdoHotel.Size = new System.Drawing.Size(50, 17);
            this.rdoHotel.TabIndex = 1;
            this.rdoHotel.TabStop = true;
            this.rdoHotel.Text = "Hotel";
            this.rdoHotel.UseVisualStyleBackColor = true;
            this.rdoHotel.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // rdoTour
            // 
            this.rdoTour.AutoSize = true;
            this.rdoTour.Location = new System.Drawing.Point(127, 53);
            this.rdoTour.Name = "rdoTour";
            this.rdoTour.Size = new System.Drawing.Size(47, 17);
            this.rdoTour.TabIndex = 2;
            this.rdoTour.TabStop = true;
            this.rdoTour.Text = "Tour";
            this.rdoTour.UseVisualStyleBackColor = true;
            this.rdoTour.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // rdoAuto
            // 
            this.rdoAuto.AutoSize = true;
            this.rdoAuto.Location = new System.Drawing.Point(30, 76);
            this.rdoAuto.Name = "rdoAuto";
            this.rdoAuto.Size = new System.Drawing.Size(47, 17);
            this.rdoAuto.TabIndex = 3;
            this.rdoAuto.TabStop = true;
            this.rdoAuto.Text = "Auto";
            this.rdoAuto.UseVisualStyleBackColor = true;
            this.rdoAuto.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // rdoCruise
            // 
            this.rdoCruise.AutoSize = true;
            this.rdoCruise.Location = new System.Drawing.Point(127, 76);
            this.rdoCruise.Name = "rdoCruise";
            this.rdoCruise.Size = new System.Drawing.Size(61, 17);
            this.rdoCruise.TabIndex = 4;
            this.rdoCruise.TabStop = true;
            this.rdoCruise.Text = "Cruzero";
            this.rdoCruise.UseVisualStyleBackColor = true;
            this.rdoCruise.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // rdoOthers
            // 
            this.rdoOthers.AutoSize = true;
            this.rdoOthers.Location = new System.Drawing.Point(30, 99);
            this.rdoOthers.Name = "rdoOthers";
            this.rdoOthers.Size = new System.Drawing.Size(50, 17);
            this.rdoOthers.TabIndex = 5;
            this.rdoOthers.TabStop = true;
            this.rdoOthers.Text = "Otros";
            this.rdoOthers.UseVisualStyleBackColor = true;
            this.rdoOthers.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // rdoBus
            // 
            this.rdoBus.AutoSize = true;
            this.rdoBus.Location = new System.Drawing.Point(127, 99);
            this.rdoBus.Name = "rdoBus";
            this.rdoBus.Size = new System.Drawing.Size(64, 17);
            this.rdoBus.TabIndex = 6;
            this.rdoBus.TabStop = true;
            this.rdoBus.Text = "Autobus";
            this.rdoBus.UseVisualStyleBackColor = true;
            this.rdoBus.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // rdoInsurance
            // 
            this.rdoInsurance.AutoSize = true;
            this.rdoInsurance.Location = new System.Drawing.Point(30, 122);
            this.rdoInsurance.Name = "rdoInsurance";
            this.rdoInsurance.Size = new System.Drawing.Size(64, 17);
            this.rdoInsurance.TabIndex = 7;
            this.rdoInsurance.TabStop = true;
            this.rdoInsurance.Text = "Seguros";
            this.rdoInsurance.UseVisualStyleBackColor = true;
            this.rdoInsurance.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // rdoTrain
            // 
            this.rdoTrain.AutoSize = true;
            this.rdoTrain.Location = new System.Drawing.Point(127, 122);
            this.rdoTrain.Name = "rdoTrain";
            this.rdoTrain.Size = new System.Drawing.Size(47, 17);
            this.rdoTrain.TabIndex = 8;
            this.rdoTrain.TabStop = true;
            this.rdoTrain.Text = "Tren";
            this.rdoTrain.UseVisualStyleBackColor = true;
            this.rdoTrain.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // lblSegment
            // 
            this.lblSegment.AutoSize = true;
            this.lblSegment.Location = new System.Drawing.Point(51, 148);
            this.lblSegment.Name = "lblSegment";
            this.lblSegment.Size = new System.Drawing.Size(58, 13);
            this.lblSegment.TabIndex = 41;
            this.lblSegment.Text = "Segmento:";
            // 
            // txtSegment
            // 
            this.txtSegment.AllowBlankSpaces = false;
            this.txtSegment.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtSegment.CharsIncluded = new char[0];
            this.txtSegment.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.OnlyNumbers;
            this.txtSegment.CustomExpression = ".*";
            this.txtSegment.EnterColor = System.Drawing.Color.Empty;
            this.txtSegment.LeaveColor = System.Drawing.Color.Empty;
            this.txtSegment.Location = new System.Drawing.Point(127, 145);
            this.txtSegment.MaxLength = 2;
            this.txtSegment.Name = "txtSegment";
            this.txtSegment.Size = new System.Drawing.Size(47, 20);
            this.txtSegment.TabIndex = 9;
            this.txtSegment.TextChanged += new System.EventHandler(this.txtPaxNumber_TextChanged);
            this.txtSegment.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // lblTypeInvoice
            // 
            this.lblTypeInvoice.AutoSize = true;
            this.lblTypeInvoice.Location = new System.Drawing.Point(27, 179);
            this.lblTypeInvoice.Name = "lblTypeInvoice";
            this.lblTypeInvoice.Size = new System.Drawing.Size(70, 13);
            this.lblTypeInvoice.TabIndex = 41;
            this.lblTypeInvoice.Text = "Tipo Factura:";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 54.16667F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 45.83333F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 79F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 65F));
            this.tableLayoutPanel1.Controls.Add(this.rdoTotalPay, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.rdoVoucher, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.rdoDeposit, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.rdoFinalPay, 3, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(116, 165);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(283, 40);
            this.tableLayoutPanel1.TabIndex = 10;
            this.tableLayoutPanel1.TabStop = true;
            // 
            // rdoTotalPay
            // 
            this.rdoTotalPay.Location = new System.Drawing.Point(78, 3);
            this.rdoTotalPay.Name = "rdoTotalPay";
            this.rdoTotalPay.Size = new System.Drawing.Size(54, 34);
            this.rdoTotalPay.TabIndex = 11;
            this.rdoTotalPay.TabStop = true;
            this.rdoTotalPay.Text = "Pago Total";
            this.rdoTotalPay.UseVisualStyleBackColor = true;
            this.rdoTotalPay.CheckedChanged += new System.EventHandler(this.rdoVoucher_CheckedChanged);
            this.rdoTotalPay.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // rdoVoucher
            // 
            this.rdoVoucher.Location = new System.Drawing.Point(3, 3);
            this.rdoVoucher.Name = "rdoVoucher";
            this.rdoVoucher.Size = new System.Drawing.Size(69, 34);
            this.rdoVoucher.TabIndex = 10;
            this.rdoVoucher.TabStop = true;
            this.rdoVoucher.Text = "Voucher";
            this.rdoVoucher.UseVisualStyleBackColor = true;
            this.rdoVoucher.CheckedChanged += new System.EventHandler(this.rdoVoucher_CheckedChanged);
            this.rdoVoucher.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // rdoDeposit
            // 
            this.rdoDeposit.Location = new System.Drawing.Point(141, 3);
            this.rdoDeposit.Name = "rdoDeposit";
            this.rdoDeposit.Size = new System.Drawing.Size(67, 34);
            this.rdoDeposit.TabIndex = 12;
            this.rdoDeposit.TabStop = true;
            this.rdoDeposit.Text = "Deposito";
            this.rdoDeposit.UseVisualStyleBackColor = true;
            this.rdoDeposit.CheckedChanged += new System.EventHandler(this.rdoVoucher_CheckedChanged);
            this.rdoDeposit.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // rdoFinalPay
            // 
            this.rdoFinalPay.Location = new System.Drawing.Point(220, 3);
            this.rdoFinalPay.Name = "rdoFinalPay";
            this.rdoFinalPay.Size = new System.Drawing.Size(52, 34);
            this.rdoFinalPay.TabIndex = 13;
            this.rdoFinalPay.TabStop = true;
            this.rdoFinalPay.Text = "Pago Final";
            this.rdoFinalPay.UseVisualStyleBackColor = true;
            this.rdoFinalPay.CheckedChanged += new System.EventHandler(this.rdoVoucher_CheckedChanged);
            this.rdoFinalPay.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // lblNumVoucher
            // 
            this.lblNumVoucher.AutoSize = true;
            this.lblNumVoucher.Location = new System.Drawing.Point(51, 214);
            this.lblNumVoucher.Name = "lblNumVoucher";
            this.lblNumVoucher.Size = new System.Drawing.Size(70, 13);
            this.lblNumVoucher.TabIndex = 42;
            this.lblNumVoucher.Text = "No. Voucher:";
            // 
            // txtNumVoucher
            // 
            this.txtNumVoucher.AllowBlankSpaces = false;
            this.txtNumVoucher.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtNumVoucher.CharsIncluded = new char[0];
            this.txtNumVoucher.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.OnlyNumbers;
            this.txtNumVoucher.CustomExpression = ".*";
            this.txtNumVoucher.Enabled = false;
            this.txtNumVoucher.EnterColor = System.Drawing.Color.Empty;
            this.txtNumVoucher.LeaveColor = System.Drawing.Color.Empty;
            this.txtNumVoucher.Location = new System.Drawing.Point(127, 211);
            this.txtNumVoucher.MaxLength = 5;
            this.txtNumVoucher.Name = "txtNumVoucher";
            this.txtNumVoucher.Size = new System.Drawing.Size(72, 20);
            this.txtNumVoucher.TabIndex = 14;
            this.txtNumVoucher.TextChanged += new System.EventHandler(this.txtPaxNumber_TextChanged);
            this.txtNumVoucher.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // lblOtherTaxes
            // 
            this.lblOtherTaxes.AutoSize = true;
            this.lblOtherTaxes.ForeColor = System.Drawing.Color.DarkCyan;
            this.lblOtherTaxes.Location = new System.Drawing.Point(22, 292);
            this.lblOtherTaxes.Name = "lblOtherTaxes";
            this.lblOtherTaxes.Size = new System.Drawing.Size(81, 13);
            this.lblOtherTaxes.TabIndex = 44;
            this.lblOtherTaxes.Text = "Otros Imp. (Intl):";
            // 
            // lblIva
            // 
            this.lblIva.AutoSize = true;
            this.lblIva.Location = new System.Drawing.Point(22, 266);
            this.lblIva.Name = "lblIva";
            this.lblIva.Size = new System.Drawing.Size(27, 13);
            this.lblIva.TabIndex = 43;
            this.lblIva.Text = "IVA:";
            // 
            // lblBasisFare
            // 
            this.lblBasisFare.AutoSize = true;
            this.lblBasisFare.Location = new System.Drawing.Point(22, 240);
            this.lblBasisFare.Name = "lblBasisFare";
            this.lblBasisFare.Size = new System.Drawing.Size(64, 13);
            this.lblBasisFare.TabIndex = 45;
            this.lblBasisFare.Text = "Tarifa Base:";
            // 
            // txtIVA
            // 
            this.txtIVA.AllowBlankSpaces = false;
            this.txtIVA.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtIVA.CharsIncluded = new char[] {
        '.'};
            this.txtIVA.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.OnlyNumbers;
            this.txtIVA.CustomExpression = ".*";
            this.txtIVA.EnterColor = System.Drawing.Color.Empty;
            this.txtIVA.LeaveColor = System.Drawing.Color.Empty;
            this.txtIVA.Location = new System.Drawing.Point(127, 263);
            this.txtIVA.MaxLength = 7;
            this.txtIVA.Name = "txtIVA";
            this.txtIVA.Size = new System.Drawing.Size(76, 20);
            this.txtIVA.TabIndex = 16;
            this.txtIVA.Text = "0.00";
            this.txtIVA.TextChanged += new System.EventHandler(this.txtPaxNumber_TextChanged);
            this.txtIVA.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // txtOtherTaxes
            // 
            this.txtOtherTaxes.AllowBlankSpaces = false;
            this.txtOtherTaxes.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtOtherTaxes.CharsIncluded = new char[] {
        '.'};
            this.txtOtherTaxes.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.OnlyNumbers;
            this.txtOtherTaxes.CustomExpression = ".*";
            this.txtOtherTaxes.EnterColor = System.Drawing.Color.Empty;
            this.txtOtherTaxes.LeaveColor = System.Drawing.Color.Empty;
            this.txtOtherTaxes.Location = new System.Drawing.Point(127, 289);
            this.txtOtherTaxes.MaxLength = 8;
            this.txtOtherTaxes.Name = "txtOtherTaxes";
            this.txtOtherTaxes.Size = new System.Drawing.Size(90, 20);
            this.txtOtherTaxes.TabIndex = 17;
            this.txtOtherTaxes.Text = "0.00";
            this.txtOtherTaxes.TextChanged += new System.EventHandler(this.txtPaxNumber_TextChanged);
            this.txtOtherTaxes.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // txtBasisFare
            // 
            this.txtBasisFare.AllowBlankSpaces = false;
            this.txtBasisFare.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtBasisFare.CharsIncluded = new char[] {
        '.'};
            this.txtBasisFare.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.OnlyNumbers;
            this.txtBasisFare.CustomExpression = ".*";
            this.txtBasisFare.EnterColor = System.Drawing.Color.Empty;
            this.txtBasisFare.LeaveColor = System.Drawing.Color.Empty;
            this.txtBasisFare.Location = new System.Drawing.Point(127, 237);
            this.txtBasisFare.MaxLength = 8;
            this.txtBasisFare.Name = "txtBasisFare";
            this.txtBasisFare.Size = new System.Drawing.Size(90, 20);
            this.txtBasisFare.TabIndex = 15;
            this.txtBasisFare.Text = "0.00";
            this.txtBasisFare.TextChanged += new System.EventHandler(this.txtPaxNumber_TextChanged);
            this.txtBasisFare.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // lblCommision
            // 
            this.lblCommision.AutoSize = true;
            this.lblCommision.Location = new System.Drawing.Point(22, 318);
            this.lblCommision.Name = "lblCommision";
            this.lblCommision.Size = new System.Drawing.Size(78, 13);
            this.lblCommision.TabIndex = 50;
            this.lblCommision.Text = "% de Comisión:";
            // 
            // txtCommision
            // 
            this.txtCommision.AllowBlankSpaces = false;
            this.txtCommision.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtCommision.CharsIncluded = new char[0];
            this.txtCommision.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.OnlyNumbers;
            this.txtCommision.CustomExpression = ".*";
            this.txtCommision.EnterColor = System.Drawing.Color.Empty;
            this.txtCommision.LeaveColor = System.Drawing.Color.Empty;
            this.txtCommision.Location = new System.Drawing.Point(127, 315);
            this.txtCommision.MaxLength = 3;
            this.txtCommision.Name = "txtCommision";
            this.txtCommision.Size = new System.Drawing.Size(46, 20);
            this.txtCommision.TabIndex = 18;
            this.txtCommision.TextChanged += new System.EventHandler(this.txtPaxNumber_TextChanged);
            this.txtCommision.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // lblAplication
            // 
            this.lblAplication.AutoSize = true;
            this.lblAplication.Location = new System.Drawing.Point(22, 350);
            this.lblAplication.Name = "lblAplication";
            this.lblAplication.Size = new System.Drawing.Size(59, 13);
            this.lblAplication.TabIndex = 51;
            this.lblAplication.Text = "Aplicación:";
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 3;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 47.10744F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 52.89256F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 70F));
            this.tableLayoutPanel2.Controls.Add(this.rdoOne, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.rdoALL, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.rdoPER, 2, 0);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(127, 345);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 59.52381F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(192, 21);
            this.tableLayoutPanel2.TabIndex = 19;
            this.tableLayoutPanel2.TabStop = true;
            // 
            // rdoOne
            // 
            this.rdoOne.AutoSize = true;
            this.rdoOne.Location = new System.Drawing.Point(3, 3);
            this.rdoOne.Name = "rdoOne";
            this.rdoOne.Size = new System.Drawing.Size(48, 15);
            this.rdoOne.TabIndex = 19;
            this.rdoOne.TabStop = true;
            this.rdoOne.Text = "ONE";
            this.rdoOne.UseVisualStyleBackColor = true;
            this.rdoOne.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // rdoALL
            // 
            this.rdoALL.AutoSize = true;
            this.rdoALL.Location = new System.Drawing.Point(60, 3);
            this.rdoALL.Name = "rdoALL";
            this.rdoALL.Size = new System.Drawing.Size(44, 15);
            this.rdoALL.TabIndex = 20;
            this.rdoALL.TabStop = true;
            this.rdoALL.Text = "ALL";
            this.rdoALL.UseVisualStyleBackColor = true;
            this.rdoALL.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // rdoPER
            // 
            this.rdoPER.AutoSize = true;
            this.rdoPER.Location = new System.Drawing.Point(124, 3);
            this.rdoPER.Name = "rdoPER";
            this.rdoPER.Size = new System.Drawing.Size(47, 15);
            this.rdoPER.TabIndex = 21;
            this.rdoPER.TabStop = true;
            this.rdoPER.Text = "PER";
            this.rdoPER.UseVisualStyleBackColor = true;
            this.rdoPER.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 3;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 48.90511F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 51.09489F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 72F));
            this.tableLayoutPanel3.Controls.Add(this.rdoCC, 1, 0);
            this.tableLayoutPanel3.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(200, 100);
            this.tableLayoutPanel3.TabIndex = 0;
            // 
            // rdoCC
            // 
            this.rdoCC.AutoSize = true;
            this.rdoCC.Location = new System.Drawing.Point(65, 3);
            this.rdoCC.Name = "rdoCC";
            this.rdoCC.Size = new System.Drawing.Size(39, 17);
            this.rdoCC.TabIndex = 20;
            this.rdoCC.TabStop = true;
            this.rdoCC.Text = "CC";
            this.rdoCC.UseVisualStyleBackColor = true;
            // 
            // rdoCX
            // 
            this.rdoCX.AutoSize = true;
            this.rdoCX.Location = new System.Drawing.Point(122, 3);
            this.rdoCX.Name = "rdoCX";
            this.rdoCX.Size = new System.Drawing.Size(39, 17);
            this.rdoCX.TabIndex = 21;
            this.rdoCX.TabStop = true;
            this.rdoCX.Text = "CX";
            this.rdoCX.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.ColumnCount = 2;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 49.15254F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.84746F));
            this.tableLayoutPanel4.Controls.Add(this.rdoCC2, 1, 0);
            this.tableLayoutPanel4.Controls.Add(this.rdoCA, 0, 0);
            this.tableLayoutPanel4.Location = new System.Drawing.Point(127, 376);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 1;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(118, 28);
            this.tableLayoutPanel4.TabIndex = 22;
            this.tableLayoutPanel4.TabStop = true;
            // 
            // rdoCC2
            // 
            this.rdoCC2.AutoSize = true;
            this.rdoCC2.Location = new System.Drawing.Point(60, 3);
            this.rdoCC2.Name = "rdoCC2";
            this.rdoCC2.Size = new System.Drawing.Size(39, 17);
            this.rdoCC2.TabIndex = 23;
            this.rdoCC2.TabStop = true;
            this.rdoCC2.Text = "CC";
            this.rdoCC2.UseVisualStyleBackColor = true;
            this.rdoCC2.CheckedChanged += new System.EventHandler(this.rdoCA_CheckedChanged);
            this.rdoCC2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // rdoCA
            // 
            this.rdoCA.AutoSize = true;
            this.rdoCA.Location = new System.Drawing.Point(3, 3);
            this.rdoCA.Name = "rdoCA";
            this.rdoCA.Size = new System.Drawing.Size(39, 17);
            this.rdoCA.TabIndex = 22;
            this.rdoCA.TabStop = true;
            this.rdoCA.Text = "CA";
            this.rdoCA.UseVisualStyleBackColor = true;
            this.rdoCA.CheckedChanged += new System.EventHandler(this.rdoCA_CheckedChanged);
            this.rdoCA.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // lblFormPay
            // 
            this.lblFormPay.AutoSize = true;
            this.lblFormPay.Location = new System.Drawing.Point(22, 381);
            this.lblFormPay.Name = "lblFormPay";
            this.lblFormPay.Size = new System.Drawing.Size(82, 13);
            this.lblFormPay.TabIndex = 52;
            this.lblFormPay.Text = "Forma de Pago:";
            // 
            // lblNumberCard
            // 
            this.lblNumberCard.AutoSize = true;
            this.lblNumberCard.Location = new System.Drawing.Point(73, 439);
            this.lblNumberCard.Name = "lblNumberCard";
            this.lblNumberCard.Size = new System.Drawing.Size(98, 13);
            this.lblNumberCard.TabIndex = 53;
            this.lblNumberCard.Text = "Número de Tarjeta:";
            // 
            // lblCardCode
            // 
            this.lblCardCode.AutoSize = true;
            this.lblCardCode.Location = new System.Drawing.Point(73, 413);
            this.lblCardCode.Name = "lblCardCode";
            this.lblCardCode.Size = new System.Drawing.Size(94, 13);
            this.lblCardCode.TabIndex = 54;
            this.lblCardCode.Text = "Código de Tarjeta:";
            // 
            // txtNumberCard
            // 
            this.txtNumberCard.AllowBlankSpaces = false;
            this.txtNumberCard.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtNumberCard.CharsIncluded = new char[0];
            this.txtNumberCard.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.OnlyNumbers;
            this.txtNumberCard.CustomExpression = ".*";
            this.txtNumberCard.Enabled = false;
            this.txtNumberCard.EnterColor = System.Drawing.Color.Empty;
            this.txtNumberCard.LeaveColor = System.Drawing.Color.Empty;
            this.txtNumberCard.Location = new System.Drawing.Point(178, 436);
            this.txtNumberCard.MaxLength = 16;
            this.txtNumberCard.Name = "txtNumberCard";
            this.txtNumberCard.Size = new System.Drawing.Size(157, 20);
            this.txtNumberCard.TabIndex = 25;
            this.txtNumberCard.TextChanged += new System.EventHandler(this.txtPaxNumber_TextChanged);
            this.txtNumberCard.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // txtCardCode
            // 
            this.txtCardCode.AllowBlankSpaces = true;
            this.txtCardCode.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtCardCode.CharsIncluded = new char[0];
            this.txtCardCode.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.OnlyLetters;
            this.txtCardCode.CustomExpression = ".*";
            this.txtCardCode.Enabled = false;
            this.txtCardCode.EnterColor = System.Drawing.Color.Empty;
            this.txtCardCode.LeaveColor = System.Drawing.Color.Empty;
            this.txtCardCode.Location = new System.Drawing.Point(178, 410);
            this.txtCardCode.MaxLength = 52;
            this.txtCardCode.Name = "txtCardCode";
            this.txtCardCode.Size = new System.Drawing.Size(178, 20);
            this.txtCardCode.TabIndex = 24;
            this.txtCardCode.TextChanged += new System.EventHandler(this.txtCardCode_TextChanged);
            this.txtCardCode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCardCode_KeyDown);
            // 
            // lblInicialName
            // 
            this.lblInicialName.AutoSize = true;
            this.lblInicialName.Location = new System.Drawing.Point(73, 490);
            this.lblInicialName.Name = "lblInicialName";
            this.lblInicialName.Size = new System.Drawing.Size(94, 13);
            this.lblInicialName.TabIndex = 56;
            this.lblInicialName.Text = "Inicial del Nombre:";
            // 
            // lblLastname
            // 
            this.lblLastname.AutoSize = true;
            this.lblLastname.Location = new System.Drawing.Point(72, 465);
            this.lblLastname.Name = "lblLastname";
            this.lblLastname.Size = new System.Drawing.Size(47, 13);
            this.lblLastname.TabIndex = 55;
            this.lblLastname.Text = "Apellido:";
            // 
            // txtInicialName
            // 
            this.txtInicialName.AllowBlankSpaces = false;
            this.txtInicialName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtInicialName.CharsIncluded = new char[0];
            this.txtInicialName.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.OnlyLetters;
            this.txtInicialName.CustomExpression = ".*";
            this.txtInicialName.Enabled = false;
            this.txtInicialName.EnterColor = System.Drawing.Color.Empty;
            this.txtInicialName.LeaveColor = System.Drawing.Color.Empty;
            this.txtInicialName.Location = new System.Drawing.Point(178, 488);
            this.txtInicialName.MaxLength = 1;
            this.txtInicialName.Name = "txtInicialName";
            this.txtInicialName.Size = new System.Drawing.Size(29, 20);
            this.txtInicialName.TabIndex = 27;
            this.txtInicialName.TextChanged += new System.EventHandler(this.txtPaxNumber_TextChanged);
            this.txtInicialName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // txtLastname
            // 
            this.txtLastname.AllowBlankSpaces = false;
            this.txtLastname.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtLastname.CharsIncluded = new char[0];
            this.txtLastname.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.OnlyLetters;
            this.txtLastname.CustomExpression = ".*";
            this.txtLastname.Enabled = false;
            this.txtLastname.EnterColor = System.Drawing.Color.Empty;
            this.txtLastname.LeaveColor = System.Drawing.Color.Empty;
            this.txtLastname.Location = new System.Drawing.Point(178, 462);
            this.txtLastname.MaxLength = 20;
            this.txtLastname.Name = "txtLastname";
            this.txtLastname.Size = new System.Drawing.Size(144, 20);
            this.txtLastname.TabIndex = 26;
            this.txtLastname.TextChanged += new System.EventHandler(this.txtPaxNumber_TextChanged);
            this.txtLastname.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // txtNumDoctos
            // 
            this.txtNumDoctos.AllowBlankSpaces = false;
            this.txtNumDoctos.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtNumDoctos.CharsIncluded = new char[0];
            this.txtNumDoctos.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.OnlyNumbers;
            this.txtNumDoctos.CustomExpression = ".*";
            this.txtNumDoctos.EnterColor = System.Drawing.Color.Empty;
            this.txtNumDoctos.LeaveColor = System.Drawing.Color.Empty;
            this.txtNumDoctos.Location = new System.Drawing.Point(134, 516);
            this.txtNumDoctos.MaxLength = 1;
            this.txtNumDoctos.Name = "txtNumDoctos";
            this.txtNumDoctos.Size = new System.Drawing.Size(35, 20);
            this.txtNumDoctos.TabIndex = 28;
            this.txtNumDoctos.TextChanged += new System.EventHandler(this.txtPaxNumber_TextChanged);
            this.txtNumDoctos.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // txtPaxNumber
            // 
            this.txtPaxNumber.AllowBlankSpaces = false;
            this.txtPaxNumber.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtPaxNumber.CharsIncluded = new char[] {
        '.'};
            this.txtPaxNumber.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.OnlyNumbers;
            this.txtPaxNumber.CustomExpression = ".*";
            this.txtPaxNumber.EnterColor = System.Drawing.Color.Empty;
            this.txtPaxNumber.LeaveColor = System.Drawing.Color.Empty;
            this.txtPaxNumber.Location = new System.Drawing.Point(134, 542);
            this.txtPaxNumber.MaxLength = 4;
            this.txtPaxNumber.Name = "txtPaxNumber";
            this.txtPaxNumber.Size = new System.Drawing.Size(57, 20);
            this.txtPaxNumber.TabIndex = 29;
            this.txtPaxNumber.TextChanged += new System.EventHandler(this.txtPaxNumber_TextChanged);
            this.txtPaxNumber.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // lblNumDoctos
            // 
            this.lblNumDoctos.AutoSize = true;
            this.lblNumDoctos.Location = new System.Drawing.Point(14, 519);
            this.lblNumDoctos.Name = "lblNumDoctos";
            this.lblNumDoctos.Size = new System.Drawing.Size(105, 13);
            this.lblNumDoctos.TabIndex = 56;
            this.lblNumDoctos.Text = "No. de Documentos:";
            // 
            // lblPaxNumber
            // 
            this.lblPaxNumber.AutoSize = true;
            this.lblPaxNumber.Location = new System.Drawing.Point(14, 545);
            this.lblPaxNumber.Name = "lblPaxNumber";
            this.lblPaxNumber.Size = new System.Drawing.Size(111, 13);
            this.lblPaxNumber.TabIndex = 56;
            this.lblPaxNumber.Text = "Posición del Pasajero:";
            // 
            // lblInfo
            // 
            this.lblInfo.AutoSize = true;
            this.lblInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInfo.ForeColor = System.Drawing.Color.Blue;
            this.lblInfo.Location = new System.Drawing.Point(27, 28);
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Size = new System.Drawing.Size(199, 16);
            this.lblInfo.TabIndex = 57;
            this.lblInfo.Text = "Elige el Tipo de Línea Contable:";
            // 
            // lbCardCode
            // 
            this.lbCardCode.DisplayMember = "Text";
            this.lbCardCode.FormattingEnabled = true;
            this.lbCardCode.Location = new System.Drawing.Point(178, 429);
            this.lbCardCode.Name = "lbCardCode";
            this.lbCardCode.Size = new System.Drawing.Size(178, 95);
            this.lbCardCode.TabIndex = 58;
            this.lbCardCode.MouseClick += new System.Windows.Forms.MouseEventHandler(this.ListBox_MouseClick);
            this.lbCardCode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.lbCardCode_KeyDown);
            // 
            // ucLandAccountingLine
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.lbCardCode);
            this.Controls.Add(this.lblInfo);
            this.Controls.Add(this.lblPaxNumber);
            this.Controls.Add(this.lblNumDoctos);
            this.Controls.Add(this.lblInicialName);
            this.Controls.Add(this.lblLastname);
            this.Controls.Add(this.txtPaxNumber);
            this.Controls.Add(this.txtNumDoctos);
            this.Controls.Add(this.txtInicialName);
            this.Controls.Add(this.txtLastname);
            this.Controls.Add(this.lblNumberCard);
            this.Controls.Add(this.lblCardCode);
            this.Controls.Add(this.txtNumberCard);
            this.Controls.Add(this.txtCardCode);
            this.Controls.Add(this.tableLayoutPanel4);
            this.Controls.Add(this.lblFormPay);
            this.Controls.Add(this.tableLayoutPanel2);
            this.Controls.Add(this.lblAplication);
            this.Controls.Add(this.lblCommision);
            this.Controls.Add(this.txtCommision);
            this.Controls.Add(this.lblOtherTaxes);
            this.Controls.Add(this.lblIva);
            this.Controls.Add(this.lblBasisFare);
            this.Controls.Add(this.txtIVA);
            this.Controls.Add(this.txtOtherTaxes);
            this.Controls.Add(this.txtBasisFare);
            this.Controls.Add(this.lblNumVoucher);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.txtNumVoucher);
            this.Controls.Add(this.txtSegment);
            this.Controls.Add(this.lblTypeInvoice);
            this.Controls.Add(this.lblSegment);
            this.Controls.Add(this.rdoTrain);
            this.Controls.Add(this.rdoBus);
            this.Controls.Add(this.rdoCruise);
            this.Controls.Add(this.rdoTour);
            this.Controls.Add(this.rdoInsurance);
            this.Controls.Add(this.rdoOthers);
            this.Controls.Add(this.rdoAuto);
            this.Controls.Add(this.rdoHotel);
            this.Controls.Add(this.btnAccept);
            this.Controls.Add(this.lblTitle);
            this.Name = "ucLandAccountingLine";
            this.Size = new System.Drawing.Size(411, 580);
            this.Load += new System.EventHandler(this.ucLandAccountingLine_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel4.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Button btnAccept;
        private System.Windows.Forms.RadioButton rdoHotel;
        private System.Windows.Forms.RadioButton rdoTour;
        private System.Windows.Forms.RadioButton rdoAuto;
        private System.Windows.Forms.RadioButton rdoCruise;
        private System.Windows.Forms.RadioButton rdoOthers;
        private System.Windows.Forms.RadioButton rdoBus;
        private System.Windows.Forms.RadioButton rdoInsurance;
        private System.Windows.Forms.RadioButton rdoTrain;
        private System.Windows.Forms.Label lblSegment;
        private MyCTS.Forms.UI.SmartTextBox txtSegment;
        private System.Windows.Forms.Label lblTypeInvoice;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.RadioButton rdoVoucher;
        private System.Windows.Forms.RadioButton rdoTotalPay;
        private System.Windows.Forms.RadioButton rdoDeposit;
        private System.Windows.Forms.RadioButton rdoFinalPay;
        private System.Windows.Forms.Label lblNumVoucher;
        private MyCTS.Forms.UI.SmartTextBox txtNumVoucher;
        private System.Windows.Forms.Label lblOtherTaxes;
        private System.Windows.Forms.Label lblIva;
        private System.Windows.Forms.Label lblBasisFare;
        private MyCTS.Forms.UI.SmartTextBox txtIVA;
        private MyCTS.Forms.UI.SmartTextBox txtOtherTaxes;
        private MyCTS.Forms.UI.SmartTextBox txtBasisFare;
        private System.Windows.Forms.Label lblCommision;
        private MyCTS.Forms.UI.SmartTextBox txtCommision;
        private System.Windows.Forms.Label lblAplication;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.RadioButton rdoOne;
        private System.Windows.Forms.RadioButton rdoPER;
        private System.Windows.Forms.RadioButton rdoALL;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.RadioButton rdoCC;
        private System.Windows.Forms.RadioButton rdoCX;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.RadioButton rdoCC2;
        private System.Windows.Forms.RadioButton rdoCA;
        private System.Windows.Forms.Label lblFormPay;
        private System.Windows.Forms.Label lblNumberCard;
        private System.Windows.Forms.Label lblCardCode;
        private MyCTS.Forms.UI.SmartTextBox txtNumberCard;
        private MyCTS.Forms.UI.SmartTextBox txtCardCode;
        private System.Windows.Forms.Label lblInicialName;
        private System.Windows.Forms.Label lblLastname;
        private MyCTS.Forms.UI.SmartTextBox txtInicialName;
        private MyCTS.Forms.UI.SmartTextBox txtLastname;
        private MyCTS.Forms.UI.SmartTextBox txtNumDoctos;
        private MyCTS.Forms.UI.SmartTextBox txtPaxNumber;
        private System.Windows.Forms.Label lblNumDoctos;
        private System.Windows.Forms.Label lblPaxNumber;
        private System.Windows.Forms.Label lblInfo;
        private System.Windows.Forms.ListBox lbCardCode;
    }
}
