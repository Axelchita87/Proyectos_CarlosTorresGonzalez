namespace MyCTS.Presentation
{
    partial class ucPhaseIVBreakDown
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
            this.txtCalculationLine = new MyCTS.Forms.UI.SmartTextBox();
            this.lblCommonSymbols = new System.Windows.Forms.Label();
            this.lblCircleTrip = new System.Windows.Forms.Label();
            this.lblCircleTripValue = new System.Windows.Forms.Label();
            this.lblDirecFareValue = new System.Windows.Forms.Label();
            this.lblDirectFare = new System.Windows.Forms.Label();
            this.lblExtraMileageValue = new System.Windows.Forms.Label();
            this.lblExtraMileage = new System.Windows.Forms.Label();
            this.lblDifferentialValue = new System.Windows.Forms.Label();
            this.lblDifferential = new System.Windows.Forms.Label();
            this.lblMPMReductionValue = new System.Windows.Forms.Label();
            this.lblMPMReduction = new System.Windows.Forms.Label();
            this.lblNoStopoverValue = new System.Windows.Forms.Label();
            this.lblNoStopover = new System.Windows.Forms.Label();
            this.Mileage5MValue = new System.Windows.Forms.Label();
            this.lblMileage5M = new System.Windows.Forms.Label();
            this.lblhigherPointValue = new System.Windows.Forms.Label();
            this.lblHigherPoint = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.lblTicketedExclusion = new System.Windows.Forms.Label();
            this.lblSurfaceValue = new System.Windows.Forms.Label();
            this.lblSurface = new System.Windows.Forms.Label();
            this.lblMileageIncludeValue = new System.Windows.Forms.Label();
            this.lblSurMileageIncluded = new System.Windows.Forms.Label();
            this.lblRateExchangeValue = new System.Windows.Forms.Label();
            this.lblRateExchange = new System.Windows.Forms.Label();
            this.lblSurchargevalue = new System.Windows.Forms.Label();
            this.lblSurcharge = new System.Windows.Forms.Label();
            this.lblStopoverValue = new System.Windows.Forms.Label();
            this.lblStopover = new System.Windows.Forms.Label();
            this.lblSiteTripValue = new System.Windows.Forms.Label();
            this.lblSideTrip = new System.Windows.Forms.Label();
            this.lblWayBackhaulvalue = new System.Windows.Forms.Label();
            this.lblWayBackhaul = new System.Windows.Forms.Label();
            this.btnAccept = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(139)))), ((int)(((byte)(208)))));
            this.lblTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(0, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(411, 15);
            this.lblTitle.TabIndex = 1;
            this.lblTitle.Text = "Fase IV - BreakDown";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // txtCalculationLine
            // 
            this.txtCalculationLine.AllowBlankSpaces = true;
            this.txtCalculationLine.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtCalculationLine.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.AnyCharacter;
            this.txtCalculationLine.CustomExpression = ".*";
            this.txtCalculationLine.EnterColor = System.Drawing.Color.Empty;
            this.txtCalculationLine.LeaveColor = System.Drawing.Color.Empty;
            this.txtCalculationLine.Location = new System.Drawing.Point(14, 46);
            this.txtCalculationLine.MaxLength = 500;
            this.txtCalculationLine.Multiline = true;
            this.txtCalculationLine.Name = "txtCalculationLine";
            this.txtCalculationLine.Size = new System.Drawing.Size(377, 88);
            this.txtCalculationLine.TabIndex = 1;
            this.txtCalculationLine.TextChanged += new System.EventHandler(this.txtControl_TextChanged);
            this.txtCalculationLine.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // lblCommonSymbols
            // 
            this.lblCommonSymbols.AutoSize = true;
            this.lblCommonSymbols.ForeColor = System.Drawing.Color.Navy;
            this.lblCommonSymbols.Location = new System.Drawing.Point(29, 168);
            this.lblCommonSymbols.Name = "lblCommonSymbols";
            this.lblCommonSymbols.Size = new System.Drawing.Size(302, 13);
            this.lblCommonSymbols.TabIndex = 3;
            this.lblCommonSymbols.Text = "Simbolos comunes para la construcción de la línea de cálculo:";
            // 
            // lblCircleTrip
            // 
            this.lblCircleTrip.AutoSize = true;
            this.lblCircleTrip.ForeColor = System.Drawing.Color.RoyalBlue;
            this.lblCircleTrip.Location = new System.Drawing.Point(46, 209);
            this.lblCircleTrip.Name = "lblCircleTrip";
            this.lblCircleTrip.Size = new System.Drawing.Size(176, 13);
            this.lblCircleTrip.TabIndex = 4;
            this.lblCircleTrip.Text = "Circle trip/round the world minimums";
            // 
            // lblCircleTripValue
            // 
            this.lblCircleTripValue.AutoSize = true;
            this.lblCircleTripValue.ForeColor = System.Drawing.Color.RoyalBlue;
            this.lblCircleTripValue.Location = new System.Drawing.Point(296, 209);
            this.lblCircleTripValue.Name = "lblCircleTripValue";
            this.lblCircleTripValue.Size = new System.Drawing.Size(14, 13);
            this.lblCircleTripValue.TabIndex = 5;
            this.lblCircleTripValue.Text = "P";
            // 
            // lblDirecFareValue
            // 
            this.lblDirecFareValue.AutoSize = true;
            this.lblDirecFareValue.ForeColor = System.Drawing.Color.RoyalBlue;
            this.lblDirecFareValue.Location = new System.Drawing.Point(296, 224);
            this.lblDirecFareValue.Name = "lblDirecFareValue";
            this.lblDirecFareValue.Size = new System.Drawing.Size(15, 13);
            this.lblDirecFareValue.TabIndex = 7;
            this.lblDirecFareValue.Text = "H";
            // 
            // lblDirectFare
            // 
            this.lblDirectFare.AutoSize = true;
            this.lblDirectFare.ForeColor = System.Drawing.Color.RoyalBlue;
            this.lblDirectFare.Location = new System.Drawing.Point(46, 224);
            this.lblDirectFare.Name = "lblDirectFare";
            this.lblDirectFare.Size = new System.Drawing.Size(101, 13);
            this.lblDirectFare.TabIndex = 6;
            this.lblDirectFare.Text = "Direct fare undercut";
            // 
            // lblExtraMileageValue
            // 
            this.lblExtraMileageValue.AutoSize = true;
            this.lblExtraMileageValue.ForeColor = System.Drawing.Color.RoyalBlue;
            this.lblExtraMileageValue.Location = new System.Drawing.Point(296, 253);
            this.lblExtraMileageValue.Name = "lblExtraMileageValue";
            this.lblExtraMileageValue.Size = new System.Drawing.Size(19, 13);
            this.lblExtraMileageValue.TabIndex = 11;
            this.lblExtraMileageValue.Text = "E/";
            // 
            // lblExtraMileage
            // 
            this.lblExtraMileage.AutoSize = true;
            this.lblExtraMileage.ForeColor = System.Drawing.Color.RoyalBlue;
            this.lblExtraMileage.Location = new System.Drawing.Point(46, 253);
            this.lblExtraMileage.Name = "lblExtraMileage";
            this.lblExtraMileage.Size = new System.Drawing.Size(121, 13);
            this.lblExtraMileage.TabIndex = 10;
            this.lblExtraMileage.Text = "Extra mileage allowance";
            // 
            // lblDifferentialValue
            // 
            this.lblDifferentialValue.AutoSize = true;
            this.lblDifferentialValue.ForeColor = System.Drawing.Color.RoyalBlue;
            this.lblDifferentialValue.Location = new System.Drawing.Point(296, 239);
            this.lblDifferentialValue.Name = "lblDifferentialValue";
            this.lblDifferentialValue.Size = new System.Drawing.Size(15, 13);
            this.lblDifferentialValue.TabIndex = 9;
            this.lblDifferentialValue.Text = "D";
            // 
            // lblDifferential
            // 
            this.lblDifferential.AutoSize = true;
            this.lblDifferential.ForeColor = System.Drawing.Color.RoyalBlue;
            this.lblDifferential.Location = new System.Drawing.Point(46, 239);
            this.lblDifferential.Name = "lblDifferential";
            this.lblDifferential.Size = new System.Drawing.Size(57, 13);
            this.lblDifferential.TabIndex = 8;
            this.lblDifferential.Text = "Differential";
            // 
            // lblMPMReductionValue
            // 
            this.lblMPMReductionValue.AutoSize = true;
            this.lblMPMReductionValue.ForeColor = System.Drawing.Color.RoyalBlue;
            this.lblMPMReductionValue.Location = new System.Drawing.Point(296, 312);
            this.lblMPMReductionValue.Name = "lblMPMReductionValue";
            this.lblMPMReductionValue.Size = new System.Drawing.Size(18, 13);
            this.lblMPMReductionValue.TabIndex = 19;
            this.lblMPMReductionValue.Text = "L/";
            // 
            // lblMPMReduction
            // 
            this.lblMPMReduction.AutoSize = true;
            this.lblMPMReduction.ForeColor = System.Drawing.Color.RoyalBlue;
            this.lblMPMReduction.Location = new System.Drawing.Point(46, 312);
            this.lblMPMReduction.Name = "lblMPMReduction";
            this.lblMPMReduction.Size = new System.Drawing.Size(79, 13);
            this.lblMPMReduction.TabIndex = 18;
            this.lblMPMReduction.Text = "MPM reduction";
            // 
            // lblNoStopoverValue
            // 
            this.lblNoStopoverValue.AutoSize = true;
            this.lblNoStopoverValue.ForeColor = System.Drawing.Color.RoyalBlue;
            this.lblNoStopoverValue.Location = new System.Drawing.Point(296, 298);
            this.lblNoStopoverValue.Name = "lblNoStopoverValue";
            this.lblNoStopoverValue.Size = new System.Drawing.Size(19, 13);
            this.lblNoStopoverValue.TabIndex = 17;
            this.lblNoStopoverValue.Text = "X/";
            // 
            // lblNoStopover
            // 
            this.lblNoStopover.AutoSize = true;
            this.lblNoStopover.ForeColor = System.Drawing.Color.RoyalBlue;
            this.lblNoStopover.Location = new System.Drawing.Point(46, 298);
            this.lblNoStopover.Name = "lblNoStopover";
            this.lblNoStopover.Size = new System.Drawing.Size(65, 13);
            this.lblNoStopover.TabIndex = 16;
            this.lblNoStopover.Text = "No stopover";
            // 
            // Mileage5MValue
            // 
            this.Mileage5MValue.AutoSize = true;
            this.Mileage5MValue.ForeColor = System.Drawing.Color.RoyalBlue;
            this.Mileage5MValue.Location = new System.Drawing.Point(296, 283);
            this.Mileage5MValue.Name = "Mileage5MValue";
            this.Mileage5MValue.Size = new System.Drawing.Size(16, 13);
            this.Mileage5MValue.TabIndex = 15;
            this.Mileage5MValue.Text = "M";
            // 
            // lblMileage5M
            // 
            this.lblMileage5M.AutoSize = true;
            this.lblMileage5M.ForeColor = System.Drawing.Color.RoyalBlue;
            this.lblMileage5M.Location = new System.Drawing.Point(46, 283);
            this.lblMileage5M.Name = "lblMileage5M";
            this.lblMileage5M.Size = new System.Drawing.Size(62, 13);
            this.lblMileage5M.TabIndex = 14;
            this.lblMileage5M.Text = "Mileage 5M";
            // 
            // lblhigherPointValue
            // 
            this.lblhigherPointValue.AutoSize = true;
            this.lblhigherPointValue.ForeColor = System.Drawing.Color.RoyalBlue;
            this.lblhigherPointValue.Location = new System.Drawing.Point(296, 268);
            this.lblhigherPointValue.Name = "lblhigherPointValue";
            this.lblhigherPointValue.Size = new System.Drawing.Size(49, 13);
            this.lblhigherPointValue.TabIndex = 13;
            this.lblhigherPointValue.Text = "CTYCTY";
            // 
            // lblHigherPoint
            // 
            this.lblHigherPoint.AutoSize = true;
            this.lblHigherPoint.ForeColor = System.Drawing.Color.RoyalBlue;
            this.lblHigherPoint.Location = new System.Drawing.Point(46, 268);
            this.lblHigherPoint.Name = "lblHigherPoint";
            this.lblHigherPoint.Size = new System.Drawing.Size(124, 13);
            this.lblHigherPoint.TabIndex = 12;
            this.lblHigherPoint.Text = "Higher intermediate point";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.ForeColor = System.Drawing.Color.RoyalBlue;
            this.label15.Location = new System.Drawing.Point(296, 430);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(19, 13);
            this.label15.TabIndex = 35;
            this.label15.Text = "T/";
            // 
            // lblTicketedExclusion
            // 
            this.lblTicketedExclusion.AutoSize = true;
            this.lblTicketedExclusion.ForeColor = System.Drawing.Color.RoyalBlue;
            this.lblTicketedExclusion.Location = new System.Drawing.Point(46, 428);
            this.lblTicketedExclusion.Name = "lblTicketedExclusion";
            this.lblTicketedExclusion.Size = new System.Drawing.Size(122, 13);
            this.lblTicketedExclusion.TabIndex = 34;
            this.lblTicketedExclusion.Text = "Ticketed point exclusion";
            // 
            // lblSurfaceValue
            // 
            this.lblSurfaceValue.AutoSize = true;
            this.lblSurfaceValue.ForeColor = System.Drawing.Color.RoyalBlue;
            this.lblSurfaceValue.Location = new System.Drawing.Point(296, 414);
            this.lblSurfaceValue.Name = "lblSurfaceValue";
            this.lblSurfaceValue.Size = new System.Drawing.Size(15, 13);
            this.lblSurfaceValue.TabIndex = 33;
            this.lblSurfaceValue.Text = "/-";
            // 
            // lblSurface
            // 
            this.lblSurface.AutoSize = true;
            this.lblSurface.ForeColor = System.Drawing.Color.RoyalBlue;
            this.lblSurface.Location = new System.Drawing.Point(46, 412);
            this.lblSurface.Name = "lblSurface";
            this.lblSurface.Size = new System.Drawing.Size(44, 13);
            this.lblSurface.TabIndex = 32;
            this.lblSurface.Text = "Surface";
            // 
            // lblMileageIncludeValue
            // 
            this.lblMileageIncludeValue.AutoSize = true;
            this.lblMileageIncludeValue.ForeColor = System.Drawing.Color.RoyalBlue;
            this.lblMileageIncludeValue.Location = new System.Drawing.Point(296, 399);
            this.lblMileageIncludeValue.Name = "lblMileageIncludeValue";
            this.lblMileageIncludeValue.Size = new System.Drawing.Size(17, 13);
            this.lblMileageIncludeValue.TabIndex = 31;
            this.lblMileageIncludeValue.Text = "//";
            // 
            // lblSurMileageIncluded
            // 
            this.lblSurMileageIncluded.AutoSize = true;
            this.lblSurMileageIncluded.ForeColor = System.Drawing.Color.RoyalBlue;
            this.lblSurMileageIncluded.Location = new System.Drawing.Point(46, 397);
            this.lblSurMileageIncluded.Name = "lblSurMileageIncluded";
            this.lblSurMileageIncluded.Size = new System.Drawing.Size(126, 13);
            this.lblSurMileageIncluded.TabIndex = 30;
            this.lblSurMileageIncluded.Text = "Surface mileage included";
            // 
            // lblRateExchangeValue
            // 
            this.lblRateExchangeValue.AutoSize = true;
            this.lblRateExchangeValue.ForeColor = System.Drawing.Color.RoyalBlue;
            this.lblRateExchangeValue.Location = new System.Drawing.Point(296, 384);
            this.lblRateExchangeValue.Name = "lblRateExchangeValue";
            this.lblRateExchangeValue.Size = new System.Drawing.Size(30, 13);
            this.lblRateExchangeValue.TabIndex = 29;
            this.lblRateExchangeValue.Text = "ROE";
            // 
            // lblRateExchange
            // 
            this.lblRateExchange.AutoSize = true;
            this.lblRateExchange.ForeColor = System.Drawing.Color.RoyalBlue;
            this.lblRateExchange.Location = new System.Drawing.Point(46, 382);
            this.lblRateExchange.Name = "lblRateExchange";
            this.lblRateExchange.Size = new System.Drawing.Size(92, 13);
            this.lblRateExchange.TabIndex = 28;
            this.lblRateExchange.Text = "Rate of exchange";
            // 
            // lblSurchargevalue
            // 
            this.lblSurchargevalue.AutoSize = true;
            this.lblSurchargevalue.ForeColor = System.Drawing.Color.RoyalBlue;
            this.lblSurchargevalue.Location = new System.Drawing.Point(296, 371);
            this.lblSurchargevalue.Name = "lblSurchargevalue";
            this.lblSurchargevalue.Size = new System.Drawing.Size(15, 13);
            this.lblSurchargevalue.TabIndex = 27;
            this.lblSurchargevalue.Text = "Q";
            // 
            // lblSurcharge
            // 
            this.lblSurcharge.AutoSize = true;
            this.lblSurcharge.ForeColor = System.Drawing.Color.RoyalBlue;
            this.lblSurcharge.Location = new System.Drawing.Point(46, 369);
            this.lblSurcharge.Name = "lblSurcharge";
            this.lblSurcharge.Size = new System.Drawing.Size(56, 13);
            this.lblSurcharge.TabIndex = 26;
            this.lblSurcharge.Text = "Surcharge";
            // 
            // lblStopoverValue
            // 
            this.lblStopoverValue.AutoSize = true;
            this.lblStopoverValue.ForeColor = System.Drawing.Color.RoyalBlue;
            this.lblStopoverValue.Location = new System.Drawing.Point(296, 355);
            this.lblStopoverValue.Name = "lblStopoverValue";
            this.lblStopoverValue.Size = new System.Drawing.Size(14, 13);
            this.lblStopoverValue.TabIndex = 25;
            this.lblStopoverValue.Text = "S";
            // 
            // lblStopover
            // 
            this.lblStopover.AutoSize = true;
            this.lblStopover.ForeColor = System.Drawing.Color.RoyalBlue;
            this.lblStopover.Location = new System.Drawing.Point(46, 355);
            this.lblStopover.Name = "lblStopover";
            this.lblStopover.Size = new System.Drawing.Size(50, 13);
            this.lblStopover.TabIndex = 24;
            this.lblStopover.Text = "Stopover";
            // 
            // lblSiteTripValue
            // 
            this.lblSiteTripValue.AutoSize = true;
            this.lblSiteTripValue.ForeColor = System.Drawing.Color.RoyalBlue;
            this.lblSiteTripValue.Location = new System.Drawing.Point(296, 340);
            this.lblSiteTripValue.Name = "lblSiteTripValue";
            this.lblSiteTripValue.Size = new System.Drawing.Size(49, 13);
            this.lblSiteTripValue.TabIndex = 23;
            this.lblSiteTripValue.Text = "CTYCTY";
            // 
            // lblSideTrip
            // 
            this.lblSideTrip.AutoSize = true;
            this.lblSideTrip.ForeColor = System.Drawing.Color.RoyalBlue;
            this.lblSideTrip.Location = new System.Drawing.Point(46, 340);
            this.lblSideTrip.Name = "lblSideTrip";
            this.lblSideTrip.Size = new System.Drawing.Size(49, 13);
            this.lblSideTrip.TabIndex = 22;
            this.lblSideTrip.Text = "Side Trip";
            // 
            // lblWayBackhaulvalue
            // 
            this.lblWayBackhaulvalue.AutoSize = true;
            this.lblWayBackhaulvalue.ForeColor = System.Drawing.Color.RoyalBlue;
            this.lblWayBackhaulvalue.Location = new System.Drawing.Point(296, 325);
            this.lblWayBackhaulvalue.Name = "lblWayBackhaulvalue";
            this.lblWayBackhaulvalue.Size = new System.Drawing.Size(14, 13);
            this.lblWayBackhaulvalue.TabIndex = 21;
            this.lblWayBackhaulvalue.Text = "P";
            // 
            // lblWayBackhaul
            // 
            this.lblWayBackhaul.AutoSize = true;
            this.lblWayBackhaul.ForeColor = System.Drawing.Color.RoyalBlue;
            this.lblWayBackhaul.Location = new System.Drawing.Point(46, 325);
            this.lblWayBackhaul.Name = "lblWayBackhaul";
            this.lblWayBackhaul.Size = new System.Drawing.Size(99, 13);
            this.lblWayBackhaul.TabIndex = 20;
            this.lblWayBackhaul.Text = "One Way-backhaul";
            // 
            // btnAccept
            // 
            this.btnAccept.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnAccept.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAccept.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAccept.Location = new System.Drawing.Point(258, 474);
            this.btnAccept.Name = "btnAccept";
            this.btnAccept.Size = new System.Drawing.Size(100, 23);
            this.btnAccept.TabIndex = 2;
            this.btnAccept.Text = "Aceptar";
            this.btnAccept.UseVisualStyleBackColor = false;
            this.btnAccept.Click += new System.EventHandler(this.btnAccept_Click);
            // 
            // ucPhaseIVBreakDown
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.btnAccept);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.lblTicketedExclusion);
            this.Controls.Add(this.lblSurfaceValue);
            this.Controls.Add(this.lblSurface);
            this.Controls.Add(this.lblMileageIncludeValue);
            this.Controls.Add(this.lblSurMileageIncluded);
            this.Controls.Add(this.lblRateExchangeValue);
            this.Controls.Add(this.lblRateExchange);
            this.Controls.Add(this.lblSurchargevalue);
            this.Controls.Add(this.lblSurcharge);
            this.Controls.Add(this.lblStopoverValue);
            this.Controls.Add(this.lblStopover);
            this.Controls.Add(this.lblSiteTripValue);
            this.Controls.Add(this.lblSideTrip);
            this.Controls.Add(this.lblWayBackhaulvalue);
            this.Controls.Add(this.lblWayBackhaul);
            this.Controls.Add(this.lblMPMReductionValue);
            this.Controls.Add(this.lblMPMReduction);
            this.Controls.Add(this.lblNoStopoverValue);
            this.Controls.Add(this.lblNoStopover);
            this.Controls.Add(this.Mileage5MValue);
            this.Controls.Add(this.lblMileage5M);
            this.Controls.Add(this.lblhigherPointValue);
            this.Controls.Add(this.lblHigherPoint);
            this.Controls.Add(this.lblExtraMileageValue);
            this.Controls.Add(this.lblExtraMileage);
            this.Controls.Add(this.lblDifferentialValue);
            this.Controls.Add(this.lblDifferential);
            this.Controls.Add(this.lblDirecFareValue);
            this.Controls.Add(this.lblDirectFare);
            this.Controls.Add(this.lblCircleTripValue);
            this.Controls.Add(this.lblCircleTrip);
            this.Controls.Add(this.lblCommonSymbols);
            this.Controls.Add(this.txtCalculationLine);
            this.Controls.Add(this.lblTitle);
            this.Name = "ucPhaseIVBreakDown";
            this.Size = new System.Drawing.Size(411, 580);
            this.Load += new System.EventHandler(this.ucPhaseIVBreakDown_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.Label lblTitle;
        private MyCTS.Forms.UI.SmartTextBox txtCalculationLine;
        private System.Windows.Forms.Label lblCommonSymbols;
        private System.Windows.Forms.Label lblCircleTrip;
        private System.Windows.Forms.Label lblCircleTripValue;
        private System.Windows.Forms.Label lblDirecFareValue;
        private System.Windows.Forms.Label lblDirectFare;
        private System.Windows.Forms.Label lblExtraMileageValue;
        private System.Windows.Forms.Label lblExtraMileage;
        private System.Windows.Forms.Label lblDifferentialValue;
        private System.Windows.Forms.Label lblDifferential;
        private System.Windows.Forms.Label lblMPMReductionValue;
        private System.Windows.Forms.Label lblMPMReduction;
        private System.Windows.Forms.Label lblNoStopoverValue;
        private System.Windows.Forms.Label lblNoStopover;
        private System.Windows.Forms.Label Mileage5MValue;
        private System.Windows.Forms.Label lblMileage5M;
        private System.Windows.Forms.Label lblhigherPointValue;
        private System.Windows.Forms.Label lblHigherPoint;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label lblTicketedExclusion;
        private System.Windows.Forms.Label lblSurfaceValue;
        private System.Windows.Forms.Label lblSurface;
        private System.Windows.Forms.Label lblMileageIncludeValue;
        private System.Windows.Forms.Label lblSurMileageIncluded;
        private System.Windows.Forms.Label lblRateExchangeValue;
        private System.Windows.Forms.Label lblRateExchange;
        private System.Windows.Forms.Label lblSurchargevalue;
        private System.Windows.Forms.Label lblSurcharge;
        private System.Windows.Forms.Label lblStopoverValue;
        private System.Windows.Forms.Label lblStopover;
        private System.Windows.Forms.Label lblSiteTripValue;
        private System.Windows.Forms.Label lblSideTrip;
        private System.Windows.Forms.Label lblWayBackhaulvalue;
        private System.Windows.Forms.Label lblWayBackhaul;
        private System.Windows.Forms.Button btnAccept;
    }
}
