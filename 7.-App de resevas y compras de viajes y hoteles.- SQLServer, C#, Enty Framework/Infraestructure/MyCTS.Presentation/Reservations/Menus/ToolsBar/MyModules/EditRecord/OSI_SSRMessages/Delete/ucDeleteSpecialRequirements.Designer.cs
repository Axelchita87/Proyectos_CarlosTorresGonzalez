namespace MyCTS.Presentation
{
    partial class ucDeleteSpecialRequirements
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
            this.lblDataPassenger = new System.Windows.Forms.Label();
            this.lblLine = new System.Windows.Forms.Label();
            this.txtLine1 = new MyCTS.Forms.UI.SmartTextBox();
            this.txtRange4 = new MyCTS.Forms.UI.SmartTextBox();
            this.btnAccept = new System.Windows.Forms.Button();
            this.lblscript = new System.Windows.Forms.Label();
            this.lblRange = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblDataPassenger
            // 
            this.lblDataPassenger.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(139)))), ((int)(((byte)(208)))));
            this.lblDataPassenger.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDataPassenger.ForeColor = System.Drawing.Color.White;
            this.lblDataPassenger.Location = new System.Drawing.Point(3, 0);
            this.lblDataPassenger.Name = "lblDataPassenger";
            this.lblDataPassenger.Size = new System.Drawing.Size(405, 18);
            this.lblDataPassenger.TabIndex = 0;
            this.lblDataPassenger.Text = "Mensaje SSR: Borrar Requerimiento Especial";
            this.lblDataPassenger.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblLine
            // 
            this.lblLine.AutoSize = true;
            this.lblLine.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLine.Location = new System.Drawing.Point(14, 40);
            this.lblLine.Name = "lblLine";
            this.lblLine.Size = new System.Drawing.Size(35, 13);
            this.lblLine.TabIndex = 0;
            this.lblLine.Text = "Línea";
            this.lblLine.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtLine1
            // 
            this.txtLine1.AllowBlankSpaces = true;
            this.txtLine1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtLine1.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.OnlyNumbers;
            this.txtLine1.CustomExpression = ".*";
            this.txtLine1.EnterColor = System.Drawing.Color.Empty;
            this.txtLine1.LeaveColor = System.Drawing.Color.Empty;
            this.txtLine1.Location = new System.Drawing.Point(17, 56);
            this.txtLine1.MaxLength = 3;
            this.txtLine1.Name = "txtLine1";
            this.txtLine1.NextControl = this.txtRange4;
            this.txtLine1.Size = new System.Drawing.Size(37, 20);
            this.txtLine1.TabIndex = 1;
            this.txtLine1.TextChanged += new System.EventHandler(this.txtLine1_TextChanged);
            this.txtLine1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // txtRange4
            // 
            this.txtRange4.AllowBlankSpaces = true;
            this.txtRange4.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtRange4.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.OnlyNumbers;
            this.txtRange4.CustomExpression = ".*";
            this.txtRange4.EnterColor = System.Drawing.Color.Empty;
            this.txtRange4.LeaveColor = System.Drawing.Color.Empty;
            this.txtRange4.Location = new System.Drawing.Point(75, 56);
            this.txtRange4.MaxLength = 3;
            this.txtRange4.Name = "txtRange4";
            this.txtRange4.NextControl = this.btnAccept;
            this.txtRange4.Size = new System.Drawing.Size(37, 20);
            this.txtRange4.TabIndex = 2;
            this.txtRange4.TextChanged += new System.EventHandler(this.txtRange4_TextChanged);
            this.txtRange4.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // btnAccept
            // 
            this.btnAccept.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnAccept.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAccept.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAccept.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAccept.Location = new System.Drawing.Point(184, 166);
            this.btnAccept.Name = "btnAccept";
            this.btnAccept.Size = new System.Drawing.Size(100, 23);
            this.btnAccept.TabIndex = 3;
            this.btnAccept.Text = "Aceptar";
            this.btnAccept.UseVisualStyleBackColor = false;
            this.btnAccept.Click += new System.EventHandler(this.btnAccept_Click);
            // 
            // lblscript
            // 
            this.lblscript.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lblscript.AutoSize = true;
            this.lblscript.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblscript.Location = new System.Drawing.Point(57, 40);
            this.lblscript.Name = "lblscript";
            this.lblscript.Size = new System.Drawing.Size(12, 16);
            this.lblscript.TabIndex = 0;
            this.lblscript.Text = "-";
            this.lblscript.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblRange
            // 
            this.lblRange.AutoSize = true;
            this.lblRange.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRange.ForeColor = System.Drawing.Color.DarkCyan;
            this.lblRange.Location = new System.Drawing.Point(75, 40);
            this.lblRange.Name = "lblRange";
            this.lblRange.Size = new System.Drawing.Size(39, 13);
            this.lblRange.TabIndex = 0;
            this.lblRange.Text = "Rango";
            this.lblRange.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ucDeleteSpecialRequirements
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.lblDataPassenger);
            this.Controls.Add(this.lblLine);
            this.Controls.Add(this.txtLine1);
            this.Controls.Add(this.lblscript);
            this.Controls.Add(this.lblRange);
            this.Controls.Add(this.txtRange4);
            this.Controls.Add(this.btnAccept);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "ucDeleteSpecialRequirements";
            this.Size = new System.Drawing.Size(411, 580);
            this.Load += new System.EventHandler(this.ucDeleteSpecialRequirements_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.Label lblDataPassenger;
        private System.Windows.Forms.Label lblLine;
        private MyCTS.Forms.UI.SmartTextBox txtLine1;
        private MyCTS.Forms.UI.SmartTextBox txtRange4;
        private System.Windows.Forms.Label lblscript;
        private System.Windows.Forms.Label lblRange;
        private System.Windows.Forms.Button btnAccept;
    }
}
