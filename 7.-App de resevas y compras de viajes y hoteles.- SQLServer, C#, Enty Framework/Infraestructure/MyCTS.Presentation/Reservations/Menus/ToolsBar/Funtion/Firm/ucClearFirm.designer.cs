namespace MyCTS.Presentation
{
    partial class ucClearFirm
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
            this.btnAccept = new System.Windows.Forms.Button();
            this.txtFirmNumber = new MyCTS.Forms.UI.SmartTextBox();
            this.lblFirmNumber = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.txtAuthorization = new MyCTS.Forms.UI.SmartTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnAccept
            // 
            this.btnAccept.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnAccept.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAccept.Location = new System.Drawing.Point(276, 124);
            this.btnAccept.Name = "btnAccept";
            this.btnAccept.Size = new System.Drawing.Size(100, 23);
            this.btnAccept.TabIndex = 3;
            this.btnAccept.Text = "Aceptar";
            this.btnAccept.UseVisualStyleBackColor = false;
            this.btnAccept.Click += new System.EventHandler(this.btnAccept_Click);
            // 
            // txtFirmNumber
            // 
            this.txtFirmNumber.AllowBlankSpaces = true;
            this.txtFirmNumber.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtFirmNumber.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.OnlyNumbers;
            this.txtFirmNumber.CustomExpression = ".*";
            this.txtFirmNumber.EnterColor = System.Drawing.Color.Empty;
            this.txtFirmNumber.LeaveColor = System.Drawing.Color.Empty;
            this.txtFirmNumber.Location = new System.Drawing.Point(97, 30);
            this.txtFirmNumber.MaxLength = 4;
            this.txtFirmNumber.Name = "txtFirmNumber";
            this.txtFirmNumber.Size = new System.Drawing.Size(68, 20);
            this.txtFirmNumber.TabIndex = 1;
            this.txtFirmNumber.TextChanged += new System.EventHandler(this.txtFirmNumber_TextChanged);
            this.txtFirmNumber.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // lblFirmNumber
            // 
            this.lblFirmNumber.AutoSize = true;
            this.lblFirmNumber.Location = new System.Drawing.Point(13, 33);
            this.lblFirmNumber.Name = "lblFirmNumber";
            this.lblFirmNumber.Size = new System.Drawing.Size(67, 13);
            this.lblFirmNumber.TabIndex = 0;
            this.lblFirmNumber.Text = "No. de Firma";
            // 
            // lblTitle
            // 
            this.lblTitle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(139)))), ((int)(((byte)(208)))));
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(0, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(411, 17);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Limpiar Firma";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // txtAuthorization
            // 
            this.txtAuthorization.AllowBlankSpaces = true;
            this.txtAuthorization.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtAuthorization.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.AnyCharacter;
            this.txtAuthorization.CustomExpression = ".*";
            this.txtAuthorization.EnterColor = System.Drawing.Color.Empty;
            this.txtAuthorization.LeaveColor = System.Drawing.Color.Empty;
            this.txtAuthorization.Location = new System.Drawing.Point(97, 61);
            this.txtAuthorization.MaxLength = 15;
            this.txtAuthorization.Name = "txtAuthorization";
            this.txtAuthorization.Size = new System.Drawing.Size(100, 20);
            this.txtAuthorization.TabIndex = 2;
            this.txtAuthorization.TextChanged += new System.EventHandler(this.txtAuthorization_TextChanged);
            this.txtAuthorization.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 64);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Autorizado por";
            // 
            // ucClearFirm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtAuthorization);
            this.Controls.Add(this.btnAccept);
            this.Controls.Add(this.txtFirmNumber);
            this.Controls.Add(this.lblFirmNumber);
            this.Controls.Add(this.lblTitle);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "ucClearFirm";
            this.Size = new System.Drawing.Size(411, 580);
            this.Load += new System.EventHandler(this.ucClearFirm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnAccept;
        private MyCTS.Forms.UI.SmartTextBox txtFirmNumber;
        private System.Windows.Forms.Label lblFirmNumber;
        internal System.Windows.Forms.Label lblTitle;
        private MyCTS.Forms.UI.SmartTextBox txtAuthorization;
        private System.Windows.Forms.Label label1;
    }
}
