namespace MyCTS.Presentation
{
    partial class ucCouponReexpedition
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
            this.lblNumberLine = new System.Windows.Forms.Label();
            this.txtNumberTicket = new MyCTS.Forms.UI.SmartTextBox();
            this.btnAccept = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(139)))), ((int)(((byte)(208)))));
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(3, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(405, 16);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Reexpedir Cupón";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblNumberLine
            // 
            this.lblNumberLine.AutoSize = true;
            this.lblNumberLine.Location = new System.Drawing.Point(27, 82);
            this.lblNumberLine.Name = "lblNumberLine";
            this.lblNumberLine.Size = new System.Drawing.Size(95, 13);
            this.lblNumberLine.TabIndex = 0;
            this.lblNumberLine.Text = "Número de Boleto:";
            this.lblNumberLine.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtNumberTicket
            // 
            this.txtNumberTicket.AllowBlankSpaces = false;
            this.txtNumberTicket.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtNumberTicket.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.OnlyNumbers;
            this.txtNumberTicket.CustomExpression = ".*";
            this.txtNumberTicket.EnterColor = System.Drawing.Color.Empty;
            this.txtNumberTicket.LeaveColor = System.Drawing.Color.Empty;
            this.txtNumberTicket.Location = new System.Drawing.Point(128, 79);
            this.txtNumberTicket.MaxLength = 13;
            this.txtNumberTicket.Name = "txtNumberTicket";
            this.txtNumberTicket.Size = new System.Drawing.Size(100, 20);
            this.txtNumberTicket.TabIndex = 1;
            this.txtNumberTicket.TextChanged += new System.EventHandler(this.txtNumberTicket_TextChanged);
            this.txtNumberTicket.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // btnAccept
            // 
            this.btnAccept.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnAccept.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAccept.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAccept.Location = new System.Drawing.Point(230, 144);
            this.btnAccept.Name = "btnAccept";
            this.btnAccept.Size = new System.Drawing.Size(100, 23);
            this.btnAccept.TabIndex = 2;
            this.btnAccept.Text = "Aceptar";
            this.btnAccept.UseVisualStyleBackColor = false;
            this.btnAccept.Click += new System.EventHandler(this.btnAccept_Click);
            // 
            // ucCouponReexpedition
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.btnAccept);
            this.Controls.Add(this.lblNumberLine);
            this.Controls.Add(this.txtNumberTicket);
            this.Controls.Add(this.lblTitle);
            this.Name = "ucCouponReexpedition";
            this.Size = new System.Drawing.Size(411, 580);
            this.Load += new System.EventHandler(this.ucCouponReexpedition_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblNumberLine;
        private MyCTS.Forms.UI.SmartTextBox txtNumberTicket;
        private System.Windows.Forms.Button btnAccept;
    }
}
