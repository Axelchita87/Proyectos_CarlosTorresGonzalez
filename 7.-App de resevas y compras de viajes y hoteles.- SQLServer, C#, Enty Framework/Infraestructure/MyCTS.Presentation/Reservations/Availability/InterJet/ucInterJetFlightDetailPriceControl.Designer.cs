namespace MyCTS.Presentation
{
    partial class ucInterJetFlightDetailPriceControl
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
            this.groupBoxContainer = new System.Windows.Forms.GroupBox();
            this.lblinfantPrice = new System.Windows.Forms.Label();
            this.lblInfantExtra = new System.Windows.Forms.Label();
            this.lblInfante = new System.Windows.Forms.Label();
            this.totalPriceLabel = new System.Windows.Forms.Label();
            this.totalLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.arrivalLabel = new System.Windows.Forms.Label();
            this.departureTimeLabel = new System.Windows.Forms.Label();
            this.departureLabel = new System.Windows.Forms.Label();
            this.departureAndArrivalLabel = new System.Windows.Forms.Label();
            this.flightLabel = new System.Windows.Forms.Label();
            this.childTaxDetailControl = new MyCTS.Presentation.ucInterJetTaxFlightDetail();
            this.seniorTaxDetailControl = new MyCTS.Presentation.ucInterJetTaxFlightDetail();
            this.adultTaxDetailControl = new MyCTS.Presentation.ucInterJetTaxFlightDetail();
            this.groupBoxContainer.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBoxContainer
            // 
            this.groupBoxContainer.Controls.Add(this.lblinfantPrice);
            this.groupBoxContainer.Controls.Add(this.lblInfantExtra);
            this.groupBoxContainer.Controls.Add(this.lblInfante);
            this.groupBoxContainer.Controls.Add(this.totalPriceLabel);
            this.groupBoxContainer.Controls.Add(this.totalLabel);
            this.groupBoxContainer.Controls.Add(this.label1);
            this.groupBoxContainer.Controls.Add(this.arrivalLabel);
            this.groupBoxContainer.Controls.Add(this.departureTimeLabel);
            this.groupBoxContainer.Controls.Add(this.departureLabel);
            this.groupBoxContainer.Controls.Add(this.departureAndArrivalLabel);
            this.groupBoxContainer.Controls.Add(this.flightLabel);
            this.groupBoxContainer.Controls.Add(this.childTaxDetailControl);
            this.groupBoxContainer.Controls.Add(this.seniorTaxDetailControl);
            this.groupBoxContainer.Controls.Add(this.adultTaxDetailControl);
            this.groupBoxContainer.Location = new System.Drawing.Point(3, 3);
            this.groupBoxContainer.Name = "groupBoxContainer";
            this.groupBoxContainer.Size = new System.Drawing.Size(386, 338);
            this.groupBoxContainer.TabIndex = 0;
            this.groupBoxContainer.TabStop = false;
            this.groupBoxContainer.Text = "-";
            this.groupBoxContainer.Enter += new System.EventHandler(this.groupBoxContainer_Enter);
            // 
            // lblinfantPrice
            // 
            this.lblinfantPrice.AutoSize = true;
            this.lblinfantPrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblinfantPrice.Location = new System.Drawing.Point(263, 244);
            this.lblinfantPrice.Name = "lblinfantPrice";
            this.lblinfantPrice.Size = new System.Drawing.Size(32, 13);
            this.lblinfantPrice.TabIndex = 13;
            this.lblinfantPrice.Text = "$0.0";
            this.lblinfantPrice.Visible = false;
            // 
            // lblInfantExtra
            // 
            this.lblInfantExtra.AutoSize = true;
            this.lblInfantExtra.Location = new System.Drawing.Point(223, 244);
            this.lblInfantExtra.Name = "lblInfantExtra";
            this.lblInfantExtra.Size = new System.Drawing.Size(31, 13);
            this.lblInfantExtra.TabIndex = 12;
            this.lblInfantExtra.Text = "Extra";
            this.lblInfantExtra.Visible = false;
            // 
            // lblInfante
            // 
            this.lblInfante.AutoSize = true;
            this.lblInfante.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInfante.ForeColor = System.Drawing.Color.Navy;
            this.lblInfante.Location = new System.Drawing.Point(220, 227);
            this.lblInfante.Name = "lblInfante";
            this.lblInfante.Size = new System.Drawing.Size(61, 13);
            this.lblInfante.TabIndex = 11;
            this.lblInfante.Text = "Infante(s)";
            this.lblInfante.Visible = false;
            // 
            // totalPriceLabel
            // 
            this.totalPriceLabel.AutoSize = true;
            this.totalPriceLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.totalPriceLabel.Location = new System.Drawing.Point(260, 309);
            this.totalPriceLabel.Name = "totalPriceLabel";
            this.totalPriceLabel.Size = new System.Drawing.Size(39, 13);
            this.totalPriceLabel.TabIndex = 10;
            this.totalPriceLabel.Text = "$0.00";
            // 
            // totalLabel
            // 
            this.totalLabel.AutoSize = true;
            this.totalLabel.Location = new System.Drawing.Point(217, 309);
            this.totalLabel.Name = "totalLabel";
            this.totalLabel.Size = new System.Drawing.Size(37, 13);
            this.totalLabel.TabIndex = 9;
            this.totalLabel.Text = "Total :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(65, 64);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(10, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "-";
            // 
            // arrivalLabel
            // 
            this.arrivalLabel.AutoSize = true;
            this.arrivalLabel.Location = new System.Drawing.Point(14, 64);
            this.arrivalLabel.Name = "arrivalLabel";
            this.arrivalLabel.Size = new System.Drawing.Size(51, 13);
            this.arrivalLabel.TabIndex = 7;
            this.arrivalLabel.Text = "Llegada :";
            // 
            // departureTimeLabel
            // 
            this.departureTimeLabel.AutoSize = true;
            this.departureTimeLabel.Location = new System.Drawing.Point(65, 39);
            this.departureTimeLabel.Name = "departureTimeLabel";
            this.departureTimeLabel.Size = new System.Drawing.Size(10, 13);
            this.departureTimeLabel.TabIndex = 6;
            this.departureTimeLabel.Text = "-";
            // 
            // departureLabel
            // 
            this.departureLabel.AutoSize = true;
            this.departureLabel.Location = new System.Drawing.Point(25, 39);
            this.departureLabel.Name = "departureLabel";
            this.departureLabel.Size = new System.Drawing.Size(42, 13);
            this.departureLabel.TabIndex = 5;
            this.departureLabel.Text = "Salida :";
            // 
            // departureAndArrivalLabel
            // 
            this.departureAndArrivalLabel.AutoSize = true;
            this.departureAndArrivalLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.departureAndArrivalLabel.ForeColor = System.Drawing.Color.DarkBlue;
            this.departureAndArrivalLabel.Location = new System.Drawing.Point(65, 16);
            this.departureAndArrivalLabel.Name = "departureAndArrivalLabel";
            this.departureAndArrivalLabel.Size = new System.Drawing.Size(11, 13);
            this.departureAndArrivalLabel.TabIndex = 4;
            this.departureAndArrivalLabel.Text = "-";
            // 
            // flightLabel
            // 
            this.flightLabel.AutoSize = true;
            this.flightLabel.Location = new System.Drawing.Point(27, 16);
            this.flightLabel.Name = "flightLabel";
            this.flightLabel.Size = new System.Drawing.Size(40, 13);
            this.flightLabel.TabIndex = 3;
            this.flightLabel.Text = "Vuelo :";
            // 
            // childTaxDetailControl
            // 
            this.childTaxDetailControl.BackColor = System.Drawing.Color.White;
            this.childTaxDetailControl.Data = null;
            this.childTaxDetailControl.InitialControlFocus = null;
            this.childTaxDetailControl.LastControlFocus = null;
            this.childTaxDetailControl.LightingTextBox = true;
            this.childTaxDetailControl.Location = new System.Drawing.Point(17, 204);
            this.childTaxDetailControl.Name = "childTaxDetailControl";
            this.childTaxDetailControl.Parameter = null;
            this.childTaxDetailControl.Parameters = null;
            this.childTaxDetailControl.Size = new System.Drawing.Size(165, 128);
            this.childTaxDetailControl.TabIndex = 2;
            // 
            // seniorTaxDetailControl
            // 
            this.seniorTaxDetailControl.BackColor = System.Drawing.Color.White;
            this.seniorTaxDetailControl.Data = null;
            this.seniorTaxDetailControl.InitialControlFocus = null;
            this.seniorTaxDetailControl.LastControlFocus = null;
            this.seniorTaxDetailControl.LightingTextBox = true;
            this.seniorTaxDetailControl.Location = new System.Drawing.Point(191, 80);
            this.seniorTaxDetailControl.Name = "seniorTaxDetailControl";
            this.seniorTaxDetailControl.Parameter = null;
            this.seniorTaxDetailControl.Parameters = null;
            this.seniorTaxDetailControl.Size = new System.Drawing.Size(168, 125);
            this.seniorTaxDetailControl.TabIndex = 1;
            // 
            // adultTaxDetailControl
            // 
            this.adultTaxDetailControl.BackColor = System.Drawing.Color.White;
            this.adultTaxDetailControl.Data = null;
            this.adultTaxDetailControl.InitialControlFocus = null;
            this.adultTaxDetailControl.LastControlFocus = null;
            this.adultTaxDetailControl.LightingTextBox = true;
            this.adultTaxDetailControl.Location = new System.Drawing.Point(17, 80);
            this.adultTaxDetailControl.Name = "adultTaxDetailControl";
            this.adultTaxDetailControl.Parameter = null;
            this.adultTaxDetailControl.Parameters = null;
            this.adultTaxDetailControl.Size = new System.Drawing.Size(168, 128);
            this.adultTaxDetailControl.TabIndex = 0;
            // 
            // ucInterJetFlightDetailPriceControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.groupBoxContainer);
            this.Name = "ucInterJetFlightDetailPriceControl";
            this.Size = new System.Drawing.Size(413, 345);
            this.groupBoxContainer.ResumeLayout(false);
            this.groupBoxContainer.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBoxContainer;
        private ucInterJetTaxFlightDetail childTaxDetailControl;
        private ucInterJetTaxFlightDetail seniorTaxDetailControl;
        private ucInterJetTaxFlightDetail adultTaxDetailControl;
        private System.Windows.Forms.Label departureAndArrivalLabel;
        private System.Windows.Forms.Label flightLabel;
        private System.Windows.Forms.Label departureLabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label arrivalLabel;
        private System.Windows.Forms.Label departureTimeLabel;
        private System.Windows.Forms.Label totalPriceLabel;
        private System.Windows.Forms.Label totalLabel;
        private System.Windows.Forms.Label lblinfantPrice;
        private System.Windows.Forms.Label lblInfantExtra;
        private System.Windows.Forms.Label lblInfante;
    }
}
