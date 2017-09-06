namespace MyCTS.Presentation
{
    partial class ucVolarisPassangerCapture
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
            this.components = new System.ComponentModel.Container();
            this.lblTitle = new System.Windows.Forms.Label();
            this.waitingForControls1 = new MyCTS.Presentation.Components.WaitingForControls();
            this.buttonPanel = new System.Windows.Forms.Panel();
            this.backButton = new System.Windows.Forms.Button();
            this.continueButton = new System.Windows.Forms.Button();
            this.volarisBanner1 = new MyCTS.Presentation.Reservations.Availability.Volaris.Banner.VolarisBanner();
            this.container = new System.Windows.Forms.Panel();
            this.defaultLookAndFeel1 = new DevExpress.LookAndFeel.DefaultLookAndFeel(this.components);
            this.loadingControl1 = new MyCTS.Presentation.Components.LoadingControl();
            this.ucVolarisErrorRecovery1 = new MyCTS.Presentation.Reservations.Availability.Volaris.ErrorRecovery.ucVolarisErrorRecovery();
            this.buttonPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(139)))), ((int)(((byte)(208)))));
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(3, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(395, 13);
            this.lblTitle.TabIndex = 3;
            this.lblTitle.Text = "Captura de Pasajeros";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // waitingForControls1
            // 
            this.waitingForControls1.AutoSize = true;
            this.waitingForControls1.BackColor = System.Drawing.Color.Transparent;
            this.waitingForControls1.Location = new System.Drawing.Point(149, 211);
            this.waitingForControls1.MessageToShow = "Cargando...";
            this.waitingForControls1.Name = "waitingForControls1";
            this.waitingForControls1.Size = new System.Drawing.Size(90, 77);
            this.waitingForControls1.TabIndex = 4;
            // 
            // buttonPanel
            // 
            this.buttonPanel.Controls.Add(this.backButton);
            this.buttonPanel.Controls.Add(this.continueButton);
            this.buttonPanel.Location = new System.Drawing.Point(226, 83);
            this.buttonPanel.Name = "buttonPanel";
            this.buttonPanel.Size = new System.Drawing.Size(172, 32);
            this.buttonPanel.TabIndex = 17;
            this.buttonPanel.Visible = false;
            // 
            // backButton
            // 
            this.backButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.backButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.backButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.backButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.backButton.Location = new System.Drawing.Point(3, 3);
            this.backButton.Name = "backButton";
            this.backButton.Size = new System.Drawing.Size(74, 25);
            this.backButton.TabIndex = 18;
            this.backButton.Text = "<Regresar";
            this.backButton.UseVisualStyleBackColor = false;
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
            // 
            // volarisBanner1
            // 
            this.volarisBanner1.AutoSize = true;
            this.volarisBanner1.Location = new System.Drawing.Point(6, 16);
            this.volarisBanner1.Name = "volarisBanner1";
            this.volarisBanner1.Size = new System.Drawing.Size(388, 49);
            this.volarisBanner1.TabIndex = 18;
            this.volarisBanner1.Visible = false;
            // 
            // container
            // 
            this.container.AutoSize = true;
            this.container.Location = new System.Drawing.Point(3, 68);
            this.container.Name = "container";
            this.container.Size = new System.Drawing.Size(391, 12);
            this.container.TabIndex = 19;
            // 
            // defaultLookAndFeel1
            // 
            this.defaultLookAndFeel1.LookAndFeel.SkinName = "Metropolis";
            // 
            // loadingControl1
            // 
            this.loadingControl1.BackColor = System.Drawing.Color.White;
            this.loadingControl1.ImageToShow = null;
            this.loadingControl1.Location = new System.Drawing.Point(47, 148);
            this.loadingControl1.MessageToShow = "";
            this.loadingControl1.Name = "loadingControl1";
            this.loadingControl1.Size = new System.Drawing.Size(281, 195);
            this.loadingControl1.TabIndex = 20;
            this.loadingControl1.Visible = false;
            // 
            // ucVolarisErrorRecovery1
            // 
            this.ucVolarisErrorRecovery1.AutoSize = true;
            this.ucVolarisErrorRecovery1.Error = null;
            this.ucVolarisErrorRecovery1.Location = new System.Drawing.Point(0, 148);
            this.ucVolarisErrorRecovery1.Name = "ucVolarisErrorRecovery1";
            this.ucVolarisErrorRecovery1.Size = new System.Drawing.Size(396, 218);
            this.ucVolarisErrorRecovery1.TabIndex = 21;
            this.ucVolarisErrorRecovery1.Visible = false;
            // 
            // ucVolarisPassangerCapture
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.ucVolarisErrorRecovery1);
            this.Controls.Add(this.loadingControl1);
            this.Controls.Add(this.container);
            this.Controls.Add(this.volarisBanner1);
            this.Controls.Add(this.buttonPanel);
            this.Controls.Add(this.waitingForControls1);
            this.Controls.Add(this.lblTitle);
            this.ForeColor = System.Drawing.Color.Black;
            this.Name = "ucVolarisPassangerCapture";
            this.Size = new System.Drawing.Size(401, 499);
            this.Load += new System.EventHandler(this.ucVolarisPassangerCapture_Load);
            this.buttonPanel.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.Label lblTitle;
        private MyCTS.Presentation.Components.WaitingForControls waitingForControls1;
        private System.Windows.Forms.Panel buttonPanel;
        private System.Windows.Forms.Button backButton;
        private System.Windows.Forms.Button continueButton;
        private MyCTS.Presentation.Reservations.Availability.Volaris.Banner.VolarisBanner volarisBanner1;
        private System.Windows.Forms.Panel container;
        private DevExpress.LookAndFeel.DefaultLookAndFeel defaultLookAndFeel1;
        private MyCTS.Presentation.Components.LoadingControl loadingControl1;
        private MyCTS.Presentation.Reservations.Availability.Volaris.ErrorRecovery.ucVolarisErrorRecovery ucVolarisErrorRecovery1;
    }
}
