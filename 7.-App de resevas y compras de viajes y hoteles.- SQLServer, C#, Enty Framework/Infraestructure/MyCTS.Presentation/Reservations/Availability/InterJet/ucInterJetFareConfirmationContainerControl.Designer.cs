namespace MyCTS.Presentation
{
    partial class ucInterJetFareConfirmationContainerControl
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
            this.mainContainer = new System.Windows.Forms.GroupBox();
            this.SuspendLayout();
            // 
            // mainContainer
            // 
            this.mainContainer.AutoSize = true;
            this.mainContainer.Location = new System.Drawing.Point(4, 4);
            this.mainContainer.Name = "mainContainer";
            this.mainContainer.Size = new System.Drawing.Size(384, 150);
            this.mainContainer.TabIndex = 0;
            this.mainContainer.TabStop = false;
            this.mainContainer.Text = "Tarifas";
            // 
            // ucInterJetFareConfirmationContainerControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.mainContainer);
            this.Name = "ucInterJetFareConfirmationContainerControl";
            this.Size = new System.Drawing.Size(393, 157);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox mainContainer;
    }
}
