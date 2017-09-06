namespace MyCTS.Presentation
{
    partial class ucPhaseIVDeleteMask
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
            this.txtMaskNumber = new MyCTS.Forms.UI.SmartTextBox();
            this.lblMaskNumber = new System.Windows.Forms.Label();
            this.lblEmpty = new System.Windows.Forms.Label();
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
            this.lblTitle.Text = "Borrar Mascarilla Fase IV";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // txtMaskNumber
            // 
            this.txtMaskNumber.AllowBlankSpaces = false;
            this.txtMaskNumber.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtMaskNumber.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.OnlyNumbers;
            this.txtMaskNumber.CustomExpression = ".*";
            this.txtMaskNumber.EnterColor = System.Drawing.Color.Empty;
            this.txtMaskNumber.LeaveColor = System.Drawing.Color.Empty;
            this.txtMaskNumber.Location = new System.Drawing.Point(132, 42);
            this.txtMaskNumber.Name = "txtMaskNumber";
            this.txtMaskNumber.Size = new System.Drawing.Size(25, 20);
            this.txtMaskNumber.TabIndex = 2;
            this.txtMaskNumber.TextChanged += new System.EventHandler(this.maskNumber_TextChanged);
            this.txtMaskNumber.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // lblMaskNumber
            // 
            this.lblMaskNumber.AutoSize = true;
            this.lblMaskNumber.ForeColor = System.Drawing.Color.DarkCyan;
            this.lblMaskNumber.Location = new System.Drawing.Point(29, 45);
            this.lblMaskNumber.Name = "lblMaskNumber";
            this.lblMaskNumber.Size = new System.Drawing.Size(97, 13);
            this.lblMaskNumber.TabIndex = 3;
            this.lblMaskNumber.Text = "Num de Mascarilla:";
            // 
            // lblEmpty
            // 
            this.lblEmpty.AutoSize = true;
            this.lblEmpty.ForeColor = System.Drawing.Color.Navy;
            this.lblEmpty.Location = new System.Drawing.Point(29, 78);
            this.lblEmpty.Name = "lblEmpty";
            this.lblEmpty.Size = new System.Drawing.Size(158, 13);
            this.lblEmpty.TabIndex = 4;
            this.lblEmpty.Text = "Deja en vacío para borrar todas";
            // 
            // btnAccept
            // 
            this.btnAccept.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnAccept.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAccept.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAccept.Location = new System.Drawing.Point(245, 151);
            this.btnAccept.Name = "btnAccept";
            this.btnAccept.Size = new System.Drawing.Size(100, 23);
            this.btnAccept.TabIndex = 5;
            this.btnAccept.Text = "Aceptar";
            this.btnAccept.UseVisualStyleBackColor = false;
            this.btnAccept.Click += new System.EventHandler(this.btnAccept_Click);
            // 
            // ucPhaseIVDeleteMask
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.btnAccept);
            this.Controls.Add(this.lblEmpty);
            this.Controls.Add(this.lblMaskNumber);
            this.Controls.Add(this.txtMaskNumber);
            this.Controls.Add(this.lblTitle);
            this.ForeColor = System.Drawing.Color.Black;
            this.Name = "ucPhaseIVDeleteMask";
            this.Size = new System.Drawing.Size(411, 580);
            this.Load += new System.EventHandler(this.ucPhaseIVDeleteMask_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.Label lblTitle;
        private MyCTS.Forms.UI.SmartTextBox txtMaskNumber;
        private System.Windows.Forms.Label lblMaskNumber;
        private System.Windows.Forms.Label lblEmpty;
        private System.Windows.Forms.Button btnAccept;
    }
}
