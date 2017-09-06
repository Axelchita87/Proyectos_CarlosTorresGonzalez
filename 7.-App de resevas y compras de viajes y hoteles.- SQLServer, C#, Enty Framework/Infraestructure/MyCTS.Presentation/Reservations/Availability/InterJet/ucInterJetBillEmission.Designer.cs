namespace MyCTS.Presentation
{
    partial class ucInterJetBillEmission
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
            this.billEmisionButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // billEmisionButton
            // 
            this.billEmisionButton.Location = new System.Drawing.Point(27, 42);
            this.billEmisionButton.Name = "billEmisionButton";
            this.billEmisionButton.Size = new System.Drawing.Size(125, 23);
            this.billEmisionButton.TabIndex = 0;
            this.billEmisionButton.Text = "Emision Factura";
            this.billEmisionButton.UseVisualStyleBackColor = true;
            this.billEmisionButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // ucInterJetBillEmission
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.billEmisionButton);
            this.Name = "ucInterJetBillEmission";
            this.Size = new System.Drawing.Size(498, 600);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button billEmisionButton;
    }
}
