namespace MyCTS.Presentation.Components
{
    partial class ucMultiLinePassport
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.Pais = new System.Windows.Forms.Label();
            this.lblYear = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblMonth = new System.Windows.Forms.Label();
            this.lblVigency = new System.Windows.Forms.Label();
            this.lblPassport = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtPassportNum = new MyCTS.Forms.UI.SmartTextBox();
            this.lblNameOn = new MyCTS.Forms.UI.SmartTextBox();
            this.txtCountry = new MyCTS.Forms.UI.SmartTextBox();
            this.txtPassportVigencyMonth = new MyCTS.Forms.UI.SmartTextBox();
            this.txtPassportVigencyYear = new MyCTS.Forms.UI.SmartTextBox();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // Pais
            // 
            this.Pais.AutoSize = true;
            this.Pais.ForeColor = System.Drawing.Color.DarkCyan;
            this.Pais.Location = new System.Drawing.Point(248, 5);
            this.Pais.Name = "Pais";
            this.Pais.Size = new System.Drawing.Size(27, 13);
            this.Pais.TabIndex = 244;
            this.Pais.Text = "Pais";
            // 
            // lblYear
            // 
            this.lblYear.AutoSize = true;
            this.lblYear.ForeColor = System.Drawing.Color.DarkCyan;
            this.lblYear.Location = new System.Drawing.Point(215, 5);
            this.lblYear.Name = "lblYear";
            this.lblYear.Size = new System.Drawing.Size(21, 13);
            this.lblYear.TabIndex = 240;
            this.lblYear.Text = "YY";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.DarkCyan;
            this.label2.Location = new System.Drawing.Point(199, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(10, 13);
            this.label2.TabIndex = 241;
            this.label2.Text = "-";
            // 
            // lblMonth
            // 
            this.lblMonth.AutoSize = true;
            this.lblMonth.ForeColor = System.Drawing.Color.DarkCyan;
            this.lblMonth.Location = new System.Drawing.Point(164, 5);
            this.lblMonth.Name = "lblMonth";
            this.lblMonth.Size = new System.Drawing.Size(34, 13);
            this.lblMonth.TabIndex = 250;
            this.lblMonth.Text = "MMM";
            // 
            // lblVigency
            // 
            this.lblVigency.AutoSize = true;
            this.lblVigency.ForeColor = System.Drawing.Color.DarkCyan;
            this.lblVigency.Location = new System.Drawing.Point(126, 23);
            this.lblVigency.Name = "lblVigency";
            this.lblVigency.Size = new System.Drawing.Size(38, 13);
            this.lblVigency.TabIndex = 249;
            this.lblVigency.Text = "Vence";
            // 
            // lblPassport
            // 
            this.lblPassport.AutoSize = true;
            this.lblPassport.ForeColor = System.Drawing.Color.DarkCyan;
            this.lblPassport.Location = new System.Drawing.Point(3, 5);
            this.lblPassport.Name = "lblPassport";
            this.lblPassport.Size = new System.Drawing.Size(80, 13);
            this.lblPassport.TabIndex = 248;
            this.lblPassport.Text = "Pasaporte Num";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.DarkCyan;
            this.label1.Location = new System.Drawing.Point(281, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 252;
            this.label1.Text = "Nombre";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(349, 3);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(115, 23);
            this.button1.TabIndex = 253;
            this.button1.Text = "Agregar Pasaporte";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.Controls.Add(this.lblPassport);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.txtPassportNum);
            this.panel1.Controls.Add(this.lblNameOn);
            this.panel1.Controls.Add(this.lblVigency);
            this.panel1.Controls.Add(this.txtCountry);
            this.panel1.Controls.Add(this.txtPassportVigencyMonth);
            this.panel1.Controls.Add(this.Pais);
            this.panel1.Controls.Add(this.lblMonth);
            this.panel1.Controls.Add(this.txtPassportVigencyYear);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.lblYear);
            this.panel1.Location = new System.Drawing.Point(4, 25);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(471, 59);
            this.panel1.TabIndex = 254;
            // 
            // txtPassportNum
            // 
            this.txtPassportNum.AllowBlankSpaces = false;
            this.txtPassportNum.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtPassportNum.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.NumbersOrLetters;
            this.txtPassportNum.CustomExpression = ".*";
            this.txtPassportNum.EnterColor = System.Drawing.Color.Empty;
            this.txtPassportNum.LeaveColor = System.Drawing.Color.Empty;
            this.txtPassportNum.Location = new System.Drawing.Point(6, 20);
            this.txtPassportNum.MaxLength = 16;
            this.txtPassportNum.Name = "txtPassportNum";
            this.txtPassportNum.Size = new System.Drawing.Size(118, 20);
            this.txtPassportNum.TabIndex = 232;
            // 
            // lblNameOn
            // 
            this.lblNameOn.AllowBlankSpaces = true;
            this.lblNameOn.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.lblNameOn.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.AnyCharacter;
            this.lblNameOn.CustomExpression = ".*";
            this.lblNameOn.EnterColor = System.Drawing.Color.Empty;
            this.lblNameOn.LeaveColor = System.Drawing.Color.Empty;
            this.lblNameOn.Location = new System.Drawing.Point(282, 20);
            this.lblNameOn.Name = "lblNameOn";
            this.lblNameOn.Size = new System.Drawing.Size(184, 20);
            this.lblNameOn.TabIndex = 251;
            // 
            // txtCountry
            // 
            this.txtCountry.AllowBlankSpaces = false;
            this.txtCountry.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtCountry.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.OnlyLetters;
            this.txtCountry.CustomExpression = ".*";
            this.txtCountry.EnterColor = System.Drawing.Color.Empty;
            this.txtCountry.LeaveColor = System.Drawing.Color.Empty;
            this.txtCountry.Location = new System.Drawing.Point(246, 20);
            this.txtCountry.MaxLength = 2;
            this.txtCountry.Name = "txtCountry";
            this.txtCountry.Size = new System.Drawing.Size(30, 20);
            this.txtCountry.TabIndex = 235;
            // 
            // txtPassportVigencyMonth
            // 
            this.txtPassportVigencyMonth.AllowBlankSpaces = false;
            this.txtPassportVigencyMonth.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtPassportVigencyMonth.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.OnlyLetters;
            this.txtPassportVigencyMonth.CustomExpression = ".*";
            this.txtPassportVigencyMonth.EnterColor = System.Drawing.Color.Empty;
            this.txtPassportVigencyMonth.LeaveColor = System.Drawing.Color.Empty;
            this.txtPassportVigencyMonth.Location = new System.Drawing.Point(165, 20);
            this.txtPassportVigencyMonth.MaxLength = 3;
            this.txtPassportVigencyMonth.Name = "txtPassportVigencyMonth";
            this.txtPassportVigencyMonth.Size = new System.Drawing.Size(35, 20);
            this.txtPassportVigencyMonth.TabIndex = 233;
            // 
            // txtPassportVigencyYear
            // 
            this.txtPassportVigencyYear.AllowBlankSpaces = false;
            this.txtPassportVigencyYear.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtPassportVigencyYear.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.OnlyNumbers;
            this.txtPassportVigencyYear.CustomExpression = ".*";
            this.txtPassportVigencyYear.EnterColor = System.Drawing.Color.Empty;
            this.txtPassportVigencyYear.LeaveColor = System.Drawing.Color.Empty;
            this.txtPassportVigencyYear.Location = new System.Drawing.Point(210, 20);
            this.txtPassportVigencyYear.MaxLength = 2;
            this.txtPassportVigencyYear.Name = "txtPassportVigencyYear";
            this.txtPassportVigencyYear.Size = new System.Drawing.Size(30, 20);
            this.txtPassportVigencyYear.TabIndex = 234;
            // 
            // ucMultiLinePassport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightBlue;
            this.Controls.Add(this.button1);
            this.Controls.Add(this.panel1);
            this.Name = "ucMultiLinePassport";
            this.Size = new System.Drawing.Size(478, 87);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Forms.UI.SmartTextBox txtCountry;
        private System.Windows.Forms.Label Pais;
        private Forms.UI.SmartTextBox txtPassportVigencyYear;
        private System.Windows.Forms.Label lblYear;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblMonth;
        private Forms.UI.SmartTextBox txtPassportVigencyMonth;
        private System.Windows.Forms.Label lblVigency;
        private Forms.UI.SmartTextBox txtPassportNum;
        private System.Windows.Forms.Label lblPassport;
        private Forms.UI.SmartTextBox lblNameOn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel panel1;
    }
}
