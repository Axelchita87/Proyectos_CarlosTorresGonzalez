namespace MyCTS.Presentation.Components
{
    partial class ucMultiTextRemarks
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
            this.comboBox5 = new System.Windows.Forms.ComboBox();
            this.comboBox6 = new System.Windows.Forms.ComboBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.smartTextBox2 = new MyCTS.Forms.UI.SmartTextBox();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.comboBox3 = new System.Windows.Forms.ComboBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.smartTextBox1 = new MyCTS.Forms.UI.SmartTextBox();
            this.comboBox4 = new System.Windows.Forms.ComboBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
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
            this.panel1.Location = new System.Drawing.Point(1, 26);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(443, 90);
            this.panel1.TabIndex = 6;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.LightBlue;
            this.panel4.Controls.Add(this.smartTextBox3);
            this.panel4.Controls.Add(this.comboBox5);
            this.panel4.Controls.Add(this.comboBox6);
            this.panel4.Location = new System.Drawing.Point(0, 59);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(423, 28);
            this.panel4.TabIndex = 7;
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
        '*'};
            this.smartTextBox3.CharsNoIncluded = new char[] {
        'ñ',
        'Ñ'};
            this.smartTextBox3.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.NumbersOrLetters;
            this.smartTextBox3.CustomExpression = ".*";
            this.smartTextBox3.EnterColor = System.Drawing.Color.Empty;
            this.smartTextBox3.LeaveColor = System.Drawing.Color.Empty;
            this.smartTextBox3.Location = new System.Drawing.Point(2, 3);
            this.smartTextBox3.Name = "smartTextBox3";
            this.smartTextBox3.Size = new System.Drawing.Size(310, 20);
            this.smartTextBox3.TabIndex = 8;
            // 
            // comboBox5
            // 
            this.comboBox5.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox5.FormattingEnabled = true;
            this.comboBox5.Items.AddRange(new object[] {
            global::MyCTS.Presentation.Resources.ErrorMessages.INTERJET_DEPARTURE_NOT_FOUND,
            "Contable",
            "Itinerario",
            "Histórico"});
            this.comboBox5.Location = new System.Drawing.Point(367, 3);
            this.comboBox5.Name = "comboBox5";
            this.comboBox5.Size = new System.Drawing.Size(53, 21);
            this.comboBox5.TabIndex = 10;
            // 
            // comboBox6
            // 
            this.comboBox6.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox6.FormattingEnabled = true;
            this.comboBox6.Items.AddRange(new object[] {
            global::MyCTS.Presentation.Resources.ErrorMessages.INTERJET_DEPARTURE_NOT_FOUND,
            "A",
            "O"});
            this.comboBox6.Location = new System.Drawing.Point(318, 3);
            this.comboBox6.Name = "comboBox6";
            this.comboBox6.Size = new System.Drawing.Size(43, 21);
            this.comboBox6.TabIndex = 9;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.LightBlue;
            this.panel3.Controls.Add(this.smartTextBox2);
            this.panel3.Controls.Add(this.comboBox2);
            this.panel3.Controls.Add(this.comboBox3);
            this.panel3.Location = new System.Drawing.Point(0, 30);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(423, 28);
            this.panel3.TabIndex = 6;
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
        '*'};
            this.smartTextBox2.CharsNoIncluded = new char[] {
        'ñ',
        'Ñ'};
            this.smartTextBox2.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.NumbersOrLetters;
            this.smartTextBox2.CustomExpression = ".*";
            this.smartTextBox2.EnterColor = System.Drawing.Color.Empty;
            this.smartTextBox2.LeaveColor = System.Drawing.Color.Empty;
            this.smartTextBox2.Location = new System.Drawing.Point(3, 3);
            this.smartTextBox2.Name = "smartTextBox2";
            this.smartTextBox2.Size = new System.Drawing.Size(310, 20);
            this.smartTextBox2.TabIndex = 8;
            // 
            // comboBox2
            // 
            this.comboBox2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Items.AddRange(new object[] {
            global::MyCTS.Presentation.Resources.ErrorMessages.INTERJET_DEPARTURE_NOT_FOUND,
            "Contable",
            "Itinerario",
            "Histórico"});
            this.comboBox2.Location = new System.Drawing.Point(367, 3);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(53, 21);
            this.comboBox2.TabIndex = 10;
            // 
            // comboBox3
            // 
            this.comboBox3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox3.FormattingEnabled = true;
            this.comboBox3.Items.AddRange(new object[] {
            global::MyCTS.Presentation.Resources.ErrorMessages.INTERJET_DEPARTURE_NOT_FOUND,
            "A",
            "O"});
            this.comboBox3.Location = new System.Drawing.Point(318, 3);
            this.comboBox3.Name = "comboBox3";
            this.comboBox3.Size = new System.Drawing.Size(43, 21);
            this.comboBox3.TabIndex = 9;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.LightBlue;
            this.panel2.Controls.Add(this.smartTextBox1);
            this.panel2.Controls.Add(this.comboBox4);
            this.panel2.Controls.Add(this.comboBox1);
            this.panel2.Location = new System.Drawing.Point(0, 1);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(423, 28);
            this.panel2.TabIndex = 5;
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
            this.smartTextBox1.CustomExpression = "^[A-Z0-9 a-z]*$";
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
            this.comboBox4.Location = new System.Drawing.Point(367, 3);
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
            this.comboBox1.Location = new System.Drawing.Point(318, 3);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(43, 21);
            this.comboBox1.TabIndex = 9;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(226, 1);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(87, 23);
            this.button1.TabIndex = 7;
            this.button1.Text = "Agregar Línea";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(323, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Línea";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(380, 6);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(28, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Tipo";
            // 
            // ucMultiTextRemarks
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightBlue;
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.button1);
            this.Name = "ucMultiTextRemarks";
            this.Size = new System.Drawing.Size(447, 117);
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
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.ComboBox comboBox3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ComboBox comboBox4;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.ComboBox comboBox5;
        private System.Windows.Forms.ComboBox comboBox6;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private MyCTS.Forms.UI.SmartTextBox smartTextBox3;
        private MyCTS.Forms.UI.SmartTextBox smartTextBox2;
        private MyCTS.Forms.UI.SmartTextBox smartTextBox1;
    }
}
