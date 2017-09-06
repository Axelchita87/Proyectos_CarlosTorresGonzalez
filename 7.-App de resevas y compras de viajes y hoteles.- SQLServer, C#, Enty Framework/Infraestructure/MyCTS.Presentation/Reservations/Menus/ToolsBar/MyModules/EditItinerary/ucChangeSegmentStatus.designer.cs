namespace MyCTS.Presentation
{
    partial class ucChangeSegmentStatus
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
            this.lblIndent3 = new System.Windows.Forms.Label();
            this.txtSegment3 = new MyCTS.Forms.UI.SmartTextBox();
            this.lblIndent2 = new System.Windows.Forms.Label();
            this.txtSegment2 = new MyCTS.Forms.UI.SmartTextBox();
            this.lblIndent1 = new System.Windows.Forms.Label();
            this.txtSegment1 = new MyCTS.Forms.UI.SmartTextBox();
            this.lblRangeSegment = new System.Windows.Forms.Label();
            this.lblSegment = new System.Windows.Forms.Label();
            this.txtStatusCode1 = new MyCTS.Forms.UI.SmartTextBox();
            this.lblSegmentStatus = new System.Windows.Forms.Label();
            this.txtStatusCode2 = new MyCTS.Forms.UI.SmartTextBox();
            this.txtStatusCode3 = new MyCTS.Forms.UI.SmartTextBox();
            this.btnAccept = new System.Windows.Forms.Button();
            this.txtRange3 = new MyCTS.Forms.UI.SmartTextBox();
            this.txtRange2 = new MyCTS.Forms.UI.SmartTextBox();
            this.txtRange1 = new MyCTS.Forms.UI.SmartTextBox();
            this.txtRange4 = new MyCTS.Forms.UI.SmartTextBox();
            this.txtStatusCode4 = new MyCTS.Forms.UI.SmartTextBox();
            this.lblIndent4 = new System.Windows.Forms.Label();
            this.txtSegment4 = new MyCTS.Forms.UI.SmartTextBox();
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
            this.lblTitle.Text = "Cambia Status de Segmento";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblIndent3
            // 
            this.lblIndent3.AutoSize = true;
            this.lblIndent3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIndent3.ForeColor = System.Drawing.Color.Black;
            this.lblIndent3.Location = new System.Drawing.Point(88, 164);
            this.lblIndent3.Name = "lblIndent3";
            this.lblIndent3.Size = new System.Drawing.Size(14, 20);
            this.lblIndent3.TabIndex = 0;
            this.lblIndent3.Text = "-";
            // 
            // txtSegment3
            // 
            this.txtSegment3.AllowBlankSpaces = false;
            this.txtSegment3.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtSegment3.CharsIncluded = new char[0];
            this.txtSegment3.CharsNoIncluded = new char[0];
            this.txtSegment3.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.OnlyNumbers;
            this.txtSegment3.CustomExpression = "@\"^[0-9]{1,2}[.]{1}[0-9]{1}$\"";
            this.txtSegment3.EnterColor = System.Drawing.Color.Empty;
            this.txtSegment3.LeaveColor = System.Drawing.Color.Empty;
            this.txtSegment3.Location = new System.Drawing.Point(50, 166);
            this.txtSegment3.MaxLength = 2;
            this.txtSegment3.Name = "txtSegment3";
            this.txtSegment3.Size = new System.Drawing.Size(25, 20);
            this.txtSegment3.TabIndex = 7;
            this.txtSegment3.TextChanged += new System.EventHandler(this.txtControls_TextChanged);
            this.txtSegment3.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // lblIndent2
            // 
            this.lblIndent2.AutoSize = true;
            this.lblIndent2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIndent2.ForeColor = System.Drawing.Color.Black;
            this.lblIndent2.Location = new System.Drawing.Point(88, 133);
            this.lblIndent2.Name = "lblIndent2";
            this.lblIndent2.Size = new System.Drawing.Size(14, 20);
            this.lblIndent2.TabIndex = 0;
            this.lblIndent2.Text = "-";
            // 
            // txtSegment2
            // 
            this.txtSegment2.AllowBlankSpaces = false;
            this.txtSegment2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtSegment2.CharsIncluded = new char[0];
            this.txtSegment2.CharsNoIncluded = new char[0];
            this.txtSegment2.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.OnlyNumbers;
            this.txtSegment2.CustomExpression = "@\"^[0-9]{1,2}[.]{1}[0-9]{1}$\"";
            this.txtSegment2.EnterColor = System.Drawing.Color.Empty;
            this.txtSegment2.LeaveColor = System.Drawing.Color.Empty;
            this.txtSegment2.Location = new System.Drawing.Point(50, 135);
            this.txtSegment2.MaxLength = 2;
            this.txtSegment2.Name = "txtSegment2";
            this.txtSegment2.Size = new System.Drawing.Size(25, 20);
            this.txtSegment2.TabIndex = 4;
            this.txtSegment2.TextChanged += new System.EventHandler(this.txtControls_TextChanged);
            this.txtSegment2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // lblIndent1
            // 
            this.lblIndent1.AutoSize = true;
            this.lblIndent1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIndent1.ForeColor = System.Drawing.Color.Black;
            this.lblIndent1.Location = new System.Drawing.Point(88, 102);
            this.lblIndent1.Name = "lblIndent1";
            this.lblIndent1.Size = new System.Drawing.Size(14, 20);
            this.lblIndent1.TabIndex = 0;
            this.lblIndent1.Text = "-";
            // 
            // txtSegment1
            // 
            this.txtSegment1.AllowBlankSpaces = false;
            this.txtSegment1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtSegment1.CharsIncluded = new char[0];
            this.txtSegment1.CharsNoIncluded = new char[0];
            this.txtSegment1.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.OnlyNumbers;
            this.txtSegment1.CustomExpression = "@\"^[0-9]{1,2}[.]{1}[0-9]{1}$\"";
            this.txtSegment1.EnterColor = System.Drawing.Color.Empty;
            this.txtSegment1.LeaveColor = System.Drawing.Color.Empty;
            this.txtSegment1.Location = new System.Drawing.Point(50, 104);
            this.txtSegment1.MaxLength = 2;
            this.txtSegment1.Name = "txtSegment1";
            this.txtSegment1.Size = new System.Drawing.Size(25, 20);
            this.txtSegment1.TabIndex = 1;
            this.txtSegment1.TextChanged += new System.EventHandler(this.txtControls_TextChanged);
            this.txtSegment1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // lblRangeSegment
            // 
            this.lblRangeSegment.AutoSize = true;
            this.lblRangeSegment.ForeColor = System.Drawing.Color.DarkCyan;
            this.lblRangeSegment.Location = new System.Drawing.Point(110, 78);
            this.lblRangeSegment.Name = "lblRangeSegment";
            this.lblRangeSegment.Size = new System.Drawing.Size(39, 13);
            this.lblRangeSegment.TabIndex = 0;
            this.lblRangeSegment.Text = "Rango";
            // 
            // lblSegment
            // 
            this.lblSegment.AutoSize = true;
            this.lblSegment.ForeColor = System.Drawing.Color.Black;
            this.lblSegment.Location = new System.Drawing.Point(35, 78);
            this.lblSegment.Name = "lblSegment";
            this.lblSegment.Size = new System.Drawing.Size(55, 13);
            this.lblSegment.TabIndex = 0;
            this.lblSegment.Text = "Segmento";
            // 
            // txtStatusCode1
            // 
            this.txtStatusCode1.AllowBlankSpaces = false;
            this.txtStatusCode1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtStatusCode1.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.OnlyLetters;
            this.txtStatusCode1.CustomExpression = ".*";
            this.txtStatusCode1.EnterColor = System.Drawing.Color.Empty;
            this.txtStatusCode1.LeaveColor = System.Drawing.Color.Empty;
            this.txtStatusCode1.Location = new System.Drawing.Point(182, 104);
            this.txtStatusCode1.MaxLength = 2;
            this.txtStatusCode1.Name = "txtStatusCode1";
            this.txtStatusCode1.Size = new System.Drawing.Size(25, 20);
            this.txtStatusCode1.TabIndex = 3;
            this.txtStatusCode1.TextChanged += new System.EventHandler(this.txtControls_TextChanged);
            this.txtStatusCode1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // lblSegmentStatus
            // 
            this.lblSegmentStatus.AutoSize = true;
            this.lblSegmentStatus.ForeColor = System.Drawing.Color.DarkCyan;
            this.lblSegmentStatus.Location = new System.Drawing.Point(162, 78);
            this.lblSegmentStatus.Name = "lblSegmentStatus";
            this.lblSegmentStatus.Size = new System.Drawing.Size(73, 13);
            this.lblSegmentStatus.TabIndex = 0;
            this.lblSegmentStatus.Text = "Código Status";
            // 
            // txtStatusCode2
            // 
            this.txtStatusCode2.AllowBlankSpaces = false;
            this.txtStatusCode2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtStatusCode2.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.OnlyLetters;
            this.txtStatusCode2.CustomExpression = ".*";
            this.txtStatusCode2.EnterColor = System.Drawing.Color.Empty;
            this.txtStatusCode2.LeaveColor = System.Drawing.Color.Empty;
            this.txtStatusCode2.Location = new System.Drawing.Point(182, 135);
            this.txtStatusCode2.MaxLength = 2;
            this.txtStatusCode2.Name = "txtStatusCode2";
            this.txtStatusCode2.Size = new System.Drawing.Size(25, 20);
            this.txtStatusCode2.TabIndex = 6;
            this.txtStatusCode2.TextChanged += new System.EventHandler(this.txtControls_TextChanged);
            this.txtStatusCode2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // txtStatusCode3
            // 
            this.txtStatusCode3.AllowBlankSpaces = false;
            this.txtStatusCode3.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtStatusCode3.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.OnlyLetters;
            this.txtStatusCode3.CustomExpression = ".*";
            this.txtStatusCode3.EnterColor = System.Drawing.Color.Empty;
            this.txtStatusCode3.LeaveColor = System.Drawing.Color.Empty;
            this.txtStatusCode3.Location = new System.Drawing.Point(182, 166);
            this.txtStatusCode3.MaxLength = 2;
            this.txtStatusCode3.Name = "txtStatusCode3";
            this.txtStatusCode3.Size = new System.Drawing.Size(25, 20);
            this.txtStatusCode3.TabIndex = 9;
            this.txtStatusCode3.TextChanged += new System.EventHandler(this.txtControls_TextChanged);
            this.txtStatusCode3.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // btnAccept
            // 
            this.btnAccept.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnAccept.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAccept.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAccept.Location = new System.Drawing.Point(269, 229);
            this.btnAccept.Name = "btnAccept";
            this.btnAccept.Size = new System.Drawing.Size(100, 23);
            this.btnAccept.TabIndex = 13;
            this.btnAccept.Text = "Aceptar";
            this.btnAccept.UseVisualStyleBackColor = false;
            this.btnAccept.Click += new System.EventHandler(this.btnAccept_Click);
            // 
            // txtRange3
            // 
            this.txtRange3.AllowBlankSpaces = false;
            this.txtRange3.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtRange3.CharsIncluded = new char[0];
            this.txtRange3.CharsNoIncluded = new char[0];
            this.txtRange3.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.OnlyNumbers;
            this.txtRange3.CustomExpression = "@\"^[0-9]{1,2}[.]{1}[0-9]{1}$\"";
            this.txtRange3.EnterColor = System.Drawing.Color.Empty;
            this.txtRange3.LeaveColor = System.Drawing.Color.Empty;
            this.txtRange3.Location = new System.Drawing.Point(113, 166);
            this.txtRange3.MaxLength = 2;
            this.txtRange3.Name = "txtRange3";
            this.txtRange3.Size = new System.Drawing.Size(25, 20);
            this.txtRange3.TabIndex = 8;
            this.txtRange3.TextChanged += new System.EventHandler(this.txtControls_TextChanged);
            this.txtRange3.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // txtRange2
            // 
            this.txtRange2.AllowBlankSpaces = false;
            this.txtRange2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtRange2.CharsIncluded = new char[0];
            this.txtRange2.CharsNoIncluded = new char[0];
            this.txtRange2.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.OnlyNumbers;
            this.txtRange2.CustomExpression = "@\"^[0-9]{1,2}[.]{1}[0-9]{1}$\"";
            this.txtRange2.EnterColor = System.Drawing.Color.Empty;
            this.txtRange2.LeaveColor = System.Drawing.Color.Empty;
            this.txtRange2.Location = new System.Drawing.Point(113, 135);
            this.txtRange2.MaxLength = 2;
            this.txtRange2.Name = "txtRange2";
            this.txtRange2.Size = new System.Drawing.Size(25, 20);
            this.txtRange2.TabIndex = 5;
            this.txtRange2.TextChanged += new System.EventHandler(this.txtControls_TextChanged);
            this.txtRange2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // txtRange1
            // 
            this.txtRange1.AllowBlankSpaces = false;
            this.txtRange1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtRange1.CharsIncluded = new char[0];
            this.txtRange1.CharsNoIncluded = new char[0];
            this.txtRange1.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.OnlyNumbers;
            this.txtRange1.CustomExpression = "@\"^[0-9]{1,2}[.]{1}[0-9]{1}$\"";
            this.txtRange1.EnterColor = System.Drawing.Color.Empty;
            this.txtRange1.LeaveColor = System.Drawing.Color.Empty;
            this.txtRange1.Location = new System.Drawing.Point(113, 104);
            this.txtRange1.MaxLength = 2;
            this.txtRange1.Name = "txtRange1";
            this.txtRange1.Size = new System.Drawing.Size(25, 20);
            this.txtRange1.TabIndex = 2;
            this.txtRange1.TextChanged += new System.EventHandler(this.txtControls_TextChanged);
            this.txtRange1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // txtRange4
            // 
            this.txtRange4.AllowBlankSpaces = false;
            this.txtRange4.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtRange4.CharsIncluded = new char[0];
            this.txtRange4.CharsNoIncluded = new char[0];
            this.txtRange4.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.OnlyNumbers;
            this.txtRange4.CustomExpression = "@\"^[0-9]{1,2}[.]{1}[0-9]{1}$\"";
            this.txtRange4.EnterColor = System.Drawing.Color.Empty;
            this.txtRange4.LeaveColor = System.Drawing.Color.Empty;
            this.txtRange4.Location = new System.Drawing.Point(113, 194);
            this.txtRange4.MaxLength = 2;
            this.txtRange4.Name = "txtRange4";
            this.txtRange4.Size = new System.Drawing.Size(25, 20);
            this.txtRange4.TabIndex = 11;
            this.txtRange4.TextChanged += new System.EventHandler(this.txtControls_TextChanged);
            this.txtRange4.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // txtStatusCode4
            // 
            this.txtStatusCode4.AllowBlankSpaces = false;
            this.txtStatusCode4.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtStatusCode4.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.OnlyLetters;
            this.txtStatusCode4.CustomExpression = ".*";
            this.txtStatusCode4.EnterColor = System.Drawing.Color.Empty;
            this.txtStatusCode4.LeaveColor = System.Drawing.Color.Empty;
            this.txtStatusCode4.Location = new System.Drawing.Point(182, 194);
            this.txtStatusCode4.MaxLength = 2;
            this.txtStatusCode4.Name = "txtStatusCode4";
            this.txtStatusCode4.Size = new System.Drawing.Size(25, 20);
            this.txtStatusCode4.TabIndex = 12;
            this.txtStatusCode4.TextChanged += new System.EventHandler(this.txtControls_TextChanged);
            this.txtStatusCode4.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // lblIndent4
            // 
            this.lblIndent4.AutoSize = true;
            this.lblIndent4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIndent4.ForeColor = System.Drawing.Color.Black;
            this.lblIndent4.Location = new System.Drawing.Point(88, 192);
            this.lblIndent4.Name = "lblIndent4";
            this.lblIndent4.Size = new System.Drawing.Size(14, 20);
            this.lblIndent4.TabIndex = 0;
            this.lblIndent4.Text = "-";
            // 
            // txtSegment4
            // 
            this.txtSegment4.AllowBlankSpaces = false;
            this.txtSegment4.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtSegment4.CharsIncluded = new char[0];
            this.txtSegment4.CharsNoIncluded = new char[0];
            this.txtSegment4.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.OnlyNumbers;
            this.txtSegment4.CustomExpression = "@\"^[0-9]{1,2}[.]{1}[0-9]{1}$\"";
            this.txtSegment4.EnterColor = System.Drawing.Color.Empty;
            this.txtSegment4.LeaveColor = System.Drawing.Color.Empty;
            this.txtSegment4.Location = new System.Drawing.Point(50, 194);
            this.txtSegment4.MaxLength = 2;
            this.txtSegment4.Name = "txtSegment4";
            this.txtSegment4.Size = new System.Drawing.Size(25, 20);
            this.txtSegment4.TabIndex = 10;
            this.txtSegment4.TextChanged += new System.EventHandler(this.txtControls_TextChanged);
            this.txtSegment4.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // ucChangeSegmentStatus
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.txtRange4);
            this.Controls.Add(this.txtStatusCode4);
            this.Controls.Add(this.lblIndent4);
            this.Controls.Add(this.txtSegment4);
            this.Controls.Add(this.txtRange3);
            this.Controls.Add(this.txtRange2);
            this.Controls.Add(this.txtRange1);
            this.Controls.Add(this.btnAccept);
            this.Controls.Add(this.txtStatusCode3);
            this.Controls.Add(this.txtStatusCode2);
            this.Controls.Add(this.txtStatusCode1);
            this.Controls.Add(this.lblSegmentStatus);
            this.Controls.Add(this.lblIndent3);
            this.Controls.Add(this.txtSegment3);
            this.Controls.Add(this.lblIndent2);
            this.Controls.Add(this.txtSegment2);
            this.Controls.Add(this.lblIndent1);
            this.Controls.Add(this.txtSegment1);
            this.Controls.Add(this.lblRangeSegment);
            this.Controls.Add(this.lblSegment);
            this.Controls.Add(this.lblTitle);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "ucChangeSegmentStatus";
            this.Size = new System.Drawing.Size(411, 580);
            this.Load += new System.EventHandler(this.ucChangeSegmentStatus_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblIndent3;
        private MyCTS.Forms.UI.SmartTextBox txtSegment3;
        private System.Windows.Forms.Label lblIndent2;
        private MyCTS.Forms.UI.SmartTextBox txtSegment2;
        private System.Windows.Forms.Label lblIndent1;
        private MyCTS.Forms.UI.SmartTextBox txtSegment1;
        private System.Windows.Forms.Label lblRangeSegment;
        private System.Windows.Forms.Label lblSegment;
        private MyCTS.Forms.UI.SmartTextBox txtStatusCode1;
        private System.Windows.Forms.Label lblSegmentStatus;
        private MyCTS.Forms.UI.SmartTextBox txtStatusCode2;
        private MyCTS.Forms.UI.SmartTextBox txtStatusCode3;
        private System.Windows.Forms.Button btnAccept;
        private MyCTS.Forms.UI.SmartTextBox txtRange3;
        private MyCTS.Forms.UI.SmartTextBox txtRange2;
        private MyCTS.Forms.UI.SmartTextBox txtRange1;
        private MyCTS.Forms.UI.SmartTextBox txtRange4;
        private MyCTS.Forms.UI.SmartTextBox txtStatusCode4;
        private System.Windows.Forms.Label lblIndent4;
        private MyCTS.Forms.UI.SmartTextBox txtSegment4;
    }
}
