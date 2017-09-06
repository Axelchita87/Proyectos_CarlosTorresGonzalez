namespace MyCTS.Presentation
{
    partial class ucInsertIATA
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
            this.txtOffice = new MyCTS.Forms.UI.SmartTextBox();
            this.lblOffice = new System.Windows.Forms.Label();
            this.lbPCC = new System.Windows.Forms.ListBox();
            this.txtPCC = new MyCTS.Forms.UI.SmartTextBox();
            this.lblPCC = new System.Windows.Forms.Label();
            this.txtIATA = new MyCTS.Forms.UI.SmartTextBox();
            this.lblIATA = new System.Windows.Forms.Label();
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
            this.lblTitle.TabIndex = 3;
            this.lblTitle.Text = "Insertar IATA";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnAccept
            // 
            this.btnAccept.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnAccept.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAccept.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAccept.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAccept.Location = new System.Drawing.Point(262, 280);
            this.btnAccept.Name = "btnAccept";
            this.btnAccept.Size = new System.Drawing.Size(100, 23);
            this.btnAccept.TabIndex = 4;
            this.btnAccept.Text = "Aceptar";
            this.btnAccept.UseVisualStyleBackColor = false;
            this.btnAccept.Click += new System.EventHandler(this.btnAccept_Click);
            // 
            // txtOffice
            // 
            this.txtOffice.AllowBlankSpaces = true;
            this.txtOffice.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtOffice.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.AnyCharacter;
            this.txtOffice.CustomExpression = ".*";
            this.txtOffice.EnterColor = System.Drawing.Color.Empty;
            this.txtOffice.LeaveColor = System.Drawing.Color.Empty;
            this.txtOffice.Location = new System.Drawing.Point(84, 108);
            this.txtOffice.MaxLength = 30;
            this.txtOffice.Name = "txtOffice";
            this.txtOffice.Size = new System.Drawing.Size(103, 20);
            this.txtOffice.TabIndex = 2;
            this.txtOffice.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // lblOffice
            // 
            this.lblOffice.AutoSize = true;
            this.lblOffice.Location = new System.Drawing.Point(30, 111);
            this.lblOffice.Name = "lblOffice";
            this.lblOffice.Size = new System.Drawing.Size(40, 13);
            this.lblOffice.TabIndex = 34;
            this.lblOffice.Text = "Oficina";
            // 
            // lbPCC
            // 
            this.lbPCC.DisplayMember = "Text";
            this.lbPCC.FormattingEnabled = true;
            this.lbPCC.Location = new System.Drawing.Point(81, 182);
            this.lbPCC.Name = "lbPCC";
            this.lbPCC.Size = new System.Drawing.Size(263, 43);
            this.lbPCC.TabIndex = 33;
            this.lbPCC.ValueMember = "Value";
            this.lbPCC.Visible = false;
            this.lbPCC.MouseClick += new System.Windows.Forms.MouseEventHandler(this.ListBox_MouseClick);
            this.lbPCC.KeyDown += new System.Windows.Forms.KeyEventHandler(this.lbPCC_KeyDown);
            // 
            // txtPCC
            // 
            this.txtPCC.AllowBlankSpaces = false;
            this.txtPCC.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtPCC.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.NumbersOrLetters;
            this.txtPCC.CustomExpression = ".*";
            this.txtPCC.EnterColor = System.Drawing.Color.Empty;
            this.txtPCC.LeaveColor = System.Drawing.Color.Empty;
            this.txtPCC.Location = new System.Drawing.Point(81, 161);
            this.txtPCC.MaxLength = 4;
            this.txtPCC.Name = "txtPCC";
            this.txtPCC.Size = new System.Drawing.Size(263, 20);
            this.txtPCC.TabIndex = 3;
            this.txtPCC.TextChanged += new System.EventHandler(this.txtPCC_TextChanged);
            this.txtPCC.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControlListBox_KeyDown);
            // 
            // lblPCC
            // 
            this.lblPCC.AutoSize = true;
            this.lblPCC.Cursor = System.Windows.Forms.Cursors.Default;
            this.lblPCC.Location = new System.Drawing.Point(30, 161);
            this.lblPCC.Name = "lblPCC";
            this.lblPCC.Size = new System.Drawing.Size(31, 13);
            this.lblPCC.TabIndex = 31;
            this.lblPCC.Text = "PCC:";
            // 
            // txtIATA
            // 
            this.txtIATA.AllowBlankSpaces = false;
            this.txtIATA.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtIATA.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.OnlyNumbers;
            this.txtIATA.CustomExpression = ".*";
            this.txtIATA.EnterColor = System.Drawing.Color.Empty;
            this.txtIATA.LeaveColor = System.Drawing.Color.Empty;
            this.txtIATA.Location = new System.Drawing.Point(86, 61);
            this.txtIATA.MaxLength = 9;
            this.txtIATA.Name = "txtIATA";
            this.txtIATA.Size = new System.Drawing.Size(103, 20);
            this.txtIATA.TabIndex = 1;
            this.txtIATA.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // lblIATA
            // 
            this.lblIATA.AutoSize = true;
            this.lblIATA.Location = new System.Drawing.Point(30, 64);
            this.lblIATA.Name = "lblIATA";
            this.lblIATA.Size = new System.Drawing.Size(31, 13);
            this.lblIATA.TabIndex = 29;
            this.lblIATA.Text = "IATA";
            // 
            // ucInsertIATA
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.btnAccept);
            this.Controls.Add(this.txtOffice);
            this.Controls.Add(this.lblOffice);
            this.Controls.Add(this.lbPCC);
            this.Controls.Add(this.txtPCC);
            this.Controls.Add(this.lblPCC);
            this.Controls.Add(this.txtIATA);
            this.Controls.Add(this.lblIATA);
            this.Controls.Add(this.lblTitle);
            this.Name = "ucInsertIATA";
            this.Size = new System.Drawing.Size(411, 580);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Button btnAccept;
        private MyCTS.Forms.UI.SmartTextBox txtOffice;
        private System.Windows.Forms.Label lblOffice;
        private System.Windows.Forms.ListBox lbPCC;
        private MyCTS.Forms.UI.SmartTextBox txtPCC;
        private System.Windows.Forms.Label lblPCC;
        private MyCTS.Forms.UI.SmartTextBox txtIATA;
        private System.Windows.Forms.Label lblIATA;
    }
}
