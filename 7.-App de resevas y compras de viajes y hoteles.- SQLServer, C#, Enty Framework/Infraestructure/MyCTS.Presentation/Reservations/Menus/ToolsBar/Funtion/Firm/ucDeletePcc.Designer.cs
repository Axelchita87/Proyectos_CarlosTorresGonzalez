namespace MyCTS.Presentation
{
    partial class ucDeletePcc
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
            this.txtPcc = new MyCTS.Forms.UI.SmartTextBox();
            this.lblPcc = new System.Windows.Forms.Label();
            this.lbPCC = new System.Windows.Forms.ListBox();
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
            this.lblTitle.Text = "Eliminar Pcc";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnAccept
            // 
            this.btnAccept.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnAccept.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAccept.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAccept.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAccept.Location = new System.Drawing.Point(247, 200);
            this.btnAccept.Name = "btnAccept";
            this.btnAccept.Size = new System.Drawing.Size(100, 23);
            this.btnAccept.TabIndex = 45;
            this.btnAccept.Text = "Aceptar";
            this.btnAccept.UseVisualStyleBackColor = false;
            this.btnAccept.Click += new System.EventHandler(this.btnAccept_Click);
            this.btnAccept.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // txtPcc
            // 
            this.txtPcc.AllowBlankSpaces = false;
            this.txtPcc.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtPcc.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.NumbersOrLetters;
            this.txtPcc.CustomExpression = ".*";
            this.txtPcc.EnterColor = System.Drawing.Color.Empty;
            this.txtPcc.LeaveColor = System.Drawing.Color.Empty;
            this.txtPcc.Location = new System.Drawing.Point(85, 90);
            this.txtPcc.MaxLength = 4;
            this.txtPcc.Name = "txtPcc";
            this.txtPcc.Size = new System.Drawing.Size(262, 20);
            this.txtPcc.TabIndex = 43;
            this.txtPcc.TextChanged += new System.EventHandler(this.txtPcc_TextChanged);
            this.txtPcc.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControlListBox_KeyDown);
            // 
            // lblPcc
            // 
            this.lblPcc.AutoSize = true;
            this.lblPcc.Location = new System.Drawing.Point(53, 93);
            this.lblPcc.Name = "lblPcc";
            this.lblPcc.Size = new System.Drawing.Size(26, 13);
            this.lblPcc.TabIndex = 44;
            this.lblPcc.Text = "Pcc";
            // 
            // lbPCC
            // 
            this.lbPCC.DisplayMember = "Text";
            this.lbPCC.FormattingEnabled = true;
            this.lbPCC.Location = new System.Drawing.Point(85, 110);
            this.lbPCC.Name = "lbPCC";
            this.lbPCC.Size = new System.Drawing.Size(262, 43);
            this.lbPCC.TabIndex = 46;
            this.lbPCC.ValueMember = "Value";
            this.lbPCC.Visible = false;
            this.lbPCC.KeyDown += new System.Windows.Forms.KeyEventHandler(this.lbPCC_KeyDown);
            this.lbPCC.Click += new System.EventHandler(this.ListBox_MouseClick);
            // 
            // ucDeletePcc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.lbPCC);
            this.Controls.Add(this.btnAccept);
            this.Controls.Add(this.txtPcc);
            this.Controls.Add(this.lblPcc);
            this.Controls.Add(this.lblTitle);
            this.Name = "ucDeletePcc";
            this.Size = new System.Drawing.Size(411, 580);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Button btnAccept;
        private MyCTS.Forms.UI.SmartTextBox txtPcc;
        private System.Windows.Forms.Label lblPcc;
        private System.Windows.Forms.ListBox lbPCC;
    }
}
