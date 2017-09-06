namespace MyCTS.Presentation
{
    partial class ucOrderSegments
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
            this.txtInsert = new MyCTS.Forms.UI.SmartTextBox();
            this.lblInsert = new System.Windows.Forms.Label();
            this.lblSegment = new System.Windows.Forms.Label();
            this.lblRango = new System.Windows.Forms.Label();
            this.lblLine = new System.Windows.Forms.Label();
            this.txtSegment1 = new MyCTS.Forms.UI.SmartTextBox();
            this.txtSegment2 = new MyCTS.Forms.UI.SmartTextBox();
            this.txtSegment3 = new MyCTS.Forms.UI.SmartTextBox();
            this.txtRange = new MyCTS.Forms.UI.SmartTextBox();
            this.txtSegment4 = new MyCTS.Forms.UI.SmartTextBox();
            this.txtSegment5 = new MyCTS.Forms.UI.SmartTextBox();
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
            this.lblTitle.TabIndex = 3;
            this.lblTitle.Text = "Ordenar Segmentos";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // txtInsert
            // 
            this.txtInsert.AllowBlankSpaces = false;
            this.txtInsert.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtInsert.CharsNoIncluded = new char[] {
        '0'};
            this.txtInsert.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.OnlyNumbers;
            this.txtInsert.CustomExpression = ".*";
            this.txtInsert.EnterColor = System.Drawing.Color.Empty;
            this.txtInsert.LeaveColor = System.Drawing.Color.Empty;
            this.txtInsert.Location = new System.Drawing.Point(187, 50);
            this.txtInsert.MaxLength = 2;
            this.txtInsert.Name = "txtInsert";
            this.txtInsert.Size = new System.Drawing.Size(28, 20);
            this.txtInsert.TabIndex = 1;
            this.txtInsert.TextChanged += new System.EventHandler(this.txtControls_TextChanged);
            this.txtInsert.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // lblInsert
            // 
            this.lblInsert.AutoSize = true;
            this.lblInsert.Location = new System.Drawing.Point(33, 56);
            this.lblInsert.Name = "lblInsert";
            this.lblInsert.Size = new System.Drawing.Size(134, 13);
            this.lblInsert.TabIndex = 9;
            this.lblInsert.Text = "¿Insertar tras el segmento?";
            // 
            // lblSegment
            // 
            this.lblSegment.AutoSize = true;
            this.lblSegment.ForeColor = System.Drawing.Color.DarkCyan;
            this.lblSegment.Location = new System.Drawing.Point(51, 95);
            this.lblSegment.Name = "lblSegment";
            this.lblSegment.Size = new System.Drawing.Size(55, 13);
            this.lblSegment.TabIndex = 10;
            this.lblSegment.Text = "Segmento";
            // 
            // lblRango
            // 
            this.lblRango.AutoSize = true;
            this.lblRango.ForeColor = System.Drawing.Color.DarkCyan;
            this.lblRango.Location = new System.Drawing.Point(137, 95);
            this.lblRango.Name = "lblRango";
            this.lblRango.Size = new System.Drawing.Size(39, 13);
            this.lblRango.TabIndex = 11;
            this.lblRango.Text = "Rango";
            // 
            // lblLine
            // 
            this.lblLine.AutoSize = true;
            this.lblLine.ForeColor = System.Drawing.Color.DarkCyan;
            this.lblLine.Location = new System.Drawing.Point(107, 118);
            this.lblLine.Name = "lblLine";
            this.lblLine.Size = new System.Drawing.Size(19, 13);
            this.lblLine.TabIndex = 12;
            this.lblLine.Text = "__";
            // 
            // txtSegment1
            // 
            this.txtSegment1.AllowBlankSpaces = false;
            this.txtSegment1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtSegment1.CharsNoIncluded = new char[] {
        '0'};
            this.txtSegment1.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.OnlyNumbers;
            this.txtSegment1.CustomExpression = ".*";
            this.txtSegment1.EnterColor = System.Drawing.Color.Empty;
            this.txtSegment1.LeaveColor = System.Drawing.Color.Empty;
            this.txtSegment1.Location = new System.Drawing.Point(63, 119);
            this.txtSegment1.MaxLength = 2;
            this.txtSegment1.Name = "txtSegment1";
            this.txtSegment1.Size = new System.Drawing.Size(28, 20);
            this.txtSegment1.TabIndex = 2;
            this.txtSegment1.TextChanged += new System.EventHandler(this.txtControls_TextChanged);
            this.txtSegment1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // txtSegment2
            // 
            this.txtSegment2.AllowBlankSpaces = false;
            this.txtSegment2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtSegment2.CharsNoIncluded = new char[] {
        '0'};
            this.txtSegment2.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.OnlyNumbers;
            this.txtSegment2.CustomExpression = ".*";
            this.txtSegment2.EnterColor = System.Drawing.Color.Empty;
            this.txtSegment2.LeaveColor = System.Drawing.Color.Empty;
            this.txtSegment2.Location = new System.Drawing.Point(63, 145);
            this.txtSegment2.MaxLength = 2;
            this.txtSegment2.Name = "txtSegment2";
            this.txtSegment2.Size = new System.Drawing.Size(28, 20);
            this.txtSegment2.TabIndex = 4;
            this.txtSegment2.TextChanged += new System.EventHandler(this.txtControls_TextChanged);
            this.txtSegment2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // txtSegment3
            // 
            this.txtSegment3.AllowBlankSpaces = false;
            this.txtSegment3.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtSegment3.CharsNoIncluded = new char[] {
        '0'};
            this.txtSegment3.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.OnlyNumbers;
            this.txtSegment3.CustomExpression = ".*";
            this.txtSegment3.EnterColor = System.Drawing.Color.Empty;
            this.txtSegment3.LeaveColor = System.Drawing.Color.Empty;
            this.txtSegment3.Location = new System.Drawing.Point(63, 171);
            this.txtSegment3.MaxLength = 2;
            this.txtSegment3.Name = "txtSegment3";
            this.txtSegment3.Size = new System.Drawing.Size(28, 20);
            this.txtSegment3.TabIndex = 5;
            this.txtSegment3.TextChanged += new System.EventHandler(this.txtControls_TextChanged);
            this.txtSegment3.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // txtRange
            // 
            this.txtRange.AllowBlankSpaces = false;
            this.txtRange.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtRange.CharsNoIncluded = new char[] {
        '0'};
            this.txtRange.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.OnlyNumbers;
            this.txtRange.CustomExpression = ".*";
            this.txtRange.EnterColor = System.Drawing.Color.Empty;
            this.txtRange.LeaveColor = System.Drawing.Color.Empty;
            this.txtRange.Location = new System.Drawing.Point(142, 119);
            this.txtRange.MaxLength = 2;
            this.txtRange.Name = "txtRange";
            this.txtRange.Size = new System.Drawing.Size(28, 20);
            this.txtRange.TabIndex = 3;
            this.txtRange.TextChanged += new System.EventHandler(this.txtControls_TextChanged);
            this.txtRange.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // txtSegment4
            // 
            this.txtSegment4.AllowBlankSpaces = false;
            this.txtSegment4.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtSegment4.CharsNoIncluded = new char[] {
        '0'};
            this.txtSegment4.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.OnlyNumbers;
            this.txtSegment4.CustomExpression = ".*";
            this.txtSegment4.EnterColor = System.Drawing.Color.Empty;
            this.txtSegment4.LeaveColor = System.Drawing.Color.Empty;
            this.txtSegment4.Location = new System.Drawing.Point(63, 197);
            this.txtSegment4.MaxLength = 2;
            this.txtSegment4.Name = "txtSegment4";
            this.txtSegment4.Size = new System.Drawing.Size(28, 20);
            this.txtSegment4.TabIndex = 6;
            this.txtSegment4.TextChanged += new System.EventHandler(this.txtControls_TextChanged);
            this.txtSegment4.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // txtSegment5
            // 
            this.txtSegment5.AllowBlankSpaces = false;
            this.txtSegment5.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtSegment5.CharsNoIncluded = new char[] {
        '0'};
            this.txtSegment5.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.OnlyNumbers;
            this.txtSegment5.CustomExpression = ".*";
            this.txtSegment5.EnterColor = System.Drawing.Color.Empty;
            this.txtSegment5.LeaveColor = System.Drawing.Color.Empty;
            this.txtSegment5.Location = new System.Drawing.Point(63, 223);
            this.txtSegment5.MaxLength = 2;
            this.txtSegment5.Name = "txtSegment5";
            this.txtSegment5.Size = new System.Drawing.Size(28, 20);
            this.txtSegment5.TabIndex = 7;
            this.txtSegment5.TextChanged += new System.EventHandler(this.txtControls_TextChanged);
            this.txtSegment5.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // btnAccept
            // 
            this.btnAccept.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnAccept.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAccept.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAccept.Location = new System.Drawing.Point(260, 280);
            this.btnAccept.Name = "btnAccept";
            this.btnAccept.Size = new System.Drawing.Size(100, 23);
            this.btnAccept.TabIndex = 8;
            this.btnAccept.Text = "Aceptar";
            this.btnAccept.UseVisualStyleBackColor = false;
            this.btnAccept.Click += new System.EventHandler(this.btnAccept_Click);
            // 
            // ucOrderSegments
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.btnAccept);
            this.Controls.Add(this.lblLine);
            this.Controls.Add(this.lblRango);
            this.Controls.Add(this.lblSegment);
            this.Controls.Add(this.lblInsert);
            this.Controls.Add(this.txtSegment5);
            this.Controls.Add(this.txtSegment4);
            this.Controls.Add(this.txtSegment3);
            this.Controls.Add(this.txtRange);
            this.Controls.Add(this.txtSegment2);
            this.Controls.Add(this.txtSegment1);
            this.Controls.Add(this.txtInsert);
            this.Controls.Add(this.lblTitle);
            this.Name = "ucOrderSegments";
            this.Size = new System.Drawing.Size(411, 580);
            this.Load += new System.EventHandler(this.ucOrderSegments_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.Label lblTitle;
        private MyCTS.Forms.UI.SmartTextBox txtInsert;
        private System.Windows.Forms.Label lblInsert;
        private System.Windows.Forms.Label lblSegment;
        private System.Windows.Forms.Label lblRango;
        private System.Windows.Forms.Label lblLine;
        private MyCTS.Forms.UI.SmartTextBox txtSegment1;
        private MyCTS.Forms.UI.SmartTextBox txtSegment2;
        private MyCTS.Forms.UI.SmartTextBox txtSegment3;
        private MyCTS.Forms.UI.SmartTextBox txtRange;
        private MyCTS.Forms.UI.SmartTextBox txtSegment4;
        private MyCTS.Forms.UI.SmartTextBox txtSegment5;
        private System.Windows.Forms.Button btnAccept;
    }
}
