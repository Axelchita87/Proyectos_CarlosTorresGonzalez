namespace MyCTS.Presentation
{
    partial class ucRegenerateInvoice
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
            this.txtNumberInvoice = new MyCTS.Forms.UI.SmartTextBox();
            this.cmbTypeInvoice = new System.Windows.Forms.ComboBox();
            this.lblTypeInvoice = new System.Windows.Forms.Label();
            this.lblNumberInvoice = new System.Windows.Forms.Label();
            this.btnAccept = new System.Windows.Forms.Button();
            this.lblInstruction = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(139)))), ((int)(((byte)(208)))));
            this.lblTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(0, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(411, 17);
            this.lblTitle.TabIndex = 41;
            this.lblTitle.Text = "Regenerar Factura";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtNumberInvoice
            // 
            this.txtNumberInvoice.AllowBlankSpaces = false;
            this.txtNumberInvoice.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtNumberInvoice.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.OnlyNumbers;
            this.txtNumberInvoice.CustomExpression = ".*";
            this.txtNumberInvoice.EnterColor = System.Drawing.Color.Empty;
            this.txtNumberInvoice.LeaveColor = System.Drawing.Color.Empty;
            this.txtNumberInvoice.Location = new System.Drawing.Point(123, 118);
            this.txtNumberInvoice.MaxLength = 10;
            this.txtNumberInvoice.Name = "txtNumberInvoice";
            this.txtNumberInvoice.Size = new System.Drawing.Size(113, 20);
            this.txtNumberInvoice.TabIndex = 2;
            this.txtNumberInvoice.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // cmbTypeInvoice
            // 
            this.cmbTypeInvoice.FormattingEnabled = true;
            this.cmbTypeInvoice.Items.AddRange(new object[] {
            "Seleccione una opción",
            "DXE - Nota de Credito Documentos de Servicio",
            "NCE - Nota de Credito Factura Fiscal",
            "FCE - Factura Fiscal",
            "STE - Documentos de Servicio"});
            this.cmbTypeInvoice.Location = new System.Drawing.Point(123, 79);
            this.cmbTypeInvoice.Name = "cmbTypeInvoice";
            this.cmbTypeInvoice.Size = new System.Drawing.Size(260, 21);
            this.cmbTypeInvoice.TabIndex = 1;
            this.cmbTypeInvoice.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // lblTypeInvoice
            // 
            this.lblTypeInvoice.AutoSize = true;
            this.lblTypeInvoice.Location = new System.Drawing.Point(19, 87);
            this.lblTypeInvoice.Name = "lblTypeInvoice";
            this.lblTypeInvoice.Size = new System.Drawing.Size(85, 13);
            this.lblTypeInvoice.TabIndex = 43;
            this.lblTypeInvoice.Text = "Tipo de Factura:";
            // 
            // lblNumberInvoice
            // 
            this.lblNumberInvoice.AutoSize = true;
            this.lblNumberInvoice.Location = new System.Drawing.Point(19, 125);
            this.lblNumberInvoice.Name = "lblNumberInvoice";
            this.lblNumberInvoice.Size = new System.Drawing.Size(98, 13);
            this.lblNumberInvoice.TabIndex = 43;
            this.lblNumberInvoice.Text = "Número de factura:";
            // 
            // btnAccept
            // 
            this.btnAccept.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnAccept.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAccept.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAccept.Location = new System.Drawing.Point(283, 180);
            this.btnAccept.Name = "btnAccept";
            this.btnAccept.Size = new System.Drawing.Size(100, 23);
            this.btnAccept.TabIndex = 3;
            this.btnAccept.Text = "Aceptar";
            this.btnAccept.UseVisualStyleBackColor = false;
            this.btnAccept.Click += new System.EventHandler(this.btnAccept_Click);
            // 
            // lblInstruction
            // 
            this.lblInstruction.AutoSize = true;
            this.lblInstruction.Location = new System.Drawing.Point(19, 42);
            this.lblInstruction.Name = "lblInstruction";
            this.lblInstruction.Size = new System.Drawing.Size(149, 13);
            this.lblInstruction.TabIndex = 45;
            this.lblInstruction.Text = "Ingrese los datos de la factura";
            // 
            // ucRegenerateInvoice
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.lblInstruction);
            this.Controls.Add(this.btnAccept);
            this.Controls.Add(this.lblNumberInvoice);
            this.Controls.Add(this.lblTypeInvoice);
            this.Controls.Add(this.cmbTypeInvoice);
            this.Controls.Add(this.txtNumberInvoice);
            this.Controls.Add(this.lblTitle);
            this.Name = "ucRegenerateInvoice";
            this.Size = new System.Drawing.Size(411, 580);
            this.Load += new System.EventHandler(this.ucRegenerateInvoice_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.Label lblTitle;
        private MyCTS.Forms.UI.SmartTextBox txtNumberInvoice;
        private System.Windows.Forms.ComboBox cmbTypeInvoice;
        private System.Windows.Forms.Label lblTypeInvoice;
        private System.Windows.Forms.Label lblNumberInvoice;
        private System.Windows.Forms.Button btnAccept;
        private System.Windows.Forms.Label lblInstruction;
    }
}
