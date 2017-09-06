namespace MyCTS.Presentation
{
    partial class ucInterJetPassangerConfirmationContainerControl
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
            this.paxContainer = new System.Windows.Forms.GroupBox();
            this.SuspendLayout();
            // 
            // paxContainer
            // 
            this.paxContainer.AutoSize = true;
            this.paxContainer.BackColor = System.Drawing.Color.White;
            this.paxContainer.Location = new System.Drawing.Point(3, 3);
            this.paxContainer.Name = "paxContainer";
            this.paxContainer.Size = new System.Drawing.Size(384, 72);
            this.paxContainer.TabIndex = 0;
            this.paxContainer.TabStop = false;
            this.paxContainer.Text = "Pasajeros";
            // 
            // ucInterJetPassangerConfirmationContainerControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.paxContainer);
            this.Name = "ucInterJetPassangerConfirmationContainerControl";
            this.Size = new System.Drawing.Size(391, 80);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox paxContainer;
    }
}
