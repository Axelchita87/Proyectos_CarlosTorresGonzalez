namespace MyCTS.Presentation
{
    partial class ucInsertDataPassenger
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucInsertDataPassenger));
            this.lblIntroduceDataPassenger = new System.Windows.Forms.Label();
            this.txtRecordLocalizer = new MyCTS.Forms.UI.SmartTextBox();
            this.lblRecordLocalizer = new System.Windows.Forms.Label();
            this.lblPlaceReserve = new System.Windows.Forms.Label();
            this.txtPlaceReserve = new MyCTS.Forms.UI.SmartTextBox();
            this.lblTimeLimit = new System.Windows.Forms.Label();
            this.txtTimeLimit = new MyCTS.Forms.UI.SmartTextBox();
            this.btnAccept = new System.Windows.Forms.Button();
            this.monthCalendar1 = new System.Windows.Forms.MonthCalendar();
            this.Calendar = new System.Windows.Forms.PictureBox();
            this.lblCodeName = new System.Windows.Forms.Label();
            this.txtCodeGroup = new MyCTS.Forms.UI.SmartTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.Calendar)).BeginInit();
            this.SuspendLayout();
            // 
            // lblIntroduceDataPassenger
            // 
            this.lblIntroduceDataPassenger.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(139)))), ((int)(((byte)(208)))));
            this.lblIntroduceDataPassenger.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIntroduceDataPassenger.ForeColor = System.Drawing.Color.White;
            this.lblIntroduceDataPassenger.Location = new System.Drawing.Point(3, 0);
            this.lblIntroduceDataPassenger.Name = "lblIntroduceDataPassenger";
            this.lblIntroduceDataPassenger.Size = new System.Drawing.Size(405, 16);
            this.lblIntroduceDataPassenger.TabIndex = 1;
            this.lblIntroduceDataPassenger.Text = "Ingresar Datos del Pasajero";
            this.lblIntroduceDataPassenger.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // txtRecordLocalizer
            // 
            this.txtRecordLocalizer.AllowBlankSpaces = true;
            this.txtRecordLocalizer.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtRecordLocalizer.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.AnyCharacter;
            this.txtRecordLocalizer.CustomExpression = ".*";
            this.txtRecordLocalizer.EnterColor = System.Drawing.Color.Empty;
            this.txtRecordLocalizer.LeaveColor = System.Drawing.Color.Empty;
            this.txtRecordLocalizer.Location = new System.Drawing.Point(120, 51);
            this.txtRecordLocalizer.MaxLength = 6;
            this.txtRecordLocalizer.Name = "txtRecordLocalizer";
            this.txtRecordLocalizer.Size = new System.Drawing.Size(87, 20);
            this.txtRecordLocalizer.TabIndex = 1;
            this.txtRecordLocalizer.TextChanged += new System.EventHandler(this.txtRecordLocalizer_TextChanged);
            this.txtRecordLocalizer.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // lblRecordLocalizer
            // 
            this.lblRecordLocalizer.AutoSize = true;
            this.lblRecordLocalizer.Location = new System.Drawing.Point(15, 54);
            this.lblRecordLocalizer.Name = "lblRecordLocalizer";
            this.lblRecordLocalizer.Size = new System.Drawing.Size(99, 13);
            this.lblRecordLocalizer.TabIndex = 0;
            this.lblRecordLocalizer.Text = "Record Localizador";
            // 
            // lblPlaceReserve
            // 
            this.lblPlaceReserve.AutoSize = true;
            this.lblPlaceReserve.Location = new System.Drawing.Point(14, 85);
            this.lblPlaceReserve.Name = "lblPlaceReserve";
            this.lblPlaceReserve.Size = new System.Drawing.Size(100, 13);
            this.lblPlaceReserve.TabIndex = 0;
            this.lblPlaceReserve.Text = "Lugares a Reservar";
            // 
            // txtPlaceReserve
            // 
            this.txtPlaceReserve.AllowBlankSpaces = true;
            this.txtPlaceReserve.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtPlaceReserve.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.OnlyNumbers;
            this.txtPlaceReserve.CustomExpression = ".*";
            this.txtPlaceReserve.EnterColor = System.Drawing.Color.Empty;
            this.txtPlaceReserve.LeaveColor = System.Drawing.Color.Empty;
            this.txtPlaceReserve.Location = new System.Drawing.Point(120, 82);
            this.txtPlaceReserve.MaxLength = 3;
            this.txtPlaceReserve.Name = "txtPlaceReserve";
            this.txtPlaceReserve.Size = new System.Drawing.Size(55, 20);
            this.txtPlaceReserve.TabIndex = 2;
            this.txtPlaceReserve.TextChanged += new System.EventHandler(this.txtPlaceReserve_TextChanged);
            this.txtPlaceReserve.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // lblTimeLimit
            // 
            this.lblTimeLimit.AutoSize = true;
            this.lblTimeLimit.Location = new System.Drawing.Point(15, 116);
            this.lblTimeLimit.Name = "lblTimeLimit";
            this.lblTimeLimit.Size = new System.Drawing.Size(72, 13);
            this.lblTimeLimit.TabIndex = 0;
            this.lblTimeLimit.Text = "Tiempo Limite";
            // 
            // txtTimeLimit
            // 
            this.txtTimeLimit.AllowBlankSpaces = true;
            this.txtTimeLimit.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtTimeLimit.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.AnyCharacter;
            this.txtTimeLimit.CustomExpression = ".*";
            this.txtTimeLimit.EnterColor = System.Drawing.Color.Empty;
            this.txtTimeLimit.LeaveColor = System.Drawing.Color.Empty;
            this.txtTimeLimit.Location = new System.Drawing.Point(120, 116);
            this.txtTimeLimit.MaxLength = 5;
            this.txtTimeLimit.Name = "txtTimeLimit";
            this.txtTimeLimit.Size = new System.Drawing.Size(65, 20);
            this.txtTimeLimit.TabIndex = 3;
            this.txtTimeLimit.TextChanged += new System.EventHandler(this.txtTimeLimit_TextChanged);
            this.txtTimeLimit.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // btnAccept
            // 
            this.btnAccept.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnAccept.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAccept.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAccept.Location = new System.Drawing.Point(268, 176);
            this.btnAccept.Name = "btnAccept";
            this.btnAccept.Size = new System.Drawing.Size(100, 24);
            this.btnAccept.TabIndex = 5;
            this.btnAccept.Text = "Aceptar";
            this.btnAccept.UseVisualStyleBackColor = false;
            this.btnAccept.Click += new System.EventHandler(this.btnAccept_Click);
            // 
            // monthCalendar1
            // 
            this.monthCalendar1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.monthCalendar1.Location = new System.Drawing.Point(74, 138);
            this.monthCalendar1.Name = "monthCalendar1";
            this.monthCalendar1.TabIndex = 69;
            this.monthCalendar1.DateSelected += new System.Windows.Forms.DateRangeEventHandler(this.monthCalendar1_DateSelected);
            this.monthCalendar1.Leave += new System.EventHandler(this.monthCalendar1_Leave);
            this.monthCalendar1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.monthCalendar1_KeyDown);
            // 
            // Calendar
            // 
            this.Calendar.BackColor = System.Drawing.Color.Transparent;
            this.Calendar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Calendar.Image = ((System.Drawing.Image)(resources.GetObject("Calendar.Image")));
            this.Calendar.Location = new System.Drawing.Point(188, 117);
            this.Calendar.Name = "Calendar";
            this.Calendar.Size = new System.Drawing.Size(19, 19);
            this.Calendar.TabIndex = 68;
            this.Calendar.TabStop = false;
            this.Calendar.Click += new System.EventHandler(this.Calendar_Click);
            // 
            // lblCodeName
            // 
            this.lblCodeName.AutoSize = true;
            this.lblCodeName.Location = new System.Drawing.Point(15, 147);
            this.lblCodeName.Name = "lblCodeName";
            this.lblCodeName.Size = new System.Drawing.Size(87, 13);
            this.lblCodeName.TabIndex = 0;
            this.lblCodeName.Text = "Código de Grupo";
            // 
            // txtCodeGroup
            // 
            this.txtCodeGroup.AllowBlankSpaces = true;
            this.txtCodeGroup.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtCodeGroup.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.AnyCharacter;
            this.txtCodeGroup.CustomExpression = ".*";
            this.txtCodeGroup.EnterColor = System.Drawing.Color.Empty;
            this.txtCodeGroup.LeaveColor = System.Drawing.Color.Empty;
            this.txtCodeGroup.Location = new System.Drawing.Point(120, 144);
            this.txtCodeGroup.MaxLength = 10;
            this.txtCodeGroup.Name = "txtCodeGroup";
            this.txtCodeGroup.Size = new System.Drawing.Size(100, 20);
            this.txtCodeGroup.TabIndex = 4;
            this.txtCodeGroup.TextChanged += new System.EventHandler(this.txtCodeGroup_TextChanged);
            this.txtCodeGroup.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // ucInsertDataPassenger
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.txtCodeGroup);
            this.Controls.Add(this.lblCodeName);
            this.Controls.Add(this.Calendar);
            this.Controls.Add(this.btnAccept);
            this.Controls.Add(this.txtTimeLimit);
            this.Controls.Add(this.lblTimeLimit);
            this.Controls.Add(this.txtPlaceReserve);
            this.Controls.Add(this.lblPlaceReserve);
            this.Controls.Add(this.lblRecordLocalizer);
            this.Controls.Add(this.txtRecordLocalizer);
            this.Controls.Add(this.lblIntroduceDataPassenger);
            this.Controls.Add(this.monthCalendar1);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "ucInsertDataPassenger";
            this.Size = new System.Drawing.Size(411, 580);
            this.Load += new System.EventHandler(this.ucInsertDataPassenger_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Calendar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.Label lblIntroduceDataPassenger;
        private MyCTS.Forms.UI.SmartTextBox txtRecordLocalizer;
        private System.Windows.Forms.Label lblRecordLocalizer;
        private System.Windows.Forms.Label lblPlaceReserve;
        private MyCTS.Forms.UI.SmartTextBox txtPlaceReserve;
        private System.Windows.Forms.Label lblTimeLimit;
        private MyCTS.Forms.UI.SmartTextBox txtTimeLimit;
        private System.Windows.Forms.Button btnAccept;
        private System.Windows.Forms.MonthCalendar monthCalendar1;
        internal System.Windows.Forms.PictureBox Calendar;
        private System.Windows.Forms.Label lblCodeName;
        private MyCTS.Forms.UI.SmartTextBox txtCodeGroup;
    }
}
