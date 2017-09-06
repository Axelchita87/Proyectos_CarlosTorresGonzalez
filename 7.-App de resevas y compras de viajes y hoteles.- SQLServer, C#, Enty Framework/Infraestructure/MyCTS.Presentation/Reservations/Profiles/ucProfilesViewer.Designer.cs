namespace MyCTS.Presentation
{
    partial class ucProfilesViewer
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblPCC = new System.Windows.Forms.Label();
            this.txtPCC = new MyCTS.Forms.UI.SmartTextBox();
            this.lbProfileInfo = new System.Windows.Forms.ListBox();
            this.dgvStar1List = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IsL2Exist = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.dgvStar2List = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblStar1Name = new System.Windows.Forms.Label();
            this.lblStar2Name = new System.Windows.Forms.Label();
            this.btnAccept = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStar1List)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStar2List)).BeginInit();
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
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Selecciona Perfil de Pasajero";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblPCC
            // 
            this.lblPCC.AutoSize = true;
            this.lblPCC.Location = new System.Drawing.Point(23, 31);
            this.lblPCC.Name = "lblPCC";
            this.lblPCC.Size = new System.Drawing.Size(69, 13);
            this.lblPCC.TabIndex = 0;
            this.lblPCC.Text = "Ingresa PCC:";
            // 
            // txtPCC
            // 
            this.txtPCC.AllowBlankSpaces = true;
            this.txtPCC.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtPCC.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.AnyCharacter;
            this.txtPCC.CustomExpression = ".*";
            this.txtPCC.EnterColor = System.Drawing.Color.Empty;
            this.txtPCC.LeaveColor = System.Drawing.Color.Empty;
            this.txtPCC.Location = new System.Drawing.Point(26, 47);
            this.txtPCC.MaxLength = 30;
            this.txtPCC.Name = "txtPCC";
            this.txtPCC.Size = new System.Drawing.Size(198, 20);
            this.txtPCC.TabIndex = 1;
            this.txtPCC.TextChanged += new System.EventHandler(this.txtPCC_TextChanged);
            // 
            // lbProfileInfo
            // 
            this.lbProfileInfo.DisplayMember = "Text";
            this.lbProfileInfo.FormattingEnabled = true;
            this.lbProfileInfo.HorizontalScrollbar = true;
            this.lbProfileInfo.Location = new System.Drawing.Point(26, 482);
            this.lbProfileInfo.Name = "lbProfileInfo";
            this.lbProfileInfo.Size = new System.Drawing.Size(195, 95);
            this.lbProfileInfo.TabIndex = 0;
            this.lbProfileInfo.ValueMember = "Value";
            // 
            // dgvStar1List
            // 
            this.dgvStar1List.AllowUserToAddRows = false;
            this.dgvStar1List.AllowUserToDeleteRows = false;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopLeft;
            dataGridViewCellStyle3.NullValue = null;
            this.dgvStar1List.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvStar1List.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvStar1List.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn3,
            this.IsL2Exist});
            this.dgvStar1List.Location = new System.Drawing.Point(26, 94);
            this.dgvStar1List.Name = "dgvStar1List";
            this.dgvStar1List.ReadOnly = true;
            this.dgvStar1List.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvStar1List.Size = new System.Drawing.Size(367, 175);
            this.dgvStar1List.StandardTab = true;
            this.dgvStar1List.TabIndex = 2;
            this.dgvStar1List.Enter += new System.EventHandler(this.dgvStarsList_Enter);
            this.dgvStar1List.MultiSelectChanged += new System.EventHandler(this.dgvStar1List_MultiSelectChanged);
            this.dgvStar1List.Leave += new System.EventHandler(this.dgvStarsList_Leave);
            this.dgvStar1List.SelectionChanged += new System.EventHandler(this.dgvStar1List_SelectionChanged);
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewTextBoxColumn3.HeaderText = "Nombre";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewTextBoxColumn3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn3.Width = 50;
            // 
            // IsL2Exist
            // 
            this.IsL2Exist.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopLeft;
            dataGridViewCellStyle4.NullValue = false;
            this.IsL2Exist.DefaultCellStyle = dataGridViewCellStyle4;
            this.IsL2Exist.HeaderText = "2do nivel";
            this.IsL2Exist.Name = "IsL2Exist";
            this.IsL2Exist.ReadOnly = true;
            this.IsL2Exist.Width = 56;
            // 
            // dgvStar2List
            // 
            this.dgvStar2List.AllowUserToAddRows = false;
            this.dgvStar2List.AllowUserToDeleteRows = false;
            this.dgvStar2List.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvStar2List.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn5});
            this.dgvStar2List.Location = new System.Drawing.Point(26, 304);
            this.dgvStar2List.Name = "dgvStar2List";
            this.dgvStar2List.ReadOnly = true;
            this.dgvStar2List.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvStar2List.Size = new System.Drawing.Size(367, 175);
            this.dgvStar2List.StandardTab = true;
            this.dgvStar2List.TabIndex = 3;
            this.dgvStar2List.Enter += new System.EventHandler(this.dgvStarsList_Enter);
            this.dgvStar2List.Leave += new System.EventHandler(this.dgvStarsList_Leave);
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dataGridViewTextBoxColumn5.HeaderText = "Nombre";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            this.dataGridViewTextBoxColumn5.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewTextBoxColumn5.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn5.Width = 50;
            // 
            // lblStar1Name
            // 
            this.lblStar1Name.AutoSize = true;
            this.lblStar1Name.Location = new System.Drawing.Point(23, 78);
            this.lblStar1Name.Name = "lblStar1Name";
            this.lblStar1Name.Size = new System.Drawing.Size(174, 13);
            this.lblStar1Name.TabIndex = 0;
            this.lblStar1Name.Text = "Selecciona Estrella de Primer Nivel:";
            // 
            // lblStar2Name
            // 
            this.lblStar2Name.AutoSize = true;
            this.lblStar2Name.ForeColor = System.Drawing.Color.DarkCyan;
            this.lblStar2Name.Location = new System.Drawing.Point(23, 288);
            this.lblStar2Name.Name = "lblStar2Name";
            this.lblStar2Name.Size = new System.Drawing.Size(191, 13);
            this.lblStar2Name.TabIndex = 0;
            this.lblStar2Name.Text = "Selecciona  Estrella de Segundo Nivel:";
            // 
            // btnAccept
            // 
            this.btnAccept.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnAccept.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAccept.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAccept.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAccept.ForeColor = System.Drawing.Color.Black;
            this.btnAccept.Location = new System.Drawing.Point(293, 512);
            this.btnAccept.Name = "btnAccept";
            this.btnAccept.Size = new System.Drawing.Size(100, 23);
            this.btnAccept.TabIndex = 4;
            this.btnAccept.Text = "Aceptar";
            this.btnAccept.UseVisualStyleBackColor = false;
            // 
            // ucProfilesViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.lbProfileInfo);
            this.Controls.Add(this.btnAccept);
            this.Controls.Add(this.lblStar2Name);
            this.Controls.Add(this.lblStar1Name);
            this.Controls.Add(this.dgvStar2List);
            this.Controls.Add(this.dgvStar1List);
            this.Controls.Add(this.lblPCC);
            this.Controls.Add(this.txtPCC);
            this.Controls.Add(this.lblTitle);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "ucProfilesViewer";
            this.Size = new System.Drawing.Size(411, 580);
            this.Load += new System.EventHandler(this.ucProfilesViewer_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvStar1List)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStar2List)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblPCC;
        private MyCTS.Forms.UI.SmartTextBox txtPCC;
        private System.Windows.Forms.ListBox lbProfileInfo;
        private System.Windows.Forms.DataGridView dgvStar1List;
        private System.Windows.Forms.DataGridView dgvStar2List;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.Label lblStar1Name;
        private System.Windows.Forms.Label lblStar2Name;
        private System.Windows.Forms.Button btnAccept;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewCheckBoxColumn IsL2Exist;
    }
}
