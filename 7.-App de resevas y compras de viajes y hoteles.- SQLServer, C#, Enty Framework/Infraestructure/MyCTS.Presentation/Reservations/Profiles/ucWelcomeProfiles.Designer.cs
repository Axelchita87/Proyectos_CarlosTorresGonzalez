namespace MyCTS.Presentation
{
    partial class ucWelcomeProfiles
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucWelcomeProfiles));
            //this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lblTitle = new System.Windows.Forms.Label();
            this.linkPrivacy = new System.Windows.Forms.LinkLabel();
            
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.ForeColor = System.Drawing.Color.Blue;
            this.lblTitle.Location = new System.Drawing.Point(57, 38);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(370, 150);
            this.lblTitle.TabIndex = 13;
            this.lblTitle.Text = resources.GetString("lblTitle.Text");
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // linkPrivacy
            // 
            this.linkPrivacy.AutoSize = true;
            this.linkPrivacy.LinkColor = System.Drawing.Color.Purple;
            this.linkPrivacy.Location = new System.Drawing.Point(57, 202);
            this.linkPrivacy.Name = "linkPrivacy";
            this.linkPrivacy.Size = new System.Drawing.Size(193, 13);
            this.linkPrivacy.TabIndex = 14;
            this.linkPrivacy.TabStop = true;
            this.linkPrivacy.Text = "Consulta nuestra Política de Privacidad";
            this.linkPrivacy.Click += new System.EventHandler(this.linkPrivacy_Click);
            // 
            // ucWelcomeProfiles
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.GhostWhite;
            this.Controls.Add(this.linkPrivacy);
            this.Controls.Add(this.lblTitle);
            
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "ucWelcomeProfiles";
            this.Size = new System.Drawing.Size(492, 298);
            this.Load += new System.EventHandler(this.ucWelcomeProflies_Load);
            
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.LinkLabel linkPrivacy;
    }
}
