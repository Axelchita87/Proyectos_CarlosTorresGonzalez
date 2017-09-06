namespace MyCTS.Presentation
{
    partial class ucBusinessUnit
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
            this.components = new System.ComponentModel.Container();
            this.lblCTS = new System.Windows.Forms.Label();
            this.btnAccept = new System.Windows.Forms.Button();
            this.lblTitle = new System.Windows.Forms.Label();
            this.dgvJustifications = new System.Windows.Forms.DataGridView();
            this.nameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pCCDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.rdoEnterpricePolicy = new System.Windows.Forms.RadioButton();
            this.rdoTouristBulletin = new System.Windows.Forms.RadioButton();
            this.rdoEmail = new System.Windows.Forms.RadioButton();
            this.rdoCustomerRecommendation = new System.Windows.Forms.RadioButton();
            this.rdoHumanResources = new System.Windows.Forms.RadioButton();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)(this.dgvJustifications)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblCTS
            // 
            this.lblCTS.AutoSize = true;
            this.lblCTS.ForeColor = System.Drawing.Color.Blue;
            this.lblCTS.Location = new System.Drawing.Point(3, 32);
            this.lblCTS.Name = "lblCTS";
            this.lblCTS.Size = new System.Drawing.Size(166, 13);
            this.lblCTS.TabIndex = 0;
            this.lblCTS.Text = "Selecciona la Unidad de Negocio";
            // 
            // btnAccept
            // 
            this.btnAccept.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnAccept.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAccept.Location = new System.Drawing.Point(290, 545);
            this.btnAccept.Name = "btnAccept";
            this.btnAccept.Size = new System.Drawing.Size(100, 23);
            this.btnAccept.TabIndex = 8;
            this.btnAccept.Text = "Aceptar";
            this.btnAccept.UseVisualStyleBackColor = false;
            this.btnAccept.Click += new System.EventHandler(this.btnAccept_Click);
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
            this.lblTitle.Text = "Unidad de Negocio/Origen Venta";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // dgvJustifications
            // 
            this.dgvJustifications.AllowUserToAddRows = false;
            this.dgvJustifications.AllowUserToDeleteRows = false;
            this.dgvJustifications.AllowUserToResizeRows = false;
            this.dgvJustifications.AutoGenerateColumns = false;
            this.dgvJustifications.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvJustifications.BackgroundColor = System.Drawing.Color.FloralWhite;
            this.dgvJustifications.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            this.dgvJustifications.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvJustifications.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.nameDataGridViewTextBoxColumn,
            this.pCCDataGridViewTextBoxColumn});
            this.dgvJustifications.DataSource = this.bindingSource1;
            this.dgvJustifications.EnableHeadersVisualStyles = false;
            this.dgvJustifications.GridColor = System.Drawing.Color.White;
            this.dgvJustifications.Location = new System.Drawing.Point(6, 48);
            this.dgvJustifications.MultiSelect = false;
            this.dgvJustifications.Name = "dgvJustifications";
            this.dgvJustifications.ReadOnly = true;
            this.dgvJustifications.RowHeadersWidth = 21;
            this.dgvJustifications.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgvJustifications.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvJustifications.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvJustifications.Size = new System.Drawing.Size(384, 319);
            this.dgvJustifications.StandardTab = true;
            this.dgvJustifications.TabIndex = 1;
            this.dgvJustifications.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvJustifications_CellDoubleClick);
            this.dgvJustifications.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgvJustifications_KeyDown);
            // 
            // nameDataGridViewTextBoxColumn
            // 
            this.nameDataGridViewTextBoxColumn.DataPropertyName = "Name";
            this.nameDataGridViewTextBoxColumn.HeaderText = "Leyenda";
            this.nameDataGridViewTextBoxColumn.Name = "nameDataGridViewTextBoxColumn";
            this.nameDataGridViewTextBoxColumn.ReadOnly = true;
            this.nameDataGridViewTextBoxColumn.Width = 73;
            // 
            // pCCDataGridViewTextBoxColumn
            // 
            this.pCCDataGridViewTextBoxColumn.DataPropertyName = "PCC";
            this.pCCDataGridViewTextBoxColumn.HeaderText = "PCC";
            this.pCCDataGridViewTextBoxColumn.Name = "pCCDataGridViewTextBoxColumn";
            this.pCCDataGridViewTextBoxColumn.ReadOnly = true;
            this.pCCDataGridViewTextBoxColumn.Width = 53;
            // 
            // bindingSource1
            // 
            this.bindingSource1.DataSource = typeof(MyCTS.Entities.CatBusinessUnits);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Blue;
            this.label1.Location = new System.Drawing.Point(0, 388);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(138, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Selecciona origen de Venta";
            // 
            // rdoEnterpricePolicy
            // 
            this.rdoEnterpricePolicy.AutoSize = true;
            this.rdoEnterpricePolicy.Location = new System.Drawing.Point(3, 3);
            this.rdoEnterpricePolicy.Name = "rdoEnterpricePolicy";
            this.rdoEnterpricePolicy.Size = new System.Drawing.Size(131, 17);
            this.rdoEnterpricePolicy.TabIndex = 3;
            this.rdoEnterpricePolicy.TabStop = true;
            this.rdoEnterpricePolicy.Text = "Política de la Empresa";
            this.rdoEnterpricePolicy.UseVisualStyleBackColor = true;
            this.rdoEnterpricePolicy.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgvJustifications_KeyDown);
            // 
            // rdoTouristBulletin
            // 
            this.rdoTouristBulletin.AutoSize = true;
            this.rdoTouristBulletin.Location = new System.Drawing.Point(3, 28);
            this.rdoTouristBulletin.Name = "rdoTouristBulletin";
            this.rdoTouristBulletin.Size = new System.Drawing.Size(144, 17);
            this.rdoTouristBulletin.TabIndex = 4;
            this.rdoTouristBulletin.TabStop = true;
            this.rdoTouristBulletin.Text = "Anuncio Boletín Turistico";
            this.rdoTouristBulletin.UseVisualStyleBackColor = true;
            this.rdoTouristBulletin.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgvJustifications_KeyDown);
            // 
            // rdoEmail
            // 
            this.rdoEmail.AutoSize = true;
            this.rdoEmail.Location = new System.Drawing.Point(3, 53);
            this.rdoEmail.Name = "rdoEmail";
            this.rdoEmail.Size = new System.Drawing.Size(112, 17);
            this.rdoEmail.TabIndex = 5;
            this.rdoEmail.TabStop = true;
            this.rdoEmail.Text = "Correo Electronico";
            this.rdoEmail.UseVisualStyleBackColor = true;
            this.rdoEmail.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgvJustifications_KeyDown);
            // 
            // rdoCustomerRecommendation
            // 
            this.rdoCustomerRecommendation.AutoSize = true;
            this.rdoCustomerRecommendation.Location = new System.Drawing.Point(3, 78);
            this.rdoCustomerRecommendation.Name = "rdoCustomerRecommendation";
            this.rdoCustomerRecommendation.Size = new System.Drawing.Size(137, 17);
            this.rdoCustomerRecommendation.TabIndex = 6;
            this.rdoCustomerRecommendation.TabStop = true;
            this.rdoCustomerRecommendation.Text = "Recomendación cliente";
            this.rdoCustomerRecommendation.UseVisualStyleBackColor = true;
            this.rdoCustomerRecommendation.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgvJustifications_KeyDown);
            // 
            // rdoHumanResources
            // 
            this.rdoHumanResources.AutoSize = true;
            this.rdoHumanResources.Location = new System.Drawing.Point(3, 103);
            this.rdoHumanResources.Name = "rdoHumanResources";
            this.rdoHumanResources.Size = new System.Drawing.Size(118, 17);
            this.rdoHumanResources.TabIndex = 7;
            this.rdoHumanResources.TabStop = true;
            this.rdoHumanResources.Text = "Recursos Humanos";
            this.rdoHumanResources.UseVisualStyleBackColor = true;
            this.rdoHumanResources.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgvJustifications_KeyDown);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 204F));
            this.tableLayoutPanel1.Controls.Add(this.rdoHumanResources, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.rdoTouristBulletin, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.rdoCustomerRecommendation, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.rdoEmail, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.rdoEnterpricePolicy, 0, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(6, 415);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 5;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(204, 125);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // ucBusinessUnit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblCTS);
            this.Controls.Add(this.btnAccept);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.dgvJustifications);
            this.Name = "ucBusinessUnit";
            this.Size = new System.Drawing.Size(411, 580);
            this.Load += new System.EventHandler(this.ucBusinessUnit_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvJustifications)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblCTS;
        private System.Windows.Forms.Button btnAccept;
        internal System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.DataGridView dgvJustifications;
        private System.Windows.Forms.BindingSource bindingSource1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton rdoEnterpricePolicy;
        private System.Windows.Forms.RadioButton rdoTouristBulletin;
        private System.Windows.Forms.RadioButton rdoEmail;
        private System.Windows.Forms.RadioButton rdoCustomerRecommendation;
        private System.Windows.Forms.RadioButton rdoHumanResources;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn pCCDataGridViewTextBoxColumn;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
    }
}
