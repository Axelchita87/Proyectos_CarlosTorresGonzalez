namespace MyCTS.Presentation.Reservations.Availability.InterJet.PaymentHandlers
{
    partial class frmInterJetReservationConfirmation
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.mainContainer = new System.Windows.Forms.Panel();
            this.faresGroupBox = new System.Windows.Forms.GroupBox();
            this.pricingLabel = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.segmentsLabel = new System.Windows.Forms.Label();
            this.passangerGroupBox = new System.Windows.Forms.GroupBox();
            this.passangersLabel = new System.Windows.Forms.Label();
            this.acceptButton = new System.Windows.Forms.Button();
            this.emissionTimeLabel = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.mainContainer.SuspendLayout();
            this.faresGroupBox.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.passangerGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainContainer
            // 
            this.mainContainer.AutoSize = true;
            this.mainContainer.Controls.Add(this.faresGroupBox);
            this.mainContainer.Controls.Add(this.groupBox1);
            this.mainContainer.Controls.Add(this.passangerGroupBox);
            this.mainContainer.Controls.Add(this.acceptButton);
            this.mainContainer.Controls.Add(this.emissionTimeLabel);
            this.mainContainer.Controls.Add(this.label3);
            this.mainContainer.Location = new System.Drawing.Point(1, 4);
            this.mainContainer.Name = "mainContainer";
            this.mainContainer.Size = new System.Drawing.Size(549, 423);
            this.mainContainer.TabIndex = 0;
            // 
            // faresGroupBox
            // 
            this.faresGroupBox.Controls.Add(this.pricingLabel);
            this.faresGroupBox.Location = new System.Drawing.Point(32, 266);
            this.faresGroupBox.Name = "faresGroupBox";
            this.faresGroupBox.Size = new System.Drawing.Size(495, 12);
            this.faresGroupBox.TabIndex = 8;
            this.faresGroupBox.TabStop = false;
            this.faresGroupBox.Text = "Tarifas";
            // 
            // pricingLabel
            // 
            this.pricingLabel.AutoSize = true;
            this.pricingLabel.Location = new System.Drawing.Point(6, 25);
            this.pricingLabel.Name = "pricingLabel";
            this.pricingLabel.Size = new System.Drawing.Size(145, 52);
            this.pricingLabel.TabIndex = 5;
            this.pricingLabel.Text = "Tarifa Base MXN ({0}-{1}) {2}\r\nTUA XV ({3}-{4}) {5}\r\nIVA MX ({6}-{7})  {8}\r\nTarif" +
                "a Total {9}";
            // 
            // groupBox1
            // 
            this.groupBox1.AutoSize = true;
            this.groupBox1.Controls.Add(this.segmentsLabel);
            this.groupBox1.Location = new System.Drawing.Point(32, 139);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(495, 110);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Vuelos";
            // 
            // segmentsLabel
            // 
            this.segmentsLabel.AutoSize = true;
            this.segmentsLabel.Location = new System.Drawing.Point(6, 16);
            this.segmentsLabel.Name = "segmentsLabel";
            this.segmentsLabel.Size = new System.Drawing.Size(122, 78);
            this.segmentsLabel.TabIndex = 0;
            this.segmentsLabel.Text = "MID a MEX                    \r\n------------------------- \r\nSegmento: MID-MEX\r\nNo." +
                " Vuelo: 2523\r\nFecha: 10/09/2011\r\nHora : 06:35 - 08:25";
            // 
            // passangerGroupBox
            // 
            this.passangerGroupBox.AutoSize = true;
            this.passangerGroupBox.Controls.Add(this.passangersLabel);
            this.passangerGroupBox.Location = new System.Drawing.Point(32, 40);
            this.passangerGroupBox.Name = "passangerGroupBox";
            this.passangerGroupBox.Size = new System.Drawing.Size(495, 85);
            this.passangerGroupBox.TabIndex = 6;
            this.passangerGroupBox.TabStop = false;
            this.passangerGroupBox.Text = "Pasajeros";
            // 
            // passangersLabel
            // 
            this.passangersLabel.AutoSize = true;
            this.passangersLabel.Location = new System.Drawing.Point(6, 25);
            this.passangersLabel.Name = "passangersLabel";
            this.passangersLabel.Size = new System.Drawing.Size(194, 26);
            this.passangersLabel.TabIndex = 2;
            this.passangersLabel.Text = "Pasajero: MR RODRIGO FERNANDEZ\r\nCodigo de Confirmación : D232F\r\n";
            // 
            // acceptButton
            // 
            this.acceptButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.acceptButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.acceptButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.acceptButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.acceptButton.Location = new System.Drawing.Point(430, 372);
            this.acceptButton.Name = "acceptButton";
            this.acceptButton.Size = new System.Drawing.Size(97, 28);
            this.acceptButton.TabIndex = 20;
            this.acceptButton.Text = "Aceptar";
            this.acceptButton.UseVisualStyleBackColor = false;
            this.acceptButton.Click += new System.EventHandler(this.acceptButton_Click);
            // 
            // emissionTimeLabel
            // 
            this.emissionTimeLabel.AutoSize = true;
            this.emissionTimeLabel.Location = new System.Drawing.Point(38, 24);
            this.emissionTimeLabel.Name = "emissionTimeLabel";
            this.emissionTimeLabel.Size = new System.Drawing.Size(122, 13);
            this.emissionTimeLabel.TabIndex = 4;
            this.emissionTimeLabel.Text = "Fecha : 23/12/11 16:03";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(26, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(166, 15);
            this.label3.TabIndex = 3;
            this.label3.Text = "Confirmación de Compra";
            // 
            // frmInterJetReservationConfirmation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(555, 438);
            this.Controls.Add(this.mainContainer);
            this.Name = "frmInterJetReservationConfirmation";
            this.ShowInTaskbar = false;
            this.Text = "Confirmación de Compra";
            this.Load += new System.EventHandler(this.frmInterJetReservationConfirmation_Load);
            this.mainContainer.ResumeLayout(false);
            this.mainContainer.PerformLayout();
            this.faresGroupBox.ResumeLayout(false);
            this.faresGroupBox.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.passangerGroupBox.ResumeLayout(false);
            this.passangerGroupBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel mainContainer;
        private System.Windows.Forms.Label segmentsLabel;
        private System.Windows.Forms.Label passangersLabel;
        private System.Windows.Forms.Label emissionTimeLabel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label pricingLabel;
        private System.Windows.Forms.GroupBox passangerGroupBox;
        private System.Windows.Forms.GroupBox faresGroupBox;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button acceptButton;
    }
}