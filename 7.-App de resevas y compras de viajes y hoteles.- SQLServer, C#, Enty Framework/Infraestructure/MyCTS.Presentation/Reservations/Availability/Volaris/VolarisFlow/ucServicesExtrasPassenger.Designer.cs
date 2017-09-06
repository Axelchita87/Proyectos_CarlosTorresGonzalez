namespace MyCTS.Presentation
{
    partial class ucServicesExtrasPassenger
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBoxServicesExtras = new System.Windows.Forms.GroupBox();
            this.lblPax = new System.Windows.Forms.Label();
            this.chkArrival = new System.Windows.Forms.CheckBox();
            this.lblArrivalRute = new System.Windows.Forms.Label();
            this.chkDeparture = new System.Windows.Forms.CheckBox();
            this.lblDepartureRute = new System.Windows.Forms.Label();
            this.groupBoxServicesExtras.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBoxServicesExtras
            // 
            this.groupBoxServicesExtras.Controls.Add(this.lblPax);
            this.groupBoxServicesExtras.Controls.Add(this.chkArrival);
            this.groupBoxServicesExtras.Controls.Add(this.lblArrivalRute);
            this.groupBoxServicesExtras.Controls.Add(this.chkDeparture);
            this.groupBoxServicesExtras.Controls.Add(this.lblDepartureRute);
            this.groupBoxServicesExtras.Location = new System.Drawing.Point(3, 5);
            this.groupBoxServicesExtras.Name = "groupBoxServicesExtras";
            this.groupBoxServicesExtras.Size = new System.Drawing.Size(360, 36);
            this.groupBoxServicesExtras.TabIndex = 122;
            this.groupBoxServicesExtras.TabStop = false;
            // 
            // lblPax
            // 
            this.lblPax.AutoSize = true;
            this.lblPax.Location = new System.Drawing.Point(5, 15);
            this.lblPax.Name = "lblPax";
            this.lblPax.Size = new System.Drawing.Size(91, 13);
            this.lblPax.TabIndex = 4;
            this.lblPax.Text = "Nombre Completo";
            // 
            // chkArrival
            // 
            this.chkArrival.AutoSize = true;
            this.chkArrival.Location = new System.Drawing.Point(328, 14);
            this.chkArrival.Name = "chkArrival";
            this.chkArrival.Size = new System.Drawing.Size(15, 14);
            this.chkArrival.TabIndex = 3;
            this.chkArrival.UseVisualStyleBackColor = true;
            // 
            // lblArrivalRute
            // 
            this.lblArrivalRute.AutoSize = true;
            this.lblArrivalRute.Location = new System.Drawing.Point(252, 14);
            this.lblArrivalRute.Name = "lblArrivalRute";
            this.lblArrivalRute.Size = new System.Drawing.Size(56, 13);
            this.lblArrivalRute.TabIndex = 2;
            this.lblArrivalRute.Text = "CUN-MEX";
            // 
            // chkDeparture
            // 
            this.chkDeparture.AutoSize = true;
            this.chkDeparture.Location = new System.Drawing.Point(220, 13);
            this.chkDeparture.Name = "chkDeparture";
            this.chkDeparture.Size = new System.Drawing.Size(15, 14);
            this.chkDeparture.TabIndex = 1;
            this.chkDeparture.UseVisualStyleBackColor = true;
            // 
            // lblDepartureRute
            // 
            this.lblDepartureRute.AutoSize = true;
            this.lblDepartureRute.Location = new System.Drawing.Point(148, 14);
            this.lblDepartureRute.Name = "lblDepartureRute";
            this.lblDepartureRute.Size = new System.Drawing.Size(56, 13);
            this.lblDepartureRute.TabIndex = 0;
            this.lblDepartureRute.Text = "MEX-CUN";
            // 
            // ucServicesExtrasPassenger
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.groupBoxServicesExtras);
            this.Name = "ucServicesExtrasPassenger";
            this.Size = new System.Drawing.Size(365, 45);
            this.Load += new System.EventHandler(this.ucServicesExtrasPassenger_Load);
            this.groupBoxServicesExtras.ResumeLayout(false);
            this.groupBoxServicesExtras.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBoxServicesExtras;
        private System.Windows.Forms.Label lblPax;
        private System.Windows.Forms.CheckBox chkArrival;
        private System.Windows.Forms.Label lblArrivalRute;
        private System.Windows.Forms.CheckBox chkDeparture;
        private System.Windows.Forms.Label lblDepartureRute;
    }
}
