namespace MyCTS.Presentation
{
    partial class ucPhaseIVSelectMask
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
            this.btnAccept = new System.Windows.Forms.Button();
            this.dgvSelectMask = new System.Windows.Forms.DataGridView();
            this.Number = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Mask = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblSelectMask = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSelectMask)).BeginInit();
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
            this.lblTitle.Size = new System.Drawing.Size(411, 15);
            this.lblTitle.TabIndex = 1;
            this.lblTitle.Text = "Fase IV - Selecciona Mascara";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // btnAccept
            // 
            this.btnAccept.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnAccept.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAccept.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAccept.Location = new System.Drawing.Point(287, 446);
            this.btnAccept.Name = "btnAccept";
            this.btnAccept.Size = new System.Drawing.Size(100, 23);
            this.btnAccept.TabIndex = 2;
            this.btnAccept.Text = "Aceptar";
            this.btnAccept.UseVisualStyleBackColor = false;
            this.btnAccept.Click += new System.EventHandler(this.btnAccept_Click);
            // 
            // dgvSelectMask
            // 
            this.dgvSelectMask.AllowUserToAddRows = false;
            this.dgvSelectMask.AllowUserToDeleteRows = false;
            this.dgvSelectMask.AllowUserToResizeRows = false;
            this.dgvSelectMask.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvSelectMask.BackgroundColor = System.Drawing.Color.FloralWhite;
            this.dgvSelectMask.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            this.dgvSelectMask.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvSelectMask.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Number,
            this.Mask});
            this.dgvSelectMask.EnableHeadersVisualStyles = false;
            this.dgvSelectMask.GridColor = System.Drawing.Color.White;
            this.dgvSelectMask.Location = new System.Drawing.Point(27, 67);
            this.dgvSelectMask.MultiSelect = false;
            this.dgvSelectMask.Name = "dgvSelectMask";
            this.dgvSelectMask.ReadOnly = true;
            this.dgvSelectMask.RowHeadersWidth = 21;
            this.dgvSelectMask.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgvSelectMask.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvSelectMask.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvSelectMask.Size = new System.Drawing.Size(331, 341);
            this.dgvSelectMask.StandardTab = true;
            this.dgvSelectMask.TabIndex = 1;
            this.dgvSelectMask.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvSelectMask_CellDoubleClick);
            this.dgvSelectMask.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // Number
            // 
            this.Number.Frozen = true;
            this.Number.HeaderText = "Número";
            this.Number.Name = "Number";
            this.Number.ReadOnly = true;
            this.Number.Width = 69;
            // 
            // Mask
            // 
            this.Mask.Frozen = true;
            this.Mask.HeaderText = "Mascara";
            this.Mask.Name = "Mask";
            this.Mask.ReadOnly = true;
            this.Mask.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Mask.Width = 73;
            // 
            // lblSelectMask
            // 
            this.lblSelectMask.AutoSize = true;
            this.lblSelectMask.Location = new System.Drawing.Point(24, 34);
            this.lblSelectMask.Name = "lblSelectMask";
            this.lblSelectMask.Size = new System.Drawing.Size(162, 13);
            this.lblSelectMask.TabIndex = 0;
            this.lblSelectMask.Text = "Seleccione la Mascara deseada:";
            // 
            // ucPhaseIVSelectMask
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.lblSelectMask);
            this.Controls.Add(this.dgvSelectMask);
            this.Controls.Add(this.btnAccept);
            this.Controls.Add(this.lblTitle);
            this.Name = "ucPhaseIVSelectMask";
            this.Size = new System.Drawing.Size(411, 580);
            this.Load += new System.EventHandler(this.ucPhaseIVSelectMask_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSelectMask)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Button btnAccept;
        private System.Windows.Forms.DataGridView dgvSelectMask;
        private System.Windows.Forms.Label lblSelectMask;
        private System.Windows.Forms.DataGridViewTextBoxColumn Number;
        private System.Windows.Forms.DataGridViewTextBoxColumn Mask;
    }
}
