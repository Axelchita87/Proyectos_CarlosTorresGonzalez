namespace MyCTS.Presentation
{
    partial class ucPromo
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
            this.lblFormPay = new System.Windows.Forms.Label();
            this.lblBegin = new System.Windows.Forms.Label();
            this.lblPromo = new System.Windows.Forms.Label();
            this.btnAccept = new System.Windows.Forms.Button();
            this.rdoPromoNot = new System.Windows.Forms.RadioButton();
            this.SuspendLayout();
            // 
            // lblFormPay
            // 
            this.lblFormPay.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(139)))), ((int)(((byte)(208)))));
            this.lblFormPay.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblFormPay.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFormPay.ForeColor = System.Drawing.Color.White;
            this.lblFormPay.Location = new System.Drawing.Point(0, 0);
            this.lblFormPay.Name = "lblFormPay";
            this.lblFormPay.Size = new System.Drawing.Size(411, 16);
            this.lblFormPay.TabIndex = 1;
            this.lblFormPay.Text = "Promociones";
            this.lblFormPay.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblBegin
            // 
            this.lblBegin.AutoSize = true;
            this.lblBegin.Location = new System.Drawing.Point(25, 72);
            this.lblBegin.Name = "lblBegin";
            this.lblBegin.Size = new System.Drawing.Size(114, 13);
            this.lblBegin.TabIndex = 1;
            this.lblBegin.Text = "Existe una promoción: ";
            // 
            // lblPromo
            // 
            this.lblPromo.AutoSize = true;
            this.lblPromo.ForeColor = System.Drawing.Color.Blue;
            this.lblPromo.Location = new System.Drawing.Point(25, 107);
            this.lblPromo.MaximumSize = new System.Drawing.Size(350, 0);
            this.lblPromo.Name = "lblPromo";
            this.lblPromo.Size = new System.Drawing.Size(35, 13);
            this.lblPromo.TabIndex = 2;
            this.lblPromo.Text = "label2";
            // 
            // btnAccept
            // 
            this.btnAccept.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnAccept.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAccept.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAccept.Location = new System.Drawing.Point(281, 406);
            this.btnAccept.Name = "btnAccept";
            this.btnAccept.Size = new System.Drawing.Size(110, 24);
            this.btnAccept.TabIndex = 7;
            this.btnAccept.Text = "Aceptar";
            this.btnAccept.UseVisualStyleBackColor = false;
            this.btnAccept.Click += new System.EventHandler(this.btnAccept_Click);
            this.btnAccept.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // rdoPromoNot
            // 
            this.rdoPromoNot.AutoSize = true;
            this.rdoPromoNot.Location = new System.Drawing.Point(28, 410);
            this.rdoPromoNot.Name = "rdoPromoNot";
            this.rdoPromoNot.Size = new System.Drawing.Size(125, 17);
            this.rdoPromoNot.TabIndex = 1;
            this.rdoPromoNot.TabStop = true;
            this.rdoPromoNot.Text = "No aplicar promoción";
            this.rdoPromoNot.UseVisualStyleBackColor = true;
            this.rdoPromoNot.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // ucPromo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.rdoPromoNot);
            this.Controls.Add(this.lblPromo);
            this.Controls.Add(this.btnAccept);
            this.Controls.Add(this.lblBegin);
            this.Controls.Add(this.lblFormPay);
            this.Name = "ucPromo";
            this.Size = new System.Drawing.Size(411, 580);
            this.Load += new System.EventHandler(this.ucPromo_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.Label lblFormPay;
        private System.Windows.Forms.Label lblBegin;
        private System.Windows.Forms.Label lblPromo;
        private System.Windows.Forms.Button btnAccept;
        private System.Windows.Forms.RadioButton rdoPromoNot;
    }
}
