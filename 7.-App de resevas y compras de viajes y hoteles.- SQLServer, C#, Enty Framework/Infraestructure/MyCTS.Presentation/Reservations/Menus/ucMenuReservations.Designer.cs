namespace MyCTS.Presentation
{
    partial class ucMenuReservations
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
            menuStrip1 = new MyCTS.Forms.UI.MenuStripEnhanced();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            ucMenuReservations.menuStrip1.BackColor = System.Drawing.Color.LightGray;
            ucMenuReservations.menuStrip1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            ucMenuReservations.menuStrip1.Form = null;
            ucMenuReservations.menuStrip1.Location = new System.Drawing.Point(0, 0);
            ucMenuReservations.menuStrip1.Name = "menuStrip1";
            ucMenuReservations.menuStrip1.ShowItemToolTips = true;
            ucMenuReservations.menuStrip1.AutoSize = false;
            ucMenuReservations.menuStrip1.Size = new System.Drawing.Size(300, 24);
            ucMenuReservations.menuStrip1.TabIndex = 1;
            ucMenuReservations.menuStrip1.Text = "menuStrip1";
            // 
            // ucMenuReservations
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = false;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(ucMenuReservations.menuStrip1);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "ucMenuReservations";
            this.Size = new System.Drawing.Size(300, 24);
            this.Load += new System.EventHandler(this.ucMenuReservations_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private static MyCTS.Forms.UI.MenuStripEnhanced menuStrip1;
    }
}
