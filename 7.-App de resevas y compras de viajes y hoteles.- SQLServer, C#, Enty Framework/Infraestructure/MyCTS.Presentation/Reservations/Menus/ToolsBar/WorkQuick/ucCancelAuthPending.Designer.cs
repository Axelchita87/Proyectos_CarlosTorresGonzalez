namespace MyCTS.Presentation
{
    partial class ucCancelAuthPending
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
            this.txtPNR = new MyCTS.Forms.UI.SmartTextBox();
            this.Record = new System.Windows.Forms.Label();
            this.btnAccept = new System.Windows.Forms.Button();
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
            this.lblTitle.Text = "Cancelar Autorización Pendiente";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // txtPNR
            // 
            this.txtPNR.AllowBlankSpaces = true;
            this.txtPNR.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtPNR.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.NumbersOrLetters;
            this.txtPNR.CustomExpression = ".*";
            this.txtPNR.EnterColor = System.Drawing.Color.Empty;
            this.txtPNR.LeaveColor = System.Drawing.Color.Empty;
            this.txtPNR.Location = new System.Drawing.Point(141, 65);
            this.txtPNR.MaxLength = 6;
            this.txtPNR.Name = "txtPNR";
            this.txtPNR.Size = new System.Drawing.Size(78, 20);
            this.txtPNR.TabIndex = 159;
            this.txtPNR.TextChanged += new System.EventHandler(this.txtPNR_TextChanged);
            this.txtPNR.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // Record
            // 
            this.Record.AutoSize = true;
            this.Record.Location = new System.Drawing.Point(74, 68);
            this.Record.Name = "Record";
            this.Record.Size = new System.Drawing.Size(48, 13);
            this.Record.TabIndex = 160;
            this.Record.Text = "Record: ";
            // 
            // btnAccept
            // 
            this.btnAccept.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnAccept.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAccept.Location = new System.Drawing.Point(272, 139);
            this.btnAccept.Name = "btnAccept";
            this.btnAccept.Size = new System.Drawing.Size(100, 23);
            this.btnAccept.TabIndex = 164;
            this.btnAccept.Text = "Aceptar";
            this.btnAccept.UseVisualStyleBackColor = false;
            this.btnAccept.Click += new System.EventHandler(this.btnAccept_Click);
            this.btnAccept.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // ucCancelAuthPending
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.btnAccept);
            this.Controls.Add(this.Record);
            this.Controls.Add(this.txtPNR);
            this.Controls.Add(this.lblTitle);
            this.Name = "ucCancelAuthPending";
            this.Size = new System.Drawing.Size(411, 580);
            this.Load += new System.EventHandler(this.ucCancelAuthPending_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.Label lblTitle;
        internal MyCTS.Forms.UI.SmartTextBox txtPNR;
        private System.Windows.Forms.Label Record;
        private System.Windows.Forms.Button btnAccept;
    }
}
