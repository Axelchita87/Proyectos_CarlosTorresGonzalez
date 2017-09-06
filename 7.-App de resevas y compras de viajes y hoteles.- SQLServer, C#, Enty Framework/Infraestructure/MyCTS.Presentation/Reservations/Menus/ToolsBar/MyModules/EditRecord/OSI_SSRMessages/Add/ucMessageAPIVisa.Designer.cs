namespace MyCTS.Presentation
{
    partial class ucMessageAPIVisa
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
            this.txtSegment1 = new MyCTS.Forms.UI.SmartTextBox();
            this.txtSegment2 = new MyCTS.Forms.UI.SmartTextBox();
            this.txtSegment3 = new MyCTS.Forms.UI.SmartTextBox();
            this.txtSegment4 = new MyCTS.Forms.UI.SmartTextBox();
            this.lblSegments = new System.Windows.Forms.Label();
            this.txtBirthPlace = new MyCTS.Forms.UI.SmartTextBox();
            this.lblBirthPlace = new System.Windows.Forms.Label();
            this.txtNumberOfVisa = new MyCTS.Forms.UI.SmartTextBox();
            this.lblNumberOfVisa = new System.Windows.Forms.Label();
            this.txtCityBrodcast = new MyCTS.Forms.UI.SmartTextBox();
            this.lblCityBrodcast = new System.Windows.Forms.Label();
            this.txtDateBrodcast = new MyCTS.Forms.UI.SmartTextBox();
            this.lblDateBrodcast = new System.Windows.Forms.Label();
            this.txtCountryWhereApplicable = new MyCTS.Forms.UI.SmartTextBox();
            this.lblCountryWhereApplicable = new System.Windows.Forms.Label();
            this.lblPassengerType = new System.Windows.Forms.Label();
            this.rdoAdult = new System.Windows.Forms.RadioButton();
            this.rdoBoy = new System.Windows.Forms.RadioButton();
            this.rdoInfant = new System.Windows.Forms.RadioButton();
            this.lblPaxNumber = new System.Windows.Forms.Label();
            this.txtPaxNumber = new MyCTS.Forms.UI.SmartTextBox();
            this.btnAccept = new System.Windows.Forms.Button();
            this.lblDateFormat = new System.Windows.Forms.Label();
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
            this.lblTitle.Text = "Mensaje SSR: APIS Visa";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // txtSegment1
            // 
            this.txtSegment1.AllowBlankSpaces = false;
            this.txtSegment1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtSegment1.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.OnlyNumbers;
            this.txtSegment1.CustomExpression = ".*";
            this.txtSegment1.EnterColor = System.Drawing.Color.Empty;
            this.txtSegment1.LeaveColor = System.Drawing.Color.Empty;
            this.txtSegment1.Location = new System.Drawing.Point(152, 44);
            this.txtSegment1.MaxLength = 2;
            this.txtSegment1.Name = "txtSegment1";
            this.txtSegment1.Size = new System.Drawing.Size(25, 20);
            this.txtSegment1.TabIndex = 1;
            this.txtSegment1.TextChanged += new System.EventHandler(this.txtControls_TextChanged);
            this.txtSegment1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // txtSegment2
            // 
            this.txtSegment2.AllowBlankSpaces = false;
            this.txtSegment2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtSegment2.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.OnlyNumbers;
            this.txtSegment2.CustomExpression = ".*";
            this.txtSegment2.EnterColor = System.Drawing.Color.Empty;
            this.txtSegment2.LeaveColor = System.Drawing.Color.Empty;
            this.txtSegment2.Location = new System.Drawing.Point(194, 44);
            this.txtSegment2.MaxLength = 2;
            this.txtSegment2.Name = "txtSegment2";
            this.txtSegment2.Size = new System.Drawing.Size(25, 20);
            this.txtSegment2.TabIndex = 2;
            this.txtSegment2.TextChanged += new System.EventHandler(this.txtControls_TextChanged);
            this.txtSegment2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // txtSegment3
            // 
            this.txtSegment3.AllowBlankSpaces = false;
            this.txtSegment3.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtSegment3.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.OnlyNumbers;
            this.txtSegment3.CustomExpression = ".*";
            this.txtSegment3.EnterColor = System.Drawing.Color.Empty;
            this.txtSegment3.LeaveColor = System.Drawing.Color.Empty;
            this.txtSegment3.Location = new System.Drawing.Point(234, 44);
            this.txtSegment3.MaxLength = 2;
            this.txtSegment3.Name = "txtSegment3";
            this.txtSegment3.Size = new System.Drawing.Size(25, 20);
            this.txtSegment3.TabIndex = 3;
            this.txtSegment3.TextChanged += new System.EventHandler(this.txtControls_TextChanged);
            this.txtSegment3.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // txtSegment4
            // 
            this.txtSegment4.AllowBlankSpaces = false;
            this.txtSegment4.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtSegment4.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.OnlyNumbers;
            this.txtSegment4.CustomExpression = ".*";
            this.txtSegment4.EnterColor = System.Drawing.Color.Empty;
            this.txtSegment4.LeaveColor = System.Drawing.Color.Empty;
            this.txtSegment4.Location = new System.Drawing.Point(275, 44);
            this.txtSegment4.MaxLength = 2;
            this.txtSegment4.Name = "txtSegment4";
            this.txtSegment4.Size = new System.Drawing.Size(25, 20);
            this.txtSegment4.TabIndex = 4;
            this.txtSegment4.TextChanged += new System.EventHandler(this.txtControls_TextChanged);
            this.txtSegment4.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // lblSegments
            // 
            this.lblSegments.AutoSize = true;
            this.lblSegments.Location = new System.Drawing.Point(25, 50);
            this.lblSegments.Name = "lblSegments";
            this.lblSegments.Size = new System.Drawing.Size(63, 13);
            this.lblSegments.TabIndex = 3;
            this.lblSegments.Text = "Segmentos:";
            // 
            // txtBirthPlace
            // 
            this.txtBirthPlace.AllowBlankSpaces = true;
            this.txtBirthPlace.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtBirthPlace.CharsIncluded = new char[] {
        ' '};
            this.txtBirthPlace.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.AnyCharacter;
            this.txtBirthPlace.CustomExpression = ".*";
            this.txtBirthPlace.EnterColor = System.Drawing.Color.Empty;
            this.txtBirthPlace.LeaveColor = System.Drawing.Color.Empty;
            this.txtBirthPlace.Location = new System.Drawing.Point(152, 77);
            this.txtBirthPlace.MaxLength = 60;
            this.txtBirthPlace.Name = "txtBirthPlace";
            this.txtBirthPlace.Size = new System.Drawing.Size(178, 20);
            this.txtBirthPlace.TabIndex = 5;
            this.txtBirthPlace.TextChanged += new System.EventHandler(this.txtControls_TextChanged);
            this.txtBirthPlace.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // lblBirthPlace
            // 
            this.lblBirthPlace.AutoSize = true;
            this.lblBirthPlace.Location = new System.Drawing.Point(25, 83);
            this.lblBirthPlace.Name = "lblBirthPlace";
            this.lblBirthPlace.Size = new System.Drawing.Size(108, 13);
            this.lblBirthPlace.TabIndex = 3;
            this.lblBirthPlace.Text = "Lugar de Nacimiento:";
            // 
            // txtNumberOfVisa
            // 
            this.txtNumberOfVisa.AllowBlankSpaces = false;
            this.txtNumberOfVisa.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtNumberOfVisa.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.OnlyNumbers;
            this.txtNumberOfVisa.CustomExpression = ".*";
            this.txtNumberOfVisa.EnterColor = System.Drawing.Color.Empty;
            this.txtNumberOfVisa.LeaveColor = System.Drawing.Color.Empty;
            this.txtNumberOfVisa.Location = new System.Drawing.Point(152, 109);
            this.txtNumberOfVisa.MaxLength = 15;
            this.txtNumberOfVisa.Name = "txtNumberOfVisa";
            this.txtNumberOfVisa.Size = new System.Drawing.Size(107, 20);
            this.txtNumberOfVisa.TabIndex = 6;
            this.txtNumberOfVisa.TextChanged += new System.EventHandler(this.txtControls_TextChanged);
            this.txtNumberOfVisa.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // lblNumberOfVisa
            // 
            this.lblNumberOfVisa.AutoSize = true;
            this.lblNumberOfVisa.Location = new System.Drawing.Point(25, 116);
            this.lblNumberOfVisa.Name = "lblNumberOfVisa";
            this.lblNumberOfVisa.Size = new System.Drawing.Size(85, 13);
            this.lblNumberOfVisa.TabIndex = 3;
            this.lblNumberOfVisa.Text = "Numero de Visa:";
            // 
            // txtCityBrodcast
            // 
            this.txtCityBrodcast.AllowBlankSpaces = true;
            this.txtCityBrodcast.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtCityBrodcast.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.AnyCharacter;
            this.txtCityBrodcast.CustomExpression = ".*";
            this.txtCityBrodcast.EnterColor = System.Drawing.Color.Empty;
            this.txtCityBrodcast.LeaveColor = System.Drawing.Color.Empty;
            this.txtCityBrodcast.Location = new System.Drawing.Point(152, 142);
            this.txtCityBrodcast.MaxLength = 30;
            this.txtCityBrodcast.Name = "txtCityBrodcast";
            this.txtCityBrodcast.Size = new System.Drawing.Size(178, 20);
            this.txtCityBrodcast.TabIndex = 7;
            this.txtCityBrodcast.TextChanged += new System.EventHandler(this.txtControls_TextChanged);
            this.txtCityBrodcast.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // lblCityBrodcast
            // 
            this.lblCityBrodcast.AutoSize = true;
            this.lblCityBrodcast.Location = new System.Drawing.Point(25, 149);
            this.lblCityBrodcast.Name = "lblCityBrodcast";
            this.lblCityBrodcast.Size = new System.Drawing.Size(96, 13);
            this.lblCityBrodcast.TabIndex = 3;
            this.lblCityBrodcast.Text = "Ciudad de emisión:";
            // 
            // txtDateBrodcast
            // 
            this.txtDateBrodcast.AllowBlankSpaces = false;
            this.txtDateBrodcast.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtDateBrodcast.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.NumbersOrLetters;
            this.txtDateBrodcast.CustomExpression = ".*";
            this.txtDateBrodcast.EnterColor = System.Drawing.Color.Empty;
            this.txtDateBrodcast.LeaveColor = System.Drawing.Color.Empty;
            this.txtDateBrodcast.Location = new System.Drawing.Point(152, 176);
            this.txtDateBrodcast.MaxLength = 7;
            this.txtDateBrodcast.Name = "txtDateBrodcast";
            this.txtDateBrodcast.Size = new System.Drawing.Size(79, 20);
            this.txtDateBrodcast.TabIndex = 8;
            this.txtDateBrodcast.TextChanged += new System.EventHandler(this.txtControls_TextChanged);
            this.txtDateBrodcast.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // lblDateBrodcast
            // 
            this.lblDateBrodcast.AutoSize = true;
            this.lblDateBrodcast.Location = new System.Drawing.Point(25, 183);
            this.lblDateBrodcast.Name = "lblDateBrodcast";
            this.lblDateBrodcast.Size = new System.Drawing.Size(93, 13);
            this.lblDateBrodcast.TabIndex = 3;
            this.lblDateBrodcast.Text = "Fecha de emisión:";
            // 
            // txtCountryWhereApplicable
            // 
            this.txtCountryWhereApplicable.AllowBlankSpaces = false;
            this.txtCountryWhereApplicable.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtCountryWhereApplicable.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.OnlyLetters;
            this.txtCountryWhereApplicable.CustomExpression = ".*";
            this.txtCountryWhereApplicable.EnterColor = System.Drawing.Color.Empty;
            this.txtCountryWhereApplicable.LeaveColor = System.Drawing.Color.Empty;
            this.txtCountryWhereApplicable.Location = new System.Drawing.Point(152, 210);
            this.txtCountryWhereApplicable.MaxLength = 2;
            this.txtCountryWhereApplicable.Name = "txtCountryWhereApplicable";
            this.txtCountryWhereApplicable.Size = new System.Drawing.Size(55, 20);
            this.txtCountryWhereApplicable.TabIndex = 9;
            this.txtCountryWhereApplicable.TextChanged += new System.EventHandler(this.txtControls_TextChanged);
            this.txtCountryWhereApplicable.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // lblCountryWhereApplicable
            // 
            this.lblCountryWhereApplicable.AutoSize = true;
            this.lblCountryWhereApplicable.Location = new System.Drawing.Point(25, 217);
            this.lblCountryWhereApplicable.Name = "lblCountryWhereApplicable";
            this.lblCountryWhereApplicable.Size = new System.Drawing.Size(97, 13);
            this.lblCountryWhereApplicable.TabIndex = 3;
            this.lblCountryWhereApplicable.Text = "País donde Aplica:";
            // 
            // lblPassengerType
            // 
            this.lblPassengerType.AutoSize = true;
            this.lblPassengerType.Location = new System.Drawing.Point(25, 253);
            this.lblPassengerType.Name = "lblPassengerType";
            this.lblPassengerType.Size = new System.Drawing.Size(90, 13);
            this.lblPassengerType.TabIndex = 3;
            this.lblPassengerType.Text = "Tipo de Pasajero:";
            // 
            // rdoAdult
            // 
            this.rdoAdult.AutoSize = true;
            this.rdoAdult.Location = new System.Drawing.Point(152, 253);
            this.rdoAdult.Name = "rdoAdult";
            this.rdoAdult.Size = new System.Drawing.Size(55, 17);
            this.rdoAdult.TabIndex = 10;
            this.rdoAdult.TabStop = true;
            this.rdoAdult.Text = "&Adulto";
            this.rdoAdult.UseVisualStyleBackColor = true;
            this.rdoAdult.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // rdoBoy
            // 
            this.rdoBoy.AutoSize = true;
            this.rdoBoy.Location = new System.Drawing.Point(221, 253);
            this.rdoBoy.Name = "rdoBoy";
            this.rdoBoy.Size = new System.Drawing.Size(47, 17);
            this.rdoBoy.TabIndex = 11;
            this.rdoBoy.TabStop = true;
            this.rdoBoy.Text = "&Niño";
            this.rdoBoy.UseVisualStyleBackColor = true;
            this.rdoBoy.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // rdoInfant
            // 
            this.rdoInfant.AutoSize = true;
            this.rdoInfant.Location = new System.Drawing.Point(283, 253);
            this.rdoInfant.Name = "rdoInfant";
            this.rdoInfant.Size = new System.Drawing.Size(58, 17);
            this.rdoInfant.TabIndex = 12;
            this.rdoInfant.TabStop = true;
            this.rdoInfant.Text = "&Infante";
            this.rdoInfant.UseVisualStyleBackColor = true;
            this.rdoInfant.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // lblPaxNumber
            // 
            this.lblPaxNumber.AutoSize = true;
            this.lblPaxNumber.Location = new System.Drawing.Point(25, 290);
            this.lblPaxNumber.Name = "lblPaxNumber";
            this.lblPaxNumber.Size = new System.Drawing.Size(71, 13);
            this.lblPaxNumber.TabIndex = 3;
            this.lblPaxNumber.Text = "Num. de Pax:";
            // 
            // txtPaxNumber
            // 
            this.txtPaxNumber.AllowBlankSpaces = false;
            this.txtPaxNumber.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtPaxNumber.CharsIncluded = new char[] {
        '.'};
            this.txtPaxNumber.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.OnlyNumbers;
            this.txtPaxNumber.CustomExpression = ".*";
            this.txtPaxNumber.EnterColor = System.Drawing.Color.Empty;
            this.txtPaxNumber.LeaveColor = System.Drawing.Color.Empty;
            this.txtPaxNumber.Location = new System.Drawing.Point(152, 290);
            this.txtPaxNumber.MaxLength = 4;
            this.txtPaxNumber.Name = "txtPaxNumber";
            this.txtPaxNumber.Size = new System.Drawing.Size(55, 20);
            this.txtPaxNumber.TabIndex = 13;
            this.txtPaxNumber.TextChanged += new System.EventHandler(this.txtControls_TextChanged);
            this.txtPaxNumber.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // btnAccept
            // 
            this.btnAccept.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnAccept.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAccept.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAccept.Location = new System.Drawing.Point(257, 353);
            this.btnAccept.Name = "btnAccept";
            this.btnAccept.Size = new System.Drawing.Size(100, 23);
            this.btnAccept.TabIndex = 14;
            this.btnAccept.Text = "Aceptar";
            this.btnAccept.UseVisualStyleBackColor = false;
            this.btnAccept.Click += new System.EventHandler(this.btnAccept_Click);
            // 
            // lblDateFormat
            // 
            this.lblDateFormat.AutoSize = true;
            this.lblDateFormat.ForeColor = System.Drawing.Color.MediumBlue;
            this.lblDateFormat.Location = new System.Drawing.Point(237, 182);
            this.lblDateFormat.Name = "lblDateFormat";
            this.lblDateFormat.Size = new System.Drawing.Size(64, 13);
            this.lblDateFormat.TabIndex = 3;
            this.lblDateFormat.Text = "DDMMMYY";
            // 
            // ucMessageAPIVisa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.btnAccept);
            this.Controls.Add(this.rdoInfant);
            this.Controls.Add(this.rdoBoy);
            this.Controls.Add(this.rdoAdult);
            this.Controls.Add(this.lblPaxNumber);
            this.Controls.Add(this.lblPassengerType);
            this.Controls.Add(this.lblCountryWhereApplicable);
            this.Controls.Add(this.lblDateFormat);
            this.Controls.Add(this.lblDateBrodcast);
            this.Controls.Add(this.lblCityBrodcast);
            this.Controls.Add(this.lblNumberOfVisa);
            this.Controls.Add(this.lblBirthPlace);
            this.Controls.Add(this.lblSegments);
            this.Controls.Add(this.txtSegment4);
            this.Controls.Add(this.txtSegment3);
            this.Controls.Add(this.txtPaxNumber);
            this.Controls.Add(this.txtCountryWhereApplicable);
            this.Controls.Add(this.txtDateBrodcast);
            this.Controls.Add(this.txtCityBrodcast);
            this.Controls.Add(this.txtNumberOfVisa);
            this.Controls.Add(this.txtBirthPlace);
            this.Controls.Add(this.txtSegment2);
            this.Controls.Add(this.txtSegment1);
            this.Controls.Add(this.lblTitle);
            this.Name = "ucMessageAPIVisa";
            this.Size = new System.Drawing.Size(411, 580);
            this.Load += new System.EventHandler(this.ucMessageAPIVisa_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.Label lblTitle;
        private MyCTS.Forms.UI.SmartTextBox txtSegment1;
        private MyCTS.Forms.UI.SmartTextBox txtSegment2;
        private MyCTS.Forms.UI.SmartTextBox txtSegment3;
        private MyCTS.Forms.UI.SmartTextBox txtSegment4;
        private System.Windows.Forms.Label lblSegments;
        private MyCTS.Forms.UI.SmartTextBox txtBirthPlace;
        private System.Windows.Forms.Label lblBirthPlace;
        private MyCTS.Forms.UI.SmartTextBox txtNumberOfVisa;
        private System.Windows.Forms.Label lblNumberOfVisa;
        private MyCTS.Forms.UI.SmartTextBox txtCityBrodcast;
        private System.Windows.Forms.Label lblCityBrodcast;
        private MyCTS.Forms.UI.SmartTextBox txtDateBrodcast;
        private System.Windows.Forms.Label lblDateBrodcast;
        private MyCTS.Forms.UI.SmartTextBox txtCountryWhereApplicable;
        private System.Windows.Forms.Label lblCountryWhereApplicable;
        private System.Windows.Forms.Label lblPassengerType;
        private System.Windows.Forms.RadioButton rdoAdult;
        private System.Windows.Forms.RadioButton rdoBoy;
        private System.Windows.Forms.RadioButton rdoInfant;
        private System.Windows.Forms.Label lblPaxNumber;
        private MyCTS.Forms.UI.SmartTextBox txtPaxNumber;
        private System.Windows.Forms.Button btnAccept;
        private System.Windows.Forms.Label lblDateFormat;
    }
}
