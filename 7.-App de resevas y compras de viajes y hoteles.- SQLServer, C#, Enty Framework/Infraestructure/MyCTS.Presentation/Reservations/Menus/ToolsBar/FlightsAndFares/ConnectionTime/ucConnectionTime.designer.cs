namespace MyCTS.Presentation
{
    partial class ucConnectionTime
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
            this.txtAirportCode = new MyCTS.Forms.UI.SmartTextBox();
            this.txtAirlineArrival = new MyCTS.Forms.UI.SmartTextBox();
            this.txtAirlineDeparture = new MyCTS.Forms.UI.SmartTextBox();
            this.lblAirportCode = new System.Windows.Forms.Label();
            this.lblAirlineArrival = new System.Windows.Forms.Label();
            this.lblAirlineDeparture = new System.Windows.Forms.Label();
            this.lblTypeConexion = new System.Windows.Forms.Label();
            this.rdoDomesticToDomestic = new System.Windows.Forms.RadioButton();
            this.rdoDomesticToInternational = new System.Windows.Forms.RadioButton();
            this.rdoInternationalToInternational = new System.Windows.Forms.RadioButton();
            this.rdoInternationalToDomestic = new System.Windows.Forms.RadioButton();
            this.btnAccept = new System.Windows.Forms.Button();
            this.lbAirport = new System.Windows.Forms.ListBox();
            this.lbAirLine1 = new System.Windows.Forms.ListBox();
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
            this.lblTitle.TabIndex = 2;
            this.lblTitle.Text = "Tiempo de Conexión - Mismo Aeropuerto";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // txtAirportCode
            // 
            this.txtAirportCode.AllowBlankSpaces = false;
            this.txtAirportCode.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtAirportCode.CharsIncluded = new char[0];
            this.txtAirportCode.CharsNoIncluded = new char[0];
            this.txtAirportCode.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.OnlyLetters;
            this.txtAirportCode.CustomExpression = ".*";
            this.txtAirportCode.EnterColor = System.Drawing.Color.Empty;
            this.txtAirportCode.LeaveColor = System.Drawing.Color.Empty;
            this.txtAirportCode.Location = new System.Drawing.Point(155, 47);
            this.txtAirportCode.MaxLength = 52;
            this.txtAirportCode.Name = "txtAirportCode";
            this.txtAirportCode.Size = new System.Drawing.Size(195, 20);
            this.txtAirportCode.TabIndex = 1;
            this.txtAirportCode.TextChanged += new System.EventHandler(this.txtAirportCode_TextChanged);
            this.txtAirportCode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.AirportActions_KeyDown);
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
            this.txtAirlineArrival.Location = new System.Drawing.Point(155, 80);
            this.txtAirlineArrival.MaxLength = 52;
            this.txtAirlineArrival.Name = "txtAirlineArrival";
            this.txtAirlineArrival.Size = new System.Drawing.Size(195, 20);
            this.txtAirlineArrival.TabIndex = 2;
            this.txtAirlineArrival.TextChanged += new System.EventHandler(this.txtAirlineArrival_TextChanged);
            this.txtAirlineArrival.KeyDown += new System.Windows.Forms.KeyEventHandler(this.AirLine1Actions_KeyDown);
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
            this.txtAirlineDeparture.Location = new System.Drawing.Point(155, 111);
            this.txtAirlineDeparture.MaxLength = 52;
            this.txtAirlineDeparture.Name = "txtAirlineDeparture";
            this.txtAirlineDeparture.Size = new System.Drawing.Size(195, 20);
            this.txtAirlineDeparture.TabIndex = 3;
            this.txtAirlineDeparture.TextChanged += new System.EventHandler(this.txtAirlineArrival_TextChanged);
            this.txtAirlineDeparture.KeyDown += new System.Windows.Forms.KeyEventHandler(this.AirLine1Actions_KeyDown);
            // 
            // lblAirportCode
            // 
            this.lblAirportCode.AutoSize = true;
            this.lblAirportCode.Location = new System.Drawing.Point(38, 53);
            this.lblAirportCode.Name = "lblAirportCode";
            this.lblAirportCode.Size = new System.Drawing.Size(113, 13);
            this.lblAirportCode.TabIndex = 4;
            this.lblAirportCode.Text = "Código de Aeropuerto:";
            // 
            // lblAirlineArrival
            // 
            this.lblAirlineArrival.AutoSize = true;
            this.lblAirlineArrival.ForeColor = System.Drawing.Color.DarkCyan;
            this.lblAirlineArrival.Location = new System.Drawing.Point(41, 86);
            this.lblAirlineArrival.Name = "lblAirlineArrival";
            this.lblAirlineArrival.Size = new System.Drawing.Size(108, 13);
            this.lblAirlineArrival.TabIndex = 5;
            this.lblAirlineArrival.Text = "Aerolínea de llegada:";
            // 
            // lblAirlineDeparture
            // 
            this.lblAirlineDeparture.AutoSize = true;
            this.lblAirlineDeparture.ForeColor = System.Drawing.Color.DarkCyan;
            this.lblAirlineDeparture.Location = new System.Drawing.Point(41, 118);
            this.lblAirlineDeparture.Name = "lblAirlineDeparture";
            this.lblAirlineDeparture.Size = new System.Drawing.Size(101, 13);
            this.lblAirlineDeparture.TabIndex = 5;
            this.lblAirlineDeparture.Text = "Aerolínea de salida:";
            // 
            // lblTypeConexion
            // 
            this.lblTypeConexion.AutoSize = true;
            this.lblTypeConexion.ForeColor = System.Drawing.Color.DarkCyan;
            this.lblTypeConexion.Location = new System.Drawing.Point(41, 161);
            this.lblTypeConexion.Name = "lblTypeConexion";
            this.lblTypeConexion.Size = new System.Drawing.Size(93, 13);
            this.lblTypeConexion.TabIndex = 5;
            this.lblTypeConexion.Text = "Tipo de Conexión:";
            // 
            // rdoDomesticToDomestic
            // 
            this.rdoDomesticToDomestic.AutoSize = true;
            this.rdoDomesticToDomestic.Location = new System.Drawing.Point(155, 159);
            this.rdoDomesticToDomestic.Name = "rdoDomesticToDomestic";
            this.rdoDomesticToDomestic.Size = new System.Drawing.Size(137, 17);
            this.rdoDomesticToDomestic.TabIndex = 4;
            this.rdoDomesticToDomestic.TabStop = true;
            this.rdoDomesticToDomestic.Text = "Domestica a Domestica";
            this.rdoDomesticToDomestic.UseVisualStyleBackColor = true;
            this.rdoDomesticToDomestic.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // rdoDomesticToInternational
            // 
            this.rdoDomesticToInternational.AutoSize = true;
            this.rdoDomesticToInternational.Location = new System.Drawing.Point(155, 182);
            this.rdoDomesticToInternational.Name = "rdoDomesticToInternational";
            this.rdoDomesticToInternational.Size = new System.Drawing.Size(148, 17);
            this.rdoDomesticToInternational.TabIndex = 5;
            this.rdoDomesticToInternational.TabStop = true;
            this.rdoDomesticToInternational.Text = "Domestica a Internacional";
            this.rdoDomesticToInternational.UseVisualStyleBackColor = true;
            this.rdoDomesticToInternational.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // rdoInternationalToInternational
            // 
            this.rdoInternationalToInternational.AutoSize = true;
            this.rdoInternationalToInternational.Location = new System.Drawing.Point(155, 205);
            this.rdoInternationalToInternational.Name = "rdoInternationalToInternational";
            this.rdoInternationalToInternational.Size = new System.Drawing.Size(159, 17);
            this.rdoInternationalToInternational.TabIndex = 6;
            this.rdoInternationalToInternational.TabStop = true;
            this.rdoInternationalToInternational.Text = "Internacional a Internacional";
            this.rdoInternationalToInternational.UseVisualStyleBackColor = true;
            this.rdoInternationalToInternational.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // rdoInternationalToDomestic
            // 
            this.rdoInternationalToDomestic.AutoSize = true;
            this.rdoInternationalToDomestic.Location = new System.Drawing.Point(155, 228);
            this.rdoInternationalToDomestic.Name = "rdoInternationalToDomestic";
            this.rdoInternationalToDomestic.Size = new System.Drawing.Size(148, 17);
            this.rdoInternationalToDomestic.TabIndex = 7;
            this.rdoInternationalToDomestic.TabStop = true;
            this.rdoInternationalToDomestic.Text = "Internacional a Domestica";
            this.rdoInternationalToDomestic.UseVisualStyleBackColor = true;
            this.rdoInternationalToDomestic.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // btnAccept
            // 
            this.btnAccept.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnAccept.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAccept.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAccept.Location = new System.Drawing.Point(280, 291);
            this.btnAccept.Name = "btnAccept";
            this.btnAccept.Size = new System.Drawing.Size(100, 23);
            this.btnAccept.TabIndex = 8;
            this.btnAccept.Text = "Aceptar";
            this.btnAccept.UseVisualStyleBackColor = false;
            this.btnAccept.Click += new System.EventHandler(this.btnAccept_Click);
            // 
            // lbAirport
            // 
            this.lbAirport.DisplayMember = "Text";
            this.lbAirport.FormattingEnabled = true;
            this.lbAirport.Location = new System.Drawing.Point(24, 431);
            this.lbAirport.Name = "lbAirport";
            this.lbAirport.Size = new System.Drawing.Size(194, 95);
            this.lbAirport.TabIndex = 9;
            this.lbAirport.ValueMember = "Value";
            this.lbAirport.MouseClick += new System.Windows.Forms.MouseEventHandler(this.ListBox_MouseClick);
            this.lbAirport.KeyDown += new System.Windows.Forms.KeyEventHandler(this.lbAirport_KeyDown);
            // 
            // lbAirLine1
            // 
            this.lbAirLine1.DisplayMember = "Text";
            this.lbAirLine1.FormattingEnabled = true;
            this.lbAirLine1.Location = new System.Drawing.Point(24, 320);
            this.lbAirLine1.Name = "lbAirLine1";
            this.lbAirLine1.Size = new System.Drawing.Size(194, 95);
            this.lbAirLine1.TabIndex = 9;
            this.lbAirLine1.ValueMember = "Value";
            this.lbAirLine1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.ListBox_MouseClick);
            this.lbAirLine1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.lbAirline1_KeyDown);
            // 
            // ucConnectionTime
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.lbAirLine1);
            this.Controls.Add(this.lbAirport);
            this.Controls.Add(this.btnAccept);
            this.Controls.Add(this.rdoInternationalToDomestic);
            this.Controls.Add(this.rdoInternationalToInternational);
            this.Controls.Add(this.rdoDomesticToInternational);
            this.Controls.Add(this.rdoDomesticToDomestic);
            this.Controls.Add(this.lblTypeConexion);
            this.Controls.Add(this.lblAirlineDeparture);
            this.Controls.Add(this.lblAirlineArrival);
            this.Controls.Add(this.lblAirportCode);
            this.Controls.Add(this.txtAirlineDeparture);
            this.Controls.Add(this.txtAirlineArrival);
            this.Controls.Add(this.txtAirportCode);
            this.Controls.Add(this.lblTitle);
            this.Name = "ucConnectionTime";
            this.Size = new System.Drawing.Size(411, 580);
            this.Load += new System.EventHandler(this.ucConnectionTime_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.Label lblTitle;
        private MyCTS.Forms.UI.SmartTextBox txtAirportCode;
        private MyCTS.Forms.UI.SmartTextBox txtAirlineArrival;
        private MyCTS.Forms.UI.SmartTextBox txtAirlineDeparture;
        private System.Windows.Forms.Label lblAirportCode;
        private System.Windows.Forms.Label lblAirlineArrival;
        private System.Windows.Forms.Label lblAirlineDeparture;
        private System.Windows.Forms.Label lblTypeConexion;
        private System.Windows.Forms.RadioButton rdoDomesticToDomestic;
        private System.Windows.Forms.RadioButton rdoDomesticToInternational;
        private System.Windows.Forms.RadioButton rdoInternationalToInternational;
        private System.Windows.Forms.RadioButton rdoInternationalToDomestic;
        private System.Windows.Forms.Button btnAccept;
        private System.Windows.Forms.ListBox lbAirport;
        private System.Windows.Forms.ListBox lbAirLine1;
    }
}
