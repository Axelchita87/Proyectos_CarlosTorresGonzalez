namespace MyCTS.Presentation
{
    partial class ucJustifications
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.dgvJustifications = new System.Windows.Forms.DataGridView();
            this.Code = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descriptionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblJustifications = new System.Windows.Forms.Label();
            this.btnAccept = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvJustifications)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            this.SuspendLayout();
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
            this.dgvJustifications.Location = new System.Drawing.Point(0, 42);
            this.dgvJustifications.MultiSelect = false;
            this.dgvJustifications.Name = "dgvJustifications";
            this.dgvJustifications.ReadOnly = true;
            this.dgvJustifications.RowHeadersWidth = 21;
            this.dgvJustifications.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgvJustifications.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvJustifications.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvJustifications.Size = new System.Drawing.Size(408, 230);
            this.dgvJustifications.TabIndex = 0;
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
            this.descriptionDataGridViewTextBoxColumn.Frozen = true;
            this.descriptionDataGridViewTextBoxColumn.HeaderText = "Descripción";
            this.descriptionDataGridViewTextBoxColumn.MaxInputLength = 700;
            this.descriptionDataGridViewTextBoxColumn.Name = "descriptionDataGridViewTextBoxColumn";
            this.descriptionDataGridViewTextBoxColumn.ReadOnly = true;
            this.descriptionDataGridViewTextBoxColumn.Width = 88;
            // 
            // bindingSource1
            // 
            this.bindingSource1.DataSource = typeof(MyCTS.Entities.DKTemp);
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
            this.lblTitle.Text = "Justificaciones";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblJustifications
            // 
            this.lblJustifications.AutoSize = true;
            this.lblJustifications.Location = new System.Drawing.Point(0, 26);
            this.lblJustifications.Name = "lblJustifications";
            this.lblJustifications.Size = new System.Drawing.Size(183, 13);
            this.lblJustifications.TabIndex = 0;
            this.lblJustifications.Text = "Selecciona la justificación adecuada:";
            this.lblJustifications.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnAccept
            // 
            this.btnAccept.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnAccept.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAccept.Location = new System.Drawing.Point(308, 278);
            this.btnAccept.Name = "btnAccept";
            this.btnAccept.Size = new System.Drawing.Size(100, 23);
            this.btnAccept.TabIndex = 3;
            this.btnAccept.Text = "Aceptar";
            this.btnAccept.UseVisualStyleBackColor = false;
            this.btnAccept.Click += new System.EventHandler(this.btnAccept_Click);
            // 
            // ucJustifications
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.btnAccept);
            this.Controls.Add(this.lblJustifications);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.dgvJustifications);
            this.Name = "ucJustifications";
            this.Size = new System.Drawing.Size(411, 580);
            this.Load += new System.EventHandler(this.ucJustifications_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvJustifications)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvJustifications;
        private System.Windows.Forms.BindingSource bindingSource1;
        //private System.Windows.Forms.DataGridViewTextBoxColumn justificationIDDataGridViewTextBoxColumn;
        internal System.Windows.Forms.Label lblTitle;
       private System.Windows.Forms.Label lblJustifications;
       private System.Windows.Forms.DataGridViewTextBoxColumn Code;
       private System.Windows.Forms.DataGridViewTextBoxColumn descriptionDataGridViewTextBoxColumn;
        private System.Windows.Forms.Button btnAccept; 
       
    }
}
