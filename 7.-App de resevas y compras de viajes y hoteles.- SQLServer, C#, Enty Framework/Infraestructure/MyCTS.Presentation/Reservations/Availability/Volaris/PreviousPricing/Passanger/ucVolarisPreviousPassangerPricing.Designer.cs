namespace MyCTS.Presentation
{
    partial class ucVolarisPreviousPassangerPricing
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
            this.passangerCount = new System.Windows.Forms.Label();
            this.passangerType = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.basePrice = new System.Windows.Forms.Label();
            this.taxes = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.total = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // passangerCount
            // 
            this.passangerCount.AutoSize = true;
            this.passangerCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.passangerCount.Location = new System.Drawing.Point(69, 25);
            this.passangerCount.Name = "passangerCount";
            this.passangerCount.Size = new System.Drawing.Size(14, 13);
            this.passangerCount.TabIndex = 1;
            this.passangerCount.Text = "1";
            // 
            // passangerType
            // 
            this.passangerType.AutoSize = true;
            this.passangerType.Enabled = false;
            this.passangerType.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.passangerType.ForeColor = System.Drawing.Color.DarkBlue;
            this.passangerType.Location = new System.Drawing.Point(132, 25);
            this.passangerType.Name = "passangerType";
            this.passangerType.Size = new System.Drawing.Size(57, 13);
            this.passangerType.TabIndex = 2;
            this.passangerType.Text = "Adulto(s)";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(60, 52);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Precio Base :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(69, 74);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(58, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "Impuestos:";
            // 
            // basePrice
            // 
            this.basePrice.AutoSize = true;
            this.basePrice.Location = new System.Drawing.Point(143, 52);
            this.basePrice.Name = "basePrice";
            this.basePrice.Size = new System.Drawing.Size(46, 13);
            this.basePrice.TabIndex = 5;
            this.basePrice.Text = "1580.00";
            // 
            // taxes
            // 
            this.taxes.AutoSize = true;
            this.taxes.Location = new System.Drawing.Point(143, 74);
            this.taxes.Name = "taxes";
            this.taxes.Size = new System.Drawing.Size(46, 13);
            this.taxes.TabIndex = 6;
            this.taxes.Text = "1855.00";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(93, 98);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(34, 13);
            this.label7.TabIndex = 7;
            this.label7.Text = "Total:";
            // 
            // total
            // 
            this.total.AutoSize = true;
            this.total.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.total.Location = new System.Drawing.Point(136, 98);
            this.total.Name = "total";
            this.total.Size = new System.Drawing.Size(53, 13);
            this.total.TabIndex = 8;
            this.total.Text = "3456.00";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(89, 13);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(37, 36);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // ucVolarisPreviousPassangerPricing
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.total);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.taxes);
            this.Controls.Add(this.basePrice);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.passangerType);
            this.Controls.Add(this.passangerCount);
            this.Controls.Add(this.pictureBox1);
            this.Name = "ucVolarisPreviousPassangerPricing";
            this.Size = new System.Drawing.Size(296, 123);
            this.Load += new System.EventHandler(this.ucVolarisPreviousPassangerPricing_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label passangerCount;
        private System.Windows.Forms.Label passangerType;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label basePrice;
        private System.Windows.Forms.Label taxes;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label total;
    }
}
