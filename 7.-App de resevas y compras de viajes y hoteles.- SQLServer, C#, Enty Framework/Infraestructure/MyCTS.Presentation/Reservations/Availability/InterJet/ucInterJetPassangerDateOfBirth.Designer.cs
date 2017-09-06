namespace MyCTS.Presentation.Reservations.Availability.InterJet
{
    partial class ucInterJetPassangerDateOfBirth
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
            this.daysCombo = new System.Windows.Forms.ComboBox();
            this.monthsCombo = new System.Windows.Forms.ComboBox();
            this.yearsCombo = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // daysCombo
            // 
            this.daysCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.daysCombo.FormattingEnabled = true;
            this.daysCombo.Location = new System.Drawing.Point(3, 3);
            this.daysCombo.Name = "daysCombo";
            this.daysCombo.Size = new System.Drawing.Size(38, 21);
            this.daysCombo.TabIndex = 0;
            this.daysCombo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.daysCombo_KeyDown);
            // 
            // monthsCombo
            // 
            this.monthsCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.monthsCombo.FormattingEnabled = true;
            this.monthsCombo.Location = new System.Drawing.Point(47, 3);
            this.monthsCombo.Name = "monthsCombo";
            this.monthsCombo.Size = new System.Drawing.Size(58, 21);
            this.monthsCombo.TabIndex = 1;
            this.monthsCombo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.monthsCombo_KeyDown);
            // 
            // yearsCombo
            // 
            this.yearsCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.yearsCombo.FormattingEnabled = true;
            this.yearsCombo.Location = new System.Drawing.Point(111, 3);
            this.yearsCombo.Name = "yearsCombo";
            this.yearsCombo.Size = new System.Drawing.Size(66, 21);
            this.yearsCombo.TabIndex = 2;
            // 
            // ucInterJetPassangerDateOfBirth
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.yearsCombo);
            this.Controls.Add(this.monthsCombo);
            this.Controls.Add(this.daysCombo);
            this.Name = "ucInterJetPassangerDateOfBirth";
            this.Size = new System.Drawing.Size(183, 32);
            this.Load += new System.EventHandler(this.ucInterJetPassangerDateOfBirth_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox daysCombo;
        private System.Windows.Forms.ComboBox monthsCombo;
        private System.Windows.Forms.ComboBox yearsCombo;
    }
}
