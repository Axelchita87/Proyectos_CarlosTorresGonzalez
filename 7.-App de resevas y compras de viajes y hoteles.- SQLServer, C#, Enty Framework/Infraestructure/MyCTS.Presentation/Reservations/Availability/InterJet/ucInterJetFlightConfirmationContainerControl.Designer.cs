namespace MyCTS.Presentation
{
    partial class ucInterJetFlightConfirmationContainerControl
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
            this.segmentContainer = new System.Windows.Forms.GroupBox();
            this.SuspendLayout();
            // 
            // segmentContainer
            // 
            this.segmentContainer.AutoSize = true;
            this.segmentContainer.Location = new System.Drawing.Point(4, 4);
            this.segmentContainer.Name = "segmentContainer";
            this.segmentContainer.Size = new System.Drawing.Size(384, 145);
            this.segmentContainer.TabIndex = 0;
            this.segmentContainer.TabStop = false;
            this.segmentContainer.Text = "Vuelos";
            // 
            // ucInterJetFlightConfirmationContainerControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.segmentContainer);
            this.Name = "ucInterJetFlightConfirmationContainerControl";
            this.Size = new System.Drawing.Size(393, 155);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox segmentContainer;
    }
}
