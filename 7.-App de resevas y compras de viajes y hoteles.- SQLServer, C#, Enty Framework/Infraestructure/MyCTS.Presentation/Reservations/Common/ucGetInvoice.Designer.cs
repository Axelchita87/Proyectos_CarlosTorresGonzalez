namespace MyCTS.Presentation
{
    partial class ucGetInvoice
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.lblChargePerService = new System.Windows.Forms.Label();
            this.txtInvoice = new MyCTS.Forms.UI.SmartTextBox();
            this.lblTktNumber = new System.Windows.Forms.Label();
            this.btnAccept = new System.Windows.Forms.Button();
            this.lblInfoFacturas = new System.Windows.Forms.Label();
            this.GridViewFacturas = new System.Windows.Forms.DataGridView();
            this.FacturaName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NameFactura = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.GridViewFacturas)).BeginInit();
            this.SuspendLayout();
            // 
            // lblChargePerService
            // 
            this.lblChargePerService.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(139)))), ((int)(((byte)(208)))));
            this.lblChargePerService.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblChargePerService.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblChargePerService.ForeColor = System.Drawing.Color.White;
            this.lblChargePerService.Location = new System.Drawing.Point(0, 0);
            this.lblChargePerService.Name = "lblChargePerService";
            this.lblChargePerService.Size = new System.Drawing.Size(411, 17);
            this.lblChargePerService.TabIndex = 40;
            this.lblChargePerService.Text = "Generar Factura";
            this.lblChargePerService.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtInvoice
            // 
            this.txtInvoice.AllowBlankSpaces = false;
            this.txtInvoice.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtInvoice.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.OnlyNumbers;
            this.txtInvoice.CustomExpression = ".*";
            this.txtInvoice.EnterColor = System.Drawing.Color.Empty;
            this.txtInvoice.LeaveColor = System.Drawing.Color.Empty;
            this.txtInvoice.Location = new System.Drawing.Point(148, 57);
            this.txtInvoice.MaxLength = 10;
            this.txtInvoice.Name = "txtInvoice";
            this.txtInvoice.Size = new System.Drawing.Size(97, 20);
            this.txtInvoice.TabIndex = 2;
            this.txtInvoice.TextChanged += new System.EventHandler(this.txtControls_TextChanged);
            this.txtInvoice.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // lblTktNumber
            // 
            this.lblTktNumber.AutoSize = true;
            this.lblTktNumber.Location = new System.Drawing.Point(33, 64);
            this.lblTktNumber.Name = "lblTktNumber";
            this.lblTktNumber.Size = new System.Drawing.Size(95, 13);
            this.lblTktNumber.TabIndex = 41;
            this.lblTktNumber.Text = "Número de Boleto:";
            // 
            // btnAccept
            // 
            this.btnAccept.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnAccept.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAccept.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAccept.Location = new System.Drawing.Point(270, 154);
            this.btnAccept.Name = "btnAccept";
            this.btnAccept.Size = new System.Drawing.Size(100, 23);
            this.btnAccept.TabIndex = 3;
            this.btnAccept.Text = "Aceptar";
            this.btnAccept.UseVisualStyleBackColor = false;
            this.btnAccept.Click += new System.EventHandler(this.btnAccept_Click);
            // 
            // lblInfoFacturas
            // 
            this.lblInfoFacturas.AutoSize = true;
            this.lblInfoFacturas.Location = new System.Drawing.Point(33, 237);
            this.lblInfoFacturas.Name = "lblInfoFacturas";
            this.lblInfoFacturas.Size = new System.Drawing.Size(173, 13);
            this.lblInfoFacturas.TabIndex = 44;
            this.lblInfoFacturas.Text = "Selecciona el documento a mostrar";
            this.lblInfoFacturas.Visible = false;
            // 
            // GridViewFacturas
            // 
            this.GridViewFacturas.AllowUserToAddRows = false;
            this.GridViewFacturas.AllowUserToDeleteRows = false;
            this.GridViewFacturas.AllowUserToResizeRows = false;
            this.GridViewFacturas.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.GridViewFacturas.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedHeaders;
            this.GridViewFacturas.BackgroundColor = System.Drawing.Color.White;
            this.GridViewFacturas.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.GridViewFacturas.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.GridViewFacturas.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.GridViewFacturas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.FacturaName,
            this.NameFactura});
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.GridViewFacturas.DefaultCellStyle = dataGridViewCellStyle4;
            this.GridViewFacturas.EnableHeadersVisualStyles = false;
            this.GridViewFacturas.GridColor = System.Drawing.Color.White;
            this.GridViewFacturas.Location = new System.Drawing.Point(21, 270);
            this.GridViewFacturas.MultiSelect = false;
            this.GridViewFacturas.Name = "GridViewFacturas";
            this.GridViewFacturas.ReadOnly = true;
            this.GridViewFacturas.RowHeadersWidth = 21;
            this.GridViewFacturas.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.GridViewFacturas.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.GridViewFacturas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.GridViewFacturas.Size = new System.Drawing.Size(370, 227);
            this.GridViewFacturas.StandardTab = true;
            this.GridViewFacturas.TabIndex = 45;
            this.GridViewFacturas.Visible = false;
            this.GridViewFacturas.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.GridViewFacturas_Click);
            // 
            // FacturaName
            // 
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FacturaName.DefaultCellStyle = dataGridViewCellStyle2;
            this.FacturaName.FillWeight = 121.8274F;
            this.FacturaName.HeaderText = "Facturas";
            this.FacturaName.Name = "FacturaName";
            this.FacturaName.ReadOnly = true;
            this.FacturaName.Width = 82;
            // 
            // NameFactura
            // 
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NameFactura.DefaultCellStyle = dataGridViewCellStyle3;
            this.NameFactura.FillWeight = 78.17259F;
            this.NameFactura.HeaderText = "Documentos";
            this.NameFactura.Name = "NameFactura";
            this.NameFactura.ReadOnly = true;
            this.NameFactura.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.NameFactura.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.NameFactura.Width = 84;
            // 
            // ucGetInvoice
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.GridViewFacturas);
            this.Controls.Add(this.lblInfoFacturas);
            this.Controls.Add(this.btnAccept);
            this.Controls.Add(this.lblTktNumber);
            this.Controls.Add(this.txtInvoice);
            this.Controls.Add(this.lblChargePerService);
            this.Name = "ucGetInvoice";
            this.Size = new System.Drawing.Size(411, 580);
            this.Load += new System.EventHandler(this.ucGetInvoice_Load);
            ((System.ComponentModel.ISupportInitialize)(this.GridViewFacturas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.Label lblChargePerService;
        private MyCTS.Forms.UI.SmartTextBox txtInvoice;
        private System.Windows.Forms.Label lblTktNumber;
        private System.Windows.Forms.Button btnAccept;
        private System.Windows.Forms.Label lblInfoFacturas;
        private System.Windows.Forms.DataGridView GridViewFacturas;
        private System.Windows.Forms.DataGridViewTextBoxColumn FacturaName;
        private System.Windows.Forms.DataGridViewTextBoxColumn NameFactura;
    }
}
