namespace MyCTS.Presentation
{
    partial class ucUpdateTA
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
            this.lblType = new System.Windows.Forms.Label();
            this.lbPCC = new System.Windows.Forms.ListBox();
            this.txtPCC = new MyCTS.Forms.UI.SmartTextBox();
            this.lblPCC = new System.Windows.Forms.Label();
            this.txtTA = new MyCTS.Forms.UI.SmartTextBox();
            this.lblTA = new System.Windows.Forms.Label();
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
            this.lblTitle.TabIndex = 4;
            this.lblTitle.Text = "Actualizar TA";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cmbType
            // 
            this.cmbType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbType.FormattingEnabled = true;
            this.cmbType.Items.AddRange(new object[] {
            "PTR",
            "MINI",
            "CRT"});
            this.cmbType.Location = new System.Drawing.Point(74, 119);
            this.cmbType.Name = "cmbType";
            this.cmbType.Size = new System.Drawing.Size(103, 21);
            this.cmbType.TabIndex = 2;
            this.cmbType.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // btnAccept
            // 
            this.btnAccept.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnAccept.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAccept.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAccept.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAccept.Location = new System.Drawing.Point(155, 250);
            this.btnAccept.Name = "btnAccept";
            this.btnAccept.Size = new System.Drawing.Size(100, 23);
            this.btnAccept.TabIndex = 4;
            this.btnAccept.Text = "Aceptar";
            this.btnAccept.UseVisualStyleBackColor = false;
            this.btnAccept.Click += new System.EventHandler(this.btnAccept_Click);
            this.btnAccept.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // lblType
            // 
            this.lblType.AutoSize = true;
            this.lblType.Location = new System.Drawing.Point(32, 123);
            this.lblType.Name = "lblType";
            this.lblType.Size = new System.Drawing.Size(28, 13);
            this.lblType.TabIndex = 34;
            this.lblType.Text = "Tipo";
            // 
            // lbPCC
            // 
            this.lbPCC.DisplayMember = "Text";
            this.lbPCC.FormattingEnabled = true;
            this.lbPCC.Location = new System.Drawing.Point(73, 189);
            this.lbPCC.Name = "lbPCC";
            this.lbPCC.Size = new System.Drawing.Size(300, 43);
            this.lbPCC.TabIndex = 33;
            this.lbPCC.ValueMember = "Value";
            this.lbPCC.Visible = false;
            // 
            // txtPCC
            // 
            this.txtPCC.AllowBlankSpaces = true;
            this.txtPCC.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtPCC.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.NumbersOrLetters;
            this.txtPCC.CustomExpression = ".*";
            this.txtPCC.EnterColor = System.Drawing.Color.Empty;
            this.txtPCC.LeaveColor = System.Drawing.Color.Empty;
            this.txtPCC.Location = new System.Drawing.Point(73, 168);
            this.txtPCC.MaxLength = 4;
            this.txtPCC.Name = "txtPCC";
            this.txtPCC.Size = new System.Drawing.Size(300, 20);
            this.txtPCC.TabIndex = 3;
            this.txtPCC.TextChanged += new System.EventHandler(this.txtPCC_TextChanged);
            this.txtPCC.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControlListBox_KeyDown);
            // 
            // lblPCC
            // 
            this.lblPCC.AutoSize = true;
            this.lblPCC.Cursor = System.Windows.Forms.Cursors.Default;
            this.lblPCC.Location = new System.Drawing.Point(35, 171);
            this.lblPCC.Name = "lblPCC";
            this.lblPCC.Size = new System.Drawing.Size(31, 13);
            this.lblPCC.TabIndex = 32;
            this.lblPCC.Text = "PCC:";
            // 
            // txtTA
            // 
            this.txtTA.AllowBlankSpaces = false;
            this.txtTA.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtTA.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.NumbersOrLetters;
            this.txtTA.CustomExpression = ".*";
            this.txtTA.EnterColor = System.Drawing.Color.Empty;
            this.txtTA.LeaveColor = System.Drawing.Color.Empty;
            this.txtTA.Location = new System.Drawing.Point(76, 80);
            this.txtTA.MaxLength = 6;
            this.txtTA.Name = "txtTA";
            this.txtTA.Size = new System.Drawing.Size(103, 20);
            this.txtTA.TabIndex = 1;
            this.txtTA.TextChanged += new System.EventHandler(this.txtTA_TextChanged);
            this.txtTA.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // lblTA
            // 
            this.lblTA.AutoSize = true;
            this.lblTA.Location = new System.Drawing.Point(37, 83);
            this.lblTA.Name = "lblTA";
            this.lblTA.Size = new System.Drawing.Size(21, 13);
            this.lblTA.TabIndex = 31;
            this.lblTA.Text = "TA";
            // 
            // ucUpdateTA
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.cmbType);
            this.Controls.Add(this.btnAccept);
            this.Controls.Add(this.lblType);
            this.Controls.Add(this.lbPCC);
            this.Controls.Add(this.txtPCC);
            this.Controls.Add(this.lblPCC);
            this.Controls.Add(this.txtTA);
            this.Controls.Add(this.lblTA);
            this.Controls.Add(this.lblTitle);
            this.Name = "ucUpdateTA";
            this.Size = new System.Drawing.Size(411, 580);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.ComboBox cmbType;
        private System.Windows.Forms.Button btnAccept;
        private System.Windows.Forms.Label lblType;
        private System.Windows.Forms.ListBox lbPCC;
        private MyCTS.Forms.UI.SmartTextBox txtPCC;
        private System.Windows.Forms.Label lblPCC;
        private MyCTS.Forms.UI.SmartTextBox txtTA;
        private System.Windows.Forms.Label lblTA;
    }
}
