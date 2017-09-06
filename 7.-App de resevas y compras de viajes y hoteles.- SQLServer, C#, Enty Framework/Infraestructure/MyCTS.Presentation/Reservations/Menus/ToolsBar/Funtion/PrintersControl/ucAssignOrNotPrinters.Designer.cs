namespace MyCTS.Presentation
{
    partial class ucAssignOrNotPrinters
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
            this.tblLayoutMain = new System.Windows.Forms.TableLayoutPanel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.txtValue = new MyCTS.Forms.UI.SmartTextBox();
            this.lblInstructions = new System.Windows.Forms.Label();
            this.btnAccept = new System.Windows.Forms.Button();
            this.tblLayoutOptions = new System.Windows.Forms.TableLayoutPanel();
            this.rdoPrinterProfile = new System.Windows.Forms.RadioButton();
            this.rdoTickets = new System.Windows.Forms.RadioButton();
            this.rdoItineraryInvoice = new System.Windows.Forms.RadioButton();
            this.rdoHardCopy = new System.Windows.Forms.RadioButton();
            this.chkAssign = new System.Windows.Forms.CheckBox();
            this.chkNotAssign = new System.Windows.Forms.CheckBox();
            this.tblLayoutMain.SuspendLayout();
            this.tblLayoutOptions.SuspendLayout();
            this.SuspendLayout();
            // 
            // tblLayoutMain
            // 
            this.tblLayoutMain.BackColor = System.Drawing.Color.White;
            this.tblLayoutMain.ColumnCount = 5;
            this.tblLayoutMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 15F));
            this.tblLayoutMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 9.743589F));
            this.tblLayoutMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 90.25641F));
            this.tblLayoutMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 93F));
            this.tblLayoutMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 103F));
            this.tblLayoutMain.Controls.Add(this.lblTitle, 0, 0);
            this.tblLayoutMain.Controls.Add(this.txtValue, 3, 6);
            this.tblLayoutMain.Controls.Add(this.lblInstructions, 2, 6);
            this.tblLayoutMain.Controls.Add(this.btnAccept, 3, 8);
            this.tblLayoutMain.Controls.Add(this.tblLayoutOptions, 1, 2);
            this.tblLayoutMain.Controls.Add(this.chkAssign, 3, 2);
            this.tblLayoutMain.Controls.Add(this.chkNotAssign, 3, 3);
            this.tblLayoutMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblLayoutMain.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tblLayoutMain.Location = new System.Drawing.Point(0, 0);
            this.tblLayoutMain.Name = "tblLayoutMain";
            this.tblLayoutMain.RowCount = 12;
            this.tblLayoutMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 15F));
            this.tblLayoutMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 37F));
            this.tblLayoutMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15.68627F));
            this.tblLayoutMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15.84699F));
            this.tblLayoutMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15.30055F));
            this.tblLayoutMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.93989F));
            this.tblLayoutMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 13.71429F));
            this.tblLayoutMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 22.28572F));
            this.tblLayoutMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.tblLayoutMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 211F));
            this.tblLayoutMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tblLayoutMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tblLayoutMain.Size = new System.Drawing.Size(411, 580);
            this.tblLayoutMain.TabIndex = 0;
            // 
            // lblTitle
            // 
            this.lblTitle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(139)))), ((int)(((byte)(208)))));
            this.tblLayoutMain.SetColumnSpan(this.lblTitle, 5);
            this.lblTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(3, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(405, 15);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Asigna/Desasigna Impresoras";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // txtValue
            // 
            this.txtValue.AllowBlankSpaces = false;
            this.txtValue.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtValue.CharsNoIncluded = new char[] {
        ' '};
            this.txtValue.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.AnyCharacter;
            this.txtValue.CustomExpression = ".*";
            this.txtValue.Dock = System.Windows.Forms.DockStyle.Left;
            this.txtValue.EnterColor = System.Drawing.Color.Empty;
            this.txtValue.LeaveColor = System.Drawing.Color.Empty;
            this.txtValue.Location = new System.Drawing.Point(217, 167);
            this.txtValue.Name = "txtValue";
            this.txtValue.Size = new System.Drawing.Size(77, 20);
            this.txtValue.TabIndex = 8;
            this.txtValue.TextChanged += new System.EventHandler(this.txtValue_TextChanged);
            this.txtValue.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // lblInstructions
            // 
            this.lblInstructions.AutoSize = true;
            this.lblInstructions.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblInstructions.Location = new System.Drawing.Point(37, 164);
            this.lblInstructions.Name = "lblInstructions";
            this.lblInstructions.Size = new System.Drawing.Size(29, 24);
            this.lblInstructions.TabIndex = 0;
            this.lblInstructions.Text = "label";
            this.lblInstructions.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnAccept
            // 
            this.btnAccept.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnAccept.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAccept.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnAccept.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAccept.Location = new System.Drawing.Point(217, 230);
            this.btnAccept.Name = "btnAccept";
            this.btnAccept.Size = new System.Drawing.Size(87, 23);
            this.btnAccept.TabIndex = 9;
            this.btnAccept.Text = "Aceptar";
            this.btnAccept.UseVisualStyleBackColor = false;
            this.btnAccept.Click += new System.EventHandler(this.btnAccept_Click);
            // 
            // tblLayoutOptions
            // 
            this.tblLayoutOptions.ColumnCount = 1;
            this.tblLayoutMain.SetColumnSpan(this.tblLayoutOptions, 2);
            this.tblLayoutOptions.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblLayoutOptions.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tblLayoutOptions.Controls.Add(this.rdoPrinterProfile, 0, 0);
            this.tblLayoutOptions.Controls.Add(this.rdoTickets, 0, 1);
            this.tblLayoutOptions.Controls.Add(this.rdoItineraryInvoice, 0, 2);
            this.tblLayoutOptions.Controls.Add(this.rdoHardCopy, 0, 3);
            this.tblLayoutOptions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblLayoutOptions.Location = new System.Drawing.Point(15, 52);
            this.tblLayoutOptions.Margin = new System.Windows.Forms.Padding(0);
            this.tblLayoutOptions.Name = "tblLayoutOptions";
            this.tblLayoutOptions.RowCount = 4;
            this.tblLayoutMain.SetRowSpan(this.tblLayoutOptions, 4);
            this.tblLayoutOptions.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 49.09091F));
            this.tblLayoutOptions.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.90909F));
            this.tblLayoutOptions.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.tblLayoutOptions.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.tblLayoutOptions.Size = new System.Drawing.Size(199, 112);
            this.tblLayoutOptions.TabIndex = 1;
            // 
            // rdoPrinterProfile
            // 
            this.rdoPrinterProfile.AutoSize = true;
            this.rdoPrinterProfile.Dock = System.Windows.Forms.DockStyle.Left;
            this.rdoPrinterProfile.Location = new System.Drawing.Point(3, 3);
            this.rdoPrinterProfile.Name = "rdoPrinterProfile";
            this.rdoPrinterProfile.Size = new System.Drawing.Size(110, 21);
            this.rdoPrinterProfile.TabIndex = 2;
            this.rdoPrinterProfile.TabStop = true;
            this.rdoPrinterProfile.Text = "Perfil de impresión";
            this.rdoPrinterProfile.UseVisualStyleBackColor = true;
            this.rdoPrinterProfile.CheckedChanged += new System.EventHandler(this.rdoPrinterProfile_CheckedChanged);
            this.rdoPrinterProfile.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // rdoTickets
            // 
            this.rdoTickets.AutoSize = true;
            this.rdoTickets.Dock = System.Windows.Forms.DockStyle.Left;
            this.rdoTickets.Location = new System.Drawing.Point(3, 30);
            this.rdoTickets.Name = "rdoTickets";
            this.rdoTickets.Size = new System.Drawing.Size(60, 22);
            this.rdoTickets.TabIndex = 3;
            this.rdoTickets.TabStop = true;
            this.rdoTickets.Text = "Boletos";
            this.rdoTickets.UseVisualStyleBackColor = true;
            this.rdoTickets.CheckedChanged += new System.EventHandler(this.rdoTickets_CheckedChanged);
            this.rdoTickets.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // rdoItineraryInvoice
            // 
            this.rdoItineraryInvoice.AutoSize = true;
            this.rdoItineraryInvoice.Dock = System.Windows.Forms.DockStyle.Left;
            this.rdoItineraryInvoice.Location = new System.Drawing.Point(3, 58);
            this.rdoItineraryInvoice.Name = "rdoItineraryInvoice";
            this.rdoItineraryInvoice.Size = new System.Drawing.Size(106, 21);
            this.rdoItineraryInvoice.TabIndex = 4;
            this.rdoItineraryInvoice.TabStop = true;
            this.rdoItineraryInvoice.Text = "Itinerario/Factura";
            this.rdoItineraryInvoice.UseVisualStyleBackColor = true;
            this.rdoItineraryInvoice.CheckedChanged += new System.EventHandler(this.rdoItineraryInvoice_CheckedChanged);
            this.rdoItineraryInvoice.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // rdoHardCopy
            // 
            this.rdoHardCopy.AutoSize = true;
            this.rdoHardCopy.Dock = System.Windows.Forms.DockStyle.Left;
            this.rdoHardCopy.Location = new System.Drawing.Point(3, 85);
            this.rdoHardCopy.Name = "rdoHardCopy";
            this.rdoHardCopy.Size = new System.Drawing.Size(72, 24);
            this.rdoHardCopy.TabIndex = 5;
            this.rdoHardCopy.TabStop = true;
            this.rdoHardCopy.Text = "HardCopy";
            this.rdoHardCopy.UseVisualStyleBackColor = true;
            this.rdoHardCopy.CheckedChanged += new System.EventHandler(this.rdoHardCopy_CheckedChanged);
            this.rdoHardCopy.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // chkAssign
            // 
            this.chkAssign.AutoSize = true;
            this.chkAssign.Dock = System.Windows.Forms.DockStyle.Left;
            this.chkAssign.Location = new System.Drawing.Point(217, 55);
            this.chkAssign.Name = "chkAssign";
            this.chkAssign.Size = new System.Drawing.Size(61, 21);
            this.chkAssign.TabIndex = 6;
            this.chkAssign.Text = "Asignar";
            this.chkAssign.UseVisualStyleBackColor = true;
            this.chkAssign.CheckedChanged += new System.EventHandler(this.chkAssign_CheckedChanged);
            this.chkAssign.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // chkNotAssign
            // 
            this.chkNotAssign.AutoSize = true;
            this.chkNotAssign.Dock = System.Windows.Forms.DockStyle.Left;
            this.chkNotAssign.Location = new System.Drawing.Point(217, 82);
            this.chkNotAssign.Name = "chkNotAssign";
            this.chkNotAssign.Size = new System.Drawing.Size(82, 22);
            this.chkNotAssign.TabIndex = 7;
            this.chkNotAssign.Text = "Des-asignar";
            this.chkNotAssign.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkNotAssign.UseVisualStyleBackColor = true;
            this.chkNotAssign.CheckedChanged += new System.EventHandler(this.chkNotAssign_CheckedChanged);
            this.chkNotAssign.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // ucAssignOrNotPrinters
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tblLayoutMain);
            this.Name = "ucAssignOrNotPrinters";
            this.Size = new System.Drawing.Size(411, 580);
            this.Load += new System.EventHandler(this.ucAssignOrNotPrinters_Load);
            this.tblLayoutMain.ResumeLayout(false);
            this.tblLayoutMain.PerformLayout();
            this.tblLayoutOptions.ResumeLayout(false);
            this.tblLayoutOptions.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.TableLayoutPanel tblLayoutMain;
        internal System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Button btnAccept;
        private System.Windows.Forms.RadioButton rdoPrinterProfile;
        private System.Windows.Forms.RadioButton rdoTickets;
        private System.Windows.Forms.RadioButton rdoItineraryInvoice;
        private System.Windows.Forms.RadioButton rdoHardCopy;
        private System.Windows.Forms.CheckBox chkAssign;
        private System.Windows.Forms.CheckBox chkNotAssign;
        private MyCTS.Forms.UI.SmartTextBox txtValue;
        private System.Windows.Forms.Label lblInstructions;
        private System.Windows.Forms.TableLayoutPanel tblLayoutOptions;
    }
}
