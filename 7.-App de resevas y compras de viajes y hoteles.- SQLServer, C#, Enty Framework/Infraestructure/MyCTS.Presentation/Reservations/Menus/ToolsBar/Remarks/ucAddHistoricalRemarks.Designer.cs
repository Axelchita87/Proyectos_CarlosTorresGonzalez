namespace MyCTS.Presentation
{
    partial class ucAddHistoricalRemarks
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
            this.txtLine4 = new MyCTS.Forms.UI.SmartTextBox();
            this.lblFive4 = new System.Windows.Forms.Label();
            this.txtLine3 = new MyCTS.Forms.UI.SmartTextBox();
            this.lblFive3 = new System.Windows.Forms.Label();
            this.txtLine2 = new MyCTS.Forms.UI.SmartTextBox();
            this.lblFive2 = new System.Windows.Forms.Label();
            this.btnAccept = new System.Windows.Forms.Button();
            this.lblTitle = new System.Windows.Forms.Label();
            this.txtLine1 = new MyCTS.Forms.UI.SmartTextBox();
            this.lblFive1 = new System.Windows.Forms.Label();
            this.lblText = new System.Windows.Forms.Label();
            this.SuspendLayout();
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
            this.txtLine4.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.NumbersOrLetters;
            this.txtLine4.CustomExpression = ".*";
            this.txtLine4.EnterColor = System.Drawing.Color.Empty;
            this.txtLine4.LeaveColor = System.Drawing.Color.Empty;
            this.txtLine4.Location = new System.Drawing.Point(45, 133);
            this.txtLine4.MaxLength = 56;
            this.txtLine4.Name = "txtLine4";
            this.txtLine4.Size = new System.Drawing.Size(326, 20);
            this.txtLine4.TabIndex = 4;
            this.txtLine4.TextChanged += new System.EventHandler(this.txtLine4_TextChanged);
            this.txtLine4.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // lblFive4
            // 
            this.lblFive4.AutoSize = true;
            this.lblFive4.ForeColor = System.Drawing.Color.Blue;
            this.lblFive4.Location = new System.Drawing.Point(20, 136);
            this.lblFive4.Name = "lblFive4";
            this.lblFive4.Size = new System.Drawing.Size(24, 13);
            this.lblFive4.TabIndex = 0;
            this.lblFive4.Text = "5H-";
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
            this.txtLine3.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.NumbersOrLetters;
            this.txtLine3.CustomExpression = ".*";
            this.txtLine3.EnterColor = System.Drawing.Color.Empty;
            this.txtLine3.LeaveColor = System.Drawing.Color.Empty;
            this.txtLine3.Location = new System.Drawing.Point(45, 107);
            this.txtLine3.MaxLength = 56;
            this.txtLine3.Name = "txtLine3";
            this.txtLine3.Size = new System.Drawing.Size(326, 20);
            this.txtLine3.TabIndex = 3;
            this.txtLine3.TextChanged += new System.EventHandler(this.txtLine3_TextChanged);
            this.txtLine3.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // lblFive3
            // 
            this.lblFive3.AutoSize = true;
            this.lblFive3.ForeColor = System.Drawing.Color.Blue;
            this.lblFive3.Location = new System.Drawing.Point(20, 110);
            this.lblFive3.Name = "lblFive3";
            this.lblFive3.Size = new System.Drawing.Size(24, 13);
            this.lblFive3.TabIndex = 0;
            this.lblFive3.Text = "5H-";
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
            this.txtLine2.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.NumbersOrLetters;
            this.txtLine2.CustomExpression = ".*";
            this.txtLine2.EnterColor = System.Drawing.Color.Empty;
            this.txtLine2.LeaveColor = System.Drawing.Color.Empty;
            this.txtLine2.Location = new System.Drawing.Point(45, 81);
            this.txtLine2.MaxLength = 56;
            this.txtLine2.Name = "txtLine2";
            this.txtLine2.Size = new System.Drawing.Size(326, 20);
            this.txtLine2.TabIndex = 2;
            this.txtLine2.TextChanged += new System.EventHandler(this.txtLine2_TextChanged);
            this.txtLine2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // lblFive2
            // 
            this.lblFive2.AutoSize = true;
            this.lblFive2.ForeColor = System.Drawing.Color.Blue;
            this.lblFive2.Location = new System.Drawing.Point(20, 84);
            this.lblFive2.Name = "lblFive2";
            this.lblFive2.Size = new System.Drawing.Size(24, 13);
            this.lblFive2.TabIndex = 0;
            this.lblFive2.Text = "5H-";
            // 
            // btnAccept
            // 
            this.btnAccept.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnAccept.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAccept.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAccept.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAccept.Location = new System.Drawing.Point(266, 235);
            this.btnAccept.Name = "btnAccept";
            this.btnAccept.Size = new System.Drawing.Size(120, 24);
            this.btnAccept.TabIndex = 5;
            this.btnAccept.Text = "Aceptar";
            this.btnAccept.UseVisualStyleBackColor = false;
            this.btnAccept.Click += new System.EventHandler(this.btnAccept_Click);
            // 
            // lblTitle
            // 
            this.lblTitle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(139)))), ((int)(((byte)(208)))));
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(3, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(405, 15);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Remarks Historicos - Agregar";
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
            this.txtLine1.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.NumbersOrLetters;
            this.txtLine1.CustomExpression = ".*";
            this.txtLine1.EnterColor = System.Drawing.Color.Empty;
            this.txtLine1.LeaveColor = System.Drawing.Color.Empty;
            this.txtLine1.Location = new System.Drawing.Point(45, 55);
            this.txtLine1.MaxLength = 56;
            this.txtLine1.Name = "txtLine1";
            this.txtLine1.Size = new System.Drawing.Size(326, 20);
            this.txtLine1.TabIndex = 1;
            this.txtLine1.TextChanged += new System.EventHandler(this.txtLine1_TextChanged);
            this.txtLine1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // lblFive1
            // 
            this.lblFive1.AutoSize = true;
            this.lblFive1.ForeColor = System.Drawing.Color.Blue;
            this.lblFive1.Location = new System.Drawing.Point(20, 58);
            this.lblFive1.Name = "lblFive1";
            this.lblFive1.Size = new System.Drawing.Size(24, 13);
            this.lblFive1.TabIndex = 0;
            this.lblFive1.Text = "5H-";
            // 
            // lblText
            // 
            this.lblText.AutoSize = true;
            this.lblText.ForeColor = System.Drawing.Color.DarkCyan;
            this.lblText.Location = new System.Drawing.Point(178, 36);
            this.lblText.Name = "lblText";
            this.lblText.Size = new System.Drawing.Size(34, 13);
            this.lblText.TabIndex = 6;
            this.lblText.Text = "Texto";
            // 
            // ucAddHistoricalRemarks
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.lblText);
            this.Controls.Add(this.txtLine4);
            this.Controls.Add(this.lblFive4);
            this.Controls.Add(this.txtLine3);
            this.Controls.Add(this.lblFive3);
            this.Controls.Add(this.txtLine2);
            this.Controls.Add(this.lblFive2);
            this.Controls.Add(this.btnAccept);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.txtLine1);
            this.Controls.Add(this.lblFive1);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "ucAddHistoricalRemarks";
            this.Size = new System.Drawing.Size(411, 580);
            this.Load += new System.EventHandler(this.ucAddHistoricalRemarks_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MyCTS.Forms.UI.SmartTextBox txtLine4;
        private System.Windows.Forms.Label lblFive4;
        private MyCTS.Forms.UI.SmartTextBox txtLine3;
        private System.Windows.Forms.Label lblFive3;
        private MyCTS.Forms.UI.SmartTextBox txtLine2;
        private System.Windows.Forms.Label lblFive2;
        private System.Windows.Forms.Button btnAccept;
        internal System.Windows.Forms.Label lblTitle;
        private MyCTS.Forms.UI.SmartTextBox txtLine1;
        private System.Windows.Forms.Label lblFive1;
        private System.Windows.Forms.Label lblText;
    }
}
