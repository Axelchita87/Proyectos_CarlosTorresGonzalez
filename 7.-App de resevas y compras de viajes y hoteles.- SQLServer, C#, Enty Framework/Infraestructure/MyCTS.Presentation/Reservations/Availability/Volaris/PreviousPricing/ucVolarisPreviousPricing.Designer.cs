namespace MyCTS.Presentation
{
    partial class ucVolarisPreviousPricing
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
            this.mainContainer = new System.Windows.Forms.Panel();
            this.buttonPanel = new System.Windows.Forms.Panel();
            this.backButton = new System.Windows.Forms.Button();
            this.continueButton = new System.Windows.Forms.Button();
            this.loadingControl = new MyCTS.Presentation.Components.LoadingControl();
            this.waitingForControls1 = new MyCTS.Presentation.Components.WaitingForControls();
            this.volarisBanner1 = new MyCTS.Presentation.Reservations.Availability.Volaris.Banner.VolarisBanner();
            this.buttonPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(139)))), ((int)(((byte)(208)))));
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(2, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(390, 13);
            this.lblTitle.TabIndex = 2;
            this.lblTitle.Text = "Cotización Volaris";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // mainContainer
            // 
            this.mainContainer.AutoSize = true;
            this.mainContainer.Location = new System.Drawing.Point(5, 67);
            this.mainContainer.Name = "mainContainer";
            this.mainContainer.Size = new System.Drawing.Size(387, 19);
            this.mainContainer.TabIndex = 3;
            this.mainContainer.Visible = false;
            // 
            // buttonPanel
            // 
            this.buttonPanel.Controls.Add(this.backButton);
            this.buttonPanel.Controls.Add(this.continueButton);
            this.buttonPanel.Location = new System.Drawing.Point(218, 108);
            this.buttonPanel.Name = "buttonPanel";
            this.buttonPanel.Size = new System.Drawing.Size(174, 32);
            this.buttonPanel.TabIndex = 16;
            this.buttonPanel.Visible = false;
            // 
            // backButton
            // 
            this.backButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.backButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.backButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.backButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.backButton.Location = new System.Drawing.Point(3, 4);
            this.backButton.Name = "backButton";
            this.backButton.Size = new System.Drawing.Size(74, 25);
            this.backButton.TabIndex = 18;
            this.backButton.Text = "<Regresar";
            this.backButton.UseVisualStyleBackColor = false;
            this.backButton.Click += new System.EventHandler(this.backButton_Click);
            // 
            // continueButton
            // 
            this.continueButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.continueButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.continueButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.continueButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.continueButton.Location = new System.Drawing.Point(83, 3);
            this.continueButton.Name = "continueButton";
            this.continueButton.Size = new System.Drawing.Size(85, 25);
            this.continueButton.TabIndex = 17;
            this.continueButton.Text = "Continuar>";
            this.continueButton.UseVisualStyleBackColor = false;
            this.continueButton.Click += new System.EventHandler(this.continueButton_Click);
            // 
            // loadingControl
            // 
            this.loadingControl.BackColor = System.Drawing.Color.White;
            this.loadingControl.ImageToShow = null;
            this.loadingControl.Location = new System.Drawing.Point(68, 146);
            this.loadingControl.MessageToShow = "Cotizando espere por favor...";
            this.loadingControl.Name = "loadingControl";
            this.loadingControl.Size = new System.Drawing.Size(281, 195);
            this.loadingControl.TabIndex = 17;
            // 
            // waitingForControls1
            // 
            this.waitingForControls1.AutoSize = true;
            this.waitingForControls1.Location = new System.Drawing.Point(137, 215);
            this.waitingForControls1.MessageToShow = "Cargando...";
            this.waitingForControls1.Name = "waitingForControls1";
            this.waitingForControls1.Size = new System.Drawing.Size(90, 77);
            this.waitingForControls1.TabIndex = 18;
            this.waitingForControls1.Visible = false;
            // 
            // volarisBanner1
            // 
            this.volarisBanner1.AutoSize = true;
            this.volarisBanner1.Location = new System.Drawing.Point(3, 16);
            this.volarisBanner1.Name = "volarisBanner1";
            this.volarisBanner1.Size = new System.Drawing.Size(389, 47);
            this.volarisBanner1.TabIndex = 19;
            this.volarisBanner1.Visible = false;
            // 
            // ucVolarisPreviousPricing
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.Controls.Add(this.volarisBanner1);
            this.Controls.Add(this.waitingForControls1);
            this.Controls.Add(this.loadingControl);
            this.Controls.Add(this.buttonPanel);
            this.Controls.Add(this.mainContainer);
            this.Controls.Add(this.lblTitle);
            this.Name = "ucVolarisPreviousPricing";
            this.Size = new System.Drawing.Size(395, 473);
            this.Load += new System.EventHandler(this.ucVolarisPreviousPricing_Load);
            this.buttonPanel.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Panel mainContainer;
        private System.Windows.Forms.Panel buttonPanel;
        private System.Windows.Forms.Button backButton;
        private System.Windows.Forms.Button continueButton;
        private MyCTS.Presentation.Components.LoadingControl loadingControl;
        private MyCTS.Presentation.Components.WaitingForControls waitingForControls1;
        private MyCTS.Presentation.Reservations.Availability.Volaris.Banner.VolarisBanner volarisBanner1;

    }
}
