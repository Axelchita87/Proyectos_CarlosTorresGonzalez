namespace MyCTS.Presentation.Components
{
    partial class LineTextPassport
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
            this.label1 = new System.Windows.Forms.Label();
            this.lblNameOn = new MyCTS.Forms.UI.SmartTextBox();
            this.txtCountry = new MyCTS.Forms.UI.SmartTextBox();
            this.Pais = new System.Windows.Forms.Label();
            this.txtPassportVigencyYear = new MyCTS.Forms.UI.SmartTextBox();
            this.lblYear = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblMonth = new System.Windows.Forms.Label();
            this.txtPassportVigencyMonth = new MyCTS.Forms.UI.SmartTextBox();
            this.lblVigency = new System.Windows.Forms.Label();
            this.txtPassportNum = new MyCTS.Forms.UI.SmartTextBox();
            this.lblPassport = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.DarkCyan;
            this.label1.Location = new System.Drawing.Point(281, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 264;
            this.label1.Text = "Nombre";
            // 
            // lblNameOn
            // 
            this.lblNameOn.AllowBlankSpaces = true;
            this.lblNameOn.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.lblNameOn.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.AnyCharacter;
            this.lblNameOn.CustomExpression = ".*";
            this.lblNameOn.EnterColor = System.Drawing.Color.Empty;
            this.lblNameOn.LeaveColor = System.Drawing.Color.Empty;
            this.lblNameOn.Location = new System.Drawing.Point(282, 19);
            this.lblNameOn.Name = "lblNameOn";
            this.lblNameOn.Size = new System.Drawing.Size(184, 20);
            this.lblNameOn.TabIndex = 263;
            // 
            // txtCountry
            // 
            this.txtCountry.AllowBlankSpaces = false;
            this.txtCountry.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtCountry.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.OnlyLetters;
            this.txtCountry.CustomExpression = ".*";
            this.txtCountry.EnterColor = System.Drawing.Color.Empty;
            this.txtCountry.LeaveColor = System.Drawing.Color.Empty;
            this.txtCountry.Location = new System.Drawing.Point(246, 19);
            this.txtCountry.MaxLength = 2;
            this.txtCountry.Name = "txtCountry";
            this.txtCountry.Size = new System.Drawing.Size(30, 20);
            this.txtCountry.TabIndex = 256;
            // 
            // Pais
            // 
            this.Pais.AutoSize = true;
            this.Pais.ForeColor = System.Drawing.Color.DarkCyan;
            this.Pais.Location = new System.Drawing.Point(248, 4);
            this.Pais.Name = "Pais";
            this.Pais.Size = new System.Drawing.Size(27, 13);
            this.Pais.TabIndex = 259;
            this.Pais.Text = "Pais";
            // 
            // txtPassportVigencyYear
            // 
            this.txtPassportVigencyYear.AllowBlankSpaces = false;
            this.txtPassportVigencyYear.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtPassportVigencyYear.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.OnlyNumbers;
            this.txtPassportVigencyYear.CustomExpression = ".*";
            this.txtPassportVigencyYear.EnterColor = System.Drawing.Color.Empty;
            this.txtPassportVigencyYear.LeaveColor = System.Drawing.Color.Empty;
            this.txtPassportVigencyYear.Location = new System.Drawing.Point(210, 19);
            this.txtPassportVigencyYear.MaxLength = 2;
            this.txtPassportVigencyYear.Name = "txtPassportVigencyYear";
            this.txtPassportVigencyYear.Size = new System.Drawing.Size(30, 20);
            this.txtPassportVigencyYear.TabIndex = 255;
            // 
            // lblYear
            // 
            this.lblYear.AutoSize = true;
            this.lblYear.ForeColor = System.Drawing.Color.DarkCyan;
            this.lblYear.Location = new System.Drawing.Point(215, 4);
            this.lblYear.Name = "lblYear";
            this.lblYear.Size = new System.Drawing.Size(21, 13);
            this.lblYear.TabIndex = 257;
            this.lblYear.Text = "YY";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.DarkCyan;
            this.label2.Location = new System.Drawing.Point(199, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(10, 13);
            this.label2.TabIndex = 258;
            this.label2.Text = "-";
            // 
            // lblMonth
            // 
            this.lblMonth.AutoSize = true;
            this.lblMonth.ForeColor = System.Drawing.Color.DarkCyan;
            this.lblMonth.Location = new System.Drawing.Point(164, 4);
            this.lblMonth.Name = "lblMonth";
            this.lblMonth.Size = new System.Drawing.Size(34, 13);
            this.lblMonth.TabIndex = 262;
            this.lblMonth.Text = "MMM";
            // 
            // txtPassportVigencyMonth
            // 
            this.txtPassportVigencyMonth.AllowBlankSpaces = false;
            this.txtPassportVigencyMonth.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtPassportVigencyMonth.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.OnlyLetters;
            this.txtPassportVigencyMonth.CustomExpression = ".*";
            this.txtPassportVigencyMonth.EnterColor = System.Drawing.Color.Empty;
            this.txtPassportVigencyMonth.LeaveColor = System.Drawing.Color.Empty;
            this.txtPassportVigencyMonth.Location = new System.Drawing.Point(165, 19);
            this.txtPassportVigencyMonth.MaxLength = 3;
            this.txtPassportVigencyMonth.Name = "txtPassportVigencyMonth";
            this.txtPassportVigencyMonth.Size = new System.Drawing.Size(35, 20);
            this.txtPassportVigencyMonth.TabIndex = 254;
            // 
            // lblVigency
            // 
            this.lblVigency.AutoSize = true;
            this.lblVigency.ForeColor = System.Drawing.Color.DarkCyan;
            this.lblVigency.Location = new System.Drawing.Point(126, 22);
            this.lblVigency.Name = "lblVigency";
            this.lblVigency.Size = new System.Drawing.Size(38, 13);
            this.lblVigency.TabIndex = 261;
            this.lblVigency.Text = "Vence";
            // 
            // txtPassportNum
            // 
            this.txtPassportNum.AllowBlankSpaces = false;
            this.txtPassportNum.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtPassportNum.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.NumbersOrLetters;
            this.txtPassportNum.CustomExpression = ".*";
            this.txtPassportNum.EnterColor = System.Drawing.Color.Empty;
            this.txtPassportNum.LeaveColor = System.Drawing.Color.Empty;
            this.txtPassportNum.Location = new System.Drawing.Point(6, 19);
            this.txtPassportNum.MaxLength = 16;
            this.txtPassportNum.Name = "txtPassportNum";
            this.txtPassportNum.Size = new System.Drawing.Size(118, 20);
            this.txtPassportNum.TabIndex = 253;
            // 
            // lblPassport
            // 
            this.lblPassport.AutoSize = true;
            this.lblPassport.ForeColor = System.Drawing.Color.DarkCyan;
            this.lblPassport.Location = new System.Drawing.Point(3, 4);
            this.lblPassport.Name = "lblPassport";
            this.lblPassport.Size = new System.Drawing.Size(80, 13);
            this.lblPassport.TabIndex = 260;
            this.lblPassport.Text = "Pasaporte Num";
            // 
            // LineTextPassport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightBlue;
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblNameOn);
            this.Controls.Add(this.txtCountry);
            this.Controls.Add(this.Pais);
            this.Controls.Add(this.txtPassportVigencyYear);
            this.Controls.Add(this.lblYear);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblMonth);
            this.Controls.Add(this.txtPassportVigencyMonth);
            this.Controls.Add(this.lblVigency);
            this.Controls.Add(this.txtPassportNum);
            this.Controls.Add(this.lblPassport);
            this.Name = "LineTextPassport";
            this.Size = new System.Drawing.Size(471, 44);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private Forms.UI.SmartTextBox lblNameOn;
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
    }
}
