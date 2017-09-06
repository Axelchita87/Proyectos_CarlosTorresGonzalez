namespace MyCTS.Presentation
{
    partial class ucDefineGroup
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucDefineGroup));
            this.lblDefineGroup = new System.Windows.Forms.Label();
            this.lblPlaceReservation = new System.Windows.Forms.Label();
            this.txtPlaceReservation = new MyCTS.Forms.UI.SmartTextBox();
            this.lblGroupName = new System.Windows.Forms.Label();
            this.txtGroupName = new MyCTS.Forms.UI.SmartTextBox();
            this.lblDK = new System.Windows.Forms.Label();
            this.txtDK = new MyCTS.Forms.UI.SmartTextBox();
            this.lblOriginCity = new System.Windows.Forms.Label();
            this.txtOriginCity = new MyCTS.Forms.UI.SmartTextBox();
            this.lblAirline = new System.Windows.Forms.Label();
            this.txtAirline = new MyCTS.Forms.UI.SmartTextBox();
            this.lblTimeDeparture = new System.Windows.Forms.Label();
            this.txtTimeDeparture = new MyCTS.Forms.UI.SmartTextBox();
            this.lblDate = new System.Windows.Forms.Label();
            this.txtDate = new MyCTS.Forms.UI.SmartTextBox();
            this.btnAccept = new System.Windows.Forms.Button();
            this.lblIndet = new System.Windows.Forms.Label();
            this.Calendar = new System.Windows.Forms.PictureBox();
            this.monthCalendar1 = new System.Windows.Forms.MonthCalendar();
            this.lbGeneric = new System.Windows.Forms.ListBox();
            this.lblCodeGroup = new System.Windows.Forms.Label();
            this.txtCodeGroup = new MyCTS.Forms.UI.SmartTextBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.Calendar)).BeginInit();
            this.SuspendLayout();
            // 
            // lblDefineGroup
            // 
            this.lblDefineGroup.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(139)))), ((int)(((byte)(208)))));
            this.lblDefineGroup.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblDefineGroup.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDefineGroup.ForeColor = System.Drawing.Color.White;
            this.lblDefineGroup.Location = new System.Drawing.Point(0, 0);
            this.lblDefineGroup.Name = "lblDefineGroup";
            this.lblDefineGroup.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblDefineGroup.Size = new System.Drawing.Size(411, 17);
            this.lblDefineGroup.TabIndex = 0;
            this.lblDefineGroup.Text = "Define Grupo";
            this.lblDefineGroup.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblPlaceReservation
            // 
            this.lblPlaceReservation.AutoSize = true;
            this.lblPlaceReservation.Location = new System.Drawing.Point(9, 34);
            this.lblPlaceReservation.Name = "lblPlaceReservation";
            this.lblPlaceReservation.Size = new System.Drawing.Size(103, 13);
            this.lblPlaceReservation.TabIndex = 0;
            this.lblPlaceReservation.Text = "Lugares a Reservar:";
            // 
            // txtPlaceReservation
            // 
            this.txtPlaceReservation.AllowBlankSpaces = true;
            this.txtPlaceReservation.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtPlaceReservation.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.OnlyNumbers;
            this.txtPlaceReservation.CustomExpression = ".*";
            this.txtPlaceReservation.EnterColor = System.Drawing.Color.Empty;
            this.txtPlaceReservation.LeaveColor = System.Drawing.Color.Empty;
            this.txtPlaceReservation.Location = new System.Drawing.Point(120, 31);
            this.txtPlaceReservation.MaxLength = 3;
            this.txtPlaceReservation.Name = "txtPlaceReservation";
            this.txtPlaceReservation.Size = new System.Drawing.Size(46, 20);
            this.txtPlaceReservation.TabIndex = 1;
            this.txtPlaceReservation.TextChanged += new System.EventHandler(this.txtPlaceReservation_TextChanged);
            this.txtPlaceReservation.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // lblGroupName
            // 
            this.lblGroupName.AutoSize = true;
            this.lblGroupName.Location = new System.Drawing.Point(12, 73);
            this.lblGroupName.Name = "lblGroupName";
            this.lblGroupName.Size = new System.Drawing.Size(96, 13);
            this.lblGroupName.TabIndex = 0;
            this.lblGroupName.Text = "Nombre del Grupo:";
            // 
            // txtGroupName
            // 
            this.txtGroupName.AllowBlankSpaces = true;
            this.txtGroupName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtGroupName.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.OnlyLetters;
            this.txtGroupName.CustomExpression = ".*";
            this.txtGroupName.EnterColor = System.Drawing.Color.Empty;
            this.txtGroupName.LeaveColor = System.Drawing.Color.Empty;
            this.txtGroupName.Location = new System.Drawing.Point(120, 70);
            this.txtGroupName.MaxLength = 50;
            this.txtGroupName.Name = "txtGroupName";
            this.txtGroupName.Size = new System.Drawing.Size(281, 20);
            this.txtGroupName.TabIndex = 2;
            this.txtGroupName.TextChanged += new System.EventHandler(this.txtGroupName_TextChanged);
            this.txtGroupName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // lblDK
            // 
            this.lblDK.AutoSize = true;
            this.lblDK.Location = new System.Drawing.Point(9, 136);
            this.lblDK.Name = "lblDK";
            this.lblDK.Size = new System.Drawing.Size(25, 13);
            this.lblDK.TabIndex = 0;
            this.lblDK.Text = "DK:";
            // 
            // txtDK
            // 
            this.txtDK.AllowBlankSpaces = true;
            this.txtDK.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtDK.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.AnyCharacter;
            this.txtDK.CustomExpression = ".*";
            this.txtDK.EnterColor = System.Drawing.Color.Empty;
            this.txtDK.LeaveColor = System.Drawing.Color.Empty;
            this.txtDK.Location = new System.Drawing.Point(120, 133);
            this.txtDK.Name = "txtDK";
            this.txtDK.Size = new System.Drawing.Size(144, 20);
            this.txtDK.TabIndex = 4;
            this.txtDK.TextChanged += new System.EventHandler(this.txtDK_TextChanged);
            this.txtDK.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // lblOriginCity
            // 
            this.lblOriginCity.AutoSize = true;
            this.lblOriginCity.Location = new System.Drawing.Point(10, 186);
            this.lblOriginCity.Name = "lblOriginCity";
            this.lblOriginCity.Size = new System.Drawing.Size(92, 13);
            this.lblOriginCity.TabIndex = 0;
            this.lblOriginCity.Text = "Ciudad de Origen:";
            // 
            // txtOriginCity
            // 
            this.txtOriginCity.AllowBlankSpaces = true;
            this.txtOriginCity.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtOriginCity.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.AnyCharacter;
            this.txtOriginCity.CustomExpression = ".*";
            this.txtOriginCity.EnterColor = System.Drawing.Color.Empty;
            this.txtOriginCity.LeaveColor = System.Drawing.Color.Empty;
            this.txtOriginCity.Location = new System.Drawing.Point(120, 186);
            this.txtOriginCity.Name = "txtOriginCity";
            this.txtOriginCity.Size = new System.Drawing.Size(144, 20);
            this.txtOriginCity.TabIndex = 5;
            this.txtOriginCity.TextChanged += new System.EventHandler(this.txtOriginCity_TextChanged);
            this.txtOriginCity.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // lblAirline
            // 
            this.lblAirline.AutoSize = true;
            this.lblAirline.Location = new System.Drawing.Point(10, 220);
            this.lblAirline.Name = "lblAirline";
            this.lblAirline.Size = new System.Drawing.Size(54, 13);
            this.lblAirline.TabIndex = 0;
            this.lblAirline.Text = "Aerolinea:";
            // 
            // txtAirline
            // 
            this.txtAirline.AllowBlankSpaces = true;
            this.txtAirline.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtAirline.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.AnyCharacter;
            this.txtAirline.CustomExpression = ".*";
            this.txtAirline.EnterColor = System.Drawing.Color.Empty;
            this.txtAirline.LeaveColor = System.Drawing.Color.Empty;
            this.txtAirline.Location = new System.Drawing.Point(120, 220);
            this.txtAirline.Name = "txtAirline";
            this.txtAirline.Size = new System.Drawing.Size(144, 20);
            this.txtAirline.TabIndex = 6;
            this.txtAirline.TextChanged += new System.EventHandler(this.txtAirline_TextChanged);
            this.txtAirline.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // lblTimeDeparture
            // 
            this.lblTimeDeparture.AutoSize = true;
            this.lblTimeDeparture.Location = new System.Drawing.Point(10, 252);
            this.lblTimeDeparture.Name = "lblTimeDeparture";
            this.lblTimeDeparture.Size = new System.Drawing.Size(78, 13);
            this.lblTimeDeparture.TabIndex = 0;
            this.lblTimeDeparture.Text = "Hora de salida:";
            // 
            // txtTimeDeparture
            // 
            this.txtTimeDeparture.AllowBlankSpaces = true;
            this.txtTimeDeparture.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtTimeDeparture.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.NumbersOrLetters;
            this.txtTimeDeparture.CustomExpression = ".*";
            this.txtTimeDeparture.EnterColor = System.Drawing.Color.Empty;
            this.txtTimeDeparture.LeaveColor = System.Drawing.Color.Empty;
            this.txtTimeDeparture.Location = new System.Drawing.Point(120, 252);
            this.txtTimeDeparture.MaxLength = 3;
            this.txtTimeDeparture.Name = "txtTimeDeparture";
            this.txtTimeDeparture.Size = new System.Drawing.Size(59, 20);
            this.txtTimeDeparture.TabIndex = 7;
            this.txtTimeDeparture.TextChanged += new System.EventHandler(this.txtTimeDeparture_TextChanged);
            this.txtTimeDeparture.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.Location = new System.Drawing.Point(13, 291);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(40, 13);
            this.lblDate.TabIndex = 0;
            this.lblDate.Text = "Fecha:";
            // 
            // txtDate
            // 
            this.txtDate.AllowBlankSpaces = true;
            this.txtDate.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtDate.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.AnyCharacter;
            this.txtDate.CustomExpression = ".*";
            this.txtDate.EnterColor = System.Drawing.Color.Empty;
            this.txtDate.LeaveColor = System.Drawing.Color.Empty;
            this.txtDate.Location = new System.Drawing.Point(120, 291);
            this.txtDate.MaxLength = 5;
            this.txtDate.Name = "txtDate";
            this.txtDate.Size = new System.Drawing.Size(67, 20);
            this.txtDate.TabIndex = 8;
            this.txtDate.TextChanged += new System.EventHandler(this.txtDate_TextChanged);
            this.txtDate.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // btnAccept
            // 
            this.btnAccept.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnAccept.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAccept.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAccept.Location = new System.Drawing.Point(250, 354);
            this.btnAccept.Name = "btnAccept";
            this.btnAccept.Size = new System.Drawing.Size(110, 24);
            this.btnAccept.TabIndex = 9;
            this.btnAccept.Text = "Aceptar";
            this.btnAccept.UseVisualStyleBackColor = false;
            this.btnAccept.Click += new System.EventHandler(this.btnAccept_Click);
            // 
            // lblIndet
            // 
            this.lblIndet.AutoSize = true;
            this.lblIndet.Location = new System.Drawing.Point(12, 156);
            this.lblIndet.Name = "lblIndet";
            this.lblIndet.Size = new System.Drawing.Size(379, 13);
            this.lblIndet.TabIndex = 17;
            this.lblIndet.Text = "______________________________________________________________";
            // 
            // Calendar
            // 
            this.Calendar.BackColor = System.Drawing.Color.Transparent;
            this.Calendar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Calendar.Image = ((System.Drawing.Image)(resources.GetObject("Calendar.Image")));
            this.Calendar.Location = new System.Drawing.Point(188, 291);
            this.Calendar.Name = "Calendar";
            this.Calendar.Size = new System.Drawing.Size(19, 19);
            this.Calendar.TabIndex = 66;
            this.Calendar.TabStop = false;
            this.Calendar.Click += new System.EventHandler(this.Calendar_Click);
            // 
            // monthCalendar1
            // 
            this.monthCalendar1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.monthCalendar1.Location = new System.Drawing.Point(67, 312);
            this.monthCalendar1.Name = "monthCalendar1";
            this.monthCalendar1.TabIndex = 67;
            this.monthCalendar1.DateSelected += new System.Windows.Forms.DateRangeEventHandler(this.monthCalendar1_DateSelected);
            this.monthCalendar1.Leave += new System.EventHandler(this.monthCalendar1_Leave);
            this.monthCalendar1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.monthCalendar1_KeyDown);
            // 
            // lbGeneric
            // 
            this.lbGeneric.DisplayMember = "Text";
            this.lbGeneric.FormattingEnabled = true;
            this.lbGeneric.Location = new System.Drawing.Point(120, 243);
            this.lbGeneric.Name = "lbGeneric";
            this.lbGeneric.Size = new System.Drawing.Size(144, 95);
            this.lbGeneric.TabIndex = 68;
            this.lbGeneric.ValueMember = "Vaule";
            this.lbGeneric.MouseClick += new System.Windows.Forms.MouseEventHandler(this.ListBox_MouseClick);
            this.lbGeneric.KeyDown += new System.Windows.Forms.KeyEventHandler(this.lbGeneric_KeyDown);
            // 
            // lblCodeGroup
            // 
            this.lblCodeGroup.AutoSize = true;
            this.lblCodeGroup.Location = new System.Drawing.Point(12, 102);
            this.lblCodeGroup.Name = "lblCodeGroup";
            this.lblCodeGroup.Size = new System.Drawing.Size(90, 13);
            this.lblCodeGroup.TabIndex = 0;
            this.lblCodeGroup.Text = "Código de Grupo:";
            // 
            // txtCodeGroup
            // 
            this.txtCodeGroup.AllowBlankSpaces = true;
            this.txtCodeGroup.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtCodeGroup.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.AnyCharacter;
            this.txtCodeGroup.CustomExpression = ".*";
            this.txtCodeGroup.EnterColor = System.Drawing.Color.Empty;
            this.txtCodeGroup.LeaveColor = System.Drawing.Color.Empty;
            this.txtCodeGroup.Location = new System.Drawing.Point(120, 102);
            this.txtCodeGroup.MaxLength = 10;
            this.txtCodeGroup.Name = "txtCodeGroup";
            this.txtCodeGroup.Size = new System.Drawing.Size(76, 20);
            this.txtCodeGroup.TabIndex = 3;
            this.txtCodeGroup.TextChanged += new System.EventHandler(this.txtCodeGroup_TextChanged);
            this.txtCodeGroup.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Blue;
            this.label1.Location = new System.Drawing.Point(186, 252);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 13);
            this.label1.TabIndex = 69;
            this.label1.Text = "Ej. 08A ó 12P";
            // 
            // ucDefineGroup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtCodeGroup);
            this.Controls.Add(this.lblCodeGroup);
            this.Controls.Add(this.monthCalendar1);
            this.Controls.Add(this.Calendar);
            this.Controls.Add(this.lblIndet);
            this.Controls.Add(this.btnAccept);
            this.Controls.Add(this.txtDate);
            this.Controls.Add(this.lblDate);
            this.Controls.Add(this.txtTimeDeparture);
            this.Controls.Add(this.lblTimeDeparture);
            this.Controls.Add(this.txtAirline);
            this.Controls.Add(this.lblAirline);
            this.Controls.Add(this.txtOriginCity);
            this.Controls.Add(this.lblOriginCity);
            this.Controls.Add(this.txtDK);
            this.Controls.Add(this.lblDK);
            this.Controls.Add(this.txtGroupName);
            this.Controls.Add(this.lblGroupName);
            this.Controls.Add(this.txtPlaceReservation);
            this.Controls.Add(this.lblPlaceReservation);
            this.Controls.Add(this.lblDefineGroup);
            this.Controls.Add(this.lbGeneric);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "ucDefineGroup";
            this.Size = new System.Drawing.Size(411, 580);
            this.Load += new System.EventHandler(this.ucDefineGroup_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Calendar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.Label lblDefineGroup;
        private System.Windows.Forms.Label lblPlaceReservation;
        private MyCTS.Forms.UI.SmartTextBox txtPlaceReservation;
        private System.Windows.Forms.Label lblGroupName;
        private MyCTS.Forms.UI.SmartTextBox txtGroupName;
        private System.Windows.Forms.Label lblDK;
        private MyCTS.Forms.UI.SmartTextBox txtDK;
        private System.Windows.Forms.Label lblOriginCity;
        private MyCTS.Forms.UI.SmartTextBox txtOriginCity;
        private System.Windows.Forms.Label lblAirline;
        private MyCTS.Forms.UI.SmartTextBox txtAirline;
        private System.Windows.Forms.Label lblTimeDeparture;
        private MyCTS.Forms.UI.SmartTextBox txtTimeDeparture;
        private System.Windows.Forms.Label lblDate;
        private MyCTS.Forms.UI.SmartTextBox txtDate;
        private System.Windows.Forms.Button btnAccept;
        private System.Windows.Forms.Label lblIndet;
        internal System.Windows.Forms.PictureBox Calendar;
        private System.Windows.Forms.MonthCalendar monthCalendar1;
        private System.Windows.Forms.ListBox lbGeneric;
        private System.Windows.Forms.Label lblCodeGroup;
        private MyCTS.Forms.UI.SmartTextBox txtCodeGroup;
        private System.Windows.Forms.Label label1;
    }
}
