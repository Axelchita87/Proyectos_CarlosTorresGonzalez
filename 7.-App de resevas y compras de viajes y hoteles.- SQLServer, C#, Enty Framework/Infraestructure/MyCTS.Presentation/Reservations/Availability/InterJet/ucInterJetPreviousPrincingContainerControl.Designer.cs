namespace MyCTS.Presentation
{
    partial class ucInterJetPreviousPrincingContainerControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucInterJetPreviousPrincingContainerControl));
            this.lblTitle = new System.Windows.Forms.Label();
            this.progressbar = new GradProg.GradProg();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.mainPanel = new System.Windows.Forms.Panel();
            this.princingPictureBox = new System.Windows.Forms.PictureBox();
            this.totalPricePanel = new System.Windows.Forms.Panel();
            this.totalPriceLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonsPanel = new System.Windows.Forms.Panel();
            this.lblPurseElectronicDisponible = new System.Windows.Forms.Label();
            this.lblPurseElectronic = new System.Windows.Forms.Label();
            this.goBackButton = new System.Windows.Forms.Button();
            this.continueToPassangerControl = new System.Windows.Forms.Button();
            this.loadingLabel = new System.Windows.Forms.Label();
            this.loadingPictureBox = new System.Windows.Forms.PictureBox();
            this.mainPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.princingPictureBox)).BeginInit();
            this.totalPricePanel.SuspendLayout();
            this.buttonsPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.loadingPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(139)))), ((int)(((byte)(208)))));
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(3, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(394, 13);
            this.lblTitle.TabIndex = 2;
            this.lblTitle.Text = "Paso 2/8 - Cotización ";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // progressbar
            // 
            this.progressbar.BackColor = System.Drawing.Color.White;
            this.progressbar.GradientStyle = System.Drawing.Drawing2D.LinearGradientMode.ForwardDiagonal;
            this.progressbar.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.progressbar.LabelBackColour = System.Drawing.Color.DimGray;
            this.progressbar.LabelForeColour = System.Drawing.Color.LightSeaGreen;
            this.progressbar.LabelPosition = new System.Drawing.Point(0, 0);
            this.progressbar.Location = new System.Drawing.Point(3, 355);
            this.progressbar.Maximum = 100;
            this.progressbar.Minimum = 0;
            this.progressbar.Name = "progressbar";
            this.progressbar.Percentage = 0;
            this.progressbar.ProgressBarBackColour = System.Drawing.Color.White;
            this.progressbar.ProgressBarForeColour = System.Drawing.Color.SteelBlue;
            this.progressbar.ShowLabel = false;
            this.progressbar.Size = new System.Drawing.Size(394, 26);
            this.progressbar.TabIndex = 103;
            this.progressbar.Value = 0;
            this.progressbar.Visible = false;
            // 
            // mainPanel
            // 
            this.mainPanel.AutoSize = true;
            this.mainPanel.Controls.Add(this.princingPictureBox);
            this.mainPanel.Controls.Add(this.totalPricePanel);
            this.mainPanel.Controls.Add(this.buttonsPanel);
            this.mainPanel.Location = new System.Drawing.Point(3, 16);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Size = new System.Drawing.Size(397, 313);
            this.mainPanel.TabIndex = 104;
            // 
            // princingPictureBox
            // 
            this.princingPictureBox.Image = ((System.Drawing.Image)(resources.GetObject("princingPictureBox.Image")));
            this.princingPictureBox.Location = new System.Drawing.Point(111, 129);
            this.princingPictureBox.Name = "princingPictureBox";
            this.princingPictureBox.Size = new System.Drawing.Size(129, 129);
            this.princingPictureBox.TabIndex = 107;
            this.princingPictureBox.TabStop = false;
            // 
            // totalPricePanel
            // 
            this.totalPricePanel.Controls.Add(this.totalPriceLabel);
            this.totalPricePanel.Controls.Add(this.label1);
            this.totalPricePanel.Location = new System.Drawing.Point(181, 210);
            this.totalPricePanel.Name = "totalPricePanel";
            this.totalPricePanel.Size = new System.Drawing.Size(200, 37);
            this.totalPricePanel.TabIndex = 106;
            // 
            // totalPriceLabel
            // 
            this.totalPriceLabel.AutoSize = true;
            this.totalPriceLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.totalPriceLabel.Location = new System.Drawing.Point(93, 13);
            this.totalPriceLabel.Name = "totalPriceLabel";
            this.totalPriceLabel.Size = new System.Drawing.Size(71, 13);
            this.totalPriceLabel.TabIndex = 1;
            this.totalPriceLabel.Text = "$14,350.00";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.DarkBlue;
            this.label1.Location = new System.Drawing.Point(3, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Precio Total :";
            // 
            // buttonsPanel
            // 
            this.buttonsPanel.Controls.Add(this.lblPurseElectronicDisponible);
            this.buttonsPanel.Controls.Add(this.lblPurseElectronic);
            this.buttonsPanel.Controls.Add(this.goBackButton);
            this.buttonsPanel.Controls.Add(this.continueToPassangerControl);
            this.buttonsPanel.Location = new System.Drawing.Point(171, 253);
            this.buttonsPanel.Name = "buttonsPanel";
            this.buttonsPanel.Size = new System.Drawing.Size(212, 57);
            this.buttonsPanel.TabIndex = 105;
            this.buttonsPanel.Visible = false;
            // 
            // lblPurseElectronicDisponible
            // 
            this.lblPurseElectronicDisponible.AutoSize = true;
            this.lblPurseElectronicDisponible.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPurseElectronicDisponible.ForeColor = System.Drawing.Color.DarkBlue;
            this.lblPurseElectronicDisponible.Location = new System.Drawing.Point(14, 8);
            this.lblPurseElectronicDisponible.Name = "lblPurseElectronicDisponible";
            this.lblPurseElectronicDisponible.Size = new System.Drawing.Size(124, 13);
            this.lblPurseElectronicDisponible.TabIndex = 110;
            this.lblPurseElectronicDisponible.Text = "Cantidad Disponible:";
            // 
            // lblPurseElectronic
            // 
            this.lblPurseElectronic.AutoSize = true;
            this.lblPurseElectronic.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPurseElectronic.Location = new System.Drawing.Point(137, 8);
            this.lblPurseElectronic.Name = "lblPurseElectronic";
            this.lblPurseElectronic.Size = new System.Drawing.Size(61, 13);
            this.lblPurseElectronic.TabIndex = 111;
            this.lblPurseElectronic.Text = "$25,000.00";
            // 
            // goBackButton
            // 
            this.goBackButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.goBackButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.goBackButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.goBackButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.goBackButton.Location = new System.Drawing.Point(6, 26);
            this.goBackButton.Name = "goBackButton";
            this.goBackButton.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.goBackButton.Size = new System.Drawing.Size(99, 26);
            this.goBackButton.TabIndex = 22;
            this.goBackButton.Text = "<Regresar";
            this.goBackButton.UseVisualStyleBackColor = false;
            this.goBackButton.Click += new System.EventHandler(this.goBackButton_Click);
            this.goBackButton.KeyDown += new System.Windows.Forms.KeyEventHandler(this.goBackButton_KeyDown);
            // 
            // continueToPassangerControl
            // 
            this.continueToPassangerControl.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.continueToPassangerControl.Cursor = System.Windows.Forms.Cursors.Hand;
            this.continueToPassangerControl.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.continueToPassangerControl.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.continueToPassangerControl.Location = new System.Drawing.Point(111, 26);
            this.continueToPassangerControl.Name = "continueToPassangerControl";
            this.continueToPassangerControl.Size = new System.Drawing.Size(97, 26);
            this.continueToPassangerControl.TabIndex = 19;
            this.continueToPassangerControl.Text = "Continuar>";
            this.continueToPassangerControl.UseVisualStyleBackColor = false;
            this.continueToPassangerControl.Click += new System.EventHandler(this.continueToPassangerControl_Click);
            this.continueToPassangerControl.KeyDown += new System.Windows.Forms.KeyEventHandler(this.continueToPassangerControl_KeyDown);
            // 
            // loadingLabel
            // 
            this.loadingLabel.AutoSize = true;
            this.loadingLabel.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold);
            this.loadingLabel.Location = new System.Drawing.Point(111, 292);
            this.loadingLabel.Name = "loadingLabel";
            this.loadingLabel.Size = new System.Drawing.Size(128, 14);
            this.loadingLabel.TabIndex = 108;
            this.loadingLabel.Text = "Cotizando Vuelos..";
            // 
            // loadingPictureBox
            // 
            this.loadingPictureBox.Image = ((System.Drawing.Image)(resources.GetObject("loadingPictureBox.Image")));
            this.loadingPictureBox.Location = new System.Drawing.Point(71, 321);
            this.loadingPictureBox.Name = "loadingPictureBox";
            this.loadingPictureBox.Size = new System.Drawing.Size(267, 28);
            this.loadingPictureBox.TabIndex = 109;
            this.loadingPictureBox.TabStop = false;
            this.loadingPictureBox.Visible = false;
            // 
            // ucInterJetPreviousPrincingContainerControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.loadingPictureBox);
            this.Controls.Add(this.loadingLabel);
            this.Controls.Add(this.mainPanel);
            this.Controls.Add(this.progressbar);
            this.Controls.Add(this.lblTitle);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Name = "ucInterJetPreviousPrincingContainerControl";
            this.Size = new System.Drawing.Size(403, 451);
            this.Load += new System.EventHandler(this.ucInterJetPreviousPrincingContainerControl_Load);
            this.mainPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.princingPictureBox)).EndInit();
            this.totalPricePanel.ResumeLayout(false);
            this.totalPricePanel.PerformLayout();
            this.buttonsPanel.ResumeLayout(false);
            this.buttonsPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.loadingPictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.Label lblTitle;

        private GradProg.GradProg progressbar;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Panel mainPanel;
        private System.Windows.Forms.Panel buttonsPanel;
        private System.Windows.Forms.Button goBackButton;
        private System.Windows.Forms.Button continueToPassangerControl;
        private System.Windows.Forms.Label loadingLabel;
        private System.Windows.Forms.Panel totalPricePanel;
        private System.Windows.Forms.Label totalPriceLabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblPurseElectronicDisponible;
        private System.Windows.Forms.Label lblPurseElectronic;
        private System.Windows.Forms.PictureBox princingPictureBox;
        private System.Windows.Forms.PictureBox loadingPictureBox;
    }
}

