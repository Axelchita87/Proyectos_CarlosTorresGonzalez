namespace MyCTS.Presentation
{
    partial class ucFrecuentFligher
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
            this.rdoAdd = new System.Windows.Forms.RadioButton();
            this.lblLine = new System.Windows.Forms.Label();
            this.rdoDelete = new System.Windows.Forms.RadioButton();
            this.lblLineNumber = new System.Windows.Forms.Label();
            this.lblRange = new System.Windows.Forms.Label();
            this.txtLineNumber = new MyCTS.Forms.UI.SmartTextBox();
            this.lblIndent = new System.Windows.Forms.Label();
            this.txtRange = new MyCTS.Forms.UI.SmartTextBox();
            this.pnlAdd = new System.Windows.Forms.Panel();
            this.txtOtherAirLine3 = new MyCTS.Forms.UI.SmartTextBox();
            this.txtPaxNumber3 = new MyCTS.Forms.UI.SmartTextBox();
            this.txtFFnumber3 = new MyCTS.Forms.UI.SmartTextBox();
            this.txtAirline3 = new MyCTS.Forms.UI.SmartTextBox();
            this.txtOtherAirline2 = new MyCTS.Forms.UI.SmartTextBox();
            this.txtPaxNumber2 = new MyCTS.Forms.UI.SmartTextBox();
            this.txtFFnumber2 = new MyCTS.Forms.UI.SmartTextBox();
            this.txtAirline2 = new MyCTS.Forms.UI.SmartTextBox();
            this.txtOtherAirline1 = new MyCTS.Forms.UI.SmartTextBox();
            this.txtPaxNumber1 = new MyCTS.Forms.UI.SmartTextBox();
            this.txtFFnumber1 = new MyCTS.Forms.UI.SmartTextBox();
            this.txtAirline1 = new MyCTS.Forms.UI.SmartTextBox();
            this.lblOtherAirline = new System.Windows.Forms.Label();
            this.lblPaxNumber = new System.Windows.Forms.Label();
            this.lblFFnumber = new System.Windows.Forms.Label();
            this.lblAirLine = new System.Windows.Forms.Label();
            this.pnlDelete = new System.Windows.Forms.Panel();
            this.pnlAdd.SuspendLayout();
            this.pnlDelete.SuspendLayout();
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
            this.lblTitle.Text = "Viajero Frecuente";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // btnAccept
            // 
            this.btnAccept.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnAccept.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAccept.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAccept.Location = new System.Drawing.Point(279, 388);
            this.btnAccept.Name = "btnAccept";
            this.btnAccept.Size = new System.Drawing.Size(100, 23);
            this.btnAccept.TabIndex = 20;
            this.btnAccept.Text = "Aceptar";
            this.btnAccept.UseVisualStyleBackColor = false;
            this.btnAccept.Click += new System.EventHandler(this.btnAccept_Click);
            // 
            // rdoAdd
            // 
            this.rdoAdd.AutoSize = true;
            this.rdoAdd.Location = new System.Drawing.Point(19, 49);
            this.rdoAdd.Name = "rdoAdd";
            this.rdoAdd.Size = new System.Drawing.Size(62, 17);
            this.rdoAdd.TabIndex = 1;
            this.rdoAdd.TabStop = true;
            this.rdoAdd.Text = "Agregar";
            this.rdoAdd.UseVisualStyleBackColor = true;
            this.rdoAdd.CheckedChanged += new System.EventHandler(this.rdoAdd_CheckedChanged);
            this.rdoAdd.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // lblLine
            // 
            this.lblLine.AutoSize = true;
            this.lblLine.Location = new System.Drawing.Point(7, 259);
            this.lblLine.Name = "lblLine";
            this.lblLine.Size = new System.Drawing.Size(391, 13);
            this.lblLine.TabIndex = 0;
            this.lblLine.Text = "________________________________________________________________";
            // 
            // rdoDelete
            // 
            this.rdoDelete.AutoSize = true;
            this.rdoDelete.Location = new System.Drawing.Point(19, 297);
            this.rdoDelete.Name = "rdoDelete";
            this.rdoDelete.Size = new System.Drawing.Size(53, 17);
            this.rdoDelete.TabIndex = 16;
            this.rdoDelete.TabStop = true;
            this.rdoDelete.Text = "Borrar";
            this.rdoDelete.UseVisualStyleBackColor = true;
            this.rdoDelete.CheckedChanged += new System.EventHandler(this.rdoDelete_CheckedChanged);
            this.rdoDelete.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // lblLineNumber
            // 
            this.lblLineNumber.AutoSize = true;
            this.lblLineNumber.ForeColor = System.Drawing.Color.DarkCyan;
            this.lblLineNumber.Location = new System.Drawing.Point(8, 14);
            this.lblLineNumber.Name = "lblLineNumber";
            this.lblLineNumber.Size = new System.Drawing.Size(35, 13);
            this.lblLineNumber.TabIndex = 0;
            this.lblLineNumber.Text = "Línea";
            // 
            // lblRange
            // 
            this.lblRange.AutoSize = true;
            this.lblRange.ForeColor = System.Drawing.Color.DarkCyan;
            this.lblRange.Location = new System.Drawing.Point(61, 14);
            this.lblRange.Name = "lblRange";
            this.lblRange.Size = new System.Drawing.Size(39, 13);
            this.lblRange.TabIndex = 0;
            this.lblRange.Text = "Rango";
            // 
            // txtLineNumber
            // 
            this.txtLineNumber.AllowBlankSpaces = false;
            this.txtLineNumber.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtLineNumber.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.OnlyNumbers;
            this.txtLineNumber.CustomExpression = ".*";
            this.txtLineNumber.EnterColor = System.Drawing.Color.Empty;
            this.txtLineNumber.LeaveColor = System.Drawing.Color.Empty;
            this.txtLineNumber.Location = new System.Drawing.Point(13, 40);
            this.txtLineNumber.MaxLength = 2;
            this.txtLineNumber.Name = "txtLineNumber";
            this.txtLineNumber.Size = new System.Drawing.Size(25, 20);
            this.txtLineNumber.TabIndex = 18;
            this.txtLineNumber.TextChanged += new System.EventHandler(this.DeleteTxtControls_TextChanged);
            this.txtLineNumber.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // lblIndent
            // 
            this.lblIndent.AutoSize = true;
            this.lblIndent.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIndent.ForeColor = System.Drawing.Color.Black;
            this.lblIndent.Location = new System.Drawing.Point(44, 38);
            this.lblIndent.Name = "lblIndent";
            this.lblIndent.Size = new System.Drawing.Size(14, 20);
            this.lblIndent.TabIndex = 0;
            this.lblIndent.Text = "-";
            // 
            // txtRange
            // 
            this.txtRange.AllowBlankSpaces = false;
            this.txtRange.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtRange.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.OnlyNumbers;
            this.txtRange.CustomExpression = ".*";
            this.txtRange.EnterColor = System.Drawing.Color.Empty;
            this.txtRange.LeaveColor = System.Drawing.Color.Empty;
            this.txtRange.Location = new System.Drawing.Point(64, 40);
            this.txtRange.MaxLength = 2;
            this.txtRange.Name = "txtRange";
            this.txtRange.Size = new System.Drawing.Size(25, 20);
            this.txtRange.TabIndex = 19;
            this.txtRange.TextChanged += new System.EventHandler(this.DeleteTxtControls_TextChanged);
            this.txtRange.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // pnlAdd
            // 
            this.pnlAdd.Controls.Add(this.txtOtherAirLine3);
            this.pnlAdd.Controls.Add(this.txtPaxNumber3);
            this.pnlAdd.Controls.Add(this.txtFFnumber3);
            this.pnlAdd.Controls.Add(this.txtAirline3);
            this.pnlAdd.Controls.Add(this.txtOtherAirline2);
            this.pnlAdd.Controls.Add(this.txtPaxNumber2);
            this.pnlAdd.Controls.Add(this.txtFFnumber2);
            this.pnlAdd.Controls.Add(this.txtAirline2);
            this.pnlAdd.Controls.Add(this.txtOtherAirline1);
            this.pnlAdd.Controls.Add(this.txtPaxNumber1);
            this.pnlAdd.Controls.Add(this.txtFFnumber1);
            this.pnlAdd.Controls.Add(this.txtAirline1);
            this.pnlAdd.Controls.Add(this.lblOtherAirline);
            this.pnlAdd.Controls.Add(this.lblPaxNumber);
            this.pnlAdd.Controls.Add(this.lblFFnumber);
            this.pnlAdd.Controls.Add(this.lblAirLine);
            this.pnlAdd.Location = new System.Drawing.Point(45, 75);
            this.pnlAdd.Name = "pnlAdd";
            this.pnlAdd.Size = new System.Drawing.Size(353, 181);
            this.pnlAdd.TabIndex = 2;
            this.pnlAdd.TabStop = true;
            // 
            // txtOtherAirLine3
            // 
            this.txtOtherAirLine3.AllowBlankSpaces = false;
            this.txtOtherAirLine3.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtOtherAirLine3.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.NumbersOrLetters;
            this.txtOtherAirLine3.CustomExpression = ".*";
            this.txtOtherAirLine3.EnterColor = System.Drawing.Color.Empty;
            this.txtOtherAirLine3.LeaveColor = System.Drawing.Color.Empty;
            this.txtOtherAirLine3.Location = new System.Drawing.Point(300, 119);
            this.txtOtherAirLine3.MaxLength = 2;
            this.txtOtherAirLine3.Name = "txtOtherAirLine3";
            this.txtOtherAirLine3.Size = new System.Drawing.Size(25, 20);
            this.txtOtherAirLine3.TabIndex = 14;
            this.txtOtherAirLine3.TextChanged += new System.EventHandler(this.AddTxtControls_TextChanged);
            this.txtOtherAirLine3.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // txtPaxNumber3
            // 
            this.txtPaxNumber3.AllowBlankSpaces = false;
            this.txtPaxNumber3.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtPaxNumber3.CharsIncluded = new char[] {
        '.'};
            this.txtPaxNumber3.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.OnlyNumbers;
            this.txtPaxNumber3.CustomExpression = ".*";
            this.txtPaxNumber3.EnterColor = System.Drawing.Color.Empty;
            this.txtPaxNumber3.LeaveColor = System.Drawing.Color.Empty;
            this.txtPaxNumber3.Location = new System.Drawing.Point(220, 119);
            this.txtPaxNumber3.MaxLength = 4;
            this.txtPaxNumber3.Name = "txtPaxNumber3";
            this.txtPaxNumber3.Size = new System.Drawing.Size(35, 20);
            this.txtPaxNumber3.TabIndex = 13;
            this.txtPaxNumber3.TextChanged += new System.EventHandler(this.AddTxtControls_TextChanged);
            this.txtPaxNumber3.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // txtFFnumber3
            // 
            this.txtFFnumber3.AllowBlankSpaces = false;
            this.txtFFnumber3.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtFFnumber3.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.NumbersOrLetters;
            this.txtFFnumber3.CustomExpression = ".*";
            this.txtFFnumber3.EnterColor = System.Drawing.Color.Empty;
            this.txtFFnumber3.LeaveColor = System.Drawing.Color.Empty;
            this.txtFFnumber3.Location = new System.Drawing.Point(83, 119);
            this.txtFFnumber3.MaxLength = 16;
            this.txtFFnumber3.Name = "txtFFnumber3";
            this.txtFFnumber3.Size = new System.Drawing.Size(104, 20);
            this.txtFFnumber3.TabIndex = 12;
            this.txtFFnumber3.TextChanged += new System.EventHandler(this.AddTxtControls_TextChanged);
            this.txtFFnumber3.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // txtAirline3
            // 
            this.txtAirline3.AllowBlankSpaces = false;
            this.txtAirline3.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtAirline3.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.NumbersOrLetters;
            this.txtAirline3.CustomExpression = ".*";
            this.txtAirline3.EnterColor = System.Drawing.Color.Empty;
            this.txtAirline3.LeaveColor = System.Drawing.Color.Empty;
            this.txtAirline3.Location = new System.Drawing.Point(20, 119);
            this.txtAirline3.MaxLength = 2;
            this.txtAirline3.Name = "txtAirline3";
            this.txtAirline3.Size = new System.Drawing.Size(25, 20);
            this.txtAirline3.TabIndex = 11;
            this.txtAirline3.TextChanged += new System.EventHandler(this.AddTxtControls_TextChanged);
            this.txtAirline3.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // txtOtherAirline2
            // 
            this.txtOtherAirline2.AllowBlankSpaces = false;
            this.txtOtherAirline2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtOtherAirline2.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.NumbersOrLetters;
            this.txtOtherAirline2.CustomExpression = ".*";
            this.txtOtherAirline2.EnterColor = System.Drawing.Color.Empty;
            this.txtOtherAirline2.LeaveColor = System.Drawing.Color.Empty;
            this.txtOtherAirline2.Location = new System.Drawing.Point(300, 81);
            this.txtOtherAirline2.MaxLength = 2;
            this.txtOtherAirline2.Name = "txtOtherAirline2";
            this.txtOtherAirline2.Size = new System.Drawing.Size(25, 20);
            this.txtOtherAirline2.TabIndex = 10;
            this.txtOtherAirline2.TextChanged += new System.EventHandler(this.AddTxtControls_TextChanged);
            this.txtOtherAirline2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // txtPaxNumber2
            // 
            this.txtPaxNumber2.AllowBlankSpaces = false;
            this.txtPaxNumber2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtPaxNumber2.CharsIncluded = new char[] {
        '.'};
            this.txtPaxNumber2.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.OnlyNumbers;
            this.txtPaxNumber2.CustomExpression = ".*";
            this.txtPaxNumber2.EnterColor = System.Drawing.Color.Empty;
            this.txtPaxNumber2.LeaveColor = System.Drawing.Color.Empty;
            this.txtPaxNumber2.Location = new System.Drawing.Point(220, 81);
            this.txtPaxNumber2.MaxLength = 4;
            this.txtPaxNumber2.Name = "txtPaxNumber2";
            this.txtPaxNumber2.Size = new System.Drawing.Size(35, 20);
            this.txtPaxNumber2.TabIndex = 9;
            this.txtPaxNumber2.TextChanged += new System.EventHandler(this.AddTxtControls_TextChanged);
            this.txtPaxNumber2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // txtFFnumber2
            // 
            this.txtFFnumber2.AllowBlankSpaces = false;
            this.txtFFnumber2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtFFnumber2.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.NumbersOrLetters;
            this.txtFFnumber2.CustomExpression = ".*";
            this.txtFFnumber2.EnterColor = System.Drawing.Color.Empty;
            this.txtFFnumber2.LeaveColor = System.Drawing.Color.Empty;
            this.txtFFnumber2.Location = new System.Drawing.Point(83, 81);
            this.txtFFnumber2.MaxLength = 16;
            this.txtFFnumber2.Name = "txtFFnumber2";
            this.txtFFnumber2.Size = new System.Drawing.Size(104, 20);
            this.txtFFnumber2.TabIndex = 8;
            this.txtFFnumber2.TextChanged += new System.EventHandler(this.AddTxtControls_TextChanged);
            this.txtFFnumber2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // txtAirline2
            // 
            this.txtAirline2.AllowBlankSpaces = false;
            this.txtAirline2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtAirline2.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.NumbersOrLetters;
            this.txtAirline2.CustomExpression = ".*";
            this.txtAirline2.EnterColor = System.Drawing.Color.Empty;
            this.txtAirline2.LeaveColor = System.Drawing.Color.Empty;
            this.txtAirline2.Location = new System.Drawing.Point(20, 81);
            this.txtAirline2.MaxLength = 2;
            this.txtAirline2.Name = "txtAirline2";
            this.txtAirline2.Size = new System.Drawing.Size(25, 20);
            this.txtAirline2.TabIndex = 7;
            this.txtAirline2.TextChanged += new System.EventHandler(this.AddTxtControls_TextChanged);
            this.txtAirline2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // txtOtherAirline1
            // 
            this.txtOtherAirline1.AllowBlankSpaces = false;
            this.txtOtherAirline1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtOtherAirline1.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.NumbersOrLetters;
            this.txtOtherAirline1.CustomExpression = ".*";
            this.txtOtherAirline1.EnterColor = System.Drawing.Color.Empty;
            this.txtOtherAirline1.LeaveColor = System.Drawing.Color.Empty;
            this.txtOtherAirline1.Location = new System.Drawing.Point(300, 44);
            this.txtOtherAirline1.MaxLength = 2;
            this.txtOtherAirline1.Name = "txtOtherAirline1";
            this.txtOtherAirline1.Size = new System.Drawing.Size(25, 20);
            this.txtOtherAirline1.TabIndex = 6;
            this.txtOtherAirline1.TextChanged += new System.EventHandler(this.AddTxtControls_TextChanged);
            this.txtOtherAirline1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // txtPaxNumber1
            // 
            this.txtPaxNumber1.AllowBlankSpaces = false;
            this.txtPaxNumber1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtPaxNumber1.CharsIncluded = new char[] {
        '.'};
            this.txtPaxNumber1.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.OnlyNumbers;
            this.txtPaxNumber1.CustomExpression = ".*";
            this.txtPaxNumber1.EnterColor = System.Drawing.Color.Empty;
            this.txtPaxNumber1.LeaveColor = System.Drawing.Color.Empty;
            this.txtPaxNumber1.Location = new System.Drawing.Point(220, 44);
            this.txtPaxNumber1.MaxLength = 4;
            this.txtPaxNumber1.Name = "txtPaxNumber1";
            this.txtPaxNumber1.Size = new System.Drawing.Size(35, 20);
            this.txtPaxNumber1.TabIndex = 5;
            this.txtPaxNumber1.TextChanged += new System.EventHandler(this.AddTxtControls_TextChanged);
            this.txtPaxNumber1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // txtFFnumber1
            // 
            this.txtFFnumber1.AllowBlankSpaces = false;
            this.txtFFnumber1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtFFnumber1.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.NumbersOrLetters;
            this.txtFFnumber1.CustomExpression = ".*";
            this.txtFFnumber1.EnterColor = System.Drawing.Color.Empty;
            this.txtFFnumber1.LeaveColor = System.Drawing.Color.Empty;
            this.txtFFnumber1.Location = new System.Drawing.Point(83, 44);
            this.txtFFnumber1.MaxLength = 16;
            this.txtFFnumber1.Name = "txtFFnumber1";
            this.txtFFnumber1.Size = new System.Drawing.Size(104, 20);
            this.txtFFnumber1.TabIndex = 4;
            this.txtFFnumber1.TextChanged += new System.EventHandler(this.AddTxtControls_TextChanged);
            this.txtFFnumber1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // txtAirline1
            // 
            this.txtAirline1.AllowBlankSpaces = false;
            this.txtAirline1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtAirline1.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.NumbersOrLetters;
            this.txtAirline1.CustomExpression = ".*";
            this.txtAirline1.EnterColor = System.Drawing.Color.Empty;
            this.txtAirline1.LeaveColor = System.Drawing.Color.Empty;
            this.txtAirline1.Location = new System.Drawing.Point(20, 44);
            this.txtAirline1.MaxLength = 2;
            this.txtAirline1.Name = "txtAirline1";
            this.txtAirline1.Size = new System.Drawing.Size(25, 20);
            this.txtAirline1.TabIndex = 3;
            this.txtAirline1.TextChanged += new System.EventHandler(this.AddTxtControls_TextChanged);
            this.txtAirline1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // lblOtherAirline
            // 
            this.lblOtherAirline.BackColor = System.Drawing.Color.White;
            this.lblOtherAirline.ForeColor = System.Drawing.Color.DarkCyan;
            this.lblOtherAirline.Location = new System.Drawing.Point(281, 2);
            this.lblOtherAirline.Name = "lblOtherAirline";
            this.lblOtherAirline.Size = new System.Drawing.Size(67, 34);
            this.lblOtherAirline.TabIndex = 16;
            this.lblOtherAirline.Text = "Enviar a otra Aereolínea:";
            this.lblOtherAirline.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblPaxNumber
            // 
            this.lblPaxNumber.AutoSize = true;
            this.lblPaxNumber.Location = new System.Drawing.Point(211, 19);
            this.lblPaxNumber.Name = "lblPaxNumber";
            this.lblPaxNumber.Size = new System.Drawing.Size(53, 13);
            this.lblPaxNumber.TabIndex = 15;
            this.lblPaxNumber.Text = "Num Pax:";
            // 
            // lblFFnumber
            // 
            this.lblFFnumber.AutoSize = true;
            this.lblFFnumber.Location = new System.Drawing.Point(96, 19);
            this.lblFFnumber.Name = "lblFFnumber";
            this.lblFFnumber.Size = new System.Drawing.Size(77, 13);
            this.lblFFnumber.TabIndex = 18;
            this.lblFFnumber.Text = "Número de FF:";
            // 
            // lblAirLine
            // 
            this.lblAirLine.AutoSize = true;
            this.lblAirLine.Location = new System.Drawing.Point(5, 19);
            this.lblAirLine.Name = "lblAirLine";
            this.lblAirLine.Size = new System.Drawing.Size(62, 13);
            this.lblAirLine.TabIndex = 17;
            this.lblAirLine.Text = "Aereolínea:";
            // 
            // pnlDelete
            // 
            this.pnlDelete.Controls.Add(this.lblRange);
            this.pnlDelete.Controls.Add(this.lblLineNumber);
            this.pnlDelete.Controls.Add(this.txtRange);
            this.pnlDelete.Controls.Add(this.txtLineNumber);
            this.pnlDelete.Controls.Add(this.lblIndent);
            this.pnlDelete.Location = new System.Drawing.Point(45, 320);
            this.pnlDelete.Name = "pnlDelete";
            this.pnlDelete.Size = new System.Drawing.Size(200, 65);
            this.pnlDelete.TabIndex = 17;
            this.pnlDelete.TabStop = true;
            // 
            // ucFrecuentFligher
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.pnlDelete);
            this.Controls.Add(this.pnlAdd);
            this.Controls.Add(this.rdoDelete);
            this.Controls.Add(this.lblLine);
            this.Controls.Add(this.rdoAdd);
            this.Controls.Add(this.btnAccept);
            this.Controls.Add(this.lblTitle);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "ucFrecuentFligher";
            this.Size = new System.Drawing.Size(411, 580);
            this.Load += new System.EventHandler(this.ucFrecuentFligher_Load);
            this.pnlAdd.ResumeLayout(false);
            this.pnlAdd.PerformLayout();
            this.pnlDelete.ResumeLayout(false);
            this.pnlDelete.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Button btnAccept;
        private System.Windows.Forms.RadioButton rdoAdd;
        private System.Windows.Forms.Label lblLine;
        private System.Windows.Forms.RadioButton rdoDelete;
        private System.Windows.Forms.Label lblLineNumber;
        private System.Windows.Forms.Label lblRange;
        private MyCTS.Forms.UI.SmartTextBox txtLineNumber;
        private System.Windows.Forms.Label lblIndent;
        private MyCTS.Forms.UI.SmartTextBox txtRange;
        private System.Windows.Forms.Panel pnlAdd;
        private MyCTS.Forms.UI.SmartTextBox txtOtherAirLine3;
        private MyCTS.Forms.UI.SmartTextBox txtPaxNumber3;
        private MyCTS.Forms.UI.SmartTextBox txtFFnumber3;
        private MyCTS.Forms.UI.SmartTextBox txtAirline3;
        private MyCTS.Forms.UI.SmartTextBox txtOtherAirline2;
        private MyCTS.Forms.UI.SmartTextBox txtPaxNumber2;
        private MyCTS.Forms.UI.SmartTextBox txtFFnumber2;
        private MyCTS.Forms.UI.SmartTextBox txtAirline2;
        private MyCTS.Forms.UI.SmartTextBox txtOtherAirline1;
        private MyCTS.Forms.UI.SmartTextBox txtPaxNumber1;
        private MyCTS.Forms.UI.SmartTextBox txtFFnumber1;
        private MyCTS.Forms.UI.SmartTextBox txtAirline1;
        private System.Windows.Forms.Label lblOtherAirline;
        private System.Windows.Forms.Label lblPaxNumber;
        private System.Windows.Forms.Label lblFFnumber;
        private System.Windows.Forms.Label lblAirLine;
        private System.Windows.Forms.Panel pnlDelete;
    }
}
