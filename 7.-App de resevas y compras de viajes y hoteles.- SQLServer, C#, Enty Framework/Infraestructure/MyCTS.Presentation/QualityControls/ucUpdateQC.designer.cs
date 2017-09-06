namespace MyCTS.Presentation
{
    partial class ucUpdateQC
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
            this.cmbAllowInsertValues = new System.Windows.Forms.ComboBox();
            this.lblAllowInsertValues = new System.Windows.Forms.Label();
            this.txtCtrlCatalogues = new MyCTS.Forms.UI.SmartTextBox();
            this.lblCatalogues = new System.Windows.Forms.Label();
            this.cmbCtrlCurrentCriteria = new System.Windows.Forms.ComboBox();
            this.lblCtrlCurrentCriteria = new System.Windows.Forms.Label();
            this.txtCtrlLen = new MyCTS.Forms.UI.SmartTextBox();
            this.lblCtrlLen = new System.Windows.Forms.Label();
            this.txtCtrlDescription = new MyCTS.Forms.UI.SmartTextBox();
            this.lblCtrlDescription = new System.Windows.Forms.Label();
            this.cmbCtrlType = new System.Windows.Forms.ComboBox();
            this.lblCtrlType = new System.Windows.Forms.Label();
            this.txtNumberLabel = new MyCTS.Forms.UI.SmartTextBox();
            this.txtDescription = new MyCTS.Forms.UI.SmartTextBox();
            this.lblNumberLabel = new System.Windows.Forms.Label();
            this.lblDescription = new System.Windows.Forms.Label();
            this.btnAccept = new System.Windows.Forms.Button();
            this.lblTitle = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.rdoSearch = new System.Windows.Forms.RadioButton();
            this.rdoUpdate = new System.Windows.Forms.RadioButton();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.toolTip2 = new System.Windows.Forms.ToolTip(this.components);
            this.lblGenericDescription = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // cmbAllowInsertValues
            // 
            this.cmbAllowInsertValues.FormattingEnabled = true;
            this.cmbAllowInsertValues.Items.AddRange(new object[] {
            "",
            "True",
            "False"});
            this.cmbAllowInsertValues.Location = new System.Drawing.Point(110, 240);
            this.cmbAllowInsertValues.Name = "cmbAllowInsertValues";
            this.cmbAllowInsertValues.Size = new System.Drawing.Size(121, 21);
            this.cmbAllowInsertValues.TabIndex = 10;
            this.cmbAllowInsertValues.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // lblAllowInsertValues
            // 
            this.lblAllowInsertValues.AutoSize = true;
            this.lblAllowInsertValues.Location = new System.Drawing.Point(15, 243);
            this.lblAllowInsertValues.Name = "lblAllowInsertValues";
            this.lblAllowInsertValues.Size = new System.Drawing.Size(90, 13);
            this.lblAllowInsertValues.TabIndex = 0;
            this.lblAllowInsertValues.Text = "AllowInsertValues";
            // 
            // txtCtrlCatalogues
            // 
            this.txtCtrlCatalogues.AllowBlankSpaces = true;
            this.txtCtrlCatalogues.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtCtrlCatalogues.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.AnyCharacter;
            this.txtCtrlCatalogues.CustomExpression = ".*";
            this.txtCtrlCatalogues.EnterColor = System.Drawing.Color.Empty;
            this.txtCtrlCatalogues.LeaveColor = System.Drawing.Color.Empty;
            this.txtCtrlCatalogues.Location = new System.Drawing.Point(110, 215);
            this.txtCtrlCatalogues.MaxLength = 50;
            this.txtCtrlCatalogues.Name = "txtCtrlCatalogues";
            this.txtCtrlCatalogues.Size = new System.Drawing.Size(121, 20);
            this.txtCtrlCatalogues.TabIndex = 9;
            this.txtCtrlCatalogues.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // lblCatalogues
            // 
            this.lblCatalogues.AutoSize = true;
            this.lblCatalogues.Location = new System.Drawing.Point(15, 218);
            this.lblCatalogues.Name = "lblCatalogues";
            this.lblCatalogues.Size = new System.Drawing.Size(75, 13);
            this.lblCatalogues.TabIndex = 0;
            this.lblCatalogues.Text = "CtrlCatalogues";
            // 
            // cmbCtrlCurrentCriteria
            // 
            this.cmbCtrlCurrentCriteria.DisplayMember = "Text";
            this.cmbCtrlCurrentCriteria.FormattingEnabled = true;
            this.cmbCtrlCurrentCriteria.Items.AddRange(new object[] {
            ""});
            this.cmbCtrlCurrentCriteria.Location = new System.Drawing.Point(110, 185);
            this.cmbCtrlCurrentCriteria.Name = "cmbCtrlCurrentCriteria";
            this.cmbCtrlCurrentCriteria.Size = new System.Drawing.Size(121, 21);
            this.cmbCtrlCurrentCriteria.TabIndex = 8;
            this.cmbCtrlCurrentCriteria.ValueMember = "Value";
            this.cmbCtrlCurrentCriteria.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // lblCtrlCurrentCriteria
            // 
            this.lblCtrlCurrentCriteria.AutoSize = true;
            this.lblCtrlCurrentCriteria.Location = new System.Drawing.Point(15, 193);
            this.lblCtrlCurrentCriteria.Name = "lblCtrlCurrentCriteria";
            this.lblCtrlCurrentCriteria.Size = new System.Drawing.Size(88, 13);
            this.lblCtrlCurrentCriteria.TabIndex = 0;
            this.lblCtrlCurrentCriteria.Text = "CtrlCurrentCriteria";
            // 
            // txtCtrlLen
            // 
            this.txtCtrlLen.AllowBlankSpaces = true;
            this.txtCtrlLen.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtCtrlLen.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.AnyCharacter;
            this.txtCtrlLen.CustomExpression = ".*";
            this.txtCtrlLen.EnterColor = System.Drawing.Color.Empty;
            this.txtCtrlLen.LeaveColor = System.Drawing.Color.Empty;
            this.txtCtrlLen.Location = new System.Drawing.Point(110, 161);
            this.txtCtrlLen.MaxLength = 10;
            this.txtCtrlLen.Name = "txtCtrlLen";
            this.txtCtrlLen.Size = new System.Drawing.Size(71, 20);
            this.txtCtrlLen.TabIndex = 7;
            this.txtCtrlLen.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // lblCtrlLen
            // 
            this.lblCtrlLen.AutoSize = true;
            this.lblCtrlLen.Location = new System.Drawing.Point(15, 168);
            this.lblCtrlLen.Name = "lblCtrlLen";
            this.lblCtrlLen.Size = new System.Drawing.Size(40, 13);
            this.lblCtrlLen.TabIndex = 0;
            this.lblCtrlLen.Text = "CtrlLen";
            // 
            // txtCtrlDescription
            // 
            this.txtCtrlDescription.AllowBlankSpaces = true;
            this.txtCtrlDescription.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtCtrlDescription.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.AnyCharacter;
            this.txtCtrlDescription.CustomExpression = ".*";
            this.txtCtrlDescription.EnterColor = System.Drawing.Color.Empty;
            this.txtCtrlDescription.LeaveColor = System.Drawing.Color.Empty;
            this.txtCtrlDescription.Location = new System.Drawing.Point(110, 134);
            this.txtCtrlDescription.MaxLength = 50;
            this.txtCtrlDescription.Name = "txtCtrlDescription";
            this.txtCtrlDescription.Size = new System.Drawing.Size(121, 20);
            this.txtCtrlDescription.TabIndex = 6;
            this.txtCtrlDescription.Tag = "Descripción de funcionalidad de QC";
            this.txtCtrlDescription.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // lblCtrlDescription
            // 
            this.lblCtrlDescription.AutoSize = true;
            this.lblCtrlDescription.ForeColor = System.Drawing.Color.Black;
            this.lblCtrlDescription.Location = new System.Drawing.Point(15, 141);
            this.lblCtrlDescription.Name = "lblCtrlDescription";
            this.lblCtrlDescription.Size = new System.Drawing.Size(75, 13);
            this.lblCtrlDescription.TabIndex = 0;
            this.lblCtrlDescription.Text = "CtrlDescription";
            // 
            // cmbCtrlType
            // 
            this.cmbCtrlType.DisplayMember = "Text";
            this.cmbCtrlType.FormattingEnabled = true;
            this.cmbCtrlType.Items.AddRange(new object[] {
            ""});
            this.cmbCtrlType.Location = new System.Drawing.Point(110, 107);
            this.cmbCtrlType.Name = "cmbCtrlType";
            this.cmbCtrlType.Size = new System.Drawing.Size(121, 21);
            this.cmbCtrlType.TabIndex = 5;
            this.cmbCtrlType.ValueMember = "Value";
            this.cmbCtrlType.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // lblCtrlType
            // 
            this.lblCtrlType.AutoSize = true;
            this.lblCtrlType.ForeColor = System.Drawing.Color.DarkCyan;
            this.lblCtrlType.Location = new System.Drawing.Point(15, 115);
            this.lblCtrlType.Name = "lblCtrlType";
            this.lblCtrlType.Size = new System.Drawing.Size(46, 13);
            this.lblCtrlType.TabIndex = 0;
            this.lblCtrlType.Text = "CtrlType";
            // 
            // txtNumberLabel
            // 
            this.txtNumberLabel.AllowBlankSpaces = true;
            this.txtNumberLabel.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtNumberLabel.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.AnyCharacter;
            this.txtNumberLabel.CustomExpression = ".*";
            this.txtNumberLabel.EnterColor = System.Drawing.Color.Empty;
            this.txtNumberLabel.LeaveColor = System.Drawing.Color.Empty;
            this.txtNumberLabel.Location = new System.Drawing.Point(110, 55);
            this.txtNumberLabel.MaxLength = 10;
            this.txtNumberLabel.Name = "txtNumberLabel";
            this.txtNumberLabel.Size = new System.Drawing.Size(87, 20);
            this.txtNumberLabel.TabIndex = 3;
            this.txtNumberLabel.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // txtDescription
            // 
            this.txtDescription.AllowBlankSpaces = true;
            this.txtDescription.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtDescription.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.AnyCharacter;
            this.txtDescription.CustomExpression = ".*";
            this.txtDescription.EnterColor = System.Drawing.Color.Empty;
            this.txtDescription.LeaveColor = System.Drawing.Color.Empty;
            this.txtDescription.Location = new System.Drawing.Point(110, 82);
            this.txtDescription.MaxLength = 50;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(121, 20);
            this.txtDescription.TabIndex = 4;
            this.txtDescription.Tag = "Nombre de QualityControls";
            this.txtDescription.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // lblNumberLabel
            // 
            this.lblNumberLabel.AutoSize = true;
            this.lblNumberLabel.Location = new System.Drawing.Point(15, 62);
            this.lblNumberLabel.Name = "lblNumberLabel";
            this.lblNumberLabel.Size = new System.Drawing.Size(86, 13);
            this.lblNumberLabel.TabIndex = 0;
            this.lblNumberLabel.Text = "Etiqueta Número";
            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.Location = new System.Drawing.Point(15, 85);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(62, 13);
            this.lblDescription.TabIndex = 0;
            this.lblDescription.Text = "Nombre QC";
            // 
            // btnAccept
            // 
            this.btnAccept.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnAccept.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAccept.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAccept.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAccept.Location = new System.Drawing.Point(250, 301);
            this.btnAccept.Name = "btnAccept";
            this.btnAccept.Size = new System.Drawing.Size(100, 23);
            this.btnAccept.TabIndex = 11;
            this.btnAccept.Text = "Aceptar";
            this.btnAccept.UseVisualStyleBackColor = false;
            this.btnAccept.Click += new System.EventHandler(this.btnAccept_Click);
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
            this.lblTitle.Text = "Modificación de Quality Controls ";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(106, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "¿Que deseas hacer?";
            // 
            // rdoSearch
            // 
            this.rdoSearch.AutoSize = true;
            this.rdoSearch.Location = new System.Drawing.Point(140, 33);
            this.rdoSearch.Name = "rdoSearch";
            this.rdoSearch.Size = new System.Drawing.Size(73, 17);
            this.rdoSearch.TabIndex = 1;
            this.rdoSearch.TabStop = true;
            this.rdoSearch.Text = "Busqueda";
            this.rdoSearch.UseVisualStyleBackColor = true;
            this.rdoSearch.CheckedChanged += new System.EventHandler(this.rdoSearch_CheckedChanged);
            this.rdoSearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // rdoUpdate
            // 
            this.rdoUpdate.AutoSize = true;
            this.rdoUpdate.Location = new System.Drawing.Point(235, 33);
            this.rdoUpdate.Name = "rdoUpdate";
            this.rdoUpdate.Size = new System.Drawing.Size(68, 17);
            this.rdoUpdate.TabIndex = 2;
            this.rdoUpdate.TabStop = true;
            this.rdoUpdate.Text = "Modificar";
            this.rdoUpdate.UseVisualStyleBackColor = true;
            this.rdoUpdate.CheckedChanged += new System.EventHandler(this.rdoUpdate_CheckedChanged);
            this.rdoUpdate.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // lblGenericDescription
            // 
            this.lblGenericDescription.AutoSize = true;
            this.lblGenericDescription.ForeColor = System.Drawing.Color.Blue;
            this.lblGenericDescription.Location = new System.Drawing.Point(18, 272);
            this.lblGenericDescription.Name = "lblGenericDescription";
            this.lblGenericDescription.Size = new System.Drawing.Size(273, 13);
            this.lblGenericDescription.TabIndex = 12;
            this.lblGenericDescription.Text = "Tablas afectadas: LabelsRemarks y QCControlsFeatures";
            // 
            // ucUpdateQC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.lblGenericDescription);
            this.Controls.Add(this.rdoUpdate);
            this.Controls.Add(this.rdoSearch);
            this.Controls.Add(this.label1);
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
            this.Name = "ucUpdateQC";
            this.Size = new System.Drawing.Size(411, 580);
            this.Load += new System.EventHandler(this.ucUpdateQC_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbAllowInsertValues;
        private System.Windows.Forms.Label lblAllowInsertValues;
        private MyCTS.Forms.UI.SmartTextBox txtCtrlCatalogues;
        private System.Windows.Forms.Label lblCatalogues;
        private System.Windows.Forms.ComboBox cmbCtrlCurrentCriteria;
        private System.Windows.Forms.Label lblCtrlCurrentCriteria;
        private MyCTS.Forms.UI.SmartTextBox txtCtrlLen;
        private System.Windows.Forms.Label lblCtrlLen;
        private MyCTS.Forms.UI.SmartTextBox txtCtrlDescription;
        private System.Windows.Forms.Label lblCtrlDescription;
        private System.Windows.Forms.ComboBox cmbCtrlType;
        private System.Windows.Forms.Label lblCtrlType;
        private MyCTS.Forms.UI.SmartTextBox txtNumberLabel;
        private MyCTS.Forms.UI.SmartTextBox txtDescription;
        private System.Windows.Forms.Label lblNumberLabel;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.Button btnAccept;
        internal System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton rdoSearch;
        private System.Windows.Forms.RadioButton rdoUpdate;
        private System.Windows.Forms.BindingSource bindingSource1;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.ToolTip toolTip2;
        private System.Windows.Forms.Label lblGenericDescription;
    }
}
