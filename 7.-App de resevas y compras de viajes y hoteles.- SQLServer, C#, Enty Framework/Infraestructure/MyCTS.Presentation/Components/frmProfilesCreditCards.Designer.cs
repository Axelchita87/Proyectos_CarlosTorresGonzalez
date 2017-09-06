namespace MyCTS.Presentation.Components
{
    partial class frmProfilesCreditCards
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.btnAccept = new System.Windows.Forms.Button();
            this.btnDeny = new System.Windows.Forms.Button();
            this.groupSecondLevel = new System.Windows.Forms.GroupBox();
            this.secondLevelCheckBox = new System.Windows.Forms.CheckBox();
            this.secondLevelCombo = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupFirstLevel = new System.Windows.Forms.GroupBox();
            this.firstLevelCheckBox = new System.Windows.Forms.CheckBox();
            this.firstLevelCombo = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.groupSecondLevel.SuspendLayout();
            this.groupFirstLevel.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(36, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Elije una opción:";
            // 
            // btnAccept
            // 
            this.btnAccept.Location = new System.Drawing.Point(157, 192);
            this.btnAccept.Name = "btnAccept";
            this.btnAccept.Size = new System.Drawing.Size(75, 23);
            this.btnAccept.TabIndex = 2;
            this.btnAccept.Text = "Aceptar";
            this.btnAccept.UseVisualStyleBackColor = true;
            this.btnAccept.Click += new System.EventHandler(this.btnAccept_Click);
            // 
            // btnDeny
            // 
            this.btnDeny.Location = new System.Drawing.Point(258, 192);
            this.btnDeny.Name = "btnDeny";
            this.btnDeny.Size = new System.Drawing.Size(118, 23);
            this.btnDeny.TabIndex = 3;
            this.btnDeny.Text = "No usar esta opción";
            this.btnDeny.UseVisualStyleBackColor = true;
            this.btnDeny.Click += new System.EventHandler(this.btnDeny_Click);
            // 
            // groupSecondLevel
            // 
            this.groupSecondLevel.Controls.Add(this.secondLevelCheckBox);
            this.groupSecondLevel.Controls.Add(this.secondLevelCombo);
            this.groupSecondLevel.Controls.Add(this.label2);
            this.groupSecondLevel.Location = new System.Drawing.Point(7, 86);
            this.groupSecondLevel.Name = "groupSecondLevel";
            this.groupSecondLevel.Size = new System.Drawing.Size(381, 76);
            this.groupSecondLevel.TabIndex = 5;
            this.groupSecondLevel.TabStop = false;
            this.groupSecondLevel.Text = "Tarjetas de Segundo Nivel";
            // 
            // secondLevelCheckBox
            // 
            this.secondLevelCheckBox.AutoSize = true;
            this.secondLevelCheckBox.Location = new System.Drawing.Point(354, 39);
            this.secondLevelCheckBox.Name = "secondLevelCheckBox";
            this.secondLevelCheckBox.Size = new System.Drawing.Size(15, 14);
            this.secondLevelCheckBox.TabIndex = 3;
            this.secondLevelCheckBox.UseVisualStyleBackColor = true;
            this.secondLevelCheckBox.CheckedChanged += new System.EventHandler(this.secondLevelCheckBox_CheckedChanged);
            // 
            // secondLevelCombo
            // 
            this.secondLevelCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.secondLevelCombo.FormattingEnabled = true;
            this.secondLevelCombo.Location = new System.Drawing.Point(72, 36);
            this.secondLevelCombo.Name = "secondLevelCombo";
            this.secondLevelCombo.Size = new System.Drawing.Size(276, 21);
            this.secondLevelCombo.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(2, 39);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Seleccione:";
            // 
            // groupFirstLevel
            // 
            this.groupFirstLevel.Controls.Add(this.firstLevelCheckBox);
            this.groupFirstLevel.Controls.Add(this.firstLevelCombo);
            this.groupFirstLevel.Controls.Add(this.label3);
            this.groupFirstLevel.Location = new System.Drawing.Point(7, 5);
            this.groupFirstLevel.Name = "groupFirstLevel";
            this.groupFirstLevel.Size = new System.Drawing.Size(381, 75);
            this.groupFirstLevel.TabIndex = 4;
            this.groupFirstLevel.TabStop = false;
            this.groupFirstLevel.Text = "Tarjetas de Primer Nivel";
            // 
            // firstLevelCheckBox
            // 
            this.firstLevelCheckBox.AutoSize = true;
            this.firstLevelCheckBox.Location = new System.Drawing.Point(354, 36);
            this.firstLevelCheckBox.Name = "firstLevelCheckBox";
            this.firstLevelCheckBox.Size = new System.Drawing.Size(15, 14);
            this.firstLevelCheckBox.TabIndex = 2;
            this.firstLevelCheckBox.UseVisualStyleBackColor = true;
            this.firstLevelCheckBox.CheckedChanged += new System.EventHandler(this.firstLevelCheckBox_CheckedChanged);
            // 
            // firstLevelCombo
            // 
            this.firstLevelCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.firstLevelCombo.FormattingEnabled = true;
            this.firstLevelCombo.Location = new System.Drawing.Point(72, 33);
            this.firstLevelCombo.Name = "firstLevelCombo";
            this.firstLevelCombo.Size = new System.Drawing.Size(276, 21);
            this.firstLevelCombo.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(1, 36);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Seleccione:";
            // 
            // frmProfilesCreditCards
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(399, 238);
            this.Controls.Add(this.groupSecondLevel);
            this.Controls.Add(this.groupFirstLevel);
            this.Controls.Add(this.btnDeny);
            this.Controls.Add(this.btnAccept);
            this.Controls.Add(this.label1);
            this.Name = "frmProfilesCreditCards";
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tarjetas de Crédito de los Perfiles";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmProfilesCreditCards_FormClosing);
            this.Load += new System.EventHandler(this.frmProfilesCreditCards_Load);
            this.groupSecondLevel.ResumeLayout(false);
            this.groupSecondLevel.PerformLayout();
            this.groupFirstLevel.ResumeLayout(false);
            this.groupFirstLevel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnAccept;
        private System.Windows.Forms.Button btnDeny;
        private System.Windows.Forms.GroupBox groupSecondLevel;
        private System.Windows.Forms.CheckBox secondLevelCheckBox;
        private System.Windows.Forms.ComboBox secondLevelCombo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupFirstLevel;
        private System.Windows.Forms.CheckBox firstLevelCheckBox;
        private System.Windows.Forms.ComboBox firstLevelCombo;
        private System.Windows.Forms.Label label3;
    }
}
