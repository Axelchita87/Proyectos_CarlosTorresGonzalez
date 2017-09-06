namespace MyCTS.Presentation
{
    partial class ucConsultingAirPorts
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
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblCodeAirPort = new System.Windows.Forms.Label();
            this.lblCodeCountry = new System.Windows.Forms.Label();
            this.txtCodeAirPort = new MyCTS.Forms.UI.SmartTextBox();
            this.txtCodeCountry = new MyCTS.Forms.UI.SmartTextBox();
            this.btnAccept = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.catCitIdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.catCitNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.catCouIdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.catCouNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(139)))), ((int)(((byte)(208)))));
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(3, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(405, 18);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Consulta de Aeropuerto";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblCodeAirPort
            // 
            this.lblCodeAirPort.AutoSize = true;
            this.lblCodeAirPort.Location = new System.Drawing.Point(6, 41);
            this.lblCodeAirPort.Name = "lblCodeAirPort";
            this.lblCodeAirPort.Size = new System.Drawing.Size(110, 13);
            this.lblCodeAirPort.TabIndex = 0;
            this.lblCodeAirPort.Text = "Por Código de Ciudad";
            // 
            // lblCodeCountry
            // 
            this.lblCodeCountry.AutoSize = true;
            this.lblCodeCountry.Location = new System.Drawing.Point(9, 71);
            this.lblCodeCountry.Name = "lblCodeCountry";
            this.lblCodeCountry.Size = new System.Drawing.Size(102, 13);
            this.lblCodeCountry.TabIndex = 0;
            this.lblCodeCountry.Text = "Por Código de País:";
            // 
            // txtCodeAirPort
            // 
            this.txtCodeAirPort.AllowBlankSpaces = true;
            this.txtCodeAirPort.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtCodeAirPort.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.OnlyLetters;
            this.txtCodeAirPort.CustomExpression = ".*";
            this.txtCodeAirPort.EnterColor = System.Drawing.Color.Empty;
            this.txtCodeAirPort.LeaveColor = System.Drawing.Color.Empty;
            this.txtCodeAirPort.Location = new System.Drawing.Point(145, 41);
            this.txtCodeAirPort.MaxLength = 3;
            this.txtCodeAirPort.Name = "txtCodeAirPort";
            this.txtCodeAirPort.Size = new System.Drawing.Size(44, 20);
            this.txtCodeAirPort.TabIndex = 1;
            this.txtCodeAirPort.TextChanged += new System.EventHandler(this.txtCodeAirport_TextChanged);
            this.txtCodeAirPort.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // txtCodeCountry
            // 
            this.txtCodeCountry.AllowBlankSpaces = true;
            this.txtCodeCountry.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtCodeCountry.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.OnlyLetters;
            this.txtCodeCountry.CustomExpression = ".*";
            this.txtCodeCountry.EnterColor = System.Drawing.Color.Empty;
            this.txtCodeCountry.LeaveColor = System.Drawing.Color.Empty;
            this.txtCodeCountry.Location = new System.Drawing.Point(145, 68);
            this.txtCodeCountry.MaxLength = 2;
            this.txtCodeCountry.Name = "txtCodeCountry";
            this.txtCodeCountry.Size = new System.Drawing.Size(35, 20);
            this.txtCodeCountry.TabIndex = 2;
            this.txtCodeCountry.TextChanged += new System.EventHandler(this.txtCountryAirport_TextChanged);
            this.txtCodeCountry.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // btnAccept
            // 
            this.btnAccept.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnAccept.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAccept.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAccept.Location = new System.Drawing.Point(249, 104);
            this.btnAccept.Name = "btnAccept";
            this.btnAccept.Size = new System.Drawing.Size(100, 24);
            this.btnAccept.TabIndex = 3;
            this.btnAccept.Text = "Aceptar";
            this.btnAccept.UseVisualStyleBackColor = false;
            this.btnAccept.Click += new System.EventHandler(this.btnAccept_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.MistyRose;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.catCitIdDataGridViewTextBoxColumn,
            this.catCitNameDataGridViewTextBoxColumn,
            this.catCouIdDataGridViewTextBoxColumn,
            this.catCouNameDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.bindingSource1;
            this.dataGridView1.GridColor = System.Drawing.Color.MistyRose;
            this.dataGridView1.Location = new System.Drawing.Point(24, 151);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(358, 405);
            this.dataGridView1.TabIndex = 4;
            this.dataGridView1.Visible = false;
            // 
            // catCitIdDataGridViewTextBoxColumn
            // 
            this.catCitIdDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.catCitIdDataGridViewTextBoxColumn.DataPropertyName = "CatCitId";
            this.catCitIdDataGridViewTextBoxColumn.HeaderText = "CatCitId";
            this.catCitIdDataGridViewTextBoxColumn.Name = "catCitIdDataGridViewTextBoxColumn";
            this.catCitIdDataGridViewTextBoxColumn.ReadOnly = true;
            this.catCitIdDataGridViewTextBoxColumn.Width = 69;
            // 
            // catCitNameDataGridViewTextBoxColumn
            // 
            this.catCitNameDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.catCitNameDataGridViewTextBoxColumn.DataPropertyName = "CatCitName";
            this.catCitNameDataGridViewTextBoxColumn.HeaderText = "CatCitName";
            this.catCitNameDataGridViewTextBoxColumn.Name = "catCitNameDataGridViewTextBoxColumn";
            this.catCitNameDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // catCouIdDataGridViewTextBoxColumn
            // 
            this.catCouIdDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.catCouIdDataGridViewTextBoxColumn.DataPropertyName = "CatCouId";
            this.catCouIdDataGridViewTextBoxColumn.HeaderText = "CatCouId";
            this.catCouIdDataGridViewTextBoxColumn.Name = "catCouIdDataGridViewTextBoxColumn";
            this.catCouIdDataGridViewTextBoxColumn.ReadOnly = true;
            this.catCouIdDataGridViewTextBoxColumn.Width = 76;
            // 
            // catCouNameDataGridViewTextBoxColumn
            // 
            this.catCouNameDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.catCouNameDataGridViewTextBoxColumn.DataPropertyName = "CatCouName";
            this.catCouNameDataGridViewTextBoxColumn.HeaderText = "CatCouName";
            this.catCouNameDataGridViewTextBoxColumn.Name = "catCouNameDataGridViewTextBoxColumn";
            this.catCouNameDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // bindingSource1
            // 
            this.bindingSource1.DataSource = typeof(MyCTS.Entities.AirPorts);
            // 
            // ucConsultingAirPorts
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.btnAccept);
            this.Controls.Add(this.txtCodeCountry);
            this.Controls.Add(this.txtCodeAirPort);
            this.Controls.Add(this.lblCodeCountry);
            this.Controls.Add(this.lblCodeAirPort);
            this.Controls.Add(this.lblTitle);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "ucConsultingAirPorts";
            this.Size = new System.Drawing.Size(411, 580);
            this.Load += new System.EventHandler(this.ucConsultingAirPorts_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblCodeAirPort;
        private System.Windows.Forms.Label lblCodeCountry;
        private MyCTS.Forms.UI.SmartTextBox txtCodeAirPort;
        private MyCTS.Forms.UI.SmartTextBox txtCodeCountry;
        private System.Windows.Forms.Button btnAccept;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.BindingSource bindingSource1;
        private System.Windows.Forms.DataGridViewTextBoxColumn catCitIdDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn catCitNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn catCouIdDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn catCouNameDataGridViewTextBoxColumn;
    }
}
