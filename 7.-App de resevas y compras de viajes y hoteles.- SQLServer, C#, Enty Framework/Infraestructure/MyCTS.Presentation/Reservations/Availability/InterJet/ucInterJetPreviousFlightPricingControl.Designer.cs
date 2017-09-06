namespace MyCTS.Presentation
{
    partial class ucInterJetPreviousFlightPricingControl
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
            this.flightsContainer = new System.Windows.Forms.GroupBox();
            this.ItineraryControl = new MyCTS.Presentation.ucInterJetPreviousItineraryControl();
            this.flightsContainer.SuspendLayout();
            this.SuspendLayout();
            // 
            // flightsContainer
            // 
            this.flightsContainer.AutoSize = true;
            this.flightsContainer.Controls.Add(this.ItineraryControl);
            this.flightsContainer.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.flightsContainer.Location = new System.Drawing.Point(4, 4);
            this.flightsContainer.Name = "flightsContainer";
            this.flightsContainer.Size = new System.Drawing.Size(390, 193);
            this.flightsContainer.TabIndex = 0;
            this.flightsContainer.TabStop = false;
            this.flightsContainer.Text = "Vuelo";
            // 
            // ItineraryControl
            // 
            this.ItineraryControl.BackColor = System.Drawing.Color.White;
            this.ItineraryControl.Data = null;
            this.ItineraryControl.InitialControlFocus = null;
            this.ItineraryControl.LastControlFocus = null;
            this.ItineraryControl.LightingTextBox = true;
            this.ItineraryControl.Location = new System.Drawing.Point(109, 19);
            this.ItineraryControl.Name = "ItineraryControl";
            this.ItineraryControl.Parameter = null;
            this.ItineraryControl.Parameters = null;
            this.ItineraryControl.Size = new System.Drawing.Size(151, 82);
            this.ItineraryControl.TabIndex = 0;
            // 
            // ucInterJetPreviousFlightPricingControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.flightsContainer);
            this.Name = "ucInterJetPreviousFlightPricingControl";
            this.Size = new System.Drawing.Size(399, 235);
            this.Load += new System.EventHandler(this.ucInterJetPreviousFlightPricingControl_Load);
            this.flightsContainer.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox flightsContainer;
        private ucInterJetPreviousItineraryControl ItineraryControl;
    }
}
