namespace MyCTS.Presentation.Reservations.Availability.Volaris.PreviousReservationResume.PassangerResume
{
    partial class ucVolarisPassangerTypeResume
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
            this.paxCount = new System.Windows.Forms.Label();
            this.paxType = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // paxCount
            // 
            this.paxCount.AutoSize = true;
            this.paxCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.paxCount.Location = new System.Drawing.Point(3, 0);
            this.paxCount.Name = "paxCount";
            this.paxCount.Size = new System.Drawing.Size(14, 13);
            this.paxCount.TabIndex = 0;
            this.paxCount.Text = "1";
            // 
            // paxType
            // 
            this.paxType.AutoSize = true;
            this.paxType.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.paxType.ForeColor = System.Drawing.Color.DarkBlue;
            this.paxType.Location = new System.Drawing.Point(23, 0);
            this.paxType.Name = "paxType";
            this.paxType.Size = new System.Drawing.Size(57, 13);
            this.paxType.TabIndex = 1;
            this.paxType.Text = "Adulto(s)";
            // 
            // ucVolarisPassangerTypeResume
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.Controls.Add(this.paxType);
            this.Controls.Add(this.paxCount);
            this.Name = "ucVolarisPassangerTypeResume";
            this.Size = new System.Drawing.Size(92, 18);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label paxCount;
        private System.Windows.Forms.Label paxType;
    }
}
