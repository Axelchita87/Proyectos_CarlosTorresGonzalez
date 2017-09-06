namespace MyCTS.Presentation
{
    partial class ucTicketEmissionBuildCommand
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
            this.lblEmitingTicket = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblEmitingTicket
            // 
            this.lblEmitingTicket.AutoSize = true;
            this.lblEmitingTicket.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEmitingTicket.ForeColor = System.Drawing.SystemColors.Desktop;
            this.lblEmitingTicket.Location = new System.Drawing.Point(101, 229);
            this.lblEmitingTicket.Name = "lblEmitingTicket";
            this.lblEmitingTicket.Size = new System.Drawing.Size(192, 25);
            this.lblEmitingTicket.TabIndex = 0;
            this.lblEmitingTicket.Text = "Emitiendo Boleto...";
            this.lblEmitingTicket.Visible = false;
            // 
            // ucTicketEmissionBuildCommand
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.lblEmitingTicket);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "ucTicketEmissionBuildCommand";
            this.Size = new System.Drawing.Size(411, 580);
            this.Load += new System.EventHandler(this.ucTicketEmissionBuildCommand_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblEmitingTicket;
    }
}
