namespace MyCTS.Presentation
{
    partial class ucAddAccountingRemarks
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
            this.txtLine1 = new MyCTS.Forms.UI.SmartTextBox();
            this.lblLine1 = new System.Windows.Forms.Label();
            this.lblLine2 = new System.Windows.Forms.Label();
            this.lblLine3 = new System.Windows.Forms.Label();
            this.lblLine4 = new System.Windows.Forms.Label();
            this.btnAccept = new System.Windows.Forms.Button();
            this.lblTexto = new System.Windows.Forms.Label();
            this.txtLine2 = new MyCTS.Forms.UI.SmartTextBox();
            this.txtLine3 = new MyCTS.Forms.UI.SmartTextBox();
            this.txtLine4 = new MyCTS.Forms.UI.SmartTextBox();
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
            this.lblTitle.TabIndex = 1;
            this.lblTitle.Text = "Remarks Contables - Agregar";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // txtLine1
            // 
            this.txtLine1.AllowBlankSpaces = true;
            this.txtLine1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtLine1.CharsIncluded = new char[] {
        ',',
        '.',
        '/',
        '*',
        '-'};
            this.txtLine1.CharsNoIncluded = new char[] {
        'Ñ'};
            this.txtLine1.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.NumbersOrLetters;
            this.txtLine1.CustomExpression = ".*";
            this.txtLine1.EnterColor = System.Drawing.Color.Empty;
            this.txtLine1.LeaveColor = System.Drawing.Color.Empty;
            this.txtLine1.Location = new System.Drawing.Point(58, 76);
            this.txtLine1.MaxLength = 200;
            this.txtLine1.Name = "txtLine1";
            this.txtLine1.Size = new System.Drawing.Size(317, 20);
            this.txtLine1.TabIndex = 1;
            this.txtLine1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // lblLine1
            // 
            this.lblLine1.AutoSize = true;
            this.lblLine1.ForeColor = System.Drawing.Color.Blue;
            this.lblLine1.Location = new System.Drawing.Point(37, 79);
            this.lblLine1.Name = "lblLine1";
            this.lblLine1.Size = new System.Drawing.Size(16, 13);
            this.lblLine1.TabIndex = 4;
            this.lblLine1.Text = "5.";
            // 
            // lblLine2
            // 
            this.lblLine2.AutoSize = true;
            this.lblLine2.ForeColor = System.Drawing.Color.Blue;
            this.lblLine2.Location = new System.Drawing.Point(37, 105);
            this.lblLine2.Name = "lblLine2";
            this.lblLine2.Size = new System.Drawing.Size(16, 13);
            this.lblLine2.TabIndex = 4;
            this.lblLine2.Text = "5.";
            // 
            // lblLine3
            // 
            this.lblLine3.AutoSize = true;
            this.lblLine3.ForeColor = System.Drawing.Color.Blue;
            this.lblLine3.Location = new System.Drawing.Point(37, 131);
            this.lblLine3.Name = "lblLine3";
            this.lblLine3.Size = new System.Drawing.Size(16, 13);
            this.lblLine3.TabIndex = 4;
            this.lblLine3.Text = "5.";
            // 
            // lblLine4
            // 
            this.lblLine4.AutoSize = true;
            this.lblLine4.ForeColor = System.Drawing.Color.Blue;
            this.lblLine4.Location = new System.Drawing.Point(37, 157);
            this.lblLine4.Name = "lblLine4";
            this.lblLine4.Size = new System.Drawing.Size(16, 13);
            this.lblLine4.TabIndex = 4;
            this.lblLine4.Text = "5.";
            // 
            // btnAccept
            // 
            this.btnAccept.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnAccept.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAccept.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAccept.Location = new System.Drawing.Point(275, 245);
            this.btnAccept.Name = "btnAccept";
            this.btnAccept.Size = new System.Drawing.Size(100, 23);
            this.btnAccept.TabIndex = 10;
            this.btnAccept.Text = "Aceptar";
            this.btnAccept.UseVisualStyleBackColor = false;
            this.btnAccept.Click += new System.EventHandler(this.btnAccept_Click);
            // 
            // lblTexto
            // 
            this.lblTexto.AutoSize = true;
            this.lblTexto.ForeColor = System.Drawing.Color.DarkCyan;
            this.lblTexto.Location = new System.Drawing.Point(193, 52);
            this.lblTexto.Name = "lblTexto";
            this.lblTexto.Size = new System.Drawing.Size(34, 13);
            this.lblTexto.TabIndex = 4;
            this.lblTexto.Text = "Texto";
            // 
            // txtLine2
            // 
            this.txtLine2.AllowBlankSpaces = true;
            this.txtLine2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtLine2.CharsIncluded = new char[] {
        ',',
        '.',
        '/',
        '*',
        '-'};
            this.txtLine2.CharsNoIncluded = new char[] {
        'Ñ'};
            this.txtLine2.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.NumbersOrLetters;
            this.txtLine2.CustomExpression = ".*";
            this.txtLine2.EnterColor = System.Drawing.Color.Empty;
            this.txtLine2.LeaveColor = System.Drawing.Color.Empty;
            this.txtLine2.Location = new System.Drawing.Point(58, 102);
            this.txtLine2.MaxLength = 200;
            this.txtLine2.Name = "txtLine2";
            this.txtLine2.Size = new System.Drawing.Size(317, 20);
            this.txtLine2.TabIndex = 2;
            this.txtLine2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // txtLine3
            // 
            this.txtLine3.AllowBlankSpaces = true;
            this.txtLine3.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtLine3.CharsIncluded = new char[] {
        ',',
        '.',
        '/',
        '*',
        '-'};
            this.txtLine3.CharsNoIncluded = new char[] {
        'Ñ'};
            this.txtLine3.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.NumbersOrLetters;
            this.txtLine3.CustomExpression = ".*";
            this.txtLine3.EnterColor = System.Drawing.Color.Empty;
            this.txtLine3.LeaveColor = System.Drawing.Color.Empty;
            this.txtLine3.Location = new System.Drawing.Point(58, 128);
            this.txtLine3.MaxLength = 200;
            this.txtLine3.Name = "txtLine3";
            this.txtLine3.Size = new System.Drawing.Size(317, 20);
            this.txtLine3.TabIndex = 3;
            this.txtLine3.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // txtLine4
            // 
            this.txtLine4.AllowBlankSpaces = true;
            this.txtLine4.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtLine4.CharsIncluded = new char[] {
        ',',
        '.',
        '/',
        '*',
        '-'};
            this.txtLine4.CharsNoIncluded = new char[] {
        'Ñ'};
            this.txtLine4.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.NumbersOrLetters;
            this.txtLine4.CustomExpression = ".*";
            this.txtLine4.EnterColor = System.Drawing.Color.Empty;
            this.txtLine4.LeaveColor = System.Drawing.Color.Empty;
            this.txtLine4.Location = new System.Drawing.Point(58, 154);
            this.txtLine4.MaxLength = 200;
            this.txtLine4.Name = "txtLine4";
            this.txtLine4.Size = new System.Drawing.Size(317, 20);
            this.txtLine4.TabIndex = 4;
            this.txtLine4.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // ucAddAccountingRemarks
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.btnAccept);
            this.Controls.Add(this.lblLine4);
            this.Controls.Add(this.lblLine3);
            this.Controls.Add(this.lblLine2);
            this.Controls.Add(this.lblTexto);
            this.Controls.Add(this.lblLine1);
            this.Controls.Add(this.txtLine4);
            this.Controls.Add(this.txtLine3);
            this.Controls.Add(this.txtLine2);
            this.Controls.Add(this.txtLine1);
            this.Controls.Add(this.lblTitle);
            this.Name = "ucAddAccountingRemarks";
            this.Size = new System.Drawing.Size(411, 580);
            this.Load += new System.EventHandler(this.ucAddAccountingRemarks_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.Label lblTitle;
        private MyCTS.Forms.UI.SmartTextBox txtLine1;
        private System.Windows.Forms.Label lblLine1;
        private System.Windows.Forms.Label lblLine2;
        private System.Windows.Forms.Label lblLine3;
        private System.Windows.Forms.Label lblLine4;
        private System.Windows.Forms.Button btnAccept;
        private System.Windows.Forms.Label lblTexto;
        private MyCTS.Forms.UI.SmartTextBox txtLine2;
        private MyCTS.Forms.UI.SmartTextBox txtLine3;
        private MyCTS.Forms.UI.SmartTextBox txtLine4;
    }
}
