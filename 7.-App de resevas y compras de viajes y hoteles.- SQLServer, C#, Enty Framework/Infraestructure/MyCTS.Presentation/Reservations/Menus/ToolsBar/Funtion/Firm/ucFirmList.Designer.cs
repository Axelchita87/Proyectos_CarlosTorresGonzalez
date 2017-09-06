namespace MyCTS.Presentation
{
    partial class ucFirmList
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
            this.lblFirm = new System.Windows.Forms.Label();
            this.txtFirm = new MyCTS.Forms.UI.SmartTextBox();
            this.lblAgent = new System.Windows.Forms.Label();
            this.txtAgent = new MyCTS.Forms.UI.SmartTextBox();
            this.btnAccept = new System.Windows.Forms.Button();
            this.dgvFirm = new System.Windows.Forms.DataGridView();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.firmDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.agentDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.userNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.familyNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFirm)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(139)))), ((int)(((byte)(208)))));
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(-3, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(411, 17);
            this.lblTitle.TabIndex = 1;
            this.lblTitle.Text = "Lista de Firmas";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblFirm
            // 
            this.lblFirm.AutoSize = true;
            this.lblFirm.ForeColor = System.Drawing.Color.DarkCyan;
            this.lblFirm.Location = new System.Drawing.Point(33, 41);
            this.lblFirm.Name = "lblFirm";
            this.lblFirm.Size = new System.Drawing.Size(98, 13);
            this.lblFirm.TabIndex = 2;
            this.lblFirm.Text = "¿Buscar por Firma?";
            // 
            // txtFirm
            // 
            this.txtFirm.AllowBlankSpaces = true;
            this.txtFirm.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtFirm.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.OnlyNumbers;
            this.txtFirm.CustomExpression = ".*";
            this.txtFirm.EnterColor = System.Drawing.Color.Empty;
            this.txtFirm.LeaveColor = System.Drawing.Color.Empty;
            this.txtFirm.Location = new System.Drawing.Point(148, 38);
            this.txtFirm.MaxLength = 4;
            this.txtFirm.Name = "txtFirm";
            this.txtFirm.Size = new System.Drawing.Size(71, 20);
            this.txtFirm.TabIndex = 3;
            this.txtFirm.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // lblAgent
            // 
            this.lblAgent.AutoSize = true;
            this.lblAgent.ForeColor = System.Drawing.Color.DarkCyan;
            this.lblAgent.Location = new System.Drawing.Point(33, 64);
            this.lblAgent.Name = "lblAgent";
            this.lblAgent.Size = new System.Drawing.Size(107, 13);
            this.lblAgent.TabIndex = 4;
            this.lblAgent.Tag = "";
            this.lblAgent.Text = "¿Buscar por Agente?";
            // 
            // txtAgent
            // 
            this.txtAgent.AllowBlankSpaces = true;
            this.txtAgent.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtAgent.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.OnlyLetters;
            this.txtAgent.CustomExpression = ".*";
            this.txtAgent.EnterColor = System.Drawing.Color.Empty;
            this.txtAgent.LeaveColor = System.Drawing.Color.Empty;
            this.txtAgent.Location = new System.Drawing.Point(148, 64);
            this.txtAgent.MaxLength = 2;
            this.txtAgent.Name = "txtAgent";
            this.txtAgent.Size = new System.Drawing.Size(71, 20);
            this.txtAgent.TabIndex = 5;
            this.txtAgent.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // btnAccept
            // 
            this.btnAccept.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnAccept.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAccept.Location = new System.Drawing.Point(269, 100);
            this.btnAccept.Name = "btnAccept";
            this.btnAccept.Size = new System.Drawing.Size(100, 23);
            this.btnAccept.TabIndex = 26;
            this.btnAccept.Text = "Aceptar";
            this.btnAccept.UseVisualStyleBackColor = false;
            this.btnAccept.Click += new System.EventHandler(this.btnAccept_Click);
            // 
            // dgvFirm
            // 
            this.dgvFirm.AllowUserToAddRows = false;
            this.dgvFirm.AllowUserToDeleteRows = false;
            this.dgvFirm.AutoGenerateColumns = false;
            this.dgvFirm.BackgroundColor = System.Drawing.Color.FloralWhite;
            this.dgvFirm.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvFirm.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.firmDataGridViewTextBoxColumn,
            this.agentDataGridViewTextBoxColumn,
            this.userNameDataGridViewTextBoxColumn,
            this.familyNameDataGridViewTextBoxColumn});
            this.dgvFirm.DataSource = this.bindingSource1;
            this.dgvFirm.Location = new System.Drawing.Point(27, 158);
            this.dgvFirm.Name = "dgvFirm";
            this.dgvFirm.ReadOnly = true;
            this.dgvFirm.Size = new System.Drawing.Size(355, 396);
            this.dgvFirm.TabIndex = 27;
            this.dgvFirm.Visible = false;
            // 
            // bindingSource1
            // 
            this.bindingSource1.DataSource = typeof(MyCTS.Entities.UsersSelectByPCC);
            // 
            // firmDataGridViewTextBoxColumn
            // 
            this.firmDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.firmDataGridViewTextBoxColumn.DataPropertyName = "Firm";
            this.firmDataGridViewTextBoxColumn.HeaderText = "Firm";
            this.firmDataGridViewTextBoxColumn.Name = "firmDataGridViewTextBoxColumn";
            this.firmDataGridViewTextBoxColumn.ReadOnly = true;
            this.firmDataGridViewTextBoxColumn.Width = 51;
            // 
            // agentDataGridViewTextBoxColumn
            // 
            this.agentDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.agentDataGridViewTextBoxColumn.DataPropertyName = "Agent";
            this.agentDataGridViewTextBoxColumn.HeaderText = "Agent";
            this.agentDataGridViewTextBoxColumn.Name = "agentDataGridViewTextBoxColumn";
            this.agentDataGridViewTextBoxColumn.ReadOnly = true;
            this.agentDataGridViewTextBoxColumn.Width = 60;
            // 
            // userNameDataGridViewTextBoxColumn
            // 
            this.userNameDataGridViewTextBoxColumn.DataPropertyName = "UserName";
            this.userNameDataGridViewTextBoxColumn.HeaderText = "UserName";
            this.userNameDataGridViewTextBoxColumn.Name = "userNameDataGridViewTextBoxColumn";
            this.userNameDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // familyNameDataGridViewTextBoxColumn
            // 
            this.familyNameDataGridViewTextBoxColumn.DataPropertyName = "FamilyName";
            this.familyNameDataGridViewTextBoxColumn.HeaderText = "FamilyName";
            this.familyNameDataGridViewTextBoxColumn.Name = "familyNameDataGridViewTextBoxColumn";
            this.familyNameDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // ucFirmList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.dgvFirm);
            this.Controls.Add(this.btnAccept);
            this.Controls.Add(this.txtAgent);
            this.Controls.Add(this.lblAgent);
            this.Controls.Add(this.txtFirm);
            this.Controls.Add(this.lblFirm);
            this.Controls.Add(this.lblTitle);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "ucFirmList";
            this.Size = new System.Drawing.Size(411, 580);
            this.Load += new System.EventHandler(this.ucFirmList_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvFirm)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblFirm;
        private MyCTS.Forms.UI.SmartTextBox txtFirm;
        private System.Windows.Forms.Label lblAgent;
        private MyCTS.Forms.UI.SmartTextBox txtAgent;
        private System.Windows.Forms.Button btnAccept;
        private System.Windows.Forms.DataGridView dgvFirm;
        private System.Windows.Forms.BindingSource bindingSource1;
        private System.Windows.Forms.DataGridViewTextBoxColumn firmDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn agentDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn userNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn familyNameDataGridViewTextBoxColumn;
    }
}
