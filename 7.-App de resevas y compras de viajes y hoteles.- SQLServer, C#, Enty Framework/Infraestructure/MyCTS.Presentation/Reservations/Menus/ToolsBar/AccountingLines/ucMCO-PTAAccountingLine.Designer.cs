namespace MyCTS.Presentation
{
    partial class ucMCO_PTAAccountingLine
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
            this.lblInfo = new System.Windows.Forms.Label();
            this.rdoMCO = new System.Windows.Forms.RadioButton();
            this.rdoPTA = new System.Windows.Forms.RadioButton();
            this.lblSegment = new System.Windows.Forms.Label();
            this.txtSegment = new MyCTS.Forms.UI.SmartTextBox();
            this.txtAirLine = new MyCTS.Forms.UI.SmartTextBox();
            this.lblAirline = new System.Windows.Forms.Label();
            this.txtNumberTicket = new MyCTS.Forms.UI.SmartTextBox();
            this.lblTicket = new System.Windows.Forms.Label();
            this.lblDigit = new System.Windows.Forms.Label();
            this.txtDigit = new MyCTS.Forms.UI.SmartTextBox();
            this.lblAmount = new System.Windows.Forms.Label();
            this.lblCommision = new System.Windows.Forms.Label();
            this.txtQuantity = new MyCTS.Forms.UI.SmartTextBox();
            this.txtCommision = new MyCTS.Forms.UI.SmartTextBox();
            this.lblOtherTaxes = new System.Windows.Forms.Label();
            this.lblBasisFare = new System.Windows.Forms.Label();
            this.txtTaxe1 = new MyCTS.Forms.UI.SmartTextBox();
            this.txtBasisFare = new MyCTS.Forms.UI.SmartTextBox();
            this.txtTaxe2 = new MyCTS.Forms.UI.SmartTextBox();
            this.lblTaxe2 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.rdoOne = new System.Windows.Forms.RadioButton();
            this.rdoPER = new System.Windows.Forms.RadioButton();
            this.rdoALL = new System.Windows.Forms.RadioButton();
            this.lblRateRequest = new System.Windows.Forms.Label();
            this.lblNumberDocuments = new System.Windows.Forms.Label();
            this.txtNumberDoctos = new MyCTS.Forms.UI.SmartTextBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.rdoCC = new System.Windows.Forms.RadioButton();
            this.rdoCX = new System.Windows.Forms.RadioButton();
            this.rdoCA = new System.Windows.Forms.RadioButton();
            this.lblFormPay = new System.Windows.Forms.Label();
            this.lblInicialName = new System.Windows.Forms.Label();
            this.lblLastname = new System.Windows.Forms.Label();
            this.lblNumPax = new System.Windows.Forms.Label();
            this.lblNumberCard = new System.Windows.Forms.Label();
            this.lblCardCode = new System.Windows.Forms.Label();
            this.txtPaxNumber = new MyCTS.Forms.UI.SmartTextBox();
            this.txtInicialName = new MyCTS.Forms.UI.SmartTextBox();
            this.txtLastname = new MyCTS.Forms.UI.SmartTextBox();
            this.txtNumberCard = new MyCTS.Forms.UI.SmartTextBox();
            this.txtCardCode = new MyCTS.Forms.UI.SmartTextBox();
            this.lblComment = new System.Windows.Forms.Label();
            this.txtComentarios = new MyCTS.Forms.UI.SmartTextBox();
            this.btnAccept = new System.Windows.Forms.Button();
            this.lbAirline = new System.Windows.Forms.ListBox();
            this.lbCardCode = new System.Windows.Forms.ListBox();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
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
            this.lblTitle.TabIndex = 2;
            this.lblTitle.Text = "Línea Contable MCO / PTA";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblInfo
            // 
            this.lblInfo.AutoSize = true;
            this.lblInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInfo.ForeColor = System.Drawing.Color.Blue;
            this.lblInfo.Location = new System.Drawing.Point(20, 31);
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Size = new System.Drawing.Size(199, 16);
            this.lblInfo.TabIndex = 58;
            this.lblInfo.Text = "Elige el Tipo de Línea Contable:";
            // 
            // rdoMCO
            // 
            this.rdoMCO.AutoSize = true;
            this.rdoMCO.Location = new System.Drawing.Point(26, 66);
            this.rdoMCO.Name = "rdoMCO";
            this.rdoMCO.Size = new System.Drawing.Size(49, 17);
            this.rdoMCO.TabIndex = 1;
            this.rdoMCO.TabStop = true;
            this.rdoMCO.Text = "MCO";
            this.rdoMCO.UseVisualStyleBackColor = true;
            this.rdoMCO.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // rdoPTA
            // 
            this.rdoPTA.AutoSize = true;
            this.rdoPTA.Location = new System.Drawing.Point(136, 66);
            this.rdoPTA.Name = "rdoPTA";
            this.rdoPTA.Size = new System.Drawing.Size(46, 17);
            this.rdoPTA.TabIndex = 2;
            this.rdoPTA.TabStop = true;
            this.rdoPTA.Text = "PTA";
            this.rdoPTA.UseVisualStyleBackColor = true;
            this.rdoPTA.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // lblSegment
            // 
            this.lblSegment.AutoSize = true;
            this.lblSegment.Location = new System.Drawing.Point(21, 94);
            this.lblSegment.Name = "lblSegment";
            this.lblSegment.Size = new System.Drawing.Size(58, 13);
            this.lblSegment.TabIndex = 59;
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
            this.txtSegment.Location = new System.Drawing.Point(130, 91);
            this.txtSegment.MaxLength = 2;
            this.txtSegment.Name = "txtSegment";
            this.txtSegment.Size = new System.Drawing.Size(42, 20);
            this.txtSegment.TabIndex = 3;
            this.txtSegment.TextChanged += new System.EventHandler(this.txtSegment_TextChanged);
            this.txtSegment.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // txtAirLine
            // 
            this.txtAirLine.AllowBlankSpaces = true;
            this.txtAirLine.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtAirLine.CharsIncluded = new char[0];
            this.txtAirLine.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.NumbersOrLetters;
            this.txtAirLine.CustomExpression = ".*";
            this.txtAirLine.EnterColor = System.Drawing.Color.Empty;
            this.txtAirLine.LeaveColor = System.Drawing.Color.Empty;
            this.txtAirLine.Location = new System.Drawing.Point(130, 117);
            this.txtAirLine.MaxLength = 52;
            this.txtAirLine.Name = "txtAirLine";
            this.txtAirLine.Size = new System.Drawing.Size(196, 20);
            this.txtAirLine.TabIndex = 4;
            this.txtAirLine.TextChanged += new System.EventHandler(this.txtAirLine_TextChanged);
            this.txtAirLine.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtAirLine_KeyDown);
            // 
            // lblAirline
            // 
            this.lblAirline.AutoSize = true;
            this.lblAirline.Location = new System.Drawing.Point(21, 120);
            this.lblAirline.Name = "lblAirline";
            this.lblAirline.Size = new System.Drawing.Size(56, 13);
            this.lblAirline.TabIndex = 59;
            this.lblAirline.Text = "Aerolínea:";
            // 
            // txtNumberTicket
            // 
            this.txtNumberTicket.AllowBlankSpaces = false;
            this.txtNumberTicket.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtNumberTicket.CharsIncluded = new char[0];
            this.txtNumberTicket.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.OnlyNumbers;
            this.txtNumberTicket.CustomExpression = ".*";
            this.txtNumberTicket.EnterColor = System.Drawing.Color.Empty;
            this.txtNumberTicket.LeaveColor = System.Drawing.Color.Empty;
            this.txtNumberTicket.Location = new System.Drawing.Point(130, 143);
            this.txtNumberTicket.MaxLength = 10;
            this.txtNumberTicket.Name = "txtNumberTicket";
            this.txtNumberTicket.Size = new System.Drawing.Size(112, 20);
            this.txtNumberTicket.TabIndex = 5;
            this.txtNumberTicket.TextChanged += new System.EventHandler(this.txtSegment_TextChanged);
            this.txtNumberTicket.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // lblTicket
            // 
            this.lblTicket.AutoSize = true;
            this.lblTicket.Location = new System.Drawing.Point(21, 146);
            this.lblTicket.Name = "lblTicket";
            this.lblTicket.Size = new System.Drawing.Size(75, 13);
            this.lblTicket.TabIndex = 59;
            this.lblTicket.Text = "No. de Boleto:";
            // 
            // lblDigit
            // 
            this.lblDigit.AutoSize = true;
            this.lblDigit.Location = new System.Drawing.Point(254, 146);
            this.lblDigit.Name = "lblDigit";
            this.lblDigit.Size = new System.Drawing.Size(37, 13);
            this.lblDigit.TabIndex = 59;
            this.lblDigit.Text = "Digito:";
            // 
            // txtDigit
            // 
            this.txtDigit.AllowBlankSpaces = false;
            this.txtDigit.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtDigit.CharsIncluded = new char[0];
            this.txtDigit.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.OnlyNumbers;
            this.txtDigit.CustomExpression = ".*";
            this.txtDigit.EnterColor = System.Drawing.Color.Empty;
            this.txtDigit.LeaveColor = System.Drawing.Color.Empty;
            this.txtDigit.Location = new System.Drawing.Point(297, 143);
            this.txtDigit.MaxLength = 1;
            this.txtDigit.Name = "txtDigit";
            this.txtDigit.Size = new System.Drawing.Size(36, 20);
            this.txtDigit.TabIndex = 6;
            this.txtDigit.TextChanged += new System.EventHandler(this.txtSegment_TextChanged);
            this.txtDigit.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // lblAmount
            // 
            this.lblAmount.AutoSize = true;
            this.lblAmount.ForeColor = System.Drawing.Color.DarkCyan;
            this.lblAmount.Location = new System.Drawing.Point(242, 172);
            this.lblAmount.Name = "lblAmount";
            this.lblAmount.Size = new System.Drawing.Size(49, 13);
            this.lblAmount.TabIndex = 61;
            this.lblAmount.Text = "o Monto:";
            // 
            // lblCommision
            // 
            this.lblCommision.AutoSize = true;
            this.lblCommision.Location = new System.Drawing.Point(21, 172);
            this.lblCommision.Name = "lblCommision";
            this.lblCommision.Size = new System.Drawing.Size(78, 13);
            this.lblCommision.TabIndex = 63;
            this.lblCommision.Text = "% de Comisión:";
            // 
            // txtQuantity
            // 
            this.txtQuantity.AllowBlankSpaces = false;
            this.txtQuantity.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtQuantity.CharsIncluded = new char[] {
        '.'};
            this.txtQuantity.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.OnlyNumbers;
            this.txtQuantity.CustomExpression = ".*";
            this.txtQuantity.EnterColor = System.Drawing.Color.Empty;
            this.txtQuantity.LeaveColor = System.Drawing.Color.Empty;
            this.txtQuantity.Location = new System.Drawing.Point(297, 169);
            this.txtQuantity.MaxLength = 7;
            this.txtQuantity.Name = "txtQuantity";
            this.txtQuantity.Size = new System.Drawing.Size(76, 20);
            this.txtQuantity.TabIndex = 8;
            this.txtQuantity.TextChanged += new System.EventHandler(this.txtSegment_TextChanged);
            this.txtQuantity.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
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
            this.txtCommision.Location = new System.Drawing.Point(130, 169);
            this.txtCommision.MaxLength = 3;
            this.txtCommision.Name = "txtCommision";
            this.txtCommision.Size = new System.Drawing.Size(46, 20);
            this.txtCommision.TabIndex = 7;
            this.txtCommision.TextChanged += new System.EventHandler(this.txtSegment_TextChanged);
            this.txtCommision.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // lblOtherTaxes
            // 
            this.lblOtherTaxes.AutoSize = true;
            this.lblOtherTaxes.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblOtherTaxes.Location = new System.Drawing.Point(21, 224);
            this.lblOtherTaxes.Name = "lblOtherTaxes";
            this.lblOtherTaxes.Size = new System.Drawing.Size(62, 13);
            this.lblOtherTaxes.TabIndex = 65;
            this.lblOtherTaxes.Text = "Impuesto 1:";
            // 
            // lblBasisFare
            // 
            this.lblBasisFare.AutoSize = true;
            this.lblBasisFare.Location = new System.Drawing.Point(21, 198);
            this.lblBasisFare.Name = "lblBasisFare";
            this.lblBasisFare.Size = new System.Drawing.Size(64, 13);
            this.lblBasisFare.TabIndex = 64;
            this.lblBasisFare.Text = "Tarifa Base:";
            // 
            // txtTaxe1
            // 
            this.txtTaxe1.AllowBlankSpaces = false;
            this.txtTaxe1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtTaxe1.CharsIncluded = new char[] {
        '.'};
            this.txtTaxe1.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.OnlyNumbers;
            this.txtTaxe1.CustomExpression = ".*";
            this.txtTaxe1.EnterColor = System.Drawing.Color.Empty;
            this.txtTaxe1.LeaveColor = System.Drawing.Color.Empty;
            this.txtTaxe1.Location = new System.Drawing.Point(130, 221);
            this.txtTaxe1.MaxLength = 8;
            this.txtTaxe1.Name = "txtTaxe1";
            this.txtTaxe1.Size = new System.Drawing.Size(90, 20);
            this.txtTaxe1.TabIndex = 10;
            this.txtTaxe1.Text = "0.00";
            this.txtTaxe1.TextChanged += new System.EventHandler(this.txtSegment_TextChanged);
            this.txtTaxe1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
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
            this.txtBasisFare.Location = new System.Drawing.Point(130, 195);
            this.txtBasisFare.MaxLength = 8;
            this.txtBasisFare.Name = "txtBasisFare";
            this.txtBasisFare.Size = new System.Drawing.Size(90, 20);
            this.txtBasisFare.TabIndex = 9;
            this.txtBasisFare.Text = "0.00";
            this.txtBasisFare.TextChanged += new System.EventHandler(this.txtSegment_TextChanged);
            this.txtBasisFare.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // txtTaxe2
            // 
            this.txtTaxe2.AllowBlankSpaces = false;
            this.txtTaxe2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtTaxe2.CharsIncluded = new char[] {
        '.'};
            this.txtTaxe2.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.OnlyNumbers;
            this.txtTaxe2.CustomExpression = ".*";
            this.txtTaxe2.EnterColor = System.Drawing.Color.Empty;
            this.txtTaxe2.LeaveColor = System.Drawing.Color.Empty;
            this.txtTaxe2.Location = new System.Drawing.Point(130, 247);
            this.txtTaxe2.MaxLength = 8;
            this.txtTaxe2.Name = "txtTaxe2";
            this.txtTaxe2.Size = new System.Drawing.Size(90, 20);
            this.txtTaxe2.TabIndex = 11;
            this.txtTaxe2.Text = "0.00";
            this.txtTaxe2.TextChanged += new System.EventHandler(this.txtSegment_TextChanged);
            this.txtTaxe2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // lblTaxe2
            // 
            this.lblTaxe2.AutoSize = true;
            this.lblTaxe2.ForeColor = System.Drawing.Color.DarkCyan;
            this.lblTaxe2.Location = new System.Drawing.Point(21, 250);
            this.lblTaxe2.Name = "lblTaxe2";
            this.lblTaxe2.Size = new System.Drawing.Size(62, 13);
            this.lblTaxe2.TabIndex = 65;
            this.lblTaxe2.Text = "Impuesto 2:";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.38168F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 49.61832F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tableLayoutPanel1.Controls.Add(this.rdoOne, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.rdoPER, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.rdoALL, 1, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(130, 273);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 59.52381F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(192, 21);
            this.tableLayoutPanel1.TabIndex = 12;
            this.tableLayoutPanel1.TabStop = true;
            // 
            // rdoOne
            // 
            this.rdoOne.AutoSize = true;
            this.rdoOne.Location = new System.Drawing.Point(3, 3);
            this.rdoOne.Name = "rdoOne";
            this.rdoOne.Size = new System.Drawing.Size(48, 15);
            this.rdoOne.TabIndex = 12;
            this.rdoOne.TabStop = true;
            this.rdoOne.Text = "ONE";
            this.rdoOne.UseVisualStyleBackColor = true;
            this.rdoOne.CheckedChanged += new System.EventHandler(this.rdoOne_CheckedChanged);
            this.rdoOne.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // rdoPER
            // 
            this.rdoPER.AutoSize = true;
            this.rdoPER.Location = new System.Drawing.Point(134, 3);
            this.rdoPER.Name = "rdoPER";
            this.rdoPER.Size = new System.Drawing.Size(47, 15);
            this.rdoPER.TabIndex = 14;
            this.rdoPER.TabStop = true;
            this.rdoPER.Text = "PER";
            this.rdoPER.UseVisualStyleBackColor = true;
            this.rdoPER.CheckedChanged += new System.EventHandler(this.rdoOne_CheckedChanged);
            this.rdoPER.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // rdoALL
            // 
            this.rdoALL.AutoSize = true;
            this.rdoALL.Location = new System.Drawing.Point(69, 3);
            this.rdoALL.Name = "rdoALL";
            this.rdoALL.Size = new System.Drawing.Size(44, 15);
            this.rdoALL.TabIndex = 13;
            this.rdoALL.TabStop = true;
            this.rdoALL.Text = "ALL";
            this.rdoALL.UseVisualStyleBackColor = true;
            this.rdoALL.CheckedChanged += new System.EventHandler(this.rdoOne_CheckedChanged);
            this.rdoALL.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // lblRateRequest
            // 
            this.lblRateRequest.AutoSize = true;
            this.lblRateRequest.Location = new System.Drawing.Point(21, 277);
            this.lblRateRequest.Name = "lblRateRequest";
            this.lblRateRequest.Size = new System.Drawing.Size(59, 13);
            this.lblRateRequest.TabIndex = 66;
            this.lblRateRequest.Text = "Aplicación:";
            // 
            // lblNumberDocuments
            // 
            this.lblNumberDocuments.AutoSize = true;
            this.lblNumberDocuments.Location = new System.Drawing.Point(21, 303);
            this.lblNumberDocuments.Name = "lblNumberDocuments";
            this.lblNumberDocuments.Size = new System.Drawing.Size(105, 13);
            this.lblNumberDocuments.TabIndex = 67;
            this.lblNumberDocuments.Text = "No. de Documentos:";
            // 
            // txtNumberDoctos
            // 
            this.txtNumberDoctos.AllowBlankSpaces = false;
            this.txtNumberDoctos.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtNumberDoctos.CharsIncluded = new char[0];
            this.txtNumberDoctos.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.OnlyNumbers;
            this.txtNumberDoctos.CustomExpression = ".*";
            this.txtNumberDoctos.EnterColor = System.Drawing.Color.Empty;
            this.txtNumberDoctos.LeaveColor = System.Drawing.Color.Empty;
            this.txtNumberDoctos.Location = new System.Drawing.Point(130, 300);
            this.txtNumberDoctos.MaxLength = 1;
            this.txtNumberDoctos.Name = "txtNumberDoctos";
            this.txtNumberDoctos.Size = new System.Drawing.Size(31, 20);
            this.txtNumberDoctos.TabIndex = 15;
            this.txtNumberDoctos.TextChanged += new System.EventHandler(this.txtSegment_TextChanged);
            this.txtNumberDoctos.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 3;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 48.90511F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 51.09489F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 83F));
            this.tableLayoutPanel2.Controls.Add(this.rdoCC, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.rdoCX, 2, 0);
            this.tableLayoutPanel2.Controls.Add(this.rdoCA, 0, 0);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(130, 326);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(192, 24);
            this.tableLayoutPanel2.TabIndex = 16;
            this.tableLayoutPanel2.TabStop = true;
            // 
            // rdoCC
            // 
            this.rdoCC.AutoSize = true;
            this.rdoCC.Location = new System.Drawing.Point(56, 3);
            this.rdoCC.Name = "rdoCC";
            this.rdoCC.Size = new System.Drawing.Size(39, 17);
            this.rdoCC.TabIndex = 17;
            this.rdoCC.TabStop = true;
            this.rdoCC.Text = "CC";
            this.rdoCC.UseVisualStyleBackColor = true;
            this.rdoCC.CheckedChanged += new System.EventHandler(this.rdoOne_CheckedChanged);
            this.rdoCC.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // rdoCX
            // 
            this.rdoCX.AutoSize = true;
            this.rdoCX.Location = new System.Drawing.Point(111, 3);
            this.rdoCX.Name = "rdoCX";
            this.rdoCX.Size = new System.Drawing.Size(39, 17);
            this.rdoCX.TabIndex = 18;
            this.rdoCX.TabStop = true;
            this.rdoCX.Text = "CX";
            this.rdoCX.UseVisualStyleBackColor = true;
            this.rdoCX.CheckedChanged += new System.EventHandler(this.rdoOne_CheckedChanged);
            this.rdoCX.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // rdoCA
            // 
            this.rdoCA.AutoSize = true;
            this.rdoCA.Location = new System.Drawing.Point(3, 3);
            this.rdoCA.Name = "rdoCA";
            this.rdoCA.Size = new System.Drawing.Size(39, 17);
            this.rdoCA.TabIndex = 16;
            this.rdoCA.TabStop = true;
            this.rdoCA.Text = "CA";
            this.rdoCA.UseVisualStyleBackColor = true;
            this.rdoCA.CheckedChanged += new System.EventHandler(this.rdoOne_CheckedChanged);
            this.rdoCA.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // lblFormPay
            // 
            this.lblFormPay.AutoSize = true;
            this.lblFormPay.Location = new System.Drawing.Point(21, 331);
            this.lblFormPay.Name = "lblFormPay";
            this.lblFormPay.Size = new System.Drawing.Size(82, 13);
            this.lblFormPay.TabIndex = 69;
            this.lblFormPay.Text = "Forma de Pago:";
            // 
            // lblInicialName
            // 
            this.lblInicialName.AutoSize = true;
            this.lblInicialName.Location = new System.Drawing.Point(43, 436);
            this.lblInicialName.Name = "lblInicialName";
            this.lblInicialName.Size = new System.Drawing.Size(94, 13);
            this.lblInicialName.TabIndex = 73;
            this.lblInicialName.Text = "Inicial del Nombre:";
            // 
            // lblLastname
            // 
            this.lblLastname.AutoSize = true;
            this.lblLastname.Location = new System.Drawing.Point(42, 411);
            this.lblLastname.Name = "lblLastname";
            this.lblLastname.Size = new System.Drawing.Size(47, 13);
            this.lblLastname.TabIndex = 74;
            this.lblLastname.Text = "Apellido:";
            // 
            // lblNumPax
            // 
            this.lblNumPax.AutoSize = true;
            this.lblNumPax.Location = new System.Drawing.Point(42, 463);
            this.lblNumPax.Name = "lblNumPax";
            this.lblNumPax.Size = new System.Drawing.Size(94, 13);
            this.lblNumPax.TabIndex = 72;
            this.lblNumPax.Text = "Núm. de Pasajero:";
            // 
            // lblNumberCard
            // 
            this.lblNumberCard.AutoSize = true;
            this.lblNumberCard.Location = new System.Drawing.Point(43, 385);
            this.lblNumberCard.Name = "lblNumberCard";
            this.lblNumberCard.Size = new System.Drawing.Size(98, 13);
            this.lblNumberCard.TabIndex = 70;
            this.lblNumberCard.Text = "Número de Tarjeta:";
            // 
            // lblCardCode
            // 
            this.lblCardCode.AutoSize = true;
            this.lblCardCode.Location = new System.Drawing.Point(43, 359);
            this.lblCardCode.Name = "lblCardCode";
            this.lblCardCode.Size = new System.Drawing.Size(94, 13);
            this.lblCardCode.TabIndex = 71;
            this.lblCardCode.Text = "Código de Tarjeta:";
            // 
            // txtPaxNumber
            // 
            this.txtPaxNumber.AllowBlankSpaces = false;
            this.txtPaxNumber.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtPaxNumber.CharsIncluded = new char[] {
        '.'};
            this.txtPaxNumber.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.OnlyNumbers;
            this.txtPaxNumber.CustomExpression = ".*";
            this.txtPaxNumber.Enabled = false;
            this.txtPaxNumber.EnterColor = System.Drawing.Color.Empty;
            this.txtPaxNumber.LeaveColor = System.Drawing.Color.Empty;
            this.txtPaxNumber.Location = new System.Drawing.Point(148, 460);
            this.txtPaxNumber.MaxLength = 4;
            this.txtPaxNumber.Name = "txtPaxNumber";
            this.txtPaxNumber.Size = new System.Drawing.Size(48, 20);
            this.txtPaxNumber.TabIndex = 23;
            this.txtPaxNumber.TextChanged += new System.EventHandler(this.txtSegment_TextChanged);
            this.txtPaxNumber.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
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
            this.txtInicialName.Location = new System.Drawing.Point(148, 434);
            this.txtInicialName.MaxLength = 1;
            this.txtInicialName.Name = "txtInicialName";
            this.txtInicialName.Size = new System.Drawing.Size(29, 20);
            this.txtInicialName.TabIndex = 22;
            this.txtInicialName.TextChanged += new System.EventHandler(this.txtSegment_TextChanged);
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
            this.txtLastname.Location = new System.Drawing.Point(148, 408);
            this.txtLastname.MaxLength = 20;
            this.txtLastname.Name = "txtLastname";
            this.txtLastname.Size = new System.Drawing.Size(144, 20);
            this.txtLastname.TabIndex = 21;
            this.txtLastname.TextChanged += new System.EventHandler(this.txtSegment_TextChanged);
            this.txtLastname.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
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
            this.txtNumberCard.Location = new System.Drawing.Point(148, 382);
            this.txtNumberCard.MaxLength = 16;
            this.txtNumberCard.Name = "txtNumberCard";
            this.txtNumberCard.Size = new System.Drawing.Size(157, 20);
            this.txtNumberCard.TabIndex = 20;
            this.txtNumberCard.TextChanged += new System.EventHandler(this.txtSegment_TextChanged);
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
            this.txtCardCode.Location = new System.Drawing.Point(148, 356);
            this.txtCardCode.MaxLength = 52;
            this.txtCardCode.Name = "txtCardCode";
            this.txtCardCode.Size = new System.Drawing.Size(178, 20);
            this.txtCardCode.TabIndex = 19;
            this.txtCardCode.TextChanged += new System.EventHandler(this.txtCardCode_TextChanged);
            this.txtCardCode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCardCode_KeyDown);
            // 
            // lblComment
            // 
            this.lblComment.AutoSize = true;
            this.lblComment.ForeColor = System.Drawing.Color.DarkCyan;
            this.lblComment.Location = new System.Drawing.Point(21, 489);
            this.lblComment.Name = "lblComment";
            this.lblComment.Size = new System.Drawing.Size(68, 13);
            this.lblComment.TabIndex = 75;
            this.lblComment.Text = "Comentarios:";
            // 
            // txtComentarios
            // 
            this.txtComentarios.AllowBlankSpaces = true;
            this.txtComentarios.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtComentarios.CharsIncluded = new char[0];
            this.txtComentarios.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.NumbersOrLetters;
            this.txtComentarios.CustomExpression = ".*";
            this.txtComentarios.EnterColor = System.Drawing.Color.Empty;
            this.txtComentarios.LeaveColor = System.Drawing.Color.Empty;
            this.txtComentarios.Location = new System.Drawing.Point(119, 486);
            this.txtComentarios.MaxLength = 50;
            this.txtComentarios.Name = "txtComentarios";
            this.txtComentarios.Size = new System.Drawing.Size(254, 20);
            this.txtComentarios.TabIndex = 24;
            this.txtComentarios.TextChanged += new System.EventHandler(this.txtSegment_TextChanged);
            this.txtComentarios.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // btnAccept
            // 
            this.btnAccept.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnAccept.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAccept.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAccept.Location = new System.Drawing.Point(273, 521);
            this.btnAccept.Name = "btnAccept";
            this.btnAccept.Size = new System.Drawing.Size(100, 23);
            this.btnAccept.TabIndex = 25;
            this.btnAccept.Text = "Aceptar";
            this.btnAccept.UseVisualStyleBackColor = false;
            this.btnAccept.Click += new System.EventHandler(this.btnAccept_Click);
            // 
            // lbAirline
            // 
            this.lbAirline.DisplayMember = "Text";
            this.lbAirline.FormattingEnabled = true;
            this.lbAirline.Location = new System.Drawing.Point(130, 136);
            this.lbAirline.Name = "lbAirline";
            this.lbAirline.Size = new System.Drawing.Size(196, 69);
            this.lbAirline.TabIndex = 76;
            this.lbAirline.MouseClick += new System.Windows.Forms.MouseEventHandler(this.ListBox_MouseClick);
            this.lbAirline.KeyDown += new System.Windows.Forms.KeyEventHandler(this.lbAirline_KeyDown);
            // 
            // lbCardCode
            // 
            this.lbCardCode.DisplayMember = "Text";
            this.lbCardCode.FormattingEnabled = true;
            this.lbCardCode.Location = new System.Drawing.Point(148, 375);
            this.lbCardCode.Name = "lbCardCode";
            this.lbCardCode.Size = new System.Drawing.Size(178, 95);
            this.lbCardCode.TabIndex = 77;
            this.lbCardCode.MouseClick += new System.Windows.Forms.MouseEventHandler(this.ListBox_MouseClick);
            this.lbCardCode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.lbCardCode_KeyDown);
            // 
            // ucMCO_PTAAccountingLine
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.lbCardCode);
            this.Controls.Add(this.lbAirline);
            this.Controls.Add(this.btnAccept);
            this.Controls.Add(this.lblComment);
            this.Controls.Add(this.txtComentarios);
            this.Controls.Add(this.lblInicialName);
            this.Controls.Add(this.lblLastname);
            this.Controls.Add(this.lblNumPax);
            this.Controls.Add(this.lblNumberCard);
            this.Controls.Add(this.lblCardCode);
            this.Controls.Add(this.txtPaxNumber);
            this.Controls.Add(this.txtInicialName);
            this.Controls.Add(this.txtLastname);
            this.Controls.Add(this.txtNumberCard);
            this.Controls.Add(this.txtCardCode);
            this.Controls.Add(this.tableLayoutPanel2);
            this.Controls.Add(this.lblFormPay);
            this.Controls.Add(this.lblNumberDocuments);
            this.Controls.Add(this.txtNumberDoctos);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.lblRateRequest);
            this.Controls.Add(this.lblTaxe2);
            this.Controls.Add(this.lblOtherTaxes);
            this.Controls.Add(this.lblBasisFare);
            this.Controls.Add(this.txtTaxe2);
            this.Controls.Add(this.txtTaxe1);
            this.Controls.Add(this.txtBasisFare);
            this.Controls.Add(this.lblAmount);
            this.Controls.Add(this.lblCommision);
            this.Controls.Add(this.txtQuantity);
            this.Controls.Add(this.txtCommision);
            this.Controls.Add(this.txtAirLine);
            this.Controls.Add(this.txtNumberTicket);
            this.Controls.Add(this.txtDigit);
            this.Controls.Add(this.txtSegment);
            this.Controls.Add(this.lblDigit);
            this.Controls.Add(this.lblTicket);
            this.Controls.Add(this.lblAirline);
            this.Controls.Add(this.lblSegment);
            this.Controls.Add(this.rdoPTA);
            this.Controls.Add(this.rdoMCO);
            this.Controls.Add(this.lblInfo);
            this.Controls.Add(this.lblTitle);
            this.Name = "ucMCO_PTAAccountingLine";
            this.Size = new System.Drawing.Size(411, 580);
            this.Load += new System.EventHandler(this.ucMCO_PTAAccountingLine_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblInfo;
        private System.Windows.Forms.RadioButton rdoMCO;
        private System.Windows.Forms.RadioButton rdoPTA;
        private System.Windows.Forms.Label lblSegment;
        private MyCTS.Forms.UI.SmartTextBox txtSegment;
        private MyCTS.Forms.UI.SmartTextBox txtAirLine;
        private System.Windows.Forms.Label lblAirline;
        private MyCTS.Forms.UI.SmartTextBox txtNumberTicket;
        private System.Windows.Forms.Label lblTicket;
        private System.Windows.Forms.Label lblDigit;
        private MyCTS.Forms.UI.SmartTextBox txtDigit;
        private System.Windows.Forms.Label lblAmount;
        private System.Windows.Forms.Label lblCommision;
        private MyCTS.Forms.UI.SmartTextBox txtQuantity;
        private MyCTS.Forms.UI.SmartTextBox txtCommision;
        private System.Windows.Forms.Label lblOtherTaxes;
        private System.Windows.Forms.Label lblBasisFare;
        private MyCTS.Forms.UI.SmartTextBox txtTaxe1;
        private MyCTS.Forms.UI.SmartTextBox txtBasisFare;
        private MyCTS.Forms.UI.SmartTextBox txtTaxe2;
        private System.Windows.Forms.Label lblTaxe2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.RadioButton rdoOne;
        private System.Windows.Forms.RadioButton rdoPER;
        private System.Windows.Forms.RadioButton rdoALL;
        private System.Windows.Forms.Label lblRateRequest;
        private System.Windows.Forms.Label lblNumberDocuments;
        private MyCTS.Forms.UI.SmartTextBox txtNumberDoctos;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.RadioButton rdoCC;
        private System.Windows.Forms.RadioButton rdoCX;
        private System.Windows.Forms.RadioButton rdoCA;
        private System.Windows.Forms.Label lblFormPay;
        private System.Windows.Forms.Label lblInicialName;
        private System.Windows.Forms.Label lblLastname;
        private System.Windows.Forms.Label lblNumPax;
        private System.Windows.Forms.Label lblNumberCard;
        private System.Windows.Forms.Label lblCardCode;
        private MyCTS.Forms.UI.SmartTextBox txtPaxNumber;
        private MyCTS.Forms.UI.SmartTextBox txtInicialName;
        private MyCTS.Forms.UI.SmartTextBox txtLastname;
        private MyCTS.Forms.UI.SmartTextBox txtNumberCard;
        private MyCTS.Forms.UI.SmartTextBox txtCardCode;
        private System.Windows.Forms.Label lblComment;
        private MyCTS.Forms.UI.SmartTextBox txtComentarios;
        private System.Windows.Forms.Button btnAccept;
        private System.Windows.Forms.ListBox lbAirline;
        private System.Windows.Forms.ListBox lbCardCode;
    }
}
