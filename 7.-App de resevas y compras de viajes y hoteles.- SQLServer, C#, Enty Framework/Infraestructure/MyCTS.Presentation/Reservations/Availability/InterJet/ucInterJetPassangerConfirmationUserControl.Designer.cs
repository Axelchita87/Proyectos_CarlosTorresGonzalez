namespace MyCTS.Presentation
{
    partial class ucInterJetPassangerConfirmationUserControl
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
            this.paxLabel = new System.Windows.Forms.Label();
            this.paxNameLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // paxLabel
            // 
            this.paxLabel.AutoSize = true;
            this.paxLabel.Location = new System.Drawing.Point(3, 10);
            this.paxLabel.Name = "paxLabel";
            this.paxLabel.Size = new System.Drawing.Size(51, 13);
            this.paxLabel.TabIndex = 0;
            this.paxLabel.Text = "Pasajero:";
            // 
            // paxNameLabel
            // 
            this.paxNameLabel.AutoSize = true;
            this.paxNameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.paxNameLabel.Location = new System.Drawing.Point(60, 10);
            this.paxNameLabel.Name = "paxNameLabel";
            this.paxNameLabel.Size = new System.Drawing.Size(11, 13);
            this.paxNameLabel.TabIndex = 1;
            this.paxNameLabel.Text = "-";
            // 
            // ucInterJetPassangerConfirmationUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.paxNameLabel);
            this.Controls.Add(this.paxLabel);
            this.Name = "ucInterJetPassangerConfirmationUserControl";
            this.Size = new System.Drawing.Size(280, 38);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label paxLabel;
        private System.Windows.Forms.Label paxNameLabel;
    }
}
