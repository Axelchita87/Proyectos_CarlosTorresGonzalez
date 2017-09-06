namespace MyCTS.Presentation.Components
{
    partial class ucMultiLineSmartText
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.smartTextBox3 = new MyCTS.Forms.UI.SmartTextBox();
            this.comboBox3 = new System.Windows.Forms.ComboBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.smartTextBox2 = new MyCTS.Forms.UI.SmartTextBox();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.smartTextBox1 = new MyCTS.Forms.UI.SmartTextBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.Controls.Add(this.panel4);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Location = new System.Drawing.Point(0, 29);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(433, 92);
            this.panel1.TabIndex = 4;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.LightBlue;
            this.panel4.Controls.Add(this.smartTextBox3);
            this.panel4.Controls.Add(this.comboBox3);
            this.panel4.Location = new System.Drawing.Point(1, 61);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(425, 28);
            this.panel4.TabIndex = 4;
            // 
            // smartTextBox3
            // 
            this.smartTextBox3.AllowBlankSpaces = true;
            this.smartTextBox3.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.smartTextBox3.CharsIncluded = new char[] {
        ' ',
        '.',
        '-',
        '/',
        '@',
        '*',
        '='};
            this.smartTextBox3.CharsNoIncluded = new char[] {
        'ñ',
        'Ñ'};
            this.smartTextBox3.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.NumbersOrLetters;
            this.smartTextBox3.CustomExpression = ".*";
            this.smartTextBox3.EnterColor = System.Drawing.Color.Empty;
            this.smartTextBox3.LeaveColor = System.Drawing.Color.Empty;
            this.smartTextBox3.Location = new System.Drawing.Point(7, 3);
            this.smartTextBox3.Name = "smartTextBox3";
            this.smartTextBox3.Size = new System.Drawing.Size(344, 20);
            this.smartTextBox3.TabIndex = 8;
            // 
            // comboBox3
            // 
            this.comboBox3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox3.FormattingEnabled = true;
            this.comboBox3.Items.AddRange(new object[] {
            "",
            "A",
            "O"});
            this.comboBox3.Location = new System.Drawing.Point(354, 3);
            this.comboBox3.Name = "comboBox3";
            this.comboBox3.Size = new System.Drawing.Size(68, 21);
            this.comboBox3.TabIndex = 9;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.LightBlue;
            this.panel3.Controls.Add(this.smartTextBox2);
            this.panel3.Controls.Add(this.comboBox2);
            this.panel3.Location = new System.Drawing.Point(1, 32);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(425, 28);
            this.panel3.TabIndex = 3;
            // 
            // smartTextBox2
            // 
            this.smartTextBox2.AllowBlankSpaces = true;
            this.smartTextBox2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.smartTextBox2.CharsIncluded = new char[] {
        ' ',
        '.',
        '-',
        '/',
        '@',
        '*',
        '='};
            this.smartTextBox2.CharsNoIncluded = new char[] {
        'ñ',
        'Ñ'};
            this.smartTextBox2.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.NumbersOrLetters;
            this.smartTextBox2.CustomExpression = ".*";
            this.smartTextBox2.EnterColor = System.Drawing.Color.Empty;
            this.smartTextBox2.LeaveColor = System.Drawing.Color.Empty;
            this.smartTextBox2.Location = new System.Drawing.Point(7, 3);
            this.smartTextBox2.Name = "smartTextBox2";
            this.smartTextBox2.Size = new System.Drawing.Size(344, 20);
            this.smartTextBox2.TabIndex = 8;
            // 
            // comboBox2
            // 
            this.comboBox2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Items.AddRange(new object[] {
            "",
            "A",
            "O"});
            this.comboBox2.Location = new System.Drawing.Point(354, 3);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(68, 21);
            this.comboBox2.TabIndex = 9;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.LightBlue;
            this.panel2.Controls.Add(this.smartTextBox1);
            this.panel2.Controls.Add(this.comboBox1);
            this.panel2.Location = new System.Drawing.Point(1, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(425, 28);
            this.panel2.TabIndex = 2;
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
        '@',
        '*',
        '='};
            this.smartTextBox1.CharsNoIncluded = new char[] {
        'ñ',
        'Ñ'};
            this.smartTextBox1.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.NumbersOrLetters;
            this.smartTextBox1.CustomExpression = " ";
            this.smartTextBox1.EnterColor = System.Drawing.Color.Empty;
            this.smartTextBox1.LeaveColor = System.Drawing.Color.Empty;
            this.smartTextBox1.Location = new System.Drawing.Point(7, 3);
            this.smartTextBox1.Name = "smartTextBox1";
            this.smartTextBox1.Size = new System.Drawing.Size(344, 20);
            this.smartTextBox1.TabIndex = 8;
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "",
            "A",
            "O"});
            this.comboBox1.Location = new System.Drawing.Point(355, 3);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(68, 21);
            this.comboBox1.TabIndex = 9;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(265, 5);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(87, 23);
            this.button1.TabIndex = 5;
            this.button1.Text = "Agregar Línea";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(370, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Línea";
            // 
            // ucMultiLineSmartText
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightBlue;
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.button1);
            this.Name = "ucMultiLineSmartText";
            this.Size = new System.Drawing.Size(451, 121);
            this.panel1.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.ComboBox comboBox3;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label1;
        private MyCTS.Forms.UI.SmartTextBox smartTextBox3;
        private MyCTS.Forms.UI.SmartTextBox smartTextBox2;
        private MyCTS.Forms.UI.SmartTextBox smartTextBox1;


    }
}
