namespace MyCTS.Presentation.Components
{
    partial class LineTextRemark
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
            this.panel2 = new System.Windows.Forms.Panel();
            this.smartTextBox1 = new MyCTS.Forms.UI.SmartTextBox();
            this.comboBox4 = new System.Windows.Forms.ComboBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.LightBlue;
            this.panel2.Controls.Add(this.smartTextBox1);
            this.panel2.Controls.Add(this.comboBox4);
            this.panel2.Controls.Add(this.comboBox1);
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(424, 28);
            this.panel2.TabIndex = 3;
            // 
            // smartTextBox1
            // 
            this.smartTextBox1.AllowBlankSpaces = true;
            this.smartTextBox1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.smartTextBox1.CharsIncluded = new char[] {
        ' ',
        '.',
        '-',
        '/',
        '*'};
            this.smartTextBox1.CharsNoIncluded = new char[] {
        'ñ',
        'Ñ'};
            this.smartTextBox1.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.NumbersOrLetters;
            this.smartTextBox1.CustomExpression = ".*";
            this.smartTextBox1.EnterColor = System.Drawing.Color.Empty;
            this.smartTextBox1.LeaveColor = System.Drawing.Color.Empty;
            this.smartTextBox1.Location = new System.Drawing.Point(3, 3);
            this.smartTextBox1.Name = "smartTextBox1";
            this.smartTextBox1.Size = new System.Drawing.Size(310, 20);
            this.smartTextBox1.TabIndex = 8;
            // 
            // comboBox4
            // 
            this.comboBox4.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox4.FormattingEnabled = true;
            this.comboBox4.Items.AddRange(new object[] {
            global::MyCTS.Presentation.Resources.ErrorMessages.INTERJET_DEPARTURE_NOT_FOUND,
            "Contable",
            "Itinerario",
            "Histórico"});
            this.comboBox4.Location = new System.Drawing.Point(368, 3);
            this.comboBox4.Name = "comboBox4";
            this.comboBox4.Size = new System.Drawing.Size(53, 21);
            this.comboBox4.TabIndex = 10;
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            global::MyCTS.Presentation.Resources.ErrorMessages.INTERJET_DEPARTURE_NOT_FOUND,
            "A",
            "O"});
            this.comboBox1.Location = new System.Drawing.Point(319, 3);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(43, 21);
            this.comboBox1.TabIndex = 9;
            // 
            // LineTextRemark
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel2);
            this.Name = "LineTextRemark";
            this.Size = new System.Drawing.Size(425, 28);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ComboBox comboBox4;
        private System.Windows.Forms.ComboBox comboBox1;
        private MyCTS.Forms.UI.SmartTextBox smartTextBox1;
    }
}
