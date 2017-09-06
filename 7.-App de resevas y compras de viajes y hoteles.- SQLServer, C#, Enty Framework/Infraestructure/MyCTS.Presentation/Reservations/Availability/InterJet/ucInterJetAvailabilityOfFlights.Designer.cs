namespace MyCTS.Presentation
{
    partial class ucInterJetAvailabilityOfFlights
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.MainGroupBox = new System.Windows.Forms.GroupBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.selledSegmentsCount = new System.Windows.Forms.Label();
            this.segmentSelled = new System.Windows.Forms.Label();
            this.fareRuleTitleLabel = new System.Windows.Forms.Label();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.departureFlightsPanel = new System.Windows.Forms.Panel();
            this.avionInterJetPictureBox = new System.Windows.Forms.PictureBox();
            this.departureIntineraryInformationLabel = new System.Windows.Forms.Label();
            this.departureInformationLabel = new System.Windows.Forms.Label();
            this.departureFlightsDataGrid = new System.Windows.Forms.DataGridView();
            this.selectedFlight = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.numberOfFlights = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.departureTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.arrivalTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.price = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.processButtonsPanel = new System.Windows.Forms.Panel();
            this.cancelIntejerProcessButton = new System.Windows.Forms.Button();
            this.newAvailabilityButton = new System.Windows.Forms.Button();
            this.continueInterJetProcessButton = new System.Windows.Forms.Button();
            this.gradProg1 = new GradProg.GradProg();
            this.progressLabel = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.loadingPictureBox = new System.Windows.Forms.PictureBox();
            this.airPlaneLoadingPicture = new System.Windows.Forms.PictureBox();
            this.MainGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.departureFlightsPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.avionInterJetPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.departureFlightsDataGrid)).BeginInit();
            this.processButtonsPanel.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.loadingPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.airPlaneLoadingPicture)).BeginInit();
            this.SuspendLayout();
            // 
            // MainGroupBox
            // 
            this.MainGroupBox.Controls.Add(this.pictureBox1);
            this.MainGroupBox.Controls.Add(this.selledSegmentsCount);
            this.MainGroupBox.Controls.Add(this.segmentSelled);
            this.MainGroupBox.Controls.Add(this.fareRuleTitleLabel);
            this.MainGroupBox.Controls.Add(this.richTextBox1);
            this.MainGroupBox.Controls.Add(this.departureFlightsPanel);
            this.MainGroupBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MainGroupBox.Location = new System.Drawing.Point(3, 21);
            this.MainGroupBox.Name = "MainGroupBox";
            this.MainGroupBox.Size = new System.Drawing.Size(402, 572);
            this.MainGroupBox.TabIndex = 0;
            this.MainGroupBox.TabStop = false;
            this.MainGroupBox.Text = "Disponibilidad";
            this.MainGroupBox.Visible = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::MyCTS.Presentation.Properties.Resources.rsz_rsz_1327611485_shopping_cart_webshop;
            this.pictureBox1.Location = new System.Drawing.Point(320, 303);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(21, 29);
            this.pictureBox1.TabIndex = 104;
            this.pictureBox1.TabStop = false;
            // 
            // selledSegmentsCount
            // 
            this.selledSegmentsCount.AutoSize = true;
            this.selledSegmentsCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.selledSegmentsCount.Location = new System.Drawing.Point(347, 308);
            this.selledSegmentsCount.Name = "selledSegmentsCount";
            this.selledSegmentsCount.Size = new System.Drawing.Size(14, 13);
            this.selledSegmentsCount.TabIndex = 103;
            this.selledSegmentsCount.Text = "0";
            // 
            // segmentSelled
            // 
            this.segmentSelled.AutoSize = true;
            this.segmentSelled.Location = new System.Drawing.Point(211, 308);
            this.segmentSelled.Name = "segmentSelled";
            this.segmentSelled.Size = new System.Drawing.Size(113, 13);
            this.segmentSelled.TabIndex = 102;
            this.segmentSelled.Text = "Segmentos Vendidos :";
            // 
            // fareRuleTitleLabel
            // 
            this.fareRuleTitleLabel.AutoSize = true;
            this.fareRuleTitleLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fareRuleTitleLabel.Location = new System.Drawing.Point(10, 306);
            this.fareRuleTitleLabel.Name = "fareRuleTitleLabel";
            this.fareRuleTitleLabel.Size = new System.Drawing.Size(142, 15);
            this.fareRuleTitleLabel.TabIndex = 100;
            this.fareRuleTitleLabel.Text = "REGLAS TARIFARIAS";
            // 
            // richTextBox1
            // 
            this.richTextBox1.BackColor = System.Drawing.Color.White;
            this.richTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richTextBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Strikeout, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.richTextBox1.Location = new System.Drawing.Point(1, 324);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.ReadOnly = true;
            this.richTextBox1.Size = new System.Drawing.Size(390, 217);
            this.richTextBox1.TabIndex = 101;
            this.richTextBox1.Text = global::MyCTS.Presentation.Resources.Profiles.Constants.String1;
            // 
            // departureFlightsPanel
            // 
            this.departureFlightsPanel.Controls.Add(this.avionInterJetPictureBox);
            this.departureFlightsPanel.Controls.Add(this.departureIntineraryInformationLabel);
            this.departureFlightsPanel.Controls.Add(this.departureInformationLabel);
            this.departureFlightsPanel.Controls.Add(this.departureFlightsDataGrid);
            this.departureFlightsPanel.Controls.Add(this.processButtonsPanel);
            this.departureFlightsPanel.Location = new System.Drawing.Point(6, 15);
            this.departureFlightsPanel.Name = "departureFlightsPanel";
            this.departureFlightsPanel.Size = new System.Drawing.Size(390, 287);
            this.departureFlightsPanel.TabIndex = 0;
            // 
            // avionInterJetPictureBox
            // 
            this.avionInterJetPictureBox.Image = global::MyCTS.Presentation.Properties.Resources.rsz_1rsz_11327607979_365;
            this.avionInterJetPictureBox.Location = new System.Drawing.Point(4, 1);
            this.avionInterJetPictureBox.Name = "avionInterJetPictureBox";
            this.avionInterJetPictureBox.Size = new System.Drawing.Size(66, 57);
            this.avionInterJetPictureBox.TabIndex = 3;
            this.avionInterJetPictureBox.TabStop = false;
            // 
            // departureIntineraryInformationLabel
            // 
            this.departureIntineraryInformationLabel.AutoSize = true;
            this.departureIntineraryInformationLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.departureIntineraryInformationLabel.Location = new System.Drawing.Point(153, 43);
            this.departureIntineraryInformationLabel.Name = "departureIntineraryInformationLabel";
            this.departureIntineraryInformationLabel.Size = new System.Drawing.Size(12, 15);
            this.departureIntineraryInformationLabel.TabIndex = 2;
            this.departureIntineraryInformationLabel.Text = "-";
            // 
            // departureInformationLabel
            // 
            this.departureInformationLabel.AutoSize = true;
            this.departureInformationLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.departureInformationLabel.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.departureInformationLabel.Location = new System.Drawing.Point(77, 12);
            this.departureInformationLabel.Name = "departureInformationLabel";
            this.departureInformationLabel.Size = new System.Drawing.Size(12, 15);
            this.departureInformationLabel.TabIndex = 1;
            this.departureInformationLabel.Text = "-";
            // 
            // departureFlightsDataGrid
            // 
            this.departureFlightsDataGrid.AllowUserToAddRows = false;
            this.departureFlightsDataGrid.AllowUserToDeleteRows = false;
            this.departureFlightsDataGrid.AllowUserToResizeColumns = false;
            this.departureFlightsDataGrid.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.DarkGray;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.LightGray;
            this.departureFlightsDataGrid.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.departureFlightsDataGrid.BackgroundColor = System.Drawing.Color.White;
            this.departureFlightsDataGrid.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.departureFlightsDataGrid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.departureFlightsDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.departureFlightsDataGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.selectedFlight,
            this.numberOfFlights,
            this.departureTime,
            this.arrivalTime,
            this.price});
            this.departureFlightsDataGrid.Location = new System.Drawing.Point(7, 67);
            this.departureFlightsDataGrid.Name = "departureFlightsDataGrid";
            this.departureFlightsDataGrid.ReadOnly = true;
            this.departureFlightsDataGrid.RowHeadersVisible = false;
            this.departureFlightsDataGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.departureFlightsDataGrid.Size = new System.Drawing.Size(378, 180);
            this.departureFlightsDataGrid.TabIndex = 0;
            this.departureFlightsDataGrid.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cancelIntejerProcessButton_KeyDown);
            this.departureFlightsDataGrid.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.departureFlightsDataGrid_CellContentClick);
            // 
            // selectedFlight
            // 
            this.selectedFlight.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.selectedFlight.FillWeight = 50.76142F;
            this.selectedFlight.HeaderText = global::MyCTS.Presentation.Resources.Profiles.Constants.String1;
            this.selectedFlight.Name = "selectedFlight";
            this.selectedFlight.ReadOnly = true;
            // 
            // numberOfFlights
            // 
            this.numberOfFlights.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.numberOfFlights.DataPropertyName = "FlightNumber";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.numberOfFlights.DefaultCellStyle = dataGridViewCellStyle3;
            this.numberOfFlights.FillWeight = 112.3096F;
            this.numberOfFlights.HeaderText = "No. Vuelo";
            this.numberOfFlights.Name = "numberOfFlights";
            this.numberOfFlights.ReadOnly = true;
            // 
            // departureTime
            // 
            this.departureTime.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.departureTime.DataPropertyName = "Departure";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.departureTime.DefaultCellStyle = dataGridViewCellStyle4;
            this.departureTime.FillWeight = 112.3096F;
            this.departureTime.HeaderText = "Hora Salida";
            this.departureTime.Name = "departureTime";
            this.departureTime.ReadOnly = true;
            // 
            // arrivalTime
            // 
            this.arrivalTime.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.arrivalTime.DataPropertyName = "Arrival";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.arrivalTime.DefaultCellStyle = dataGridViewCellStyle5;
            this.arrivalTime.FillWeight = 112.3096F;
            this.arrivalTime.HeaderText = "Hora Llegada";
            this.arrivalTime.Name = "arrivalTime";
            this.arrivalTime.ReadOnly = true;
            // 
            // price
            // 
            this.price.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.price.DataPropertyName = "Price";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.price.DefaultCellStyle = dataGridViewCellStyle6;
            this.price.FillWeight = 112.3096F;
            this.price.HeaderText = "   Precio Base";
            this.price.Name = "price";
            this.price.ReadOnly = true;
            // 
            // processButtonsPanel
            // 
            this.processButtonsPanel.Controls.Add(this.cancelIntejerProcessButton);
            this.processButtonsPanel.Controls.Add(this.newAvailabilityButton);
            this.processButtonsPanel.Controls.Add(this.continueInterJetProcessButton);
            this.processButtonsPanel.Location = new System.Drawing.Point(7, 253);
            this.processButtonsPanel.Name = "processButtonsPanel";
            this.processButtonsPanel.Size = new System.Drawing.Size(378, 28);
            this.processButtonsPanel.TabIndex = 2;
            // 
            // cancelIntejerProcessButton
            // 
            this.cancelIntejerProcessButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.cancelIntejerProcessButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cancelIntejerProcessButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cancelIntejerProcessButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cancelIntejerProcessButton.Location = new System.Drawing.Point(27, 0);
            this.cancelIntejerProcessButton.Name = "cancelIntejerProcessButton";
            this.cancelIntejerProcessButton.Size = new System.Drawing.Size(124, 25);
            this.cancelIntejerProcessButton.TabIndex = 19;
            this.cancelIntejerProcessButton.Text = "<Nueva Disponibilidad";
            this.cancelIntejerProcessButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.cancelIntejerProcessButton.UseVisualStyleBackColor = false;
            this.cancelIntejerProcessButton.Click += new System.EventHandler(this.cancelIntejerProcessButton_Click);
            this.cancelIntejerProcessButton.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cancelIntejerProcessButton_KeyDown);
            // 
            // newAvailabilityButton
            // 
            this.newAvailabilityButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.newAvailabilityButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.newAvailabilityButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.newAvailabilityButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.newAvailabilityButton.Location = new System.Drawing.Point(157, 0);
            this.newAvailabilityButton.Name = "newAvailabilityButton";
            this.newAvailabilityButton.Size = new System.Drawing.Size(127, 25);
            this.newAvailabilityButton.TabIndex = 18;
            this.newAvailabilityButton.Text = "Vende otro Segmento";
            this.newAvailabilityButton.UseVisualStyleBackColor = false;
            this.newAvailabilityButton.Click += new System.EventHandler(this.newAvailabilityButton_Click);
            // 
            // continueInterJetProcessButton
            // 
            this.continueInterJetProcessButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.continueInterJetProcessButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.continueInterJetProcessButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.continueInterJetProcessButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.continueInterJetProcessButton.Location = new System.Drawing.Point(290, 0);
            this.continueInterJetProcessButton.Name = "continueInterJetProcessButton";
            this.continueInterJetProcessButton.Size = new System.Drawing.Size(85, 25);
            this.continueInterJetProcessButton.TabIndex = 17;
            this.continueInterJetProcessButton.Text = "Continuar>";
            this.continueInterJetProcessButton.UseVisualStyleBackColor = false;
            this.continueInterJetProcessButton.Click += new System.EventHandler(this.continueInterJetProcessButton_Click_1);
            this.continueInterJetProcessButton.KeyDown += new System.Windows.Forms.KeyEventHandler(this.continueInterJetProcessButton_KeyDown);
            // 
            // gradProg1
            // 
            this.gradProg1.BackColor = System.Drawing.Color.White;
            this.gradProg1.GradientStyle = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.gradProg1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.gradProg1.LabelBackColour = System.Drawing.Color.DimGray;
            this.gradProg1.LabelForeColour = System.Drawing.Color.LightSeaGreen;
            this.gradProg1.LabelPosition = new System.Drawing.Point(0, 0);
            this.gradProg1.Location = new System.Drawing.Point(3, 309);
            this.gradProg1.Maximum = 100;
            this.gradProg1.Minimum = 0;
            this.gradProg1.Name = "gradProg1";
            this.gradProg1.Percentage = 0;
            this.gradProg1.ProgressBarBackColour = System.Drawing.Color.White;
            this.gradProg1.ProgressBarForeColour = System.Drawing.Color.SteelBlue;
            this.gradProg1.ShowLabel = false;
            this.gradProg1.Size = new System.Drawing.Size(374, 26);
            this.gradProg1.TabIndex = 97;
            this.gradProg1.Value = 0;
            this.gradProg1.Visible = false;
            // 
            // progressLabel
            // 
            this.progressLabel.AutoSize = true;
            this.progressLabel.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.progressLabel.Location = new System.Drawing.Point(45, 292);
            this.progressLabel.Name = "progressLabel";
            this.progressLabel.Size = new System.Drawing.Size(244, 14);
            this.progressLabel.TabIndex = 98;
            this.progressLabel.Text = "Buscando Vuelos espere por favor...";
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lblTitle);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(405, 16);
            this.panel1.TabIndex = 2;
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
            this.lblTitle.Text = "Paso 1/8 - Disponibilidad";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // loadingPictureBox
            // 
            this.loadingPictureBox.Image = global::MyCTS.Presentation.Properties.Resources.loadingBlue;
            this.loadingPictureBox.Location = new System.Drawing.Point(48, 309);
            this.loadingPictureBox.Name = "loadingPictureBox";
            this.loadingPictureBox.Size = new System.Drawing.Size(267, 28);
            this.loadingPictureBox.TabIndex = 106;
            this.loadingPictureBox.TabStop = false;
            // 
            // airPlaneLoadingPicture
            // 
            this.airPlaneLoadingPicture.Image = global::MyCTS.Presentation.Properties.Resources.rsz_avialability;
            this.airPlaneLoadingPicture.Location = new System.Drawing.Point(106, 161);
            this.airPlaneLoadingPicture.Name = "airPlaneLoadingPicture";
            this.airPlaneLoadingPicture.Size = new System.Drawing.Size(123, 125);
            this.airPlaneLoadingPicture.TabIndex = 105;
            this.airPlaneLoadingPicture.TabStop = false;
            // 
            // ucInterJetAvailabilityOfFlights
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.loadingPictureBox);
            this.Controls.Add(this.airPlaneLoadingPicture);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.MainGroupBox);
            this.Controls.Add(this.gradProg1);
            this.Controls.Add(this.progressLabel);
            this.Name = "ucInterJetAvailabilityOfFlights";
            this.Size = new System.Drawing.Size(425, 596);
            this.Load += new System.EventHandler(this.ucInterJetAvailabilityOfFlights_Load);
            this.MainGroupBox.ResumeLayout(false);
            this.MainGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.departureFlightsPanel.ResumeLayout(false);
            this.departureFlightsPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.avionInterJetPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.departureFlightsDataGrid)).EndInit();
            this.processButtonsPanel.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.loadingPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.airPlaneLoadingPicture)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox MainGroupBox;
        private System.Windows.Forms.Panel departureFlightsPanel;
        private System.Windows.Forms.DataGridView departureFlightsDataGrid;
        private System.Windows.Forms.Label departureIntineraryInformationLabel;
        private System.Windows.Forms.Label departureInformationLabel;
        private System.Windows.Forms.Panel processButtonsPanel;
        private GradProg.GradProg gradProg1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label progressLabel;
        private System.Windows.Forms.Button continueInterJetProcessButton;
        private System.Windows.Forms.Button newAvailabilityButton;
        private System.Windows.Forms.Button cancelIntejerProcessButton;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label fareRuleTitleLabel;
        private System.Windows.Forms.RichTextBox richTextBox1;
        public System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.DataGridViewCheckBoxColumn selectedFlight;
        private System.Windows.Forms.DataGridViewTextBoxColumn numberOfFlights;
        private System.Windows.Forms.DataGridViewTextBoxColumn departureTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn arrivalTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn price;
        private System.Windows.Forms.Label segmentSelled;
        private System.Windows.Forms.Label selledSegmentsCount;
        private System.Windows.Forms.PictureBox avionInterJetPictureBox;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox airPlaneLoadingPicture;
        private System.Windows.Forms.PictureBox loadingPictureBox;
    }
}
