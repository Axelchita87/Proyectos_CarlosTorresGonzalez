namespace MyCTS.Presentation
{
    partial class ucDeleteRemarks
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
            this.lblLine = new System.Windows.Forms.Label();
            this.lblRange = new System.Windows.Forms.Label();
            this.txtLine1 = new MyCTS.Forms.UI.SmartTextBox();
            this.txtRange = new MyCTS.Forms.UI.SmartTextBox();
            this.txtLine2 = new MyCTS.Forms.UI.SmartTextBox();
            this.txtLine3 = new MyCTS.Forms.UI.SmartTextBox();
            this.txtLine4 = new MyCTS.Forms.UI.SmartTextBox();
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
            this.lblTitle.Text = "Remarks - Borrar";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblLine
            // 
            this.lblLine.AutoSize = true;
            this.lblLine.Location = new System.Drawing.Point(52, 65);
            this.lblLine.Name = "lblLine";
            this.lblLine.Size = new System.Drawing.Size(35, 13);
            this.lblLine.TabIndex = 4;
            this.lblLine.Text = "Línea";
            // 
            // lblRange
            // 
            this.lblRange.AutoSize = true;
            this.lblRange.ForeColor = System.Drawing.Color.DarkCyan;
            this.lblRange.Location = new System.Drawing.Point(124, 65);
            this.lblRange.Name = "lblRange";
            this.lblRange.Size = new System.Drawing.Size(39, 13);
            this.lblRange.TabIndex = 5;
            this.lblRange.Text = "Rango";
            // 
            // txtLine1
            // 
            this.txtLine1.AllowBlankSpaces = false;
            this.txtLine1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtLine1.CharsIncluded = new char[0];
            this.txtLine1.CharsNoIncluded = new char[0];
            this.txtLine1.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.OnlyNumbers;
            this.txtLine1.CustomExpression = ".*";
            this.txtLine1.EnterColor = System.Drawing.Color.Empty;
            this.txtLine1.LeaveColor = System.Drawing.Color.Empty;
            this.txtLine1.Location = new System.Drawing.Point(54, 89);
            this.txtLine1.MaxLength = 2;
            this.txtLine1.Name = "txtLine1";
            this.txtLine1.Size = new System.Drawing.Size(33, 20);
            this.txtLine1.TabIndex = 1;
            this.txtLine1.TextChanged += new System.EventHandler(this.txtControls_TextChanged);
            this.txtLine1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // txtRange
            // 
            this.txtRange.AllowBlankSpaces = false;
            this.txtRange.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtRange.CharsIncluded = new char[0];
            this.txtRange.CharsNoIncluded = new char[0];
            this.txtRange.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.OnlyNumbers;
            this.txtRange.CustomExpression = ".*";
            this.txtRange.EnterColor = System.Drawing.Color.Empty;
            this.txtRange.LeaveColor = System.Drawing.Color.Empty;
            this.txtRange.Location = new System.Drawing.Point(127, 89);
            this.txtRange.MaxLength = 2;
            this.txtRange.Name = "txtRange";
            this.txtRange.Size = new System.Drawing.Size(33, 20);
            this.txtRange.TabIndex = 2;
            this.txtRange.TextChanged += new System.EventHandler(this.txtControls_TextChanged);
            this.txtRange.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // txtLine2
            // 
            this.txtLine2.AllowBlankSpaces = false;
            this.txtLine2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtLine2.CharsIncluded = new char[0];
            this.txtLine2.CharsNoIncluded = new char[0];
            this.txtLine2.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.OnlyNumbers;
            this.txtLine2.CustomExpression = ".*";
            this.txtLine2.EnterColor = System.Drawing.Color.Empty;
            this.txtLine2.LeaveColor = System.Drawing.Color.Empty;
            this.txtLine2.Location = new System.Drawing.Point(54, 115);
            this.txtLine2.MaxLength = 2;
            this.txtLine2.Name = "txtLine2";
            this.txtLine2.Size = new System.Drawing.Size(33, 20);
            this.txtLine2.TabIndex = 3;
            this.txtLine2.TextChanged += new System.EventHandler(this.txtControls_TextChanged);
            this.txtLine2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // txtLine3
            // 
            this.txtLine3.AllowBlankSpaces = false;
            this.txtLine3.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtLine3.CharsIncluded = new char[0];
            this.txtLine3.CharsNoIncluded = new char[0];
            this.txtLine3.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.OnlyNumbers;
            this.txtLine3.CustomExpression = ".*";
            this.txtLine3.EnterColor = System.Drawing.Color.Empty;
            this.txtLine3.LeaveColor = System.Drawing.Color.Empty;
            this.txtLine3.Location = new System.Drawing.Point(54, 141);
            this.txtLine3.MaxLength = 2;
            this.txtLine3.Name = "txtLine3";
            this.txtLine3.Size = new System.Drawing.Size(33, 20);
            this.txtLine3.TabIndex = 4;
            this.txtLine3.TextChanged += new System.EventHandler(this.txtControls_TextChanged);
            this.txtLine3.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // txtLine4
            // 
            this.txtLine4.AllowBlankSpaces = false;
            this.txtLine4.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtLine4.CharsIncluded = new char[0];
            this.txtLine4.CharsNoIncluded = new char[0];
            this.txtLine4.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.OnlyNumbers;
            this.txtLine4.CustomExpression = ".*";
            this.txtLine4.EnterColor = System.Drawing.Color.Empty;
            this.txtLine4.LeaveColor = System.Drawing.Color.Empty;
            this.txtLine4.Location = new System.Drawing.Point(54, 167);
            this.txtLine4.MaxLength = 2;
            this.txtLine4.Name = "txtLine4";
            this.txtLine4.Size = new System.Drawing.Size(33, 20);
            this.txtLine4.TabIndex = 5;
            this.txtLine4.TextChanged += new System.EventHandler(this.txtControls_TextChanged);
            this.txtLine4.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // btnAccept
            // 
            this.btnAccept.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnAccept.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAccept.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAccept.Location = new System.Drawing.Point(254, 239);
            this.btnAccept.Name = "btnAccept";
            this.btnAccept.Size = new System.Drawing.Size(100, 23);
            this.btnAccept.TabIndex = 6;
            this.btnAccept.Text = "Aceptar";
            this.btnAccept.UseVisualStyleBackColor = false;
            this.btnAccept.Click += new System.EventHandler(this.btnAccept_Click);
            // 
            // ucDeleteRemarks
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.btnAccept);
            this.Controls.Add(this.txtRange);
            this.Controls.Add(this.txtLine4);
            this.Controls.Add(this.txtLine3);
            this.Controls.Add(this.txtLine2);
            this.Controls.Add(this.txtLine1);
            this.Controls.Add(this.lblRange);
            this.Controls.Add(this.lblLine);
            this.Controls.Add(this.lblTitle);
            this.Name = "ucDeleteRemarks";
            this.Size = new System.Drawing.Size(411, 580);
            this.Load += new System.EventHandler(this.ucDeleteRemarks_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblLine;
        private System.Windows.Forms.Label lblRange;
        private MyCTS.Forms.UI.SmartTextBox txtLine1;
        private MyCTS.Forms.UI.SmartTextBox txtRange;
        private MyCTS.Forms.UI.SmartTextBox txtLine2;
        private MyCTS.Forms.UI.SmartTextBox txtLine3;
        private MyCTS.Forms.UI.SmartTextBox txtLine4;
        private System.Windows.Forms.Button btnAccept;
    }
}
