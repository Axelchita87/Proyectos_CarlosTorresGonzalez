namespace MyCTS.Presentation
{
    partial class ucSplitRecord
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
            this.lblDescription = new System.Windows.Forms.Label();
            this.txtPassenger1 = new MyCTS.Forms.UI.SmartTextBox();
            this.txtPassenger2 = new MyCTS.Forms.UI.SmartTextBox();
            this.txtPassenger3 = new MyCTS.Forms.UI.SmartTextBox();
            this.txtPassenger4 = new MyCTS.Forms.UI.SmartTextBox();
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
            this.lblTitle.TabIndex = 1;
            this.lblTitle.Text = "División de Record";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.Location = new System.Drawing.Point(27, 39);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(124, 13);
            this.lblDescription.TabIndex = 0;
            this.lblDescription.Text = "Número de Pax a Dividir:";
            // 
            // txtPassenger1
            // 
            this.txtPassenger1.AllowBlankSpaces = false;
            this.txtPassenger1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtPassenger1.CharsIncluded = new char[] {
        '.'};
            this.txtPassenger1.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.OnlyNumbers;
            this.txtPassenger1.CustomExpression = "@\"^[0-9]{1,2}[.]{1}[0-9]{1}$\"";
            this.txtPassenger1.EnterColor = System.Drawing.Color.Empty;
            this.txtPassenger1.LeaveColor = System.Drawing.Color.Empty;
            this.txtPassenger1.Location = new System.Drawing.Point(43, 71);
            this.txtPassenger1.MaxLength = 4;
            this.txtPassenger1.Name = "txtPassenger1";
            this.txtPassenger1.Size = new System.Drawing.Size(35, 20);
            this.txtPassenger1.TabIndex = 1;
            this.txtPassenger1.TextChanged += new System.EventHandler(this.txtControls_TextChanged);
            this.txtPassenger1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // txtPassenger2
            // 
            this.txtPassenger2.AllowBlankSpaces = false;
            this.txtPassenger2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtPassenger2.CharsIncluded = new char[] {
        '.'};
            this.txtPassenger2.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.OnlyNumbers;
            this.txtPassenger2.CustomExpression = ".*";
            this.txtPassenger2.EnterColor = System.Drawing.Color.Empty;
            this.txtPassenger2.LeaveColor = System.Drawing.Color.Empty;
            this.txtPassenger2.Location = new System.Drawing.Point(43, 97);
            this.txtPassenger2.MaxLength = 4;
            this.txtPassenger2.Name = "txtPassenger2";
            this.txtPassenger2.Size = new System.Drawing.Size(35, 20);
            this.txtPassenger2.TabIndex = 2;
            this.txtPassenger2.TextChanged += new System.EventHandler(this.txtControls_TextChanged);
            this.txtPassenger2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // txtPassenger3
            // 
            this.txtPassenger3.AllowBlankSpaces = false;
            this.txtPassenger3.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtPassenger3.CharsIncluded = new char[] {
        '.'};
            this.txtPassenger3.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.OnlyNumbers;
            this.txtPassenger3.CustomExpression = ".*";
            this.txtPassenger3.EnterColor = System.Drawing.Color.Empty;
            this.txtPassenger3.LeaveColor = System.Drawing.Color.Empty;
            this.txtPassenger3.Location = new System.Drawing.Point(43, 123);
            this.txtPassenger3.MaxLength = 4;
            this.txtPassenger3.Name = "txtPassenger3";
            this.txtPassenger3.Size = new System.Drawing.Size(35, 20);
            this.txtPassenger3.TabIndex = 3;
            this.txtPassenger3.TextChanged += new System.EventHandler(this.txtControls_TextChanged);
            this.txtPassenger3.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // txtPassenger4
            // 
            this.txtPassenger4.AllowBlankSpaces = false;
            this.txtPassenger4.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtPassenger4.CharsIncluded = new char[] {
        '.'};
            this.txtPassenger4.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.OnlyNumbers;
            this.txtPassenger4.CustomExpression = ".*";
            this.txtPassenger4.EnterColor = System.Drawing.Color.Empty;
            this.txtPassenger4.LeaveColor = System.Drawing.Color.Empty;
            this.txtPassenger4.Location = new System.Drawing.Point(43, 149);
            this.txtPassenger4.MaxLength = 4;
            this.txtPassenger4.Name = "txtPassenger4";
            this.txtPassenger4.Size = new System.Drawing.Size(35, 20);
            this.txtPassenger4.TabIndex = 4;
            this.txtPassenger4.TextChanged += new System.EventHandler(this.txtControls_TextChanged);
            this.txtPassenger4.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // btnAccept
            // 
            this.btnAccept.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnAccept.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAccept.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAccept.Location = new System.Drawing.Point(237, 203);
            this.btnAccept.Name = "btnAccept";
            this.btnAccept.Size = new System.Drawing.Size(100, 23);
            this.btnAccept.TabIndex = 5;
            this.btnAccept.Text = "Aceptar";
            this.btnAccept.UseVisualStyleBackColor = false;
            this.btnAccept.Click += new System.EventHandler(this.btnAccept_Click);
            // 
            // ucSplitRecord
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.btnAccept);
            this.Controls.Add(this.txtPassenger1);
            this.Controls.Add(this.txtPassenger2);
            this.Controls.Add(this.txtPassenger3);
            this.Controls.Add(this.txtPassenger4);
            this.Controls.Add(this.lblDescription);
            this.Controls.Add(this.lblTitle);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "ucSplitRecord";
            this.Size = new System.Drawing.Size(411, 580);
            this.Load += new System.EventHandler(this.ucSplitRecord_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblDescription;
        private MyCTS.Forms.UI.SmartTextBox txtPassenger1;
        private MyCTS.Forms.UI.SmartTextBox txtPassenger2;
        private MyCTS.Forms.UI.SmartTextBox txtPassenger3;
        private MyCTS.Forms.UI.SmartTextBox txtPassenger4;
        private System.Windows.Forms.Button btnAccept;
    }
}
