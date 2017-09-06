namespace MyCTS.Presentation
{
    partial class ucInterJetReservationConfirmationContainerControl
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.buttonPanel = new System.Windows.Forms.Panel();
            this.ContinueWithDkButton = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.MainContainer = new System.Windows.Forms.Panel();
            this.warningMessage1 = new MyCTS.Presentation.Components.WarningMessage();
            this.waitingLabel = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.progressBar = new GradProg.GradProg();
            this.pictureBoxReservation = new System.Windows.Forms.PictureBox();
            this.loadingPictureBox = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            this.buttonPanel.SuspendLayout();
            this.MainContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxReservation)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.loadingPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lblTitle);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(417, 16);
            this.panel1.TabIndex = 3;
            // 
            // lblTitle
            // 
            this.lblTitle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(139)))), ((int)(((byte)(208)))));
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(0, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(405, 13);
            this.lblTitle.TabIndex = 1;
            this.lblTitle.Text = "Paso 8/8 - Confirmación de la Reserva";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // buttonPanel
            // 
            this.buttonPanel.Controls.Add(this.ContinueWithDkButton);
            this.buttonPanel.Location = new System.Drawing.Point(296, 457);
            this.buttonPanel.Name = "buttonPanel";
            this.buttonPanel.Size = new System.Drawing.Size(97, 38);
            this.buttonPanel.TabIndex = 4;
            // 
            // ContinueWithDkButton
            // 
            this.ContinueWithDkButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.ContinueWithDkButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ContinueWithDkButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ContinueWithDkButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ContinueWithDkButton.Location = new System.Drawing.Point(9, 3);
            this.ContinueWithDkButton.Name = "ContinueWithDkButton";
            this.ContinueWithDkButton.Size = new System.Drawing.Size(85, 29);
            this.ContinueWithDkButton.TabIndex = 21;
            this.ContinueWithDkButton.Text = "Continuar>";
            this.ContinueWithDkButton.UseVisualStyleBackColor = false;
            this.ContinueWithDkButton.Click += new System.EventHandler(this.backToPassangerControlButton_Click);
            this.ContinueWithDkButton.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ContinueWithDkButton_KeyDown);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(229, 546);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 5;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Visible = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // MainContainer
            // 
            this.MainContainer.AutoSize = true;
            this.MainContainer.Controls.Add(this.warningMessage1);
            this.MainContainer.Controls.Add(this.buttonPanel);
            this.MainContainer.Controls.Add(this.button1);
            this.MainContainer.Location = new System.Drawing.Point(0, 16);
            this.MainContainer.Name = "MainContainer";
            this.MainContainer.Size = new System.Drawing.Size(405, 588);
            this.MainContainer.TabIndex = 6;
            // 
            // warningMessage1
            // 
            this.warningMessage1.Location = new System.Drawing.Point(3, 3);
            this.warningMessage1.Name = "warningMessage1";
            this.warningMessage1.Size = new System.Drawing.Size(396, 90);
            this.warningMessage1.TabIndex = 6;
            // 
            // waitingLabel
            // 
            this.waitingLabel.AutoSize = true;
            this.waitingLabel.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.waitingLabel.Location = new System.Drawing.Point(49, 292);
            this.waitingLabel.Name = "waitingLabel";
            this.waitingLabel.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.waitingLabel.Size = new System.Drawing.Size(287, 14);
            this.waitingLabel.TabIndex = 101;
            this.waitingLabel.Text = "Generando reservación espere por favor ..";
            this.waitingLabel.Visible = false;
            // 
            // progressBar
            // 
            this.progressBar.BackColor = System.Drawing.Color.White;
            this.progressBar.GradientStyle = System.Drawing.Drawing2D.LinearGradientMode.ForwardDiagonal;
            this.progressBar.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.progressBar.LabelBackColour = System.Drawing.Color.DimGray;
            this.progressBar.LabelForeColour = System.Drawing.Color.LightSeaGreen;
            this.progressBar.LabelPosition = new System.Drawing.Point(0, 0);
            this.progressBar.Location = new System.Drawing.Point(16, 316);
            this.progressBar.Maximum = 100;
            this.progressBar.Minimum = 0;
            this.progressBar.Name = "progressBar";
            this.progressBar.Percentage = 0;
            this.progressBar.ProgressBarBackColour = System.Drawing.Color.White;
            this.progressBar.ProgressBarForeColour = System.Drawing.Color.SteelBlue;
            this.progressBar.ShowLabel = false;
            this.progressBar.Size = new System.Drawing.Size(380, 26);
            this.progressBar.TabIndex = 100;
            this.progressBar.Value = 0;
            this.progressBar.Visible = false;
            // 
            // pictureBoxReservation
            // 
            this.pictureBoxReservation.Image = global::MyCTS.Presentation.Properties.Resources.rsz_1327971100_passport;
            this.pictureBoxReservation.Location = new System.Drawing.Point(108, 155);
            this.pictureBoxReservation.Name = "pictureBoxReservation";
            this.pictureBoxReservation.Size = new System.Drawing.Size(142, 134);
            this.pictureBoxReservation.TabIndex = 102;
            this.pictureBoxReservation.TabStop = false;
            this.pictureBoxReservation.Visible = false;
            // 
            // loadingPictureBox
            // 
            this.loadingPictureBox.Image = global::MyCTS.Presentation.Properties.Resources.loadingBlue;
            this.loadingPictureBox.Location = new System.Drawing.Point(48, 309);
            this.loadingPictureBox.Name = "loadingPictureBox";
            this.loadingPictureBox.Size = new System.Drawing.Size(267, 28);
            this.loadingPictureBox.TabIndex = 111;
            this.loadingPictureBox.TabStop = false;
            this.loadingPictureBox.Visible = false;
            // 
            // ucInterJetReservationConfirmationContainerControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.loadingPictureBox);
            this.Controls.Add(this.pictureBoxReservation);
            this.Controls.Add(this.waitingLabel);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.MainContainer);
            this.Controls.Add(this.panel1);
            this.Name = "ucInterJetReservationConfirmationContainerControl";
            this.Size = new System.Drawing.Size(420, 619);
            this.Load += new System.EventHandler(this.ucInterJetReservationConfirmationContainerControl_Load);
            this.panel1.ResumeLayout(false);
            this.buttonPanel.ResumeLayout(false);
            this.MainContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxReservation)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.loadingPictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        internal System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Panel buttonPanel;
        private System.Windows.Forms.Button ContinueWithDkButton;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel MainContainer;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label waitingLabel;
        private GradProg.GradProg progressBar;
        private System.Windows.Forms.PictureBox pictureBoxReservation;
        private System.Windows.Forms.PictureBox loadingPictureBox;
        private MyCTS.Presentation.Components.WarningMessage warningMessage1;
    }
}
