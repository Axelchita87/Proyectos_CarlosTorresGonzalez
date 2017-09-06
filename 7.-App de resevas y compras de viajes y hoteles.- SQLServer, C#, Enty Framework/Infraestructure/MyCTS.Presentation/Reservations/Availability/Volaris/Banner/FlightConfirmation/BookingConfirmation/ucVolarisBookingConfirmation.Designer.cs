namespace MyCTS.Presentation
{
    partial class ucVolarisBookingConfirmation
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
            this.volarisBanner1 = new MyCTS.Presentation.Reservations.Availability.Volaris.Banner.VolarisBanner();
            this.lblTitle = new System.Windows.Forms.Label();
            this.container = new System.Windows.Forms.Panel();
            this.waitingForControls1 = new MyCTS.Presentation.Components.WaitingForControls();
            this.button1 = new System.Windows.Forms.Button();
            this.buttonsPanelToHide = new System.Windows.Forms.Panel();
            this.continueButton = new System.Windows.Forms.Button();
            this.buttonsPanelToHide.SuspendLayout();
            this.SuspendLayout();
            // 
            // volarisBanner1
            // 
            this.volarisBanner1.AutoSize = true;
            this.volarisBanner1.Location = new System.Drawing.Point(6, 16);
            this.volarisBanner1.Name = "volarisBanner1";
            this.volarisBanner1.Size = new System.Drawing.Size(289, 49);
            this.volarisBanner1.TabIndex = 0;
            // 
            // lblTitle
            // 
            this.lblTitle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(139)))), ((int)(((byte)(208)))));
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(3, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(390, 13);
            this.lblTitle.TabIndex = 22;
            this.lblTitle.Text = "Confirmación de Reserva.";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // container
            // 
            this.container.AutoSize = true;
            this.container.Location = new System.Drawing.Point(0, 99);
            this.container.Name = "container";
            this.container.Size = new System.Drawing.Size(393, 14);
            this.container.TabIndex = 23;
            this.container.Visible = false;
            // 
            // waitingForControls1
            // 
            this.waitingForControls1.AutoSize = true;
            this.waitingForControls1.Location = new System.Drawing.Point(132, 141);
            this.waitingForControls1.MessageToShow = "Cargando...";
            this.waitingForControls1.Name = "waitingForControls1";
            this.waitingForControls1.Size = new System.Drawing.Size(90, 77);
            this.waitingForControls1.TabIndex = 25;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(51, 70);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 26;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Visible = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // buttonsPanelToHide
            // 
            this.buttonsPanelToHide.Controls.Add(this.continueButton);
            this.buttonsPanelToHide.Location = new System.Drawing.Point(23, 357);
            this.buttonsPanelToHide.Name = "buttonsPanelToHide";
            this.buttonsPanelToHide.Size = new System.Drawing.Size(370, 33);
            this.buttonsPanelToHide.TabIndex = 27;
            this.buttonsPanelToHide.Visible = false;
            // 
            // continueButton
            // 
            this.continueButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.continueButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.continueButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.continueButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.continueButton.Location = new System.Drawing.Point(252, 0);
            this.continueButton.Name = "continueButton";
            this.continueButton.Size = new System.Drawing.Size(115, 29);
            this.continueButton.TabIndex = 19;
            this.continueButton.Text = "Continuar>";
            this.continueButton.UseVisualStyleBackColor = false;
            this.continueButton.Click += new System.EventHandler(this.continueButton_Click);
            // 
            // ucVolarisBookingConfirmation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.Controls.Add(this.buttonsPanelToHide);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.waitingForControls1);
            this.Controls.Add(this.container);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.volarisBanner1);
            this.Name = "ucVolarisBookingConfirmation";
            this.Size = new System.Drawing.Size(413, 423);
            this.Load += new System.EventHandler(this.ucVolarisBookingConfirmation_Load);
            this.buttonsPanelToHide.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MyCTS.Presentation.Reservations.Availability.Volaris.Banner.VolarisBanner volarisBanner1;
        public System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Panel container;
        private MyCTS.Presentation.Components.WaitingForControls waitingForControls1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel buttonsPanelToHide;
        private System.Windows.Forms.Button continueButton;
    }
}
