namespace MyCTS.Presentation
{
    partial class ucHistoricRules
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
            this.lbGeneric = new System.Windows.Forms.ListBox();
            this.picCalendar2 = new System.Windows.Forms.PictureBox();
            this.picCalender = new System.Windows.Forms.PictureBox();
            this.btnAccept = new System.Windows.Forms.Button();
            this.txtFareBasis = new MyCTS.Forms.UI.SmartTextBox();
            this.txtAirLine = new MyCTS.Forms.UI.SmartTextBox();
            this.txtDestinationCity = new MyCTS.Forms.UI.SmartTextBox();
            this.lblCurrency = new System.Windows.Forms.Label();
            this.lblAirline = new System.Windows.Forms.Label();
            this.lblDestinCity = new System.Windows.Forms.Label();
            this.txtOriginCity = new MyCTS.Forms.UI.SmartTextBox();
            this.lblOriginCity = new System.Windows.Forms.Label();
            this.txtDepartureDate = new MyCTS.Forms.UI.SmartTextBox();
            this.lblDepartureDate = new System.Windows.Forms.Label();
            this.txtTicketsDate = new MyCTS.Forms.UI.SmartTextBox();
            this.lblTicketDate = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.monthCalendar1 = new System.Windows.Forms.MonthCalendar();
            ((System.ComponentModel.ISupportInitialize)(this.picCalendar2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picCalender)).BeginInit();
            this.SuspendLayout();
            // 
            // lbGeneric
            // 
            this.lbGeneric.DisplayMember = "Text";
            this.lbGeneric.FormattingEnabled = true;
            this.lbGeneric.Location = new System.Drawing.Point(20, 297);
            this.lbGeneric.Name = "lbGeneric";
            this.lbGeneric.Size = new System.Drawing.Size(141, 95);
            this.lbGeneric.TabIndex = 96;
            this.lbGeneric.ValueMember = "Value";
            this.lbGeneric.MouseClick += new System.Windows.Forms.MouseEventHandler(this.ListBox_MouseClick);
            this.lbGeneric.KeyDown += new System.Windows.Forms.KeyEventHandler(this.lbGeneric_KeyDown);
            // 
            // picCalendar2
            // 
            this.picCalendar2.Image = global::MyCTS.Presentation.Properties.Resources.calendario;
            this.picCalendar2.Location = new System.Drawing.Point(260, 73);
            this.picCalendar2.Name = "picCalendar2";
            this.picCalendar2.Size = new System.Drawing.Size(18, 20);
            this.picCalendar2.TabIndex = 99;
            this.picCalendar2.TabStop = false;
            this.picCalendar2.Click += new System.EventHandler(this.picCalendar2_Click);
            // 
            // picCalender
            // 
            this.picCalender.Image = global::MyCTS.Presentation.Properties.Resources.calendario;
            this.picCalender.Location = new System.Drawing.Point(260, 46);
            this.picCalender.Name = "picCalender";
            this.picCalender.Size = new System.Drawing.Size(18, 20);
            this.picCalender.TabIndex = 98;
            this.picCalender.TabStop = false;
            this.picCalender.Click += new System.EventHandler(this.picCalender_Click);
            // 
            // btnAccept
            // 
            this.btnAccept.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnAccept.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAccept.Location = new System.Drawing.Point(257, 354);
            this.btnAccept.Name = "btnAccept";
            this.btnAccept.Size = new System.Drawing.Size(100, 23);
            this.btnAccept.TabIndex = 7;
            this.btnAccept.Text = "Aceptar";
            this.btnAccept.UseVisualStyleBackColor = false;
            this.btnAccept.Click += new System.EventHandler(this.btnAccept_Click);
            // 
            // txtFareBasis
            // 
            this.txtFareBasis.AllowBlankSpaces = true;
            this.txtFareBasis.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtFareBasis.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.AnyCharacter;
            this.txtFareBasis.CustomExpression = ".*";
            this.txtFareBasis.EnterColor = System.Drawing.Color.Empty;
            this.txtFareBasis.LeaveColor = System.Drawing.Color.Empty;
            this.txtFareBasis.Location = new System.Drawing.Point(154, 185);
            this.txtFareBasis.MaxLength = 16;
            this.txtFareBasis.Name = "txtFareBasis";
            this.txtFareBasis.Size = new System.Drawing.Size(141, 20);
            this.txtFareBasis.TabIndex = 6;
            this.txtFareBasis.TextChanged += new System.EventHandler(this.txtFareBasis_TextChanged);
            this.txtFareBasis.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // txtAirLine
            // 
            this.txtAirLine.AllowBlankSpaces = true;
            this.txtAirLine.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtAirLine.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.AnyCharacter;
            this.txtAirLine.CustomExpression = ".*";
            this.txtAirLine.EnterColor = System.Drawing.Color.Empty;
            this.txtAirLine.LeaveColor = System.Drawing.Color.Empty;
            this.txtAirLine.Location = new System.Drawing.Point(154, 158);
            this.txtAirLine.Name = "txtAirLine";
            this.txtAirLine.Size = new System.Drawing.Size(141, 20);
            this.txtAirLine.TabIndex = 5;
            this.txtAirLine.TextChanged += new System.EventHandler(this.txtAirLine_TextChanged);
            this.txtAirLine.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // txtDestinationCity
            // 
            this.txtDestinationCity.AllowBlankSpaces = true;
            this.txtDestinationCity.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtDestinationCity.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.AnyCharacter;
            this.txtDestinationCity.CustomExpression = ".*";
            this.txtDestinationCity.EnterColor = System.Drawing.Color.Empty;
            this.txtDestinationCity.LeaveColor = System.Drawing.Color.Empty;
            this.txtDestinationCity.Location = new System.Drawing.Point(154, 131);
            this.txtDestinationCity.Name = "txtDestinationCity";
            this.txtDestinationCity.Size = new System.Drawing.Size(141, 20);
            this.txtDestinationCity.TabIndex = 4;
            this.txtDestinationCity.TextChanged += new System.EventHandler(this.txtDestinationCity_TextChanged);
            this.txtDestinationCity.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // lblCurrency
            // 
            this.lblCurrency.AutoSize = true;
            this.lblCurrency.ForeColor = System.Drawing.Color.Black;
            this.lblCurrency.Location = new System.Drawing.Point(30, 183);
            this.lblCurrency.Name = "lblCurrency";
            this.lblCurrency.Size = new System.Drawing.Size(56, 13);
            this.lblCurrency.TabIndex = 0;
            this.lblCurrency.Text = "Fare Basis";
            // 
            // lblAirline
            // 
            this.lblAirline.AutoSize = true;
            this.lblAirline.Location = new System.Drawing.Point(30, 156);
            this.lblAirline.Name = "lblAirline";
            this.lblAirline.Size = new System.Drawing.Size(69, 13);
            this.lblAirline.TabIndex = 0;
            this.lblAirline.Text = "Línea Aerea:";
            // 
            // lblDestinCity
            // 
            this.lblDestinCity.AutoSize = true;
            this.lblDestinCity.Location = new System.Drawing.Point(30, 130);
            this.lblDestinCity.Name = "lblDestinCity";
            this.lblDestinCity.Size = new System.Drawing.Size(82, 13);
            this.lblDestinCity.TabIndex = 0;
            this.lblDestinCity.Text = "Ciudad Destino:";
            // 
            // txtOriginCity
            // 
            this.txtOriginCity.AllowBlankSpaces = true;
            this.txtOriginCity.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtOriginCity.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.AnyCharacter;
            this.txtOriginCity.CustomExpression = ".*";
            this.txtOriginCity.EnterColor = System.Drawing.Color.Empty;
            this.txtOriginCity.LeaveColor = System.Drawing.Color.Empty;
            this.txtOriginCity.Location = new System.Drawing.Point(154, 104);
            this.txtOriginCity.Name = "txtOriginCity";
            this.txtOriginCity.Size = new System.Drawing.Size(141, 20);
            this.txtOriginCity.TabIndex = 3;
            this.txtOriginCity.TextChanged += new System.EventHandler(this.txtOriginCity_TextChanged);
            this.txtOriginCity.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // lblOriginCity
            // 
            this.lblOriginCity.AutoSize = true;
            this.lblOriginCity.Location = new System.Drawing.Point(30, 104);
            this.lblOriginCity.Name = "lblOriginCity";
            this.lblOriginCity.Size = new System.Drawing.Size(77, 13);
            this.lblOriginCity.TabIndex = 0;
            this.lblOriginCity.Text = "Ciudad Origen:";
            // 
            // txtDepartureDate
            // 
            this.txtDepartureDate.AllowBlankSpaces = true;
            this.txtDepartureDate.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtDepartureDate.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.NumbersOrLetters;
            this.txtDepartureDate.CustomExpression = ".*";
            this.txtDepartureDate.EnterColor = System.Drawing.Color.Empty;
            this.txtDepartureDate.LeaveColor = System.Drawing.Color.Empty;
            this.txtDepartureDate.Location = new System.Drawing.Point(154, 73);
            this.txtDepartureDate.MaxLength = 7;
            this.txtDepartureDate.Name = "txtDepartureDate";
            this.txtDepartureDate.Size = new System.Drawing.Size(100, 20);
            this.txtDepartureDate.TabIndex = 2;
            this.txtDepartureDate.TextChanged += new System.EventHandler(this.txtDepartureDate_TextChanged);
            this.txtDepartureDate.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // lblDepartureDate
            // 
            this.lblDepartureDate.AutoSize = true;
            this.lblDepartureDate.Location = new System.Drawing.Point(30, 73);
            this.lblDepartureDate.Name = "lblDepartureDate";
            this.lblDepartureDate.Size = new System.Drawing.Size(70, 13);
            this.lblDepartureDate.TabIndex = 0;
            this.lblDepartureDate.Text = "Fecha salida:";
            // 
            // txtTicketsDate
            // 
            this.txtTicketsDate.AllowBlankSpaces = true;
            this.txtTicketsDate.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtTicketsDate.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.NumbersOrLetters;
            this.txtTicketsDate.CustomExpression = ".*";
            this.txtTicketsDate.EnterColor = System.Drawing.Color.Empty;
            this.txtTicketsDate.LeaveColor = System.Drawing.Color.Empty;
            this.txtTicketsDate.Location = new System.Drawing.Point(154, 46);
            this.txtTicketsDate.MaxLength = 7;
            this.txtTicketsDate.Name = "txtTicketsDate";
            this.txtTicketsDate.Size = new System.Drawing.Size(100, 20);
            this.txtTicketsDate.TabIndex = 1;
            this.txtTicketsDate.TextChanged += new System.EventHandler(this.txtTicketsDate_TextChanged);
            this.txtTicketsDate.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // lblTicketDate
            // 
            this.lblTicketDate.AutoSize = true;
            this.lblTicketDate.Location = new System.Drawing.Point(30, 46);
            this.lblTicketDate.Name = "lblTicketDate";
            this.lblTicketDate.Size = new System.Drawing.Size(73, 13);
            this.lblTicketDate.TabIndex = 0;
            this.lblTicketDate.Text = "Fecha Boleto:";
            // 
            // lblTitle
            // 
            this.lblTitle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(139)))), ((int)(((byte)(208)))));
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(3, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(405, 14);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Reglas Históricas";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // monthCalendar1
            // 
            this.monthCalendar1.Location = new System.Drawing.Point(124, 94);
            this.monthCalendar1.Name = "monthCalendar1";
            this.monthCalendar1.TabIndex = 97;
            this.monthCalendar1.DateSelected += new System.Windows.Forms.DateRangeEventHandler(this.monthCalendar1_DateSelected);
            this.monthCalendar1.Leave += new System.EventHandler(this.monthCalendar1_Leave);
            this.monthCalendar1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.monthCalendar1_KeyDown);
            // 
            // ucHistoricRules
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.lbGeneric);
            this.Controls.Add(this.picCalendar2);
            this.Controls.Add(this.picCalender);
            this.Controls.Add(this.btnAccept);
            this.Controls.Add(this.txtFareBasis);
            this.Controls.Add(this.txtAirLine);
            this.Controls.Add(this.txtDestinationCity);
            this.Controls.Add(this.lblCurrency);
            this.Controls.Add(this.lblAirline);
            this.Controls.Add(this.lblDestinCity);
            this.Controls.Add(this.txtOriginCity);
            this.Controls.Add(this.lblOriginCity);
            this.Controls.Add(this.txtDepartureDate);
            this.Controls.Add(this.lblDepartureDate);
            this.Controls.Add(this.txtTicketsDate);
            this.Controls.Add(this.lblTicketDate);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.monthCalendar1);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "ucHistoricRules";
            this.Size = new System.Drawing.Size(411, 580);
            this.Load += new System.EventHandler(this.ucHistoricRules_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picCalendar2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picCalender)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lbGeneric;
        private System.Windows.Forms.PictureBox picCalendar2;
        private System.Windows.Forms.PictureBox picCalender;
        private System.Windows.Forms.Button btnAccept;
        private MyCTS.Forms.UI.SmartTextBox txtFareBasis;
        private MyCTS.Forms.UI.SmartTextBox txtAirLine;
        private MyCTS.Forms.UI.SmartTextBox txtDestinationCity;
        private System.Windows.Forms.Label lblCurrency;
        private System.Windows.Forms.Label lblAirline;
        private System.Windows.Forms.Label lblDestinCity;
        private MyCTS.Forms.UI.SmartTextBox txtOriginCity;
        private System.Windows.Forms.Label lblOriginCity;
        private MyCTS.Forms.UI.SmartTextBox txtDepartureDate;
        private System.Windows.Forms.Label lblDepartureDate;
        private MyCTS.Forms.UI.SmartTextBox txtTicketsDate;
        private System.Windows.Forms.Label lblTicketDate;
        internal System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.MonthCalendar monthCalendar1;
    }
}
