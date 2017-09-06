namespace MyCTS.Presentation
{
    partial class ucAPISResidenceDestination
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
            this.rdoResidence = new System.Windows.Forms.RadioButton();
            this.rdoDestination = new System.Windows.Forms.RadioButton();
            this.txtCountry = new MyCTS.Forms.UI.SmartTextBox();
            this.txtSegment1 = new MyCTS.Forms.UI.SmartTextBox();
            this.lblSex = new System.Windows.Forms.Label();
            this.lblEmissionCountry = new System.Windows.Forms.Label();
            this.lblSegments = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.txtStreet = new MyCTS.Forms.UI.SmartTextBox();
            this.lblLastName = new System.Windows.Forms.Label();
            this.txtCity = new MyCTS.Forms.UI.SmartTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtState = new MyCTS.Forms.UI.SmartTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtZIP = new MyCTS.Forms.UI.SmartTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtNumberPax = new MyCTS.Forms.UI.SmartTextBox();
            this.lblNumberPax = new System.Windows.Forms.Label();
            this.btnAccept = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // rdoResidence
            // 
            this.rdoResidence.AutoSize = true;
            this.rdoResidence.Location = new System.Drawing.Point(220, 52);
            this.rdoResidence.Name = "rdoResidence";
            this.rdoResidence.Size = new System.Drawing.Size(79, 17);
            this.rdoResidence.TabIndex = 6;
            this.rdoResidence.TabStop = true;
            this.rdoResidence.Text = "&Recidencia";
            this.rdoResidence.UseVisualStyleBackColor = true;
            this.rdoResidence.KeyUp += new System.Windows.Forms.KeyEventHandler(this.rdoResidence_KeyUp);
            this.rdoResidence.CheckedChanged += new System.EventHandler(this.rdoResidence_CheckedChanged);
            this.rdoResidence.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // rdoDestination
            // 
            this.rdoDestination.AutoSize = true;
            this.rdoDestination.Location = new System.Drawing.Point(147, 52);
            this.rdoDestination.Name = "rdoDestination";
            this.rdoDestination.Size = new System.Drawing.Size(61, 17);
            this.rdoDestination.TabIndex = 5;
            this.rdoDestination.TabStop = true;
            this.rdoDestination.Text = "&Destino";
            this.rdoDestination.UseVisualStyleBackColor = true;
            this.rdoDestination.KeyUp += new System.Windows.Forms.KeyEventHandler(this.rdoDestination_KeyUp);
            this.rdoDestination.CheckedChanged += new System.EventHandler(this.rdoDestination_CheckedChanged);
            this.rdoDestination.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // txtCountry
            // 
            this.txtCountry.AllowBlankSpaces = false;
            this.txtCountry.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtCountry.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.OnlyLetters;
            this.txtCountry.CustomExpression = ".*";
            this.txtCountry.EnterColor = System.Drawing.Color.Empty;
            this.txtCountry.LeaveColor = System.Drawing.Color.Empty;
            this.txtCountry.Location = new System.Drawing.Point(147, 72);
            this.txtCountry.MaxLength = 2;
            this.txtCountry.Name = "txtCountry";
            this.txtCountry.Size = new System.Drawing.Size(25, 20);
            this.txtCountry.TabIndex = 7;
            this.txtCountry.TextChanged += new System.EventHandler(this.txtCountry_TextChanged);
            this.txtCountry.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // txtSegment1
            // 
            this.txtSegment1.AllowBlankSpaces = false;
            this.txtSegment1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtSegment1.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.OnlyNumbers;
            this.txtSegment1.CustomExpression = ".*";
            this.txtSegment1.EnterColor = System.Drawing.Color.Empty;
            this.txtSegment1.LeaveColor = System.Drawing.Color.Empty;
            this.txtSegment1.Location = new System.Drawing.Point(147, 27);
            this.txtSegment1.MaxLength = 2;
            this.txtSegment1.Name = "txtSegment1";
            this.txtSegment1.Size = new System.Drawing.Size(25, 20);
            this.txtSegment1.TabIndex = 1;
            this.txtSegment1.TextChanged += new System.EventHandler(this.txtSegment1_TextChanged);
            this.txtSegment1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // lblSex
            // 
            this.lblSex.AutoSize = true;
            this.lblSex.Location = new System.Drawing.Point(3, 56);
            this.lblSex.Name = "lblSex";
            this.lblSex.Size = new System.Drawing.Size(76, 13);
            this.lblSex.TabIndex = 0;
            this.lblSex.Text = "Tipo Domicilio:";
            // 
            // lblEmissionCountry
            // 
            this.lblEmissionCountry.AutoSize = true;
            this.lblEmissionCountry.Location = new System.Drawing.Point(3, 79);
            this.lblEmissionCountry.Name = "lblEmissionCountry";
            this.lblEmissionCountry.Size = new System.Drawing.Size(32, 13);
            this.lblEmissionCountry.TabIndex = 0;
            this.lblEmissionCountry.Text = "País:";
            // 
            // lblSegments
            // 
            this.lblSegments.AutoSize = true;
            this.lblSegments.ForeColor = System.Drawing.Color.DarkCyan;
            this.lblSegments.Location = new System.Drawing.Point(3, 30);
            this.lblSegments.Name = "lblSegments";
            this.lblSegments.Size = new System.Drawing.Size(63, 13);
            this.lblSegments.TabIndex = 0;
            this.lblSegments.Text = "Segmentos:";
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
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Mensaje SSR: APIS Residencia o Destino";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // txtStreet
            // 
            this.txtStreet.AllowBlankSpaces = true;
            this.txtStreet.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtStreet.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.NumbersOrLetters;
            this.txtStreet.CustomExpression = ".*";
            this.txtStreet.EnterColor = System.Drawing.Color.Empty;
            this.txtStreet.LeaveColor = System.Drawing.Color.Empty;
            this.txtStreet.Location = new System.Drawing.Point(147, 100);
            this.txtStreet.MaxLength = 20;
            this.txtStreet.Name = "txtStreet";
            this.txtStreet.Size = new System.Drawing.Size(146, 20);
            this.txtStreet.TabIndex = 8;
            this.txtStreet.TextChanged += new System.EventHandler(this.txtStreet_TextChanged);
            this.txtStreet.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // lblLastName
            // 
            this.lblLastName.AutoSize = true;
            this.lblLastName.Location = new System.Drawing.Point(3, 103);
            this.lblLastName.Name = "lblLastName";
            this.lblLastName.Size = new System.Drawing.Size(33, 13);
            this.lblLastName.TabIndex = 0;
            this.lblLastName.Text = "Calle:";
            // 
            // txtCity
            // 
            this.txtCity.AllowBlankSpaces = true;
            this.txtCity.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtCity.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.NumbersOrLetters;
            this.txtCity.CustomExpression = ".*";
            this.txtCity.EnterColor = System.Drawing.Color.Empty;
            this.txtCity.LeaveColor = System.Drawing.Color.Empty;
            this.txtCity.Location = new System.Drawing.Point(147, 126);
            this.txtCity.MaxLength = 15;
            this.txtCity.Name = "txtCity";
            this.txtCity.Size = new System.Drawing.Size(106, 20);
            this.txtCity.TabIndex = 9;
            this.txtCity.TextChanged += new System.EventHandler(this.txtCity_TextChanged);
            this.txtCity.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 129);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Ciudad:";
            // 
            // txtState
            // 
            this.txtState.AllowBlankSpaces = false;
            this.txtState.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtState.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.OnlyLetters;
            this.txtState.CustomExpression = ".*";
            this.txtState.EnterColor = System.Drawing.Color.Empty;
            this.txtState.LeaveColor = System.Drawing.Color.Empty;
            this.txtState.Location = new System.Drawing.Point(147, 150);
            this.txtState.MaxLength = 2;
            this.txtState.Name = "txtState";
            this.txtState.Size = new System.Drawing.Size(25, 20);
            this.txtState.TabIndex = 10;
            this.txtState.TextChanged += new System.EventHandler(this.txtState_TextChanged);
            this.txtState.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.DarkCyan;
            this.label2.Location = new System.Drawing.Point(3, 157);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(98, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Estado (Solo USA):";
            // 
            // txtZIP
            // 
            this.txtZIP.AllowBlankSpaces = false;
            this.txtZIP.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtZIP.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.OnlyNumbers;
            this.txtZIP.CustomExpression = ".*";
            this.txtZIP.EnterColor = System.Drawing.Color.Empty;
            this.txtZIP.LeaveColor = System.Drawing.Color.Empty;
            this.txtZIP.Location = new System.Drawing.Point(147, 182);
            this.txtZIP.MaxLength = 7;
            this.txtZIP.Name = "txtZIP";
            this.txtZIP.Size = new System.Drawing.Size(106, 20);
            this.txtZIP.TabIndex = 11;
            this.txtZIP.TextChanged += new System.EventHandler(this.txtZIP_TextChanged);
            this.txtZIP.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 185);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(104, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Código Postal o ZIP:";
            // 
            // txtNumberPax
            // 
            this.txtNumberPax.AllowBlankSpaces = false;
            this.txtNumberPax.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtNumberPax.CharsIncluded = new char[] {
        '.'};
            this.txtNumberPax.CurrentCriteria = MyCTS.Forms.UI.SmartTextBox.CriteriaFields.OnlyNumbers;
            this.txtNumberPax.CustomExpression = ".*";
            this.txtNumberPax.EnterColor = System.Drawing.Color.Empty;
            this.txtNumberPax.LeaveColor = System.Drawing.Color.Empty;
            this.txtNumberPax.Location = new System.Drawing.Point(147, 210);
            this.txtNumberPax.MaxLength = 4;
            this.txtNumberPax.Name = "txtNumberPax";
            this.txtNumberPax.Size = new System.Drawing.Size(44, 20);
            this.txtNumberPax.TabIndex = 12;
            this.txtNumberPax.TextChanged += new System.EventHandler(this.txtNumberPax_TextChanged);
            this.txtNumberPax.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackEnterUserControl_KeyDown);
            // 
            // lblNumberPax
            // 
            this.lblNumberPax.AutoSize = true;
            this.lblNumberPax.Location = new System.Drawing.Point(3, 214);
            this.lblNumberPax.Name = "lblNumberPax";
            this.lblNumberPax.Size = new System.Drawing.Size(71, 13);
            this.lblNumberPax.TabIndex = 0;
            this.lblNumberPax.Text = "Num. de Pax:";
            // 
            // btnAccept
            // 
            this.btnAccept.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnAccept.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAccept.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAccept.Location = new System.Drawing.Point(267, 311);
            this.btnAccept.Name = "btnAccept";
            this.btnAccept.Size = new System.Drawing.Size(100, 23);
            this.btnAccept.TabIndex = 13;
            this.btnAccept.Text = "Aceptar";
            this.btnAccept.UseVisualStyleBackColor = false;
            this.btnAccept.Click += new System.EventHandler(this.btnAccept_Click);
            // 
            // ucAPISResidenceDestination
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.txtNumberPax);
            this.Controls.Add(this.lblNumberPax);
            this.Controls.Add(this.btnAccept);
            this.Controls.Add(this.txtZIP);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtState);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtCity);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtStreet);
            this.Controls.Add(this.lblLastName);
            this.Controls.Add(this.rdoResidence);
            this.Controls.Add(this.rdoDestination);
            this.Controls.Add(this.txtCountry);
            this.Controls.Add(this.txtSegment1);
            this.Controls.Add(this.lblSex);
            this.Controls.Add(this.lblEmissionCountry);
            this.Controls.Add(this.lblSegments);
            this.Controls.Add(this.lblTitle);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "ucAPISResidenceDestination";
            this.Size = new System.Drawing.Size(411, 580);
            this.Load += new System.EventHandler(this.ucAPISResidenceDestination_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton rdoResidence;
        private System.Windows.Forms.RadioButton rdoDestination;
        private MyCTS.Forms.UI.SmartTextBox txtCountry;
        private MyCTS.Forms.UI.SmartTextBox txtSegment1;
        private System.Windows.Forms.Label lblSex;
        private System.Windows.Forms.Label lblEmissionCountry;
        private System.Windows.Forms.Label lblSegments;
        internal System.Windows.Forms.Label lblTitle;
        private MyCTS.Forms.UI.SmartTextBox txtStreet;
        private System.Windows.Forms.Label lblLastName;
        private MyCTS.Forms.UI.SmartTextBox txtCity;
        private System.Windows.Forms.Label label1;
        private MyCTS.Forms.UI.SmartTextBox txtState;
        private System.Windows.Forms.Label label2;
        private MyCTS.Forms.UI.SmartTextBox txtZIP;
        private System.Windows.Forms.Label label3;
        private MyCTS.Forms.UI.SmartTextBox txtNumberPax;
        private System.Windows.Forms.Label lblNumberPax;
        private System.Windows.Forms.Button btnAccept;
    }
}
