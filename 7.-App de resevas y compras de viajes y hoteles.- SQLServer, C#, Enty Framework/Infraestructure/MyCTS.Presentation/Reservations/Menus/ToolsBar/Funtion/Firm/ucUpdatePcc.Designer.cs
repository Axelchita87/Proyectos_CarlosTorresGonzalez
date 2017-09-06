namespace MyCTS.Presentation
{
    partial class ucUpdatePcc
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
            this.cmbType = new System.Windows.Forms.ComboBox();
            this.btnAccept = new System.Windows.Forms.Button();
            this.lblApplication = new System.Windows.Forms.Label();
            this.txtPCC = new MyCTS.Forms.UI.SmartTextBox();
            this.lblPCC = new System.Windows.Forms.Label();
            this.txtName = new MyCTS.Forms.UI.SmartTextBox();
            this.lblInfo = new System.Windows.Forms.Label();
            this.lbPCC = new System.Windows.Forms.ListBox();
            this.TypeBox = new System.Windows.Forms.ComboBox();
            this.ToolBox = new System.Windows.Forms.ComboBox();
            this.GDSBox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
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
            this.lblTitle.TabIndex = 6;
            this.lblTitle.Text = "Actualizar Pcc";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cmbType
            // 
            this.cmbType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbType.FormattingEnabled = true;
            this.cmbType.Items.AddRange(new object[] {
            "CTS",
            "CONSOLID"});
            this.cmbType.Location = new System.Drawing.Point(113, 165);
            this.cmbType.Name = "cmbType";
            this.cmbType.Size = new System.Drawing.Size(132, 21);
            this.cmbType.TabIndex = 37;
            this.cmbType.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // btnAccept
            // 
            this.btnAccept.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnAccept.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAccept.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAccept.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAccept.Location = new System.Drawing.Point(255, 379);
            this.btnAccept.Name = "btnAccept";
            this.btnAccept.Size = new System.Drawing.Size(100, 23);
            this.btnAccept.TabIndex = 38;
            this.btnAccept.Text = "Aceptar";
            this.btnAccept.UseVisualStyleBackColor = false;
            this.btnAccept.Click += new System.EventHandler(this.btnAccept_Click);
            this.btnAccept.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // lblApplication
            // 
            this.lblApplication.AutoSize = true;
            this.lblApplication.Location = new System.Drawing.Point(45, 168);
            this.lblApplication.Name = "lblApplication";
            this.lblApplication.Size = new System.Drawing.Size(48, 13);
            this.lblApplication.TabIndex = 41;
            this.lblApplication.Text = "Empresa";
            // 
            // txtPCC
            // 
            this.txtPCC.AllowBlankSpaces = false;
            this.txtPCC.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtPCC.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.NumbersOrLetters;
            this.txtPCC.CustomExpression = ".*";
            this.txtPCC.EnterColor = System.Drawing.Color.Empty;
            this.txtPCC.LeaveColor = System.Drawing.Color.Empty;
            this.txtPCC.Location = new System.Drawing.Point(113, 65);
            this.txtPCC.MaxLength = 4;
            this.txtPCC.Name = "txtPCC";
            this.txtPCC.Size = new System.Drawing.Size(242, 20);
            this.txtPCC.TabIndex = 35;
            this.txtPCC.TextChanged += new System.EventHandler(this.txtPCC_TextChanged);
            this.txtPCC.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControlListBox_KeyDown);
            // 
            // lblPCC
            // 
            this.lblPCC.AutoSize = true;
            this.lblPCC.Cursor = System.Windows.Forms.Cursors.Default;
            this.lblPCC.Location = new System.Drawing.Point(45, 68);
            this.lblPCC.Name = "lblPCC";
            this.lblPCC.Size = new System.Drawing.Size(31, 13);
            this.lblPCC.TabIndex = 40;
            this.lblPCC.Text = "PCC:";
            // 
            // txtName
            // 
            this.txtName.AllowBlankSpaces = true;
            this.txtName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtName.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.NumbersOrLetters;
            this.txtName.CustomExpression = ".*";
            this.txtName.EnterColor = System.Drawing.Color.Empty;
            this.txtName.LeaveColor = System.Drawing.Color.Empty;
            this.txtName.Location = new System.Drawing.Point(113, 123);
            this.txtName.MaxLength = 30;
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(132, 20);
            this.txtName.TabIndex = 36;
            this.txtName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // lblInfo
            // 
            this.lblInfo.AutoSize = true;
            this.lblInfo.Location = new System.Drawing.Point(45, 123);
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Size = new System.Drawing.Size(44, 13);
            this.lblInfo.TabIndex = 39;
            this.lblInfo.Text = "Nombre";
            // 
            // lbPCC
            // 
            this.lbPCC.DisplayMember = "Text";
            this.lbPCC.FormattingEnabled = true;
            this.lbPCC.Location = new System.Drawing.Point(113, 84);
            this.lbPCC.Name = "lbPCC";
            this.lbPCC.Size = new System.Drawing.Size(242, 43);
            this.lbPCC.TabIndex = 47;
            this.lbPCC.ValueMember = "Value";
            this.lbPCC.Visible = false;
            this.lbPCC.KeyDown += new System.Windows.Forms.KeyEventHandler(this.lbPCC_KeyDown);
            this.lbPCC.Click += new System.EventHandler(this.ListBox_MouseClick);
            // 
            // TypeBox
            // 
            this.TypeBox.FormattingEnabled = true;
            this.TypeBox.Items.AddRange(new object[] {
            "OPERATIVO",
            "GETTHERE",
            "IPCC",
            "CONSOLIDADOR",
            "BIZSITE",
            "ROBOTICO",
            "CAPACITACION"});
            this.TypeBox.Location = new System.Drawing.Point(113, 218);
            this.TypeBox.Name = "TypeBox";
            this.TypeBox.Size = new System.Drawing.Size(132, 21);
            this.TypeBox.TabIndex = 48;
            // 
            // ToolBox
            // 
            this.ToolBox.FormattingEnabled = true;
            this.ToolBox.Items.AddRange(new object[] {
            "ONLINE",
            "OFFLINE"});
            this.ToolBox.Location = new System.Drawing.Point(113, 268);
            this.ToolBox.Name = "ToolBox";
            this.ToolBox.Size = new System.Drawing.Size(132, 21);
            this.ToolBox.TabIndex = 49;
            // 
            // GDSBox
            // 
            this.GDSBox.FormattingEnabled = true;
            this.GDSBox.Items.AddRange(new object[] {
            "SABRE",
            "AMADEUS",
            "WORLDSPAN"});
            this.GDSBox.Location = new System.Drawing.Point(113, 313);
            this.GDSBox.Name = "GDSBox";
            this.GDSBox.Size = new System.Drawing.Size(132, 21);
            this.GDSBox.TabIndex = 50;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(45, 218);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(31, 13);
            this.label1.TabIndex = 51;
            this.label1.Text = "Type";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(45, 276);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(28, 13);
            this.label2.TabIndex = 52;
            this.label2.Text = "Tool";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(45, 313);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(30, 13);
            this.label3.TabIndex = 53;
            this.label3.Text = "GDS";
            // 
            // ucUpdatePcc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.GDSBox);
            this.Controls.Add(this.ToolBox);
            this.Controls.Add(this.TypeBox);
            this.Controls.Add(this.lbPCC);
            this.Controls.Add(this.cmbType);
            this.Controls.Add(this.btnAccept);
            this.Controls.Add(this.lblApplication);
            this.Controls.Add(this.txtPCC);
            this.Controls.Add(this.lblPCC);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.lblInfo);
            this.Controls.Add(this.lblTitle);
            this.Name = "ucUpdatePcc";
            this.Size = new System.Drawing.Size(411, 580);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.ComboBox cmbType;
        private System.Windows.Forms.Button btnAccept;
        private System.Windows.Forms.Label lblApplication;
        private MyCTS.Forms.UI.SmartTextBox txtPCC;
        private System.Windows.Forms.Label lblPCC;
        private MyCTS.Forms.UI.SmartTextBox txtName;
        private System.Windows.Forms.Label lblInfo;
        private System.Windows.Forms.ListBox lbPCC;
        private System.Windows.Forms.ComboBox TypeBox;
        private System.Windows.Forms.ComboBox ToolBox;
        private System.Windows.Forms.ComboBox GDSBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}
