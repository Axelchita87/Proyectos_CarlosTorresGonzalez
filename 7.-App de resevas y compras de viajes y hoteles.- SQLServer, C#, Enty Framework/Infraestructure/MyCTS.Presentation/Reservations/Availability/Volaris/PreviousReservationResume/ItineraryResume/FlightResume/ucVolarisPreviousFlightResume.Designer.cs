namespace MyCTS.Presentation.Reservations.Availability.Volaris.PreviousReservationResume.ItineraryResume.FlightResume
{
    partial class ucVolarisPreviousFlightResume
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
            this.typeOfFlight = new System.Windows.Forms.Label();
            this.dateOfFlight = new System.Windows.Forms.Label();
            this.itinerary = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // typeOfFlight
            // 
            this.typeOfFlight.AutoSize = true;
            this.typeOfFlight.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.typeOfFlight.Location = new System.Drawing.Point(16, 0);
            this.typeOfFlight.Name = "typeOfFlight";
            this.typeOfFlight.Size = new System.Drawing.Size(51, 13);
            this.typeOfFlight.TabIndex = 0;
            this.typeOfFlight.Text = "SALIDA";
            // 
            // dateOfFlight
            // 
            this.dateOfFlight.AutoSize = true;
            this.dateOfFlight.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateOfFlight.Location = new System.Drawing.Point(82, 0);
            this.dateOfFlight.Name = "dateOfFlight";
            this.dateOfFlight.Size = new System.Drawing.Size(69, 13);
            this.dateOfFlight.TabIndex = 1;
            this.dateOfFlight.Text = "mar 02 sep";
            // 
            // itinerary
            // 
            this.itinerary.AutoSize = true;
            this.itinerary.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.itinerary.ForeColor = System.Drawing.Color.DarkBlue;
            this.itinerary.Location = new System.Drawing.Point(3, 13);
            this.itinerary.Name = "itinerary";
            this.itinerary.Size = new System.Drawing.Size(85, 13);
            this.itinerary.TabIndex = 2;
            this.itinerary.Text = "MEX-CUN-TIJ";
            // 
            // ucVolarisPreviousFlightResume
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.Controls.Add(this.itinerary);
            this.Controls.Add(this.dateOfFlight);
            this.Controls.Add(this.typeOfFlight);
            this.Name = "ucVolarisPreviousFlightResume";
            this.Size = new System.Drawing.Size(192, 30);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label typeOfFlight;
        private System.Windows.Forms.Label dateOfFlight;
        private System.Windows.Forms.Label itinerary;
    }
}
