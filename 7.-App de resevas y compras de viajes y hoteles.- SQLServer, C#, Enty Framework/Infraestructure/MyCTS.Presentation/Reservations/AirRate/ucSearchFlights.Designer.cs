namespace MyCTS.Presentation
{
    partial class ucSearchFlights
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
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.tblLayoutMain = new System.Windows.Forms.TableLayoutPanel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.chkSearchInOthersAirports = new System.Windows.Forms.CheckBox();
            this.lblLookAireLine = new System.Windows.Forms.Label();
            this.txtAirline1 = new MyCTS.Forms.UI.SmartTextBox();
            this.txtAirline2 = new MyCTS.Forms.UI.SmartTextBox();
            this.txtAirline3 = new MyCTS.Forms.UI.SmartTextBox();
            this.lblNumberConnection = new System.Windows.Forms.Label();
            this.txtConnections = new MyCTS.Forms.UI.SmartTextBox();
            this.lblCurrencyCode = new System.Windows.Forms.Label();
            this.txtMoneyCode = new MyCTS.Forms.UI.SmartTextBox();
            this.btnAccept = new System.Windows.Forms.Button();
            this.lbMoneyCode = new System.Windows.Forms.ListBox();
            this.lbAirlines = new System.Windows.Forms.ListBox();
            this.tblLayoutMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Location = new System.Drawing.Point(3, 4);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(19, 1);
            this.checkBox2.TabIndex = 64;
            this.checkBox2.Text = "¿Buscar en aeropuertos alternos?";
            this.checkBox2.UseVisualStyleBackColor = true;
            // 
            // tblLayoutMain
            // 
            this.tblLayoutMain.BackColor = System.Drawing.Color.White;
            this.tblLayoutMain.ColumnCount = 1;
            this.tblLayoutMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 411F));
            this.tblLayoutMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tblLayoutMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tblLayoutMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tblLayoutMain.Controls.Add(this.lblTitle, 0, 0);
            this.tblLayoutMain.Location = new System.Drawing.Point(0, 0);
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
            this.tblLayoutMain.Size = new System.Drawing.Size(411, 15);
            this.tblLayoutMain.TabIndex = 8;
            // 
            // lblTitle
            // 
            this.lblTitle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(139)))), ((int)(((byte)(208)))));
            this.lblTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(3, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(405, 15);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Buscar Otros Vuelos";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.lblTitle.UseMnemonic = false;
            // 
            // chkSearchInOthersAirports
            // 
            this.chkSearchInOthersAirports.AutoSize = true;
            this.chkSearchInOthersAirports.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkSearchInOthersAirports.ForeColor = System.Drawing.Color.DarkCyan;
            this.chkSearchInOthersAirports.Location = new System.Drawing.Point(26, 67);
            this.chkSearchInOthersAirports.Name = "chkSearchInOthersAirports";
            this.chkSearchInOthersAirports.Size = new System.Drawing.Size(185, 17);
            this.chkSearchInOthersAirports.TabIndex = 1;
            this.chkSearchInOthersAirports.Text = "¿Buscar en aeropuertos alternos?";
            this.chkSearchInOthersAirports.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkSearchInOthersAirports.UseVisualStyleBackColor = true;
            this.chkSearchInOthersAirports.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // lblLookAireLine
            // 
            this.lblLookAireLine.AutoSize = true;
            this.lblLookAireLine.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLookAireLine.ForeColor = System.Drawing.Color.DarkCyan;
            this.lblLookAireLine.Location = new System.Drawing.Point(23, 87);
            this.lblLookAireLine.Name = "lblLookAireLine";
            this.lblLookAireLine.Size = new System.Drawing.Size(141, 13);
            this.lblLookAireLine.TabIndex = 10;
            this.lblLookAireLine.Text = "¿Buscar en que aerolíneas?";
            this.lblLookAireLine.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtAirline1
            // 
            this.txtAirline1.AllowBlankSpaces = true;
            this.txtAirline1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtAirline1.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.NumbersOrLetters;
            this.txtAirline1.CustomExpression = ".*";
            this.txtAirline1.EnterColor = System.Drawing.Color.Empty;
            this.txtAirline1.LeaveColor = System.Drawing.Color.Empty;
            this.txtAirline1.Location = new System.Drawing.Point(26, 103);
            this.txtAirline1.MaxLength = 52;
            this.txtAirline1.Name = "txtAirline1";
            this.txtAirline1.Size = new System.Drawing.Size(195, 20);
            this.txtAirline1.TabIndex = 2;
            this.txtAirline1.TextChanged += new System.EventHandler(this.txtAirline_TextChanged);
            this.txtAirline1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.AirlinesActions_KeyDown);
            // 
            // txtAirline2
            // 
            this.txtAirline2.AllowBlankSpaces = true;
            this.txtAirline2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtAirline2.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.NumbersOrLetters;
            this.txtAirline2.CustomExpression = ".*";
            this.txtAirline2.EnterColor = System.Drawing.Color.Empty;
            this.txtAirline2.LeaveColor = System.Drawing.Color.Empty;
            this.txtAirline2.Location = new System.Drawing.Point(26, 129);
            this.txtAirline2.MaxLength = 52;
            this.txtAirline2.Name = "txtAirline2";
            this.txtAirline2.Size = new System.Drawing.Size(195, 20);
            this.txtAirline2.TabIndex = 3;
            this.txtAirline2.TextChanged += new System.EventHandler(this.txtAirline_TextChanged);
            this.txtAirline2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.AirlinesActions_KeyDown);
            // 
            // txtAirline3
            // 
            this.txtAirline3.AllowBlankSpaces = true;
            this.txtAirline3.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtAirline3.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.NumbersOrLetters;
            this.txtAirline3.CustomExpression = ".*";
            this.txtAirline3.EnterColor = System.Drawing.Color.Empty;
            this.txtAirline3.LeaveColor = System.Drawing.Color.Empty;
            this.txtAirline3.Location = new System.Drawing.Point(26, 155);
            this.txtAirline3.MaxLength = 52;
            this.txtAirline3.Name = "txtAirline3";
            this.txtAirline3.Size = new System.Drawing.Size(195, 20);
            this.txtAirline3.TabIndex = 4;
            this.txtAirline3.TextChanged += new System.EventHandler(this.txtAirline_TextChanged);
            this.txtAirline3.KeyDown += new System.Windows.Forms.KeyEventHandler(this.AirlinesActions_KeyDown);
            // 
            // lblNumberConnection
            // 
            this.lblNumberConnection.AutoSize = true;
            this.lblNumberConnection.Location = new System.Drawing.Point(23, 184);
            this.lblNumberConnection.Name = "lblNumberConnection";
            this.lblNumberConnection.Size = new System.Drawing.Size(157, 13);
            this.lblNumberConnection.TabIndex = 14;
            this.lblNumberConnection.Text = "Número máximo de conexiones:";
            this.lblNumberConnection.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtConnections
            // 
            this.txtConnections.AllowBlankSpaces = false;
            this.txtConnections.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtConnections.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.OnlyNumbers;
            this.txtConnections.CustomExpression = ".*";
            this.txtConnections.EnterColor = System.Drawing.Color.Empty;
            this.txtConnections.LeaveColor = System.Drawing.Color.Empty;
            this.txtConnections.Location = new System.Drawing.Point(186, 181);
            this.txtConnections.MaxLength = 1;
            this.txtConnections.Name = "txtConnections";
            this.txtConnections.Size = new System.Drawing.Size(25, 20);
            this.txtConnections.TabIndex = 5;
            this.txtConnections.Text = "1";
            this.txtConnections.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // lblCurrencyCode
            // 
            this.lblCurrencyCode.AutoSize = true;
            this.lblCurrencyCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCurrencyCode.ForeColor = System.Drawing.Color.DarkCyan;
            this.lblCurrencyCode.Location = new System.Drawing.Point(23, 207);
            this.lblCurrencyCode.Name = "lblCurrencyCode";
            this.lblCurrencyCode.Size = new System.Drawing.Size(99, 13);
            this.lblCurrencyCode.TabIndex = 16;
            this.lblCurrencyCode.Text = "Código de moneda:";
            this.lblCurrencyCode.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtMoneyCode
            // 
            this.txtMoneyCode.AllowBlankSpaces = true;
            this.txtMoneyCode.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtMoneyCode.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.OnlyLetters;
            this.txtMoneyCode.CustomExpression = ".*";
            this.txtMoneyCode.EnterColor = System.Drawing.Color.Empty;
            this.txtMoneyCode.LeaveColor = System.Drawing.Color.Empty;
            this.txtMoneyCode.Location = new System.Drawing.Point(26, 223);
            this.txtMoneyCode.MaxLength = 32;
            this.txtMoneyCode.Name = "txtMoneyCode";
            this.txtMoneyCode.Size = new System.Drawing.Size(195, 20);
            this.txtMoneyCode.TabIndex = 6;
            this.txtMoneyCode.TextChanged += new System.EventHandler(this.txtMoneyCode_TextChanged);
            this.txtMoneyCode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.moneyCodeActions_KeyDown);
            // 
            // btnAccept
            // 
            this.btnAccept.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnAccept.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAccept.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAccept.Location = new System.Drawing.Point(274, 259);
            this.btnAccept.Name = "btnAccept";
            this.btnAccept.Size = new System.Drawing.Size(100, 23);
            this.btnAccept.TabIndex = 7;
            this.btnAccept.Text = "Aceptar";
            this.btnAccept.UseVisualStyleBackColor = false;
            this.btnAccept.Click += new System.EventHandler(this.btnAccept_Click);
            // 
            // lbMoneyCode
            // 
            this.lbMoneyCode.DisplayMember = "Text";
            this.lbMoneyCode.FormattingEnabled = true;
            this.lbMoneyCode.Location = new System.Drawing.Point(26, 240);
            this.lbMoneyCode.Name = "lbMoneyCode";
            this.lbMoneyCode.Size = new System.Drawing.Size(195, 95);
            this.lbMoneyCode.TabIndex = 17;
            this.lbMoneyCode.ValueMember = "Value";
            this.lbMoneyCode.MouseClick += new System.Windows.Forms.MouseEventHandler(this.ListBox_MouseClick);
            this.lbMoneyCode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.lbMoneyCode_KeyDown);
            // 
            // lbAirlines
            // 
            this.lbAirlines.DisplayMember = "Text";
            this.lbAirlines.FormattingEnabled = true;
            this.lbAirlines.Location = new System.Drawing.Point(26, 122);
            this.lbAirlines.Name = "lbAirlines";
            this.lbAirlines.Size = new System.Drawing.Size(195, 95);
            this.lbAirlines.TabIndex = 18;
            this.lbAirlines.ValueMember = "Value";
            this.lbAirlines.MouseClick += new System.Windows.Forms.MouseEventHandler(this.ListBox_MouseClick);
            this.lbAirlines.KeyDown += new System.Windows.Forms.KeyEventHandler(this.lbAirlines_KeyDown);
            // 
            // ucSearchFlights
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.btnAccept);
            this.Controls.Add(this.txtMoneyCode);
            this.Controls.Add(this.lblCurrencyCode);
            this.Controls.Add(this.txtConnections);
            this.Controls.Add(this.lblNumberConnection);
            this.Controls.Add(this.txtAirline3);
            this.Controls.Add(this.txtAirline2);
            this.Controls.Add(this.txtAirline1);
            this.Controls.Add(this.lblLookAireLine);
            this.Controls.Add(this.chkSearchInOthersAirports);
            this.Controls.Add(this.tblLayoutMain);
            this.Controls.Add(this.lbMoneyCode);
            this.Controls.Add(this.lbAirlines);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Name = "ucSearchFlights";
            this.Size = new System.Drawing.Size(411, 580);
            this.Load += new System.EventHandler(this.ucSearchFlights_Load);
            this.tblLayoutMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox checkBox2;
        internal System.Windows.Forms.TableLayoutPanel tblLayoutMain;
        private System.Windows.Forms.BindingSource bindingSource1;
        internal System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.CheckBox chkSearchInOthersAirports;
        private System.Windows.Forms.Label lblLookAireLine;
        private MyCTS.Forms.UI.SmartTextBox txtAirline1;
        private MyCTS.Forms.UI.SmartTextBox txtAirline2;
        private MyCTS.Forms.UI.SmartTextBox txtAirline3;
        private System.Windows.Forms.Label lblNumberConnection;
        private MyCTS.Forms.UI.SmartTextBox txtConnections;
        private System.Windows.Forms.Label lblCurrencyCode;
        private MyCTS.Forms.UI.SmartTextBox txtMoneyCode;
        private System.Windows.Forms.Button btnAccept;
        private System.Windows.Forms.ListBox lbMoneyCode;
        private System.Windows.Forms.ListBox lbAirlines;
    }
}
