namespace MyCTS.Presentation
{
    partial class ucGetDIX
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
            this.txtPNR = new MyCTS.Forms.UI.SmartTextBox();
            this.lblPNR = new System.Windows.Forms.Label();
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
            this.lblTitle.Text = "Generación DIX por Record";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.lblTitle.Visible = false;
            // 
            // btnAccept
            // 
            this.btnAccept.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnAccept.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAccept.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAccept.Location = new System.Drawing.Point(264, 142);
            this.btnAccept.Name = "btnAccept";
            this.btnAccept.Size = new System.Drawing.Size(100, 23);
            this.btnAccept.TabIndex = 2;
            this.btnAccept.Text = "Aceptar";
            this.btnAccept.UseVisualStyleBackColor = false;
            this.btnAccept.Visible = false;
            this.btnAccept.Click += new System.EventHandler(this.btnAccept_Click);
            // 
            // txtPNR
            // 
            this.txtPNR.AllowBlankSpaces = false;
            this.txtPNR.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtPNR.CharsIncluded = new char[0];
            this.txtPNR.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.OnlyLetters;
            this.txtPNR.CustomExpression = ".*";
            this.txtPNR.EnterColor = System.Drawing.Color.Empty;
            this.txtPNR.LeaveColor = System.Drawing.Color.Empty;
            this.txtPNR.Location = new System.Drawing.Point(172, 72);
            this.txtPNR.MaxLength = 6;
            this.txtPNR.Name = "txtPNR";
            this.txtPNR.Size = new System.Drawing.Size(93, 20);
            this.txtPNR.TabIndex = 1;
            this.txtPNR.Visible = false;
            this.txtPNR.TextChanged += new System.EventHandler(this.txtPNR_TextChanged);
            // 
            // lblPNR
            // 
            this.lblPNR.AutoSize = true;
            this.lblPNR.Location = new System.Drawing.Point(26, 75);
            this.lblPNR.Name = "lblPNR";
            this.lblPNR.Size = new System.Drawing.Size(140, 13);
            this.lblPNR.TabIndex = 3;
            this.lblPNR.Text = "Ingrese Record Localizador:";
            this.lblPNR.Visible = false;
            // 
            // ucGetDIX
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.lblPNR);
            this.Controls.Add(this.txtPNR);
            this.Controls.Add(this.btnAccept);
            this.Controls.Add(this.lblTitle);
            this.Name = "ucGetDIX";
            this.Size = new System.Drawing.Size(411, 580);
            this.Load += new System.EventHandler(this.ucGetDIX_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Button btnAccept;
        private MyCTS.Forms.UI.SmartTextBox txtPNR;
        private System.Windows.Forms.Label lblPNR;
    }
}
