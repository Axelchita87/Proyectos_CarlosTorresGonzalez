namespace MyCTS.Presentation
{
    partial class ucLowFareAvailability
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
            this.buttonPanel = new System.Windows.Forms.Panel();
            this.backButton = new System.Windows.Forms.Button();
            this.continueButton = new System.Windows.Forms.Button();
            this.panelContainer = new System.Windows.Forms.Panel();
            this.animationPanel = new System.Windows.Forms.Panel();
            this.loadingControl1 = new MyCTS.Presentation.Components.LoadingControl();
            this.waitingForControls1 = new MyCTS.Presentation.Components.WaitingForControls();
            this.buttonPanel.SuspendLayout();
            this.animationPanel.SuspendLayout();
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
            this.lblTitle.Text = "Disponibilidad";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // buttonPanel
            // 
            this.buttonPanel.Controls.Add(this.backButton);
            this.buttonPanel.Controls.Add(this.continueButton);
            this.buttonPanel.Location = new System.Drawing.Point(190, 56);
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
            this.continueButton.Location = new System.Drawing.Point(83, 4);
            this.continueButton.Name = "continueButton";
            this.continueButton.Size = new System.Drawing.Size(85, 25);
            this.continueButton.TabIndex = 17;
            this.continueButton.Text = "Continuar>";
            this.continueButton.UseVisualStyleBackColor = false;
            this.continueButton.Click += new System.EventHandler(this.continueButton_Click);
            // 
            // panelContainer
            // 
            this.panelContainer.AutoSize = true;
            this.panelContainer.Location = new System.Drawing.Point(6, 16);
            this.panelContainer.Name = "panelContainer";
            this.panelContainer.Size = new System.Drawing.Size(399, 23);
            this.panelContainer.TabIndex = 17;
            this.panelContainer.Visible = false;
            // 
            // animationPanel
            // 
            this.animationPanel.Controls.Add(this.loadingControl1);
            this.animationPanel.Location = new System.Drawing.Point(48, 153);
            this.animationPanel.Name = "animationPanel";
            this.animationPanel.Size = new System.Drawing.Size(291, 203);
            this.animationPanel.TabIndex = 18;
            // 
            // loadingControl1
            // 
            this.loadingControl1.BackColor = System.Drawing.Color.White;
            this.loadingControl1.ImageToShow = null;
            this.loadingControl1.Location = new System.Drawing.Point(3, 5);
            this.loadingControl1.MessageToShow = "Buscando vuelos...";
            this.loadingControl1.Name = "loadingControl1";
            this.loadingControl1.Size = new System.Drawing.Size(281, 195);
            this.loadingControl1.TabIndex = 0;
            // 
            // waitingForControls1
            // 
            this.waitingForControls1.Location = new System.Drawing.Point(130, 210);
            this.waitingForControls1.Name = "waitingForControls1";
            this.waitingForControls1.Size = new System.Drawing.Size(90, 77);
            this.waitingForControls1.TabIndex = 19;
            this.waitingForControls1.Visible = false;
            // 
            // ucLowFareAvailability
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.Controls.Add(this.waitingForControls1);
            this.Controls.Add(this.buttonPanel);
            this.Controls.Add(this.animationPanel);
            this.Controls.Add(this.panelContainer);
            this.Controls.Add(this.lblTitle);
            this.Name = "ucLowFareAvailability";
            this.Size = new System.Drawing.Size(493, 610);
            this.Load += new System.EventHandler(this.ucLowFareAvailability_Load);
            this.buttonPanel.ResumeLayout(false);
            this.animationPanel.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Panel buttonPanel;
        private System.Windows.Forms.Button backButton;
        private System.Windows.Forms.Button continueButton;
        private System.Windows.Forms.Panel panelContainer;
        private System.Windows.Forms.Panel animationPanel;
        private MyCTS.Presentation.Components.LoadingControl loadingControl1;
        private MyCTS.Presentation.Components.WaitingForControls waitingForControls1;


    }
}
