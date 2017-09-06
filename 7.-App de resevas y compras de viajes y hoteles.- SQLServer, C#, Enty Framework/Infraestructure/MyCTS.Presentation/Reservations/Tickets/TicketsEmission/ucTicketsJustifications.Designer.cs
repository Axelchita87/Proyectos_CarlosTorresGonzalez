namespace MyCTS.Presentation
{
    partial class ucTicketsJustifications
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
            this.btnAccept = new System.Windows.Forms.Button();
            this.lblJustifications = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.dgvJustifications = new System.Windows.Forms.DataGridView();
            this.Code = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descriptionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.lblCTS = new System.Windows.Forms.Label();
            this.chkClass = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvJustifications)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnAccept
            // 
            this.btnAccept.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnAccept.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAccept.Location = new System.Drawing.Point(308, 519);
            this.btnAccept.Name = "btnAccept";
            this.btnAccept.Size = new System.Drawing.Size(100, 23);
            this.btnAccept.TabIndex = 7;
            this.btnAccept.Text = "Aceptar";
            this.btnAccept.UseVisualStyleBackColor = false;
            this.btnAccept.Click += new System.EventHandler(this.btnAccept_Click);
            // 
            // lblJustifications
            // 
            this.lblJustifications.AutoSize = true;
            this.lblJustifications.Location = new System.Drawing.Point(3, 54);
            this.lblJustifications.Name = "lblJustifications";
            this.lblJustifications.Size = new System.Drawing.Size(183, 13);
            this.lblJustifications.TabIndex = 6;
            this.lblJustifications.Text = "Selecciona la justificación adecuada:";
            this.lblJustifications.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblTitle
            // 
            this.lblTitle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(139)))), ((int)(((byte)(208)))));
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(0, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(411, 17);
            this.lblTitle.TabIndex = 4;
            this.lblTitle.Text = "Justificaciones de Tarifa ";
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
            this.Code,
            this.descriptionDataGridViewTextBoxColumn});
            this.dgvJustifications.DataSource = this.bindingSource1;
            this.dgvJustifications.EnableHeadersVisualStyles = false;
            this.dgvJustifications.GridColor = System.Drawing.Color.White;
            this.dgvJustifications.Location = new System.Drawing.Point(3, 70);
            this.dgvJustifications.MultiSelect = false;
            this.dgvJustifications.Name = "dgvJustifications";
            this.dgvJustifications.ReadOnly = true;
            this.dgvJustifications.RowHeadersWidth = 21;
            this.dgvJustifications.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgvJustifications.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvJustifications.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvJustifications.Size = new System.Drawing.Size(408, 443);
            this.dgvJustifications.TabIndex = 5;
            this.dgvJustifications.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvJustifications_CellDoubleClick);
            this.dgvJustifications.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgvJustifications_KeyDown);
            // 
            // Code
            // 
            this.Code.DataPropertyName = "Code";
            this.Code.Frozen = true;
            this.Code.HeaderText = "Código";
            this.Code.MaxInputLength = 2;
            this.Code.Name = "Code";
            this.Code.ReadOnly = true;
            this.Code.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Code.Width = 65;
            // 
            // descriptionDataGridViewTextBoxColumn
            // 
            this.descriptionDataGridViewTextBoxColumn.DataPropertyName = "Description";
            this.descriptionDataGridViewTextBoxColumn.HeaderText = "Descripción";
            this.descriptionDataGridViewTextBoxColumn.Name = "descriptionDataGridViewTextBoxColumn";
            this.descriptionDataGridViewTextBoxColumn.ReadOnly = true;
            this.descriptionDataGridViewTextBoxColumn.Width = 88;
            // 
            // bindingSource1
            // 
            this.bindingSource1.DataSource = typeof(MyCTS.Entities.DKTemp);
            // 
            // lblCTS
            // 
            this.lblCTS.AutoSize = true;
            this.lblCTS.ForeColor = System.Drawing.Color.Red;
            this.lblCTS.Location = new System.Drawing.Point(151, 31);
            this.lblCTS.Name = "lblCTS";
            this.lblCTS.Size = new System.Drawing.Size(100, 13);
            this.lblCTS.TabIndex = 0;
            this.lblCTS.Text = "Justificaciones CTS";
            // 
            // chkClass
            // 
            this.chkClass.AutoSize = true;
            this.chkClass.Checked = true;
            this.chkClass.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkClass.Location = new System.Drawing.Point(6, 519);
            this.chkClass.Name = "chkClass";
            this.chkClass.Size = new System.Drawing.Size(191, 17);
            this.chkClass.TabIndex = 8;
            this.chkClass.Text = "¿Es una clase Business o Primera?";
            this.chkClass.UseVisualStyleBackColor = true;
            this.chkClass.Visible = false;
            // 
            // ucTicketsJustifications
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.chkClass);
            this.Controls.Add(this.lblCTS);
            this.Controls.Add(this.btnAccept);
            this.Controls.Add(this.lblJustifications);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.dgvJustifications);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "ucTicketsJustifications";
            this.Size = new System.Drawing.Size(411, 580);
            this.Load += new System.EventHandler(this.ucTicketsJustifications_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvJustifications)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnAccept;
        private System.Windows.Forms.Label lblJustifications;
        internal System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.DataGridView dgvJustifications;
        private System.Windows.Forms.Label lblCTS;
        private System.Windows.Forms.CheckBox chkClass;
        private System.Windows.Forms.BindingSource bindingSource1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Code;
        private System.Windows.Forms.DataGridViewTextBoxColumn descriptionDataGridViewTextBoxColumn;
    }
}
