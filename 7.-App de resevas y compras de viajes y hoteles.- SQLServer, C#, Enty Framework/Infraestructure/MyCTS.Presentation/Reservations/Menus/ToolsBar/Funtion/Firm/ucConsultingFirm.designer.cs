namespace MyCTS.Presentation
{
    partial class ucConsultingFirm
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
            this.lblFirmNumber = new System.Windows.Forms.Label();
            this.txtFirmNumber = new MyCTS.Forms.UI.SmartTextBox();
            this.rdoBoth = new System.Windows.Forms.RadioButton();
            this.rdoSabre = new System.Windows.Forms.RadioButton();
            this.rdoMyCTS = new System.Windows.Forms.RadioButton();
            this.btnAccept = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(139)))), ((int)(((byte)(208)))));
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(1, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(411, 17);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Consulta de Firma";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblFirmNumber
            // 
            this.lblFirmNumber.AutoSize = true;
            this.lblFirmNumber.Location = new System.Drawing.Point(14, 33);
            this.lblFirmNumber.Name = "lblFirmNumber";
            this.lblFirmNumber.Size = new System.Drawing.Size(67, 13);
            this.lblFirmNumber.TabIndex = 0;
            this.lblFirmNumber.Text = "No. de Firma";
            // 
            // txtFirmNumber
            // 
            this.txtFirmNumber.AllowBlankSpaces = true;
            this.txtFirmNumber.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtFirmNumber.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.OnlyNumbers;
            this.txtFirmNumber.CustomExpression = ".*";
            this.txtFirmNumber.EnterColor = System.Drawing.Color.Empty;
            this.txtFirmNumber.LeaveColor = System.Drawing.Color.Empty;
            this.txtFirmNumber.Location = new System.Drawing.Point(87, 31);
            this.txtFirmNumber.MaxLength = 4;
            this.txtFirmNumber.Name = "txtFirmNumber";
            this.txtFirmNumber.Size = new System.Drawing.Size(68, 20);
            this.txtFirmNumber.TabIndex = 1;
            this.txtFirmNumber.TextChanged += new System.EventHandler(this.txtFirmNumber_TextChanged);
            this.txtFirmNumber.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // rdoBoth
            // 
            this.rdoBoth.AutoSize = true;
            this.rdoBoth.Location = new System.Drawing.Point(39, 70);
            this.rdoBoth.Name = "rdoBoth";
            this.rdoBoth.Size = new System.Drawing.Size(72, 17);
            this.rdoBoth.TabIndex = 3;
            this.rdoBoth.TabStop = true;
            this.rdoBoth.Text = "En ambos";
            this.rdoBoth.UseVisualStyleBackColor = true;
            this.rdoBoth.CheckedChanged += new System.EventHandler(this.rdoBoth_CheckedChanged);
            this.rdoBoth.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // rdoSabre
            // 
            this.rdoSabre.AutoSize = true;
            this.rdoSabre.Location = new System.Drawing.Point(154, 70);
            this.rdoSabre.Name = "rdoSabre";
            this.rdoSabre.Size = new System.Drawing.Size(77, 17);
            this.rdoSabre.TabIndex = 4;
            this.rdoSabre.TabStop = true;
            this.rdoSabre.Text = "Solo Sabre";
            this.rdoSabre.UseVisualStyleBackColor = true;
            this.rdoSabre.CheckedChanged += new System.EventHandler(this.rdoSabre_CheckedChanged);
            this.rdoSabre.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // rdoMyCTS
            // 
            this.rdoMyCTS.AutoSize = true;
            this.rdoMyCTS.Location = new System.Drawing.Point(277, 70);
            this.rdoMyCTS.Name = "rdoMyCTS";
            this.rdoMyCTS.Size = new System.Drawing.Size(84, 17);
            this.rdoMyCTS.TabIndex = 5;
            this.rdoMyCTS.TabStop = true;
            this.rdoMyCTS.Text = "Solo MyCTS";
            this.rdoMyCTS.UseVisualStyleBackColor = true;
            this.rdoMyCTS.CheckedChanged += new System.EventHandler(this.rdoMyCTS_CheckedChanged);
            this.rdoMyCTS.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // btnAccept
            // 
            this.btnAccept.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnAccept.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAccept.Location = new System.Drawing.Point(277, 124);
            this.btnAccept.Name = "btnAccept";
            this.btnAccept.Size = new System.Drawing.Size(100, 23);
            this.btnAccept.TabIndex = 6;
            this.btnAccept.Text = "Aceptar";
            this.btnAccept.UseVisualStyleBackColor = false;
            this.btnAccept.Click += new System.EventHandler(this.btnAccept_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Appearance = System.Windows.Forms.TabAppearance.FlatButtons;
            this.tabControl1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.tabControl1.Location = new System.Drawing.Point(17, 176);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(344, 258);
            this.tabControl1.TabIndex = 164;
            this.tabControl1.Visible = false;
            // 
            // ucConsultingFirm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.btnAccept);
            this.Controls.Add(this.rdoMyCTS);
            this.Controls.Add(this.rdoSabre);
            this.Controls.Add(this.rdoBoth);
            this.Controls.Add(this.txtFirmNumber);
            this.Controls.Add(this.lblFirmNumber);
            this.Controls.Add(this.lblTitle);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "ucConsultingFirm";
            this.Size = new System.Drawing.Size(411, 580);
            this.Load += new System.EventHandler(this.ucConsultingFirm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblFirmNumber;
        private MyCTS.Forms.UI.SmartTextBox txtFirmNumber;
        private System.Windows.Forms.RadioButton rdoBoth;
        private System.Windows.Forms.RadioButton rdoSabre;
        private System.Windows.Forms.RadioButton rdoMyCTS;
        private System.Windows.Forms.Button btnAccept;
        private System.Windows.Forms.TabControl tabControl1;
    }
}
