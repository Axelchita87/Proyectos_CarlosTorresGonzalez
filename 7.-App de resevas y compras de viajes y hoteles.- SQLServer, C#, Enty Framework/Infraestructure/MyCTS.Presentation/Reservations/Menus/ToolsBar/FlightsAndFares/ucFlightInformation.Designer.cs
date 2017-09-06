namespace MyCTS.Presentation
{
    partial class ucFlightInformation
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
            this.lbAirlines = new System.Windows.Forms.ListBox();
            this.picCalender = new System.Windows.Forms.PictureBox();
            this.txtFlightNumber = new MyCTS.Forms.UI.SmartTextBox();
            this.txtAirLine = new MyCTS.Forms.UI.SmartTextBox();
            this.txtDate = new MyCTS.Forms.UI.SmartTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnAccept = new System.Windows.Forms.Button();
            this.lblTitle = new System.Windows.Forms.Label();
            this.monthCalendar1 = new System.Windows.Forms.MonthCalendar();
            ((System.ComponentModel.ISupportInitialize)(this.picCalender)).BeginInit();
            this.SuspendLayout();
            // 
            // lbAirlines
            // 
            this.lbAirlines.DisplayMember = "Text";
            this.lbAirlines.FormattingEnabled = true;
            this.lbAirlines.Location = new System.Drawing.Point(120, 96);
            this.lbAirlines.Name = "lbAirlines";
            this.lbAirlines.Size = new System.Drawing.Size(195, 95);
            this.lbAirlines.TabIndex = 100;
            this.lbAirlines.ValueMember = "Value";
            this.lbAirlines.MouseClick += new System.Windows.Forms.MouseEventHandler(this.ListBox_MouseClick);
            this.lbAirlines.KeyDown += new System.Windows.Forms.KeyEventHandler(this.lbAirlines_KeyDown);
            // 
            // picCalender
            // 
            this.picCalender.Image = global::MyCTS.Presentation.Properties.Resources.calendario;
            this.picCalender.Location = new System.Drawing.Point(187, 51);
            this.picCalender.Name = "picCalender";
            this.picCalender.Size = new System.Drawing.Size(18, 20);
            this.picCalender.TabIndex = 99;
            this.picCalender.TabStop = false;
            this.picCalender.Click += new System.EventHandler(this.picCalender_Click);
            // 
            // txtFlightNumber
            // 
            this.txtFlightNumber.AllowBlankSpaces = true;
            this.txtFlightNumber.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtFlightNumber.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.OnlyNumbers;
            this.txtFlightNumber.CustomExpression = ".*";
            this.txtFlightNumber.EnterColor = System.Drawing.Color.Empty;
            this.txtFlightNumber.LeaveColor = System.Drawing.Color.Empty;
            this.txtFlightNumber.Location = new System.Drawing.Point(120, 108);
            this.txtFlightNumber.MaxLength = 5;
            this.txtFlightNumber.Name = "txtFlightNumber";
            this.txtFlightNumber.Size = new System.Drawing.Size(67, 20);
            this.txtFlightNumber.TabIndex = 95;
            this.txtFlightNumber.TextChanged += new System.EventHandler(this.txtFlightNumber_TextChanged);
            this.txtFlightNumber.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // txtAirLine
            // 
            this.txtAirLine.AllowBlankSpaces = true;
            this.txtAirLine.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtAirLine.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.AnyCharacter;
            this.txtAirLine.CustomExpression = ".*";
            this.txtAirLine.EnterColor = System.Drawing.Color.Empty;
            this.txtAirLine.LeaveColor = System.Drawing.Color.Empty;
            this.txtAirLine.Location = new System.Drawing.Point(120, 78);
            this.txtAirLine.Name = "txtAirLine";
            this.txtAirLine.Size = new System.Drawing.Size(195, 20);
            this.txtAirLine.TabIndex = 94;
            this.txtAirLine.TextChanged += new System.EventHandler(this.txtAirLine_TextChanged);
            this.txtAirLine.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // txtDate
            // 
            this.txtDate.AllowBlankSpaces = true;
            this.txtDate.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtDate.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.NumbersOrLetters;
            this.txtDate.CustomExpression = ".*";
            this.txtDate.EnterColor = System.Drawing.Color.Empty;
            this.txtDate.LeaveColor = System.Drawing.Color.Empty;
            this.txtDate.Location = new System.Drawing.Point(120, 51);
            this.txtDate.MaxLength = 5;
            this.txtDate.Name = "txtDate";
            this.txtDate.Size = new System.Drawing.Size(67, 20);
            this.txtDate.TabIndex = 93;
            this.txtDate.TextChanged += new System.EventHandler(this.txtDate_TextChanged);
            this.txtDate.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(28, 108);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 13);
            this.label3.TabIndex = 92;
            this.label3.Text = "No. de Vuelo:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(28, 80);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 13);
            this.label2.TabIndex = 91;
            this.label2.Text = "Aerolínea:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.DarkCyan;
            this.label1.Location = new System.Drawing.Point(28, 51);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 13);
            this.label1.TabIndex = 90;
            this.label1.Text = "Fecha:";
            // 
            // btnAccept
            // 
            this.btnAccept.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnAccept.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAccept.Location = new System.Drawing.Point(287, 232);
            this.btnAccept.Name = "btnAccept";
            this.btnAccept.Size = new System.Drawing.Size(100, 23);
            this.btnAccept.TabIndex = 97;
            this.btnAccept.Text = "Aceptar";
            this.btnAccept.UseVisualStyleBackColor = false;
            this.btnAccept.Click += new System.EventHandler(this.btnAccept_Click);
            // 
            // lblTitle
            // 
            this.lblTitle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(139)))), ((int)(((byte)(208)))));
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(3, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(405, 14);
            this.lblTitle.TabIndex = 96;
            this.lblTitle.Text = "Información del Vuelo";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // monthCalendar1
            // 
            this.monthCalendar1.Location = new System.Drawing.Point(96, 67);
            this.monthCalendar1.Name = "monthCalendar1";
            this.monthCalendar1.TabIndex = 98;
            this.monthCalendar1.DateSelected += new System.Windows.Forms.DateRangeEventHandler(this.monthCalendar_DateSelected);
            this.monthCalendar1.Leave += new System.EventHandler(this.monthCalendar_Leave);
            this.monthCalendar1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.monthCalendar_KeyDown);
            // 
            // ucFlightInformation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.lbAirlines);
            this.Controls.Add(this.picCalender);
            this.Controls.Add(this.txtFlightNumber);
            this.Controls.Add(this.txtAirLine);
            this.Controls.Add(this.txtDate);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnAccept);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.monthCalendar1);
            this.Name = "ucFlightInformation";
            this.Size = new System.Drawing.Size(411, 580);
            this.Load += new System.EventHandler(this.ucFlightInformation_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picCalender)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lbAirlines;
        private System.Windows.Forms.PictureBox picCalender;
        private MyCTS.Forms.UI.SmartTextBox txtFlightNumber;
        private MyCTS.Forms.UI.SmartTextBox txtAirLine;
        private MyCTS.Forms.UI.SmartTextBox txtDate;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnAccept;
        internal System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.MonthCalendar monthCalendar1;
    }
}
