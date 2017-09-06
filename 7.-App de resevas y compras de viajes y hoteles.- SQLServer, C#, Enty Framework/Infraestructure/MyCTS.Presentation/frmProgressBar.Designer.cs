namespace MyCTS.Presentation
{
    partial class frmProgressBar
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

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido del método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.prbUpdate = new System.Windows.Forms.ProgressBar();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // prbUpdate
            // 
            this.prbUpdate.Location = new System.Drawing.Point(13, 13);
            this.prbUpdate.Name = "prbUpdate";
            this.prbUpdate.Size = new System.Drawing.Size(393, 23);
            this.prbUpdate.Step = 1;
            this.prbUpdate.TabIndex = 0;
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // frmProgressBar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(418, 50);
            this.Controls.Add(this.prbUpdate);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmProgressBar";
            this.Text = "Actualizando la Versión de MyCTS espere por favor. . . . . . .";
            this.Shown += new System.EventHandler(this.frmProgressBar_Shown);
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.ProgressBar prbUpdate;
        private System.Windows.Forms.Timer timer1;
    }
}