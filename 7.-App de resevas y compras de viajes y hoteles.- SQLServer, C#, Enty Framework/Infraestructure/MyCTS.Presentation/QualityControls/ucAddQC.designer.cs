namespace MyCTS.Presentation
{
    partial class ucAddQC
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
            this.btnAccept = new System.Windows.Forms.Button();
            this.lblDescription = new System.Windows.Forms.Label();
            this.lblNumberLabel = new System.Windows.Forms.Label();
            this.txtDescription = new MyCTS.Forms.UI.SmartTextBox();
            this.txtNumberLabel = new MyCTS.Forms.UI.SmartTextBox();
            this.lblCtrlType = new System.Windows.Forms.Label();
            this.cmbCtrlType = new System.Windows.Forms.ComboBox();
            this.lblCtrlDescription = new System.Windows.Forms.Label();
            this.txtCtrlDescription = new MyCTS.Forms.UI.SmartTextBox();
            this.lblCtrlLen = new System.Windows.Forms.Label();
            this.txtCtrlLen = new MyCTS.Forms.UI.SmartTextBox();
            this.lblCtrlCurrentCriteria = new System.Windows.Forms.Label();
            this.cmbCtrlCurrentCriteria = new System.Windows.Forms.ComboBox();
            this.lblCatalogues = new System.Windows.Forms.Label();
            this.txtCtrlCatalogues = new MyCTS.Forms.UI.SmartTextBox();
            this.lblAllowInsertValues = new System.Windows.Forms.Label();
            this.cmbAllowInsertValues = new System.Windows.Forms.ComboBox();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.toolTip2 = new System.Windows.Forms.ToolTip(this.components);
            this.lblDescriptionGeneric = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
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
            this.lblTitle.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblTitle.Size = new System.Drawing.Size(411, 17);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Alta de Quality Controls ";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnAccept
            // 
            this.btnAccept.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnAccept.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAccept.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAccept.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAccept.Location = new System.Drawing.Point(253, 275);
            this.btnAccept.Name = "btnAccept";
            this.btnAccept.Size = new System.Drawing.Size(100, 23);
            this.btnAccept.TabIndex = 9;
            this.btnAccept.Text = "Aceptar";
            this.btnAccept.UseVisualStyleBackColor = false;
            this.btnAccept.Click += new System.EventHandler(this.btnAccept_Click);
            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.Location = new System.Drawing.Point(16, 40);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(62, 13);
            this.lblDescription.TabIndex = 0;
            this.lblDescription.Text = "Nombre QC";
            // 
            // lblNumberLabel
            // 
            this.lblNumberLabel.AutoSize = true;
            this.lblNumberLabel.Location = new System.Drawing.Point(16, 67);
            this.lblNumberLabel.Name = "lblNumberLabel";
            this.lblNumberLabel.Size = new System.Drawing.Size(86, 13);
            this.lblNumberLabel.TabIndex = 0;
            this.lblNumberLabel.Text = "Etiqueta Número";
            // 
            // txtDescription
            // 
            this.txtDescription.AllowBlankSpaces = true;
            this.txtDescription.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtDescription.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.AnyCharacter;
            this.txtDescription.CustomExpression = ".*";
            this.txtDescription.EnterColor = System.Drawing.Color.Empty;
            this.txtDescription.LeaveColor = System.Drawing.Color.Empty;
            this.txtDescription.Location = new System.Drawing.Point(111, 37);
            this.txtDescription.MaxLength = 50;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(121, 20);
            this.txtDescription.TabIndex = 1;
            this.txtDescription.Tag = "Nombre de QualityControls";
            this.txtDescription.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // txtNumberLabel
            // 
            this.txtNumberLabel.AllowBlankSpaces = true;
            this.txtNumberLabel.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtNumberLabel.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.AnyCharacter;
            this.txtNumberLabel.CustomExpression = ".*";
            this.txtNumberLabel.EnterColor = System.Drawing.Color.Empty;
            this.txtNumberLabel.LeaveColor = System.Drawing.Color.Empty;
            this.txtNumberLabel.Location = new System.Drawing.Point(111, 60);
            this.txtNumberLabel.MaxLength = 10;
            this.txtNumberLabel.Name = "txtNumberLabel";
            this.txtNumberLabel.Size = new System.Drawing.Size(87, 20);
            this.txtNumberLabel.TabIndex = 2;
            this.txtNumberLabel.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // lblCtrlType
            // 
            this.lblCtrlType.AutoSize = true;
            this.lblCtrlType.ForeColor = System.Drawing.Color.DarkCyan;
            this.lblCtrlType.Location = new System.Drawing.Point(16, 92);
            this.lblCtrlType.Name = "lblCtrlType";
            this.lblCtrlType.Size = new System.Drawing.Size(46, 13);
            this.lblCtrlType.TabIndex = 0;
            this.lblCtrlType.Text = "CtrlType";
            // 
            // cmbCtrlType
            // 
            this.cmbCtrlType.DisplayMember = "Text";
            this.cmbCtrlType.FormattingEnabled = true;
            this.cmbCtrlType.Items.AddRange(new object[] {
            ""});
            this.cmbCtrlType.Location = new System.Drawing.Point(111, 84);
            this.cmbCtrlType.Name = "cmbCtrlType";
            this.cmbCtrlType.Size = new System.Drawing.Size(121, 21);
            this.cmbCtrlType.TabIndex = 3;
            this.cmbCtrlType.ValueMember = "Value";
            this.cmbCtrlType.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // lblCtrlDescription
            // 
            this.lblCtrlDescription.AutoSize = true;
            this.lblCtrlDescription.ForeColor = System.Drawing.Color.Black;
            this.lblCtrlDescription.Location = new System.Drawing.Point(16, 118);
            this.lblCtrlDescription.Name = "lblCtrlDescription";
            this.lblCtrlDescription.Size = new System.Drawing.Size(75, 13);
            this.lblCtrlDescription.TabIndex = 0;
            this.lblCtrlDescription.Text = "CtrlDescription";
            // 
            // txtCtrlDescription
            // 
            this.txtCtrlDescription.AllowBlankSpaces = true;
            this.txtCtrlDescription.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtCtrlDescription.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.AnyCharacter;
            this.txtCtrlDescription.CustomExpression = ".*";
            this.txtCtrlDescription.EnterColor = System.Drawing.Color.Empty;
            this.txtCtrlDescription.LeaveColor = System.Drawing.Color.Empty;
            this.txtCtrlDescription.Location = new System.Drawing.Point(111, 111);
            this.txtCtrlDescription.MaxLength = 50;
            this.txtCtrlDescription.Name = "txtCtrlDescription";
            this.txtCtrlDescription.Size = new System.Drawing.Size(121, 20);
            this.txtCtrlDescription.TabIndex = 4;
            this.txtCtrlDescription.Tag = "Descripción de funcionalidad de QC";
            this.txtCtrlDescription.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // lblCtrlLen
            // 
            this.lblCtrlLen.AutoSize = true;
            this.lblCtrlLen.Location = new System.Drawing.Point(16, 145);
            this.lblCtrlLen.Name = "lblCtrlLen";
            this.lblCtrlLen.Size = new System.Drawing.Size(40, 13);
            this.lblCtrlLen.TabIndex = 0;
            this.lblCtrlLen.Text = "CtrlLen";
            // 
            // txtCtrlLen
            // 
            this.txtCtrlLen.AllowBlankSpaces = true;
            this.txtCtrlLen.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtCtrlLen.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.AnyCharacter;
            this.txtCtrlLen.CustomExpression = ".*";
            this.txtCtrlLen.EnterColor = System.Drawing.Color.Empty;
            this.txtCtrlLen.LeaveColor = System.Drawing.Color.Empty;
            this.txtCtrlLen.Location = new System.Drawing.Point(111, 138);
            this.txtCtrlLen.MaxLength = 10;
            this.txtCtrlLen.Name = "txtCtrlLen";
            this.txtCtrlLen.Size = new System.Drawing.Size(71, 20);
            this.txtCtrlLen.TabIndex = 5;
            this.txtCtrlLen.Text = "54";
            this.txtCtrlLen.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // lblCtrlCurrentCriteria
            // 
            this.lblCtrlCurrentCriteria.AutoSize = true;
            this.lblCtrlCurrentCriteria.Location = new System.Drawing.Point(16, 170);
            this.lblCtrlCurrentCriteria.Name = "lblCtrlCurrentCriteria";
            this.lblCtrlCurrentCriteria.Size = new System.Drawing.Size(88, 13);
            this.lblCtrlCurrentCriteria.TabIndex = 0;
            this.lblCtrlCurrentCriteria.Text = "CtrlCurrentCriteria";
            // 
            // cmbCtrlCurrentCriteria
            // 
            this.cmbCtrlCurrentCriteria.DisplayMember = "Text";
            this.cmbCtrlCurrentCriteria.FormattingEnabled = true;
            this.cmbCtrlCurrentCriteria.Items.AddRange(new object[] {
            ""});
            this.cmbCtrlCurrentCriteria.Location = new System.Drawing.Point(111, 162);
            this.cmbCtrlCurrentCriteria.Name = "cmbCtrlCurrentCriteria";
            this.cmbCtrlCurrentCriteria.Size = new System.Drawing.Size(121, 21);
            this.cmbCtrlCurrentCriteria.TabIndex = 6;
            this.cmbCtrlCurrentCriteria.ValueMember = "Value";
            this.cmbCtrlCurrentCriteria.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // lblCatalogues
            // 
            this.lblCatalogues.AutoSize = true;
            this.lblCatalogues.Location = new System.Drawing.Point(16, 195);
            this.lblCatalogues.Name = "lblCatalogues";
            this.lblCatalogues.Size = new System.Drawing.Size(75, 13);
            this.lblCatalogues.TabIndex = 0;
            this.lblCatalogues.Text = "CtrlCatalogues";
            // 
            // txtCtrlCatalogues
            // 
            this.txtCtrlCatalogues.AllowBlankSpaces = true;
            this.txtCtrlCatalogues.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtCtrlCatalogues.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.AnyCharacter;
            this.txtCtrlCatalogues.CustomExpression = ".*";
            this.txtCtrlCatalogues.EnterColor = System.Drawing.Color.Empty;
            this.txtCtrlCatalogues.LeaveColor = System.Drawing.Color.Empty;
            this.txtCtrlCatalogues.Location = new System.Drawing.Point(111, 192);
            this.txtCtrlCatalogues.MaxLength = 50;
            this.txtCtrlCatalogues.Name = "txtCtrlCatalogues";
            this.txtCtrlCatalogues.Size = new System.Drawing.Size(121, 20);
            this.txtCtrlCatalogues.TabIndex = 7;
            this.txtCtrlCatalogues.Text = "CLIENTSCATALOGS";
            this.txtCtrlCatalogues.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // lblAllowInsertValues
            // 
            this.lblAllowInsertValues.AutoSize = true;
            this.lblAllowInsertValues.Location = new System.Drawing.Point(16, 220);
            this.lblAllowInsertValues.Name = "lblAllowInsertValues";
            this.lblAllowInsertValues.Size = new System.Drawing.Size(90, 13);
            this.lblAllowInsertValues.TabIndex = 0;
            this.lblAllowInsertValues.Text = "AllowInsertValues";
            // 
            // cmbAllowInsertValues
            // 
            this.cmbAllowInsertValues.FormattingEnabled = true;
            this.cmbAllowInsertValues.Items.AddRange(new object[] {
            "",
            "True",
            "False"});
            this.cmbAllowInsertValues.Location = new System.Drawing.Point(111, 217);
            this.cmbAllowInsertValues.Name = "cmbAllowInsertValues";
            this.cmbAllowInsertValues.Size = new System.Drawing.Size(121, 21);
            this.cmbAllowInsertValues.TabIndex = 8;
            this.cmbAllowInsertValues.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            this.cmbAllowInsertValues.TextChanged += new System.EventHandler(this.cmbAllowInsertValues_TextChanged);
            // 
            // lblDescriptionGeneric
            // 
            this.lblDescriptionGeneric.AutoSize = true;
            this.lblDescriptionGeneric.ForeColor = System.Drawing.Color.Blue;
            this.lblDescriptionGeneric.Location = new System.Drawing.Point(16, 247);
            this.lblDescriptionGeneric.Name = "lblDescriptionGeneric";
            this.lblDescriptionGeneric.Size = new System.Drawing.Size(276, 13);
            this.lblDescriptionGeneric.TabIndex = 10;
            this.lblDescriptionGeneric.Text = "Tablas afectadas: LabelsRemarks y  QCControlsFeatures";
            // 
            // ucAddQC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.lblDescriptionGeneric);
            this.Controls.Add(this.cmbAllowInsertValues);
            this.Controls.Add(this.lblAllowInsertValues);
            this.Controls.Add(this.txtCtrlCatalogues);
            this.Controls.Add(this.lblCatalogues);
            this.Controls.Add(this.cmbCtrlCurrentCriteria);
            this.Controls.Add(this.lblCtrlCurrentCriteria);
            this.Controls.Add(this.txtCtrlLen);
            this.Controls.Add(this.lblCtrlLen);
            this.Controls.Add(this.txtCtrlDescription);
            this.Controls.Add(this.lblCtrlDescription);
            this.Controls.Add(this.cmbCtrlType);
            this.Controls.Add(this.lblCtrlType);
            this.Controls.Add(this.txtNumberLabel);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.lblNumberLabel);
            this.Controls.Add(this.lblDescription);
            this.Controls.Add(this.btnAccept);
            this.Controls.Add(this.lblTitle);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "ucAddQC";
            this.Size = new System.Drawing.Size(411, 580);
            this.Load += new System.EventHandler(this.AddQC_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Button btnAccept;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.Label lblNumberLabel;
        private MyCTS.Forms.UI.SmartTextBox txtDescription;
        private MyCTS.Forms.UI.SmartTextBox txtNumberLabel;
        private System.Windows.Forms.Label lblCtrlType;
        private System.Windows.Forms.ComboBox cmbCtrlType;
        private System.Windows.Forms.Label lblCtrlDescription;
        private MyCTS.Forms.UI.SmartTextBox txtCtrlDescription;
        private System.Windows.Forms.Label lblCtrlLen;
        private MyCTS.Forms.UI.SmartTextBox txtCtrlLen;
        private System.Windows.Forms.Label lblCtrlCurrentCriteria;
        private System.Windows.Forms.ComboBox cmbCtrlCurrentCriteria;
        private System.Windows.Forms.Label lblCatalogues;
        private MyCTS.Forms.UI.SmartTextBox txtCtrlCatalogues;
        private System.Windows.Forms.Label lblAllowInsertValues;
        private System.Windows.Forms.ComboBox cmbAllowInsertValues;
        private System.Windows.Forms.BindingSource bindingSource1;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.ToolTip toolTip2;
        private System.Windows.Forms.Label lblDescriptionGeneric;
    }
}
