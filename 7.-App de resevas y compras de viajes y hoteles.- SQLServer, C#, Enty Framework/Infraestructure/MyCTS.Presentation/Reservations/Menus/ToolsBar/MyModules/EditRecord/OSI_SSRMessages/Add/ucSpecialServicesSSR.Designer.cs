namespace MyCTS.Presentation
{
    partial class ucSpecialServicesSSR
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
            this.lblAirLine = new System.Windows.Forms.Label();
            this.txtAirline = new MyCTS.Forms.UI.SmartTextBox();
            this.lblCode = new System.Windows.Forms.Label();
            this.cmbCode = new System.Windows.Forms.ComboBox();
            this.lblSegment = new System.Windows.Forms.Label();
            this.txtSegment = new MyCTS.Forms.UI.SmartTextBox();
            this.lblPaxNumber = new System.Windows.Forms.Label();
            this.txtPaxNumber = new MyCTS.Forms.UI.SmartTextBox();
            this.lblDescription = new System.Windows.Forms.Label();
            this.txtDescription = new MyCTS.Forms.UI.SmartTextBox();
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
            this.lblTitle.Text = "SSR - Servicios Especiales";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblAirLine
            // 
            this.lblAirLine.AutoSize = true;
            this.lblAirLine.ForeColor = System.Drawing.Color.DarkCyan;
            this.lblAirLine.Location = new System.Drawing.Point(30, 45);
            this.lblAirLine.Name = "lblAirLine";
            this.lblAirLine.Size = new System.Drawing.Size(62, 13);
            this.lblAirLine.TabIndex = 0;
            this.lblAirLine.Text = "Aereolínea:";
            // 
            // txtAirline
            // 
            this.txtAirline.AllowBlankSpaces = false;
            this.txtAirline.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtAirline.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.NumbersOrLetters;
            this.txtAirline.CustomExpression = ".*";
            this.txtAirline.EnterColor = System.Drawing.Color.Empty;
            this.txtAirline.LeaveColor = System.Drawing.Color.Empty;
            this.txtAirline.Location = new System.Drawing.Point(122, 42);
            this.txtAirline.MaxLength = 2;
            this.txtAirline.Name = "txtAirline";
            this.txtAirline.Size = new System.Drawing.Size(25, 20);
            this.txtAirline.TabIndex = 1;
            this.txtAirline.TextChanged += new System.EventHandler(this.txtControls_TextChanged);
            this.txtAirline.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // lblCode
            // 
            this.lblCode.AutoSize = true;
            this.lblCode.ForeColor = System.Drawing.Color.Black;
            this.lblCode.Location = new System.Drawing.Point(30, 76);
            this.lblCode.Name = "lblCode";
            this.lblCode.Size = new System.Drawing.Size(43, 13);
            this.lblCode.TabIndex = 0;
            this.lblCode.Text = "Código:";
            // 
            // cmbCode
            // 
            this.cmbCode.DisplayMember = "Text";
            this.cmbCode.FormattingEnabled = true;
            this.cmbCode.Items.AddRange(new object[] {
            "Selecciona el código de SSR deseado:"});
            this.cmbCode.Location = new System.Drawing.Point(122, 73);
            this.cmbCode.Name = "cmbCode";
            this.cmbCode.Size = new System.Drawing.Size(265, 21);
            this.cmbCode.TabIndex = 2;
            this.cmbCode.ValueMember = "Value";
            this.cmbCode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // lblSegment
            // 
            this.lblSegment.AutoSize = true;
            this.lblSegment.ForeColor = System.Drawing.Color.DarkCyan;
            this.lblSegment.Location = new System.Drawing.Point(30, 113);
            this.lblSegment.Name = "lblSegment";
            this.lblSegment.Size = new System.Drawing.Size(58, 13);
            this.lblSegment.TabIndex = 0;
            this.lblSegment.Text = "Segmento:";
            // 
            // txtSegment
            // 
            this.txtSegment.AllowBlankSpaces = false;
            this.txtSegment.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtSegment.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.OnlyNumbers;
            this.txtSegment.CustomExpression = ".*";
            this.txtSegment.EnterColor = System.Drawing.Color.Empty;
            this.txtSegment.LeaveColor = System.Drawing.Color.Empty;
            this.txtSegment.Location = new System.Drawing.Point(122, 110);
            this.txtSegment.MaxLength = 2;
            this.txtSegment.Name = "txtSegment";
            this.txtSegment.Size = new System.Drawing.Size(25, 20);
            this.txtSegment.TabIndex = 3;
            this.txtSegment.TextChanged += new System.EventHandler(this.txtControls_TextChanged);
            this.txtSegment.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // lblPaxNumber
            // 
            this.lblPaxNumber.AutoSize = true;
            this.lblPaxNumber.Location = new System.Drawing.Point(30, 151);
            this.lblPaxNumber.Name = "lblPaxNumber";
            this.lblPaxNumber.Size = new System.Drawing.Size(53, 13);
            this.lblPaxNumber.TabIndex = 0;
            this.lblPaxNumber.Text = "Num Pax:";
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
            this.txtPaxNumber.Location = new System.Drawing.Point(122, 148);
            this.txtPaxNumber.MaxLength = 4;
            this.txtPaxNumber.Name = "txtPaxNumber";
            this.txtPaxNumber.Size = new System.Drawing.Size(35, 20);
            this.txtPaxNumber.TabIndex = 4;
            this.txtPaxNumber.TextChanged += new System.EventHandler(this.txtControls_TextChanged);
            this.txtPaxNumber.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.Location = new System.Drawing.Point(30, 189);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(66, 13);
            this.lblDescription.TabIndex = 0;
            this.lblDescription.Text = "Descripción:";
            // 
            // txtDescription
            // 
            this.txtDescription.AllowBlankSpaces = true;
            this.txtDescription.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtDescription.CharsIncluded = new char[] {
        '.'};
            this.txtDescription.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.AnyCharacter;
            this.txtDescription.CustomExpression = ".*";
            this.txtDescription.EnterColor = System.Drawing.Color.Empty;
            this.txtDescription.LeaveColor = System.Drawing.Color.Empty;
            this.txtDescription.Location = new System.Drawing.Point(122, 186);
            this.txtDescription.MaxLength = 40;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(276, 20);
            this.txtDescription.TabIndex = 5;
            this.txtDescription.TextChanged += new System.EventHandler(this.txtControls_TextChanged);
            this.txtDescription.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // btnAccept
            // 
            this.btnAccept.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnAccept.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAccept.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAccept.Location = new System.Drawing.Point(298, 251);
            this.btnAccept.Name = "btnAccept";
            this.btnAccept.Size = new System.Drawing.Size(100, 23);
            this.btnAccept.TabIndex = 6;
            this.btnAccept.Text = "Aceptar";
            this.btnAccept.UseVisualStyleBackColor = false;
            this.btnAccept.Click += new System.EventHandler(this.btnAccept_Click);
            // 
            // ucSpecialServicesSSR
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.btnAccept);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.lblDescription);
            this.Controls.Add(this.txtPaxNumber);
            this.Controls.Add(this.lblPaxNumber);
            this.Controls.Add(this.txtSegment);
            this.Controls.Add(this.lblSegment);
            this.Controls.Add(this.cmbCode);
            this.Controls.Add(this.lblCode);
            this.Controls.Add(this.txtAirline);
            this.Controls.Add(this.lblAirLine);
            this.Controls.Add(this.lblTitle);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "ucSpecialServicesSSR";
            this.Size = new System.Drawing.Size(411, 580);
            this.Load += new System.EventHandler(this.ucSpecialServicesSSR_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblAirLine;
        private MyCTS.Forms.UI.SmartTextBox txtAirline;
        private System.Windows.Forms.Label lblCode;
        private System.Windows.Forms.ComboBox cmbCode;
        private System.Windows.Forms.Label lblSegment;
        private MyCTS.Forms.UI.SmartTextBox txtSegment;
        private System.Windows.Forms.Label lblPaxNumber;
        private MyCTS.Forms.UI.SmartTextBox txtPaxNumber;
        private System.Windows.Forms.Label lblDescription;
        private MyCTS.Forms.UI.SmartTextBox txtDescription;
        private System.Windows.Forms.Button btnAccept;
    }
}
