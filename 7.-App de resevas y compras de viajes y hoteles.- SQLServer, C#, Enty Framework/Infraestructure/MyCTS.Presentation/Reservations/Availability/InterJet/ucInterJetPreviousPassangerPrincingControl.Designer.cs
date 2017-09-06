namespace MyCTS.Presentation{
    partial class ucInterJetPreviousPassangerPrincingControl
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
            this.numberOfPaxLabel = new System.Windows.Forms.Label();
            this.passangerIcon = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.passangerTypeLabel = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.totalPriceLabel = new System.Windows.Forms.Label();
            this.totalTaxesLabel = new System.Windows.Forms.Label();
            this.basePriceTotal = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.passangerIcon)).BeginInit();
            this.SuspendLayout();
            // 
            // numberOfPaxLabel
            // 
            this.numberOfPaxLabel.AutoSize = true;
            this.numberOfPaxLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numberOfPaxLabel.Location = new System.Drawing.Point(25, 18);
            this.numberOfPaxLabel.Name = "numberOfPaxLabel";
            this.numberOfPaxLabel.Size = new System.Drawing.Size(14, 13);
            this.numberOfPaxLabel.TabIndex = 0;
            this.numberOfPaxLabel.Text = "0";
            // 
            // passangerIcon
            // 
            this.passangerIcon.Location = new System.Drawing.Point(44, 14);
            this.passangerIcon.Name = "passangerIcon";
            this.passangerIcon.Size = new System.Drawing.Size(34, 32);
            this.passangerIcon.TabIndex = 1;
            this.passangerIcon.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 57);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Precio Base :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(17, 82);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Impuestos :";
            // 
            // passangerTypeLabel
            // 
            this.passangerTypeLabel.AutoSize = true;
            this.passangerTypeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.passangerTypeLabel.ForeColor = System.Drawing.Color.DarkBlue;
            this.passangerTypeLabel.Location = new System.Drawing.Point(84, 18);
            this.passangerTypeLabel.Name = "passangerTypeLabel";
            this.passangerTypeLabel.Size = new System.Drawing.Size(116, 13);
            this.passangerTypeLabel.TabIndex = 4;
            this.passangerTypeLabel.Text = "Adulto(s) Mayor(es)";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(41, 104);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(37, 13);
            this.label5.TabIndex = 5;
            this.label5.Text = "Total :";
            // 
            // totalPriceLabel
            // 
            this.totalPriceLabel.AutoSize = true;
            this.totalPriceLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.totalPriceLabel.Location = new System.Drawing.Point(84, 104);
            this.totalPriceLabel.Name = "totalPriceLabel";
            this.totalPriceLabel.Size = new System.Drawing.Size(41, 13);
            this.totalPriceLabel.TabIndex = 6;
            this.totalPriceLabel.Text = "label6";
            // 
            // totalTaxesLabel
            // 
            this.totalTaxesLabel.AutoSize = true;
            this.totalTaxesLabel.Location = new System.Drawing.Point(84, 82);
            this.totalTaxesLabel.Name = "totalTaxesLabel";
            this.totalTaxesLabel.Size = new System.Drawing.Size(35, 13);
            this.totalTaxesLabel.TabIndex = 7;
            this.totalTaxesLabel.Text = "label6";
            // 
            // basePriceTotal
            // 
            this.basePriceTotal.AutoSize = true;
            this.basePriceTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.basePriceTotal.Location = new System.Drawing.Point(84, 57);
            this.basePriceTotal.Name = "basePriceTotal";
            this.basePriceTotal.Size = new System.Drawing.Size(29, 13);
            this.basePriceTotal.TabIndex = 8;
            this.basePriceTotal.Text = "label";
            // 
            // ucInterJetPreviousPassangerPrincingControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.basePriceTotal);
            this.Controls.Add(this.totalTaxesLabel);
            this.Controls.Add(this.totalPriceLabel);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.passangerTypeLabel);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.passangerIcon);
            this.Controls.Add(this.numberOfPaxLabel);
            this.Name = "ucInterJetPreviousPassangerPrincingControl";
            this.Size = new System.Drawing.Size(203, 123);
            ((System.ComponentModel.ISupportInitialize)(this.passangerIcon)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label numberOfPaxLabel;
        private System.Windows.Forms.PictureBox passangerIcon;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label passangerTypeLabel;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label totalPriceLabel;
        private System.Windows.Forms.Label totalTaxesLabel;
        private System.Windows.Forms.Label basePriceTotal;
    }
}
