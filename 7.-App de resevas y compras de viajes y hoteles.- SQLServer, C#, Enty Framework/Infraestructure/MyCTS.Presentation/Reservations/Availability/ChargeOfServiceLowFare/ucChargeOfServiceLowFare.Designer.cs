namespace MyCTS.Presentation
{
    partial class ucChargeOfServiceLowFare
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
            this.lblTitle = new System.Windows.Forms.Label();
            this.container = new System.Windows.Forms.Panel();
            this.waitingForControls1 = new MyCTS.Presentation.Components.WaitingForControls();
            this.buttonPanel = new System.Windows.Forms.Panel();
            this.continueButton = new System.Windows.Forms.Button();
            this.lblLeyendaIva = new System.Windows.Forms.Label();
            this.buttonPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTitle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(139)))), ((int)(((byte)(208)))));
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(3, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(395, 13);
            this.lblTitle.TabIndex = 14;
            this.lblTitle.Text = "Cargo por Servicio";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // container
            // 
            this.container.AutoSize = true;
            this.container.Location = new System.Drawing.Point(6, 34);
            this.container.Name = "container";
            this.container.Size = new System.Drawing.Size(392, 37);
            this.container.TabIndex = 15;
            this.container.Visible = false;
            // 
            // waitingForControls1
            // 
            this.waitingForControls1.AutoSize = true;
            this.waitingForControls1.Location = new System.Drawing.Point(149, 155);
            this.waitingForControls1.MessageToShow = "Cargando...";
            this.waitingForControls1.Name = "waitingForControls1";
            this.waitingForControls1.Size = new System.Drawing.Size(87, 71);
            this.waitingForControls1.TabIndex = 16;
            // 
            // buttonPanel
            // 
            this.buttonPanel.Controls.Add(this.continueButton);
            this.buttonPanel.Location = new System.Drawing.Point(196, 405);
            this.buttonPanel.Name = "buttonPanel";
            this.buttonPanel.Size = new System.Drawing.Size(174, 32);
            this.buttonPanel.TabIndex = 17;
            this.buttonPanel.Visible = false;
            // 
            // continueButton
            // 
            this.continueButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.continueButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.continueButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.continueButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.continueButton.Location = new System.Drawing.Point(84, 6);
            this.continueButton.Name = "continueButton";
            this.continueButton.Size = new System.Drawing.Size(85, 25);
            this.continueButton.TabIndex = 17;
            this.continueButton.Text = "Continuar>";
            this.continueButton.UseVisualStyleBackColor = false;
            this.continueButton.Click += new System.EventHandler(this.continueButton_Click);
            // 
            // lblLeyendaIva
            // 
            this.lblLeyendaIva.AutoSize = true;
            this.lblLeyendaIva.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLeyendaIva.ForeColor = System.Drawing.Color.Red;
            this.lblLeyendaIva.Location = new System.Drawing.Point(3, 18);
            this.lblLeyendaIva.Name = "lblLeyendaIva";
            this.lblLeyendaIva.Size = new System.Drawing.Size(367, 13);
            this.lblLeyendaIva.TabIndex = 220;
            this.lblLeyendaIva.Text = "EL SISTEMA AUTOMATICAMENTE INCLUIRA EL IVA DEL 16%";
            this.lblLeyendaIva.Visible = false;
            // 
            // ucChargeOfServiceLowFare
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.AutoSize = true;
            this.Controls.Add(this.lblLeyendaIva);
            this.Controls.Add(this.buttonPanel);
            this.Controls.Add(this.waitingForControls1);
            this.Controls.Add(this.container);
            this.Controls.Add(this.lblTitle);
            this.Name = "ucChargeOfServiceLowFare";
            this.Size = new System.Drawing.Size(401, 440);
            this.Load += new System.EventHandler(this.ucChargeOfServiceLowFare_Load);
            this.buttonPanel.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Panel container;
        private MyCTS.Presentation.Components.WaitingForControls waitingForControls1;
        private System.Windows.Forms.Panel buttonPanel;
        private System.Windows.Forms.Button continueButton;
        private System.Windows.Forms.Label lblLeyendaIva;
    }
}
