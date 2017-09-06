namespace MyCTS.Presentation
{
    partial class ucSendTicketInvoice
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
            this.lblDocumentNumbers = new System.Windows.Forms.Label();
            this.txtDocsNumber = new MyCTS.Forms.UI.SmartTextBox();
            this.lblAccountLines = new System.Windows.Forms.Label();
            this.lblLineRange = new System.Windows.Forms.Label();
            this.lblLineNumber = new System.Windows.Forms.Label();
            this.txtLineRange1 = new MyCTS.Forms.UI.SmartTextBox();
            this.txtLineNumber1 = new MyCTS.Forms.UI.SmartTextBox();
            this.lblIndent = new System.Windows.Forms.Label();
            this.txtLineRange2 = new MyCTS.Forms.UI.SmartTextBox();
            this.txtLineNumber2 = new MyCTS.Forms.UI.SmartTextBox();
            this.lblIndent2 = new System.Windows.Forms.Label();
            this.txtLineRange3 = new MyCTS.Forms.UI.SmartTextBox();
            this.txtLineNumber3 = new MyCTS.Forms.UI.SmartTextBox();
            this.lblIndent3 = new System.Windows.Forms.Label();
            this.lblPaxNumber = new System.Windows.Forms.Label();
            this.lblPaxRange = new System.Windows.Forms.Label();
            this.lblNumber = new System.Windows.Forms.Label();
            this.txtPaxNumber1 = new MyCTS.Forms.UI.SmartTextBox();
            this.lblIndent4 = new System.Windows.Forms.Label();
            this.txtRangePaxNumber1 = new MyCTS.Forms.UI.SmartTextBox();
            this.txtRangePaxNumber2 = new MyCTS.Forms.UI.SmartTextBox();
            this.lblIndent5 = new System.Windows.Forms.Label();
            this.txtPaxNumber2 = new MyCTS.Forms.UI.SmartTextBox();
            this.txtRangePaxNumber3 = new MyCTS.Forms.UI.SmartTextBox();
            this.lblIndent6 = new System.Windows.Forms.Label();
            this.txtPaxNumber3 = new MyCTS.Forms.UI.SmartTextBox();
            this.txtRangeSegment3 = new MyCTS.Forms.UI.SmartTextBox();
            this.lblIndent9 = new System.Windows.Forms.Label();
            this.txtSegment3 = new MyCTS.Forms.UI.SmartTextBox();
            this.txtRangeSegment2 = new MyCTS.Forms.UI.SmartTextBox();
            this.lblIndent8 = new System.Windows.Forms.Label();
            this.txtSegment2 = new MyCTS.Forms.UI.SmartTextBox();
            this.txtRangeSegment = new MyCTS.Forms.UI.SmartTextBox();
            this.lblIndent7 = new System.Windows.Forms.Label();
            this.txtSegment1 = new MyCTS.Forms.UI.SmartTextBox();
            this.lblRangeSegment = new System.Windows.Forms.Label();
            this.lblSegment = new System.Windows.Forms.Label();
            this.lblSegments = new System.Windows.Forms.Label();
            this.lblEmptyforAll = new System.Windows.Forms.Label();
            this.btnAccept = new System.Windows.Forms.Button();
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
            this.lblTitle.Size = new System.Drawing.Size(411, 15);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Envio de Factura";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblDocumentNumbers
            // 
            this.lblDocumentNumbers.AutoSize = true;
            this.lblDocumentNumbers.ForeColor = System.Drawing.Color.DarkCyan;
            this.lblDocumentNumbers.Location = new System.Drawing.Point(39, 36);
            this.lblDocumentNumbers.Name = "lblDocumentNumbers";
            this.lblDocumentNumbers.Size = new System.Drawing.Size(125, 13);
            this.lblDocumentNumbers.TabIndex = 0;
            this.lblDocumentNumbers.Text = "Número de Documentos:";
            // 
            // txtDocsNumber
            // 
            this.txtDocsNumber.AllowBlankSpaces = true;
            this.txtDocsNumber.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtDocsNumber.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.OnlyNumbers;
            this.txtDocsNumber.CustomExpression = ".*";
            this.txtDocsNumber.EnterColor = System.Drawing.Color.Empty;
            this.txtDocsNumber.LeaveColor = System.Drawing.Color.Empty;
            this.txtDocsNumber.Location = new System.Drawing.Point(170, 33);
            this.txtDocsNumber.MaxLength = 1;
            this.txtDocsNumber.Name = "txtDocsNumber";
            this.txtDocsNumber.Size = new System.Drawing.Size(20, 20);
            this.txtDocsNumber.TabIndex = 1;
            this.txtDocsNumber.TextChanged += new System.EventHandler(this.txtControls_TextChanged);
            this.txtDocsNumber.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // lblAccountLines
            // 
            this.lblAccountLines.AutoSize = true;
            this.lblAccountLines.ForeColor = System.Drawing.Color.DarkCyan;
            this.lblAccountLines.Location = new System.Drawing.Point(39, 87);
            this.lblAccountLines.Name = "lblAccountLines";
            this.lblAccountLines.Size = new System.Drawing.Size(93, 13);
            this.lblAccountLines.TabIndex = 0;
            this.lblAccountLines.Text = "Líneas Contables:";
            // 
            // lblLineRange
            // 
            this.lblLineRange.AutoSize = true;
            this.lblLineRange.ForeColor = System.Drawing.Color.DarkCyan;
            this.lblLineRange.Location = new System.Drawing.Point(245, 87);
            this.lblLineRange.Name = "lblLineRange";
            this.lblLineRange.Size = new System.Drawing.Size(39, 13);
            this.lblLineRange.TabIndex = 0;
            this.lblLineRange.Text = "Rango";
            // 
            // lblLineNumber
            // 
            this.lblLineNumber.AutoSize = true;
            this.lblLineNumber.ForeColor = System.Drawing.Color.DarkCyan;
            this.lblLineNumber.Location = new System.Drawing.Point(192, 87);
            this.lblLineNumber.Name = "lblLineNumber";
            this.lblLineNumber.Size = new System.Drawing.Size(35, 13);
            this.lblLineNumber.TabIndex = 0;
            this.lblLineNumber.Text = "Línea";
            // 
            // txtLineRange1
            // 
            this.txtLineRange1.AllowBlankSpaces = false;
            this.txtLineRange1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtLineRange1.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.OnlyNumbers;
            this.txtLineRange1.CustomExpression = ".*";
            this.txtLineRange1.EnterColor = System.Drawing.Color.Empty;
            this.txtLineRange1.LeaveColor = System.Drawing.Color.Empty;
            this.txtLineRange1.Location = new System.Drawing.Point(248, 113);
            this.txtLineRange1.MaxLength = 2;
            this.txtLineRange1.Name = "txtLineRange1";
            this.txtLineRange1.Size = new System.Drawing.Size(25, 20);
            this.txtLineRange1.TabIndex = 3;
            this.txtLineRange1.TextChanged += new System.EventHandler(this.txtControls_TextChanged);
            this.txtLineRange1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // txtLineNumber1
            // 
            this.txtLineNumber1.AllowBlankSpaces = false;
            this.txtLineNumber1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtLineNumber1.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.OnlyNumbers;
            this.txtLineNumber1.CustomExpression = ".*";
            this.txtLineNumber1.EnterColor = System.Drawing.Color.Empty;
            this.txtLineNumber1.LeaveColor = System.Drawing.Color.Empty;
            this.txtLineNumber1.Location = new System.Drawing.Point(197, 111);
            this.txtLineNumber1.MaxLength = 2;
            this.txtLineNumber1.Name = "txtLineNumber1";
            this.txtLineNumber1.Size = new System.Drawing.Size(25, 20);
            this.txtLineNumber1.TabIndex = 2;
            this.txtLineNumber1.TextChanged += new System.EventHandler(this.txtControls_TextChanged);
            this.txtLineNumber1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // lblIndent
            // 
            this.lblIndent.AutoSize = true;
            this.lblIndent.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIndent.ForeColor = System.Drawing.Color.Black;
            this.lblIndent.Location = new System.Drawing.Point(228, 111);
            this.lblIndent.Name = "lblIndent";
            this.lblIndent.Size = new System.Drawing.Size(14, 20);
            this.lblIndent.TabIndex = 0;
            this.lblIndent.Text = "-";
            // 
            // txtLineRange2
            // 
            this.txtLineRange2.AllowBlankSpaces = false;
            this.txtLineRange2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtLineRange2.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.OnlyNumbers;
            this.txtLineRange2.CustomExpression = ".*";
            this.txtLineRange2.EnterColor = System.Drawing.Color.Empty;
            this.txtLineRange2.LeaveColor = System.Drawing.Color.Empty;
            this.txtLineRange2.Location = new System.Drawing.Point(248, 146);
            this.txtLineRange2.MaxLength = 2;
            this.txtLineRange2.Name = "txtLineRange2";
            this.txtLineRange2.Size = new System.Drawing.Size(25, 20);
            this.txtLineRange2.TabIndex = 5;
            this.txtLineRange2.TextChanged += new System.EventHandler(this.txtControls_TextChanged);
            this.txtLineRange2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // txtLineNumber2
            // 
            this.txtLineNumber2.AllowBlankSpaces = false;
            this.txtLineNumber2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtLineNumber2.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.OnlyNumbers;
            this.txtLineNumber2.CustomExpression = ".*";
            this.txtLineNumber2.EnterColor = System.Drawing.Color.Empty;
            this.txtLineNumber2.LeaveColor = System.Drawing.Color.Empty;
            this.txtLineNumber2.Location = new System.Drawing.Point(197, 146);
            this.txtLineNumber2.MaxLength = 2;
            this.txtLineNumber2.Name = "txtLineNumber2";
            this.txtLineNumber2.Size = new System.Drawing.Size(25, 20);
            this.txtLineNumber2.TabIndex = 4;
            this.txtLineNumber2.TextChanged += new System.EventHandler(this.txtControls_TextChanged);
            this.txtLineNumber2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // lblIndent2
            // 
            this.lblIndent2.AutoSize = true;
            this.lblIndent2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIndent2.ForeColor = System.Drawing.Color.Black;
            this.lblIndent2.Location = new System.Drawing.Point(228, 144);
            this.lblIndent2.Name = "lblIndent2";
            this.lblIndent2.Size = new System.Drawing.Size(14, 20);
            this.lblIndent2.TabIndex = 0;
            this.lblIndent2.Text = "-";
            // 
            // txtLineRange3
            // 
            this.txtLineRange3.AllowBlankSpaces = false;
            this.txtLineRange3.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtLineRange3.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.OnlyNumbers;
            this.txtLineRange3.CustomExpression = ".*";
            this.txtLineRange3.EnterColor = System.Drawing.Color.Empty;
            this.txtLineRange3.LeaveColor = System.Drawing.Color.Empty;
            this.txtLineRange3.Location = new System.Drawing.Point(248, 179);
            this.txtLineRange3.MaxLength = 2;
            this.txtLineRange3.Name = "txtLineRange3";
            this.txtLineRange3.Size = new System.Drawing.Size(25, 20);
            this.txtLineRange3.TabIndex = 7;
            this.txtLineRange3.TextChanged += new System.EventHandler(this.txtControls_TextChanged);
            this.txtLineRange3.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // txtLineNumber3
            // 
            this.txtLineNumber3.AllowBlankSpaces = false;
            this.txtLineNumber3.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtLineNumber3.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.OnlyNumbers;
            this.txtLineNumber3.CustomExpression = ".*";
            this.txtLineNumber3.EnterColor = System.Drawing.Color.Empty;
            this.txtLineNumber3.LeaveColor = System.Drawing.Color.Empty;
            this.txtLineNumber3.Location = new System.Drawing.Point(197, 179);
            this.txtLineNumber3.MaxLength = 2;
            this.txtLineNumber3.Name = "txtLineNumber3";
            this.txtLineNumber3.Size = new System.Drawing.Size(25, 20);
            this.txtLineNumber3.TabIndex = 6;
            this.txtLineNumber3.TextChanged += new System.EventHandler(this.txtControls_TextChanged);
            this.txtLineNumber3.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // lblIndent3
            // 
            this.lblIndent3.AutoSize = true;
            this.lblIndent3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIndent3.ForeColor = System.Drawing.Color.Black;
            this.lblIndent3.Location = new System.Drawing.Point(228, 177);
            this.lblIndent3.Name = "lblIndent3";
            this.lblIndent3.Size = new System.Drawing.Size(14, 20);
            this.lblIndent3.TabIndex = 0;
            this.lblIndent3.Text = "-";
            // 
            // lblPaxNumber
            // 
            this.lblPaxNumber.AutoSize = true;
            this.lblPaxNumber.ForeColor = System.Drawing.Color.DarkCyan;
            this.lblPaxNumber.Location = new System.Drawing.Point(39, 230);
            this.lblPaxNumber.Name = "lblPaxNumber";
            this.lblPaxNumber.Size = new System.Drawing.Size(56, 13);
            this.lblPaxNumber.TabIndex = 0;
            this.lblPaxNumber.Text = "Num. Pax:";
            // 
            // lblPaxRange
            // 
            this.lblPaxRange.AutoSize = true;
            this.lblPaxRange.ForeColor = System.Drawing.Color.DarkCyan;
            this.lblPaxRange.Location = new System.Drawing.Point(245, 230);
            this.lblPaxRange.Name = "lblPaxRange";
            this.lblPaxRange.Size = new System.Drawing.Size(39, 13);
            this.lblPaxRange.TabIndex = 0;
            this.lblPaxRange.Text = "Rango";
            // 
            // lblNumber
            // 
            this.lblNumber.AutoSize = true;
            this.lblNumber.ForeColor = System.Drawing.Color.DarkCyan;
            this.lblNumber.Location = new System.Drawing.Point(186, 230);
            this.lblNumber.Name = "lblNumber";
            this.lblNumber.Size = new System.Drawing.Size(44, 13);
            this.lblNumber.TabIndex = 0;
            this.lblNumber.Text = "Número";
            // 
            // txtPaxNumber1
            // 
            this.txtPaxNumber1.AllowBlankSpaces = false;
            this.txtPaxNumber1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtPaxNumber1.CharsIncluded = new char[] {
        '.'};
            this.txtPaxNumber1.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.OnlyNumbers;
            this.txtPaxNumber1.CustomExpression = "@\"^[0-9]{1,2}[.]{1}[0-9]{1}$\"";
            this.txtPaxNumber1.EnterColor = System.Drawing.Color.Empty;
            this.txtPaxNumber1.LeaveColor = System.Drawing.Color.Empty;
            this.txtPaxNumber1.Location = new System.Drawing.Point(193, 257);
            this.txtPaxNumber1.MaxLength = 4;
            this.txtPaxNumber1.Name = "txtPaxNumber1";
            this.txtPaxNumber1.Size = new System.Drawing.Size(35, 20);
            this.txtPaxNumber1.TabIndex = 8;
            this.txtPaxNumber1.TextChanged += new System.EventHandler(this.txtControls_TextChanged);
            this.txtPaxNumber1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // lblIndent4
            // 
            this.lblIndent4.AutoSize = true;
            this.lblIndent4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIndent4.ForeColor = System.Drawing.Color.Black;
            this.lblIndent4.Location = new System.Drawing.Point(231, 255);
            this.lblIndent4.Name = "lblIndent4";
            this.lblIndent4.Size = new System.Drawing.Size(14, 20);
            this.lblIndent4.TabIndex = 0;
            this.lblIndent4.Text = "-";
            // 
            // txtRangePaxNumber1
            // 
            this.txtRangePaxNumber1.AllowBlankSpaces = false;
            this.txtRangePaxNumber1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtRangePaxNumber1.CharsIncluded = new char[] {
        '.'};
            this.txtRangePaxNumber1.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.OnlyNumbers;
            this.txtRangePaxNumber1.CustomExpression = "@\"^[0-9]{1,2}[.]{1}[0-9]{1}$\"";
            this.txtRangePaxNumber1.EnterColor = System.Drawing.Color.Empty;
            this.txtRangePaxNumber1.LeaveColor = System.Drawing.Color.Empty;
            this.txtRangePaxNumber1.Location = new System.Drawing.Point(248, 257);
            this.txtRangePaxNumber1.MaxLength = 4;
            this.txtRangePaxNumber1.Name = "txtRangePaxNumber1";
            this.txtRangePaxNumber1.Size = new System.Drawing.Size(35, 20);
            this.txtRangePaxNumber1.TabIndex = 9;
            this.txtRangePaxNumber1.TextChanged += new System.EventHandler(this.txtControls_TextChanged);
            this.txtRangePaxNumber1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // txtRangePaxNumber2
            // 
            this.txtRangePaxNumber2.AllowBlankSpaces = false;
            this.txtRangePaxNumber2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtRangePaxNumber2.CharsIncluded = new char[] {
        '.'};
            this.txtRangePaxNumber2.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.OnlyNumbers;
            this.txtRangePaxNumber2.CustomExpression = "@\"^[0-9]{1,2}[.]{1}[0-9]{1}$\"";
            this.txtRangePaxNumber2.EnterColor = System.Drawing.Color.Empty;
            this.txtRangePaxNumber2.LeaveColor = System.Drawing.Color.Empty;
            this.txtRangePaxNumber2.Location = new System.Drawing.Point(248, 288);
            this.txtRangePaxNumber2.MaxLength = 4;
            this.txtRangePaxNumber2.Name = "txtRangePaxNumber2";
            this.txtRangePaxNumber2.Size = new System.Drawing.Size(35, 20);
            this.txtRangePaxNumber2.TabIndex = 11;
            this.txtRangePaxNumber2.TextChanged += new System.EventHandler(this.txtControls_TextChanged);
            this.txtRangePaxNumber2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // lblIndent5
            // 
            this.lblIndent5.AutoSize = true;
            this.lblIndent5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIndent5.ForeColor = System.Drawing.Color.Black;
            this.lblIndent5.Location = new System.Drawing.Point(231, 286);
            this.lblIndent5.Name = "lblIndent5";
            this.lblIndent5.Size = new System.Drawing.Size(14, 20);
            this.lblIndent5.TabIndex = 0;
            this.lblIndent5.Text = "-";
            // 
            // txtPaxNumber2
            // 
            this.txtPaxNumber2.AllowBlankSpaces = false;
            this.txtPaxNumber2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtPaxNumber2.CharsIncluded = new char[] {
        '.'};
            this.txtPaxNumber2.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.OnlyNumbers;
            this.txtPaxNumber2.CustomExpression = "@\"^[0-9]{1,2}[.]{1}[0-9]{1}$\"";
            this.txtPaxNumber2.EnterColor = System.Drawing.Color.Empty;
            this.txtPaxNumber2.LeaveColor = System.Drawing.Color.Empty;
            this.txtPaxNumber2.Location = new System.Drawing.Point(193, 288);
            this.txtPaxNumber2.MaxLength = 4;
            this.txtPaxNumber2.Name = "txtPaxNumber2";
            this.txtPaxNumber2.Size = new System.Drawing.Size(35, 20);
            this.txtPaxNumber2.TabIndex = 10;
            this.txtPaxNumber2.TextChanged += new System.EventHandler(this.txtControls_TextChanged);
            this.txtPaxNumber2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // txtRangePaxNumber3
            // 
            this.txtRangePaxNumber3.AllowBlankSpaces = false;
            this.txtRangePaxNumber3.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtRangePaxNumber3.CharsIncluded = new char[] {
        '.'};
            this.txtRangePaxNumber3.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.OnlyNumbers;
            this.txtRangePaxNumber3.CustomExpression = "@\"^[0-9]{1,2}[.]{1}[0-9]{1}$\"";
            this.txtRangePaxNumber3.EnterColor = System.Drawing.Color.Empty;
            this.txtRangePaxNumber3.LeaveColor = System.Drawing.Color.Empty;
            this.txtRangePaxNumber3.Location = new System.Drawing.Point(248, 320);
            this.txtRangePaxNumber3.MaxLength = 4;
            this.txtRangePaxNumber3.Name = "txtRangePaxNumber3";
            this.txtRangePaxNumber3.Size = new System.Drawing.Size(35, 20);
            this.txtRangePaxNumber3.TabIndex = 13;
            this.txtRangePaxNumber3.TextChanged += new System.EventHandler(this.txtControls_TextChanged);
            this.txtRangePaxNumber3.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // lblIndent6
            // 
            this.lblIndent6.AutoSize = true;
            this.lblIndent6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIndent6.ForeColor = System.Drawing.Color.Black;
            this.lblIndent6.Location = new System.Drawing.Point(231, 318);
            this.lblIndent6.Name = "lblIndent6";
            this.lblIndent6.Size = new System.Drawing.Size(14, 20);
            this.lblIndent6.TabIndex = 0;
            this.lblIndent6.Text = "-";
            // 
            // txtPaxNumber3
            // 
            this.txtPaxNumber3.AllowBlankSpaces = false;
            this.txtPaxNumber3.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtPaxNumber3.CharsIncluded = new char[] {
        '.'};
            this.txtPaxNumber3.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.OnlyNumbers;
            this.txtPaxNumber3.CustomExpression = "@\"^[0-9]{1,2}[.]{1}[0-9]{1}$\"";
            this.txtPaxNumber3.EnterColor = System.Drawing.Color.Empty;
            this.txtPaxNumber3.LeaveColor = System.Drawing.Color.Empty;
            this.txtPaxNumber3.Location = new System.Drawing.Point(193, 320);
            this.txtPaxNumber3.MaxLength = 4;
            this.txtPaxNumber3.Name = "txtPaxNumber3";
            this.txtPaxNumber3.Size = new System.Drawing.Size(35, 20);
            this.txtPaxNumber3.TabIndex = 12;
            this.txtPaxNumber3.TextChanged += new System.EventHandler(this.txtControls_TextChanged);
            this.txtPaxNumber3.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // txtRangeSegment3
            // 
            this.txtRangeSegment3.AllowBlankSpaces = false;
            this.txtRangeSegment3.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtRangeSegment3.CharsIncluded = new char[0];
            this.txtRangeSegment3.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.OnlyNumbers;
            this.txtRangeSegment3.CustomExpression = "@\"^[0-9]{1,2}[.]{1}[0-9]{1}$\"";
            this.txtRangeSegment3.EnterColor = System.Drawing.Color.Empty;
            this.txtRangeSegment3.LeaveColor = System.Drawing.Color.Empty;
            this.txtRangeSegment3.Location = new System.Drawing.Point(248, 453);
            this.txtRangeSegment3.MaxLength = 2;
            this.txtRangeSegment3.Name = "txtRangeSegment3";
            this.txtRangeSegment3.Size = new System.Drawing.Size(25, 20);
            this.txtRangeSegment3.TabIndex = 19;
            this.txtRangeSegment3.TextChanged += new System.EventHandler(this.txtControls_TextChanged);
            this.txtRangeSegment3.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // lblIndent9
            // 
            this.lblIndent9.AutoSize = true;
            this.lblIndent9.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIndent9.ForeColor = System.Drawing.Color.Black;
            this.lblIndent9.Location = new System.Drawing.Point(228, 451);
            this.lblIndent9.Name = "lblIndent9";
            this.lblIndent9.Size = new System.Drawing.Size(14, 20);
            this.lblIndent9.TabIndex = 0;
            this.lblIndent9.Text = "-";
            // 
            // txtSegment3
            // 
            this.txtSegment3.AllowBlankSpaces = false;
            this.txtSegment3.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtSegment3.CharsIncluded = new char[0];
            this.txtSegment3.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.OnlyNumbers;
            this.txtSegment3.CustomExpression = "@\"^[0-9]{1,2}[.]{1}[0-9]{1}$\"";
            this.txtSegment3.EnterColor = System.Drawing.Color.Empty;
            this.txtSegment3.LeaveColor = System.Drawing.Color.Empty;
            this.txtSegment3.Location = new System.Drawing.Point(197, 453);
            this.txtSegment3.MaxLength = 2;
            this.txtSegment3.Name = "txtSegment3";
            this.txtSegment3.Size = new System.Drawing.Size(25, 20);
            this.txtSegment3.TabIndex = 18;
            this.txtSegment3.TextChanged += new System.EventHandler(this.txtControls_TextChanged);
            this.txtSegment3.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // txtRangeSegment2
            // 
            this.txtRangeSegment2.AllowBlankSpaces = false;
            this.txtRangeSegment2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtRangeSegment2.CharsIncluded = new char[0];
            this.txtRangeSegment2.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.OnlyNumbers;
            this.txtRangeSegment2.CustomExpression = "@\"^[0-9]{1,2}[.]{1}[0-9]{1}$\"";
            this.txtRangeSegment2.EnterColor = System.Drawing.Color.Empty;
            this.txtRangeSegment2.LeaveColor = System.Drawing.Color.Empty;
            this.txtRangeSegment2.Location = new System.Drawing.Point(248, 421);
            this.txtRangeSegment2.MaxLength = 2;
            this.txtRangeSegment2.Name = "txtRangeSegment2";
            this.txtRangeSegment2.Size = new System.Drawing.Size(25, 20);
            this.txtRangeSegment2.TabIndex = 17;
            this.txtRangeSegment2.TextChanged += new System.EventHandler(this.txtControls_TextChanged);
            this.txtRangeSegment2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // lblIndent8
            // 
            this.lblIndent8.AutoSize = true;
            this.lblIndent8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIndent8.ForeColor = System.Drawing.Color.Black;
            this.lblIndent8.Location = new System.Drawing.Point(228, 419);
            this.lblIndent8.Name = "lblIndent8";
            this.lblIndent8.Size = new System.Drawing.Size(14, 20);
            this.lblIndent8.TabIndex = 0;
            this.lblIndent8.Text = "-";
            // 
            // txtSegment2
            // 
            this.txtSegment2.AllowBlankSpaces = false;
            this.txtSegment2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtSegment2.CharsIncluded = new char[0];
            this.txtSegment2.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.OnlyNumbers;
            this.txtSegment2.CustomExpression = "@\"^[0-9]{1,2}[.]{1}[0-9]{1}$\"";
            this.txtSegment2.EnterColor = System.Drawing.Color.Empty;
            this.txtSegment2.LeaveColor = System.Drawing.Color.Empty;
            this.txtSegment2.Location = new System.Drawing.Point(197, 421);
            this.txtSegment2.MaxLength = 2;
            this.txtSegment2.Name = "txtSegment2";
            this.txtSegment2.Size = new System.Drawing.Size(25, 20);
            this.txtSegment2.TabIndex = 16;
            this.txtSegment2.TextChanged += new System.EventHandler(this.txtControls_TextChanged);
            this.txtSegment2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // txtRangeSegment
            // 
            this.txtRangeSegment.AllowBlankSpaces = false;
            this.txtRangeSegment.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtRangeSegment.CharsIncluded = new char[0];
            this.txtRangeSegment.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.OnlyNumbers;
            this.txtRangeSegment.CustomExpression = "@\"^[0-9]{1,2}[.]{1}[0-9]{1}$\"";
            this.txtRangeSegment.EnterColor = System.Drawing.Color.Empty;
            this.txtRangeSegment.LeaveColor = System.Drawing.Color.Empty;
            this.txtRangeSegment.Location = new System.Drawing.Point(248, 390);
            this.txtRangeSegment.MaxLength = 2;
            this.txtRangeSegment.Name = "txtRangeSegment";
            this.txtRangeSegment.Size = new System.Drawing.Size(25, 20);
            this.txtRangeSegment.TabIndex = 15;
            this.txtRangeSegment.TextChanged += new System.EventHandler(this.txtControls_TextChanged);
            this.txtRangeSegment.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // lblIndent7
            // 
            this.lblIndent7.AutoSize = true;
            this.lblIndent7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIndent7.ForeColor = System.Drawing.Color.Black;
            this.lblIndent7.Location = new System.Drawing.Point(228, 388);
            this.lblIndent7.Name = "lblIndent7";
            this.lblIndent7.Size = new System.Drawing.Size(14, 20);
            this.lblIndent7.TabIndex = 0;
            this.lblIndent7.Text = "-";
            // 
            // txtSegment1
            // 
            this.txtSegment1.AllowBlankSpaces = false;
            this.txtSegment1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtSegment1.CharsIncluded = new char[0];
            this.txtSegment1.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.OnlyNumbers;
            this.txtSegment1.CustomExpression = "@\"^[0-9]{1,2}[.]{1}[0-9]{1}$\"";
            this.txtSegment1.EnterColor = System.Drawing.Color.Empty;
            this.txtSegment1.LeaveColor = System.Drawing.Color.Empty;
            this.txtSegment1.Location = new System.Drawing.Point(197, 390);
            this.txtSegment1.MaxLength = 2;
            this.txtSegment1.Name = "txtSegment1";
            this.txtSegment1.Size = new System.Drawing.Size(25, 20);
            this.txtSegment1.TabIndex = 14;
            this.txtSegment1.TextChanged += new System.EventHandler(this.txtControls_TextChanged);
            this.txtSegment1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // lblRangeSegment
            // 
            this.lblRangeSegment.AutoSize = true;
            this.lblRangeSegment.ForeColor = System.Drawing.Color.DarkCyan;
            this.lblRangeSegment.Location = new System.Drawing.Point(245, 364);
            this.lblRangeSegment.Name = "lblRangeSegment";
            this.lblRangeSegment.Size = new System.Drawing.Size(39, 13);
            this.lblRangeSegment.TabIndex = 0;
            this.lblRangeSegment.Text = "Rango";
            // 
            // lblSegment
            // 
            this.lblSegment.AutoSize = true;
            this.lblSegment.ForeColor = System.Drawing.Color.DarkCyan;
            this.lblSegment.Location = new System.Drawing.Point(182, 364);
            this.lblSegment.Name = "lblSegment";
            this.lblSegment.Size = new System.Drawing.Size(55, 13);
            this.lblSegment.TabIndex = 0;
            this.lblSegment.Text = "Segmento";
            // 
            // lblSegments
            // 
            this.lblSegments.AutoSize = true;
            this.lblSegments.ForeColor = System.Drawing.Color.DarkCyan;
            this.lblSegments.Location = new System.Drawing.Point(39, 364);
            this.lblSegments.Name = "lblSegments";
            this.lblSegments.Size = new System.Drawing.Size(63, 13);
            this.lblSegments.TabIndex = 0;
            this.lblSegments.Text = "Segmentos:";
            // 
            // lblEmptyforAll
            // 
            this.lblEmptyforAll.AutoSize = true;
            this.lblEmptyforAll.ForeColor = System.Drawing.Color.Blue;
            this.lblEmptyforAll.Location = new System.Drawing.Point(39, 492);
            this.lblEmptyforAll.Name = "lblEmptyforAll";
            this.lblEmptyforAll.Size = new System.Drawing.Size(193, 13);
            this.lblEmptyforAll.TabIndex = 0;
            this.lblEmptyforAll.Text = "\"ENTER\" EN BLANCO PARA TODAS:";
            // 
            // btnAccept
            // 
            this.btnAccept.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnAccept.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAccept.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAccept.Location = new System.Drawing.Point(257, 527);
            this.btnAccept.Name = "btnAccept";
            this.btnAccept.Size = new System.Drawing.Size(100, 23);
            this.btnAccept.TabIndex = 21;
            this.btnAccept.Text = "Aceptar";
            this.btnAccept.UseVisualStyleBackColor = false;
            this.btnAccept.Click += new System.EventHandler(this.btnAccept_Click);
            // 
            // ucSendTicketInvoice
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.btnAccept);
            this.Controls.Add(this.lblEmptyforAll);
            this.Controls.Add(this.txtRangeSegment3);
            this.Controls.Add(this.lblIndent9);
            this.Controls.Add(this.txtSegment3);
            this.Controls.Add(this.txtRangeSegment2);
            this.Controls.Add(this.lblIndent8);
            this.Controls.Add(this.txtSegment2);
            this.Controls.Add(this.txtRangeSegment);
            this.Controls.Add(this.lblIndent7);
            this.Controls.Add(this.txtSegment1);
            this.Controls.Add(this.lblRangeSegment);
            this.Controls.Add(this.lblSegment);
            this.Controls.Add(this.lblSegments);
            this.Controls.Add(this.txtRangePaxNumber3);
            this.Controls.Add(this.lblIndent6);
            this.Controls.Add(this.txtPaxNumber3);
            this.Controls.Add(this.txtRangePaxNumber2);
            this.Controls.Add(this.lblIndent5);
            this.Controls.Add(this.txtPaxNumber2);
            this.Controls.Add(this.txtRangePaxNumber1);
            this.Controls.Add(this.lblIndent4);
            this.Controls.Add(this.txtPaxNumber1);
            this.Controls.Add(this.lblPaxRange);
            this.Controls.Add(this.lblNumber);
            this.Controls.Add(this.lblPaxNumber);
            this.Controls.Add(this.txtLineRange3);
            this.Controls.Add(this.txtLineNumber3);
            this.Controls.Add(this.lblIndent3);
            this.Controls.Add(this.txtLineRange2);
            this.Controls.Add(this.txtLineNumber2);
            this.Controls.Add(this.lblIndent2);
            this.Controls.Add(this.lblLineRange);
            this.Controls.Add(this.lblLineNumber);
            this.Controls.Add(this.txtLineRange1);
            this.Controls.Add(this.txtLineNumber1);
            this.Controls.Add(this.lblIndent);
            this.Controls.Add(this.lblAccountLines);
            this.Controls.Add(this.txtDocsNumber);
            this.Controls.Add(this.lblDocumentNumbers);
            this.Controls.Add(this.lblTitle);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "ucSendTicketInvoice";
            this.Size = new System.Drawing.Size(411, 580);
            this.Load += new System.EventHandler(this.ucSendTicketInvoice_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblDocumentNumbers;
        private MyCTS.Forms.UI.SmartTextBox txtDocsNumber;
        private System.Windows.Forms.Label lblAccountLines;
        private System.Windows.Forms.Label lblLineRange;
        private System.Windows.Forms.Label lblLineNumber;
        private MyCTS.Forms.UI.SmartTextBox txtLineRange1;
        private MyCTS.Forms.UI.SmartTextBox txtLineNumber1;
        private System.Windows.Forms.Label lblIndent;
        private MyCTS.Forms.UI.SmartTextBox txtLineRange2;
        private MyCTS.Forms.UI.SmartTextBox txtLineNumber2;
        private System.Windows.Forms.Label lblIndent2;
        private MyCTS.Forms.UI.SmartTextBox txtLineRange3;
        private MyCTS.Forms.UI.SmartTextBox txtLineNumber3;
        private System.Windows.Forms.Label lblIndent3;
        private System.Windows.Forms.Label lblPaxNumber;
        private System.Windows.Forms.Label lblPaxRange;
        private System.Windows.Forms.Label lblNumber;
        private MyCTS.Forms.UI.SmartTextBox txtPaxNumber1;
        private System.Windows.Forms.Label lblIndent4;
        private MyCTS.Forms.UI.SmartTextBox txtRangePaxNumber1;
        private MyCTS.Forms.UI.SmartTextBox txtRangePaxNumber2;
        private System.Windows.Forms.Label lblIndent5;
        private MyCTS.Forms.UI.SmartTextBox txtPaxNumber2;
        private MyCTS.Forms.UI.SmartTextBox txtRangePaxNumber3;
        private System.Windows.Forms.Label lblIndent6;
        private MyCTS.Forms.UI.SmartTextBox txtPaxNumber3;
        private MyCTS.Forms.UI.SmartTextBox txtRangeSegment3;
        private System.Windows.Forms.Label lblIndent9;
        private MyCTS.Forms.UI.SmartTextBox txtSegment3;
        private MyCTS.Forms.UI.SmartTextBox txtRangeSegment2;
        private System.Windows.Forms.Label lblIndent8;
        private MyCTS.Forms.UI.SmartTextBox txtSegment2;
        private MyCTS.Forms.UI.SmartTextBox txtRangeSegment;
        private System.Windows.Forms.Label lblIndent7;
        private MyCTS.Forms.UI.SmartTextBox txtSegment1;
        private System.Windows.Forms.Label lblRangeSegment;
        private System.Windows.Forms.Label lblSegment;
        private System.Windows.Forms.Label lblSegments;
        private System.Windows.Forms.Label lblEmptyforAll;
        private System.Windows.Forms.Button btnAccept;
    }
}
