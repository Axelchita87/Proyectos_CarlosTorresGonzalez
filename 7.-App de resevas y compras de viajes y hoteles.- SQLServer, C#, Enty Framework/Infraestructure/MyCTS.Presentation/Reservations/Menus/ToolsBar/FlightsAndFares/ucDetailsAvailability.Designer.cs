namespace MyCTS.Presentation
{
    partial class ucDetailsAvailability
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
            this.lblLine = new System.Windows.Forms.Label();
            this.txtLine1 = new MyCTS.Forms.UI.SmartTextBox();
            this.txtRange4 = new MyCTS.Forms.UI.SmartTextBox();
            this.txtLine2 = new MyCTS.Forms.UI.SmartTextBox();
            this.lblscript = new System.Windows.Forms.Label();
            this.lblRange = new System.Windows.Forms.Label();
            this.btnAccept = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(139)))), ((int)(((byte)(208)))));
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(0, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(405, 18);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Detalles de la Disponibilidad";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblLine
            // 
            this.lblLine.AutoSize = true;
            this.lblLine.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLine.Location = new System.Drawing.Point(25, 53);
            this.lblLine.Name = "lblLine";
            this.lblLine.Size = new System.Drawing.Size(40, 13);
            this.lblLine.TabIndex = 0;
            this.lblLine.Text = "Líneas";
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
            this.txtLine1.Location = new System.Drawing.Point(28, 72);
            this.txtLine1.MaxLength = 2;
            this.txtLine1.Name = "txtLine1";
            this.txtLine1.NextControl = this.txtRange4;
            this.txtLine1.Size = new System.Drawing.Size(46, 20);
            this.txtLine1.TabIndex = 1;
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
            this.txtRange4.Location = new System.Drawing.Point(112, 72);
            this.txtRange4.MaxLength = 2;
            this.txtRange4.Name = "txtRange4";
            this.txtRange4.NextControl = this.txtLine2;
            this.txtRange4.Size = new System.Drawing.Size(46, 20);
            this.txtRange4.TabIndex = 2;
            this.txtRange4.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // txtLine2
            // 
            this.txtLine2.AllowBlankSpaces = true;
            this.txtLine2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtLine2.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.OnlyNumbers;
            this.txtLine2.CustomExpression = ".*";
            this.txtLine2.EnterColor = System.Drawing.Color.Empty;
            this.txtLine2.LeaveColor = System.Drawing.Color.Empty;
            this.txtLine2.Location = new System.Drawing.Point(28, 96);
            this.txtLine2.MaxLength = 2;
            this.txtLine2.Name = "txtLine2";
            this.txtLine2.Size = new System.Drawing.Size(46, 20);
            this.txtLine2.TabIndex = 3;
            this.txtLine2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // lblscript
            // 
            this.lblscript.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lblscript.AutoSize = true;
            this.lblscript.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblscript.Location = new System.Drawing.Point(81, 53);
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
            this.lblRange.Location = new System.Drawing.Point(109, 53);
            this.lblRange.Name = "lblRange";
            this.lblRange.Size = new System.Drawing.Size(39, 13);
            this.lblRange.TabIndex = 0;
            this.lblRange.Text = "Rango";
            this.lblRange.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnAccept
            // 
            this.btnAccept.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnAccept.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAccept.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAccept.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAccept.Location = new System.Drawing.Point(154, 164);
            this.btnAccept.Name = "btnAccept";
            this.btnAccept.Size = new System.Drawing.Size(100, 23);
            this.btnAccept.TabIndex = 4;
            this.btnAccept.Text = "Aceptar";
            this.btnAccept.UseVisualStyleBackColor = false;
            this.btnAccept.Click += new System.EventHandler(this.btnAccept_Click);
            // 
            // ucDetailsAvailability
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.btnAccept);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.lblLine);
            this.Controls.Add(this.txtLine1);
            this.Controls.Add(this.txtLine2);
            this.Controls.Add(this.lblscript);
            this.Controls.Add(this.lblRange);
            this.Controls.Add(this.txtRange4);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "ucDetailsAvailability";
            this.Size = new System.Drawing.Size(411, 580);
            this.Load += new System.EventHandler(this.ucDetailsAvailability_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblLine;
        private MyCTS.Forms.UI.SmartTextBox txtLine1;
        private MyCTS.Forms.UI.SmartTextBox txtRange4;
        private MyCTS.Forms.UI.SmartTextBox txtLine2;
        private System.Windows.Forms.Label lblscript;
        private System.Windows.Forms.Label lblRange;
        private System.Windows.Forms.Button btnAccept;
    }
}
