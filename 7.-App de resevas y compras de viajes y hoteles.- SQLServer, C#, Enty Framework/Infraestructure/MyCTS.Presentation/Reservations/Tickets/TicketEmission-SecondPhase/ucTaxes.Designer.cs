namespace MyCTS.Presentation
{
    partial class ucTaxes
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
            this.lblTax6 = new System.Windows.Forms.Label();
            this.lblTax5 = new System.Windows.Forms.Label();
            this.lblTax2 = new System.Windows.Forms.Label();
            this.lblTax4 = new System.Windows.Forms.Label();
            this.lblTax3 = new System.Windows.Forms.Label();
            this.btnAccept = new System.Windows.Forms.Button();
            this.lblTax1 = new System.Windows.Forms.Label();
            this.tblLayout1 = new System.Windows.Forms.TableLayoutPanel();
            this.lblChargePerService = new System.Windows.Forms.Label();
            this.rdoModification = new System.Windows.Forms.RadioButton();
            this.rdoExention = new System.Windows.Forms.RadioButton();
            this.txtTax1 = new MyCTS.Forms.UI.SmartTextBox();
            this.txtTax2 = new MyCTS.Forms.UI.SmartTextBox();
            this.txtTax3 = new MyCTS.Forms.UI.SmartTextBox();
            this.txtTax4 = new MyCTS.Forms.UI.SmartTextBox();
            this.txtTax5 = new MyCTS.Forms.UI.SmartTextBox();
            this.txtTax6 = new MyCTS.Forms.UI.SmartTextBox();
            this.lblMount = new System.Windows.Forms.Label();
            this.chbExent2 = new System.Windows.Forms.CheckBox();
            this.chbExent3 = new System.Windows.Forms.CheckBox();
            this.chbExent4 = new System.Windows.Forms.CheckBox();
            this.chbExent5 = new System.Windows.Forms.CheckBox();
            this.chbExent6 = new System.Windows.Forms.CheckBox();
            this.chbExent1 = new System.Windows.Forms.CheckBox();
            this.lblExent = new System.Windows.Forms.Label();
            this.txtMount1 = new MyCTS.Forms.UI.SmartTextBox();
            this.txtMount2 = new MyCTS.Forms.UI.SmartTextBox();
            this.txtMount3 = new MyCTS.Forms.UI.SmartTextBox();
            this.txtMount4 = new MyCTS.Forms.UI.SmartTextBox();
            this.txtMount5 = new MyCTS.Forms.UI.SmartTextBox();
            this.txtMount6 = new MyCTS.Forms.UI.SmartTextBox();
            this.tblLayout1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTax6
            // 
            this.lblTax6.AutoSize = true;
            this.lblTax6.ForeColor = System.Drawing.Color.DarkCyan;
            this.lblTax6.Location = new System.Drawing.Point(76, 208);
            this.lblTax6.Name = "lblTax6";
            this.lblTax6.Size = new System.Drawing.Size(62, 13);
            this.lblTax6.TabIndex = 15;
            this.lblTax6.Text = "Impuesto 6:";
            this.lblTax6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblTax5
            // 
            this.lblTax5.AutoSize = true;
            this.lblTax5.ForeColor = System.Drawing.Color.DarkCyan;
            this.lblTax5.Location = new System.Drawing.Point(76, 184);
            this.lblTax5.Name = "lblTax5";
            this.lblTax5.Size = new System.Drawing.Size(62, 13);
            this.lblTax5.TabIndex = 14;
            this.lblTax5.Text = "Impuesto 5:";
            this.lblTax5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblTax2
            // 
            this.lblTax2.AutoSize = true;
            this.lblTax2.ForeColor = System.Drawing.Color.DarkCyan;
            this.lblTax2.Location = new System.Drawing.Point(76, 111);
            this.lblTax2.Name = "lblTax2";
            this.lblTax2.Size = new System.Drawing.Size(62, 13);
            this.lblTax2.TabIndex = 13;
            this.lblTax2.Text = "Impuesto 2:";
            this.lblTax2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblTax4
            // 
            this.lblTax4.AutoSize = true;
            this.lblTax4.ForeColor = System.Drawing.Color.DarkCyan;
            this.lblTax4.Location = new System.Drawing.Point(76, 159);
            this.lblTax4.Name = "lblTax4";
            this.lblTax4.Size = new System.Drawing.Size(62, 13);
            this.lblTax4.TabIndex = 11;
            this.lblTax4.Text = "Impuesto 4:";
            this.lblTax4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblTax3
            // 
            this.lblTax3.AutoSize = true;
            this.lblTax3.ForeColor = System.Drawing.Color.DarkCyan;
            this.lblTax3.Location = new System.Drawing.Point(76, 136);
            this.lblTax3.Name = "lblTax3";
            this.lblTax3.Size = new System.Drawing.Size(62, 13);
            this.lblTax3.TabIndex = 12;
            this.lblTax3.Text = "Impuesto 3:";
            this.lblTax3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnAccept
            // 
            this.btnAccept.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnAccept.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAccept.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAccept.Location = new System.Drawing.Point(243, 313);
            this.btnAccept.Name = "btnAccept";
            this.btnAccept.Size = new System.Drawing.Size(110, 24);
            this.btnAccept.TabIndex = 21;
            this.btnAccept.Text = "Aceptar";
            this.btnAccept.UseVisualStyleBackColor = false;
            this.btnAccept.Click += new System.EventHandler(this.btnAccept_Click);
            this.btnAccept.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // lblTax1
            // 
            this.lblTax1.AutoSize = true;
            this.lblTax1.ForeColor = System.Drawing.Color.DarkCyan;
            this.lblTax1.Location = new System.Drawing.Point(76, 87);
            this.lblTax1.Name = "lblTax1";
            this.lblTax1.Size = new System.Drawing.Size(62, 13);
            this.lblTax1.TabIndex = 0;
            this.lblTax1.Text = "Impuesto 1:";
            this.lblTax1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tblLayout1
            // 
            this.tblLayout1.BackColor = System.Drawing.Color.White;
            this.tblLayout1.ColumnCount = 6;
            this.tblLayout1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20.17045F));
            this.tblLayout1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 21.30682F));
            this.tblLayout1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tblLayout1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 12F));
            this.tblLayout1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.08791F));
            this.tblLayout1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 46.7033F));
            this.tblLayout1.Controls.Add(this.lblChargePerService, 0, 0);
            this.tblLayout1.Controls.Add(this.lblTax1, 1, 4);
            this.tblLayout1.Controls.Add(this.lblTax3, 1, 6);
            this.tblLayout1.Controls.Add(this.lblTax4, 1, 7);
            this.tblLayout1.Controls.Add(this.lblTax2, 1, 5);
            this.tblLayout1.Controls.Add(this.lblTax5, 1, 8);
            this.tblLayout1.Controls.Add(this.lblTax6, 1, 9);
            this.tblLayout1.Controls.Add(this.rdoModification, 5, 2);
            this.tblLayout1.Controls.Add(this.rdoExention, 2, 2);
            this.tblLayout1.Controls.Add(this.txtTax1, 2, 4);
            this.tblLayout1.Controls.Add(this.txtTax2, 2, 5);
            this.tblLayout1.Controls.Add(this.txtTax3, 2, 6);
            this.tblLayout1.Controls.Add(this.txtTax4, 2, 7);
            this.tblLayout1.Controls.Add(this.txtTax5, 2, 8);
            this.tblLayout1.Controls.Add(this.txtTax6, 2, 9);
            this.tblLayout1.Controls.Add(this.lblMount, 5, 3);
            this.tblLayout1.Controls.Add(this.chbExent2, 4, 5);
            this.tblLayout1.Controls.Add(this.chbExent3, 4, 6);
            this.tblLayout1.Controls.Add(this.chbExent4, 4, 7);
            this.tblLayout1.Controls.Add(this.chbExent5, 4, 8);
            this.tblLayout1.Controls.Add(this.chbExent6, 4, 9);
            this.tblLayout1.Controls.Add(this.chbExent1, 4, 4);
            this.tblLayout1.Controls.Add(this.lblExent, 3, 3);
            this.tblLayout1.Controls.Add(this.txtMount1, 5, 4);
            this.tblLayout1.Controls.Add(this.txtMount2, 5, 5);
            this.tblLayout1.Controls.Add(this.txtMount3, 5, 6);
            this.tblLayout1.Controls.Add(this.txtMount4, 5, 7);
            this.tblLayout1.Controls.Add(this.txtMount5, 5, 8);
            this.tblLayout1.Controls.Add(this.txtMount6, 5, 9);
            this.tblLayout1.Controls.Add(this.btnAccept, 5, 13);
            this.tblLayout1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblLayout1.Location = new System.Drawing.Point(0, 0);
            this.tblLayout1.Margin = new System.Windows.Forms.Padding(0);
            this.tblLayout1.Name = "tblLayout1";
            this.tblLayout1.RowCount = 16;
            this.tblLayout1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tblLayout1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.tblLayout1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 21F));
            this.tblLayout1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tblLayout1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 24F));
            this.tblLayout1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tblLayout1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 23F));
            this.tblLayout1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tblLayout1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 24F));
            this.tblLayout1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tblLayout1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 24F));
            this.tblLayout1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tblLayout1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.tblLayout1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 77F));
            this.tblLayout1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tblLayout1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tblLayout1.Size = new System.Drawing.Size(411, 580);
            this.tblLayout1.TabIndex = 15;
            // 
            // lblChargePerService
            // 
            this.lblChargePerService.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(139)))), ((int)(((byte)(208)))));
            this.tblLayout1.SetColumnSpan(this.lblChargePerService, 6);
            this.lblChargePerService.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblChargePerService.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblChargePerService.ForeColor = System.Drawing.Color.White;
            this.lblChargePerService.Location = new System.Drawing.Point(3, 0);
            this.lblChargePerService.Name = "lblChargePerService";
            this.lblChargePerService.Size = new System.Drawing.Size(405, 17);
            this.lblChargePerService.TabIndex = 0;
            this.lblChargePerService.Text = "Impuestos";
            this.lblChargePerService.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // rdoModification
            // 
            this.rdoModification.AutoSize = true;
            this.rdoModification.Location = new System.Drawing.Point(243, 49);
            this.rdoModification.Name = "rdoModification";
            this.rdoModification.Size = new System.Drawing.Size(85, 15);
            this.rdoModification.TabIndex = 2;
            this.rdoModification.TabStop = true;
            this.rdoModification.Text = "Modificación";
            this.rdoModification.UseVisualStyleBackColor = true;
            this.rdoModification.CheckedChanged += new System.EventHandler(this.rdoModification_CheckedChanged);
            this.rdoModification.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // rdoExention
            // 
            this.rdoExention.AutoSize = true;
            this.tblLayout1.SetColumnSpan(this.rdoExention, 3);
            this.rdoExention.Location = new System.Drawing.Point(153, 49);
            this.rdoExention.Name = "rdoExention";
            this.rdoExention.Size = new System.Drawing.Size(69, 15);
            this.rdoExention.TabIndex = 1;
            this.rdoExention.TabStop = true;
            this.rdoExention.Text = "Exención";
            this.rdoExention.UseVisualStyleBackColor = true;
            this.rdoExention.CheckedChanged += new System.EventHandler(this.rdoExention_CheckedChanged);
            this.rdoExention.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // txtTax1
            // 
            this.txtTax1.AllowBlankSpaces = true;
            this.txtTax1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtTax1.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.NumbersOrLetters;
            this.txtTax1.CustomExpression = ".*";
            this.txtTax1.EnterColor = System.Drawing.Color.Empty;
            this.txtTax1.LeaveColor = System.Drawing.Color.Empty;
            this.txtTax1.Location = new System.Drawing.Point(153, 90);
            this.txtTax1.MaxLength = 2;
            this.txtTax1.Name = "txtTax1";
            this.txtTax1.Size = new System.Drawing.Size(26, 20);
            this.txtTax1.TabIndex = 3;
            this.txtTax1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // txtTax2
            // 
            this.txtTax2.AllowBlankSpaces = true;
            this.txtTax2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtTax2.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.NumbersOrLetters;
            this.txtTax2.CustomExpression = ".*";
            this.txtTax2.EnterColor = System.Drawing.Color.Empty;
            this.txtTax2.LeaveColor = System.Drawing.Color.Empty;
            this.txtTax2.Location = new System.Drawing.Point(153, 114);
            this.txtTax2.MaxLength = 2;
            this.txtTax2.Name = "txtTax2";
            this.txtTax2.Size = new System.Drawing.Size(26, 20);
            this.txtTax2.TabIndex = 6;
            this.txtTax2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // txtTax3
            // 
            this.txtTax3.AllowBlankSpaces = true;
            this.txtTax3.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtTax3.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.NumbersOrLetters;
            this.txtTax3.CustomExpression = ".*";
            this.txtTax3.EnterColor = System.Drawing.Color.Empty;
            this.txtTax3.LeaveColor = System.Drawing.Color.Empty;
            this.txtTax3.Location = new System.Drawing.Point(153, 139);
            this.txtTax3.MaxLength = 2;
            this.txtTax3.Name = "txtTax3";
            this.txtTax3.Size = new System.Drawing.Size(26, 20);
            this.txtTax3.TabIndex = 9;
            this.txtTax3.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // txtTax4
            // 
            this.txtTax4.AllowBlankSpaces = true;
            this.txtTax4.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtTax4.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.NumbersOrLetters;
            this.txtTax4.CustomExpression = ".*";
            this.txtTax4.EnterColor = System.Drawing.Color.Empty;
            this.txtTax4.LeaveColor = System.Drawing.Color.Empty;
            this.txtTax4.Location = new System.Drawing.Point(153, 162);
            this.txtTax4.MaxLength = 2;
            this.txtTax4.Name = "txtTax4";
            this.txtTax4.Size = new System.Drawing.Size(26, 20);
            this.txtTax4.TabIndex = 12;
            this.txtTax4.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // txtTax5
            // 
            this.txtTax5.AllowBlankSpaces = true;
            this.txtTax5.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtTax5.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.NumbersOrLetters;
            this.txtTax5.CustomExpression = ".*";
            this.txtTax5.EnterColor = System.Drawing.Color.Empty;
            this.txtTax5.LeaveColor = System.Drawing.Color.Empty;
            this.txtTax5.Location = new System.Drawing.Point(153, 187);
            this.txtTax5.MaxLength = 2;
            this.txtTax5.Name = "txtTax5";
            this.txtTax5.Size = new System.Drawing.Size(26, 20);
            this.txtTax5.TabIndex = 15;
            this.txtTax5.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // txtTax6
            // 
            this.txtTax6.AllowBlankSpaces = true;
            this.txtTax6.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtTax6.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.NumbersOrLetters;
            this.txtTax6.CustomExpression = ".*";
            this.txtTax6.EnterColor = System.Drawing.Color.Empty;
            this.txtTax6.LeaveColor = System.Drawing.Color.Empty;
            this.txtTax6.Location = new System.Drawing.Point(153, 211);
            this.txtTax6.MaxLength = 2;
            this.txtTax6.Name = "txtTax6";
            this.txtTax6.Size = new System.Drawing.Size(26, 20);
            this.txtTax6.TabIndex = 18;
            this.txtTax6.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // lblMount
            // 
            this.lblMount.AutoSize = true;
            this.lblMount.Location = new System.Drawing.Point(243, 67);
            this.lblMount.Name = "lblMount";
            this.lblMount.Size = new System.Drawing.Size(42, 13);
            this.lblMount.TabIndex = 28;
            this.lblMount.Text = "Montos";
            this.lblMount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // chbExent2
            // 
            this.chbExent2.AutoSize = true;
            this.chbExent2.Location = new System.Drawing.Point(200, 114);
            this.chbExent2.Name = "chbExent2";
            this.chbExent2.Size = new System.Drawing.Size(15, 14);
            this.chbExent2.TabIndex = 7;
            this.chbExent2.UseVisualStyleBackColor = true;
            this.chbExent2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // chbExent3
            // 
            this.chbExent3.AutoSize = true;
            this.chbExent3.Location = new System.Drawing.Point(200, 139);
            this.chbExent3.Name = "chbExent3";
            this.chbExent3.Size = new System.Drawing.Size(15, 14);
            this.chbExent3.TabIndex = 10;
            this.chbExent3.UseVisualStyleBackColor = true;
            this.chbExent3.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // chbExent4
            // 
            this.chbExent4.AutoSize = true;
            this.chbExent4.Location = new System.Drawing.Point(200, 162);
            this.chbExent4.Name = "chbExent4";
            this.chbExent4.Size = new System.Drawing.Size(15, 14);
            this.chbExent4.TabIndex = 13;
            this.chbExent4.UseVisualStyleBackColor = true;
            this.chbExent4.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // chbExent5
            // 
            this.chbExent5.AutoSize = true;
            this.chbExent5.Location = new System.Drawing.Point(200, 187);
            this.chbExent5.Name = "chbExent5";
            this.chbExent5.Size = new System.Drawing.Size(15, 14);
            this.chbExent5.TabIndex = 16;
            this.chbExent5.UseVisualStyleBackColor = true;
            this.chbExent5.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // chbExent6
            // 
            this.chbExent6.AutoSize = true;
            this.chbExent6.Location = new System.Drawing.Point(200, 211);
            this.chbExent6.Name = "chbExent6";
            this.chbExent6.Size = new System.Drawing.Size(15, 14);
            this.chbExent6.TabIndex = 19;
            this.chbExent6.UseVisualStyleBackColor = true;
            this.chbExent6.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // chbExent1
            // 
            this.chbExent1.AutoSize = true;
            this.chbExent1.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chbExent1.Location = new System.Drawing.Point(200, 90);
            this.chbExent1.Name = "chbExent1";
            this.chbExent1.Size = new System.Drawing.Size(15, 14);
            this.chbExent1.TabIndex = 4;
            this.chbExent1.UseVisualStyleBackColor = true;
            this.chbExent1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // lblExent
            // 
            this.lblExent.AutoSize = true;
            this.tblLayout1.SetColumnSpan(this.lblExent, 2);
            this.lblExent.Location = new System.Drawing.Point(188, 67);
            this.lblExent.Name = "lblExent";
            this.lblExent.Size = new System.Drawing.Size(49, 13);
            this.lblExent.TabIndex = 27;
            this.lblExent.Text = "Exentar?";
            this.lblExent.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtMount1
            // 
            this.txtMount1.AllowBlankSpaces = false;
            this.txtMount1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtMount1.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.AnyCharacter;
            this.txtMount1.CustomExpression = ".*";
            this.txtMount1.EnterColor = System.Drawing.Color.Empty;
            this.txtMount1.LeaveColor = System.Drawing.Color.Empty;
            this.txtMount1.Location = new System.Drawing.Point(243, 90);
            this.txtMount1.MaxLength = 8;
            this.txtMount1.Name = "txtMount1";
            this.txtMount1.Size = new System.Drawing.Size(85, 20);
            this.txtMount1.TabIndex = 5;
            this.txtMount1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // txtMount2
            // 
            this.txtMount2.AllowBlankSpaces = false;
            this.txtMount2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtMount2.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.AnyCharacter;
            this.txtMount2.CustomExpression = ".*";
            this.txtMount2.EnterColor = System.Drawing.Color.Empty;
            this.txtMount2.LeaveColor = System.Drawing.Color.Empty;
            this.txtMount2.Location = new System.Drawing.Point(243, 114);
            this.txtMount2.MaxLength = 8;
            this.txtMount2.Name = "txtMount2";
            this.txtMount2.Size = new System.Drawing.Size(85, 20);
            this.txtMount2.TabIndex = 8;
            this.txtMount2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // txtMount3
            // 
            this.txtMount3.AllowBlankSpaces = false;
            this.txtMount3.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtMount3.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.AnyCharacter;
            this.txtMount3.CustomExpression = ".*";
            this.txtMount3.EnterColor = System.Drawing.Color.Empty;
            this.txtMount3.LeaveColor = System.Drawing.Color.Empty;
            this.txtMount3.Location = new System.Drawing.Point(243, 139);
            this.txtMount3.MaxLength = 8;
            this.txtMount3.Name = "txtMount3";
            this.txtMount3.Size = new System.Drawing.Size(85, 20);
            this.txtMount3.TabIndex = 11;
            this.txtMount3.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // txtMount4
            // 
            this.txtMount4.AllowBlankSpaces = false;
            this.txtMount4.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtMount4.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.AnyCharacter;
            this.txtMount4.CustomExpression = ".*";
            this.txtMount4.EnterColor = System.Drawing.Color.Empty;
            this.txtMount4.LeaveColor = System.Drawing.Color.Empty;
            this.txtMount4.Location = new System.Drawing.Point(243, 162);
            this.txtMount4.MaxLength = 8;
            this.txtMount4.Name = "txtMount4";
            this.txtMount4.Size = new System.Drawing.Size(85, 20);
            this.txtMount4.TabIndex = 14;
            this.txtMount4.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // txtMount5
            // 
            this.txtMount5.AllowBlankSpaces = false;
            this.txtMount5.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtMount5.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.AnyCharacter;
            this.txtMount5.CustomExpression = ".*";
            this.txtMount5.EnterColor = System.Drawing.Color.Empty;
            this.txtMount5.LeaveColor = System.Drawing.Color.Empty;
            this.txtMount5.Location = new System.Drawing.Point(243, 187);
            this.txtMount5.MaxLength = 8;
            this.txtMount5.Name = "txtMount5";
            this.txtMount5.Size = new System.Drawing.Size(85, 20);
            this.txtMount5.TabIndex = 17;
            this.txtMount5.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // txtMount6
            // 
            this.txtMount6.AllowBlankSpaces = false;
            this.txtMount6.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtMount6.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.AnyCharacter;
            this.txtMount6.CustomExpression = ".*";
            this.txtMount6.EnterColor = System.Drawing.Color.Empty;
            this.txtMount6.LeaveColor = System.Drawing.Color.Empty;
            this.txtMount6.Location = new System.Drawing.Point(243, 211);
            this.txtMount6.MaxLength = 8;
            this.txtMount6.Name = "txtMount6";
            this.txtMount6.Size = new System.Drawing.Size(85, 20);
            this.txtMount6.TabIndex = 20;
            this.txtMount6.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // ucTaxes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.tblLayout1);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "ucTaxes";
            this.Size = new System.Drawing.Size(411, 580);
            this.Load += new System.EventHandler(this.ucTaxes_Load);
            this.tblLayout1.ResumeLayout(false);
            this.tblLayout1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblTax6;
        private System.Windows.Forms.Label lblTax5;
        private System.Windows.Forms.Label lblTax2;
        private System.Windows.Forms.Label lblTax4;
        private System.Windows.Forms.Label lblTax3;
        private System.Windows.Forms.Button btnAccept;
        private System.Windows.Forms.Label lblTax1;
        internal System.Windows.Forms.TableLayoutPanel tblLayout1;
        private System.Windows.Forms.RadioButton rdoExention;
        internal System.Windows.Forms.Label lblChargePerService;
        private System.Windows.Forms.RadioButton rdoModification;
        private System.Windows.Forms.Label lblExent;
        private System.Windows.Forms.Label lblMount;
        private MyCTS.Forms.UI.SmartTextBox txtTax1;
        private MyCTS.Forms.UI.SmartTextBox txtTax2;
        private MyCTS.Forms.UI.SmartTextBox txtTax3;
        private MyCTS.Forms.UI.SmartTextBox txtTax4;
        private MyCTS.Forms.UI.SmartTextBox txtTax5;
        private MyCTS.Forms.UI.SmartTextBox txtTax6;
        private System.Windows.Forms.CheckBox chbExent2;
        private System.Windows.Forms.CheckBox chbExent3;
        private System.Windows.Forms.CheckBox chbExent4;
        private System.Windows.Forms.CheckBox chbExent5;
        private System.Windows.Forms.CheckBox chbExent6;
        private System.Windows.Forms.CheckBox chbExent1;
        private MyCTS.Forms.UI.SmartTextBox txtMount1;
        private MyCTS.Forms.UI.SmartTextBox txtMount2;
        private MyCTS.Forms.UI.SmartTextBox txtMount3;
        private MyCTS.Forms.UI.SmartTextBox txtMount4;
        private MyCTS.Forms.UI.SmartTextBox txtMount5;
        private MyCTS.Forms.UI.SmartTextBox txtMount6;

    }
}
