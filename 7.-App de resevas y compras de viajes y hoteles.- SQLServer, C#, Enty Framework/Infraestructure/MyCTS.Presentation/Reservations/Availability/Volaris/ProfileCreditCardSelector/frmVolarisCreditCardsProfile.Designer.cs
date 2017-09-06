namespace MyCTS.Presentation.Reservations.Availability.Volaris.ProfileCreditCardSelector
{
    partial class frmVolarisCreditCardsProfile
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
            this.buttonPanel = new System.Windows.Forms.Panel();
            this.denyButton = new System.Windows.Forms.Button();
            this.confirmButton = new System.Windows.Forms.Button();
            this.groupSecondLevel = new System.Windows.Forms.GroupBox();
            this.secondLevelCheckBox = new System.Windows.Forms.CheckBox();
            this.secondLevelCombo = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupFristLevel = new System.Windows.Forms.GroupBox();
            this.fristLevelCheckBox = new System.Windows.Forms.CheckBox();
            this.fristLevelCombo = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.buttonPanel.SuspendLayout();
            this.groupSecondLevel.SuspendLayout();
            this.groupFristLevel.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonPanel
            // 
            this.buttonPanel.Controls.Add(this.denyButton);
            this.buttonPanel.Controls.Add(this.confirmButton);
            this.buttonPanel.Location = new System.Drawing.Point(21, 175);
            this.buttonPanel.Name = "buttonPanel";
            this.buttonPanel.Size = new System.Drawing.Size(372, 31);
            this.buttonPanel.TabIndex = 6;
            // 
            // denyButton
            // 
            this.denyButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.denyButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.denyButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.denyButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.denyButton.Location = new System.Drawing.Point(217, 3);
            this.denyButton.Name = "denyButton";
            this.denyButton.Size = new System.Drawing.Size(152, 25);
            this.denyButton.TabIndex = 18;
            this.denyButton.Text = "No deseo usar esta opción";
            this.denyButton.UseVisualStyleBackColor = false;
            this.denyButton.Click += new System.EventHandler(this.denyButton_Click);
            // 
            // confirmButton
            // 
            this.confirmButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.confirmButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.confirmButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.confirmButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.confirmButton.Location = new System.Drawing.Point(126, 3);
            this.confirmButton.Name = "confirmButton";
            this.confirmButton.Size = new System.Drawing.Size(85, 25);
            this.confirmButton.TabIndex = 17;
            this.confirmButton.Text = "Confirmar selección";
            this.confirmButton.UseVisualStyleBackColor = false;
            this.confirmButton.Click += new System.EventHandler(this.confirmButton_Click);
            // 
            // groupSecondLevel
            // 
            this.groupSecondLevel.Controls.Add(this.secondLevelCheckBox);
            this.groupSecondLevel.Controls.Add(this.secondLevelCombo);
            this.groupSecondLevel.Controls.Add(this.label2);
            this.groupSecondLevel.Location = new System.Drawing.Point(12, 93);
            this.groupSecondLevel.Name = "groupSecondLevel";
            this.groupSecondLevel.Size = new System.Drawing.Size(381, 76);
            this.groupSecondLevel.TabIndex = 5;
            this.groupSecondLevel.TabStop = false;
            this.groupSecondLevel.Text = "Tarjetas de Segundo Nivel";
            // 
            // secondLevelCheckBox
            // 
            this.secondLevelCheckBox.AutoSize = true;
            this.secondLevelCheckBox.Location = new System.Drawing.Point(354, 44);
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
            this.secondLevelCombo.Location = new System.Drawing.Point(86, 37);
            this.secondLevelCombo.Name = "secondLevelCombo";
            this.secondLevelCombo.Size = new System.Drawing.Size(235, 21);
            this.secondLevelCombo.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Seleccione:";
            // 
            // groupFristLevel
            // 
            this.groupFristLevel.Controls.Add(this.fristLevelCheckBox);
            this.groupFristLevel.Controls.Add(this.fristLevelCombo);
            this.groupFristLevel.Controls.Add(this.label1);
            this.groupFristLevel.Location = new System.Drawing.Point(12, 12);
            this.groupFristLevel.Name = "groupFristLevel";
            this.groupFristLevel.Size = new System.Drawing.Size(381, 75);
            this.groupFristLevel.TabIndex = 4;
            this.groupFristLevel.TabStop = false;
            this.groupFristLevel.Text = "Tarjetas de Primer Nivel";
            // 
            // fristLevelCheckBox
            // 
            this.fristLevelCheckBox.AutoSize = true;
            this.fristLevelCheckBox.Location = new System.Drawing.Point(354, 37);
            this.fristLevelCheckBox.Name = "fristLevelCheckBox";
            this.fristLevelCheckBox.Size = new System.Drawing.Size(15, 14);
            this.fristLevelCheckBox.TabIndex = 2;
            this.fristLevelCheckBox.UseVisualStyleBackColor = true;
            this.fristLevelCheckBox.CheckedChanged += new System.EventHandler(this.fristLevelCheckBox_CheckedChanged);
            // 
            // fristLevelCombo
            // 
            this.fristLevelCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.fristLevelCombo.FormattingEnabled = true;
            this.fristLevelCombo.Location = new System.Drawing.Point(86, 34);
            this.fristLevelCombo.Name = "fristLevelCombo";
            this.fristLevelCombo.Size = new System.Drawing.Size(235, 21);
            this.fristLevelCombo.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Seleccione:";
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl1.Appearance.ForeColor = System.Drawing.SystemColors.InfoText;
            this.labelControl1.Location = new System.Drawing.Point(21, 221);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(398, 26);
            this.labelControl1.TabIndex = 7;
            this.labelControl1.Text = "Selecciona la tarjeta del perfil que desees asignar en la forma de pago,\r\nautomat" +
    "icamente se seleccionara en la mascarilla.";
            // 
            // frmVolarisCreditCardsProfile
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(435, 269);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.buttonPanel);
            this.Controls.Add(this.groupSecondLevel);
            this.Controls.Add(this.groupFristLevel);
            this.Name = "frmVolarisCreditCardsProfile";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tarjetas del Perfil";
            this.buttonPanel.ResumeLayout(false);
            this.groupSecondLevel.ResumeLayout(false);
            this.groupSecondLevel.PerformLayout();
            this.groupFristLevel.ResumeLayout(false);
            this.groupFristLevel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel buttonPanel;
        private System.Windows.Forms.Button denyButton;
        private System.Windows.Forms.Button confirmButton;
        private System.Windows.Forms.GroupBox groupSecondLevel;
        private System.Windows.Forms.CheckBox secondLevelCheckBox;
        private System.Windows.Forms.ComboBox secondLevelCombo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupFristLevel;
        private System.Windows.Forms.CheckBox fristLevelCheckBox;
        private System.Windows.Forms.ComboBox fristLevelCombo;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.LabelControl labelControl1;

    }
}