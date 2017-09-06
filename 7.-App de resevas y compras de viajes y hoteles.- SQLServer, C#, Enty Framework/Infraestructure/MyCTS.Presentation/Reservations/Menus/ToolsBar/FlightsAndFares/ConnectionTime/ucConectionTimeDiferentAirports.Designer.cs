namespace MyCTS.Presentation
{
    partial class ucConectionTimeDiferentAirports
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
            this.txtCodeCity = new MyCTS.Forms.UI.SmartTextBox();
            this.lblCityCode = new System.Windows.Forms.Label();
            this.txtAirportArrival = new MyCTS.Forms.UI.SmartTextBox();
            this.lblAirportArrival = new System.Windows.Forms.Label();
            this.txtAirportDeparture = new MyCTS.Forms.UI.SmartTextBox();
            this.lblAirportDeparture = new System.Windows.Forms.Label();
            this.txtAirlineArrival = new MyCTS.Forms.UI.SmartTextBox();
            this.lblArlineArrival = new System.Windows.Forms.Label();
            this.txtAirlineDeparture = new MyCTS.Forms.UI.SmartTextBox();
            this.lblAirlineDeparture = new System.Windows.Forms.Label();
            this.rdoInternationalToDomestic = new System.Windows.Forms.RadioButton();
            this.rdoInternationalToInternational = new System.Windows.Forms.RadioButton();
            this.rdoDomesticToInternational = new System.Windows.Forms.RadioButton();
            this.rdoDomesticToDomestic = new System.Windows.Forms.RadioButton();
            this.lblTypeConexion = new System.Windows.Forms.Label();
            this.btnAccept = new System.Windows.Forms.Button();
            this.lbCityCode = new System.Windows.Forms.ListBox();
            this.lbAirportArrival = new System.Windows.Forms.ListBox();
            this.lbAirline = new System.Windows.Forms.ListBox();
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
            this.lblTitle.TabIndex = 3;
            this.lblTitle.Text = "Tiempo de Conexión - Diferentes Aeropuertos";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // txtCodeCity
            // 
            this.txtCodeCity.AllowBlankSpaces = false;
            this.txtCodeCity.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtCodeCity.CharsIncluded = new char[0];
            this.txtCodeCity.CharsNoIncluded = new char[0];
            this.txtCodeCity.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.OnlyLetters;
            this.txtCodeCity.CustomExpression = ".*";
            this.txtCodeCity.EnterColor = System.Drawing.Color.Empty;
            this.txtCodeCity.LeaveColor = System.Drawing.Color.Empty;
            this.txtCodeCity.Location = new System.Drawing.Point(165, 53);
            this.txtCodeCity.MaxLength = 52;
            this.txtCodeCity.Name = "txtCodeCity";
            this.txtCodeCity.Size = new System.Drawing.Size(195, 20);
            this.txtCodeCity.TabIndex = 1;
            this.txtCodeCity.TextChanged += new System.EventHandler(this.txtCodeCity_TextChanged);
            this.txtCodeCity.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CityCodeActions_KeyDown);
            // 
            // lblCityCode
            // 
            this.lblCityCode.AutoSize = true;
            this.lblCityCode.Location = new System.Drawing.Point(45, 60);
            this.lblCityCode.Name = "lblCityCode";
            this.lblCityCode.Size = new System.Drawing.Size(94, 13);
            this.lblCityCode.TabIndex = 5;
            this.lblCityCode.Text = "Código de Ciudad:";
            // 
            // txtAirportArrival
            // 
            this.txtAirportArrival.AllowBlankSpaces = false;
            this.txtAirportArrival.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtAirportArrival.CharsIncluded = new char[0];
            this.txtAirportArrival.CharsNoIncluded = new char[0];
            this.txtAirportArrival.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.OnlyLetters;
            this.txtAirportArrival.CustomExpression = ".*";
            this.txtAirportArrival.EnterColor = System.Drawing.Color.Empty;
            this.txtAirportArrival.LeaveColor = System.Drawing.Color.Empty;
            this.txtAirportArrival.Location = new System.Drawing.Point(165, 79);
            this.txtAirportArrival.MaxLength = 52;
            this.txtAirportArrival.Name = "txtAirportArrival";
            this.txtAirportArrival.Size = new System.Drawing.Size(195, 20);
            this.txtAirportArrival.TabIndex = 2;
            this.txtAirportArrival.TextChanged += new System.EventHandler(this.txtAirportArrival_TextChanged);
            this.txtAirportArrival.KeyDown += new System.Windows.Forms.KeyEventHandler(this.AirportArrivalActions_KeyDown);
            // 
            // lblAirportArrival
            // 
            this.lblAirportArrival.AutoSize = true;
            this.lblAirportArrival.Location = new System.Drawing.Point(45, 86);
            this.lblAirportArrival.Name = "lblAirportArrival";
            this.lblAirportArrival.Size = new System.Drawing.Size(114, 13);
            this.lblAirportArrival.TabIndex = 5;
            this.lblAirportArrival.Text = "Aeropuerto de llegada:";
            // 
            // txtAirportDeparture
            // 
            this.txtAirportDeparture.AllowBlankSpaces = false;
            this.txtAirportDeparture.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtAirportDeparture.CharsIncluded = new char[0];
            this.txtAirportDeparture.CharsNoIncluded = new char[0];
            this.txtAirportDeparture.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.OnlyLetters;
            this.txtAirportDeparture.CustomExpression = ".*";
            this.txtAirportDeparture.EnterColor = System.Drawing.Color.Empty;
            this.txtAirportDeparture.LeaveColor = System.Drawing.Color.Empty;
            this.txtAirportDeparture.Location = new System.Drawing.Point(165, 105);
            this.txtAirportDeparture.MaxLength = 52;
            this.txtAirportDeparture.Name = "txtAirportDeparture";
            this.txtAirportDeparture.Size = new System.Drawing.Size(195, 20);
            this.txtAirportDeparture.TabIndex = 3;
            this.txtAirportDeparture.TextChanged += new System.EventHandler(this.txtAirportArrival_TextChanged);
            this.txtAirportDeparture.KeyDown += new System.Windows.Forms.KeyEventHandler(this.AirportArrivalActions_KeyDown);
            // 
            // lblAirportDeparture
            // 
            this.lblAirportDeparture.AutoSize = true;
            this.lblAirportDeparture.Location = new System.Drawing.Point(45, 112);
            this.lblAirportDeparture.Name = "lblAirportDeparture";
            this.lblAirportDeparture.Size = new System.Drawing.Size(107, 13);
            this.lblAirportDeparture.TabIndex = 5;
            this.lblAirportDeparture.Text = "Aeropuerto de salida:";
            // 
            // txtAirlineArrival
            // 
            this.txtAirlineArrival.AllowBlankSpaces = false;
            this.txtAirlineArrival.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtAirlineArrival.CharsIncluded = new char[0];
            this.txtAirlineArrival.CharsNoIncluded = new char[0];
            this.txtAirlineArrival.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.NumbersOrLetters;
            this.txtAirlineArrival.CustomExpression = ".*";
            this.txtAirlineArrival.EnterColor = System.Drawing.Color.Empty;
            this.txtAirlineArrival.LeaveColor = System.Drawing.Color.Empty;
            this.txtAirlineArrival.Location = new System.Drawing.Point(165, 131);
            this.txtAirlineArrival.MaxLength = 52;
            this.txtAirlineArrival.Name = "txtAirlineArrival";
            this.txtAirlineArrival.Size = new System.Drawing.Size(195, 20);
            this.txtAirlineArrival.TabIndex = 4;
            this.txtAirlineArrival.TextChanged += new System.EventHandler(this.txtAirlineDeparture_TextChanged);
            this.txtAirlineArrival.KeyDown += new System.Windows.Forms.KeyEventHandler(this.AirlineActions_KeyDown);
            // 
            // lblArlineArrival
            // 
            this.lblArlineArrival.AutoSize = true;
            this.lblArlineArrival.ForeColor = System.Drawing.Color.DarkCyan;
            this.lblArlineArrival.Location = new System.Drawing.Point(45, 138);
            this.lblArlineArrival.Name = "lblArlineArrival";
            this.lblArlineArrival.Size = new System.Drawing.Size(108, 13);
            this.lblArlineArrival.TabIndex = 5;
            this.lblArlineArrival.Text = "Aerolínea de llegada:";
            // 
            // txtAirlineDeparture
            // 
            this.txtAirlineDeparture.AllowBlankSpaces = false;
            this.txtAirlineDeparture.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtAirlineDeparture.CharsIncluded = new char[0];
            this.txtAirlineDeparture.CharsNoIncluded = new char[0];
            this.txtAirlineDeparture.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.NumbersOrLetters;
            this.txtAirlineDeparture.CustomExpression = ".*";
            this.txtAirlineDeparture.EnterColor = System.Drawing.Color.Empty;
            this.txtAirlineDeparture.LeaveColor = System.Drawing.Color.Empty;
            this.txtAirlineDeparture.Location = new System.Drawing.Point(165, 157);
            this.txtAirlineDeparture.MaxLength = 52;
            this.txtAirlineDeparture.Name = "txtAirlineDeparture";
            this.txtAirlineDeparture.Size = new System.Drawing.Size(195, 20);
            this.txtAirlineDeparture.TabIndex = 5;
            this.txtAirlineDeparture.TextChanged += new System.EventHandler(this.txtAirlineDeparture_TextChanged);
            this.txtAirlineDeparture.KeyDown += new System.Windows.Forms.KeyEventHandler(this.AirlineActions_KeyDown);
            // 
            // lblAirlineDeparture
            // 
            this.lblAirlineDeparture.AutoSize = true;
            this.lblAirlineDeparture.ForeColor = System.Drawing.Color.DarkCyan;
            this.lblAirlineDeparture.Location = new System.Drawing.Point(45, 164);
            this.lblAirlineDeparture.Name = "lblAirlineDeparture";
            this.lblAirlineDeparture.Size = new System.Drawing.Size(101, 13);
            this.lblAirlineDeparture.TabIndex = 5;
            this.lblAirlineDeparture.Text = "Aerolínea de salida:";
            // 
            // rdoInternationalToDomestic
            // 
            this.rdoInternationalToDomestic.AutoSize = true;
            this.rdoInternationalToDomestic.Location = new System.Drawing.Point(165, 263);
            this.rdoInternationalToDomestic.Name = "rdoInternationalToDomestic";
            this.rdoInternationalToDomestic.Size = new System.Drawing.Size(148, 17);
            this.rdoInternationalToDomestic.TabIndex = 9;
            this.rdoInternationalToDomestic.TabStop = true;
            this.rdoInternationalToDomestic.Text = "Internacional a Domestica";
            this.rdoInternationalToDomestic.UseVisualStyleBackColor = true;
            this.rdoInternationalToDomestic.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // rdoInternationalToInternational
            // 
            this.rdoInternationalToInternational.AutoSize = true;
            this.rdoInternationalToInternational.Location = new System.Drawing.Point(165, 240);
            this.rdoInternationalToInternational.Name = "rdoInternationalToInternational";
            this.rdoInternationalToInternational.Size = new System.Drawing.Size(159, 17);
            this.rdoInternationalToInternational.TabIndex = 8;
            this.rdoInternationalToInternational.TabStop = true;
            this.rdoInternationalToInternational.Text = "Internacional a Internacional";
            this.rdoInternationalToInternational.UseVisualStyleBackColor = true;
            this.rdoInternationalToInternational.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // rdoDomesticToInternational
            // 
            this.rdoDomesticToInternational.AutoSize = true;
            this.rdoDomesticToInternational.Location = new System.Drawing.Point(165, 217);
            this.rdoDomesticToInternational.Name = "rdoDomesticToInternational";
            this.rdoDomesticToInternational.Size = new System.Drawing.Size(148, 17);
            this.rdoDomesticToInternational.TabIndex = 7;
            this.rdoDomesticToInternational.TabStop = true;
            this.rdoDomesticToInternational.Text = "Domestica a Internacional";
            this.rdoDomesticToInternational.UseVisualStyleBackColor = true;
            this.rdoDomesticToInternational.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // rdoDomesticToDomestic
            // 
            this.rdoDomesticToDomestic.AutoSize = true;
            this.rdoDomesticToDomestic.Location = new System.Drawing.Point(165, 194);
            this.rdoDomesticToDomestic.Name = "rdoDomesticToDomestic";
            this.rdoDomesticToDomestic.Size = new System.Drawing.Size(137, 17);
            this.rdoDomesticToDomestic.TabIndex = 6;
            this.rdoDomesticToDomestic.TabStop = true;
            this.rdoDomesticToDomestic.Text = "Domestica a Domestica";
            this.rdoDomesticToDomestic.UseVisualStyleBackColor = true;
            this.rdoDomesticToDomestic.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // lblTypeConexion
            // 
            this.lblTypeConexion.AutoSize = true;
            this.lblTypeConexion.ForeColor = System.Drawing.Color.DarkCyan;
            this.lblTypeConexion.Location = new System.Drawing.Point(45, 196);
            this.lblTypeConexion.Name = "lblTypeConexion";
            this.lblTypeConexion.Size = new System.Drawing.Size(93, 13);
            this.lblTypeConexion.TabIndex = 9;
            this.lblTypeConexion.Text = "Tipo de Conexión:";
            // 
            // btnAccept
            // 
            this.btnAccept.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnAccept.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAccept.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAccept.Location = new System.Drawing.Point(260, 314);
            this.btnAccept.Name = "btnAccept";
            this.btnAccept.Size = new System.Drawing.Size(100, 23);
            this.btnAccept.TabIndex = 10;
            this.btnAccept.Text = "Aceptar";
            this.btnAccept.UseVisualStyleBackColor = false;
            this.btnAccept.Click += new System.EventHandler(this.btnAccept_Click);
            // 
            // lbCityCode
            // 
            this.lbCityCode.DisplayMember = "Text";
            this.lbCityCode.FormattingEnabled = true;
            this.lbCityCode.Location = new System.Drawing.Point(31, 336);
            this.lbCityCode.Name = "lbCityCode";
            this.lbCityCode.Size = new System.Drawing.Size(195, 95);
            this.lbCityCode.TabIndex = 14;
            this.lbCityCode.ValueMember = "Value";
            this.lbCityCode.MouseClick += new System.Windows.Forms.MouseEventHandler(this.ListBox_MouseClick);
            this.lbCityCode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.lbCityCode_KeyDown);
            // 
            // lbAirportArrival
            // 
            this.lbAirportArrival.DisplayMember = "Text";
            this.lbAirportArrival.FormattingEnabled = true;
            this.lbAirportArrival.Location = new System.Drawing.Point(31, 460);
            this.lbAirportArrival.Name = "lbAirportArrival";
            this.lbAirportArrival.Size = new System.Drawing.Size(195, 95);
            this.lbAirportArrival.TabIndex = 14;
            this.lbAirportArrival.ValueMember = "Value";
            this.lbAirportArrival.MouseClick += new System.Windows.Forms.MouseEventHandler(this.ListBox_MouseClick);
            this.lbAirportArrival.KeyDown += new System.Windows.Forms.KeyEventHandler(this.lbAirportArrival_KeyDown);
            // 
            // lbAirline
            // 
            this.lbAirline.DisplayMember = "Text";
            this.lbAirline.FormattingEnabled = true;
            this.lbAirline.Location = new System.Drawing.Point(31, 359);
            this.lbAirline.Name = "lbAirline";
            this.lbAirline.Size = new System.Drawing.Size(195, 95);
            this.lbAirline.TabIndex = 14;
            this.lbAirline.ValueMember = "Value";
            this.lbAirline.MouseClick += new System.Windows.Forms.MouseEventHandler(this.ListBox_MouseClick);
            this.lbAirline.KeyDown += new System.Windows.Forms.KeyEventHandler(this.lbAirportArrival_KeyDown);
            // 
            // ucConectionTimeDiferentAirports
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.lbAirline);
            this.Controls.Add(this.lbAirportArrival);
            this.Controls.Add(this.lbCityCode);
            this.Controls.Add(this.btnAccept);
            this.Controls.Add(this.rdoInternationalToDomestic);
            this.Controls.Add(this.rdoInternationalToInternational);
            this.Controls.Add(this.rdoDomesticToInternational);
            this.Controls.Add(this.rdoDomesticToDomestic);
            this.Controls.Add(this.lblTypeConexion);
            this.Controls.Add(this.lblAirlineDeparture);
            this.Controls.Add(this.lblArlineArrival);
            this.Controls.Add(this.lblAirportDeparture);
            this.Controls.Add(this.lblAirportArrival);
            this.Controls.Add(this.lblCityCode);
            this.Controls.Add(this.txtAirlineDeparture);
            this.Controls.Add(this.txtAirlineArrival);
            this.Controls.Add(this.txtAirportDeparture);
            this.Controls.Add(this.txtAirportArrival);
            this.Controls.Add(this.txtCodeCity);
            this.Controls.Add(this.lblTitle);
            this.Name = "ucConectionTimeDiferentAirports";
            this.Size = new System.Drawing.Size(411, 580);
            this.Load += new System.EventHandler(this.ucConectionTimeDiferentAirports_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.Label lblTitle;
        private MyCTS.Forms.UI.SmartTextBox txtCodeCity;
        private System.Windows.Forms.Label lblCityCode;
        private MyCTS.Forms.UI.SmartTextBox txtAirportArrival;
        private System.Windows.Forms.Label lblAirportArrival;
        private MyCTS.Forms.UI.SmartTextBox txtAirportDeparture;
        private System.Windows.Forms.Label lblAirportDeparture;
        private MyCTS.Forms.UI.SmartTextBox txtAirlineArrival;
        private System.Windows.Forms.Label lblArlineArrival;
        private MyCTS.Forms.UI.SmartTextBox txtAirlineDeparture;
        private System.Windows.Forms.Label lblAirlineDeparture;
        private System.Windows.Forms.RadioButton rdoInternationalToDomestic;
        private System.Windows.Forms.RadioButton rdoInternationalToInternational;
        private System.Windows.Forms.RadioButton rdoDomesticToInternational;
        private System.Windows.Forms.RadioButton rdoDomesticToDomestic;
        private System.Windows.Forms.Label lblTypeConexion;
        private System.Windows.Forms.Button btnAccept;
        private System.Windows.Forms.ListBox lbCityCode;
        private System.Windows.Forms.ListBox lbAirportArrival;
        private System.Windows.Forms.ListBox lbAirline;
    }
}
